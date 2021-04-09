using CheckLib.Additional;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckLib
{
    /// <summary>
    /// Represents an item you can check and uncheck. Can be used with checkboxes.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Checkable<T> : NotifyPropertyChanged
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
                OnChecked?.Invoke(this, new OnCheckedEventArgs(value));
            }
        }

        public delegate void OnCheckedEventHandler(object sender, OnCheckedEventArgs args);

        /// <summary>
        /// Raises when <see cref="IsChecked"/> property changes.
        /// </summary>
        public event OnCheckedEventHandler OnChecked;

        public Checkable() { }

        public Checkable(T item, bool isChecked = false, OnCheckedEventHandler onChecked = null)
        {
            Item = item;
            IsChecked = isChecked;
            if (onChecked != null)
            {
                OnChecked += onChecked;
            }
        }
    }
}
