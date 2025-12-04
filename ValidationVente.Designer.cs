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
            this.dgvListeVente = new System.Windows.Forms.DataGridView();
            this.PrixTotal = new System.Windows.Forms.Label();
            this.lblPrixTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListeVente)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListeVente
            // 
            this.dgvListeVente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListeVente.Location = new System.Drawing.Point(106, 61);
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
            this.lblPrixTotal.Location = new System.Drawing.Point(149, 288);
            this.lblPrixTotal.Name = "lblPrixTotal";
            this.lblPrixTotal.Size = new System.Drawing.Size(57, 16);
            this.lblPrixTotal.TabIndex = 2;
            this.lblPrixTotal.Text = "0.000DT";
            // 
            // ValidationVente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 450);
            this.Controls.Add(this.lblPrixTotal);
            this.Controls.Add(this.PrixTotal);
            this.Controls.Add(this.dgvListeVente);
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
    }
}