using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class AddCFRecs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //-------be yekbare baraye hameye user ha yekbare CF Recs ro anjam mide -----------------
        //------- baraye har zoje (User, Itam), faghat yek bar Rec ro peida mikone, dafe haye badi checkesh mikone age ghablan Rec dade, dige sabt nemikone -----------

        //List<List<int>> matrix = new List<List<int>>();
        //SqlConnection cn = new SqlConnection("Data Source=PAZAHR-PC;Initial Catalog=MusicRec;Integrated Security=True");
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MusicRecCn"].ToString());
        cn.Open();
        SqlCommand cmdusers = new SqlCommand("Select distinct userid from interests", cn);
        SqlDataAdapter dausers = new SqlDataAdapter(cmdusers);
        DataSet dsusers = new DataSet();
        dausers.Fill(dsusers, "interests");
        int m = dsusers.Tables[0].Rows.Count;
        int[] RowMap = new int[m];
        for (int i = 0; i < m; i++)
        {
            RowMap[i] = Convert.ToInt32(dsusers.Tables[0].Rows[i].ItemArray.GetValue(0));
        }

        SqlCommand cmditems = new SqlCommand("Select distinct musicid from interests", cn);
        SqlDataAdapter daitems = new SqlDataAdapter(cmditems);
        DataSet dsitems = new DataSet();
        daitems.Fill(dsitems, "interests");
        int n = dsitems.Tables[0].Rows.Count;
        int[] ColMap = new int[n];
        for (int j = 0; j < n; j++)
        {
            ColMap[j] = Convert.ToInt32(dsitems.Tables[0].Rows[j].ItemArray.GetValue(0));
        }

        decimal[,] rates = new decimal[m + 1, n + 1];
        SqlCommand cmdinterests = new SqlCommand("Select * from interests", cn);
        SqlDataAdapter dainterests = new SqlDataAdapter(cmdinterests);
        DataSet dsinterests = new DataSet();
        dainterests.Fill(dsinterests, "interests");

        int row = 0;
        int col = 0;
        for (int i = 0; i < dsinterests.Tables[0].Rows.Count; i++)
        {
            int userid = Convert.ToInt32(dsinterests.Tables[0].Rows[i].ItemArray.GetValue(0));
            int musicid = Convert.ToInt32(dsinterests.Tables[0].Rows[i].ItemArray.GetValue(1));
            int irank = Convert.ToInt32(dsinterests.Tables[0].Rows[i].ItemArray.GetValue(2));
            for (int j = 0; j < m; j++)
            {
                if (RowMap[j] == userid)
                {
                    row = j + 1;
                    break;
                }
            }
            for (int j = 0; j < n; j++)
            {
                if (ColMap[j] == musicid)
                {
                    col = j + 1;
                    break;
                }
            }
            rates[row, col] = irank;

        }

        cmdusers.Dispose();
        dausers.Dispose();
        dsusers.Dispose();
        cmditems.Dispose();
        daitems.Dispose();
        dsitems.Dispose();
        cmdinterests.Dispose();
        dainterests.Dispose();
        dsinterests.Dispose();


        //------------------------------ mohasebe W(a,u) ------------------------------------
        bool[,] SharedInterest = new bool[m+1, m+1];
        for (int i = 0; i <= m; i++)
        {
            for (int j = 0; j <= m; j++)
            {
                SharedInterest[i, j] = false;
            }
        }

        decimal[,] w = new decimal[m, m];
        for (int i = 1; i <= m - 1; i++)
        {
            for (int j = i + 1; j <= m; j++)
            {
                //----------- check whether there are any items rated by both users for the formula pearson ----------
                int RatedByBothUsers = 0;
                for (int k = 1; k <= n; k++)
                {
                    if (rates[i, k] != 0 && rates[j, k] != 0)
                    {
                        RatedByBothUsers++;
                    }
                }

                if (RatedByBothUsers != 0)
                {
                    SharedInterest[i, j] = true;
                    SharedInterest[j, i] = true;
                }

                if (RatedByBothUsers != 0)  //------------- if there are items rated by both users, start calculating W(a,u) -----------------
                {
                    decimal ru_ = 0;
                    decimal ra_ = 0;
                    for (int k = 1; k <= n; k++)
                    {
                        ru_ += rates[i, k];
                    }
                    ru_ = ru_ / n;
                    for (int k = 1; k <= n; k++)
                    {
                        ra_ += rates[j, k];
                    }
                    ra_ = ra_ / n;

                    decimal up = 0;                 //----- mohasebe surate kasr w(u,a) ----
                    for (int k = 1; k <= n; k++)
                    {
                        up += (rates[j, k] - ra_) * (rates[i, k] - ru_);
                    }

                    decimal down = 1;                 //----- mohasebe makhraje kasr w(u,a) ----
                    decimal down1 = 1;
                    decimal down2 = 1;
                    for (int k = 1; k <= n; k++)
                    {
                        down1 += (decimal)Math.Pow((double)(rates[j, k] - ra_), 2);
                        down2 += (decimal)Math.Pow((double)(rates[i, k] - ru_), 2);
                    }
                    down = down1 * down2;             //----- mohasebe w(u,a) ----
                    down = (decimal)Math.Sqrt((double)down);
                    w[i - 1, j - 1] = Decimal.Divide(up, down);
                    w[j - 1, i - 1] = w[i - 1, j - 1];

                } //----------- end of if (RatedByBothUsers != 0) --------------------



            }
        }


        for (int i = 1; i <= m; i++)        //------ mohasebe p(a,i) ha baraye matrix Rates ke 2bodie (i,j) -----
        {
            //-------- mohasebe ra_ --------------
            decimal ra_ = 0;
            int nra = 0;
            decimal sumra = 0;
            for (int k = 1; k <= n; k++)
            {
                if (rates[i, k] != 0)
                {
                    sumra += rates[i, k];
                    nra++;
                }
            }
            ra_ = decimal.Divide(sumra, nra);
            //-----------------------------------


            for (int j = 1; j <= n; j++)
            {
                if (rates[i, j] != 0)   //---- agar ghablan ratesh dade shode va mohasebe nashode nist -----
                { continue; }

                decimal up = 0;
                decimal down = 0;
                //--------- peida kardane k nearest neighbors --------
                if (m <= 8) //---- tedade 7 hamsaye ro entekhab kardam. age kolle userha ta 8ta/7hamsaye bashan ke hamashun, age na (bishtar budan) 7tashuno ke bishtarin w dashte bashan entekhab mikonim ---
                {
                    for (int u = 1; u <= m; u++)
                    {
                        //-------- mohasebe ru_ --------------
                        decimal ru_ = 0;
                        int nru = 0;
                        decimal sumru = 0;
                        if (u == i)
                        { continue; }

                        if (!SharedInterest[i, u])
                        { continue; }

                        for (int k = 1; k <= n; k++)
                        {
                            if (rates[u, k] != 0)
                            {
                                sumru += rates[u, k];
                                nru++;
                            }
                        }
                        ru_ = decimal.Divide(sumru, nru);
                        //-----------------------------------
                        down += w[i - 1, u - 1];

                        up += (rates[u, j] - ru_) * w[i - 1, u - 1];
                    }
                }
                else
                {
                    int[] index_knn = new int[7];
                    decimal[,] wp = new decimal[m, m];  //--- wp ye matrix vazne moshabehe w, ke index haye khune ha ro ham dare ----
                    for (int u = 0; u <= m - 1; u++)
                    {
                        wp[0, u] = w[i - 1, u];
                        wp[1, u] = u;
                    }
                    for (int u = 0; u < m - 1; u++) //--- sort kardan nozuli wp baraye peida kardane bishtarin wp ha ---
                    {
                        for (int v = u + 1; v <= m - 1; v++)
                        {
                            if (wp[0, u] < wp[0, v])
                            {
                                decimal temp = wp[0, u];
                                wp[0, u] = wp[0, v];
                                wp[0, v] = temp;
                                temp = wp[1, u];
                                wp[1, u] = wp[1, v];
                                wp[1, v] = temp;
                            }

                        }
                    }
                    for (int u = 0; u <= 6; u++)
                    {
                        index_knn[u] = (int)wp[1, u]; //-- in array, index haye nazdik tarin hamsaye haye be user i ro dare ---
                    }
                    foreach (int u in index_knn)
                    {
                        //-------- mohasebe ru_ --------------
                        decimal ru_ = 0;
                        int nru = 0;
                        decimal sumru = 0;
                        if (u == i)
                        { continue; }

                        if (!SharedInterest[i, u])
                        { continue; }

                        for (int k = 1; k <= n; k++)
                        {
                            if (rates[u, k] != 0)
                            {
                                sumru += rates[u, k];
                                nru++;
                            }
                        }
                        ru_ = decimal.Divide(sumru, nru);
                        //-----------------------------------
                        down += w[i - 1, u];

                        up += (rates[u + 1, j] - ru_) * w[i - 1, u];
                    }
                }

                if (down != 0)
                {
                    rates[i, j] = decimal.Round((ra_ + decimal.Divide(up, down)), 2);

                    //------------- check kon age ghablan ezafe nashode, Rec ro ezafe kon ----------
                    string strsql = "Select * From Recs Where (userid = " + RowMap[i - 1].ToString() + ") and (musicid = " + ColMap[j - 1].ToString() + ") and (rx = 'cf')";
                    SqlDataAdapter dacheck = new SqlDataAdapter(strsql, cn);
                    DataSet dscheck = new DataSet();
                    dacheck.Fill(dscheck, "Recs");

                    if (dscheck.Tables[0].Rows.Count == 0)
                    {
                        //------------- code ezafe kardane record CF Recs --------------------
                        SqlCommand cmdCFRecs = new SqlCommand("Insert Into Recs(userid, musicid, itrate, rx) Values (" + RowMap[i - 1].ToString() + ", " + ColMap[j - 1].ToString() + ", " + Decimal.Divide(rates[i, j], 10).ToString() + ", 'cf')", cn);
                        cmdCFRecs.ExecuteNonQuery();
                        cmdCFRecs.Dispose();
                        //------------- end of code ezafe kardane record CF Recs --------------------
                    }
                    
                }

            }

        }

        //////for (int i = 1; i <= m; i++)
        //////{
        //////    string s = "";
        //////    for (int j = 1; j <= n; j++)
        //////    {
        //////        //s += "   " + Convert.ToString(rates[i, j]);
        //////        s += "   " + rates[i, j].ToString();
        //////        //s += "   " + Convert.ToString(w[i-1, j-1]);
        //////    }
        //////    List.Items.Add(s);
        //////}
        cn.Close();

        //---------------------------- Go to Show Recommendations to the Current User --------------------------
        Response.Redirect("ShowRecs.aspx");

    }
}