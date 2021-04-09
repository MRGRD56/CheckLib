using System;
using System.Collections.Generic;
using System.Text;

namespace CheckLib
{
    public class OnCheckedEventArgs : EventArgs
    {
        public bool IsChecked { get; set; }

        public OnCheckedEventArgs(bool isChecked)
        {
            IsChecked = isChecked;
        }
    }
}
