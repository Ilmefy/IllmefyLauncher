using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IllmefyLauncher.Model
{
    public static class GameCreator
    {
        static Expansion _expansion { get; set; }
        public static Game? CreateGame(string gameLauncher)
        {
            GameValidator gameValidator = GetValidator(gameLauncher);
            if (gameValidator.Validate())
                return CreateGameInstance();
            return null;
        }
        private static Game? CreateGameInstance()
        {
            switch (_expansion)
            {
                case Expansion.All:
                    break;
                case Expansion.Vanilla:
                    return new VanillaGame();
                case Expansion.TheBurningCrusade:
                    return new TheBurningCrusadeGame();
                case Expansion.WrathOfTheLichKing:
                    return new WrathOfTheLichKingGame();
                case Expansion.Cataclysm:
                    return new CataclysmGame();
                case Expansion.MistsOfPandaria:
                    return  new MistsOfPandariaGame();
                case Expansion.WarlordsOfDraenor:
                    return new WarlordsOfDraenorGame();
                case Expansion.Legion:
                    return new LegionGame();
                case Expansion.BattleForAzeroth:
                    return new BattleForAzerothGame();
                case Expansion.Shadowlands:
                    return new ShadowlandsGame();
                case Expansion.Dragonflight:
                    return new DragonflightGame();
                case Expansion.None:
                    break;
            }
            return null;
        }
        private static GameValidator? GetValidator(string gameLauncher)
        {
            if (File.Exists(gameLauncher))
            {
                FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(gameLauncher);
                int firstNumberOfFileVersion = int.Parse(fileVersionInfo.FileVersion[0].ToString());
                if (firstNumberOfFileVersion > 0)
                {
                    Expansion expansion = (Expansion)firstNumberOfFileVersion;
                    _expansion = expansion;
                    switch (expansion)
                    {
                        case Expansion.All:
                            break;
                        case Expansion.Vanilla:
                            return new VanillaGameValidator(gameLauncher);
                        case Expansion.TheBurningCrusade:
                            return new TheBurningCrusadeGameValidator(gameLauncher);
                        case Expansion.WrathOfTheLichKing:
                            return new WrathOfTheLichKingGameValidator(gameLauncher);
                        case Expansion.Cataclysm:
                            return new CataclysmGameValidator(gameLauncher);
                        case Expansion.MistsOfPandaria:
                            return new MistsOfPandariaGameValidator(gameLauncher);
                        case Expansion.WarlordsOfDraenor:
                            return new WarlordsOfDraenorGameValidator(gameLauncher);
                        case Expansion.Legion:
                            return new LegionGameValidator(gameLauncher);   
                        case Expansion.BattleForAzeroth:
                            return new BattleForAzerothGameValidator(gameLauncher);
                        case Expansion.Shadowlands:
                            return new ShadowlandsGameValidator(gameLauncher);
                        case Expansion.Dragonflight:
                            return new DragonflightGameValidator(gameLauncher);
                        case Expansion.None:
                            break;
                    }
                }
            }
            return null;

        }
    }
    public abstract class GameValidator
    {
        protected abstract string[] _requiredFiles { get; }
        protected abstract string[] _requiredDirectories { get; }
        protected string _gameLauncherFileName { get; set; }
        protected string _gameDirectory { get; set; }
        public GameValidator(string gameLauncherFileName)
        {
            _gameLauncherFileName = gameLauncherFileName;
            _gameDirectory = Path.GetDirectoryName(gameLauncherFileName);
        }
        public bool Validate()
        {
            if (CheckRequiredDirectories() && CheckRequiredFiles())
                return true;

            return false;
        }
        private bool CheckGameLauncher()
        {
            if (!string.Equals(Path.GetExtension(_gameLauncherFileName), ".exe", StringComparison.OrdinalIgnoreCase))
                return false;
            return true;
        }
        private bool CheckRequiredFiles()
        {
            for (int i = 0; i < _requiredFiles.Length; i++)
            {
                if (!Directory.GetFiles(_gameDirectory, _requiredFiles[i], SearchOption.AllDirectories).Any())
                    return false;
            }
            return true;
        }
        private bool CheckRequiredDirectories()
        {
            for (int i = 0; i < _requiredDirectories.Length; i++)
            {
                if (!Directory.GetDirectories(_gameDirectory, _requiredDirectories[i], SearchOption.AllDirectories).Any())
                    return false;
            }
            return true;
        }
    }
    public class VanillaGameValidator : GameValidator
    {
        public VanillaGameValidator(string gameLauncherFileName) : base(gameLauncherFileName)
        {
        }

        protected override string[] _requiredFiles => throw new NotImplementedException();

        protected override string[] _requiredDirectories => throw new NotImplementedException();
    }
    public class TheBurningCrusadeGameValidator : GameValidator
    {
        public TheBurningCrusadeGameValidator(string gameLauncherFileName) : base(gameLauncherFileName)
        {
        }
        protected override string[] _requiredFiles => throw new NotImplementedException();

        protected override string[] _requiredDirectories => throw new NotImplementedException();
    }
    public class WrathOfTheLichKingGameValidator : GameValidator
    {
        public WrathOfTheLichKingGameValidator(string gameLauncherFileName) : base(gameLauncherFileName)
        {
        }

        protected override string[] _requiredFiles => new string[] { "Launcher.exe" };

        protected override string[] _requiredDirectories => new string[] { "Data" };
    }
    public class CataclysmGameValidator : GameValidator
    {
        public CataclysmGameValidator(string gameLauncherFileName) : base(gameLauncherFileName)
        {
        }

        protected override string[] _requiredFiles => throw new NotImplementedException();

        protected override string[] _requiredDirectories => throw new NotImplementedException();
    }
    public class MistsOfPandariaGameValidator : GameValidator
    {
        public MistsOfPandariaGameValidator(string gameLauncherFileName) : base(gameLauncherFileName)
        {
        }

        protected override string[] _requiredFiles => throw new NotImplementedException();

        protected override string[] _requiredDirectories => throw new NotImplementedException();
    }
    public class WarlordsOfDraenorGameValidator : GameValidator
    {
        public WarlordsOfDraenorGameValidator(string gameLauncherFileName) : base(gameLauncherFileName)
        {
        }

        protected override string[] _requiredFiles => throw new NotImplementedException();

        protected override string[] _requiredDirectories => throw new NotImplementedException();
    }
    public class LegionGameValidator : GameValidator
    {
        public LegionGameValidator(string gameLauncherFileName) : base(gameLauncherFileName)
        {
        }

        protected override string[] _requiredFiles => throw new NotImplementedException();

        protected override string[] _requiredDirectories => throw new NotImplementedException();
    }
    public class BattleForAzerothGameValidator : GameValidator
    {
        public BattleForAzerothGameValidator(string gameLauncherFileName) : base(gameLauncherFileName)
        {
        }

        protected override string[] _requiredFiles => throw new NotImplementedException();

        protected override string[] _requiredDirectories => throw new NotImplementedException();
    }
    public class ShadowlandsGameValidator : GameValidator
    {
        public ShadowlandsGameValidator(string gameLauncherFileName) : base(gameLauncherFileName)
        {
        }

        protected override string[] _requiredFiles => throw new NotImplementedException();

        protected override string[] _requiredDirectories => throw new NotImplementedException();
    }
    public class DragonflightGameValidator : GameValidator
    {
        public DragonflightGameValidator(string gameLauncherFileName) : base(gameLauncherFileName)
        {
        }

        protected override string[] _requiredFiles => throw new NotImplementedException();

        protected override string[] _requiredDirectories => throw new NotImplementedException();
    }
}
