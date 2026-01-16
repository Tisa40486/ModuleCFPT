namespace serie6_sol_kms
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
            btnEx1 = new Button();
            btnEx2 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnEx1
            // 
            btnEx1.FlatAppearance.BorderColor = Color.Blue;
            btnEx1.FlatAppearance.CheckedBackColor = Color.Cyan;
            btnEx1.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 192);
            btnEx1.FlatAppearance.MouseOverBackColor = Color.Cyan;
            btnEx1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnEx1.Location = new Point(250, 111);
            btnEx1.Name = "btnEx1";
            btnEx1.Padding = new Padding(10);
            btnEx1.Size = new Size(305, 96);
            btnEx1.TabIndex = 0;
            btnEx1.Text = "Exercice 1 : un animal";
            btnEx1.UseVisualStyleBackColor = true;
            btnEx1.Click += btnEx1_Click;
            // 
            // btnEx2
            // 
            btnEx2.FlatAppearance.BorderColor = Color.Blue;
            btnEx2.FlatAppearance.CheckedBackColor = Color.Cyan;
            btnEx2.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 192);
            btnEx2.FlatAppearance.MouseOverBackColor = Color.Cyan;
            btnEx2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnEx2.Location = new Point(250, 265);
            btnEx2.Name = "btnEx2";
            btnEx2.Padding = new Padding(10);
            btnEx2.Size = new Size(305, 96);
            btnEx2.TabIndex = 1;
            btnEx2.Text = "Exercice 2 : un Chien";
            btnEx2.UseVisualStyleBackColor = true;
            btnEx2.Click += btnEx2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(279, 26);
            label1.Name = "label1";
            label1.Size = new Size(241, 38);
            label1.TabIndex = 2;
            label1.Text = "M320 : l'héritage";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(btnEx2);
            Controls.Add(btnEx1);
            Name = "Form1";
            Text = "Serie 6 - héritage simple";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEx1;
        private Button btnEx2;
        private Label label1;
    }
}