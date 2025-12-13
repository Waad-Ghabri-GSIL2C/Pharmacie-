namespace Projet_Pharmacie
{
    partial class ValidationVente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ValidationVente));
            this.dgvListeVente = new System.Windows.Forms.DataGridView();
            this.PrixTotal = new System.Windows.Forms.Label();
            this.lblPrixTotal = new System.Windows.Forms.Label();
            this.btnValiderVente = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListeVente)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListeVente
            // 
            this.dgvListeVente.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvListeVente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListeVente.Location = new System.Drawing.Point(97, 93);
            this.dgvListeVente.Name = "dgvListeVente";
            this.dgvListeVente.RowHeadersWidth = 51;
            this.dgvListeVente.RowTemplate.Height = 24;
            this.dgvListeVente.Size = new System.Drawing.Size(850, 150);
            this.dgvListeVente.TabIndex = 0;
            // 
            // PrixTotal
            // 
            this.PrixTotal.AutoSize = true;
            this.PrixTotal.Location = new System.Drawing.Point(125, 265);
            this.PrixTotal.Name = "PrixTotal";
            this.PrixTotal.Size = new System.Drawing.Size(0, 16);
            this.PrixTotal.TabIndex = 1;
            // 
            // lblPrixTotal
            // 
            this.lblPrixTotal.AutoSize = true;
            this.lblPrixTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrixTotal.ForeColor = System.Drawing.Color.Red;
            this.lblPrixTotal.Location = new System.Drawing.Point(189, 302);
            this.lblPrixTotal.Name = "lblPrixTotal";
            this.lblPrixTotal.Size = new System.Drawing.Size(64, 18);
            this.lblPrixTotal.TabIndex = 2;
            this.lblPrixTotal.Text = "0.000DT";
            // 
            // btnValiderVente
            // 
            this.btnValiderVente.BackColor = System.Drawing.Color.Green;
            this.btnValiderVente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValiderVente.ForeColor = System.Drawing.Color.White;
            this.btnValiderVente.Location = new System.Drawing.Point(824, 365);
            this.btnValiderVente.Name = "btnValiderVente";
            this.btnValiderVente.Size = new System.Drawing.Size(194, 49);
            this.btnValiderVente.TabIndex = 3;
            this.btnValiderVente.Text = "Valider Vente ";
            this.btnValiderVente.UseVisualStyleBackColor = false;
            this.btnValiderVente.Click += new System.EventHandler(this.btnValiderVente_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(49, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "L\'ordonnance ( la liste de ventes ) : ";
            // 
            // ValidationVente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1048, 442);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnValiderVente);
            this.Controls.Add(this.lblPrixTotal);
            this.Controls.Add(this.PrixTotal);
            this.Controls.Add(this.dgvListeVente);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ValidationVente";
            this.Text = "ValidationVente";
            this.Load += new System.EventHandler(this.ValidationVente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListeVente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListeVente;
        private System.Windows.Forms.Label PrixTotal;
        private System.Windows.Forms.Label lblPrixTotal;
        private System.Windows.Forms.Button btnValiderVente;
        private System.Windows.Forms.Label label1;
    }
}