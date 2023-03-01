using System.Windows.Forms;
using System.Windows.Media;

namespace IllmefyLauncher.Model
{
    public static class Addons
    {
        public static System.Drawing.Color ToDrawingColor(this System.Windows.Media.Color color) => System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
        public static System.Windows.Media.Color ToMediaColor(this System.Drawing.Color color) => System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
        public static SolidColorBrush Dark(this SolidColorBrush solidColorBrush) => new SolidColorBrush(ControlPaint.Dark(solidColorBrush.Color.ToDrawingColor()).ToMediaColor());
        public static SolidColorBrush Dark(this SolidColorBrush solidColorBrush, float percOfDarkDark) => new SolidColorBrush(ControlPaint.Dark(solidColorBrush.Color.ToDrawingColor(), percOfDarkDark).ToMediaColor());
        public static SolidColorBrush DarkDark(this SolidColorBrush solidColorBrush) => new SolidColorBrush(ControlPaint.DarkDark(solidColorBrush.Color.ToDrawingColor()).ToMediaColor());
        public static SolidColorBrush Light(this SolidColorBrush solidColorBrush) => new SolidColorBrush(ControlPaint.Light(solidColorBrush.Color.ToDrawingColor()).ToMediaColor());
        public static SolidColorBrush Light(this SolidColorBrush solidColorBrush, float percOfLight) => new SolidColorBrush(ControlPaint.Light(solidColorBrush.Color.ToDrawingColor(), percOfLight).ToMediaColor());
        public static SolidColorBrush LightLight(this SolidColorBrush solidColorBrush) => new SolidColorBrush(ControlPaint.Light(solidColorBrush.Color.ToDrawingColor()).ToMediaColor());

    }
}
