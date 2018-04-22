using System;
using System.Drawing;
namespace MyApp
{
    partial class MyCanvas
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();

            //
            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.BackColor = Color.White;
            this.label1.Name = "Score";
            this.label1.Size = new System.Drawing.Size(30, 30);
            this.label1.Font = new Font("Arial", 15, FontStyle.Bold);

            // label2
            this.label2.AutoSize = true;
            this.label2.BackColor = Color.White;
            this.label2.Name = "Level";
            this.label2.Location = new System.Drawing.Point(450, 10);
            this.label2.Size = new System.Drawing.Size(100, 30);
            this.label2.Font = new Font("Arial", 15, FontStyle.Bold);

            // label3
            this.label3.AutoSize = true;
            this.label3.BackColor = Color.White;
            this.label3.Name = "High Score";
            this.label3.Location = new System.Drawing.Point(200, 10);
            this.label3.Size = new System.Drawing.Size(100, 30);
            this.label3.Font = new Font("Arial", 15, FontStyle.Bold);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Name = "Canvas";
            this.Text = "Canvas";
            this.Load += new System.EventHandler(this.CanvasLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer timer2;
    }
}
