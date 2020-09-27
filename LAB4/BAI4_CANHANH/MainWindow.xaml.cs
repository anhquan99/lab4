using BAI4_CANHANH.ENCRYPT_DECRYPT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BAI4_CANHANH
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            using (QLSV_CANHANEntities db = new QLSV_CANHANEntities())
            {
                SHA1Managed sha1 = new SHA1Managed();
                var hashMatKhau = sha1.ComputeHash(Encoding.UTF8.GetBytes(Password.Password));
                StringBuilder buildMK = new StringBuilder();
                foreach (var i in hashMatKhau)
                {
                    buildMK.Append(i.ToString());
                }
                var temp = db.LOGIN_NV(Username.Text, buildMK.ToString()).ToList();
                if (temp.Count() > 0)
                {
                    string maNV = "";
                    foreach (var i in temp)
                    {
                        maNV = i.MANV;
                        break;
                    }
                    QL_NV ql = new QL_NV(maNV);
                    ql.Show();
                    this.Close();
                    return;
                }
                var tempSV = db.LOGIN_SV(Username.Text, buildMK.ToString()).ToList();
                if (tempSV.Count() > 0)
                {
                    string maNV = "";
                    foreach (var i in tempSV)
                    {
                        maNV = i.MASV;
                        break;
                    }
                    QL_NV ql = new QL_NV(maNV);
                    ql.Show();
                    this.Close();
                    return;
                }
            }
        }
    }
}
