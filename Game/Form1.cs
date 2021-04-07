using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1{
    public partial class Form1 : Form{
        public Form1(){
            InitializeComponent();
			
			
            Width = 600;
            Height = 500;
            StartPosition = FormStartPosition.CenterScreen;
            //BackgroundImage = Image.FromFile(@"..\Image");
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            var platform = new PictureBox(){
               // BackColor = Color.Red,
                SizeMode = PictureBoxSizeMode.AutoSize,
                Tag = "platform",
                Size = new Size(2000,60),
                Location = new Point(0, ClientSize.Height-60),
                BackgroundImage = Image.FromFile(@"C:\Users\Konstantine\Desktop\Учеба\Программирование\C#\Игра\GameOfTheCentury\Images\onlyGround.png"),
                Visible = true,
            };
            
            Controls.Add(platform);
			
			FormClosing += (sender, eventArgs) => {
                var res = MessageBox.Show("Уверен, что хочешь закрыть?",
                    "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res != DialogResult.Yes)
                    eventArgs.Cancel = true;
            };

        }
    }
}