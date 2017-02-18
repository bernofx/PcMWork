using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;



namespace _FunzioniBase
{
    public class Ritorno
    {
        public List<String> Errori=new List<string>();
        public List<String> Avvisi = new List<string>();
        public List<String> Log = new List<string>();
        public List<DataTable> Tabelle = new List<DataTable>();
        public DataTable Ret = new DataTable();

        public String GetRet(String nome)
        {
            if (Ret.Columns.Contains("Nome"))
                if (Ret.Select("Nome = '" + nome.ToString()+"'").Length > 0)
                {
                    return Ret.Select("Nome = '" + nome.ToString() + "'")[0]["Valore"].ToString();
                }
                else
                    return "";
            else
                return "";
        }
        public void OrganizzaMessaggi(DataTable Messaggi)
        {
            
            foreach (DataRow dr in Messaggi.Rows)
            {
                if (dr["Tipo"].ToString() == "E") { Errori.Add(dr["Messaggio"].ToString()); }
                if (dr["Tipo"].ToString() == "A") { Avvisi.Add(dr["Messaggio"].ToString()); }
                if (dr["Tipo"].ToString() == "L") { Log.Add(dr["Messaggio"].ToString()); }
            }
        }
        
    }


    public class Tabella
    {
    public String Name = "";
    public String Struct= "";
    public String Data = "";


    public DataTable GetDataTable(){
        DataColumn  column; 

        DataTable table = new DataTable();
        String[] Cols;
        int index = 0;
        String[] elementi;
        Cols = Struct.Split(new char[] {'\t'},StringSplitOptions.None);
        
        for (int i = 0; i<=Cols.Length - 1;i++){
            
            elementi = Cols[i].Split(new char[] {' '});
            if (!(elementi[0] == "")) {
                column = new DataColumn();
            
                if ( elementi[1].StartsWith("INT")) {
                    column.DataType = System.Type.GetType("System.Int32");
                }
                if ( elementi[1].StartsWith("NVARCHAR") || elementi[1].StartsWith("VARCHAR")) {
                    column.DataType = System.Type.GetType("System.String");
                    String lung;
                    lung = elementi[1].Substring(elementi[1].IndexOf("(") + 1, elementi[1].IndexOf(")") - (elementi[1].IndexOf("(") + 1));
                    if ( !(lung == "MAX")) { column.MaxLength = Convert.ToInt32(lung);}
                }
                if ( elementi[1].StartsWith("BIT") ){
                    column.DataType = System.Type.GetType("System.Boolean");
                }
                if ( elementi[1].StartsWith("DECIMAL")) {
                    column.DataType = System.Type.GetType("System.Decimal");
                }
                if ( elementi[1].StartsWith("DATE") ){
                    column.DataType = System.Type.GetType("System.DateTime");
                }

                column.ColumnName = elementi[0];

                index = Array.IndexOf(elementi, "NOT");
                if (( index > -1) && (index < elementi.Length - 1)) {
                    column.AllowDBNull = (!(elementi[index + 1] == "NULL"));
                }
            else{
                    column.AllowDBNull = true;
                }

                index = Array.IndexOf(elementi, "PRIMARY");
                if (( index > -1) && (index < elementi.Length - 1)) {
                    column.Unique = (elementi[index + 1] == "KEY");
                }
                else
                {
                    column.Unique = false;
                }

                index = Array.IndexOf(elementi, "DEFAULT");
                if ( (index > -1) && (index < elementi.Length - 1)) {
                    column.DefaultValue = elementi[index + 1];
                }


                table.Columns.Add(column);
            }
        }

        String[] valori;
        foreach( String StringaRiga in Data.Split(new char[] {'\n'})){
            if (!(StringaRiga == "")) {
                valori = StringaRiga.Split(new char[] {'\t'});
                DataRow r;
                r = table.NewRow();
                for (int j = 0 ; j <= valori.Length - 1;j++){
                    if (( object.Equals(table.Columns[j].DataType, System.Type.GetType("System.Boolean")))) {
                        r[j] = valori[j] == "1";
                    }else
                        if (!( valori[j] == "") || ((valori[j] == "") && object.Equals(table.Columns[j].DataType, System.Type.GetType("System.String")))) {
                            if (!(object.Equals(table.Columns[j].DataType, System.Type.GetType("System.DateTime"))))
                                r[j] = Convert.ChangeType(valori[j], table.Columns[j].DataType);
                            else
                            {
                                DateTime dateS = new DateTime();
                                dateS = DateTime.ParseExact(valori[j],"yyyyMMdd",System.Globalization.CultureInfo.InvariantCulture);
                                r[j] = dateS;
                            }
                        }
                        else
                        {
                            r[j] = Convert.DBNull;
                        }
                    
                 }
                table.Rows.Add(r);
            }
         }
        table.TableName = Name;
        return table;
    }

    }
    public class Base
    {
        private  SqlConnection cnn;
        private  SqlTransaction Tran;

        public  Base()
        { //costruttore
          
            try
            {
                cnn = new SqlConnection(_FunzioniBase.Properties.Resources.ConnectionString);
                //SqlConnection cnn = new SqlConnection(_FunzioniBase.Properties.Resources.ConnectionString);
                cnn.Open();
            }
            catch
            {
               
            }
            finally
            {
                //do something here
            }

        }
        public  void BeginTransaction()
        {
           
            try 
            {
                if (!(cnn.State == ConnectionState.Open))
                {    cnn = new SqlConnection(_FunzioniBase.Properties.Resources.ConnectionString);
                    //SqlConnection cnn = new SqlConnection(_FunzioniBase.Properties.Resources.ConnectionString);
                    cnn.Open();
                }
                    Tran =  cnn.BeginTransaction();
               
            }
            catch 
            {
                Tran = null;
            }
            finally
            {
                //do something here
            }
            
        }
        public void CommitTransaction()
        {

            try
            {
                if ((cnn.State == ConnectionState.Open))
                {
                    Tran.Commit();
                }
                

            }
            catch
            {
                Tran = null;
            }
            finally
            {
                //do something here
            }

        }
        public void RollbackTransaction()
        {

            try
            {
                if ((cnn.State == ConnectionState.Open))
                {
                    Tran.Rollback();
                }


            }
            catch
            {
                Tran = null;
            }
            finally
            {
                //do something here
            }

        }
        public String GetArg(List<Tabella> Par, String nome)
        {
            DataTable brn_Arg = new DataTable();
            bool tabTrovata = false;
            foreach (Tabella p in Par)
            {
                if (p.Name == "brn_Arg")
                {
                    brn_Arg = p.GetDataTable();
                    tabTrovata = true;
                    break;
                }
            }
            if (tabTrovata)
                if (brn_Arg.Select("Nome = '" + nome.ToString()+"'").Length > 0)
                {
                    return brn_Arg.Select("Nome = '" + nome.ToString()+"'")[0]["Valore"].ToString();
                }
                else
                    return "";
            else
                return "";
        }
        public Ritorno RunProcedure(List<Tabella> Par)
        {
            Ritorno rit = new Ritorno();
            BeginTransaction();
            try
            {
                SqlCommand creaTabMex = new SqlCommand(_FunzioniBase.Properties.Resources.SqlCreaTabMex, cnn, Tran);
                SqlCommand creaTabTemp = new SqlCommand(_FunzioniBase.Properties.Resources.SqlCreaTabTemp, cnn, Tran);
                creaTabMex.ExecuteNonQuery();
                creaTabTemp.ExecuteNonQuery();
                SqlCommand insertInput = new SqlCommand("INSERT INTO #brn_input (Name,Data) Values (@Name,@Data)", cnn, Tran);
                foreach (Tabella t in Par)
                {
                    insertInput.Parameters.Clear();
                    insertInput.Parameters.AddWithValue("@Name", t.Name);
                    insertInput.Parameters.AddWithValue("@Data", t.Struct);
                    insertInput.ExecuteNonQuery();
                    foreach (String s in t.Data.Split(new char[] { '\n' }))
                    {
                        insertInput.Parameters["@Data"].Value = s;
                        insertInput.ExecuteNonQuery();
                    }
                }
                SqlCommand EseguiAzione = new SqlCommand("EXEC brn_sp_Azione", cnn, Tran);
                EseguiAzione.ExecuteNonQuery();

                SqlCommand LeggiTabTemp = new SqlCommand(_FunzioniBase.Properties.Resources.SqlLeggiTabTemp, cnn, Tran);
                SqlDataReader reader = LeggiTabTemp.ExecuteReader();
                DataTable ris = new DataTable();
                ris.Load(reader);
                String NomeTabella = "";
                _FunzioniBase.Tabella Tab = new Tabella();
                foreach (DataRow dr in ris.Rows)
                {
                    if (!(dr["Name"].ToString() == NomeTabella)) //se è una nuova tabella
                    {
                        if (Tab.Data.Length > 0)
                        {
                            Tab.Data.Substring(0, Tab.Data.Length - 1);
                        }
                        if (!(NomeTabella==""))
                            AggiungiTabella(rit, Tab);
                        
                        Tab = new Tabella();
                        Tab.Name = dr["Name"].ToString();
                        Tab.Struct = dr["Data"].ToString();
                        NomeTabella = dr["Name"].ToString();
                    }
                    else
                    {
                        Tab.Data += dr["Data"].ToString() + '\n';
                    }
                }
                if (Tab.Data.Length > 0)
                {
                    Tab.Data.Substring(0, Tab.Data.Length - 1);
                }

                    AggiungiTabella(rit, Tab);
                
                SqlCommand DropTabTemp = new SqlCommand(_FunzioniBase.Properties.Resources.SqlDropTabTemp, cnn, Tran);

            }
            catch (Exception ex)
            {
                rit = new Ritorno();
                
                rit.Errori.Add(ex.Message);
            }
            finally
            {
                if (   (rit.Errori.Count == 0)     )
                {
                    if ((GetArg(Par, "IgnoraAvvisi") == "1"))
                        rit.Avvisi.Clear();

                    if ((rit.Avvisi.Count == 0))
                        CommitTransaction();
                    else
                        RollbackTransaction();
                }
                else
                {
                    RollbackTransaction();
                }
                
            }
         return rit;
        }

        private static void AggiungiTabella(Ritorno rit, _FunzioniBase.Tabella Tab)
        {
            if ((Tab.Name == "brn_Msg")) 
            {
                rit.OrganizzaMessaggi(Tab.GetDataTable());
                return;
            }
            
            if ((Tab.Name == "brn_Ret"))
            {
                rit.Ret=Tab.GetDataTable();
                return;
            }
            rit.Tabelle.Add(Tab.GetDataTable());
        }
        public void Query(Ritorno rt, String TableName, String Query, params object[] Parametri)

        {
            
            DataTable Ris = new DataTable();
            int i = Parametri.Length;
            if (i % 2 == 0)
            {
                 SqlCommand creaTabMex = new SqlCommand(_FunzioniBase.Properties.Resources.SqlCreaTabMex,cnn,Tran);
                 
                creaTabMex.ExecuteNonQuery();
                
                SqlDataReader reader;
                SqlCommand comando = new SqlCommand(Query, cnn, Tran);
                for(int k=0;k<i;k=k+2)
                {
                    comando.Parameters.AddWithValue(Parametri[k].ToString(), Parametri[k + 1]);
                }
                reader = comando.ExecuteReader();
                Ris.Load(reader);

                SqlCommand LeggiTabMex = new SqlCommand(_FunzioniBase.Properties.Resources.SqlLeggiMex, cnn, Tran);
                SqlDataReader MsgReader;
                MsgReader = LeggiTabMex.ExecuteReader();

                
                DataTable Mex = new DataTable();
                Mex.Load(MsgReader);
                rt.OrganizzaMessaggi(Mex);

                SqlCommand dropTabMex = new SqlCommand(_FunzioniBase.Properties.Resources.SqlDropMex, cnn, Tran);

                dropTabMex.ExecuteNonQuery();
            }
            Ris.TableName = TableName;
            rt.Tabelle.Add(Ris);
            
        }
        public static Tabella ToTabella(DataTable tab)
        {
            Tabella Ris = new Tabella();

            foreach (DataColumn dc in tab.Columns)
            { 
                Ris.Struct+=dc.ColumnName+ " ";
                switch (dc.DataType.ToString())
                {
                        
                    case "System.Int32":
                        Ris.Struct += "INT ";
                        break;
                    case "System.String":
                        Ris.Struct += "NVARCHAR ";
                        if (dc.MaxLength>-1) {Ris.Struct+="("+dc.MaxLength.ToString()+") ";}
                        else {Ris.Struct+="(MAX) ";}
                        break;
                    case "System.Boolean":
                        Ris.Struct += "BIT ";
                        break;
                    case "System.DateTime":
                        Ris.Struct += "DATETIME ";
                        break;
                    case "System.Decimal":
                        Ris.Struct += "DECIMAL ";
                        break;    
                }
                if (dc.AutoIncrement)
                {
                    Ris.Struct += "IDENTITY ";
                }
                if (dc.Unique)
                { Ris.Struct += "PRIMARY KEY "; }
                
                if (dc.AllowDBNull) { Ris.Struct += "NULL "; }
                else { Ris.Struct += "NOT NULL "; }

                if (dc.DefaultValue.ToString().Length > 0)
                { 
                    Ris.Struct += "DEFAULT ";
                    if (dc.DataType.ToString() == "System.String")
                    {
                        Ris.Struct += "'" + dc.DefaultValue.ToString() + "' ";
                    }
                    else
                    {
                        Ris.Struct += dc.DefaultValue.ToString();
                    }
                }
                Ris.Struct += '\t';
            }
            Ris.Struct = Ris.Struct.Substring(0, Ris.Struct.Length - 1);
            foreach (DataRow dr in tab.Rows)
            {
                for (int i = 0; i < tab.Columns.Count; i++)
                {
                    if ((tab.Columns[i].DataType.ToString() == "System.String") || (tab.Columns[i].DataType.ToString() == "System.Int32"))
                    { 
                        Ris.Data += dr[i].ToString()+'\t';
                    }
                    if (tab.Columns[i].DataType.ToString() == "System.Decimal")
                    {
                        Ris.Data += dr[i].ToString().Replace(',','.')+'\t';
                    }
                    if (tab.Columns[i].DataType.ToString() == "System.DateTime")

                    {
                        Ris.Data += Convert.ToDateTime(dr[i]).ToString("yyyyMMdd") + '\t';
                    }
                    if (tab.Columns[i].DataType.ToString() == "System.Boolean")
                    {
                        if (Convert.ToBoolean(dr[i])) Ris.Data += "1";
                        else Ris.Data += "0";
                        Ris.Data += '\t';
                    }
                }
                Ris.Data = Ris.Data.Substring(0, Ris.Data.Length - 1);
                Ris.Data += '\n';
            }
            if (Ris.Data.EndsWith("\n"))
                Ris.Data = Ris.Data.Substring(0, Ris.Data.Length - 1);
            Ris.Name = tab.TableName;
            return Ris;
        }
        
    }
}
