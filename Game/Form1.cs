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

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1(GameModel game)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            AutoSizeMode = AutoSizeMode.GrowAndShrink;

            var PathToImages = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.FullName +
                "\\Images\\";

            
            var background = new PictureBox()
            {
                SizeMode = PictureBoxSizeMode.StretchImage,
                Tag = "background",
                Size = new Size(2000, 500),
                Location = new Point(0, 0),
                BackgroundImage = Image.FromFile(PathToImages + "background.png"),
                Visible = true,
            };
            

            

            foreach (var environmentEl in game.EnvironmentObjects) {
                Controls.Add(environmentEl);
            }
            Controls.Add(game.Hero);
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
                switch (args.KeyCode)
                {
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
                switch (args.KeyCode)
                {
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
                game.Hero.Top += jumpSpeed;
                game.Hero.Refresh();
                
                if (jumping && force < 0)
                {
                    jumping = false;
                }
                if (jumping)
                {
                    jumpSpeed = -150;
                    force = -1;
                }
                else jumpSpeed = 35;
                if (goLeft)
                {
                    if (game.Hero.Left > 50)
                        game.Hero.Left -= playerSpeed;
                    if (background.Left < 0)
                    {
                        background.Left += backLeft;
                        foreach (Control control in Controls)
                        {
                            if (control.Tag == "tree" || control.Tag == "platform")
                                control.Left += backLeft;
                        }
                    }
                }

                if (goRight)
                {
                    if ((game.Hero.Left + game.Hero.Width + 50) < ClientSize.Width)
                        game.Hero.Left += playerSpeed;
                    if (background.Left < 500)
                    {
                        Console.WriteLine(background.Left);
                        background.Left -= backLeft;
                        foreach (Control control in Controls)
                        {
                            if (control.Tag == "tree" || control.Tag == "platform")
                                control.Left -= backLeft;
                        }
                    }
                }

                foreach (Control control in Controls)
                {
                    if (control is PictureBox && control.Tag == "platform")
                    {
                        if (!jumping && game.Hero.Bounds.IntersectsWith(control.Bounds))
                        {
                            force = 8;
                            game.Hero.Top = control.Top - game.Hero.Height;
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