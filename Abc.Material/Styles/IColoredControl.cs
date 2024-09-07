using System;

namespace Material.Styles
{
    public interface IColoredControl
    {
        ColorScheme ColorScheme { get; set; }
        event EventHandler<ColorScheme> ColorSchemeChanged;
    }
}
