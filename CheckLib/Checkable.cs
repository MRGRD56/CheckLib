using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CheckLib
{
    /// <summary>
    /// Represents an item can be checked and unchecked.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Checkable<T> : INotifyPropertyChanged
    {
        private bool _isChecked;

        public T Item { get; set; }

        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                if (value == _isChecked) return;
                _isChecked = value;
                OnPropertyChanged();
                Checked?.Invoke(this, new OnCheckedEventArgs(value));
            }
        }

        public delegate void OnCheckedEventHandler(object sender, OnCheckedEventArgs args);

        /// <summary>
        /// Raises when <see cref="IsChecked"/> property changes.
        /// </summary>
        public event OnCheckedEventHandler Checked;

        public Checkable() { }

        public Checkable(T item, bool isChecked = false, OnCheckedEventHandler @checked = null)
        {
            Item = item;
            IsChecked = isChecked;
            if (@checked != null)
            {
                Checked += @checked;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
