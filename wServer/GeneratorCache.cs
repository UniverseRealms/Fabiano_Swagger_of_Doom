﻿using DungeonGenerator;
using DungeonGenerator.Templates;
using DungeonGenerator.Templates.Abyss;
using DungeonGenerator.Templates.PirateCave;
using DungeonGenerator.Templates.MadLab;
using log4net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace wServer
{
    public static class GeneratorCache
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(GeneratorCache));
        private static Dictionary<string, List<string>> cachedMaps;

        public static void Init()
        {
            cachedMaps = new Dictionary<string, List<string>>();
            createCache("Abyss of Demons", new AbyssTemplate());
            createCache("Pirate Cave", new PirateCaveTemplate());
            createCache("Mad Lab", new MadLabTemplate());
        }

        public static string NextAbyss(uint seed) => nextMap(seed, "Abyss of Demons");

        public static string NextPirateCave(uint seed) => nextMap(seed, "Pirate Cave");

        public static string NextMadLab(uint seed) => nextMap(seed, "Mad Lab");

        private static string nextMap(uint seed, string key)
        {
            var map = cachedMaps[key][0];
            cachedMaps[key].RemoveAt(0);
            log.Info($"Generating new map for dungeon: {key}");
            Task.Factory.StartNew(() => cachedMaps[key].Add(generateNext(seed, new AbyssTemplate())));
            return map;
        }

        private static string generateNext(uint seed, DungeonTemplate template)
        {
            var gen = new DungeonGen((int)seed, template);
            gen.GenerateAsync();
            return gen.ExportToJson();
        }

        private static void createCache(string key, DungeonTemplate template)
        {
            log.Info($"Generating cache for dungeon: {key}");
            cachedMaps.Add(key, new List<string>());
            for (var i = 0; i < 3; i++) //Keep at least 3 maps in cache
                cachedMaps[key].Add(generateNext(0, template));
        }
    }
}