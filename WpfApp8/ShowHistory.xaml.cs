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
using System.Windows.Shapes;

namespace WpfApp8
{
    /// <summary>
    /// Interaction logic for ShowHistory.xaml
    /// </summary>
    public partial class ShowHistory : Window
    {
        private List<PurchaseLog> purchaseLogs;
        public ShowHistory(List<PurchaseLog> logs)
        {
            InitializeComponent();
            purchaseLogs = logs;
            UpdateListBox();
        }
        private void UpdateListBox()
        {
            
            LogListBox.ItemsSource = purchaseLogs;
        }
    }
}
