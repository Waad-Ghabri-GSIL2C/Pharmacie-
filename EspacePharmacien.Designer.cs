namespace Projet_Pharmacie
{
    partial class EspacePharmacien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EspacePharmacien));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BoxLogin1 = new System.Windows.Forms.TextBox();
            this.BoxMDP1 = new System.Windows.Forms.TextBox();
            this.BtnConnexion1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(221, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(221, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mot de passe : ";
            // 
            // BoxLogin1
            // 
            this.BoxLogin1.Location = new System.Drawing.Point(366, 129);
            this.BoxLogin1.Name = "BoxLogin1";
            this.BoxLogin1.Size = new System.Drawing.Size(171, 22);
            this.BoxLogin1.TabIndex = 2;
            this.BoxLogin1.TextChanged += new System.EventHandler(this.BoxLogin1_TextChanged);
            // 
            // BoxMDP1
            // 
            this.BoxMDP1.Location = new System.Drawing.Point(366, 201);
            this.BoxMDP1.Name = "BoxMDP1";
            this.BoxMDP1.Size = new System.Drawing.Size(171, 22);
            this.BoxMDP1.TabIndex = 3;
            // 
            // BtnConnexion1
            // 
            this.BtnConnexion1.BackColor = System.Drawing.Color.Green;
            this.BtnConnexion1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConnexion1.ForeColor = System.Drawing.Color.White;
            this.BtnConnexion1.Location = new System.Drawing.Point(256, 268);
            this.BtnConnexion1.Name = "BtnConnexion1";
            this.BtnConnexion1.Size = new System.Drawing.Size(190, 50);
            this.BtnConnexion1.TabIndex = 4;
            this.BtnConnexion1.Text = "Connexion";
            this.BtnConnexion1.UseVisualStyleBackColor = false;
            this.BtnConnexion1.Click += new System.EventHandler(this.BtnConnexion1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(55, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(399, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Veuillez saisir les informations fournies par l’administrateur :";
            // 
            // EspacePharmacien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(704, 408);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnConnexion1);
            this.Controls.Add(this.BoxMDP1);
            this.Controls.Add(this.BoxLogin1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EspacePharmacien";
            this.Text = "EspacePharmacien";
            this.Load += new System.EventHandler(this.EspacePharmacien_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BoxLogin1;
        private System.Windows.Forms.TextBox BoxMDP1;
        private System.Windows.Forms.Button BtnConnexion1;
        private System.Windows.Forms.Label label3;
    }
}