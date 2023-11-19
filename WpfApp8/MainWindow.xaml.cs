using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfApp8
{
    public class Images
    {
        public static string Corona = "corona.png";
        public static string NZS = "nzs.png";
        public static string Xirdalan = "xirdalan.png";
    }
    public class PurchaseLog
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
    }
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private int number = 0;
        private List<Drink> _drinks;
        public List<Drink> Drinks
        {
            get { return _drinks; }
            set
            {
                if (_drinks != value)
                {
                    _drinks = value;
                    OnPropertyChanged(nameof(Drinks));
                }
            }
        }
        private List<PurchaseLog> purchaseLogs = new List<PurchaseLog>();
        private Drink _selectedDrink;
        public Drink SelectedDrink
        {
            get { return _selectedDrink; }
            set
            {
                if (_selectedDrink != value)
                {
                    _selectedDrink = value;
                    OnPropertyChanged(nameof(SelectedDrink));
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            Drinks = new List<Drink>
            {
                new Drink { BeerImageFileName = Images.Corona, Name = "Corona", Price = 3.5, Volume = 0.33 },
                new Drink { BeerImageFileName = Images.NZS, Name = "NZS", Price = 2.5, Volume = 0.5 },
                new Drink { BeerImageFileName = Images.Xirdalan, Name = "Xirdalan", Price = 4.0, Volume = 0.5 }
            };
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void IncreaseButton_Click(object sender, RoutedEventArgs e)
        {
            number++;
            UpdateNumber();
        }

        private void DecreaseButton_Click(object sender, RoutedEventArgs e)
        {
            if(number >0) { number--; }
            
            UpdateNumber();
        }

        private void UpdateNumber()
        {
            NumberTextBlock.Text = number.ToString();
        }
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedDrink = null;
            number = 0;
            UpdateNumber();
            MessageBox.Show("Reset Succsesfuly", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BuyButtonClick(object sender, RoutedEventArgs e)
        {
            if (SelectedDrink != null)
            {
                double totalPrice = SelectedDrink.Price * number;
                PurchaseLog purchaseLog = new PurchaseLog
                {
                    ProductName = SelectedDrink.Name,
                    Quantity = number,
                    TotalPrice = totalPrice
                };

                purchaseLogs.Add(purchaseLog);
                MessageBox.Show("Buy Succsesfuly", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                SelectedDrink = null;
                number = 0;
                UpdateNumber();
            }
        }

        private void ShowHistoryButtonClick(object sender, RoutedEventArgs e)
        {
            ShowHistory historyWindow = new ShowHistory(purchaseLogs);
            historyWindow.Show();
            
        }
    }
}
