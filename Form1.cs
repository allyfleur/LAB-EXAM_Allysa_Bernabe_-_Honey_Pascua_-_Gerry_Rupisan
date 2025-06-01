using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace IPT__Fianls_Lab_Exam
{
    public partial class Form1 : Form
    {
        private SailorScout player1;
        private SailorScout player2;
        private SailorScout currentPlayer;
        private bool isPlayer1Turn = true;

        private Dictionary<string, Type> characterTypes = new Dictionary<string, Type>();

        private Brush hitBrush = new SolidBrush(Color.FromArgb(200, 255, 255, 100)); // Yellow-white flash
        private bool player1IsHit = false;
        private bool player2IsHit = false;

        private Rectangle player1Rect = new Rectangle(50, 160, 80, 80);
        private Rectangle player2Rect = new Rectangle(440, 40, 80, 80);

        private List<Point> stars;
        private Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            InitializeStarfield();
            this.DoubleBuffered = true; // For smoother graphics
        }

        private void InitializeStarfield()
        {
            stars = new List<Point>();
            for (int i = 0; i < 100; i++)
            {
                stars.Add(new Point(rand.Next(this.Width), rand.Next(this.Height)));
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach (Point star in stars)
            {
                g.FillEllipse(Brushes.White, star.X, star.Y, 2, 2);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateCharacterTypes();
            foreach (var charName in characterTypes.Keys)
            {
                cmbPlayer1Char.Items.Add(charName);
                cmbPlayer2Char.Items.Add(charName);
            }
            if (cmbPlayer1Char.Items.Count > 0) cmbPlayer1Char.SelectedIndex = 0;
            if (cmbPlayer2Char.Items.Count > 1) cmbPlayer2Char.SelectedIndex = 1;

            ResetUIAndGame();
        }

        private void PopulateCharacterTypes()
        {
            characterTypes.Clear();
            characterTypes.Add("Sailor Moon", typeof(SailorMoon));
            characterTypes.Add("Sailor Mars", typeof(SailorMars));
            characterTypes.Add("Sailor Mercury", typeof(SailorMercury));
            characterTypes.Add("Sailor Jupiter", typeof(SailorJupiter));
        }

        private void ResetUIAndGame()
        {
            lstBattleLog.Items.Clear();
            lblWinner.Text = "";
            lblP1NameDisplay.Text = txtPlayer1Name.Text;
            lblP2NameDisplay.Text = txtPlayer2Name.Text;

            player1 = null;
            player2 = null;
            currentPlayer = null;

            btnStartBattle.Text = "Start Battle!";
            btnStartBattle.Enabled = true;
            EnableSetupControls(true);
            ToggleAttackUI(false);
            lblAttackDescription.Text = "Attack Details Appear Here...";
            lstAttackChoices.Items.Clear();

            player1IsHit = false;
            player2IsHit = false;
            pnlBattleScene.Invalidate();
        }

        private void EnableSetupControls(bool enabled)
        {
            txtPlayer1Name.Enabled = enabled;
            cmbPlayer1Char.Enabled = enabled;
            txtPlayer2Name.Enabled = enabled;
            cmbPlayer2Char.Enabled = enabled;
        }

        private void ToggleAttackUI(bool show)
        {
            lstAttackChoices.Visible = show;
            lblAttackDescription.Visible = show;
            btnExecuteAttack.Visible = show;
        }

        private void btnStartBattle_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnStartBattle.Text.Contains("Start"))
                {
                    if (string.IsNullOrWhiteSpace(txtPlayer1Name.Text) || string.IsNullOrWhiteSpace(txtPlayer2Name.Text) ||
                        cmbPlayer1Char.SelectedItem == null || cmbPlayer2Char.SelectedItem == null)
                    {
                        MessageBox.Show("Please fill player names and select characters.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    InitializeBattle();
                }
                else if (btnStartBattle.Text.StartsWith("Prepare"))
                {
                    PrepareTurn();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetUIAndGame();
            }
        }

        // --- INTERACTIVITY FOR BUTTONS ---
        private void btnStartBattle_MouseEnter(object sender, EventArgs e)
        {
            btnStartBattle.BackColor = Color.FromArgb(60, 60, 100);
        }

        private void btnStartBattle_MouseLeave(object sender, EventArgs e)
        {
            btnStartBattle.BackColor = Color.FromArgb(40, 40, 80);
        }

        private void btnExecuteAttack_MouseEnter(object sender, EventArgs e)
        {
            btnExecuteAttack.BackColor = Color.FromArgb(220, 50, 120);
        }

        private void btnExecuteAttack_MouseLeave(object sender, EventArgs e)
        {
            btnExecuteAttack.BackColor = Color.FromArgb(200, 30, 100);
        }

        private void InitializeBattle()
        {
            ResetUIAndGame();

            Type p1Type = characterTypes[cmbPlayer1Char.SelectedItem.ToString()];
            player1 = (SailorScout)Activator.CreateInstance(p1Type, txtPlayer1Name.Text);

            Type p2Type = characterTypes[cmbPlayer2Char.SelectedItem.ToString()];
            player2 = (SailorScout)Activator.CreateInstance(p2Type, txtPlayer2Name.Text);

            lblP1NameDisplay.Text = player1.Name;
            lblP2NameDisplay.Text = player2.Name;
            AddToBattleLog($"Battle Started: {player1.Name} vs {player2.Name}!");
            EnableSetupControls(false);

            isPlayer1Turn = true;
            currentPlayer = player1;
            btnStartBattle.Text = $"Prepare {SailorScout.GetDisplayName(currentPlayer)}'s Turn";
            pnlBattleScene.Invalidate();
        }

        private void PrepareTurn()
        {
            string turnStartMessage = currentPlayer.HandleTurnStartStatusEffects();
            if (!string.IsNullOrWhiteSpace(turnStartMessage))
            {
                AddToBattleLog(turnStartMessage);
                pnlBattleScene.Invalidate();
            }

            if (DeclareWinner())
            {
                EndBattle();
                return;
            }

            LoadAttackChoicesForCurrentPlayer();
            btnStartBattle.Enabled = false;
            ToggleAttackUI(true);
        }

        private void btnExecuteAttack_Click(object sender, EventArgs e)
        {
            if (currentPlayer == null || player1.IsDefeated() || player2.IsDefeated())
            {
                EndBattle();
                return;
            }

            if (lstAttackChoices.SelectedItem is AttackMove chosenMove)
            {
                SailorScout attacker = currentPlayer;
                SailorScout defender = (currentPlayer == player1) ? player2 : player1;
                int defenderOldHealth = defender.Health;

                string attackLog = attacker.ExecuteChosenAttack(defender, chosenMove);
                AddToBattleLog(attackLog);

                if (defender.Health < defenderOldHealth)
                {
                    if (defender == player1) player1IsHit = true;
                    else player2IsHit = true;
                    hitEffectTimer.Start();
                }

                attacker.TickDownStatusEffects();
                pnlBattleScene.Invalidate();
                ToggleAttackUI(false);

                if (DeclareWinner())
                {
                    EndBattle();
                }
                else
                {
                    isPlayer1Turn = !isPlayer1Turn;
                    currentPlayer = isPlayer1Turn ? player1 : player2;
                    btnStartBattle.Text = $"Prepare {SailorScout.GetDisplayName(currentPlayer)}'s Turn";
                    btnStartBattle.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Please select an attack.", "No Attack Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadAttackChoicesForCurrentPlayer()
        {
            if (currentPlayer == null) return;
            AddToBattleLog($"{SailorScout.GetDisplayName(currentPlayer)}, choose your attack!");

            lstAttackChoices.Items.Clear();
            lblAttackDescription.Text = "Select an attack to see details.";

            foreach (var move in currentPlayer.Moves)
            {
                lstAttackChoices.Items.Add(move);
            }

            if (lstAttackChoices.Items.Count > 0)
            {
                lstAttackChoices.SelectedIndex = 0;
            }
        }

        private void AddToBattleLog(string message)
        {
            lstBattleLog.Items.Add(message.Replace("\n", " "));
            if (lstBattleLog.Items.Count > 0)
            {
                lstBattleLog.SelectedIndex = lstBattleLog.Items.Count - 1;
                lstBattleLog.ClearSelected();
            }
        }

        private bool DeclareWinner()
        {
            if (player1 == null || player2 == null) return false;

            if (player1.IsDefeated() || player2.IsDefeated())
            {
                string winnerName = player1.IsDefeated() ? player2.Name : player1.Name;
                lblWinner.Text = $"Winner: {winnerName}!";
                AddToBattleLog($"{winnerName} is victorious!");
                return true;
            }
            return false;
        }

        private void EndBattle()
        {
            btnStartBattle.Text = "Start New Battle";
            btnStartBattle.Enabled = true;
            EnableSetupControls(true);
            ToggleAttackUI(false);
            hitEffectTimer.Stop();
        }

        // --- GRAPHICS & UI EVENT HANDLERS ---

        private void pnlBattleScene_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw space background and moon
            using (var bgBrush = new LinearGradientBrush(pnlBattleScene.ClientRectangle, Color.FromArgb(10, 10, 30), Color.FromArgb(30, 10, 50), 90F))
            {
                g.FillRectangle(bgBrush, pnlBattleScene.ClientRectangle);

                // Draw a crescent moon
                g.FillEllipse(Brushes.LightYellow, pnlBattleScene.Width - 100, 20, 60, 60);
                // Use the same brush to "erase" part of the moon, creating the crescent
                g.FillEllipse(bgBrush, pnlBattleScene.Width - 80, 15, 60, 60);
            }

            // Draw Stars
            for (int i = 0; i < 50; i++)
            {
                int x = rand.Next(pnlBattleScene.Width);
                int y = rand.Next(pnlBattleScene.Height);
                g.FillEllipse(Brushes.White, x, y, 2, 2);
            }

            if (player1 != null) DrawCharacter(g, player1, player1Rect, player1IsHit);
            if (player2 != null) DrawCharacter(g, player2, player2Rect, player2IsHit);
        }

        private void DrawCharacter(Graphics g, SailorScout character, Rectangle bounds, bool isHit)
        {
            // Draw shadow
            using (var shadowBrush = new SolidBrush(Color.FromArgb(80, 0, 0, 0)))
            {
                g.FillEllipse(shadowBrush, bounds.X + 5, bounds.Bottom - 5, bounds.Width - 10, 10);
            }

            // Draw glow effect
            using (var glowBrush = new SolidBrush(Color.FromArgb(100, 255, 255, 255)))
            {
                g.FillEllipse(glowBrush, bounds.X - 5, bounds.Y - 5, bounds.Width + 10, bounds.Height + 10);
            }

            Brush currentBrush = isHit ? hitBrush : character.CharacterBrush;
            using (var outlinePen = new Pen(Color.FromArgb(180, Color.Black), 2.5f))
            {
                switch (character.CharacterShape)
                {
                    case ShapeType.Circle: g.FillEllipse(currentBrush, bounds); g.DrawEllipse(outlinePen, bounds); break;
                    case ShapeType.Square: g.FillRectangle(currentBrush, bounds); g.DrawRectangle(outlinePen, bounds); break;
                    case ShapeType.Triangle:
                        Point[] triPoints = { new Point(bounds.X + bounds.Width / 2, bounds.Y), new Point(bounds.Right, bounds.Bottom), new Point(bounds.Left, bounds.Bottom) };
                        g.FillPolygon(currentBrush, triPoints); g.DrawPolygon(outlinePen, triPoints); break;
                    case ShapeType.RoundedRectangle:
                        using (GraphicsPath path = new GraphicsPath())
                        {
                            int r = 20;
                            path.AddArc(bounds.X, bounds.Y, r, r, 180, 90);
                            path.AddArc(bounds.Right - r, bounds.Y, r, r, 270, 90);
                            path.AddArc(bounds.Right - r, bounds.Bottom - r, r, r, 0, 90);
                            path.AddArc(bounds.X, bounds.Bottom - r, r, r, 90, 90);
                            path.CloseFigure();
                            g.FillPath(currentBrush, path); g.DrawPath(outlinePen, path);
                        }
                        break;
                }
            }

            DrawHealthBar(g, character, new Rectangle(bounds.X - 10, bounds.Y - 28, 100, 18));
            DrawStatusIcons(g, character, new Point(bounds.Left, bounds.Y - 28 - 18 - 2));
        }

        private void DrawHealthBar(Graphics g, SailorScout character, Rectangle bounds)
        {
            g.FillRectangle(new SolidBrush(Color.FromArgb(200, 0, 0, 0)), bounds.X - 1, bounds.Y - 1, bounds.Width + 2, bounds.Height + 2);
            g.FillRectangle(Brushes.DarkGray, bounds);

            float healthPercent = Math.Max(0, (float)character.Health / character.MaxHealth);
            Brush healthFillBrush = Brushes.LimeGreen;
            if (healthPercent < 0.5f) healthFillBrush = Brushes.Gold;
            if (healthPercent < 0.2f) healthFillBrush = Brushes.OrangeRed;

            g.FillRectangle(healthFillBrush, bounds.X + 1, bounds.Y + 1, (int)((bounds.Width - 2) * healthPercent), bounds.Height - 2);

            using (Font nameFont = new Font("Verdana", 7f, FontStyle.Bold))
            {
                TextRenderer.DrawText(g, SailorScout.GetDisplayName(character), nameFont, new Point(bounds.Left, bounds.Top - 14), Color.White);
                TextRenderer.DrawText(g, $"{character.Health}/{character.MaxHealth}", nameFont, new Point(bounds.Left, bounds.Bottom + 2), Color.White);
            }
        }

        private void DrawStatusIcons(Graphics g, SailorScout character, Point startLocation)
        {
            if (character.ActiveStatusEffects.Count == 0) return;
            int iconSize = 15, spacing = 2, currentX = startLocation.X;
            using (Font iconFont = new Font("Arial", 6.5f, FontStyle.Bold))
            {
                foreach (var effectEntry in character.ActiveStatusEffects)
                {
                    Rectangle iconRect = new Rectangle(currentX, startLocation.Y, iconSize, iconSize);
                    Brush bgBrush = Brushes.Transparent; string abr = "";
                    switch (effectEntry.Key)
                    {
                        case StatusEffect.Poisoned: bgBrush = Brushes.Purple; abr = "PSN"; break;
                        case StatusEffect.AttackUp: bgBrush = Brushes.OrangeRed; abr = "ATK↑"; break;
                        case StatusEffect.DefenseUp: bgBrush = Brushes.SteelBlue; abr = "DEF↑"; break;
                        case StatusEffect.AttackDown: bgBrush = Brushes.Gray; abr = "ATK↓"; break;
                        case StatusEffect.DefenseDown: bgBrush = Brushes.SaddleBrown; abr = "DEF↓"; break;
                        case StatusEffect.AccuracyDown: bgBrush = Brushes.SandyBrown; abr = "ACC↓"; break;
                        case StatusEffect.EvasionUp: bgBrush = Brushes.MediumSeaGreen; abr = "EVA↑"; break;
                    }
                    if (!string.IsNullOrEmpty(abr))
                    {
                        g.FillEllipse(bgBrush, iconRect);
                        TextRenderer.DrawText(g, abr, iconFont, iconRect, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                        currentX += iconSize + spacing;
                    }
                }
            }
        }

        private void hitEffectTimer_Tick(object sender, EventArgs e)
        {
            player1IsHit = false;
            player2IsHit = false;
            hitEffectTimer.Stop();
            pnlBattleScene.Invalidate();
        }

        private void lstAttackChoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAttackChoices.SelectedItem is AttackMove selectedMove)
            {
                lblAttackDescription.Text = selectedMove.GetFullDescription();
            }
        }
    }
}