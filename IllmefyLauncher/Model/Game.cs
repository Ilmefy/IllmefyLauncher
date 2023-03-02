using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace IllmefyLauncher.Model
{
    public enum Expansion
    {
        All,
        Vanilla,
        TheBurningCrusade,
        WrathOfTheLichKing,
        Cataclysm,
        MistsOfPandaria,
        WarlordsOfDraenor,
        Legion,
        BattleForAzeroth,
        Shadowlands,
        Dragonflight,
        None
    }
    public class Game
    {
        public string Name { get; set; }
        public string LauncherPath { get; set; }
        public Expansion Expansion { get; set; }
        public BitmapImage ExpansionIcon { get { return new BitmapImage(new Uri($"/Resources/ExpansionIcons/{Expansion}.png", UriKind.Relative)); } }
        public BitmapImage ExpansionBackground { get { return new BitmapImage(new Uri($"/Resources/Backgrounds/{Expansion}.jpg", UriKind.RelativeOrAbsolute)); } }
    }
}
