using System;
using System.Drawing;

namespace IPT__Fianls_Lab_Exam
{
    public class SailorMoon : SailorScout
    {
        public override ShapeType CharacterShape => ShapeType.Circle;
        public override Brush CharacterBrush => Brushes.HotPink;

        public SailorMoon(string playerName) : base(playerName + " (Sailor Moon)", 120) { }

        protected override void InitializeMoves()
        {
            Moves.Add(new AttackMove("Moon Tiara Action", "A boomerang of light!", 25, 35, 95, "A reliable and accurate attack.",
                (attacker, defender) => Tuple.Create(random.Next(25, 36), $"{attacker.Name} throws her tiara!")
            ));

            Moves.Add(new AttackMove("Moon Healing Escalation", "A gentle, healing light.", 0, 0, 100, "Heals the user for 35 HP.",
                (attacker, defender) => {
                    attacker.Health += 35;
                    return Tuple.Create(0, $"{attacker.Name} recovers 35 HP!");
                }
            ));

            Moves.Add(new AttackMove("Moonlight Veil", "A protective barrier of light.", 0, 0, 100, "Greatly raises user's Defense for 2 turns.",
                (attacker, defender) => {
                    attacker.ApplyStatusEffect(StatusEffect.DefenseUp, 2);
                    return Tuple.Create(0, $"{attacker.Name} is protected by a 'Moonlight Veil'!");
                }
            ));
        }
    }
}