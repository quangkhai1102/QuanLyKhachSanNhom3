using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace làm_việc_nhóm_3.all_user_control
{
    public partial class UC_Employee : UserControl
    {
        function fn = new function();
        String query;

        public UC_Employee()
        {
            InitializeComponent();
        }

        private void UC_Employee_Load(object sender, EventArgs e)
        {
            getMaxID();
        }

        // Lấy ID nhân viên lớn nhất và hiển thị
        public void getMaxID()
        {
            query = "select max(IDnhanvien) from Nhanvien";
            DataSet ds = fn.GetData(query);

            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                Int64 so = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                label07.Text = (so + 1).ToString();
            }
        }

        // Sự kiện khi nhấn nút đăng ký
        private void btndki_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu bất kỳ trường nào bị để trống
            if (string.IsNullOrWhiteSpace(txtten1.Text) ||
                string.IsNullOrWhiteSpace(txtsdt.Text) ||
                string.IsNullOrWhiteSpace(txtgtinh.Text) ||
                string.IsNullOrWhiteSpace(txtten.Text) ||
                string.IsNullOrWhiteSpace(txtmk.Text) ||
                string.IsNullOrWhiteSpace(txtmail.Text))
            {
                // Hiển thị thông báo
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhân viên cần đăng ký!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Nếu thông tin hợp lệ, thực hiện thêm nhân viên
            try
            {
                string ten1 = txtten1.Text;
                Int64 sdt = Int64.Parse(txtsdt.Text);
                string gtinh = txtgtinh.Text;
                string ten = txtten.Text;
                string mk = txtmk.Text;
                string email = txtmail.Text;

                query = "insert into Nhanvien (Tennhanvien, Sdt, Gioitinh, Tennguoidung, Matkhau, Email) values " +
                        $"('{ten1}', '{sdt}', '{gtinh}', '{ten}', '{mk}', '{email}')";
                fn.setData(query, "Đăng ký nhân viên thành công!");

                // Xóa toàn bộ dữ liệu trên form
                clearAll();
                getMaxID();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm xóa toàn bộ dữ liệu trên form
        public void clearAll()
        {
            txtten1.Clear();
            txtsdt.Clear();
            txtgtinh.SelectedIndex = -1;
            txtmail.Clear();
            txtten.Clear();
            txtmk.Clear();
        }

        // Xử lý khi chọn tab
        private void la_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (la.SelectedIndex == 1)
            {
                setla(guna2DataGridView2);
            }
            else if (la.SelectedIndex == 2)
            {
                setla(guna2DataGridView6);
            }
        }

        // Hiển thị dữ liệu nhân viên vào DataGridView
        public void setla(DataGridView dgv)
        {
            query = "select * from Nhanvien";
            DataSet ds = fn.GetData(query);
            dgv.DataSource = ds.Tables[0];
        }

        // Xóa nhân viên
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    query = "delete from Nhanvien where IDnhanvien = " + txtID.Text + "";
                    fn.setData(query, "Xóa thành công");

                    // Cập nhật lại danh sách
                    la_SelectedIndexChanged(this, null);
                }
            }
        }

        // Sự kiện khi rời khỏi UserControl
        private void UC_Employee_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
