using System;
using System.Collections.Generic;
using System.Text;

namespace CheckLib
{
    public class CheckedEventArgs : EventArgs
    {
        public bool IsChecked { get; set; }

        public CheckedEventArgs(bool isChecked)
        {
            IsChecked = isChecked;
        }
    }
}
