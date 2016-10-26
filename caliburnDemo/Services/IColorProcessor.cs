using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace caliburnDemo.Services
{
    public interface IColorProcessor
    {
        SolidColorBrush Color { get; }
        void GetStringDifference(string oldString, string newString);
        void SetColors();
    }
}
