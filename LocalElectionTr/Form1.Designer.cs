namespace LocalElectionTr
{
    partial class Form1
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
            this.btnOykullan = new System.Windows.Forms.Button();
            this.btnSonuc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOykullan
            // 
            this.btnOykullan.Location = new System.Drawing.Point(131, 91);
            this.btnOykullan.Name = "btnOykullan";
            this.btnOykullan.Size = new System.Drawing.Size(134, 58);
            this.btnOykullan.TabIndex = 0;
            this.btnOykullan.Text = "Oy Kullan";
            this.btnOykullan.UseVisualStyleBackColor = true;
            this.btnOykullan.Click += new System.EventHandler(this.btnOykullan_Click);
            // 
            // btnSonuc
            // 
            this.btnSonuc.Location = new System.Drawing.Point(131, 166);
            this.btnSonuc.Name = "btnSonuc";
            this.btnSonuc.Size = new System.Drawing.Size(134, 58);
            this.btnSonuc.TabIndex = 0;
            this.btnSonuc.Text = "Sonuçlar";
            this.btnSonuc.UseVisualStyleBackColor = true;
            this.btnSonuc.Click += new System.EventHandler(this.btnSonuc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(403, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "TÜRKİYE CUMHURİYETİ YEREL SEÇİM";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 300);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSonuc);
            this.Controls.Add(this.btnOykullan);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOykullan;
        private System.Windows.Forms.Button btnSonuc;
        private System.Windows.Forms.Label label1;
    }
}

