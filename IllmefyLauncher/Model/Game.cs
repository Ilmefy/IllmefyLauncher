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
        public string? Name { get; set; }
        public string LauncherPath { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public string GameDirectory { get { return Path.GetDirectoryName(LauncherPath); } }
        [Newtonsoft.Json.JsonIgnore]
        public Expansion Expansion
        {
            get
            {
                if (this is VanillaGame) return Expansion.Vanilla;
                if (this is WrathOfTheLichKingGame) return Expansion.WrathOfTheLichKing;
                if (this is CataclysmGame) return Expansion.Cataclysm;
                if (this is MistsOfPandariaGame) return Expansion.MistsOfPandaria;
                if (this is WarlordsOfDraenorGame) return Expansion.WarlordsOfDraenor;
                if (this is LegionGame) return Expansion.Legion;
                if (this is BattleForAzerothGame) return Expansion.BattleForAzeroth;
                if (this is ShadowlandsGame) return Expansion.Shadowlands;
                if (this is DragonflightGame) return Expansion.Dragonflight;
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
                    return new MistsOfPandariaGame();
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
        [Newtonsoft.Json.JsonIgnore]
        public BitmapImage ExpansionIcon { get { return new BitmapImage(new Uri($"/Resources/ExpansionIcons/{Expansion}.png", UriKind.Relative)); } }
        [Newtonsoft.Json.JsonIgnore]
        public BitmapImage ExpansionBackground { get { return new BitmapImage(new Uri($"/Resources/Backgrounds/{Expansion}.jpg", UriKind.RelativeOrAbsolute)); } }
    }    
    public class OldGames : Game
    {
        public void SetRealmlist()
        {
            string directory = Path.GetDirectoryName(LauncherPath);
        }
    }
    public class NewGames:Game
    {

    }
    public class VanillaGame : OldGames
    {

    }
    public class TheBurningCrusadeGame : OldGames
    {

    }
    public class WrathOfTheLichKingGame : OldGames
    {

    }
    public class CataclysmGame : OldGames
    {

    }
    public class MistsOfPandariaGame : OldGames
    {

    }
    public class WarlordsOfDraenorGame : NewGames
    {

    }
    public class LegionGame : NewGames
    {

    }
    public class BattleForAzerothGame : NewGames
    {

    }
    public class ShadowlandsGame : NewGames
    {

    }
    public class DragonflightGame : NewGames
    {

    }
}
