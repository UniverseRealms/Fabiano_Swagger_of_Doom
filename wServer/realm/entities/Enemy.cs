﻿using System.Collections.Generic;
using wServer.logic;
using wServer.networking.svrPackets;
using wServer.realm.entities.player;

namespace wServer.realm.entities
{
    public class Enemy : Character
    {
        private readonly bool stat;
        private DamageCounter counter;
        private float bleeding;
        private Position? pos;

        public Enemy(RealmManager manager, ushort objType)
            : base(manager, objType, new wRandom())
        {
            stat = ObjectDesc.MaxHP == 0;
            counter = new DamageCounter(this);
            LootState = "";
            Name = ObjectDesc.ObjectId;
        }

        public DamageCounter DamageCounter
        {
            get { return counter; }
        }

        public WmapTerrain Terrain { get; set; }

        public int AltTextureIndex { get; set; }

        public string LootState { get; set; }

        public Position SpawnPoint
        {
            get { return pos ?? new Position { X = X, Y = Y }; }
        }

        protected override void ExportStats(IDictionary<StatsType, object> stats)
        {
            stats[StatsType.AltTextureIndex] = AltTextureIndex;
            base.ExportStats(stats);
        }

        public override void Init(World owner)
        {
            base.Init(owner);
            if (ObjectDesc.StasisImmune)
                ApplyConditionEffect(new ConditionEffect
                {
                    Effect = ConditionEffectIndex.StasisImmune,
                    DurationMS = -1
                });
        }

        public void Death(RealmTime time)
        {
            counter.Death(time);
            if (CurrentState != null)
                CurrentState.OnDeath(new BehaviorEventArgs(this, time));
            Owner.LeaveWorld(this);
        }

        public void SetDamageCounter(DamageCounter counter, Enemy enemy)
        {
            this.counter = counter;
            this.counter.UpdateEnemy(enemy);
        }

        public int Damage(Player from, RealmTime time, int dmg, bool noDef, params ConditionEffect[] effs)
        {
            if (stat) return 0;
            if (HasConditionEffect(ConditionEffects.Invincible))
                return 0;
            if (!HasConditionEffect(ConditionEffects.Paused) &&
                !HasConditionEffect(ConditionEffects.Stasis))
            {
                int def = ObjectDesc.Defense;
                if (noDef)
                    def = 0;
                dmg = (int)StatsManager.GetDefenseDamage(this, dmg, def);
                int effDmg = dmg;
                if (effDmg > HP)
                    effDmg = HP;
                if (!HasConditionEffect(ConditionEffects.Invulnerable))
                    HP -= dmg;
                ApplyConditionEffect(effs);
                if (from != null)
                {
                    Owner.BroadcastPacket(new DamagePacket
                    {
                        TargetId = Id,
                        Effects = 0,
                        Damage = (ushort)dmg,
                        Killed = HP < 0,
                        BulletId = 0,
                        ObjectId = from.Id
                    }, null);

                    counter.HitBy(from, time, null, dmg);
                }
                else
                {
                    Owner.BroadcastPacket(new DamagePacket
                    {
                        TargetId = Id,
                        Effects = 0,
                        Damage = (ushort)dmg,
                        Killed = HP < 0,
                        BulletId = 0,
                        ObjectId = -1
                    }, null);
                }

                if (HP < 0 && Owner != null)
                {
                    Death(time);
                }

                UpdateCount++;
                return effDmg;
            }
            return 0;
        }

        public override bool HitByProjectile(Projectile projectile, RealmTime time)
        {
            if (stat) return false;
            if (HasConditionEffect(ConditionEffects.Invincible))
                return false;
            if (projectile.ProjectileOwner is Player &&
                !HasConditionEffect(ConditionEffects.Paused) &&
                !HasConditionEffect(ConditionEffects.Stasis))
            {
                int def = ObjectDesc.Defense;
                if (projectile.Descriptor.ArmorPiercing)
                    def = 0;
                int dmg = (int)StatsManager.GetDefenseDamage(this, projectile.Damage, def);
                if (!HasConditionEffect(ConditionEffects.Invulnerable))
                    HP -= dmg;
                foreach (ConditionEffect effect in projectile.Descriptor.Effects)
                {
                    if (effect.Effect == ConditionEffectIndex.Stunned && ObjectDesc.StunImmune ||
                        effect.Effect == ConditionEffectIndex.Paralyzed && ObjectDesc.ParalyzedImmune ||
                        effect.Effect == ConditionEffectIndex.Dazed && ObjectDesc.DazedImmune)
                        continue;
                    ApplyConditionEffect(effect);
                }
                Owner.BroadcastPacket(new DamagePacket
                {
                    TargetId = Id,
                    Effects = projectile.ConditionEffects,
                    Damage = (ushort)dmg,
                    Killed = HP < 0,
                    BulletId = projectile.ProjectileId,
                    ObjectId = projectile.ProjectileOwner.Self.Id
                }, projectile.ProjectileOwner as Player);

                counter.HitBy(projectile.ProjectileOwner as Player, time, projectile, dmg);

                if (HP <= 0 && Owner != null)
                {
                    Death(time);
                }
                UpdateCount++;
                return true;
            }
            return false;
        }

        public override void Tick(RealmTime time)
        {
            if (pos == null)
                pos = new Position { X = X, Y = Y };

            if (!stat && HasConditionEffect(ConditionEffects.Bleeding))
            {
                if (bleeding > 1)
                {
                    HP -= (int)bleeding;
                    bleeding -= (int)bleeding;
                    UpdateCount++;
                }
                bleeding += 28 * (time.thisTickTimes / 1000f);
            }
            base.Tick(time);
        }

        public override void Dispose()
        {
            counter = null;
            base.Dispose();
        }
    }
}