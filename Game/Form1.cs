using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game{
    public partial class Form1 : Form{
        public Form1(){
            InitializeComponent();
            FormClosing += (sender, eventArgs) => {
                var res = MessageBox.Show("Уверен, что хочешь закрыть?",
                    "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res != DialogResult.Yes)
                    eventArgs.Cancel = true;
            };
            //BackgroundImage = ResourcesImages.tempBackground;
            DoubleBuffered = true;
            var time = 0;
            var timer = new Timer();
            timer.Interval = 5;
            timer.Tick += (s, arg) => {
                time++;
                Invalidate();
            };
            Paint += (s, a) => {
                var r = new Random();
                a.Graphics.DrawLine(new Pen(Color.Red, 15), 0, 0, r.Next(ClientSize.Width), r.Next(ClientSize.Height));

            };
            timer.Start();
        }
    }
}