using Exiled.API.Features;
using Server = Exiled.Events.Handlers.Server;
using PlayerRoles;
using Features = Exiled.API.Features;
using Warhead = Exiled.Events.Handlers.Warhead;
using Exiled.API.Enums;
using InventorySystem;

namespace NukeRun
{
    public class GenHandler
    {
        private readonly NukeRun hc;

        public GenHandler(NukeRun pluginInstance)
        {
            hc = pluginInstance;
        }

        public void Start()
        {
            Server.RoundStarted += OnRoundStart;
            Warhead.Detonated += OnWarheadDetonate;
        }

        public void Stop()
        {
            Server.RoundStarted -= OnRoundStart;
            Warhead.Detonated -= OnWarheadDetonate;
        }

        public void OnRoundStart()
        {
            RoundSummary.RoundLock = true;
            Features.Warhead.DetonationTimer = 100;
            Features.Warhead.Start();
            Features.Warhead.IsLocked = true;
            
            foreach(Player p in Player.List)
            {
                p.Broadcast(10, "Nuke-run event. Escape the facility!");

                if (p.Role == RoleTypeId.Tutorial)
                {
                    continue;
                }

                p.Role.Set(RoleTypeId.ClassD);
                p.EnableEffect(EffectType.Scp207);
                p.AddItem(ItemType.Medkit);
            }
        }

        public void OnWarheadDetonate()
        {
            RoundSummary.RoundLock = false;
        }
    }
}
