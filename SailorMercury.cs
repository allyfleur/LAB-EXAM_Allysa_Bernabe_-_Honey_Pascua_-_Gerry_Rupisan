using System;
using System.Drawing;

namespace IPT__Fianls_Lab_Exam
{
    public class SailorMercury : SailorScout
    {
        public override ShapeType CharacterShape => ShapeType.RoundedRectangle;
        public override Brush CharacterBrush => Brushes.DodgerBlue;

        public SailorMercury(string playerName) : base(playerName + " (Sailor Mercury)", 110) { }

        protected override void InitializeMoves()
        {
            Moves.Add(new AttackMove("Shine Aqua Illusion", "Freezing water blast.", 20, 30, 95, "30% chance to lower opponent's Accuracy.",
                (attacker, defender) => {
                    string narrative = $"{attacker.Name} creates a 'Shine Aqua Illusion'!";
                    if (random.Next(1, 101) <= 30)
                    {
                        defender.ApplyStatusEffect(StatusEffect.AccuracyDown, 2);
                        narrative += $" The mist obscures {GetDisplayName(defender)}'s vision!";
                    }
                    return Tuple.Create(random.Next(20, 31), narrative);
                }
            ));

            Moves.Add(new AttackMove("Bubble Spray", "A thick, disorienting fog.", 0, 0, 100, "Raises user's Evasion for 3 turns.",
                (attacker, defender) => {
                    attacker.ApplyStatusEffect(StatusEffect.EvasionUp, 3);
                    return Tuple.Create(0, $"{attacker.Name} uses 'Bubble Spray' and becomes harder to see!");
                }
            ));

            Moves.Add(new AttackMove("Mercury Aqua Mirage", "Creates an optical illusion.", 0, 0, 90, "40% chance to lower opponent's Defense.",
                (attacker, defender) => {
                    string narrative = $"{attacker.Name} creates a 'Mercury Aqua Mirage'!";
                    if (random.Next(1, 101) <= 40)
                    {
                        defender.ApplyStatusEffect(StatusEffect.DefenseDown, 3);
                        narrative += $" It leaves {GetDisplayName(defender)} disoriented and vulnerable!";
                    }
                    return Tuple.Create(0, narrative);
                }
            ));
        }
    }
}