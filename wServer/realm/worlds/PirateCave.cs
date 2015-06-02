using wServer.generator;
using wServer.generator.templates.pirateCave;

namespace wServer.realm.worlds
{
    public class PirateCave : World
    {
        public PirateCave()
        {
            Name = "Pirate Cave";
            ClientWorldName = "dungeons.Pirate_Cave";
            Background = 0;
            Difficulty = 1;
            AllowTeleport = true;
        }

        protected override void Init()
        {
            var gen = new DungeonGenerator(Seed, new PirateCaveTemplate());
            gen.Generate();
            LoadMap(gen.ExportToJson());
        }
    }
}