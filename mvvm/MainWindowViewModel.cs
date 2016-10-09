using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace mvvm
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly MainWindowModel _model;
        private char colorCode;
        private SolidColorBrush _colorCanvas;
        private string _colorTextBlock;

        public MainWindowViewModel()
        {
            _model = new MainWindowModel();
            _model.ColorTextBox = "ColorTextBox";
            _model.ColorCanvas  = new SolidColorBrush(Colors.Black);
            colorCode = 'b';
        }

        public string ColorTextBox
        {
            get
            {
                return _model.ColorTextBox;
            }

            set
            {
                colorCode = GetStringDifference(_model.ColorTextBox, value);
                _model.ColorTextBox = value;
                OnPropertyChanged("ColorTextBox");
                SetColors();
                ColorTextBlockUpdate();
                ColorCanvasUpdate();
            }
        }

        public string ColorTextBlock
        {
            get
            {
                return _model.ColorTextBlock;
            }

            set
            {
                _model.ColorTextBlock = value;
                OnPropertyChanged("ColorTextBlock");
            }
        }

        public SolidColorBrush ColorCanvas
        {
            get
            {
                return _model.ColorCanvas;
            }

            set
            {
                _model.ColorCanvas = value;
                OnPropertyChanged("ColorCanvas");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ColorTextBlockUpdate()
        {
            ColorTextBlock = _colorTextBlock;
        }

        private void ColorCanvasUpdate()
        {
            ColorCanvas = _colorCanvas;
        }

        private char GetStringDifference(string oldString, string newString)
        {
            bool IsNewLonger = true;
            var oldStringList = oldString.ToCharArray().ToList();
            var newStringList = newString.ToCharArray().ToList();

            if(oldStringList.Count > newStringList.Count)
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
                if(newStringList[i].Equals(oldStringList[i]) == false)
                {
                    if (IsNewLonger)
                    {
                        return newStringList[i];
                    }

                    if (i - 1 < 0)
                    {
                        return oldStringList[i];
                    }

                    return oldStringList[i-1];

                }
            }

            return 'b';
        }

        private void SetColors()
        {
            var color = Colors.Black;

            if (colorCode == 'q') color = Colors.Aqua;
            else if (colorCode == 'w') color = Colors.White;
            else if (colorCode == 'e') color = Colors.Gold;
            else if (colorCode == 'r') color = Colors.Red;
            else if (colorCode == 't') color = Colors.Tan;
            else if (colorCode == 'y') color = Colors.Yellow;
            else if (colorCode == 'u') color = Colors.Blue;
            else if (colorCode == 'i') color = Colors.Indigo;
            else if (colorCode == 'o') color = Colors.Olive;
            else if (colorCode == 'p') color = Colors.Purple;
            else if (colorCode == 'a') color = Colors.Azure;
            else if (colorCode == 's') color = Colors.Salmon;
            else if (colorCode == 'd') color = Colors.DodgerBlue;
            else if (colorCode == 'f') color = Colors.Firebrick;
            else if (colorCode == 'g') color = Colors.Green;
            else if (colorCode == 'h') color = Colors.Honeydew;
            else if (colorCode == 'j') color = Colors.Lavender;
            else if (colorCode == 'k') color = Colors.Khaki;
            else if (colorCode == 'l') color = Colors.Lavender;
            else if (colorCode == 'z') color = Colors.Teal;
            else if (colorCode == 'x') color = Colors.Gold;
            else if (colorCode == 'c') color = Colors.Cyan;
            else if (colorCode == 'v') color = Colors.Violet;
            //else if (colorCode == 'b') color = Colors.White;
            else if (colorCode == 'n') color = Colors.Navy;
            else if (colorCode == 'm') color = Colors.Magenta;

            _colorCanvas = new SolidColorBrush(color);
            _colorTextBlock = color.ToString();
        }
    }
}
