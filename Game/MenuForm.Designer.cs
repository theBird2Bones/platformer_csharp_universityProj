using System.ComponentModel;

namespace WinFormsApp1
{
    partial class MenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Shuriken = new System.Windows.Forms.PictureBox();
            this.Kunai = new System.Windows.Forms.PictureBox();
            this.Bow = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.Shuriken)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.Kunai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.Bow)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image) (resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(100, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(444, 130);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Shuriken
            // 
            this.Shuriken.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Shuriken.Image = ((System.Drawing.Image) (resources.GetObject("Shuriken.Image")));
            this.Shuriken.Location = new System.Drawing.Point(44, 180);
            this.Shuriken.Name = "Shuriken";
            this.Shuriken.Size = new System.Drawing.Size(120, 120);
            this.Shuriken.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Shuriken.TabIndex = 1;
            this.Shuriken.TabStop = false;
            
            // 
            // Kunai
            // 
            this.Kunai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Kunai.Image = ((System.Drawing.Image) (resources.GetObject("Kunai.Image")));
            this.Kunai.Location = new System.Drawing.Point(260, 180);
            this.Kunai.Name = "Kunai";
            this.Kunai.Size = new System.Drawing.Size(120, 120);
            this.Kunai.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Kunai.TabIndex = 2;
            this.Kunai.TabStop = false;
            
            // 
            // Bow
            // 
            this.Bow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Bow.Image = ((System.Drawing.Image) (resources.GetObject("Bow.Image")));
            this.Bow.Location = new System.Drawing.Point(479, 180);
            this.Bow.Name = "Bow";
            this.Bow.Size = new System.Drawing.Size(120, 120);
            this.Bow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Bow.TabIndex = 3;
            this.Bow.TabStop = false;
            
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label1.Location = new System.Drawing.Point(28, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 34);
            this.label1.TabIndex = 4;
            this.label1.Text = "50 ОЧКОВ";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label2.Location = new System.Drawing.Point(242, 325);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 45);
            this.label2.TabIndex = 5;
            this.label2.Text = "100 ОЧКОВ\r\n";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label3.Location = new System.Drawing.Point(461, 325);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 47);
            this.label3.TabIndex = 6;
            this.label3.Text = "150 ОЧКОВ";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.LimeGreen;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label4.Location = new System.Drawing.Point(160, 448);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(318, 27);
            this.label4.TabIndex = 7;
            this.label4.Text = "КОЛИЧЕСТВО ОЧКОВ:";
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LimeGreen;
            this.ClientSize = new System.Drawing.Size(642, 493);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Bow);
            this.Controls.Add(this.Kunai);
            this.Controls.Add(this.Shuriken);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MENU";
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.Shuriken)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.Kunai)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.Bow)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox Kunai;

        private System.Windows.Forms.PictureBox Shuriken;

        private System.Windows.Forms.PictureBox Bow;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;

        private System.Windows.Forms.PictureBox pictureBox1;

        #endregion
    }
}