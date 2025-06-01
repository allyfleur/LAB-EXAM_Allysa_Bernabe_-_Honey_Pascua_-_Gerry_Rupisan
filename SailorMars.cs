using System;
using System.Drawing;

namespace IPT__Fianls_Lab_Exam
{
    public class SailorMars : SailorScout
    {
        public override ShapeType CharacterShape => ShapeType.Triangle;
        public override Brush CharacterBrush => Brushes.Crimson;

        public SailorMars(string playerName) : base(playerName + " (Sailor Mars)", 95) { }

        protected override void InitializeMoves()
        {
            Moves.Add(new AttackMove("Fire Soul", "A powerful fireball.", 30, 40, 90, "Strong fire attack.",
                (attacker, defender) => Tuple.Create(random.Next(30, 41), $"{attacker.Name} casts Fire Soul!")
            ));

            Moves.Add(new AttackMove("Fire Soul Bird", "A massive phoenix of flame.", 45, 60, 75, "High power. 20% chance to burn (poison).",
                (attacker, defender) => {
                    string narrative = $"{attacker.Name} summons a Fire Bird!";
                    if (random.Next(1, 101) <= 20)
                    {
                        defender.ApplyStatusEffect(StatusEffect.Poisoned, 3);
                        narrative += $" {GetDisplayName(defender)} is burned!";
                    }
                    return Tuple.Create(random.Next(45, 61), narrative);
                }
            ));

            Moves.Add(new AttackMove("Akuryo Taisan", "A spiritual chant to weaken foes.", 0, 0, 95, "Lowers the opponent's Attack for 3 turns.",
                (attacker, defender) => {
                    defender.ApplyStatusEffect(StatusEffect.AttackDown, 3);
                    return Tuple.Create(0, $"{attacker.Name}'s chant weakens {GetDisplayName(defender)}'s will to fight!");
                }
            ));
        }
    }
}