using System;
using System.Drawing;

namespace IPT__Fianls_Lab_Exam
{
    public class SailorJupiter : SailorScout
    {
        public override ShapeType CharacterShape => ShapeType.Square;
        public override Brush CharacterBrush => Brushes.DarkGreen;

        public SailorJupiter(string playerName) : base(playerName + " (Sailor Jupiter)", 105) { }

        protected override void InitializeMoves()
        {
            Moves.Add(new AttackMove("Supreme Thunder", "A powerful lightning bolt.", 35, 45, 85, "A strong electric attack.",
                (attacker, defender) => Tuple.Create(random.Next(35, 46), $"{attacker.Name} calls 'Supreme Thunder'!")
            ));

            Moves.Add(new AttackMove("Flower Hurricane", "A storm of sharp petals.", 15, 20, 90, "Hits 2-3 times.",
                (attacker, defender) => {
                    int hits = random.Next(2, 4);
                    int totalDamage = 0;
                    for (int i = 0; i < hits; i++) totalDamage += random.Next(15, 21);
                    return Tuple.Create(totalDamage, $"{attacker.Name} whips up a 'Flower Hurricane', hitting {hits} times!");
                }
            ));

            Moves.Add(new AttackMove("Jupiter Power, Make Up!", "Gathers strength from storms.", 0, 0, 100, "Boosts the user's Attack for the next 3 turns.",
                (attacker, defender) => {
                    attacker.ApplyStatusEffect(StatusEffect.AttackUp, 3);
                    return Tuple.Create(0, $"{attacker.Name} is charged with electrical energy!");
                }
            ));
        }
    }
}