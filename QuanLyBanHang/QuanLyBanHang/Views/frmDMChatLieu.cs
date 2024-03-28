using QuanLyBanHang.Dao;
using QuanLyBanHang.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmDMChatLieu : Form
    {
        private BanHangDBContext context = new BanHangDBContext();
        private ChatLieuDAO chatlieuDAO = new ChatLieuDAO();
        string flag = null;
        public frmDMChatLieu()
        {
            InitializeComponent();
        }

        private void frmDMChatLieu_Load(object sender, EventArgs e)
        {
            txtMaChatLieu.Enabled = false;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            loadDataGridView(); // Hiển thị bảng chất liệu
        }

        private void loadDataGridView()
        {
            dgvChatLieu.DataSource = chatlieuDAO.getList();
            dgvChatLieu.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvChatLieu.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        private void dgvChatLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                if(index >= 0)
                {
                    txtMaChatLieu.Text = dgvChatLieu.Rows[index].Cells["MaChatLieu"].Value.ToString(); 
                    txtTenChatLieu.Text = dgvChatLieu.Rows[index].Cells["TenChatLieu"].Value.ToString();
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnBoQua.Enabled = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Thông báo");
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = "them";
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue(); //Xoá trắng các textbox
            txtMaChatLieu.Enabled = true; //cho phép nhập mới
            txtMaChatLieu.Focus();
        }

        private void ResetValue()
        {
            txtMaChatLieu.Text = ""; 
            txtTenChatLieu.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = "sua";
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            txtMaChatLieu.Enabled = false; //cho phép nhập mới
            txtMaChatLieu.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaChatLieu.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
                {
                    MessageBox.Show("Bạn phải nhập mã chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaChatLieu.Focus();
                    return;
                }
                if (txtTenChatLieu.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
                {
                    MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenChatLieu.Focus();
                    return;
                }
                tblChatLieu chatLieu = new tblChatLieu();
                chatLieu.MaChatLieu = txtMaChatLieu.Text;
                chatLieu.TenChatLieu = txtTenChatLieu.Text;
                switch(flag)
                {
                    case "them":
                        {
                            chatlieuDAO.insert(chatLieu);
                            MessageBox.Show("Thêm mới thành công", "Thông báo");
                            break;
                        }
                    case "sua":
                        {
                            chatlieuDAO.update(chatLieu);
                            MessageBox.Show("Cập nhập thành công", "Thông báo");
                            break;
                        }
                }
                loadDataGridView();
                btnXoa.Enabled = true;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnBoQua.Enabled = false;
                btnLuu.Enabled = false;
                txtMaChatLieu.Enabled = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvChatLieu.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaChatLieu.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string machatlieu = txtMaChatLieu.Text;
                chatlieuDAO.delete(machatlieu);
                loadDataGridView();
                ResetValue();
                MessageBox.Show("Xóa thành công", "Thông báo");
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaChatLieu.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
