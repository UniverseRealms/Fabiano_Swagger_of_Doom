#region

using wServer.logic.behaviors;
using wServer.logic.transitions;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Misc = () => Behav()
            .Init("White Fountain",
                new State(
                    new NexusHealHp(5, 100, 1000)))
           .Init("Winter Fountain Frozen",
               new State(
                   new NexusHealHp(5, 100, 1000)))
            .Init("Sheep",
                new State(
                    new PlayerWithinTransition(15, "player_nearby"),
                        new State("player_nearby",
                            new Prioritize(
                                new StayCloseToSpawn(0.1, 2),
                                new Wander(0.1)),
                        new Taunt(0.001, 1000, "baa", "baa baa"))))

            .Init("Test Boss",
                new State(
                    new State("Kraaa",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(25, fixedAngle: 30, coolDown: 200),
                        new Shoot(25, fixedAngle: 60, coolDown: 200),
                        new Shoot(25, fixedAngle: 90, coolDown: 200),
                        new Shoot(25, fixedAngle: 120, coolDown: 200),
                        new Shoot(25, fixedAngle: 180, coolDown: 200),
                        new Shoot(25, fixedAngle: 240, coolDown: 200),
                        new Shoot(25, fixedAngle: 300, coolDown: 200),
                        new Shoot(25, fixedAngle: 0, coolDown: 200),
                        new TimedTransition(4500, "Tek")),
                    new State("Tek",
                        new ConditionalEffect(ConditionEffectIndex.Armored))));
    }
}
