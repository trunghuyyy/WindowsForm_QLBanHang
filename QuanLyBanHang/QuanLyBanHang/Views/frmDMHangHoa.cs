using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyBanHang.Dao;
using QuanLyBanHang.Models;

namespace QuanLyBanHang
{
    public partial class frmDMHangHoa : Form
    {
        private ChatLieuDAO chatLieuDao = new ChatLieuDAO();
        private HangHoaDAO hangHoaDao = new HangHoaDAO();
        public frmDMHangHoa()
        {
            InitializeComponent();
        }

        private void frmDMHangHoa_Load(object sender, EventArgs e)
        {
            txtMaHangHoa.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            FillCombobox();
            cbbChatLieu.SelectedIndex = -1;
            LoadDataGridView();
            ResetValues();
        }

        private void FillCombobox()
        {
            cbbChatLieu.DataSource = chatLieuDao.getList();
            cbbChatLieu.DisplayMember = "TenChatLieu";
            cbbChatLieu.ValueMember = "MaChatLieu";
        }
        private void ResetValues()
        {
            txtMaHangHoa.Text = "";
            txtTenHangHoa.Text = "";
            cbbChatLieu.Text = "";
            txtSoLuong.Text = "0";
            txtDonGiaNhap.Text = "0";
            txtDonGiaBan.Text = "0";
            txtSoLuong.Enabled = true;
            txtDonGiaNhap.Enabled = false;
            txtDonGiaBan.Enabled = false;
            txtAnh.Text = "";
            picAnh.Image = null;
            txtGhiChu.Text = "";
        }

        private void LoadDataGridView()
        {
            dgvHang.DataSource = hangHoaDao.getListHang();
            dgvHang.Columns[0].HeaderText = "Mã hàng";
            dgvHang.Columns[1].HeaderText = "Tên hàng";
            dgvHang.Columns[2].HeaderText = "Chất liệu";
            dgvHang.Columns[3].HeaderText = "Số lượng";
            dgvHang.Columns[4].HeaderText = "Đơn giá nhập";
            dgvHang.Columns[5].HeaderText = "Đơn giá bán";
            dgvHang.Columns[6].HeaderText = "Ảnh";
            dgvHang.Columns[7].HeaderText = "Ghi chú";
            dgvHang.Columns[0].Width = 80;
            dgvHang.Columns[1].Width = 140;
            dgvHang.Columns[2].Width = 80;
            dgvHang.Columns[3].Width = 80;
            dgvHang.Columns[4].Width = 100;
            dgvHang.Columns[5].Width = 100;
            dgvHang.Columns[6].Width = 200;
            dgvHang.Columns[7].Width = 300;
            dgvHang.AllowUserToAddRows = false;
            dgvHang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvHang_Click(object sender, EventArgs e)
        {
            string MaChatLieu;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHangHoa.Focus();
                return;
            }
            if (dgvHang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaHangHoa.Text = dgvHang.CurrentRow.Cells["MaHang"].Value.ToString();
            txtTenHangHoa.Text = dgvHang.CurrentRow.Cells["TenHang"].Value.ToString();
            MaChatLieu = dgvHang.CurrentRow.Cells["MaChatLieu"].Value.ToString();
            cbbChatLieu.Text = chatLieuDao.getTenChatLieu(MaChatLieu);
            txtSoLuong.Text = dgvHang.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtDonGiaNhap.Text = dgvHang.CurrentRow.Cells["DonGiaNhap"].Value.ToString();
            txtDonGiaBan.Text = dgvHang.CurrentRow.Cells["DonGiaBan"].Value.ToString();
            txtAnh.Text = hangHoaDao.getAnh(txtMaHangHoa.Text); ;
            picAnh.Image = Image.FromFile(txtAnh.Text);
            txtGhiChu.Text = hangHoaDao.getGhiChu(txtMaHangHoa.Text);
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaHangHoa.Enabled = true;
            txtMaHangHoa.Focus();
            txtSoLuong.Enabled = true;
            txtDonGiaNhap.Enabled = true;
            txtDonGiaBan.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaHangHoa.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHangHoa.Focus();
                return;
            }
            if (txtTenHangHoa.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenHangHoa.Focus();
                return;
            }
            if (cbbChatLieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbChatLieu.Focus();
                return;
            }
            if (txtAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn ảnh minh hoạ cho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnOpen.Focus();
                return;
            }
            if (hangHoaDao.CheckKey(txtMaHangHoa.Text))
            {
                MessageBox.Show("Mã hàng này đã tồn tại, bạn phải chọn mã hàng khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHangHoa.Focus();
                return;
            }
            tblHang hang = new tblHang();
            hang.MaHang = txtMaHangHoa.Text.Trim();
            hang.TenHang = txtTenHangHoa.Text.Trim();
            hang.MaChatLieu = cbbChatLieu.SelectedValue.ToString().Trim();
            hang.SoLuong = Convert.ToSingle(txtSoLuong.Text);
            hang.DonGiaNhap = Convert.ToSingle(txtDonGiaNhap.Text);
            hang.DonGiaBan = Convert.ToSingle(txtDonGiaBan.Text);
            hang.Anh = txtAnh.Text.Trim();
            hang.GhiChu = txtGhiChu.Text.Trim();
            hangHoaDao.insert(hang);
            LoadDataGridView();
            MessageBox.Show("Thêm mới thành công", "Thông báo");
            //ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaHangHoa.Enabled = false;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
                OpenFileDialog dlgOpen = new OpenFileDialog();
                dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
                dlgOpen.FilterIndex = 2;
                dlgOpen.Title = "Chọn ảnh minh hoạ cho sản phẩm";
                if (dlgOpen.ShowDialog() == DialogResult.OK)
                {
                    picAnh.Image = Image.FromFile(dlgOpen.FileName);
                    txtAnh.Text = dlgOpen.FileName;
                }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
                ResetValues();
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnThem.Enabled = true;
                btnBoQua.Enabled = false;
                btnLuu.Enabled = false;
                txtMaHangHoa.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvHang.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaHangHoa.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHangHoa.Focus();
                return;
            }
            if (txtTenHangHoa.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenHangHoa.Focus();
                return;
            }
            if (cbbChatLieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbChatLieu.Focus();
                return;
            }
            if (txtAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải ảnh minh hoạ cho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAnh.Focus();
                return;
            }
            tblHang hangUpdate = hangHoaDao.getListHang().FirstOrDefault(s => s.MaHang == txtMaHangHoa.Text);
            if (hangUpdate != null)
            {
                hangUpdate.TenHang = txtTenHangHoa.Text;
                hangUpdate.MaChatLieu = cbbChatLieu.SelectedValue.ToString();
                hangUpdate.SoLuong = Convert.ToSingle(txtSoLuong.Text);
                hangUpdate.Anh = txtAnh.Text;
                hangUpdate.GhiChu = txtGhiChu.Text;
                hangHoaDao.update(hangUpdate);
                MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo");
                LoadDataGridView();
                ResetValues();
                btnBoQua.Enabled = false;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHang.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaHangHoa.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tblHang hangDel = hangHoaDao.getListHang().FirstOrDefault(s => s.MaHang == txtMaHangHoa.Text);
                if(hangDel != null)
                {
                    hangHoaDao.delete(hangDel);
                    LoadDataGridView();
                    ResetValues();
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if ((txtMaHangHoa.Text == "") && (txtTenHangHoa.Text == "") && (cbbChatLieu.Text == ""))
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<tblHang> listHang = hangHoaDao.search(txtMaHangHoa.Text, txtTenHangHoa.Text, cbbChatLieu.SelectedValue.ToString());
            if (listHang == null)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else 
                MessageBox.Show("Có " + listHang.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvHang.DataSource = listHang;
            ResetValues();
        }

        private void btnHienThiDS_Click(object sender, EventArgs e)
        {
            dgvHang.DataSource = hangHoaDao.getListHang();
        }
    }
}
