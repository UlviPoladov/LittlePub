using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp8
{
    public class Drink : INotifyPropertyChanged
    {
        private string _beerImageFileName;

        public string BeerImageFileName
        {
            get { return _beerImageFileName; }
            set
            {
                if (_beerImageFileName != value)
                {
                    _beerImageFileName = value;
                    OnPropertyChanged(nameof(BeerImageFileName));
                    OnPropertyChanged(nameof(FullImagePath));
                }
            }
        }

        public string FullImagePath => $"../Images/{BeerImageFileName}";

        public string Name { get; set; }
        public double Price { get; set; }
        public double Volume { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
