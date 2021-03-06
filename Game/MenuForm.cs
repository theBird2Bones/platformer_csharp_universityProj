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
            ScoresBox.Text = game.Scores.ToString();
            Controls.Add(Shuriken);
            Controls.Add(Kunai);
            Controls.Add(Bow);
            Controls.Add(platformMaker);
            Controls.Add(ScoresBox);
            Shuriken.Click += (sender, args) => {
                if (game.Scores >= 50) {
                    game.Scores -= 50;
                    ScoresBox.Text = game.Scores.ToString();
                    game.Hero.Weapon.ChangeWeapon(new Weapon(
                        new System.Drawing.Size(25, 25),
                        new System.Drawing.Point(Location.X, Location.Y),
                        WeaponType.shuriken, 6, 0.19, 4, 60, 10, new Vector(), game.Hero));
                    game.WeaponIcon.UpdateWeapon(game.Hero.Weapon.WeaponType);
                    MessageBox.Show("ПОКУПКА СОВЕРШЕНА", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else 
                    MessageBox.Show("У ВАС НЕ ХВАТАЕТ ОЧКОВ ДЛЯ ПОКУПКИ ДАННОГО ОРУЖИЯ", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            };
             
            Kunai.Click += (sender, args) => {
                if (game.Scores >= 100) {
                    game.Scores -= 100;
                    ScoresBox.Text = game.Scores.ToString();
                    game.Hero.Weapon.ChangeWeapon(new Weapon(
                        new System.Drawing.Size(30, 30), 
                        new System.Drawing.Point(Location.X, Location.Y),
                        WeaponType.kunai, 7, 0.23, 8, 80, 12, new Vector(), game.Hero));
                    game.WeaponIcon.UpdateWeapon(game.Hero.Weapon.WeaponType);
                    MessageBox.Show("ПОКУПКА СОВЕРШЕНА", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else 
                    MessageBox.Show("У ВАС НЕ ХВАТАЕТ ОЧКОВ ДЛЯ ПОКУПКИ ДАННОГО ОРУЖИЯ", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            };

            Bow.Click += (sender, args) => {
                if (game.Scores >= 150) {
                    game.Scores -= 150;
                    ScoresBox.Text = game.Scores.ToString();
                    game.Hero.Weapon.ChangeWeapon(new Weapon(
                        new System.Drawing.Size(35, 40),
                        new System.Drawing.Point(Location.X, Location.Y-10),
                        WeaponType.bow, 12, 0.3, 11, 150, 15, new Vector(), game.Hero));
                    game.WeaponIcon.UpdateWeapon(game.Hero.Weapon.WeaponType);
                    MessageBox.Show("ПОКУПКА СОВЕРШЕНА", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }               
                else 
                    MessageBox.Show("У ВАС НЕ ХВАТАЕТ ОЧКОВ ДЛЯ ПОКУПКИ ДАННОГО ОРУЖИЯ", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            };
            platformMaker.Click += (sender, args) => {
                if (game.Scores >= 200)
                {
                    game.Scores -= 200;
                    ScoresBox.Text = game.Scores.ToString();
                    game.Hero.Weapon.ChangeWeapon(new Weapon(
                        new System.Drawing.Size(56, 56),
                        new System.Drawing.Point(Location.X, Location.Y - 10),
                        WeaponType.platformMaker, 2, 1, 11, 0, 8, new Vector(), game.Hero));
                    game.WeaponIcon.UpdateWeapon(game.Hero.Weapon.WeaponType);
                    MessageBox.Show("ПОКУПКА СОВЕРШЕНА", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("У ВАС НЕ ХВАТАЕТ ОЧКОВ ДЛЯ ПОКУПКИ ДАННОГО ОРУЖИЯ", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            };
            this.Closing += (sender, args) => {
                gameForm.generalTimer.Start();
            };
        }
    }
}