namespace Sample
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.visualizzaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.est = new Estensione(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.menuStrip2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(945, 531);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 43);
            this.dataGridView2.Name = "dataGridView2";
            this.est.SetNomeAzioneCambioValore(this.dataGridView2, "");
            this.est.SetNomeTabella(this.dataGridView2, "GrigliaClienti");
            this.dataGridView2.Size = new System.Drawing.Size(868, 485);
            this.dataGridView2.TabIndex = 1;
            // 
            // menuStrip2
            // 
            this.menuStrip2.AllowMerge = false;
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visualizzaToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem2});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip2.Size = new System.Drawing.Size(874, 40);
            this.menuStrip2.TabIndex = 2;
            this.menuStrip2.Text = "menuStrip2";
            this.menuStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // visualizzaToolStripMenuItem
            // 
            this.visualizzaToolStripMenuItem.Image = global::Sample.Properties.Resources.page_preview;
            this.visualizzaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.visualizzaToolStripMenuItem.Name = "visualizzaToolStripMenuItem";
            this.est.SetNomeAzioneMenu(this.visualizzaToolStripMenuItem, "VisualizzaCliente");
            this.visualizzaToolStripMenuItem.Size = new System.Drawing.Size(101, 36);
            this.visualizzaToolStripMenuItem.Text = "Visualizza";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::Sample.Properties.Resources.page_edit1;
            this.toolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.est.SetNomeAzioneMenu(this.toolStripMenuItem1, "ApriCliente");
            this.toolStripMenuItem1.Size = new System.Drawing.Size(73, 36);
            this.toolStripMenuItem1.Text = "Apri";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = global::Sample.Properties.Resources.document;
            this.toolStripMenuItem3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.est.SetNomeAzioneMenu(this.toolStripMenuItem3, "NuovoCliente");
            this.toolStripMenuItem3.Size = new System.Drawing.Size(87, 36);
            this.toolStripMenuItem3.Text = "Nuovo";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Image = global::Sample.Properties.Resources.ov_gear;
            this.toolStripMenuItem4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.est.SetNomeAzioneMenu(this.toolStripMenuItem4, "CopiaCliente");
            this.toolStripMenuItem4.Size = new System.Drawing.Size(82, 36);
            this.toolStripMenuItem4.Text = "Copia";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::Sample.Properties.Resources.delete_page;
            this.toolStripMenuItem2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.est.SetNomeAzioneMenu(this.toolStripMenuItem2, "EliminaCliente");
            this.toolStripMenuItem2.Size = new System.Drawing.Size(90, 36);
            this.toolStripMenuItem2.Text = "Elimina";
            // 
            // Form1
            // 
            this.est.SetAggiornaForm(this, "MostraClientiForm");
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 531);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip2;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.est.SetNomeAzioneCambioValore(this, "");
            this.est.SetNomeForm(this, "frmClientiGrid");
            this.Text = "Clienti";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView2;
        public Estensione est;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem visualizzaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
    }
}

