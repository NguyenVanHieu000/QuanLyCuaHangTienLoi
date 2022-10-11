using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangTienLoi.Ado;
using BLL_DAL;

namespace QuanLyCuaHangTienLoi.View
{
    public partial class frmError : DevExpress.XtraEditors.XtraForm
    {
        Ado.QL_DangNhap CauHinh = new Ado.QL_DangNhap();
        public frmError()
        {
            InitializeComponent();
        }

        private void cbo_servername_DropDown(object sender, EventArgs e)
        {
            cbo_servername.DataSource = CauHinh.GetServerName();
            cbo_servername.DisplayMember = "ServerName";
        }

        private void cbo_database_DropDown(object sender, EventArgs e)
        {
            cbo_database.DataSource = CauHinh.GetDBName(cbo_servername.Text, txt_username.Text, txt_password.Text);
            cbo_database.DisplayMember = "name";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string connectionString = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};", cbo_servername.Text, cbo_database.Text, txt_username.Text, txt_password.Text);
            try
            {
                SQLHelper helper = new SQLHelper(connectionString);
                SQLHelperDataSet dataSet = new SQLHelperDataSet(connectionString);
                if (helper.IsConnection && dataSet.IsConnection)
                {
                    AppSetting setting = new AppSetting();
                    AppSettingDataSet settingDataSet = new AppSettingDataSet();
                    QL_DangNhap qL_DangNhap = new QL_DangNhap();
                    setting.SaveConnectionString("BLL_DAL.Properties.Settings.QL_CUAHANGTIENLOIConnectionString", connectionString);
                    settingDataSet.SaveConnectionString("QuanLyCuaHangTienLoi.Properties.Settings.QL_CUAHANGTIENLOIConnectionString", connectionString);
                    //qL_DangNhap.SaveConfig(cbo_servername.Text, txt_username.Text, txt_password.Text, cbo_database.Text);
                    MessageBox.Show("Your connection string has been successfully save.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Restart();
                    Environment.Exit(0);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pdfViewer1_Load(object sender, EventArgs e)
        {

        }

       
    }
}
