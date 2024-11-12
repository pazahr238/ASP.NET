using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Telerik.Web.UI;
using System.Net;
using System.IO;
using System.Configuration;
using System.Text;
using System.Media;
using System.Web.Configuration;
using System.Collections.Specialized;


public partial class Main : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToString(Session["userid"]) == "")
            {
                Response.Redirect("Default.aspx");
            }
            SearchPlayer.TitleBar.ShareButton.Visible = false;
            SearchPlayer.ToolBar.HDButton.Style["display"] = "none";
            SearchPlayer.ToolBar.PlayButtonCenter.Style["display"] = "none";
            SearchPlayer.ToolBar.SubtitlesButton.Style["display"] = "none";
            SearchPlayer.ToolBar.FullScreenButton.Style["display"] = "none";
            if (!Page.IsPostBack)
            {
                txtartist.Focus();
                lbleng.Visible = false;
                lbleng.Font.Name = "B Mitra";
                //Session["musicsource"] = "";
            }

            SearchPlayer.Source = "";
            SearchPlayer.AutoPlay = false;
        }
        catch
        {
            Response.Redirect("default.aspx");
        }
        //------------------------------------------------------------
        if (Convert.ToString(Session["lang"]) == "EN")
        {
            lbltitle.Text = "Welcome to SARSIS";
            lblpreview.Text = "Preview";
            lblsearch.Text = "Search Music";
            lblartistname.Text = "Artist Name";
            lblmusicname.Text = "Music Name";
            lblheard.Text = "Have you heard it?";
            lblrate.Text = "Interest Rate";
            btnlogout.Text = "Log Out";
            btnRecs.Text = "Recommendations";
            Panelusr.Direction = ContentDirection.LeftToRight;
            btnheard.Text = "Yes";
            btnrate.Text = "Submit";
            lblmsgfound.Text = "Sorry! The music was not found. Please try another spell.";
            lblmsgfound.Font.Name = "Times New Roman";
            lblmsgerrorplay.Font.Name = "Times New Roman";
            lblmsgerrorplay.Text = "Fail to connect to Internet or another error!";
            Page.Title = "Main Page of SARSIS";
            lblmustentertrack.Font.Name = "Times New Roman";
            lblmustentertrack.Text = "Please choose a music name";
        }
        else
        {
            lbltitle.Text = "به سیستم پیشنهاد موزیک SARSIS خوش آمدید";
            lblpreview.Text = "پیش نمایش";
            lblsearch.Text = "جستجوی موزیک";
            lblartistname.Text = "نام خواننده";
            lblmusicname.Text = "نام موزیک";
            lblheard.Text = "آیا این موزیک را شنیده اید؟";
            lblrate.Text = "میزان علاقمندی";
            btnlogout.Text = "خروج";
            btnRecs.Text = "پیشنهادات";
            Panelusr.Direction = ContentDirection.RightToLeft;
            btnheard.Text = "بله";
            btnrate.Text = "ثبت نظر";
            lblmsgfound.Text = "پوزش! پیش نمایش موسیقی وجود ندارد لطفا املای دیگری را انتخاب نمایید";
            lblmsgerrorplay.Text = "امکان اتصال به اینترنت وجود ندارد یا خطای دیگری رخ داده است";
            lblmsgfound.Font.Name = "B Mitra";
            lblmsgerrorplay.Font.Name = "B Mitra";
            Page.Title = "صفحه اصلی";
            lblmustentertrack.Font.Name = "B Mitra";
            lblmustentertrack.Text = "لطفا نام موزیک را انتخاب کنید";
            txtartist.ToolTip = "نام خواننده را به انگلیسی وارد کنید";
            txttrack.ToolTip = "نام موزیک را به انگلیسی وارد نمایید";
            btnRecs.ToolTip = "موزیک های پیشنهادی وب سایت ";
            rate.ToolTip = "اگر موزیک را شنیده اید، لطفا برای نظر متوسط، خوب یا عالی، به ترتیب علاقه مندی  1 یا 2 یا 3 را ثبت کنید و اگر نظری ندارید یا خوشتان نیامد این گزینه را رها کنید";
        }
        //--------------------------------------------------------


        //-----------------------------------------------------------------------------
        //Uri uri = new Uri(@"http://www.allmusic.com/search/songs/talagh");
        //WebRequest webRequest = WebRequest.Create(uri);
        //WebResponse response = webRequest.GetResponse();
        //StreamReader streamReader = new StreamReader(response.GetResponseStream());
        //do
        //{
        //    string ss = streamReader.ReadLine();
        //    SearchPlayer.StartTime = 0;
        //    SearchPlayer.Source = "";
            
        //    if (ss.IndexOf("www.allmusic.com/song") != -1)
        //    {
        //        string sss = ss.Substring(ss.IndexOf('"') + 1);

        //        SearchPlayer.Source = sss.Substring(0, sss.IndexOf('"'));
        //        mymsg.Text = sss; //sss.Substring(0, sss.IndexOf('"'));
                
        //        break;
        //    }
        //} while (!streamReader.EndOfStream);
        //-----------------------------------------------------------------------------
    }


    protected void txtartist_Search(object sender, SearchBoxEventArgs e)
    {
        //int a = Convert.ToInt16(Encoding.ASCII.GetBytes(txtartist.Text)[0]);
        string s = txtartist.Text;
        int a = (int)s[0];
        if ((a<40) || (a>125))
        {
            lbleng.Visible = true;
            lbleng.Text = "لطفا از حروف انگلیسی استفاده کنید";
            txtartist.Text = "";
            txtartist.Focus();
        }
        else
        {
            lbleng.Visible = false;
            txttrack.Focus();
            lbltemp.Text = txtartist.Text;
            SqlDsTrack.DataBind();
            SearchPlayer.StartTime = 0;
            SearchPlayer.Source = "";
        }
        lblmsgfound.Visible = false;
        txttrack.Text = "";
    }

    ////////////////////////////Generate Access Token for webRequest from Spotify///////////////////////////
    public string GetClientCredentialsAuthToken()
    {
        var webClient = new WebClient();

        var postparams = new NameValueCollection();
        postparams.Add("grant_type", "client_credentials");

        var authHeader = Convert.ToBase64String(Encoding.Default.GetBytes("95da9f399a7847a3944c7508196e3ddd:5a7aaef94bac44878b08edaa77c07ee6"));
        webClient.Headers.Add(HttpRequestHeader.Authorization, "Basic " + authHeader);

        var tokenResponse = webClient.UploadValues("https://accounts.spotify.com/api/token", postparams);

        var TokenRes = Encoding.UTF8.GetString(tokenResponse);

        int pFrom = TokenRes.IndexOf("access_token") + "access_token".Length;
        int pTo = TokenRes.LastIndexOf("token_type");
        string semiToken = TokenRes.Substring(pFrom, pTo - pFrom);
        string myAccessToken = semiToken.Substring(3, semiToken.Length - 6);

        return myAccessToken;
    }
    ////////////////////////////////////////////////////////////////////

    protected void txttrack_Search(object sender, SearchBoxEventArgs e)
    {
        //-------------------- Try Finding Track source for playing ---------------------

        var myUri = new Uri(@"https://api.spotify.com/v1/search?q=" + txtartist.Text + "%20" + txttrack.Text + "&type=track");
        var myWebRequest = WebRequest.Create(myUri);
        
        var myHttpWebRequest = (HttpWebRequest)myWebRequest;
        myHttpWebRequest.PreAuthenticate = true;

        string AccessToken = GetClientCredentialsAuthToken();

        myHttpWebRequest.Headers.Add("Authorization", "Bearer " + AccessToken);
        myHttpWebRequest.Accept = "application/json";

        rate.Value = 0;
        lblmsgfound.Visible = false;
        lblmsgerrorplay.Visible = false;
        lblmustentertrack.Visible = false;

        rate.Value = 0;
        lblmsgfound.Visible = false;
        lblmsgerrorplay.Visible = false;
        lblmustentertrack.Visible = false;

        try
        {

            var myWebResponse = myHttpWebRequest.GetResponse();
            var responseStream = myWebResponse.GetResponseStream();
            var myStreamReader = new StreamReader(responseStream, Encoding.Default);
            
            bool FoundMusic = false;
            do
            {
                string ss = myStreamReader.ReadLine();
                SearchPlayer.StartTime = 0;
                SearchPlayer.Source = "";

                if (ss.IndexOf("preview_url") != -1)
                {
                    string sss = ss.Substring(23);
                    
                    string sss1 = sss.Substring(0, sss.IndexOf('"'));
                    string sss2 = sss1.Substring(0, sss1.IndexOf('?'));
                    SearchPlayer.Source = sss2 + ".mp3";
                    //Response.Write("<script language=javascript>alert('"+ SearchPlayer.Source + "');</script>");
                    FoundMusic = true;
                    
                    //SearchPlayer.Source = "https://p.scdn.co/mp3-preview/1d6440fb8184fa386080e481582aa76093a6b415" + ".mp3";
                    SearchPlayer.AutoPlay = true;
                    //SearchPlayer.AutoPlay = false;
                    //SearchPlayer.AutoPlay = true;
                    break;
                }
            } while (!myStreamReader.EndOfStream);

            responseStream.Close();
            myWebResponse.Close();
            
            if (!FoundMusic)
            {
                lblmsgfound.Visible = true;
            }

            //--------------------- Add a Record to table Interests & Set its irank = 5 -------------- 
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MusicRecCn"].ToString());
            cn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Tracks where (name='" + txttrack.Text + "') and (artist='" + txtartist.Text + "')", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "Tracks");
            string tid = ds.Tables[0].Rows[0].ItemArray.GetValue(0).ToString();
            string trank = ds.Tables[0].Rows[0].ItemArray.GetValue(4).ToString();
            Session["trackid"] = tid;
            cmd.Dispose();
            ds.Dispose();
            da.Dispose();

            //--------------- check and insert if not exists -------------
            cmd = new SqlCommand("Select * from Interests where (userid=" + Convert.ToString(Session["userid"]) + ") and (musicid=" + tid + ")", cn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "Interests");
            if (ds.Tables[0].Rows.Count == 0)
            {
                SqlCommand cmd2 = new SqlCommand("Insert into Interests(userid, musicid, irank, trank)  Values(" + Convert.ToString(Session["userid"]) + " , " + tid + " , 5 , " + trank + ")", cn);
                cmd2.ExecuteNonQuery();
            }

            cn.Close();
            cn.Dispose();
        }
        catch
        {
            lblmsgerrorplay.Visible = true;
        }
        
    }

    protected void btnheard_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["trackid"]) != "")
        {
            lblmustentertrack.Visible = false;
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MusicRecCn"].ToString());
            cn.Open();
            SqlCommand cmd = new SqlCommand("Update Interests set irank=4 where (userid=" + Convert.ToString(Session["userid"]) + ") and (musicid=" + Convert.ToString(Session["trackid"]) + ") and (irank > 4)", cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();
        }
        else
        {
            lblmustentertrack.Visible = true;
        }
    }
    
    protected void btnrate_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["trackid"]) != "")
        {
            lblmustentertrack.Visible = false;
            int x = Convert.ToInt16(rate.Value);
            switch (x)
            {
                case 1: x = 3; break;
                case 2: x = 2; break;
                case 3: x = 1; break;
                default: x = 4; break;
            }
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MusicRecCn"].ToString());
            cn.Open();
            SqlCommand cmd = new SqlCommand("Update Interests set irank=" + x.ToString() + " where (userid=" + Convert.ToString(Session["userid"]) + ") and (musicid=" + Convert.ToString(Session["trackid"]) + ")", cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();
        }
        else
        {
            lblmustentertrack.Visible = true;
        }
    }



    protected void btnRecs_Click(object sender, EventArgs e)
    {
        
        //================================== Find Recommendations Demo & Ctx ===========================================

        //-------------------- find Sorted Similar musics of Demo approach ---------------------------------
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MusicRecCn"].ToString());
        cn.Open();
        SqlCommand cmd = new SqlCommand("Select * from Users", cn);
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds, "User");
        int nOtherUsers = ds.Tables[0].Rows.Count - 1;
        int[,] arrSimilarUsersDemo = new int[nOtherUsers, 2];
        int[,] arrSimilarUsersCtx = new int[nOtherUsers, 2];
        int iOtherUsers = 0;

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            int demorate = 0;
            int ctxrate = 0;

            if (ds.Tables[0].Rows[i].ItemArray.GetValue(0).ToString() != Session["userid"].ToString())
            {
                if (ds.Tables[0].Rows[i].ItemArray.GetValue(9).ToString() == Session["demolocation"].ToString())
                {
                    demorate++;
                }
                if (ds.Tables[0].Rows[i].ItemArray.GetValue(10).ToString() == Session["demoage"].ToString())
                {
                    demorate++;
                }
                if (ds.Tables[0].Rows[i].ItemArray.GetValue(11).ToString() == Session["demolooking"].ToString())
                {
                    demorate++;
                }
                if (ds.Tables[0].Rows[i].ItemArray.GetValue(12).ToString() == Session["demorelig"].ToString())
                {
                    demorate++;
                }
                if (ds.Tables[0].Rows[i].ItemArray.GetValue(13).ToString() == Session["demoedu"].ToString())
                {
                    demorate++;
                }
                arrSimilarUsersDemo[iOtherUsers, 0] = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray.GetValue(0));
                arrSimilarUsersDemo[iOtherUsers, 1] = demorate;
                for (int j = 0; j < nOtherUsers - 1; j++)
                {
                    for (int k = j + 1; k < nOtherUsers; k++)
                    {
                        if (arrSimilarUsersDemo[j, 1] < arrSimilarUsersDemo[k, 1])
                        {
                            int temp;
                            temp = arrSimilarUsersDemo[j, 1];
                            arrSimilarUsersDemo[j, 1] = arrSimilarUsersDemo[k, 1];
                            arrSimilarUsersDemo[k, 1] = temp;
                            temp = arrSimilarUsersDemo[j, 0];
                            arrSimilarUsersDemo[j, 0] = arrSimilarUsersDemo[k, 0];
                            arrSimilarUsersDemo[k, 0] = temp;
                        }
                    }
                }

                //---------------------------- find Sorted Similar musics of Context-aware approach -----------------------------
                if (ds.Tables[0].Rows[i].ItemArray.GetValue(3).ToString() == Session["ctxheartime"].ToString())
                {
                    ctxrate++;
                }
                if (ds.Tables[0].Rows[i].ItemArray.GetValue(4).ToString() == Session["ctxlonewith"].ToString())
                {
                    ctxrate++;
                }
                if (ds.Tables[0].Rows[i].ItemArray.GetValue(5).ToString() == Session["ctxmentcond"].ToString())
                {
                    ctxrate++;
                }
                if (ds.Tables[0].Rows[i].ItemArray.GetValue(6).ToString() == Session["ctxway"].ToString())
                {
                    ctxrate++;
                }
                if (ds.Tables[0].Rows[i].ItemArray.GetValue(7).ToString() == Session["ctxonsite"].ToString())
                {
                    ctxrate++;
                }
                if (ds.Tables[0].Rows[i].ItemArray.GetValue(8).ToString() == Session["ctxoffdev"].ToString())
                {
                    ctxrate++;
                }
                arrSimilarUsersCtx[iOtherUsers, 0] = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray.GetValue(0));
                arrSimilarUsersCtx[iOtherUsers, 1] = ctxrate;
                for (int j = 0; j < nOtherUsers - 1; j++)
                {
                    for (int k = j + 1; k < nOtherUsers; k++)
                    {
                        if (arrSimilarUsersCtx[j, 1] < arrSimilarUsersCtx[k, 1])
                        {
                            int temp;
                            temp = arrSimilarUsersCtx[j, 1];
                            arrSimilarUsersCtx[j, 1] = arrSimilarUsersCtx[k, 1];
                            arrSimilarUsersCtx[k, 1] = temp;
                            temp = arrSimilarUsersCtx[j, 0];
                            arrSimilarUsersCtx[j, 0] = arrSimilarUsersCtx[k, 0];
                            arrSimilarUsersCtx[k, 0] = temp;
                        }
                    }
                }
                iOtherUsers++;
            }

        }

        ds.Dispose();
        da.Dispose();
        cmd.Dispose();
        //cn.Close();
        //------------------------------- Making Recommendations, Demo Approach ----------------------------

        DataTable table = new DataTable();
        table.Columns.Add(new DataColumn("userid", typeof(int)));
        table.Columns.Add(new DataColumn("musicid", typeof(int)));
        table.Columns.Add(new DataColumn("itrate", typeof(decimal)));
        table.Columns.Add(new DataColumn("rx", typeof(string)));

        for (int i = 0; i < nOtherUsers; i++)
        {

            cmd = new SqlCommand("Select * from interests Where (userid='" + arrSimilarUsersDemo[i, 0] + "')", cn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "interests");

            for (int j = 0; j < ds.Tables["interests"].Rows.Count; j++)
            {
                int musicid = Convert.ToInt32(ds.Tables["interests"].Rows[j].ItemArray.GetValue(1));
                int irank = Convert.ToInt32(ds.Tables["interests"].Rows[j].ItemArray.GetValue(2));
                int trank = Convert.ToInt32(ds.Tables["interests"].Rows[j].ItemArray.GetValue(3));
                decimal itrate = Decimal.Divide(arrSimilarUsersDemo[i, 1], (5 * irank * trank));

                DataRow row = table.NewRow();
                row["userid"] = Convert.ToInt32(Session["userid"].ToString());
                row["musicid"] = musicid;
                row["itrate"] = itrate;
                row["rx"] = "demo";
                table.Rows.Add(row);
            }

            ds.Dispose();
            da.Dispose();
            cmd.Dispose();
        }
        //------------------------------- Making Recommendations, Context-Aware Approach ----------------------------
        for (int i = 0; i < nOtherUsers; i++)
        {

            cmd = new SqlCommand("Select * from interests Where (userid='" + arrSimilarUsersCtx[i, 0] + "')", cn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "interests");

            for (int j = 0; j < ds.Tables["interests"].Rows.Count; j++)
            {
                int musicid = Convert.ToInt32(ds.Tables["interests"].Rows[j].ItemArray.GetValue(1));
                int irank = Convert.ToInt32(ds.Tables["interests"].Rows[j].ItemArray.GetValue(2));
                int trank = Convert.ToInt32(ds.Tables["interests"].Rows[j].ItemArray.GetValue(3));
                decimal itrate = Decimal.Divide(arrSimilarUsersCtx[i, 1], (6 * irank * trank));

                DataRow row = table.NewRow();
                row["userid"] = Convert.ToInt32(Session["userid"].ToString());
                row["musicid"] = musicid;
                row["itrate"] = itrate;
                row["rx"] = "ctx";
                table.Rows.Add(row);
            }

            ds.Dispose();
            da.Dispose();
            cmd.Dispose();
        }
        //-------------------- End of Finding a list of Recommendation based on Similar users with demo & ctx --------------

        using (SqlBulkCopy bulk = new SqlBulkCopy(cn))
        {
            bulk.DestinationTableName = "Recs_Temp";
            bulk.WriteToServer(table);
        }

        //---------------------------- Delete old recommendations by two approaches demo & ctx -------------------

        cmd = new SqlCommand();
        cmd.Connection = cn;
        cmd.CommandText = "DELETE From Recs WHERE ((rx='demo') or (rx='ctx')) and (userid='" + Session["userid"].ToString() + "')";
        cmd.ExecuteNonQuery();
        cmd.Dispose();

        //-------------------------------- Transfer from Recs_Temp to Recs Table ----------------------------------

        cmd = new SqlCommand();
        cmd.Connection = cn;
        cmd.CommandText = "INSERT INTO Recs(userid, musicid, itrate, rx) Select  TOP (10) userid, musicid, itrate, rx from Recs_Temp Where (userid='" + Session["userid"].ToString() + "') ORDER BY itrate DESC";
        cmd.ExecuteNonQuery();
        cmd.Dispose();

        cmd = new SqlCommand();
        cmd.Connection = cn;
        cmd.CommandText = "DELETE from Recs_Temp";
        cmd.ExecuteNonQuery();
        cmd.Dispose();

        cn.Close();
        cn.Dispose();

        //------------------------------ Go to Calculate Content-Based Recommendations ---------------------------------
        Response.Redirect("AddCBRecs.aspx");

    }


    protected void btnlogout_Click(object sender, EventArgs e)
    {
        Session["userid"] = "";
        Session["musicsource"] = "";
        Session["trackid"] = "";

        Response.Redirect("default.aspx");
    }

}

//============== extra code ======================
//==================================== Play selected music among Recommendations ==============================
//        //Response.Write(grdrecs.Rows[grdrecs.SelectedIndex].Cells[1].Text);
//        //Response.Write("<br>" + grdrecs.Rows[grdrecs.SelectedIndex].Cells[2].Text);

//        Uri uri = new Uri(@"https://api.spotify.com/v1/search?q=" + grdrecs.Rows[grdrecs.SelectedIndex].Cells[1].Text + "%20" + grdrecs.Rows[grdrecs.SelectedIndex].Cells[2].Text + "&type=track");
//        WebRequest webRequest = WebRequest.Create(uri);
//        WebResponse response = webRequest.GetResponse();
//        StreamReader streamReader = new StreamReader(response.GetResponseStream());
//        do
//        {
//            string ss = streamReader.ReadLine();
//            if (ss.IndexOf("preview_url") != -1)
//            {
//                string sss = ss.Substring(23);
//                RecPlayer.StartTime = 0;
                
//                RecPlayer.Source = sss.Substring(0, sss.IndexOf('"'));
//                break;
//            }
//        } while (!streamReader.EndOfStream);
//=============================================================================================================


