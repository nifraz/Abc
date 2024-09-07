using System;
using System.Drawing;

namespace Material.Styles
{
    public class ColorScheme : EventArgs
    {
        public string Title { get; set; }
        public Color Color0 { get; set; }
        public Color Color1 { get; set; }
        public Color Color2 { get; set; }
        public Color Color3 { get; set; }
        public Color Color4 { get; set; }
        public Color Color5 { get; set; }
        public Color Color6 { get; set; }
        public Color Color7 { get; set; }
        public Color Color8 { get; set; }
        public Color Color9 { get; set; }

        public static ColorScheme Red { get; } = new ColorScheme()
        {
            Title = "Red",
            Color0 = Color.FromArgb(255, 235, 238),
            Color1 = Color.FromArgb(255, 205, 210),
            Color2 = Color.FromArgb(239, 154, 154),
            Color3 = Color.FromArgb(229, 115, 115),
            Color4 = Color.FromArgb(239, 83, 80),
            Color5 = Color.FromArgb(244, 67, 54),
            Color6 = Color.FromArgb(229, 57, 53),
            Color7 = Color.FromArgb(211, 47, 47),
            Color8 = Color.FromArgb(198, 40, 40),
            Color9 = Color.FromArgb(183, 28, 28)
        };

        public static ColorScheme Pink { get; } = new ColorScheme()
        {
            Title = "Pink",
            Color0 = Color.FromArgb(252, 228, 236),
            Color1 = Color.FromArgb(248, 187, 208),
            Color2 = Color.FromArgb(244, 143, 177),
            Color3 = Color.FromArgb(240, 98, 146),
            Color4 = Color.FromArgb(236, 64, 122),
            Color5 = Color.FromArgb(233, 30, 99),
            Color6 = Color.FromArgb(216, 27, 96),
            Color7 = Color.FromArgb(194, 24, 91),
            Color8 = Color.FromArgb(173, 20, 87),
            Color9 = Color.FromArgb(136, 14, 79)
        };
        public static ColorScheme Purple { get; } = new ColorScheme()
        {
            Title = "Purple",
            Color0 = Color.FromArgb(243, 229, 245),
            Color1 = Color.FromArgb(225, 190, 231),
            Color2 = Color.FromArgb(206, 147, 216),
            Color3 = Color.FromArgb(186, 104, 200),
            Color4 = Color.FromArgb(171, 71, 188),
            Color5 = Color.FromArgb(156, 39, 176),
            Color6 = Color.FromArgb(142, 36, 170),
            Color7 = Color.FromArgb(123, 31, 162),
            Color8 = Color.FromArgb(106, 27, 154),
            Color9 = Color.FromArgb(74, 20, 140)
        };
        public static ColorScheme DeepPurple { get; } = new ColorScheme()
        {
            Title = "Deep Purple",
            Color0 = Color.FromArgb(237, 231, 246),
            Color1 = Color.FromArgb(209, 196, 233),
            Color2 = Color.FromArgb(179, 157, 219),
            Color3 = Color.FromArgb(149, 117, 205),
            Color4 = Color.FromArgb(126, 87, 194),
            Color5 = Color.FromArgb(103, 58, 183),
            Color6 = Color.FromArgb(94, 53, 177),
            Color7 = Color.FromArgb(81, 45, 168),
            Color8 = Color.FromArgb(69, 39, 160),
            Color9 = Color.FromArgb(49, 27, 146)
        };
        public static ColorScheme Indigo { get; } = new ColorScheme()
        {
            Title = "Indigo",
            Color0 = Color.FromArgb(232, 234, 246),
            Color1 = Color.FromArgb(197, 202, 233),
            Color2 = Color.FromArgb(159, 168, 218),
            Color3 = Color.FromArgb(121, 134, 203),
            Color4 = Color.FromArgb(92, 107, 192),
            Color5 = Color.FromArgb(63, 81, 181),
            Color6 = Color.FromArgb(57, 73, 171),
            Color7 = Color.FromArgb(48, 63, 159),
            Color8 = Color.FromArgb(40, 53, 147),
            Color9 = Color.FromArgb(26, 35, 126)
        };
        public static ColorScheme Blue { get; } = new ColorScheme()
        {
            Title = "Blue",
            Color0 = Color.FromArgb(227, 242, 253),
            Color1 = Color.FromArgb(187, 222, 251),
            Color2 = Color.FromArgb(144, 202, 249),
            Color3 = Color.FromArgb(100, 181, 246),
            Color4 = Color.FromArgb(66, 165, 245),
            Color5 = Color.FromArgb(33, 150, 243),
            Color6 = Color.FromArgb(30, 136, 229),
            Color7 = Color.FromArgb(25, 118, 210),
            Color8 = Color.FromArgb(21, 101, 192),
            Color9 = Color.FromArgb(13, 71, 161)
        };
        public static ColorScheme LightBlue { get; } = new ColorScheme()
        {
            Title = "Light Blue",
            Color0 = Color.FromArgb(225, 245, 254),
            Color1 = Color.FromArgb(179, 229, 252),
            Color2 = Color.FromArgb(129, 212, 250),
            Color3 = Color.FromArgb(79, 195, 247),
            Color4 = Color.FromArgb(41, 182, 246),
            Color5 = Color.FromArgb(3, 169, 244),
            Color6 = Color.FromArgb(3, 155, 229),
            Color7 = Color.FromArgb(2, 136, 209),
            Color8 = Color.FromArgb(2, 119, 189),
            Color9 = Color.FromArgb(1, 87, 155)
        };
        public static ColorScheme Cyan { get; } = new ColorScheme()
        {
            Title = "Cyan",
            Color0 = Color.FromArgb(224, 247, 250),
            Color1 = Color.FromArgb(178, 235, 242),
            Color2 = Color.FromArgb(128, 222, 234),
            Color3 = Color.FromArgb(77, 208, 225),
            Color4 = Color.FromArgb(38, 198, 218),
            Color5 = Color.FromArgb(0, 188, 212),
            Color6 = Color.FromArgb(0, 172, 193),
            Color7 = Color.FromArgb(0, 151, 167),
            Color8 = Color.FromArgb(0, 131, 143),
            Color9 = Color.FromArgb(0, 96, 100)
        };
        public static ColorScheme Teal { get; } = new ColorScheme()
        {
            Title = "Teal",
            Color0 = Color.FromArgb(224, 242, 241),
            Color1 = Color.FromArgb(178, 223, 219),
            Color2 = Color.FromArgb(128, 203, 196),
            Color3 = Color.FromArgb(77, 182, 172),
            Color4 = Color.FromArgb(38, 166, 154),
            Color5 = Color.FromArgb(0, 150, 136),
            Color6 = Color.FromArgb(0, 137, 123),
            Color7 = Color.FromArgb(0, 121, 107),
            Color8 = Color.FromArgb(0, 105, 92),
            Color9 = Color.FromArgb(0, 77, 64)
        };
        public static ColorScheme Green { get; } = new ColorScheme()
        {
            Title = "Green",
            Color0 = Color.FromArgb(232, 245, 233),
            Color1 = Color.FromArgb(200, 230, 201),
            Color2 = Color.FromArgb(165, 214, 167),
            Color3 = Color.FromArgb(129, 199, 132),
            Color4 = Color.FromArgb(102, 187, 106),
            Color5 = Color.FromArgb(76, 175, 80),
            Color6 = Color.FromArgb(67, 160, 71),
            Color7 = Color.FromArgb(56, 142, 60),
            Color8 = Color.FromArgb(46, 125, 50),
            Color9 = Color.FromArgb(27, 94, 32)
        };
        public static ColorScheme LightGreen { get; } = new ColorScheme()
        {
            Title = "Light Green",
            Color0 = Color.FromArgb(241, 248, 233),
            Color1 = Color.FromArgb(220, 237, 200),
            Color2 = Color.FromArgb(197, 225, 165),
            Color3 = Color.FromArgb(174, 213, 129),
            Color4 = Color.FromArgb(156, 204, 101),
            Color5 = Color.FromArgb(139, 195, 74),
            Color6 = Color.FromArgb(124, 179, 66),
            Color7 = Color.FromArgb(104, 159, 56),
            Color8 = Color.FromArgb(85, 139, 47),
            Color9 = Color.FromArgb(51, 105, 30)
        };
        public static ColorScheme Lime { get; } = new ColorScheme()
        {
            Title = "Lime",
            Color0 = Color.FromArgb(249, 251, 231),
            Color1 = Color.FromArgb(240, 244, 195),
            Color2 = Color.FromArgb(230, 238, 156),
            Color3 = Color.FromArgb(220, 231, 117),
            Color4 = Color.FromArgb(212, 225, 87),
            Color5 = Color.FromArgb(205, 220, 57),
            Color6 = Color.FromArgb(192, 202, 51),
            Color7 = Color.FromArgb(175, 180, 43),
            Color8 = Color.FromArgb(158, 157, 36),
            Color9 = Color.FromArgb(130, 119, 23)
        };
        public static ColorScheme Yellow { get; } = new ColorScheme()
        {
            Title = "Yellow",
            Color0 = Color.FromArgb(255, 253, 231),
            Color1 = Color.FromArgb(255, 249, 196),
            Color2 = Color.FromArgb(255, 245, 157),
            Color3 = Color.FromArgb(255, 241, 118),
            Color4 = Color.FromArgb(255, 238, 88),
            Color5 = Color.FromArgb(255, 235, 59),
            Color6 = Color.FromArgb(253, 216, 53),
            Color7 = Color.FromArgb(251, 192, 45),
            Color8 = Color.FromArgb(249, 168, 37),
            Color9 = Color.FromArgb(245, 127, 23)
        };
        public static ColorScheme Amber { get; } = new ColorScheme()
        {
            Title = "Amber",
            Color0 = Color.FromArgb(255, 248, 225),
            Color1 = Color.FromArgb(255, 236, 179),
            Color2 = Color.FromArgb(255, 224, 130),
            Color3 = Color.FromArgb(255, 213, 79),
            Color4 = Color.FromArgb(255, 202, 40),
            Color5 = Color.FromArgb(255, 193, 7),
            Color6 = Color.FromArgb(255, 179, 0),
            Color7 = Color.FromArgb(255, 160, 0),
            Color8 = Color.FromArgb(255, 143, 0),
            Color9 = Color.FromArgb(255, 111, 0)
        };
        public static ColorScheme Orange { get; } = new ColorScheme()
        {
            Title = "Orange",
            Color0 = Color.FromArgb(255, 243, 224),
            Color1 = Color.FromArgb(255, 224, 178),
            Color2 = Color.FromArgb(255, 204, 128),
            Color3 = Color.FromArgb(255, 183, 77),
            Color4 = Color.FromArgb(255, 167, 38),
            Color5 = Color.FromArgb(255, 152, 0),
            Color6 = Color.FromArgb(251, 140, 0),
            Color7 = Color.FromArgb(245, 124, 0),
            Color8 = Color.FromArgb(239, 108, 0),
            Color9 = Color.FromArgb(230, 81, 0)
        };
        public static ColorScheme DeepOrange { get; } = new ColorScheme()
        {
            Title = "Deep Orange",
            Color0 = Color.FromArgb(251, 233, 231),
            Color1 = Color.FromArgb(255, 204, 188),
            Color2 = Color.FromArgb(255, 171, 145),
            Color3 = Color.FromArgb(255, 138, 101),
            Color4 = Color.FromArgb(255, 112, 67),
            Color5 = Color.FromArgb(255, 87, 34),
            Color6 = Color.FromArgb(244, 81, 30),
            Color7 = Color.FromArgb(230, 74, 25),
            Color8 = Color.FromArgb(216, 67, 21),
            Color9 = Color.FromArgb(191, 54, 12)
        };
        public static ColorScheme Brown { get; } = new ColorScheme()
        {
            Title = "Brown",
            Color0 = Color.FromArgb(239, 235, 233),
            Color1 = Color.FromArgb(215, 204, 200),
            Color2 = Color.FromArgb(188, 170, 164),
            Color3 = Color.FromArgb(161, 136, 127),
            Color4 = Color.FromArgb(141, 110, 99),
            Color5 = Color.FromArgb(121, 85, 72),
            Color6 = Color.FromArgb(109, 76, 65),
            Color7 = Color.FromArgb(93, 64, 55),
            Color8 = Color.FromArgb(78, 52, 46),
            Color9 = Color.FromArgb(62, 39, 35)
        };
        public static ColorScheme Grey { get; } = new ColorScheme()
        {
            Title = "Grey",
            Color0 = Color.FromArgb(250, 250, 250),
            Color1 = Color.FromArgb(245, 245, 245),
            Color2 = Color.FromArgb(238, 238, 238),
            Color3 = Color.FromArgb(224, 224, 224),
            Color4 = Color.FromArgb(189, 189, 189),
            Color5 = Color.FromArgb(158, 158, 158),
            Color6 = Color.FromArgb(117, 117, 117),
            Color7 = Color.FromArgb(97, 97, 97),
            Color8 = Color.FromArgb(66, 66, 66),
            Color9 = Color.FromArgb(33, 33, 33)
        };
        public static ColorScheme BlueGrey { get; } = new ColorScheme()
        {
            Title = "Blue Grey",
            Color0 = Color.FromArgb(236, 239, 241),
            Color1 = Color.FromArgb(207, 216, 220),
            Color2 = Color.FromArgb(176, 190, 197),
            Color3 = Color.FromArgb(144, 164, 174),
            Color4 = Color.FromArgb(120, 144, 156),
            Color5 = Color.FromArgb(96, 125, 139),
            Color6 = Color.FromArgb(84, 110, 122),
            Color7 = Color.FromArgb(69, 90, 100),
            Color8 = Color.FromArgb(55, 71, 79),
            Color9 = Color.FromArgb(38, 50, 56)
        };
        public static ColorScheme Black { get; } = new ColorScheme()
        {
            Title = "Black",
            Color0 = Color.FromArgb(255, 255, 255),
            Color1 = Color.FromArgb(230, 230, 230),
            Color2 = Color.FromArgb(205, 205, 205),
            Color3 = Color.FromArgb(180, 180, 180),
            Color4 = Color.FromArgb(155, 155, 155),
            Color5 = Color.FromArgb(130, 130, 130),
            Color6 = Color.FromArgb(105, 105, 105),
            Color7 = Color.FromArgb(80, 80, 80),
            Color8 = Color.FromArgb(55, 55, 55),
            Color9 = Color.FromArgb(30, 30, 30)
        };

        //Common Colors
        public static ColorScheme RefreshColorScheme => Blue;
        public static ColorScheme AddColorScheme => Green;
        public static ColorScheme EditColorScheme => Yellow;
        public static ColorScheme DeleteColorScheme => Red;
    }
}