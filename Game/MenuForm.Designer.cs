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
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Shuriken = new System.Windows.Forms.PictureBox();
            this.Kunai = new System.Windows.Forms.PictureBox();
            this.Bow = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ScoresBox = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Shuriken)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Kunai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bow)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(75, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(333, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Shuriken
            // 
            this.Shuriken.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Shuriken.Image = ((System.Drawing.Image)(resources.GetObject("Shuriken.Image")));
            this.Shuriken.Location = new System.Drawing.Point(33, 146);
            this.Shuriken.Margin = new System.Windows.Forms.Padding(2);
            this.Shuriken.Name = "Shuriken";
            this.Shuriken.Size = new System.Drawing.Size(90, 98);
            this.Shuriken.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Shuriken.TabIndex = 1;
            this.Shuriken.TabStop = false;
            // 
            // Kunai
            // 
            this.Kunai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Kunai.Image = ((System.Drawing.Image)(resources.GetObject("Kunai.Image")));
            this.Kunai.Location = new System.Drawing.Point(195, 146);
            this.Kunai.Margin = new System.Windows.Forms.Padding(2);
            this.Kunai.Name = "Kunai";
            this.Kunai.Size = new System.Drawing.Size(90, 98);
            this.Kunai.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Kunai.TabIndex = 2;
            this.Kunai.TabStop = false;
            // 
            // Bow
            // 
            this.Bow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Bow.Image = ((System.Drawing.Image)(resources.GetObject("Bow.Image")));
            this.Bow.Location = new System.Drawing.Point(359, 146);
            this.Bow.Margin = new System.Windows.Forms.Padding(2);
            this.Bow.Name = "Bow";
            this.Bow.Size = new System.Drawing.Size(90, 98);
            this.Bow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Bow.TabIndex = 3;
            this.Bow.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(11, 264);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 37);
            this.label1.TabIndex = 4;
            this.label1.Text = "50 ОЧКОВ";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(165, 264);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 37);
            this.label2.TabIndex = 5;
            this.label2.Text = "100 ОЧКОВ\r\n";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(330, 263);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 38);
            this.label3.TabIndex = 6;
            this.label3.Text = "150 ОЧКОВ";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.LimeGreen;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(21, 364);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(276, 28);
            this.label4.TabIndex = 7;
            this.label4.Text = "КОЛИЧЕСТВО ОЧКОВ:";
            // 
            // ScoresBox
            // 
            this.ScoresBox.BackColor = System.Drawing.Color.LimeGreen;
            this.ScoresBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ScoresBox.Location = new System.Drawing.Point(289, 364);
            this.ScoresBox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ScoresBox.Name = "ScoresBox";
            this.ScoresBox.Size = new System.Drawing.Size(105, 28);
            this.ScoresBox.TabIndex = 8;
            this.ScoresBox.Text = "0";
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LimeGreen;
            this.ClientSize = new System.Drawing.Size(482, 401);
            this.Controls.Add(this.ScoresBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Bow);
            this.Controls.Add(this.Kunai);
            this.Controls.Add(this.Shuriken);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MENU";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Shuriken)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Kunai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bow)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label ScoresBox;

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