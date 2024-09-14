using Exiled.API.Interfaces;

namespace NukeRun.Config
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public bool Debug { get; set; } = false;

        public int EventChance { get; set; } = 10;

        public int DetonationTimer { get; set; } = 100;
    }
}