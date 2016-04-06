using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;

namespace Sample
{
    public partial class AnteprimaStampa : Form
    {
        public AnteprimaStampa(_FunzioniBase.Ritorno rt)
        {
            InitializeComponent();
            est.rt = rt;
        }
        public AnteprimaStampa()
        {
            InitializeComponent();
        }

        private void AnteprimaStampa_Load(object sender, EventArgs e)
        {

            
        }
    }
}
