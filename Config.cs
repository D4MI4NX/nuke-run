using Exiled.API.Features.Items;
using Exiled.API.Interfaces;
using InventorySystem.Items.Usables;

namespace NukeRun.Config
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public bool Debug { get; set; } = false;

        public int EventChance { get; set; } = 10;

        public int DetonationTimer { get; set; } = 100;

        public ItemType[] StarterItems { get; set; } = { ItemType.SCP207, ItemType.Medkit, ItemType.SCP500 };
    }
}