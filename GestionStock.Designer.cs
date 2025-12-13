namespace Projet_Pharmacie
{
    partial class GestionStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionStock));
            this.dgv_GS = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_Annuler = new System.Windows.Forms.Button();
            this.txt_ref = new System.Windows.Forms.TextBox();
            this.txt_Nouveau = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Btn_Modifier = new System.Windows.Forms.Button();
            this.Btn_AjouterN = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_nouveauPrix = new System.Windows.Forms.TextBox();
            this.txt_nouveauRef = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_nouveauType = new System.Windows.Forms.TextBox();
            this.txt_nouveauNom = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_nouveauQte = new System.Windows.Forms.TextBox();
            this.Btn_Supprimer = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_GS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_GS
            // 
            this.dgv_GS.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgv_GS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_GS.Location = new System.Drawing.Point(111, 55);
            this.dgv_GS.Name = "dgv_GS";
            this.dgv_GS.RowHeadersWidth = 51;
            this.dgv_GS.RowTemplate.Height = 24;
            this.dgv_GS.Size = new System.Drawing.Size(1155, 183);
            this.dgv_GS.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(46, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Les produits du stock : ";
            // 
            // Btn_Annuler
            // 
            this.Btn_Annuler.BackColor = System.Drawing.Color.LightGreen;
            this.Btn_Annuler.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Annuler.ForeColor = System.Drawing.Color.Black;
            this.Btn_Annuler.Location = new System.Drawing.Point(1210, 604);
            this.Btn_Annuler.Name = "Btn_Annuler";
            this.Btn_Annuler.Size = new System.Drawing.Size(160, 40);
            this.Btn_Annuler.TabIndex = 2;
            this.Btn_Annuler.Text = "Annuler";
            this.Btn_Annuler.UseVisualStyleBackColor = false;
            this.Btn_Annuler.Click += new System.EventHandler(this.Btn_Annuler_Click);
            // 
            // txt_ref
            // 
            this.txt_ref.Location = new System.Drawing.Point(151, 45);
            this.txt_ref.Name = "txt_ref";
            this.txt_ref.Size = new System.Drawing.Size(126, 24);
            this.txt_ref.TabIndex = 4;
            // 
            // txt_Nouveau
            // 
            this.txt_Nouveau.Location = new System.Drawing.Point(151, 112);
            this.txt_Nouveau.Name = "txt_Nouveau";
            this.txt_Nouveau.Size = new System.Drawing.Size(126, 24);
            this.txt_Nouveau.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Référence : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Nouveau prix :";
            // 
            // Btn_Modifier
            // 
            this.Btn_Modifier.BackColor = System.Drawing.Color.Green;
            this.Btn_Modifier.ForeColor = System.Drawing.Color.White;
            this.Btn_Modifier.Location = new System.Drawing.Point(167, 161);
            this.Btn_Modifier.Name = "Btn_Modifier";
            this.Btn_Modifier.Size = new System.Drawing.Size(156, 41);
            this.Btn_Modifier.TabIndex = 8;
            this.Btn_Modifier.Text = "Modifier";
            this.Btn_Modifier.UseVisualStyleBackColor = false;
            this.Btn_Modifier.Click += new System.EventHandler(this.Btn_Modifier_Click);
            // 
            // Btn_AjouterN
            // 
            this.Btn_AjouterN.BackColor = System.Drawing.Color.Green;
            this.Btn_AjouterN.ForeColor = System.Drawing.Color.White;
            this.Btn_AjouterN.Location = new System.Drawing.Point(565, 245);
            this.Btn_AjouterN.Name = "Btn_AjouterN";
            this.Btn_AjouterN.Size = new System.Drawing.Size(156, 41);
            this.Btn_AjouterN.TabIndex = 14;
            this.Btn_AjouterN.Text = "Ajouter le produit ";
            this.Btn_AjouterN.UseVisualStyleBackColor = false;
            this.Btn_AjouterN.Click += new System.EventHandler(this.Btn_AjouterN_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(418, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 18);
            this.label5.TabIndex = 13;
            this.label5.Text = "Prix : ";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(55, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 18);
            this.label6.TabIndex = 12;
            this.label6.Text = "Référence : ";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txt_nouveauPrix
            // 
            this.txt_nouveauPrix.Location = new System.Drawing.Point(565, 115);
            this.txt_nouveauPrix.Name = "txt_nouveauPrix";
            this.txt_nouveauPrix.Size = new System.Drawing.Size(110, 24);
            this.txt_nouveauPrix.TabIndex = 11;
            this.txt_nouveauPrix.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txt_nouveauRef
            // 
            this.txt_nouveauRef.Location = new System.Drawing.Point(200, 48);
            this.txt_nouveauRef.Name = "txt_nouveauRef";
            this.txt_nouveauRef.Size = new System.Drawing.Size(110, 24);
            this.txt_nouveauRef.TabIndex = 10;
            this.txt_nouveauRef.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(55, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 18);
            this.label8.TabIndex = 18;
            this.label8.Text = "Type :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(418, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 18);
            this.label9.TabIndex = 17;
            this.label9.Text = "Nom produit : ";
            // 
            // txt_nouveauType
            // 
            this.txt_nouveauType.Location = new System.Drawing.Point(200, 115);
            this.txt_nouveauType.Name = "txt_nouveauType";
            this.txt_nouveauType.Size = new System.Drawing.Size(110, 24);
            this.txt_nouveauType.TabIndex = 16;
            // 
            // txt_nouveauNom
            // 
            this.txt_nouveauNom.Location = new System.Drawing.Point(565, 48);
            this.txt_nouveauNom.Name = "txt_nouveauNom";
            this.txt_nouveauNom.Size = new System.Drawing.Size(110, 24);
            this.txt_nouveauNom.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(55, 183);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 18);
            this.label10.TabIndex = 20;
            this.label10.Text = "Quantité : ";
            // 
            // txt_nouveauQte
            // 
            this.txt_nouveauQte.Location = new System.Drawing.Point(200, 180);
            this.txt_nouveauQte.Name = "txt_nouveauQte";
            this.txt_nouveauQte.Size = new System.Drawing.Size(110, 24);
            this.txt_nouveauQte.TabIndex = 19;
            // 
            // Btn_Supprimer
            // 
            this.Btn_Supprimer.BackColor = System.Drawing.Color.Green;
            this.Btn_Supprimer.ForeColor = System.Drawing.Color.White;
            this.Btn_Supprimer.Location = new System.Drawing.Point(167, 40);
            this.Btn_Supprimer.Name = "Btn_Supprimer";
            this.Btn_Supprimer.Size = new System.Drawing.Size(156, 41);
            this.Btn_Supprimer.TabIndex = 21;
            this.Btn_Supprimer.Text = "Supprimer ";
            this.Btn_Supprimer.UseVisualStyleBackColor = false;
            this.Btn_Supprimer.Click += new System.EventHandler(this.Btn_Supprimer_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_ref);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_Nouveau);
            this.groupBox1.Controls.Add(this.Btn_Modifier);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(111, 268);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 214);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modifier le prix d\'un produit";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Btn_Supprimer);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.groupBox2.Location = new System.Drawing.Point(111, 498);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(340, 87);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sélectionner et supprimer un produit";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txt_nouveauRef);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.Btn_AjouterN);
            this.groupBox3.Controls.Add(this.txt_nouveauQte);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txt_nouveauNom);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txt_nouveauType);
            this.groupBox3.Controls.Add(this.txt_nouveauPrix);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.groupBox3.Location = new System.Drawing.Point(522, 268);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(744, 317);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ajouter un nouveau produit au stock ";
            // 
            // GestionStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1382, 656);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Btn_Annuler);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_GS);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GestionStock";
            this.Text = "GestionStock";
            this.Load += new System.EventHandler(this.GestionStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_GS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_GS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_Annuler;
        private System.Windows.Forms.TextBox txt_ref;
        private System.Windows.Forms.TextBox txt_Nouveau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Btn_Modifier;
        private System.Windows.Forms.Button Btn_AjouterN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_nouveauPrix;
        private System.Windows.Forms.TextBox txt_nouveauRef;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_nouveauType;
        private System.Windows.Forms.TextBox txt_nouveauNom;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_nouveauQte;
        private System.Windows.Forms.Button Btn_Supprimer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}