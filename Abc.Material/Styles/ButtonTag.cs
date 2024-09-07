using System.Drawing;

namespace Material.Styles
{
    public class ButtonTag
    {
        public Bitmap ButtonImageDark { get; set; }
        public Bitmap ButtonImageLight { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IColoredControl RegionControl { get; set; }

    }
}
