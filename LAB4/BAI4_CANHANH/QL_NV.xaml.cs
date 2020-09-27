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
using System.Windows.Shapes;

namespace BAI4_CANHANH
{
    /// <summary>
    /// Interaction logic for QL_NV.xaml
    /// </summary>
    public partial class QL_NV : Window
    {
        string maNV;
        void loadData()
        {
            NV_ALGORITHM nv = new NV_ALGORITHM();
            foreach (var i in nv.getNV())
            {
                dataTable.Items.Add(i);
            }
        }
        public QL_NV()
        {
            InitializeComponent();
        }
        public QL_NV(string maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            loadData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NV_ALGORITHM nv = new NV_ALGORITHM();
                if (string.IsNullOrEmpty(txtNV.Text)
                    || string.IsNullOrEmpty(txtTen.Text)
                    || string.IsNullOrEmpty(txtEmail.Text)
                    || string.IsNullOrEmpty(txtLuong.Text)
                    || string.IsNullOrEmpty(txtUsername.Text)
                    || string.IsNullOrEmpty(passwordBox.Password))
                {
                    throw new Exception("String empty");
                }
                nv.insert_NV(txtNV.Text, txtTen.Text, txtEmail.Text, txtLuong.Text, txtUsername.Text, passwordBox.Password);
                dataTable.Items.Clear();
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void xoaBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNV.Text)) throw new Exception("String empty");
                using (QLSV_CANHANEntities db = new QLSV_CANHANEntities())
                {
                    var temp = (from p in db.NHANVIENs
                                where txtNV.Text == p.MANV
                                select p).SingleOrDefault();
                    db.NHANVIENs.Remove(temp);
                    db.SaveChanges();
                }
                dataTable.Items.Clear();
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void suaBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNV.Text)
                    || string.IsNullOrEmpty(txtTen.Text)
                    || string.IsNullOrEmpty(txtEmail.Text)
                    || string.IsNullOrEmpty(txtLuong.Text)
                    || string.IsNullOrEmpty(txtUsername.Text)
                    || string.IsNullOrEmpty(passwordBox.Password)) throw new Exception("String empty");
                NV_ALGORITHM.update_NV(txtNV.Text, txtTen.Text, txtEmail.Text, txtLuong.Text, txtUsername.Text, passwordBox.Password);
                dataTable.Items.Clear();
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void DataTable_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DataGrid row = sender as DataGrid;
                dynamic selected = row.SelectedItem;
                dynamic intId = selected.MANV;
                String id = intId.ToString();
                if (id != null)
                {
                    using (QLSV_CANHANEntities db = new QLSV_CANHANEntities())
                    {
                        var temp = db.FIND_NV(id);
                        foreach (var i in temp)
                        {
                            txtNV.Text = i.MANV;
                            txtTen.Text = i.HOTEN;
                            txtEmail.Text = i.EMAIL;
                            txtLuong.Text = NV_ALGORITHM.getLuong(i.LUONG);
                            txtUsername.Text = i.TENDN;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

    }
}
