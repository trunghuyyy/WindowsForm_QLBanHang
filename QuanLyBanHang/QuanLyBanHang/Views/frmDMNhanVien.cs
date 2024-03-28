using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanHang.Dao;
using QuanLyBanHang.Models;

namespace QuanLyBanHang
{
    public partial class frmDMNhanVien : Form
    {
        private NhanVienDAO nvDao = new NhanVienDAO();
        public frmDMNhanVien()
        {
            InitializeComponent();
        }

        private void frmDMNhanVien_Load(object sender, EventArgs e)
        {
            txtMaNV.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            dgvNhanVien.DataSource = nvDao.getListNV();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaNV.Enabled = true;
            txtMaNV.Focus();
        }

        private void ResetValues()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            cbGioiTinh.Checked = false;
            txtDiaChi.Text = "";
            dtpNgaySinh.Text = "";
            mtbDienThoai.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string gt;
            if (txtMaNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return;
            }
            if (txtTenNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNV.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }
            if (mtbDienThoai.Text == "(   )     -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtbDienThoai.Focus();
                return;
            }
            if (dtpNgaySinh.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaySinh.Focus();
                return;
            }
            if (!Functions.IsDate(dtpNgaySinh.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // mskNgaySinh.Text = "";
                dtpNgaySinh.Focus();
                return;
            }
            if (cbGioiTinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            tblNhanVien vninsert = new tblNhanVien();
            vninsert.MaNhanVien = txtMaNV.Text.Trim();
            vninsert.TenNhanVien = txtTenNV.Text.Trim();
            vninsert.GioiTinh = gt;
            vninsert.NgaySinh = dtpNgaySinh.Value;
            vninsert.DiaChi = txtDiaChi.Text.Trim();
            vninsert.DienThoai = mtbDienThoai.Text;
            nvDao.insert(vninsert);
            MessageBox.Show("Thêm mới thành công");
            LoadDataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaNV.Enabled = false;
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                if (index >= 0)
                {
                    if (btnThem.Enabled == false)
                    {
                        MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMaNV.Focus();
                        return;
                    }
                    if (dgvNhanVien.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    txtMaNV.Text = dgvNhanVien.Rows[index].Cells["MaNhanVien"].Value.ToString();
                    txtTenNV.Text = dgvNhanVien.Rows[index].Cells["TenNhanVien"].Value.ToString();
                    if (dgvNhanVien.Rows[index].Cells["GioiTinh"].Value.ToString() == "Nam") 
                        cbGioiTinh.Checked = true;
                    else 
                        cbGioiTinh.Checked = false;
                    txtDiaChi.Text = dgvNhanVien.Rows[index].Cells["DiaChi"].Value.ToString();
                    mtbDienThoai.Text = dgvNhanVien.Rows[index].Cells["DienThoai"].Value.ToString();
                    dtpNgaySinh.Text = dgvNhanVien.Rows[index].Cells["NgaySinh"].Value.ToString();
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnXoa.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string gt;
            if (dgvNhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNV.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }
            if (mtbDienThoai.Text == "(   )     -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtbDienThoai.Focus();
                return;
            }
            if (dtpNgaySinh.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaySinh.Focus();
                return;
            }
            if (!Functions.IsDate(dtpNgaySinh.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaySinh.Text = "";
                dtpNgaySinh.Focus();
                return;
            }
            if (cbGioiTinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";

            tblNhanVien nvupdate = nvDao.getListNV().FirstOrDefault(s => s.MaNhanVien == txtMaNV.Text);
            nvupdate.TenNhanVien = txtTenNV.Text.Trim();
            nvupdate.GioiTinh = gt;
            nvupdate.NgaySinh = dtpNgaySinh.Value;
            nvupdate.DiaChi = txtDiaChi.Text.Trim();
            nvupdate.DienThoai = mtbDienThoai.Text;
            nvDao.update(nvupdate);
            LoadDataGridView();
            ResetValues();
            btnBoQua.Enabled = false;
            MessageBox.Show("Cập nhật thông tin nhân viên thành công");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                tblNhanVien nvdelete = nvDao.getListNV().FirstOrDefault(s => s.MaNhanVien == txtMaNV.Text);
                if(nvdelete != null)
                {
                    nvDao.delete(nvdelete);
                    LoadDataGridView();
                    ResetValues();
                    MessageBox.Show("Xóa thành công");
                }
               
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaNV.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
