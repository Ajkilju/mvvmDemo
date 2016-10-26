using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace caliburnDemo.Services
{
    public class ColorProcessor : IColorProcessor
    {
        private char colorCode;
        private SolidColorBrush color;

        public ColorProcessor()
        {
            colorCode = 'b';
        }

        public SolidColorBrush Color
        {
            get
            {
                return color;
            }
        }

        public void GetStringDifference(string oldString, string newString)
        { 
            if(oldString == null)
            {
                oldString = "";
            }
            if(newString == null)
            {
                newString = "";
            }

            bool IsNewLonger = true;
            var oldStringList = oldString.ToCharArray().ToList();
            var newStringList = newString.ToCharArray().ToList();

            if (oldStringList.Count > newStringList.Count)
            {
                newStringList.Add(' ');
                IsNewLonger = false;
            }
            else if (newStringList.Count > oldStringList.Count)
            {
                oldStringList.Add(' ');
                IsNewLonger = true;
            }

            for (int i = 0; i < newStringList.Count; i++)
            {
                if (newStringList[i].Equals(oldStringList[i]) == false)
                {
                    if (IsNewLonger)
                    {
                        colorCode = newStringList[i];
                        return;
                    }

                    if (i - 1 < 0)
                    {
                        colorCode = oldStringList[i];
                        return;
                    }

                    colorCode = oldStringList[i - 1];
                    return;

                }
            }
            colorCode = 'b';
        }

        public void SetColors()
        {
            var c = Colors.Black;

            if (colorCode == 'q') c = Colors.Aqua;
            else if (colorCode == 'w') c = Colors.White;
            else if (colorCode == 'e') c = Colors.Gold;
            else if (colorCode == 'r') c = Colors.Red;
            else if (colorCode == 't') c = Colors.Tan;
            else if (colorCode == 'y') c = Colors.Yellow;
            else if (colorCode == 'u') c = Colors.Blue;
            else if (colorCode == 'i') c = Colors.Indigo;
            else if (colorCode == 'o') c = Colors.Olive;
            else if (colorCode == 'p') c = Colors.Purple;
            else if (colorCode == 'a') c = Colors.Azure;
            else if (colorCode == 's') c = Colors.Salmon;
            else if (colorCode == 'd') c = Colors.DodgerBlue;
            else if (colorCode == 'f') c = Colors.Firebrick;
            else if (colorCode == 'g') c = Colors.Green;
            else if (colorCode == 'h') c = Colors.Honeydew;
            else if (colorCode == 'j') c = Colors.Lavender;
            else if (colorCode == 'k') c = Colors.Khaki;
            else if (colorCode == 'l') c = Colors.Lavender;
            else if (colorCode == 'z') c = Colors.Teal;
            else if (colorCode == 'x') c = Colors.Gold;
            else if (colorCode == 'c') c = Colors.Cyan;
            else if (colorCode == 'v') c = Colors.Violet;
            //else if (colorCode == 'b') c = Colors.White;
            else if (colorCode == 'n') c = Colors.Navy;
            else if (colorCode == 'm') c = Colors.Magenta;

            color = new SolidColorBrush(c);
        }
    }
}
