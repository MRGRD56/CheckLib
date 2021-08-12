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
                Checked?.Invoke(this, new CheckedEventArgs(value));
            }
        }

        /// <summary>
        /// Inverts IsChecked value.
        /// </summary>
        /// <returns>IsChecked value after the inverting.</returns>
        public bool Check()
        {
            IsChecked = !IsChecked;
            return IsChecked;
        }

        /// <summary>
        /// Sets IsChecked value.
        /// </summary>
        /// <param name="isChecked"></param>
        /// <returns>IsChecked value after the setting.</returns>
        public bool Check(bool isChecked)
        {
            IsChecked = isChecked;
            return IsChecked;
        }

        public delegate void CheckedEventHandler(object sender, CheckedEventArgs args);

        /// <summary>
        /// Raises when <see cref="IsChecked"/> property changes.
        /// </summary>
        public event CheckedEventHandler Checked;

        public Checkable() { }

        public Checkable(T item, bool isChecked = false, CheckedEventHandler onChecked = null)
        {
            Item = item;
            IsChecked = isChecked;
            if (onChecked != null)
            {
                Checked += onChecked;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
