using Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mime;
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
            
            AutoSizeMode = AutoSizeMode.GrowAndShrink;

            var PathToImages = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName +
                "\\Images\\";
            
            var platform = new PictureBox(){
                SizeMode = PictureBoxSizeMode.StretchImage,
                Tag = "platform",
                Size = new Size(2000,60),
                Location = new Point(0, ClientSize.Height-60),
                BackgroundImage = Image.FromFile(PathToImages + "onlyGround.png"),
                Visible = true,
            };
            var platform2 = new PictureBox(){
                SizeMode = PictureBoxSizeMode.StretchImage,
                Tag = "platform",
                Size = new Size(120,60),
                Location = new Point(400, ClientSize.Height-240),
                BackgroundImage = Image.FromFile(PathToImages + "onlyGround.png"),
                Visible = true,
            };
            var background = new PictureBox() {
                SizeMode = PictureBoxSizeMode.StretchImage,
                Tag = "background",
                Size = new Size(2000, 500),
                Location = new Point(0, 0),
                BackgroundImage = Image.FromFile(PathToImages + "background.png"),
                Visible = true,
            };
            var player = new PictureBox() {
                SizeMode = PictureBoxSizeMode.StretchImage,
                Tag = "player",
                Size = new Size(30, 40),
                Location = new Point(300, platform.Location.Y - 40),
                BackgroundImage = Image.FromFile(PathToImages + "mushroom.png"),
                Visible = true,
            };

            var tree = new PictureBox() {
                SizeMode = PictureBoxSizeMode.StretchImage,
                Tag = "tree",
                Size = new Size(150, 300),
                Location = new Point(600, platform.Location.Y - 300),
                BackgroundImage = Image.FromFile(PathToImages + "thirdTree.png"),
                Visible = true,
            };
            
            Controls.Add(platform);
            Controls.Add(platform2);
            Controls.Add(player);
            Controls.Add(tree);
            Controls.Add(background);
			
            bool goLeft = false; // boolean which will control players going left
            bool goRight = false; // boolean which will control players going right
            bool jumping = false; // boolean to check if player is jumping or not
 
            int jumpSpeed = 12; // integer to set jump speed
            int force = 8; // force of the jump in an integer
            int score = 0; // default score integer set to 0
 
            int playerSpeed = 18; //this integer will set players speed to 18
            int backLeft = 8; // this integer will set the background moving speed to 8

            KeyDown += (sender, args) => {
                switch (args.KeyCode) {
                    case Keys.Left:  
                        goLeft = true;
                        break;
                    case Keys.Right:  
                        goRight = true;
                        break;
                    case Keys.Space:
                        if (!jumping)
                            jumping = true;
                        break;
                }
            };
            KeyUp += (sender, args) => {
                switch (args.KeyCode) {
                    case Keys.Left:  
                        goLeft = false;
                        break;
                    case Keys.Right:  
                        goRight = false;
                        break;
                    case Keys.Space:
                        if (jumping)
                            jumping = false;
                        break;
                }
            };
            var timer = new Timer();
            timer.Interval = 43;
            timer.Tick += (sender, args) => {
                player.Top += jumpSpeed;
                player.Refresh();
                if (jumping && force < 0) {
                    jumping = false;
                }

                if (jumping) {
                    jumpSpeed = -150;
                    force = -1;
                }

                else jumpSpeed = 35;
                if (goLeft) {
                    if(player.Left > 50)
                        player.Left -= playerSpeed;
                    if (background.Left < 0) {
                        background.Left += backLeft;
                        foreach (Control control in Controls) {
                            if (control.Tag == "tree" || control.Tag == "platform")
                                control.Left += backLeft;
                        }
                    }
                }
                
                if (goRight) {
                    if((player.Left + player.Width + 50) < ClientSize.Width)
                        player.Left += playerSpeed;
                    if (background.Left < 500) {
                        Console.WriteLine(background.Left);
                        background.Left -= backLeft;
                        foreach (Control control in Controls) {
                            if (control.Tag == "tree" || control.Tag == "platform")
                                control.Left -= backLeft;
                        }
                    }
                }

                foreach (Control control in Controls) {
                    if (control is PictureBox && control.Tag == "platform") {
                        if (!jumping && player.Bounds.IntersectsWith(control.Bounds)) {
                            force = 8;
                            player.Top = control.Top - player.Height;
                            jumpSpeed = 0;
                        }
                    }
                }
            };
            timer.Start();
            FormClosing += (sender, eventArgs) => {
                var res = MessageBox.Show("Уверен, что хочешь закрыть?",
                    "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res != DialogResult.Yes)
                    eventArgs.Cancel = true;
            };
        }
    }
}