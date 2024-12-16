using làm_việc_nhóm_3.all_user_control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace làm_việc_nhóm_3
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void dashboard_Load(object sender, EventArgs e)
        {
            picture1.Visible = true;
            uc_addroom1.Visible = false;
            uc_register1.Visible = false;
            uC_CustomerDetails1.Visible = false;
            uC_Employee1.Visible = false;
            uc_checkout1.Visible = false;
            

            picture1.BringToFront();

        }
        private void btnaddroom_Click(object sender, EventArgs e)
        {
            panelmoving.Left = btnaddroom.Left + 60;
            uc_addroom1.Visible = true;
            uc_addroom1.BringToFront();
        }

        private void btncr_Click(object sender, EventArgs e)
        {
            panelmoving.Left = btncr.Left + 70;
            uc_register1.Visible = true;
            uc_register1.BringToFront();
        }

        private void btncd_Click(object sender, EventArgs e)
        {
            panelmoving.Left = btncd.Left + 60;
            uC_CustomerDetails1.Visible = true;
            uC_CustomerDetails1.BringToFront();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            panelmoving.Left = btnEmployee.Left + 60;
            uC_Employee1.Visible = true;
            uC_Employee1.BringToFront();
        }

        private void btncheckout_Click(object sender, EventArgs e)
        {
            panelmoving.Left = btncheckout.Left + 60;
            uc_checkout1.Visible = true;
            uc_checkout1.BringToFront();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            panelmoving.Left = guna2Button1.Left + 60;
            picture1.Visible = true;
            picture1.BringToFront();
        }
    }
}
