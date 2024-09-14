using Exiled.API.Features;
using Server = Exiled.Events.Handlers.Server;
using PlayerRoles;
using Features = Exiled.API.Features;
using Warhead = Exiled.Events.Handlers.Warhead;

namespace NukeRun
{
    public class GenHandler
    {
        private readonly NukeRun hc;

        public GenHandler(NukeRun pluginInstance)
        {
            hc = pluginInstance;
        }

        private bool EventEnabled;

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
            if (UnityEngine.Random.Range(0, 100) <= hc.Config.EventChance)
            {
                Log.Info("Nuke-run event active");
                EventEnabled = true;
            }
            else {
                return;
            }

            RoundSummary.RoundLock = true;
            Features.Warhead.DetonationTimer = hc.Config.DetonationTimer;
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
                foreach(ItemType i in hc.Config.StarterItems)
                {
                    p.AddItem(i);
                }
            }
        }

        public void OnWarheadDetonate()
        {
            if (!EventEnabled)
            {
                return;
            }

            RoundSummary.RoundLock = false;
        }
    }
}
