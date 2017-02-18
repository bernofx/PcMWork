using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using _FunzioniBase;



namespace Sample
{
    public partial class Form1 : Form
    {
        
        public Form1(_FunzioniBase.Ritorno rt)
        {
            
            InitializeComponent();
            est.rt = rt;
        }
        public Form1()
        {

            InitializeComponent();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
            
            

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        
    }
}
