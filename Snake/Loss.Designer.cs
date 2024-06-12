namespace Snake
{
    partial class Loss
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
            this.scored = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // scored
            // 
            this.scored.AutoSize = true;
            this.scored.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.scored.Location = new System.Drawing.Point(30, 32);
            this.scored.Name = "scored";
            this.scored.Size = new System.Drawing.Size(82, 31);
            this.scored.TabIndex = 0;
            this.scored.Text = "label1";
            // 
            // Loss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 315);
            this.Controls.Add(this.scored);
            this.Name = "Loss";
            this.Text = "Loss";
            this.Load += new System.EventHandler(this.Loss_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label scored;
    }
}