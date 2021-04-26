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
    public partial class MenuForm : Form
    {
        public MenuForm(Form1 gameForm, GameModel gameModel)
        {            
            InitializeComponent();
            this.Closing += (sender, args) => {
                gameForm.timer.Start();
            }; 
            
             Controls.Add(Shuriken);
             Controls.Add(Kunai);
             Controls.Add(Bow);

             Shuriken.Click += (sender, args) =>
             {
                 var res = MessageBox.Show("Уверен, что хочешь купить?",
                     "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                 if (res != DialogResult.Yes) return;
                 if (gameModel.Scores == 50)
                 {
                     gameModel.Hero.Weapon =
                         new Weapon(3, 8, 4, new Vector(), new Vector(), WeaponTypeIcons.shuriken);
                     MessageBox.Show("ПОКУПКА СОВЕРШЕНА", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     gameModel.Scores -= 50;
                 }
                 else
                 {
                     MessageBox.Show("У ВАС НЕ ХВАТАЕТ ОЧКОВ ДЛЯ ПОКУПКИ ДАННОГО ОРУЖИЯ", "", MessageBoxButtons.OK,
                         MessageBoxIcon.Error);
                 }

             };
             
             Kunai.Click += (sender, args) =>
             {
                 var res = MessageBox.Show("Уверен, что хочешь купить?",
                     "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                 if (res != DialogResult.Yes) return;
                 if (gameModel.Scores == 100)
                 {
                     gameModel.Hero.Weapon = new Weapon(7, 4, 8, new Vector(), new Vector(), WeaponTypeIcons.kunai);
                     MessageBox.Show("ПОКУПКА СОВЕРШЕНА", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     gameModel.Scores -= 100;
                 }
                 else
                 {
                     MessageBox.Show("У ВАС НЕ ХВАТАЕТ ОЧКОВ ДЛЯ ПОКУПКИ ДАННОГО ОРУЖИЯ", "", MessageBoxButtons.OK,
                         MessageBoxIcon.Error);
                 }
             };

             Shuriken.Click += (sender, args) =>
             {
                 var res = MessageBox.Show("Уверен, что хочешь купить?",
                     "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                 if (res != DialogResult.Yes) return;
                 if (gameModel.Scores == 150)
                 {
                     gameModel.Hero.Weapon = new Weapon(12, 1, 11, new Vector(), new Vector(), WeaponTypeIcons.bow);
                     MessageBox.Show("ПОКУПКА СОВЕРШЕНА", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     gameModel.Scores -= 150;
                 }
                 else
                 {
                     MessageBox.Show("У ВАС НЕ ХВАТАЕТ ОЧКОВ ДЛЯ ПОКУПКИ ДАННОГО ОРУЖИЯ", "", MessageBoxButtons.OK,
                         MessageBoxIcon.Error);
                 }
             };
        }
    }
}