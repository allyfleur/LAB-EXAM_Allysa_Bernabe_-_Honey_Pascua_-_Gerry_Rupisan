using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace IPT__Fianls_Lab_Exam
{
    public abstract class SailorScout
    {
        public string Name { get; protected set; }
        private int _health;
        public int Health
        {
            get => _health;
            set => _health = Math.Max(0, Math.Min(value, MaxHealth));
        }
        public int MaxHealth { get; protected set; }
        protected static Random random = new Random();
        public Dictionary<StatusEffect, int> ActiveStatusEffects { get; private set; }
        public abstract ShapeType CharacterShape { get; }
        public abstract Brush CharacterBrush { get; }
        public List<AttackMove> Moves { get; protected set; }

        public SailorScout(string name, int maxHealth)
        {
            this.Name = name;
            this.MaxHealth = maxHealth;
            this.Health = maxHealth;
            this.Moves = new List<AttackMove>();
            this.ActiveStatusEffects = new Dictionary<StatusEffect, int>();
            InitializeMoves();
        }

        protected abstract void InitializeMoves();

        public void ApplyStatusEffect(StatusEffect effect, int duration)
        {
            if (effect != StatusEffect.None)
            {
                ActiveStatusEffects[effect] = duration;
            }
        }

        public string HandleTurnStartStatusEffects()
        {
            string effectMessage = "";
            if (ActiveStatusEffects.ContainsKey(StatusEffect.Poisoned))
            {
                int poisonDamage = Math.Max(1, (int)(this.MaxHealth * 0.06)); // 6%
                this.Health -= poisonDamage;
                effectMessage += $"{this.Name} takes {poisonDamage} damage from poison! ";
            }
            return effectMessage.Trim();
        }

        public void TickDownStatusEffects()
        {
            var keys = ActiveStatusEffects.Keys.ToList();
            foreach (var key in keys)
            {
                ActiveStatusEffects[key]--;
                if (ActiveStatusEffects[key] <= 0)
                {
                    ActiveStatusEffects.Remove(key);
                }
            }
        }

        public string ExecuteChosenAttack(SailorScout opponent, AttackMove chosenMove)
        {
            if (chosenMove?.ExecuteAction == null)
            {
                return $"{this.Name} is hesitating...";
            }

            int effectiveAccuracy = chosenMove.Accuracy;
            if (this.ActiveStatusEffects.ContainsKey(StatusEffect.AccuracyDown)) effectiveAccuracy -= 20;
            if (opponent.ActiveStatusEffects.ContainsKey(StatusEffect.EvasionUp)) effectiveAccuracy -= 20;

            if (random.Next(1, 101) > effectiveAccuracy)
            {
                return $"{this.Name}'s {chosenMove.Name} missed!";
            }

            Tuple<int, string> attackResult = chosenMove.ExecuteAction(this, opponent);
            int baseDamage = attackResult.Item1;
            string attackNarrative = attackResult.Item2;

            float attackStatMultiplier = 1.0f;
            if (ActiveStatusEffects.ContainsKey(StatusEffect.AttackUp)) attackStatMultiplier += 0.5f;
            if (ActiveStatusEffects.ContainsKey(StatusEffect.AttackDown)) attackStatMultiplier -= 0.33f;

            int finalDamage = (int)(baseDamage * attackStatMultiplier);
            if (baseDamage > 0 && finalDamage <= 0) finalDamage = 1;

            string damageTakenMessage = "";
            if (finalDamage > 0)
            {
                float defenseMultiplier = 1.0f;
                if (opponent.ActiveStatusEffects.ContainsKey(StatusEffect.DefenseUp)) defenseMultiplier -= 0.33f;
                if (opponent.ActiveStatusEffects.ContainsKey(StatusEffect.DefenseDown)) defenseMultiplier += 0.33f;

                int finalDamageTaken = Math.Max(1, (int)(finalDamage * defenseMultiplier));
                opponent.Health -= finalDamageTaken;

                damageTakenMessage = $"{opponent.Name} takes {finalDamageTaken} damage!";
            }

            return $"{attackNarrative}\n{damageTakenMessage}".Trim();
        }

        public bool IsDefeated() => this.Health <= 0;
        public override string ToString() => Name;

        public static string GetDisplayName(SailorScout champion) =>
            champion.Name.Contains(" (") ? champion.Name.Substring(0, champion.Name.IndexOf(" (")) : champion.Name;
    }
}