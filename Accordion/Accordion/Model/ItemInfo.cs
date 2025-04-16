using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accordion
{
    public class ItemInfo : INotifyPropertyChanged
    {
        #region Fields

        private Color headerColor = Colors.Transparent;
        #endregion

        #region Properties
        public string? Name { get; set; }
        public string? Description { get; set; }

        public Color HeaderColor
        {
            get { return headerColor; }
            set
            {
                headerColor = value;
                this.OnPropertyChanged("HeaderColor");
            }
        }
        #endregion

        #region Interface

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
