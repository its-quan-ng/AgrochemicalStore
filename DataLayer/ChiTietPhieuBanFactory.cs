using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CuahangNongduoc.DataLayer
{
    public class ChiTietPhieuBanFactory
    {
        DataService m_Ds = new DataService();

      

        public DataTable LayChiTietPhieuBan(String idPhieuBan)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM CHI_TIET_PHIEU_BAN WHERE ID_PHIEU_BAN = @id");
            cmd.Parameters.Add("id", SqlDbType.NVarChar , 50).Value = idPhieuBan;
            m_Ds.Load(cmd);
            return m_Ds;
        }

        public DataTable LayChiTietPhieuBan(DateTime dtNgayBan)
        {
            SqlCommand cmd = new SqlCommand("SELECT CT.* FROM CHI_TIET_PHIEU_BAN CT INNER JOIN PHIEU_BAN PB ON CT.ID_PHIEU_BAN = PB.ID " +
                    " WHERE PB.NGAY_BAN = @ngayban");
            cmd.Parameters.Add("ngayban", SqlDbType.DateTime).Value = dtNgayBan;
            m_Ds.Load(cmd);
            return m_Ds;
        }

        public DataTable LayChiTietPhieuBan(int thang, int nam)
        {
            SqlCommand cmd = new SqlCommand("SELECT CT.* FROM CHI_TIET_PHIEU_BAN CT INNER JOIN PHIEU_BAN PB ON CT.ID_PHIEU_BAN = PB.ID " +
                    " WHERE MONTH(PB.NGAY_BAN) = @thang AND YEAR(PB.NGAY_BAN)= @nam");
            cmd.Parameters.Add("thang", SqlDbType.Int).Value = thang;
            cmd.Parameters.Add("nam", SqlDbType.Int).Value = nam;
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
            foreach (DataRow row in m_Ds.Rows)
            {
                if (row.RowState == DataRowState.Added)
                {
                    CuahangNongduoc.DataLayer.MaSanPhanFactory.CapNhatSoLuong(Convert.ToString(row["ID_MA_SAN_PHAM"]), -Convert.ToInt32(row["SO_LUONG"]));
                }
            }
            return m_Ds.ExecuteNoneQuery() > 0;
        }
    }
}
