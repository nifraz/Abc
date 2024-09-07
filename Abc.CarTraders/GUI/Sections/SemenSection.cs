using System;
using System.Windows.Forms;
using Material.Styles;

namespace ABC.CarTraders.GUI.Sections
{
    public partial class SemenSection : UserControl, IColoredControl
    {
        public SemenSection()
        {
            InitializeComponent();
            ColorSchemeChanged += SemenSection_ColorSchemeChanged;
        }

        private ColorScheme _colorScheme;

        public ColorScheme ColorScheme
        {
            get { return _colorScheme; }
            set
            {
                _colorScheme = value;
                ColorSchemeChanged?.Invoke(this, value);
            }
        }

        public event EventHandler<ColorScheme> ColorSchemeChanged;

        private void SemenSection_ColorSchemeChanged(object sender, ColorScheme e)
        {
            if (e == null) return;

            BackColor = e.Color4;
        }
    }
}
