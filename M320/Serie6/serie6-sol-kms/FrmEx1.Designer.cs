namespace serie6_sol_kms
{
    partial class FrmEx1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblAnimal = new Label();
            btnNewName = new Button();
            txtNewName = new TextBox();
            SuspendLayout();
            // 
            // lblAnimal
            // 
            lblAnimal.AutoSize = true;
            lblAnimal.Location = new Point(168, 189);
            lblAnimal.Name = "lblAnimal";
            lblAnimal.Size = new Size(38, 15);
            lblAnimal.TabIndex = 5;
            lblAnimal.Text = "label1";
            lblAnimal.Click += lblAnimal_Click;
            // 
            // btnNewName
            // 
            btnNewName.Location = new Point(168, 118);
            btnNewName.Margin = new Padding(3, 2, 3, 2);
            btnNewName.Name = "btnNewName";
            btnNewName.Size = new Size(224, 38);
            btnNewName.TabIndex = 4;
            btnNewName.Text = "Renommer";
            btnNewName.UseVisualStyleBackColor = true;
            btnNewName.Click += btnNewName_Click;
            // 
            // txtNewName
            // 
            txtNewName.Location = new Point(168, 68);
            txtNewName.Margin = new Padding(3, 2, 3, 2);
            txtNewName.Name = "txtNewName";
            txtNewName.Size = new Size(224, 23);
            txtNewName.TabIndex = 3;
            txtNewName.TextChanged += txtNewName_TextChanged;
            // 
            // FrmEx1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 270);
            Controls.Add(lblAnimal);
            Controls.Add(btnNewName);
            Controls.Add(txtNewName);
            Margin = new Padding(2, 2, 2, 2);
            Name = "FrmEx1";
            Text = "S6 - Exercice 1 - un Animal";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAnimal;
        private Button btnNewName;
        private TextBox txtNewName;
    }
}