namespace Sample
{
    partial class MDIParent1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.clientiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anagraficaClientiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tabForms = new System.Windows.Forms.TabControl();
            this.est = new Estensione(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientiToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1362, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            this.menuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip_ItemClicked);
            // 
            // clientiToolStripMenuItem
            // 
            this.clientiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.anagraficaClientiToolStripMenuItem});
            this.clientiToolStripMenuItem.Name = "clientiToolStripMenuItem";
            this.est.SetNomeAzioneMenu(this.clientiToolStripMenuItem, "");
            this.clientiToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.clientiToolStripMenuItem.Text = "Clienti";
            // 
            // anagraficaClientiToolStripMenuItem
            // 
            this.anagraficaClientiToolStripMenuItem.Name = "anagraficaClientiToolStripMenuItem";
            this.est.SetNomeAzioneMenu(this.anagraficaClientiToolStripMenuItem, "MostraClientiForm");
            this.anagraficaClientiToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.anagraficaClientiToolStripMenuItem.Text = "Anagrafica Clienti";
            this.anagraficaClientiToolStripMenuItem.Click += new System.EventHandler(this.anagraficaClientiToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 691);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1362, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(34, 17);
            this.toolStripStatusLabel.Text = "Stato";
            // 
            // tabForms
            // 
            this.tabForms.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabForms.Location = new System.Drawing.Point(0, 24);
            this.tabForms.Name = "tabForms";
            this.tabForms.SelectedIndex = 0;
            this.tabForms.Size = new System.Drawing.Size(1362, 22);
            this.tabForms.TabIndex = 4;
            this.tabForms.Visible = false;
            this.tabForms.SelectedIndexChanged += new System.EventHandler(this.tabForms_SelectedIndexChanged);
            // 
            // MDIParent1
            // 
            this.est.SetAggiornaForm(this, "");
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 713);
            this.Controls.Add(this.tabForms);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MDIParent1";
            this.est.SetNomeAzioneCambioValore(this, "");
            this.est.SetNomeForm(this, "");
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "PCM Work";
            this.MdiChildActivate += new System.EventHandler(this.MDIParent1_MdiChildActivate);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem clientiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anagraficaClientiToolStripMenuItem;
        private System.Windows.Forms.TabControl tabForms;
        public Estensione est;
    }
}



