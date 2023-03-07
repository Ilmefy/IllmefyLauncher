using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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
    public abstract class Game
    {
        public string Name { get; set; }
        public string LauncherPath { get; set; }
        public string GameDirectory { get { return Path.GetDirectoryName(LauncherPath); } }
        public Expansion Expansion
        {
            get
            {
                if (this is VanillaGame) return Expansion.Vanilla;
                if (this is WrathOfTheLichKingGame) return Expansion.WrathOfTheLichKing;
                return Expansion.All;
            }
        }
        private static Game AssignGameType(string gameLauncherFileName)
        {
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(gameLauncherFileName);
            Expansion expansion = (Expansion)int.Parse(fileVersionInfo.FileVersion[0].ToString());
            switch (expansion)
            {
                case Expansion.All:
                    break;
                case Expansion.Vanilla:
                    return new VanillaGame();
                case Expansion.TheBurningCrusade:
                    break;
                case Expansion.WrathOfTheLichKing:
                    return new WrathOfTheLichKingGame();
                case Expansion.Cataclysm:
                    break;
                case Expansion.MistsOfPandaria:
                    break;
                case Expansion.WarlordsOfDraenor:
                    break;
                case Expansion.Legion:
                    break;
                case Expansion.BattleForAzeroth:
                    break;
                case Expansion.Shadowlands:
                    break;
                case Expansion.Dragonflight:
                    break;
                case Expansion.None:
                    break;
            }
            return null;
        }
        public BitmapImage ExpansionIcon { get { return new BitmapImage(new Uri($"/Resources/ExpansionIcons/{Expansion}.png", UriKind.Relative)); } }
        public BitmapImage ExpansionBackground { get { return new BitmapImage(new Uri($"/Resources/Backgrounds/{Expansion}.jpg", UriKind.RelativeOrAbsolute)); } }
    }    
    public class OldGames : Game
    {
        public void SetRealmlist()
        {
            string directory = Path.GetDirectoryName(LauncherPath);
        }
    }
    public class VanillaGame : OldGames
    {

    }
    public class WrathOfTheLichKingGame : OldGames
    {

    }
}
