using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BAI4_CANHANH.ENCRYPT_DECRYPT
{
    class SV_ALGORITHM
    {
        public void insertSV(string maSV, string hoTen, string ngaySinh, string diaChi, string maLop, string tenDN, string matKhau)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(Encoding.UTF8.GetBytes(matKhau));
            byte[] hashMatKhau = md5.Hash;
            StringBuilder buildMK = new StringBuilder();
            for (int i = 0; i < hashMatKhau.Length; i++)
            {
                buildMK.Append(hashMatKhau[i].ToString());
            }
            string finalMK = buildMK.ToString();
            using (QLSV_CANHANEntities db = new QLSV_CANHANEntities())
            {
                DateTime ngaySinhDate = Convert.ToDateTime(ngaySinh);
                db.SP_INS_ENCRYPT_SINHVIEN(maSV, hoTen, ngaySinhDate, diaChi, maLop, tenDN, finalMK);
            }
        }
    }
}
