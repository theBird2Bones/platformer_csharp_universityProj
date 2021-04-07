using Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1{
    public partial class Form1 : Form{
        public Form1(GameClass game){
            InitializeComponent();
			
			
            Width = game.MapSize.X;
            Height = game.MapSize.Y;
            StartPosition = FormStartPosition.CenterScreen;
            //BackgroundImage = Image.FromFile(@"..\Image");
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            var imagesDirectory = new DirectoryInfo("Images");
            var myImage = imagesDirectory.GetFiles("onlyGround.png").First();
            var platform = new PictureBox(){
               // BackColor = Color.Red,
                SizeMode = PictureBoxSizeMode.AutoSize,
                Tag = "platform",
                Size = new Size(2000,60),
                Location = new Point(0, ClientSize.Height-60),
                BackgroundImage = Image.FromFile(myImage.FullName),
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