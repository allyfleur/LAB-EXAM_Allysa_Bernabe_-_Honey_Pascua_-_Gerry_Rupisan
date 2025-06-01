using System;

namespace IPT__Fianls_Lab_Exam
{
    public class AttackMove
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public int Accuracy { get; set; }
        public string EffectDetails { get; set; }
        public Func<SailorScout, SailorScout, Tuple<int, string>> ExecuteAction { get; set; }

        public AttackMove(string name, string description, int minDamage, int maxDamage, int accuracy,
                          string effectDetails, Func<SailorScout, SailorScout, Tuple<int, string>> executeAction)
        {
            this.Name = name;
            this.Description = description;
            this.MinDamage = minDamage;
            this.MaxDamage = maxDamage;
            this.Accuracy = accuracy;
            this.EffectDetails = effectDetails;
            this.ExecuteAction = executeAction;
        }

        public override string ToString()
        {
            return $"{Name} (Dmg: {MinDamage}-{MaxDamage}, Acc: {Accuracy}%)";
        }

        public string GetFullDescription()
        {
            return $"{Description}\nDamage: {MinDamage}-{MaxDamage} | Accuracy: {Accuracy}%\nEffects: {EffectDetails}";
        }
    }
}