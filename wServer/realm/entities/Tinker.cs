using db;
using System;
using System.Collections.Generic;

namespace wServer.realm.entities
{
    public class Tinker : StaticObject
    {
        public Tinker(RealmManager manager, ushort objType, int? life, bool dying)
            : base(manager, objType, life, false, dying, false)
        {
            Name = Database.DateTimeToUnixTimestamp(DateTime.Now.AddDays(100d)).ToString();
        }

        protected override void ExportStats(IDictionary<StatsType, object> stats)
        {
            base.ExportStats(stats);

            stats[StatsType.Name] = DateTime.Now.AddDays(100d).ToLongDateString();
        }
    }
}