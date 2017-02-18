using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sample
{
    public class FormBase : Form
    {
        public Estensione est;
        private System.ComponentModel.IContainer components;
       

       private void InitializeComponent()
       {
            this.components = new System.ComponentModel.Container();
            this.est = new Estensione(this.components);
            this.SuspendLayout();
            // 
            // FormBase
            // 
            this.est.SetAggiornaForm(this, "");
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBase";
            this.est.SetNomeForm(this, "");
            this.Load += new System.EventHandler(this.FormBase_Load);
            this.ResumeLayout(false);

       }
       public Estensione getEst()
       {
           return this.est;
       }
       private void FormBase_Load(object sender, EventArgs e)
       {

       }
    }
}
