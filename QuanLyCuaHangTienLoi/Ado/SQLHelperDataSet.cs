using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangTienLoi.Ado
{
    public class SQLHelperDataSet
    {

        SqlConnection conn;
        public SQLHelperDataSet(string connectionString)
        {
            conn = new SqlConnection(connectionString);
        }

        public SQLHelperDataSet()
        {
        }

        public bool IsConnection
        {
            get
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                return true;
            }
        }

        //Kiểm tra chuỗi cấu hình data LinQ
        public int Check_Config()
        {
            conn = new SqlConnection(Properties.Settings.Default.QL_CUAHANGTIENLOIConnectionString);
            if (Properties.Settings.Default.QL_CUAHANGTIENLOIConnectionString == string.Empty)
                return 1;// Chuỗi cấu hình không tồn tại
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                return 0;// Kết nối thành công chuỗi cấu hình hợp lệ
            }
            catch
            {
                return 2;// Chuỗi cấu hình không phù hợp.
            }
        }
    }
}
