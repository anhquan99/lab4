using BAI4_CANHANH.ENCRYPT_DECRYPT;
using System;
using System.Collections.Generic;
using System.Linq;
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
            NV_ALGORITHM nv = new NV_ALGORITHM();
            //nv.insert_NV("NV1", "NHAN VIEN 1", "NV@NV1", "1000", "NV1", "PASSWORD");
            nv.getNV();
        }
    }
}
