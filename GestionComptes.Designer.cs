namespace Projet_Pharmacie 
{
    partial class GestionComptes
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
            this.dgv_ComptePhar = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prenom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MotDePasse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSuppPhar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIDPhar = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNomPhar = new System.Windows.Forms.TextBox();
            this.txtPrePhar = new System.Windows.Forms.TextBox();
            this.txtLogPhar = new System.Windows.Forms.TextBox();
            this.txtMDPPhar = new System.Windows.Forms.TextBox();
            this.txtEmailPhar = new System.Windows.Forms.TextBox();
            this.btnAjouterPhar = new System.Windows.Forms.Button();
            this.btnAnnulerPhar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ComptePhar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_ComptePhar
            // 
            this.dgv_ComptePhar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ComptePhar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Nom,
            this.Prenom,
            this.Login,
            this.MotDePasse,
            this.Email});
            this.dgv_ComptePhar.Location = new System.Drawing.Point(133, 62);
            this.dgv_ComptePhar.Name = "dgv_ComptePhar";
            this.dgv_ComptePhar.RowHeadersWidth = 51;
            this.dgv_ComptePhar.RowTemplate.Height = 24;
            this.dgv_ComptePhar.Size = new System.Drawing.Size(803, 206);
            this.dgv_ComptePhar.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Width = 125;
            // 
            // Nom
            // 
            this.Nom.HeaderText = "Nom";
            this.Nom.MinimumWidth = 6;
            this.Nom.Name = "Nom";
            this.Nom.Width = 125;
            // 
            // Prenom
            // 
            this.Prenom.HeaderText = "Prénom";
            this.Prenom.MinimumWidth = 6;
            this.Prenom.Name = "Prenom";
            this.Prenom.Width = 125;
            // 
            // Login
            // 
            this.Login.HeaderText = "Login";
            this.Login.MinimumWidth = 6;
            this.Login.Name = "Login";
            this.Login.Width = 125;
            // 
            // MotDePasse
            // 
            this.MotDePasse.HeaderText = "MotDePasse";
            this.MotDePasse.MinimumWidth = 6;
            this.MotDePasse.Name = "MotDePasse";
            this.MotDePasse.Width = 125;
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            this.Email.Width = 125;
            // 
            // btnSuppPhar
            // 
            this.btnSuppPhar.Location = new System.Drawing.Point(44, 544);
            this.btnSuppPhar.Name = "btnSuppPhar";
            this.btnSuppPhar.Size = new System.Drawing.Size(303, 44);
            this.btnSuppPhar.TabIndex = 1;
            this.btnSuppPhar.Text = "Supprimer ce pharmacien ";
            this.btnSuppPhar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID (CIN) :";
            // 
            // txtIDPhar
            // 
            this.txtIDPhar.Location = new System.Drawing.Point(141, 42);
            this.txtIDPhar.Name = "txtIDPhar";
            this.txtIDPhar.Size = new System.Drawing.Size(127, 22);
            this.txtIDPhar.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAjouterPhar);
            this.groupBox1.Controls.Add(this.txtEmailPhar);
            this.groupBox1.Controls.Add(this.txtMDPPhar);
            this.groupBox1.Controls.Add(this.txtLogPhar);
            this.groupBox1.Controls.Add(this.txtPrePhar);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtNomPhar);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtIDPhar);
            this.groupBox1.Location = new System.Drawing.Point(44, 305);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1013, 205);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ajouter un nouveau pharmacien ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(341, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nom :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(644, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Prénom :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Login : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(341, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Mot de passe : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(644, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Email : ";
            // 
            // txtNomPhar
            // 
            this.txtNomPhar.Location = new System.Drawing.Point(446, 42);
            this.txtNomPhar.Name = "txtNomPhar";
            this.txtNomPhar.Size = new System.Drawing.Size(127, 22);
            this.txtNomPhar.TabIndex = 9;
            // 
            // txtPrePhar
            // 
            this.txtPrePhar.Location = new System.Drawing.Point(737, 42);
            this.txtPrePhar.Name = "txtPrePhar";
            this.txtPrePhar.Size = new System.Drawing.Size(127, 22);
            this.txtPrePhar.TabIndex = 10;
            // 
            // txtLogPhar
            // 
            this.txtLogPhar.Location = new System.Drawing.Point(141, 111);
            this.txtLogPhar.Name = "txtLogPhar";
            this.txtLogPhar.Size = new System.Drawing.Size(127, 22);
            this.txtLogPhar.TabIndex = 11;
            // 
            // txtMDPPhar
            // 
            this.txtMDPPhar.Location = new System.Drawing.Point(446, 111);
            this.txtMDPPhar.Name = "txtMDPPhar";
            this.txtMDPPhar.Size = new System.Drawing.Size(127, 22);
            this.txtMDPPhar.TabIndex = 12;
            // 
            // txtEmailPhar
            // 
            this.txtEmailPhar.Location = new System.Drawing.Point(737, 114);
            this.txtEmailPhar.Name = "txtEmailPhar";
            this.txtEmailPhar.Size = new System.Drawing.Size(127, 22);
            this.txtEmailPhar.TabIndex = 13;
            // 
            // btnAjouterPhar
            // 
            this.btnAjouterPhar.Location = new System.Drawing.Point(856, 155);
            this.btnAjouterPhar.Name = "btnAjouterPhar";
            this.btnAjouterPhar.Size = new System.Drawing.Size(141, 35);
            this.btnAjouterPhar.TabIndex = 5;
            this.btnAjouterPhar.Text = "Ajouter ";
            this.btnAjouterPhar.UseVisualStyleBackColor = true;
            // 
            // btnAnnulerPhar
            // 
            this.btnAnnulerPhar.Location = new System.Drawing.Point(871, 577);
            this.btnAnnulerPhar.Name = "btnAnnulerPhar";
            this.btnAnnulerPhar.Size = new System.Drawing.Size(186, 44);
            this.btnAnnulerPhar.TabIndex = 5;
            this.btnAnnulerPhar.Text = "Annuler";
            this.btnAnnulerPhar.UseVisualStyleBackColor = true;
            // 
            // GestionComptes
            // 
            // 
            // GestionComptes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 657);
            this.Controls.Add(this.btnAnnulerPhar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSuppPhar);
            this.Controls.Add(this.dgv_ComptePhar);
            this.Name = "GestionComptes";
            this.Text = "GestionComptes";
            this.Load += new System.EventHandler(this.GestionComptes_Load);
            this.btnAjouterPhar.Click += new System.EventHandler(this.btnAjouterPhar_Click);
            this.btnSuppPhar.Click += new System.EventHandler(this.btnSuppPhar_Click);
            this.btnAnnulerPhar.Click += new System.EventHandler(this.btnAnnulerPhar_Click);
            this.dgv_ComptePhar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ComptePhar_CellDoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ComptePhar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

            

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_ComptePhar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prenom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Login;
        private System.Windows.Forms.DataGridViewTextBoxColumn MotDePasse;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.Button btnSuppPhar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIDPhar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmailPhar;
        private System.Windows.Forms.TextBox txtMDPPhar;
        private System.Windows.Forms.TextBox txtLogPhar;
        private System.Windows.Forms.TextBox txtPrePhar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNomPhar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAjouterPhar;
        private System.Windows.Forms.Button btnAnnulerPhar;
    }
}