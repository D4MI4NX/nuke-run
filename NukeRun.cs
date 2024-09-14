using Exiled.API.Features;

namespace NukeRun
{
    public class NukeRun : Plugin<Config.Config>
    {
        public override string Name => "Nuke Run";
    
        public override string Prefix => "nuke_run";
        
        public override string Author => "D4MI4NX";
        
        public override Version Version => new(1, 0, 0);
        
        public override Version RequiredExiledVersion => new(8, 9, 11);


        public GenHandler Handler { get; private set; }

        public override void OnEnabled()
        {
            Handler = new GenHandler(this);
            Handler.Start();

            base.OnEnabled();
        }
        
        public override void OnDisabled()
        {
            Handler?.Stop();

            base.OnDisabled();
        }
    }
}
