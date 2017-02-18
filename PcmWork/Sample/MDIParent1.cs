using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sample
{
    public partial class MDIParent1 : Form
    {
        
        private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();

        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Finestra " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "File di testo (*.txt)|*.txt|Tutti i file (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "File di testo (*.txt)|*.txt|Tutti i file (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        

      

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void anagraficaClientiToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
       
        public void MDIParent1_MdiChildActivate(object sender, EventArgs e)
        {
            List<Form> F_inPage = new List<Form>();

           
            if (this.ActiveMdiChild == null)
                tabForms.Visible = false;
            // If no any child form, hide tabControl 
            else
            {
                this.ActiveMdiChild.WindowState = FormWindowState.Maximized;
                this.ActiveMdiChild.MinimizeBox = false;
                this.ActiveMdiChild.MaximizeBox = false;
                // Child form always maximized 

                // If child form is new and no has tabPage, 
                // create new tabPage 
                if (this.ActiveMdiChild.Tag == null)
                {
                    // Add a tabPage to tabControl with child 
                    // form caption 
                    TabPage tp = new TabPage(this.ActiveMdiChild.Text);

                    tp.Tag = this.ActiveMdiChild;
                    tp.Parent = tabForms;
                    F_inPage.Add(this.ActiveMdiChild);
                    this.ActiveMdiChild.FormClosed += new FormClosedEventHandler(ActiveMdiChild_FormClosed);
                    est.Forms.Add(tp,F_inPage);
                    tabForms.SelectedTab = tp;

                    this.ActiveMdiChild.Tag = tp;

                }
                else
                {

                    if (!(est.Forms[this.ActiveMdiChild.Tag].Contains(this.ActiveMdiChild)))
                    {
                        ((TabPage)this.ActiveMdiChild.Tag).Text += " >> " + this.ActiveMdiChild.Text;
                        F_inPage = est.Forms[this.ActiveMdiChild.Tag];
                        F_inPage.Add(this.ActiveMdiChild);
                        this.ActiveMdiChild.FormClosed += new FormClosedEventHandler(ActiveMdiChild_FormClosed);
                    }
                    else
                        this.ActiveMdiChild.Refresh();

                   
                }
                
                

                if (!tabForms.Visible) tabForms.Visible = true;

            }
        }
        private void ActiveMdiChild_FormClosed(object sender,
                                    FormClosedEventArgs e)
        {
            List<Form> F_inPage = new List<Form>();
            bool usata = false;
            String testo = ((sender as Form).Tag as TabPage).Text;
            foreach (Form f in this.MdiChildren)
            {
                if ((f.Tag == (sender as Form).Tag) && (!(f==(sender as Form))))
                {
                    usata = true;
                }
                
            }
            if (!usata)
                ((sender as Form).Tag as TabPage).Dispose();
            else
                if (testo.Contains(">"))
                    ((sender as Form).Tag as TabPage).Text = testo.Substring(0, testo.LastIndexOf(">") - 2);
            F_inPage = est.Forms[((sender as Form).Tag as TabPage)];
            F_inPage.Remove(this.ActiveMdiChild);
        }
        private void tabForms_SelectedIndexChanged(object sender,
                                           EventArgs e)
        {
            List<Form> F_inPage = new List<Form>();
            foreach (TabPage tp in tabForms.TabPages)
            {
                if (!(tp == tabForms.SelectedTab))
                {
                    F_inPage = est.Forms[tp];
                    Estensione es = GetEst(F_inPage[F_inPage.Count - 1]);
                    es.nAttivato = 1;
                }

            }

            F_inPage = est.Forms[tabForms.SelectedTab];
            F_inPage[F_inPage.Count - 1].Select();

            
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private Estensione GetEst(Form f)
        {
            
            System.Reflection.FieldInfo pi = f.GetType().GetField("est");
            object propValue = pi.GetValue(f);
            return ((Estensione)propValue);

            

            //System.Reflection.TypeAttributes a = mei.DeclaringType.Attributes;
            
            
            
            
        }
       
    }
}
