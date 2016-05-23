using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Data.SqlClient;
using System.Data;
using CrystalDecisions.Windows.Forms;
using Microsoft.Reporting.WinForms;
using DateTimePickerWithBackColor;


[ProvideProperty("NomeTabella", typeof(DataGridView))]
[ProvideProperty("NomeForm", typeof(Form))]
[ProvideProperty("AggiornaForm", typeof(Form))]
[ProvideProperty("NomeAzione", typeof(Button))]
[ProvideProperty("NomeCampoS", typeof(TextBox))]
[ProvideProperty("NomeCampoN", typeof(NumericUpDown))]
[ProvideProperty("NomeTabellaCampoS", typeof(TextBox))]
[ProvideProperty("NomeTabellaCampoN", typeof(NumericUpDown))]
[ProvideProperty("NomeAzioneMenu", typeof(ToolStripMenuItem))]
[ProvideProperty("NomeCampoD", typeof(ComboBox))]
[ProvideProperty("NomeListaD", typeof(ComboBox))]
[ProvideProperty("NomeTabellaCampoD", typeof(ComboBox))]
[ProvideProperty("NomeReport", typeof(CrystalReportViewer))]
[ProvideProperty("NomeCampoData", typeof(BCDateTimePicker))]
[ProvideProperty("NomeTabellaData", typeof(BCDateTimePicker))]
[ProvideProperty("NomeTabellaB", typeof(CheckBox))]
[ProvideProperty("NomeCampoB", typeof(CheckBox))]
[ProvideProperty("NomeAzioneCambioValore", typeof(Control))]

  public  class Estensione :Component,IExtenderProvider
  {
    public class proprieta
    {
        public String NomeTabella = "";
        public String NomeForm = "";
        public String AggiornaForm = "";
        public String NomeAzione = "";
        public String NomeCampoS = "";
        public String NomeCampoN = "";
        public String NomeTabellaCampoS = "";
        public String NomeTabellaCampoN = "";
        public String NomeTabellaCampoD = "";
        public String NomeListaD = "";
        public String NomeCampoD = "";
        public String NomeReport = "";
        public String NomeCampoData = "";
        public String NomeTabellaData = "";
        public String NomeCampo = "";
        public String NomeAzioneCambioValore = "";
        public Object ValorePrecedente = null;

    }
    public List<Object> Oggetti = new List<Object>();
    
    public Dictionary<Object, List<Form>> Forms = new Dictionary<object,List<Form>>();
    
    public Dictionary<Object,proprieta> Prop = new Dictionary<Object,proprieta>();
    public _FunzioniBase.Ritorno rt = new _FunzioniBase.Ritorno();
    public int nAttivato = 0;
    private System.Drawing.Color Modificabile = System.Drawing.Color.Beige;
    private System.Drawing.Color NonModificabile = System.Drawing.Color.Gainsboro;
    private System.Drawing.Font FontMod = new System.Drawing.Font("Microsoft Sans Serif", 8, System.Drawing.FontStyle.Bold);
    private System.Drawing.Font FontNONMod = new System.Drawing.Font("Microsoft Sans Serif", 8, System.Drawing.FontStyle.Regular);
    public Estensione(IContainer container) : this(){
        

        // Necessario per il supporto della finestra di progettazione per la composizione della classe Windows.Forms
        if (!(container ==null)) {
            container.Add(this);
        }
        

    }
      private IContainer components;

      public Estensione(): base() {
          InitializeComponent();
      }
        private void InitializeComponent(){
            components = new System.ComponentModel.Container();
        }

        

         
        public String GetNomeTabella(Object myControl)
        { 
            // Insert code here.
            if (!Prop.ContainsKey(myControl))
            {
                return "";
            }
            return (Prop[myControl].NomeTabella);
        }
        public String GetNomeAzioneCambioValore(Object myControl)
        {
            // Insert code here.
            if (!Prop.ContainsKey(myControl))
            {
                return "";
            }
            return (Prop[myControl].NomeAzione);
        }
        public String GetNomeTabellaB(Object myControl)
        {
            // Insert code here.
            if (!Prop.ContainsKey(myControl))
            {
                return "";
            }
            return (Prop[myControl].NomeTabella);
        }
        public String GetNomeCampoB(Object myControl)
        {
            // Insert code here.
            if (!Prop.ContainsKey(myControl))
            {
                return "";
            }
            return (Prop[myControl].NomeCampo);
        }
        public String GetAggiornaForm(Object myControl)
        {
            // Insert code here.
            if (!Prop.ContainsKey(myControl))
            {
                return "";
            }
            return (Prop[myControl].AggiornaForm);
        }
        public String GetNomeAzione(Object myControl)
        {
            // Insert code here.
            if (!Prop.ContainsKey(myControl))
            {
                return "";
            }
            return (Prop[myControl].NomeAzione);
        }
        public String GetNomeCampoS(Object myControl)
        {
            // Insert code here.
            if (!Prop.ContainsKey(myControl))
            {
                return "";
            }
            return (Prop[myControl].NomeCampoS);
        }
        public String GetNomeReport(Object myControl)
        {
            // Insert code here.
            if (!Prop.ContainsKey(myControl))
            {
                return "";
            }
            return (Prop[myControl].NomeReport);
        }
        public String GetNomeTabellaCampoS(Object myControl)
        {
            // Insert code here.
            if (!Prop.ContainsKey(myControl))
            {
                return "";
            }
            return (Prop[myControl].NomeTabellaCampoS);
        }
        public String GetNomeCampoN(Object myControl)
        {
            // Insert code here.
            if (!Prop.ContainsKey(myControl))
            {
                return "";
            }
            return (Prop[myControl].NomeCampoN);
        }
        public String GetNomeCampoD(Object myControl)
        {
            // Insert code here.
            if (!Prop.ContainsKey(myControl))
            {
                return "";
            }
            return (Prop[myControl].NomeCampoD);
        }
        public String GetNomeListaD(Object myControl)
        {
            // Insert code here.
            if (!Prop.ContainsKey(myControl))
            {
                return "";
            }
            return (Prop[myControl].NomeListaD);
        }
        public String GetNomeTabellaCampoD(Object myControl)
        {
            // Insert code here.
            if (!Prop.ContainsKey(myControl))
            {
                return "";
            }
            return (Prop[myControl].NomeTabellaCampoD);
        }
        public void SetNomeCampoD(Object myControl, string value)
        {
            // Insert code here.
            if (!Prop.ContainsKey(myControl))
            {
                Prop.Add(myControl, new proprieta());
            }
            Prop[myControl].NomeCampoD = value;
            Oggetti.Add(myControl);

            ((ComboBox)myControl).DropDownStyle = ComboBoxStyle.DropDownList;
            ((ComboBox)myControl).FlatStyle = FlatStyle.Flat;
            ((ComboBox)myControl).BackColor = Modificabile;
            ((ComboBox)myControl).Font = FontMod;
            
            
        }
        public void SetNomeListaD(Object myControl, string value)
        {
            if (!Prop.ContainsKey(myControl))
            {
                Prop.Add(myControl, new proprieta());
            }
            Prop[myControl].NomeListaD = value;
        }
        public void SetNomeReport(Object myControl, string value)
        {
            if (!Prop.ContainsKey(myControl))
            {
                Prop.Add(myControl, new proprieta());
            }
            Prop[myControl].NomeReport = value;
            Oggetti.Add(myControl);
        }
        public void SetAggiornaForm(Object myControl, string value)
        {
            if (!Prop.ContainsKey(myControl))
            {
                Prop.Add(myControl, new proprieta());
            }
            Prop[myControl].AggiornaForm = value;
          
        }
        public void SetNomeTabellaCampoD(Object myControl, string value)
        {
            if (!Prop.ContainsKey(myControl))
            {
                Prop.Add(myControl, new proprieta());
            }
            Prop[myControl].NomeTabellaCampoD = value;
        }
        
        public String GetNomeTabellaCampoN(Object myControl)
        {
            // Insert code here.
            if (!Prop.ContainsKey(myControl))
            {
                return "";
            }
            return (Prop[myControl].NomeTabellaCampoN);
        }
        public String GetNomeTabellaData(Object myControl)
        {
            // Insert code here.
            if (!Prop.ContainsKey(myControl))
            {
                return "";
            }
            return (Prop[myControl].NomeTabella);
        }
        public String GetNomeCampoData(Object myControl)
        {
            // Insert code here.
            if (!Prop.ContainsKey(myControl))
            {
                return "";
            }
            return (Prop[myControl].NomeCampo);
        }
        public void AssegnaDataSource(object myControl,DataTable tabella)
        {
           
            BindingSource bs = new BindingSource();
           // tabella.Columns.Add("_Sel", typeof(Boolean));
            if (!(tabella.Columns.Contains("Id")))
                tabella.Columns.Add("Id", typeof(Int32));


            bs.DataSource = tabella;
            ((DataGridView)myControl).DataSource = bs;
            ((DataGridView)myControl).AutoGenerateColumns = true;
           
            ((DataGridView)myControl).Columns["Id"].Visible = false;
            //((DataGridView)myControl).Columns["_Sel"].Visible = false;
            ((DataGridView)myControl).SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ((DataGridView)myControl).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ((DataGridView)myControl).BackgroundColor = System.Drawing.SystemColors.Control;
            ((DataGridView)myControl).BorderStyle = BorderStyle.None;
            ((DataGridView)myControl).AllowUserToAddRows = false;
            ((DataGridView)myControl).AllowUserToDeleteRows = false;
            ((DataGridView)myControl).AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            ((DataGridView)myControl).Refresh();
            
           // ((DataGridView)myControl).SelectionChanged += new EventHandler(SelezioneCambiata);
        }

        public void SetNomeTabella(object myControl, string value)
        {
            if (!Prop.ContainsKey(myControl)){ 
                Prop.Add(myControl,new proprieta());
            }
            Prop[myControl].NomeTabella = value;
            Oggetti.Add(myControl);
            ((DataGridView)myControl).ReadOnly = false;
            ((DataGridView)myControl).DefaultCellStyle.BackColor = Modificabile;
            ((DataGridView)myControl).DefaultCellStyle.Font = FontMod;
            ((DataGridView)myControl).BackgroundColor = System.Drawing.Color.White;
        }
        public void SetNomeTabellaB(object myControl, string value)
        {
            if (!Prop.ContainsKey(myControl))
            {
                Prop.Add(myControl, new proprieta());
            }
            Prop[myControl].NomeTabella = value;
            
           
        }
        public void SetNomeCampoB(object myControl, string value)
        {
            if (!Prop.ContainsKey(myControl))
            {
                Prop.Add(myControl, new proprieta());
            }
            Prop[myControl].NomeCampo = value;
            Oggetti.Add(myControl);
            ((CheckBox)myControl).Enabled = true;
            ((CheckBox)myControl).BackColor = Modificabile;
        }
        public void SetNomeAzione(object myControl, string value)
        {
            if (!Prop.ContainsKey(myControl))
            {
                Prop.Add(myControl, new proprieta());
            }
            Prop[myControl].NomeAzione = value;
            Oggetti.Add(myControl);
            ((Button)myControl).Click += new EventHandler(EvtGestisciAzione);
        }
        public void SetNomeAzioneCambioValore(object myControl, string value)
        {
            if (!Prop.ContainsKey(myControl))
            {
                Prop.Add(myControl, new proprieta());
            }
            Prop[myControl].NomeAzione = value;
            if (!String.IsNullOrEmpty(value))
            {
                ((Control)myControl).GotFocus += (sender, eventArgs) =>
                                        {
                                            if (sender.GetType() == typeof(TextBox))
                                                Prop[sender].ValorePrecedente = ((TextBox)sender).Text;
                                            else
                                                if (sender.GetType() == typeof(NumericUpDown))
                                                    Prop[sender].ValorePrecedente = ((NumericUpDown)sender).Value;
                                                else
                                                    if (sender.GetType() == typeof(ComboBox))
                                                        Prop[sender].ValorePrecedente = ((ComboBox)sender).SelectedValue;
                                                    else
                                                        if (sender.GetType() == typeof(CheckBox))
                                                            Prop[sender].ValorePrecedente = ((CheckBox)sender).Checked;
                                                        else
                                                            if (sender.GetType() == typeof(BCDateTimePicker))
                                                                Prop[sender].ValorePrecedente = ((BCDateTimePicker)sender).Value;
                                                
                                        };
                ((Control)myControl).Validated += new EventHandler(confrontaValori);
            }
        }
        public void SetNomeCampoS(object myControl, string value)
        {
            if (!Prop.ContainsKey(myControl))
            {
                Prop.Add(myControl, new proprieta());
            }
            Prop[myControl].NomeCampoS = value;
            Oggetti.Add(myControl);
            ((TextBox)myControl).ReadOnly = false;
            ((TextBox)myControl).BackColor = Modificabile;
            ((TextBox)myControl).Font = FontMod;
        }
        public void SetNomeTabellaCampoS(object myControl, string value)
        {
            if (!Prop.ContainsKey(myControl))
            {
                Prop.Add(myControl, new proprieta());
            }
            Prop[myControl].NomeTabellaCampoS = value;
        }
        public void SetNomeCampoN(object myControl, string value)
        {
            if (!Prop.ContainsKey(myControl))
            {
                Prop.Add(myControl, new proprieta());
            }
            Prop[myControl].NomeCampoN = value;
            Oggetti.Add(myControl);

            ((NumericUpDown)myControl).ReadOnly = false;
            ((NumericUpDown)myControl).BackColor = Modificabile;
            ((NumericUpDown)myControl).Font = FontMod;
        }
        public void SetNomeCampoData(object myControl, string value)
        {
            if (!Prop.ContainsKey(myControl))
            {
                Prop.Add(myControl, new proprieta());
            }
            Prop[myControl].NomeCampo = value;
            Oggetti.Add(myControl);

            ((BCDateTimePicker)myControl).Enabled = true;
            ((BCDateTimePicker)myControl).BackColor = Modificabile;
            ((BCDateTimePicker)myControl).Font = FontMod;
            ((BCDateTimePicker)myControl).Format = DateTimePickerFormat.Custom;
            ((BCDateTimePicker)myControl).CustomFormat="dd/MM/yyyy";
        }
        public void SetNomeTabellaData(object myControl, string value)
        {
            if (!Prop.ContainsKey(myControl))
            {
                Prop.Add(myControl, new proprieta());
            }
            Prop[myControl].NomeTabella = value;
            
        }
        public void SetNomeTabellaCampoN(object myControl, string value)
        {
            if (!Prop.ContainsKey(myControl))
            {
                Prop.Add(myControl, new proprieta());
            }
            Prop[myControl].NomeTabellaCampoN = value;
            
        }
        public String GetNomeForm(Object myControl)
        {
            // Insert code here.
            if (!Prop.ContainsKey(myControl))
            {
                return "";
            }
            return Prop[myControl].NomeForm;
        }

        public void SetNomeForm(Object myControl,string value)
        {
            // Insert code here.
                 if (!Prop.ContainsKey(myControl)){ 
                    Prop.Add(myControl,new proprieta());
                }
                Prop[myControl].NomeForm = value;
                Oggetti.Add(myControl);

        if (!(value == ""))
        {
                if (!((Form)myControl).IsMdiContainer)
                {
                    ((Form)myControl).WindowState = System.Windows.Forms.FormWindowState.Maximized;
                    ((Form)myControl).ControlBox = false;
                    ((Form)myControl).MaximizeBox = false;
                    ((Form)myControl).MinimizeBox = false;
                    ((Form)myControl).FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
                    ((Form)myControl).Load += new EventHandler(OnFormLoad);
                    ((Form)myControl).Activated += new EventHandler(OnFormActivate);
                    if (((Form)myControl).IsMdiContainer)
                    {
                        ((Form)myControl).ControlBox = true;
                        ((Form)myControl).MaximizeBox = true;
                        ((Form)myControl).MinimizeBox = true;
                    }
                }
                ((Form)myControl).FormClosing += (sender, e) => {
                    e.Cancel = false;
                };
            }
        }
        public void SetNomeAzioneMenu(Object myControl, string value)
        {
            if (!Prop.ContainsKey(myControl))
            {
                Prop.Add(myControl, new proprieta());
            }
            Prop[myControl].NomeAzione = value;
            Oggetti.Add(myControl);
            if (!(String.IsNullOrEmpty(value)))
                ((ToolStripMenuItem)myControl).Click += new EventHandler(EvtGestisciAzione);
        }
        public String GetNomeAzioneMenu(Object myControl)
        {
            if (!Prop.ContainsKey(myControl))
            {
                return "";
            }
            return Prop[myControl].NomeAzione;
        }
        public bool CanExtend(Object target)
        {
            Boolean ritorno = false;
            if (target.GetType()==typeof(Form)) ritorno = true;
            if (target.GetType() == typeof(DataGridView)) ritorno = true;
            if (target.GetType() == typeof(Button)) ritorno = true;
            if (target.GetType() == typeof(TextBox)) ritorno = true;
            if (target.GetType() == typeof(NumericUpDown)) ritorno = true;
            if (target.GetType() == typeof(ToolStripMenuItem)) ritorno = true;
            if (target.GetType() == typeof(ComboBox)) ritorno = true;
            if (target.GetType() == typeof(CheckBox)) ritorno = true;
            if (target.GetType() == typeof(BCDateTimePicker)) ritorno = true;
            if (target.GetType() == typeof(CrystalReportViewer)) ritorno = true;
            
            return ritorno;
        }
        private void confrontaValori(object sender, EventArgs e) {
            bool cambiato;
            object valoreAttuale=null;

            


            if (sender.GetType() == typeof(TextBox))
                valoreAttuale = (((TextBox)sender).Text);
            else
                if (sender.GetType() == typeof(NumericUpDown))
                    valoreAttuale = (((NumericUpDown)sender).Value);
                else
                    if (sender.GetType() == typeof(ComboBox))
                        valoreAttuale = (((ComboBox)sender).SelectedValue);
                    else
                        if (sender.GetType() == typeof(CheckBox))
                            valoreAttuale = (((CheckBox)sender).Checked);
                        else
                            if (sender.GetType() == typeof(BCDateTimePicker))
                                valoreAttuale = (((BCDateTimePicker)sender).Value);


            if (Object.Equals(Prop[sender].ValorePrecedente,valoreAttuale) )
                cambiato = false;
            else
                cambiato = true;

            if (cambiato)
            {
                Prop[sender].ValorePrecedente = valoreAttuale;

                GestisciAzione(sender);
            }
        }
        private void OnFormActivate(object sender, EventArgs e)
        {
            if (nAttivato > 1)
            {
                List<DataTable> TabOriginali = new List<DataTable>();
                List<_FunzioniBase.Tabella> Par = new List<_FunzioniBase.Tabella>();
                //Par = RecuperaTabelle(ref TabOriginali, this.rt);

                if (GetAggiornaForm(sender).Length > 0)
                {
                    AggiungiArg(ref Par, "Azione", GetAggiornaForm(sender));

                    EseguiAzione(Par);
                }
            }
            nAttivato += 1;

        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            nAttivato += 1;
            AssegnaTabelle(this.rt, (Form)sender);
            
        }
        private void AssegnaCampo(Object myControl, Object valore)
        {
            if (myControl.GetType() == typeof(TextBox))
            {
                ((TextBox)myControl).Text = valore.ToString();

            }
            if (myControl.GetType() == typeof(NumericUpDown))
            {
                ((NumericUpDown)myControl).Value = Convert.ToDecimal(valore);

            }
            if (myControl.GetType() == typeof(BCDateTimePicker))
            {
                ((BCDateTimePicker)myControl).Value = Convert.ToDateTime(valore);

            }
            if (myControl.GetType() == typeof(CheckBox))
            {
                ((CheckBox)myControl).Checked = Convert.ToBoolean(valore);

            }
        }
        private void AssegnaTabelle(_FunzioniBase.Ritorno rt, Control frm)
        {
            foreach (object c in Oggetti)
            {
               

                    if (c.GetType() == typeof(DataGridView))
                    {
                        foreach (DataTable Tabella in rt.Tabelle)
                        {
                            if (this.GetNomeTabella(c) == Tabella.TableName)
                            {
                                this.AssegnaDataSource(c, Tabella);
                            }
                        }
                    }
                    else if (c.GetType() == typeof(TextBox))
                    {
                        foreach (DataTable Tabella in rt.Tabelle)
                        {
                            if (this.GetNomeTabellaCampoS(c) == Tabella.TableName)
                            {
                               foreach (DataColumn Colonna in Tabella.Columns)
                                {
                                    if (this.GetNomeCampoS(c) == Colonna.ColumnName)
                                    {
                                        this.AssegnaCampo(c, Tabella.Rows[0][Colonna.ColumnName]);
                                    }
                                }
                            }
                        }
                    }
                    else if (c.GetType() == typeof(CheckBox))
                    {
                        foreach (DataTable Tabella in rt.Tabelle)
                        {
                            if (this.GetNomeTabellaB(c) == Tabella.TableName)
                            {
                                foreach (DataColumn Colonna in Tabella.Columns)
                                {
                                    if (this.GetNomeCampoB(c) == Colonna.ColumnName)
                                    {
                                        this.AssegnaCampo(c, Tabella.Rows[0][Colonna.ColumnName]);
                                    }
                                }
                            }
                        }
                    }
                    else if (c.GetType() == typeof(BCDateTimePicker))
                    {
                        foreach (DataTable Tabella in rt.Tabelle)
                        {
                            if (this.GetNomeTabellaData(c) == Tabella.TableName)
                            {
                                foreach (DataColumn Colonna in Tabella.Columns)
                                {
                                    if (this.GetNomeCampoData(c) == Colonna.ColumnName)
                                    {
                                        this.AssegnaCampo(c, Tabella.Rows[0][Colonna.ColumnName]);

                                    }
                                }
                            }
                        }
                    }
                    else if  (c.GetType() == typeof(NumericUpDown))
                    {
                        foreach (DataTable Tabella in rt.Tabelle)
                        {
                            if (this.GetNomeTabellaCampoN(c) == Tabella.TableName)
                            {
                                foreach (DataColumn Colonna in Tabella.Columns)
                                {
                                    if (this.GetNomeCampoN(c) == Colonna.ColumnName)
                                    {
                                        this.AssegnaCampo(c, Tabella.Rows[0][Colonna.ColumnName]);
                                    }
                                }
                            }
                        }
                    }
                    else if (c.GetType() == typeof(ComboBox))
                    {
                        foreach (DataTable Tabella in rt.Tabelle)
                        {
                            if (this.GetNomeListaD(c) == Tabella.TableName)
                            {
                                AssegnaLista((ComboBox)c, Tabella);
                                break;
                            }
                        }
                        foreach (DataTable Tabella in rt.Tabelle)
                        {
                            if (this.GetNomeTabellaCampoD(c) == Tabella.TableName)
                            {
                                foreach (DataColumn Colonna in Tabella.Columns)
                                {
                                    if (this.GetNomeCampoD(c) == Colonna.ColumnName)
                                    {
                                        ((ComboBox)c).SelectedValue = Tabella.Rows[0][Colonna.ColumnName];
                                        frm.Focus();
                                    }
                                }
                            }

                        }

                    }

                }

            AssegnaStatoCampi(rt);
            AssegnaStatoAzioni(rt);
            
        }
        private void AssegnaLista(ComboBox c, DataTable Lista)
        {
            c.DataSource = Lista;
        }
        public int getnAttivato()
        {
            return nAttivato;
        }
        public void setnAttivato(int valore)
        {
            nAttivato = valore;
        }
        private void AssegnaStatoAzioni(_FunzioniBase.Ritorno rt)
        {
            Boolean blocca;
            foreach (object c in Oggetti)
            {

                if (c.GetType() == typeof(Button))
                {
                    foreach (DataTable Tabella in rt.Tabelle)
                    {
                        if (Tabella.TableName == "BloccaAzione")
                        {
                            if (Tabella.Select("Azione = '" + GetNomeAzione(c) + "'").Length > 0)
                            {
                                blocca = Convert.ToBoolean(Tabella.Select("Azione = '" + GetNomeAzione(c) + "'")[0]["Blocca"]);
                                ((Button)c).Enabled = !blocca;
                               
                            }
                        }
                    }

                }
                if (c.GetType() == typeof(ToolStripMenuItem))
                {
                    foreach (DataTable Tabella in rt.Tabelle)
                    {
                        if (Tabella.TableName == "BloccaAzione")
                        {
                            if (Tabella.Select("Azione = '" + GetNomeAzioneMenu(c)+"'").Length > 0)
                            {
                                blocca = Convert.ToBoolean(Tabella.Select("Azione = '" + GetNomeAzioneMenu(c) + "'")[0]["Blocca"]);
                                ((ToolStripMenuItem)c).Enabled = !blocca;

                            }
                        }
                    }

                }
            }
        }
        private void AssegnaStatoCampi(_FunzioniBase.Ritorno rt)
        {
            Boolean blocca;
            foreach (Object c in Oggetti)
                {
                    

                    if (c.GetType() == typeof(TextBox))
                    {
                        foreach (DataTable Tabella in rt.Tabelle)
                        {
                            if (Tabella.TableName == "BloccaCampo")
                            {
                                if (Tabella.Select("Tabella = '" + GetNomeTabellaCampoS(c) + "' and (Campo='" + GetNomeCampoS(c) + "' or Campo='*')").Length > 0)
                                {
                                    blocca = Convert.ToBoolean(Tabella.Select("Tabella = '" + GetNomeTabellaCampoS(c) + "' and (Campo='" + GetNomeCampoS(c) + "' or Campo='*')")[0]["Blocca"]);

                                    ((TextBox)c).ReadOnly = blocca;
                                    ((TextBox)c).BackColor = blocca ? NonModificabile : Modificabile;
                                    ((TextBox)c).Font = blocca ? FontNONMod : FontMod;
                                }
                                else
                                {
                                    ((TextBox)c).ReadOnly = false;
                                    ((TextBox)c).BackColor = Modificabile;
                                    ((TextBox)c).Font = FontMod;
                                }
                            }
                        }
 
                    }
                    if (c.GetType() == typeof(CheckBox))
                    {
                        foreach (DataTable Tabella in rt.Tabelle)
                        {
                            if (Tabella.TableName == "BloccaCampo")
                            {
                                if (Tabella.Select("Tabella = '" + GetNomeTabellaB(c) + "' and (Campo='" + GetNomeCampoB(c) + "' or Campo='*')").Length > 0)
                                {
                                    blocca = Convert.ToBoolean(Tabella.Select("Tabella = '" + GetNomeTabellaB(c) + "' and (Campo='" + GetNomeCampoB(c) + "' or Campo='*')")[0]["Blocca"]);

                                    ((CheckBox)c).Enabled = !blocca;
                                    ((CheckBox)c).BackColor = blocca ? NonModificabile : Modificabile;
                                    
                                }
                                else
                                {
                                    ((CheckBox)c).Enabled = true;
                                    ((CheckBox)c).BackColor = Modificabile;
                                    
                                }
                            }
                        }

                    }
                    if (c.GetType() == typeof(ComboBox))
                    {
                        foreach (DataTable Tabella in rt.Tabelle)
                        {
                            if (Tabella.TableName == "BloccaCampo")
                            {
                                if (Tabella.Select("Tabella = '" + GetNomeTabellaCampoD(c) + "' and (Campo='" + GetNomeCampoD(c) + "' or Campo='*')").Length > 0)
                                {
                                    blocca = Convert.ToBoolean(Tabella.Select("Tabella = '" + GetNomeTabellaCampoD(c) + "' and (Campo='" + GetNomeCampoD(c) + "' or Campo='*')")[0]["Blocca"]);

                                    ((ComboBox)c).Enabled = !blocca;
                                    ((ComboBox)c).BackColor = blocca ? NonModificabile : Modificabile;
                                    ((ComboBox)c).Font = blocca ? FontNONMod : FontMod;
                                }
                                else
                                {
                                    ((ComboBox)c).Enabled = true;
                                    ((ComboBox)c).BackColor = Modificabile;
                                    ((ComboBox)c).Font =  FontMod;
                                }
                            }
                        }

                    }
                    if (c.GetType() == typeof(NumericUpDown))
                    {
                        foreach (DataTable Tabella in rt.Tabelle)
                        {
                            if (Tabella.TableName == "BloccaCampo")
                            {
                                if (Tabella.Select("Tabella = '" + GetNomeTabellaCampoN(c) + "' and (Campo='" + GetNomeCampoN(c) + "' or Campo='*')").Length > 0)
                                {
                                    blocca = Convert.ToBoolean(Tabella.Select("Tabella = '" + GetNomeTabellaCampoN(c) + "' and (Campo='" + GetNomeCampoN(c) + "' or Campo='*')")[0]["Blocca"]);
                                    ((NumericUpDown)c).ReadOnly = blocca;
                                    ((NumericUpDown)c).BackColor = blocca ? NonModificabile : Modificabile;
                                    ((NumericUpDown)c).Font = blocca ? FontNONMod : FontMod;
                                }
                                else
                                {
                                    ((NumericUpDown)c).ReadOnly = false;
                                    ((NumericUpDown)c).BackColor = Modificabile;
                                    ((NumericUpDown)c).Font =  FontMod;
                                }
                            }
                        }

                    }
                    if (c.GetType() == typeof(BCDateTimePicker))
                    {
                        foreach (DataTable Tabella in rt.Tabelle)
                        {
                            if (Tabella.TableName == "BloccaCampo")
                            {
                                if (Tabella.Select("Tabella = '" + GetNomeTabellaData(c) + "' and (Campo='" + GetNomeCampoData(c) + "' or Campo='*')").Length > 0)
                                {
                                    blocca = Convert.ToBoolean(Tabella.Select("Tabella = '" + GetNomeTabellaData(c) + "' and (Campo='" + GetNomeCampoData(c) + "' or Campo='*')")[0]["Blocca"]);
                                    ((BCDateTimePicker)c).Enabled = !blocca;
                                    ((BCDateTimePicker)c).BackColor = blocca ? NonModificabile : Modificabile;
                                    ((BCDateTimePicker)c).Font = blocca ? FontNONMod : FontMod;
                                }
                                else
                                {
                                    ((BCDateTimePicker)c).Enabled = true;
                                    ((BCDateTimePicker)c).BackColor = Modificabile;
                                    ((BCDateTimePicker)c).Font = FontMod;
                                }
                            }
                        }

                    }
                    if (c.GetType() == typeof(DataGridView))
                    {
                        foreach (DataTable Tabella in rt.Tabelle)
                        {
                            if (Tabella.TableName == "BloccaCampo")
                            {
                                if (Tabella.Select("Tabella = '" + GetNomeTabella(c) + "' and (Campo='*')").Length > 0)
                                {
                                    blocca = Convert.ToBoolean(Tabella.Select("Tabella = '" + GetNomeTabella(c) + "' and (Campo='*')")[0]["Blocca"]);
                                    ((DataGridView)c).ReadOnly = blocca;
                                    ((DataGridView)c).DefaultCellStyle.BackColor = blocca ? NonModificabile : Modificabile;
                                    ((DataGridView)c).DefaultCellStyle.Font = blocca ? FontNONMod : FontMod;
                                }
                                else
                                    if (Tabella.Select("Tabella = '" + GetNomeTabella(c) + "'").Length > 0)
                                    {
                                        foreach (DataGridViewColumn dc in ((DataGridView)c).Columns)
                                        {
                                            if (Tabella.Select("Tabella = '" + GetNomeTabella(c) + "' and (Campo='" + dc.HeaderText + "')").Length > 0)
                                            {
                                                blocca = Convert.ToBoolean(Tabella.Select("Tabella = '" + GetNomeTabella(c) + "' and (Campo='" + dc.HeaderText + "')")[0]["Blocca"]);
                                                dc.ReadOnly = blocca;
                                                dc.DefaultCellStyle.BackColor = blocca ? NonModificabile : Modificabile;
                                                dc.DefaultCellStyle.Font = blocca ? FontNONMod : FontMod;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        ((DataGridView)c).ReadOnly = false;
                                        ((DataGridView)c).DefaultCellStyle.BackColor =  Modificabile;
                                        ((DataGridView)c).DefaultCellStyle.Font =  FontMod;
                                    }
                            }
                        }

                    }
                }
        }
        private List<_FunzioniBase.Tabella> RecuperaTabelle( ref  List<DataTable> TabOriginali,_FunzioniBase.Ritorno rt)
        {
            DataTable t;
            DataTable Selezioni = new DataTable("Selezioni");
            Selezioni.Columns.Add("Id", typeof(Int32));
            Selezioni.Columns.Add("Tabella", typeof(String));
            Selezioni.Columns.Add("_Sel", typeof(int));
            //Selezioni.PrimaryKey[0] = Selezioni.Columns["Id"];
           
            int Iselezioni =0;

            //copio prima di tutto le tabelle originali
            foreach (DataTable dt in rt.Tabelle)
            {
                if (!(dt.TableName == "BloccaCampo") && !(dt.TableName == "BloccaAzione"))
                {
                    t = new DataTable(dt.TableName);
                    t = dt.Copy();
                    //foreach (DataColumn c in t.Columns)
                    //{
                    //    c.ReadOnly = false;
                    //    if (c.DataType == typeof(String))
                    //    { c.MaxLength = 200; }
                    //}
                    TabOriginali.Add(t);
                }

            }

            //ciclo gli oggetti che hanno un valore per recuperare i valori modificati
            foreach (Object c in Oggetti)
            { 
                switch (c.GetType().ToString())
                {
                    case "System.Windows.Forms.TextBox":
                        foreach (DataTable dt in TabOriginali)
                        {
                            if (dt.TableName == GetNomeTabellaCampoS(c))
                            {
                                foreach (DataColumn dc in dt.Columns)
                                {
                                    if (dc.ColumnName == GetNomeCampoS(c))
                                    {
                                        dt.Rows[0][dc.ColumnName] = ((TextBox)c).Text;
                                    }
                                }
                                break;
                            }
                        }
                        break;
                    case "System.Windows.Forms.CheckBox":
                        foreach (DataTable dt in TabOriginali)
                        {
                            if (dt.TableName == GetNomeTabellaB(c))
                            {
                                foreach (DataColumn dc in dt.Columns)
                                {
                                    if (dc.ColumnName == GetNomeCampoB(c))
                                    {
                                        dt.Rows[0][dc.ColumnName] = ((CheckBox)c).Checked;
                                    }
                                }
                                break;
                            }
                        }
                        break;
                    case "DateTimePickerWithBackColor.BCDateTimePicker":
                        foreach (DataTable dt in TabOriginali)
                        {
                            if (dt.TableName == GetNomeTabellaData(c))
                            {
                                foreach (DataColumn dc in dt.Columns)
                                {
                                    if (dc.ColumnName == GetNomeCampoData(c))
                                    {
                                        dt.Rows[0][dc.ColumnName] = ((BCDateTimePicker)c).Value;
                                    }
                                }
                                break;
                            }
                        }
                        break;
                    case "System.Windows.Forms.NumericUpDown":
                        foreach (DataTable dt in TabOriginali)
                        {
                            if (dt.TableName == GetNomeTabellaCampoN(c))
                            {
                                foreach (DataColumn dc in dt.Columns)
                                {
                                    if (dc.ColumnName == GetNomeCampoN(c))
                                    {
                                        dt.Rows[0][dc.ColumnName] = ((NumericUpDown)c).Value;
                                    }
                                }
                                break;
                            }
                        }
                        break;
                    case "System.Windows.Forms.ComboBox":
                        foreach (DataTable dt in TabOriginali)
                        {
                            if (dt.TableName == GetNomeTabellaCampoD(c))
                            {
                                foreach (DataColumn dc in dt.Columns)
                                {
                                    if (dc.ColumnName == GetNomeCampoD(c))
                                    {
                                        dt.Rows[0][dc.ColumnName] = ((ComboBox)c).SelectedValue == null ? Convert.DBNull : ((ComboBox)c).SelectedValue;
                                    }
                                }
                                break;
                            }
                        }
                        break;
                    case "System.Windows.Forms.DataGridView":
                        foreach (DataTable dt in TabOriginali)
                        {
                            if (dt.TableName == GetNomeTabella(c))
                            {
                                dt.Clear();
                                foreach (DataRow dr in ((DataTable)(((BindingSource)(((DataGridView)c).DataSource)).DataSource)).Rows)
                                {
                                    DataRow dr2 = dt.NewRow();
                                    for (int i = 0; i < dt.Columns.Count; i++)
                                    {
                                        dr2[i] = dr[i];
                                    }
                                    dt.Rows.Add(dr2);
                                }
                                
                                //recupero selezioni 
                                foreach (DataGridViewRow dgwr in ((DataGridView)c).Rows)
                                {
                                    if (dgwr.Selected)
                                    { 
                                        DataRow dr = Selezioni.NewRow();
                                        dr["Id"] = ++Iselezioni;
                                        dr["Tabella"] = dt.TableName;
                                        dr["_Sel"] = dgwr.Cells["Id"].Value;
                                        if (!Convert.IsDBNull(dr["_Sel"]))
                                            Selezioni.Rows.Add(dr);
                                    }
                                }
                                break;
                            }
                        }
                        break;

                }

            }
            if (Selezioni.Rows.Count > 0)
                TabOriginali.Add(Selezioni);
            List<_FunzioniBase.Tabella> Par = new List<_FunzioniBase.Tabella>();
            foreach (DataTable dt in TabOriginali)
            {
                _FunzioniBase.Tabella tab ;
                tab = _FunzioniBase.Base.ToTabella(dt);
                Par.Add(tab);
            }
            return Par;
        }
        private void SelezioneCambiata(object sender, EventArgs e)
        {
           
        }
        private void EvtGestisciAzione(object sender, EventArgs e) {
            Form FormCorrente;
            FormCorrente = null;
            foreach (object o in Oggetti)
            {
                Type t = o.GetType();
                if (t.BaseType.ToString() == "System.Windows.Forms.Form")
                {
                    FormCorrente = (Form)o;
                }
            }
           /*if (FormCorrente.IsMdiChild) {
                FormCorrente.ValidateChildren(); 
            }*/
            GestisciAzione(sender);

        }
        private void GestisciAzione(object sender)
        {
            List<DataTable> TabOriginali = new List<DataTable>();
            String nomeAzione = "";
            List<_FunzioniBase.Tabella> Par = new List<_FunzioniBase.Tabella>();

//            if (sender.GetType().ToString() == "System.Windows.Forms.Button")
                nomeAzione = GetNomeAzione(sender);
  //          else
    //            nomeAzione = GetNomeAzioneCambioValore(sender);
            if (!String.IsNullOrEmpty(nomeAzione))
            {
                if (!(nomeAzione == "Chiudi"))
                    Par = RecuperaTabelle(ref TabOriginali, this.rt);
                Form FormCorrente;
                FormCorrente = null;
                foreach (object o in Oggetti)
                {
                    Type t = o.GetType();
                    if (t.BaseType.ToString() == "System.Windows.Forms.Form")
                    {
                        FormCorrente = (Form)o;
                    }
                }
                //if (FormCorrente.IsMdiChild) { FormCorrente.ValidateChildren(); }


                AggiungiArg(ref Par, "VistaCorrente", FormCorrente.Name);
                AggiungiArg(ref Par, "Azione", nomeAzione);
                EseguiAzione(Par);
            }
        }
        private void EseguiAzione(List<_FunzioniBase.Tabella> Par)
        { 
            //ogni volta che schiaccio io voglio:
            /*
             * 1 - Recuperare i dati nella form
             * 2 - Chiamare una stored procedure composta come pcm_sp_"NomeAzioneBottone"
             * 3 - Recuperare i dati
             * 4 - Aggiornare - se richiesto - la form con i dati e lo stato dei campi,
             * 5 - oppure chiudere la form, gestire i messaggi
             */
            Form FormCorrente;
            FormCorrente = null;
            foreach (object o in Oggetti)
            {
                Type t = o.GetType();
                if (t.BaseType.ToString() == "System.Windows.Forms.Form")
                {
                    FormCorrente = (Form)o;
                }
            }
            
            _FunzioniBase.Base Runner = new _FunzioniBase.Base();
            
            

            _FunzioniBase.Ritorno rit= Runner.RunProcedure(Par);

            String Messaggio = "";
            if (rit.Errori.Count > 0)
            {
                for (int i = 0; i < rit.Errori.Count; i++)
                {
                    Messaggio += rit.Errori[i] + '\n';

                }
                MessageBox.Show(Messaggio, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (rit.Avvisi.Count > 0)
                {
                    for (int i = 0; i < rit.Avvisi.Count; i++)
                    {
                        Messaggio += rit.Avvisi[i] + '\n';

                    }
                    Messaggio = Messaggio + "Vuoi Continuare?";
                    if (MessageBox.Show(Messaggio, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        AggiungiArg(ref Par, "IgnoraAvvisi", "1");
                        EseguiAzione(Par);
                        
                    }
                    return;
                }
                else
                {
                    if (rit.Log.Count > 0)
                    {
                        for (int i = 0; i < rit.Log.Count; i++)
                        {
                            Messaggio += rit.Log[i] + '\n';

                        }

                        MessageBox.Show(Messaggio, "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                }
            }

            if (rit.Errori.Count == 0)
            {
                if (rit.GetRet("Aggiorna") == "1")
                    AssegnaTabelle(rit, FormCorrente);

                if ((rit.GetRet("NewForm").Length > 0) && (FormCorrente.IsMdiContainer))
                {
                    nAttivato = 0;
                    string asdf = rit.GetRet("NewForm");
                    Type CAType = Type.GetType("Sample." + asdf);
                    Form nextForm2 = (Form)Activator.CreateInstance(CAType,rit);
                    
                    nextForm2.MdiParent = FormCorrente;
                    if (asdf == "AnteprimaStampa")
                    {
                        nextForm2.Load += (sender, eventArgs) =>
                                 {
                                     CaricaReport(rit,nextForm2);
                                 };
                        
                    }
                    nextForm2.Show();

                
                }
                if ((rit.GetRet("NextForm").Length > 0))
                {
                    string asdf = rit.GetRet("NextForm");
                    Type CAType = Type.GetType("Sample." + asdf);
                    Form nextForm2 = (Form)Activator.CreateInstance(CAType, rit);
                    
                    TabPage tp = (TabPage)FormCorrente.Tag;
                    nextForm2.Tag = tp;
                    nextForm2.MdiParent = FormCorrente.MdiParent;
                    if (asdf == "AnteprimaStampa")
                    {
                        nextForm2.Load += (sender, eventArgs) =>
                                 {
                                     CaricaReport(rit,nextForm2);
                                 };
                    }
                    nextForm2.Show();    
                }

                if ((rit.GetRet("CloseForm")=="1"))
                {
                    FormCorrente.Close();

                }
            }
            
        }
        private _FunzioniBase.Tabella CreaArg(String nome, String valore)
        {
            _FunzioniBase.Tabella Arg = new _FunzioniBase.Tabella();
            Arg.Name = "brn_Arg";
            Arg.Struct = "Nome nvarchar(200) Primary key" + '\t' + "Valore nvarchar(max)";
            Arg.Data = nome + '\t' + valore;
            return Arg;
        }
        private void AggiungiArg(ref List<_FunzioniBase.Tabella> Par, String nome, String valore)
        {
            foreach (_FunzioniBase.Tabella t in Par)
            {
                if (t.Name == "brn_Arg") {
                    t.Data += '\n' + nome + '\t' + valore;
                    return;
                }
            }
            
            _FunzioniBase.Tabella Arg = new _FunzioniBase.Tabella();
            Arg.Name = "brn_Arg";
            Arg.Struct = "Nome nvarchar(200) Primary key" + '\t' + "Valore nvarchar(max)";
            Arg.Data = nome + '\t' + valore;
            Par.Add( Arg);
        }
        private void CaricaReport(_FunzioniBase.Ritorno rt,Form f)
        {
            
            DataSet ds = new DataSet();
            foreach (DataTable dt in rt.Tabelle)
            {
                if (dt.TableName == "DatiStampa")
                {
                    ds.DataSetName = dt.TableName;
                    ds.Tables.Add(dt);
                    ds.WriteXml( "xmlReport.xml",XmlWriteMode.WriteSchema);
                }

            }
            CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            try
            {

                rpt.Load(rt.GetRet("Report"));
                rpt.SetDataSource(ds);
                List<CrystalReportViewer> lista = new List<CrystalReportViewer>();
                CercaRPTViewer(f, ref lista);
                foreach (CrystalReportViewer r in lista)
                {
                    r.ReportSource = rpt;
                    
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
 
        }

        private void CercaRPTViewer(Control c, ref List<CrystalReportViewer> lista)
        {

            
            foreach (Control child in c.Controls)
            {

                if (child.GetType().ToString() == "CrystalDecisions.Windows.Forms.CrystalReportViewer")
                    {
                        lista.Add((CrystalReportViewer)child);
                    }
                    if (child.HasChildren)
                    {
                        CercaRPTViewer(child, ref lista);
                    }
                
                    
                   
            }

        }
    }

