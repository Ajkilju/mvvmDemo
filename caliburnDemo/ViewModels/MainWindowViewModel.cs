using Caliburn.Micro;
using caliburnDemo.Models;
using caliburnDemo.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace caliburnDemo.ViewModels
{
    public class MainWindowViewModel : PropertyChangedBase
    {
        private readonly MainWindowModel _model;
        private readonly ColorProcessor _colorProcessor;    

        public MainWindowViewModel()
        {
            _model = new MainWindowModel();
            _colorProcessor = new ColorProcessor();
            ColorTextBox = "ColorTextBox";
        }

        public string ColorTextBox
        {
            get
            {
                return _model.ColorTextBox;
            }
            set
            {
                _colorProcessor.GetStringDifference(_model.ColorTextBox, value);
                _model.ColorTextBox = value;
                NotifyOfPropertyChange("ColorTextBox");
                _colorProcessor.SetColors();
                ColorCanvas = _colorProcessor.Color;
                ColorTextBlock = ColorCanvas.ToString();
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
                NotifyOfPropertyChange("ColorCanvas");
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
                NotifyOfPropertyChange("ColorTextBlock");
            }
        }

    }
}
