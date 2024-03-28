using QuanLyBanHang.Dao;
using QuanLyBanHang.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmHoaDonBan : Form
    {
        private HangHoaDAO hhdao = new HangHoaDAO();
        private NhanVienDAO nvdao = new NhanVienDAO();
        private CTHDDAO cthddao = new CTHDDAO();
        private KhachHangDAO khdao = new KhachHangDAO();
        private HoaDonDAO hddao = new HoaDonDAO();
        public frmHoaDonBan()
        {
            InitializeComponent();
        }

        private void frmHoaDonBan_Load(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            //btnXoa.Enabled = false;
            txtMaHDBan.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            mtbDienThoai.ReadOnly = true;
            txtTenHang.ReadOnly = true;
            txtDonGiaBan.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            //txtTongTien.ReadOnly = true;
            txtGiamGia.Text = "0";
            txtTongTien.Text = "0";

            // Đổ dữ liệu lên combobox hàng hóa
            cboMaHang.DataSource = hhdao.getListHang();
            cboMaHang.DisplayMember = "TenHang";
            cboMaHang.ValueMember = "MaHang";
            cboMaHang.SelectedIndex = -1;

            // Đổ dữ liệu lên combobox nhân viên
            cboMaNhanVien.DataSource = nvdao.getListNV();
            cboMaNhanVien.DisplayMember = "TenNhanVien";
            cboMaNhanVien.ValueMember = "MaNhanVien";
            cboMaNhanVien.SelectedIndex = -1;

            // Đổ dữ liệu lên combobox khách hàng
            cboMaKhach.DataSource = khdao.getListKH();
            cboMaKhach.DisplayMember = "TenKhach";
            cboMaKhach.ValueMember = "MaKhach";
            cboMaKhach.SelectedIndex = -1;

            //Hiển thị thông tin của một hóa đơn được gọi từ form tìm kiếm
            if (txtMaHDBan.Text != "")
            {
                LoadInfoHoaDon();
            }
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            dgvHDBanHang.DataSource = cthddao.getListCTHDSanPhamByMaHD(txtMaHDBan.Text);
            dgvHDBanHang.Columns[0].HeaderText = "Mã hàng";
            dgvHDBanHang.Columns[1].HeaderText = "Tên hàng";
            dgvHDBanHang.Columns[2].HeaderText = "Số lượng";
            dgvHDBanHang.Columns[3].HeaderText = "Đơn giá";
            dgvHDBanHang.Columns[4].HeaderText = "Giảm giá %";
            dgvHDBanHang.Columns[5].HeaderText = "Thành tiền";
            dgvHDBanHang.Columns[0].Width = 80;
            dgvHDBanHang.Columns[1].Width = 170;
            dgvHDBanHang.Columns[2].Width = 80;
            dgvHDBanHang.Columns[3].Width = 90;
            dgvHDBanHang.Columns[4].Width = 90;
            dgvHDBanHang.Columns[5].Width = 90;
            dgvHDBanHang.AllowUserToAddRows = false;
            dgvHDBanHang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void LoadInfoHoaDon()
        {
            tblHDBan hdon = hddao.getInfoHDbyMaHD(txtMaHDBan.Text);
            dtpNgayBan.Text = hdon.NgayBan.ToString();
            cboMaNhanVien.SelectedValue = hdon.MaNhanVien;
            cboMaKhach.SelectedValue = hdon.MaKhach;
            txtTongTien.Text = hdon.TongTien.ToString();
            lblBangChu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(Convert.ToDouble(txtTongTien.Text));
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaHDBan.Text = Functions.CreateKey("HDB");
            LoadDataGridView();
        }

        private void ResetValues()
        {
            txtMaHDBan.Text = "";
            dtpNgayBan.Text = DateTime.Now.ToShortDateString();
            cboMaNhanVien.Text = "";
            cboMaKhach.Text = "";
            txtTongTien.Text = "0";
            lblBangChu.Text = "Bằng chữ: ";
            cboMaHang.Text = "";
            txtSoLuong.Text = "";
            txtGiamGia.Text = "0";
            txtThanhTien.Text = "0";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            double sl, SLcon, tong, Tongmoi;
            if (!hddao.checkKey(txtMaHDBan.Text))
            {
                // Mã hóa đơn chưa có, tiến hành lưu các thông tin chung
                // Mã HDBan được sinh tự động do đó không có trường hợp trùng khóa
                if (dtpNgayBan.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập ngày bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpNgayBan.Focus();
                    return;
                }
                if (cboMaNhanVien.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMaNhanVien.Focus();
                    return;
                }
                if (cboMaKhach.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMaKhach.Focus();
                    return;
                }
                tblHDBan hdonBan = new tblHDBan();
                hdonBan.MaHDBan = txtMaHDBan.Text.Trim();
                hdonBan.NgayBan = dtpNgayBan.Value;
                hdonBan.MaNhanVien = cboMaNhanVien.SelectedValue.ToString();
                hdonBan.MaKhach = cboMaKhach.SelectedValue.ToString();
                hdonBan.TongTien = Convert.ToSingle(txtThanhTien.Text);
                hddao.insert(hdonBan);
                txtTongTien.Text = txtThanhTien.Text;
                lblBangChu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(Convert.ToDouble(txtThanhTien.Text));
            }
            else
            {
                // Cập nhật lại tổng tiền cho hóa đơn bán
                tong = hddao.getTongTienHDBan(txtMaHDBan.Text);
                Tongmoi = tong + Convert.ToDouble(txtThanhTien.Text);
                tblHDBan hdUpdate = hddao.getListHDBan().FirstOrDefault(s => s.MaHDBan == txtMaHDBan.Text);
                hdUpdate.TongTien = Tongmoi;
                hddao.update(hdUpdate);
                txtTongTien.Text = Tongmoi.ToString();
                lblBangChu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(Convert.ToDouble(Tongmoi.ToString()));
            }
            // Lưu thông tin của các mặt hàng
            if (cboMaHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaHang.Focus();
                return;
            }
            if ((txtSoLuong.Text.Trim().Length == 0) || (txtSoLuong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Text = "";
                txtSoLuong.Focus();
                return;
            }
            if (txtGiamGia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiamGia.Focus();
                return;
            }
            if (cthddao.checkKey(cboMaHang.SelectedValue.ToString(), txtMaHDBan.Text))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValuesHang();
                cboMaHang.Focus();
                return;
            }
            // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?
            sl = hhdao.getSLTon(cboMaHang.SelectedValue.ToString());
            if (Convert.ToDouble(txtSoLuong.Text) > sl)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Text = "";
                txtSoLuong.Focus();
                return;
            }
            tblCTHDBan cthdBan = new tblCTHDBan();
            cthdBan.MaHDBan = txtMaHDBan.Text;
            cthdBan.MaHang = cboMaHang.SelectedValue.ToString();
            cthdBan.SoLuong = Convert.ToDouble(txtSoLuong.Text);
            cthdBan.DonGia = Convert.ToDouble(txtDonGiaBan.Text);
            cthdBan.GiamGia = Convert.ToDouble(txtGiamGia.Text);
            cthdBan.ThanhTien = Convert.ToDouble(txtThanhTien.Text);
            cthddao.insert(cthdBan);
            LoadDataGridView();

            // Cập nhật lại số lượng của mặt hàng vào bảng tblHang
            SLcon = sl - Convert.ToDouble(txtSoLuong.Text);
            tblHang slHangUpdate = hhdao.getListHang().FirstOrDefault(s => s.MaHang == cboMaHang.SelectedValue.ToString());
            if (slHangUpdate != null)
            {
                slHangUpdate.SoLuong = SLcon;
                hhdao.update(slHangUpdate);
            }
            
            ResetValuesHang();
            btnThem.Enabled = true;
        }

        private void ResetValuesHang()
        {
            cboMaHang.Text = "";
            txtSoLuong.Text = "";
            txtGiamGia.Text = "0";
            txtThanhTien.Text = "0";
            txtTenHang.Text = "";
            txtDonGiaBan.Text = "";
        }

        private void cboMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaHang.SelectedValue != null)
            {
                tblHang hang = hhdao.getListHang().FirstOrDefault(s => s.MaHang == cboMaHang.SelectedValue.ToString());
                if (hang != null)
                {
                    txtTenHang.Text = hang.TenHang;
                    txtDonGiaBan.Text = hang.DonGiaBan.ToString();
                }
            }
        }

        private void cboMaKhach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboMaKhach.SelectedValue != null)
            {
                tblKhach khach = khdao.getListKH().FirstOrDefault(s=> s.MaKhach == cboMaKhach.SelectedValue.ToString());
                if(khach != null)
                {
                    txtDiaChi.Text = khach.DiaChi;
                    mtbDienThoai.Text = khach.DienThoai;
                }
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi số lượng thì thực hiện tính lại thành tiền
            double tt, sl, dg, gg;
            if (txtSoLuong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoLuong.Text);
            if (txtGiamGia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamGia.Text);
            if (txtDonGiaBan.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDonGiaBan.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhTien.Text = tt.ToString();
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi giảm giá thì tính lại thành tiền
            double tt, sl, dg, gg;
            if (txtSoLuong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoLuong.Text);
            if (txtGiamGia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamGia.Text);
            if (txtDonGiaBan.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDonGiaBan.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhTien.Text = tt.ToString();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboMaHD_DropDown(object sender, EventArgs e)
        {
            cboMaHDBan.DataSource = hddao.getListHDBan();
            cboMaHDBan.DisplayMember = "MaHDBan";
            cboMaHDBan.ValueMember = "MaHDBan";
            cboMaHDBan.SelectedIndex = -1;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cboMaHDBan.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaHDBan.Focus();
                return;
            }
            txtMaHDBan.Text = cboMaHDBan.Text;
            LoadInfoHoaDon();
            LoadDataGridView();
            btnLuu.Enabled = true;
            cboMaHDBan.SelectedIndex = -1;
        }
    }
}
