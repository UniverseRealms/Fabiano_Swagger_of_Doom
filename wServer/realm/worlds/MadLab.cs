namespace wServer.realm.worlds
{
    public class MadLab : World
    {
        public MadLab()
        {
            Name = "Mad Lab";
            ClientWorldName = "dungeons.Pirate_Cave";
            Background = 0;
            Difficulty = 1;
            AllowTeleport = true;
        }

        protected override void Init()
        {
            LoadMap(GeneratorCache.NextMadLab(Seed));
        }
    }
}