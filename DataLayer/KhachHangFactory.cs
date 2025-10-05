using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CuahangNongduoc.DataLayer
{
    public class KhachHangFactory
    {
        DataService m_Ds = new DataService();

        public DataTable DanhsachKhachHang(bool loai)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM KHACH_HANG WHERE LOAI_KH = " + loai);
            m_Ds.Load(cmd);

            return m_Ds;
        }
        public DataTable TimHoTen(String hoten, bool loai)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM KHACH_HANG WHERE HO_TEN LIKE '%' + @hoten + '%' AND LOAI_KH = " + loai);
            cmd.Parameters.Add("hoten", SqlDbType.NVarChar).Value = hoten;
            m_Ds.Load(cmd);

            return m_Ds;
        }

        public DataTable TimDiaChi(String diachi, bool loai)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM KHACH_HANG WHERE DIA_CHI LIKE '%' + @diachi + '%' AND LOAI_KH = " + loai);
            cmd.Parameters.Add("diachi", SqlDbType.NVarChar).Value = diachi;
            m_Ds.Load(cmd);

            return m_Ds;
        }

        public DataTable DanhsachKhachHang()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM KHACH_HANG");
            m_Ds.Load(cmd);

            return m_Ds;
        }

        public DataTable LayKhachHang(String id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM KHACH_HANG WHERE ID = @id");
            cmd.Parameters.Add("id", SqlDbType.NVarChar,50).Value = id;
            m_Ds.Load(cmd);
            return m_Ds;
        }

        public DataRow NewRow()
        {
            return m_Ds.NewRow();
        }
        public void Add(DataRow row)
        {
            m_Ds.Rows.Add(row);
        }
        public bool Save()
        {
            return m_Ds.ExecuteNoneQuery() > 0;
        }
    }
}
