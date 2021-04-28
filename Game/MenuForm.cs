using Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class MenuForm : Form {
        public MenuForm(Form1 gameForm, GameModel game) {            
            InitializeComponent();
            this.Closing += (sender, args) => {
                gameForm.timer.Start();
            };
            ScoresBox.Text = game.Scores.ToString();
            Controls.Add(Shuriken);
            Controls.Add(Kunai);
            Controls.Add(Bow);
            Controls.Add(ScoresBox);
            Shuriken.Click += (sender, args) => {
                if (game.Scores >= 50) {
                    game.Scores -= 50;
                    game.Hero.Weapon.ChangeWeapon(new Weapon(
                        new System.Drawing.Size(30, 30),
                        new System.Drawing.Point(Location.X, Location.Y),
                        WeaponTypeIcons.shuriken, 3, 8, 4, new Vector(), new Vector(), game.Hero));
                    MessageBox.Show("ПОКУПКА СОВЕРШЕНА", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else {
                    MessageBox.Show("У ВАС НЕ ХВАТАЕТ ОЧКОВ ДЛЯ ПОКУПКИ ДАННОГО ОРУЖИЯ", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            };
             
            Kunai.Click += (sender, args) => {
                if (game.Scores >= 100) {
                    game.Scores -= 100;
                    game.Hero.Weapon.ChangeWeapon(new Weapon(
                        new System.Drawing.Size(30, 30), 
                        new System.Drawing.Point(Location.X, Location.Y),
                        WeaponTypeIcons.kunai, 7, 4, 8, new Vector(), new Vector(), game.Hero));
                    MessageBox.Show("ПОКУПКА СОВЕРШЕНА", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else {
                    MessageBox.Show("У ВАС НЕ ХВАТАЕТ ОЧКОВ ДЛЯ ПОКУПКИ ДАННОГО ОРУЖИЯ", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            };

            Bow.Click += (sender, args) => {
                if (game.Scores >= 150) {
                    game.Scores -= 150;
                    game.Hero.Weapon.ChangeWeapon(new Weapon(
                        new System.Drawing.Size(30, 30),
                        new System.Drawing.Point(Location.X, Location.Y),
                        WeaponTypeIcons.bow, 12, 1, 11, new Vector(), new Vector(), game.Hero));
                    MessageBox.Show("ПОКУПКА СОВЕРШЕНА", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else {
                    MessageBox.Show("У ВАС НЕ ХВАТАЕТ ОЧКОВ ДЛЯ ПОКУПКИ ДАННОГО ОРУЖИЯ", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            };

        }
    }
}