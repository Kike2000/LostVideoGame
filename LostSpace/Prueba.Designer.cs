namespace LostSpace
{
    partial class Prueba
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.claseDiseño1 = new LostSpace.ClaseDiseño();
            this.button1 = new System.Windows.Forms.Button();
            this.claseDiseño1.SuspendLayout();
            this.SuspendLayout();
            // 
            // claseDiseño1
            // 
            this.claseDiseño1.Angle = 60F;
            this.claseDiseño1.BackColor = System.Drawing.Color.Black;
            this.claseDiseño1.BottomColor = System.Drawing.Color.Empty;
            this.claseDiseño1.Controls.Add(this.button1);
            this.claseDiseño1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.claseDiseño1.Location = new System.Drawing.Point(0, 0);
            this.claseDiseño1.Name = "claseDiseño1";
            this.claseDiseño1.Size = new System.Drawing.Size(417, 405);
            this.claseDiseño1.TabIndex = 0;
            this.claseDiseño1.TopColor = System.Drawing.Color.Maroon;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(169, 263);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Prueba
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 405);
            this.ControlBox = false;
            this.Controls.Add(this.claseDiseño1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Prueba";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Prueba";
            this.Load += new System.EventHandler(this.Prueba_Load);
            this.claseDiseño1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ClaseDiseño claseDiseño1;
        private System.Windows.Forms.Button button1;
    }
}