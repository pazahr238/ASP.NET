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
using System.Collections.Specialized;

public partial class ShowRecs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //if (Convert.ToString(Session["userid"]) == "")
        //{
        //    Response.Redirect("Default.aspx");
        //}
        SearchPlayer.TitleBar.ShareButton.Visible = false;
        SearchPlayer.ToolBar.HDButton.Style["display"] = "none";
        SearchPlayer.ToolBar.PlayButtonCenter.Style["display"] = "none";
        SearchPlayer.ToolBar.SubtitlesButton.Style["display"] = "none";
        SearchPlayer.ToolBar.FullScreenButton.Style["display"] = "none";

        SearchPlayer.Source = "";
        SearchPlayer.AutoPlay = false;

        if (Convert.ToString(Session["lang"]) == "EN")
        {
            lblrecs.Text = "Recommendations for you";
            lblcmtop.Text = "Please rate each of recommended musics whether it is close to your interest";
            btngomain.Text = "Return";
            gvRecs.HeaderRow.Cells[0].Text = "Music";
            gvRecs.HeaderRow.Cells[1].Text = "Artist";
            gvRecs.HeaderRow.Cells[2].Text = "ID";
            gvRecs.HeaderRow.Cells[3].Text = "Preview";
            gvRecs.HeaderRow.Cells[4].Text = "Favorable";
            btnclear.Text = "Reset Rates";
            btnsubmit.Text = "Submit";
            btnremove.Text = "Remove Rates";
            lblmsg3.Text = "Percentage of your satisfaction:";
            btnstats.Text = "Calculate";
            lblInst.Text = "Instructions:";
            txtinst.Text = "1- Look at the recommendations and based on your personal idea whether you know or heard each one before, you can mark them favorable, if you confirm. In case of no idea about each music, you may hear the preview of it." + Environment.NewLine +
                            "2- In case of making mistake in marking, you can reset all rates of the table before submitting and start rating from the beginning." + Environment.NewLine +
                                     "3- You may also remove all your previous rates from the system." + Environment.NewLine + 
                                     "4- Submit your opinion about the recommendations. ";
            lblstats.Font.Name = "Times New Roman";
            txtinst.Font.Name = "Times New Roman";
            lblmsgerrorplay.Font.Name = "Times New Roman";
            Panelusr.Direction = ContentDirection.LeftToRight;
            lblmsgfound.Text = "Sorry! The music was not found.";
            lblmsgfound.Font.Name = "Times New Roman";
            lblmsgerrorplay.Text = "Fail to connect to Internet.";
            Page.Title = "View the recommendations";
        }
        else
        {
            lblrecs.Text = "پیشنهادات برای شما:";
            lblcmtop.Text = "لطفا درمورد هریک از پیشنهادات اگر مطابق سلیقه شماست نظر بدهید";
            btngomain.Text = "بازگشت";
            gvRecs.HeaderRow.Cells[0].Text = "موزیک";
            gvRecs.HeaderRow.Cells[1].Text = "خواننده";
            gvRecs.HeaderRow.Cells[2].Text = "شماره";
            gvRecs.HeaderRow.Cells[3].Text = "پیش نمایش";
            gvRecs.HeaderRow.Cells[4].Text = "علاقمندی";
            btnclear.Text = "نظردهی مجدد";
            btnsubmit.Text = "ثبت نظرات";
            btnremove.Text = "حذف نظرات ثبت شده";
            lblmsg3.Text = "میزان رضایت شما:";
            btnstats.Text = "محاسبه";
            lblInst.Text = "دستورالعمل استفاده از این صفحه";
            txtinst.Text = "1- به پیشنهادات نگاه کنید و برمبنای سلیقه شخصی خود برای هر یک چه آن را اکنون شنیدید یا قبلا شنیده بودید اگر پیشنهاد را تایید می کنید می توانید علاقمندی آن را علامت بزنید. " + Environment.NewLine +
                            "2- اگر در علامت زدن علاقمندی برای موزیک های پیشنهادی خواستید نظر خود را عوض کنید می توانید تمام علامت های زده شده را با فشردن نظردهی مجدد بردارید، مجددا تصمیم بگیرید و علامت بزنید" + Environment.NewLine +
                              "3- اگر قبلا نظری ثبت کرده اید و می خواهید آن ها را حذف کنید تا نظرات جدیدتان جایگزین آنها شوند، می توانید با فشردن دکمه حذف نظرات ثبت شده تمام نظرات قبلی ثبت شده خود را از سیستم حذف کنید" + Environment.NewLine +
                               "4- نظرات خود را درمورد پیشنهادات سایت ثبت کنید";
            
            lblstats.Font.Name = "B Mitra";
            txtinst.Font.Name = "B Mitra";
            Panelusr.Direction = ContentDirection.RightToLeft;
            lblmsgfound.Font.Name = "B Mitra";
            lblmsgfound.Text = "با عرض پوزش! امکان پخش پیش نمایش وجود ندارد";
            lblmsgerrorplay.Font.Name = "B Mitra"; 
            lblmsgerrorplay.Text = "امکان اتصال به اینترنت وجود ندارد";
            Page.Title = "مشاهده پیشنهادات";
        }

    }

    protected void btnrate_Click(object sender, EventArgs e)
    {
        //SqlConnection cn = new SqlConnection("Data Source=PAZAHR-PC;Initial Catalog=MusicRec;Integrated Security=True");
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MusicRecCn"].ToString());
        cn.Open();
        DataTable table = new DataTable();
        table.Columns.Add(new DataColumn("userid", typeof(int)));
        table.Columns.Add(new DataColumn("musicid", typeof(int)));
        table.Columns.Add(new DataColumn("name", typeof(string)));
        table.Columns.Add(new DataColumn("artist", typeof(string)));
        table.Columns.Add(new DataColumn("userrate", typeof(int)));

        foreach (GridViewRow row in gvRecs.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                RadRating MyRate = row.FindControl("myrate") as RadRating;

                DataRow roww = table.NewRow();
                roww["userid"] = Convert.ToInt32(Session["userid"].ToString());
                roww["musicid"] = Convert.ToInt32(row.Cells[2].Text);
                roww["name"] = row.Cells[0].Text;
                roww["artist"] = row.Cells[1].Text;
                roww["userrate"] = MyRate.Value;

                //--------- check if the record has been added before --------------
                SqlCommand cmd = new SqlCommand("SELECT     *    FROM    UserRates    WHERE    (userid = " + Session["userid"].ToString() + ") AND (musicid = " + row.Cells[2].Text + ")", cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "UserRates");
                if (ds.Tables[0].Rows.Count > 0)  //------- if rating was done before, delete it as updating ------------
                {
                    SqlCommand cmd2 = new SqlCommand("DELETE    FROM    UserRates    WHERE    (userid = " + Session["userid"].ToString() + ") AND (musicid = " + row.Cells[2].Text + ")", cn);
                    cmd2.ExecuteNonQuery();
                }
                table.Rows.Add(roww);
                
            }
        }

        using (SqlBulkCopy bulk = new SqlBulkCopy(cn))
          {
              bulk.DestinationTableName = "UserRates";
              bulk.WriteToServer(table);
          }

        lblstats.Text = "";

    }

    protected void btnstats_Click(object sender, EventArgs e)
    {
        ////SqlConnection cn = new SqlConnection("Data Source=PAZAHR-PC;Initial Catalog=MusicRec;Integrated Security=True");
        //SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MusicRecCn"].ToString());
        //cn.Open();
        //SqlCommand cmd = new SqlCommand("SELECT     count(userrate) as c , sum(userrate) as s    FROM    UserRates WHERE    (userid = " + Session["userid"].ToString() + ")" , cn);
        //SqlDataAdapter da = new SqlDataAdapter(cmd);
        //DataSet ds = new DataSet();
        //da.Fill(ds, "UserRates");
        //if (Convert.ToInt16(ds.Tables["UserRates"].Rows[0].ItemArray.GetValue(0)) > 0)
        //{
        //    int a = Convert.ToInt16(ds.Tables["UserRates"].Rows[0].ItemArray.GetValue(1));
        //    int b = Convert.ToInt16(ds.Tables["UserRates"].Rows[0].ItemArray.GetValue(0));
        //    decimal c = decimal.Divide(a, b) * 100;
        //    if (c - decimal.Truncate(c) == 0)
        //    {
        //        c = decimal.Truncate(c);
        //    }
            
        //    lblstats.Text = Convert.ToString(c) + " %";
        //}
        //else
        //{
        //    if (Session["lang"] == "EN")
        //    {
        //        lblstats.Text = "No Rate!";
        //    }
        //    else
        //    {
        //        lblstats.Text = "نظری داده نشده!";
        //    }
        //}
            
    }

    protected void btnclear_Click(object sender, EventArgs e)
    {
        Response.Redirect("ShowRecs.aspx");
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

    protected void gvRecs_SelectedIndexChanged(object sender, EventArgs e)
    {
        //-------------------- Try Finding Track source for playing ---------------------
        Uri myUri = new Uri(@"https://api.spotify.com/v1/search?q=" + gvRecs.SelectedRow.Cells[1].Text + "%20" + gvRecs.SelectedRow.Cells[0].Text + "&type=track");
        var myWebRequest = WebRequest.Create(myUri);
        var myHttpWebRequest = (HttpWebRequest)myWebRequest;
        myHttpWebRequest.PreAuthenticate = true;

        string AccessToken = GetClientCredentialsAuthToken();

        myHttpWebRequest.Headers.Add("Authorization", "Bearer " + AccessToken);
        myHttpWebRequest.Accept = "application/json";

        lblmsgfound.Visible = false;
        lblmsgerrorplay.Visible = false;
        try
        {
            var response = myHttpWebRequest.GetResponse();
            var responseStream = response.GetResponseStream();
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

                    SearchPlayer.Source = sss.Substring(0, sss.IndexOf('"'));
                    FoundMusic = true;
                    SearchPlayer.AutoPlay = true;
                    break;
                }
            } while (!myStreamReader.EndOfStream);

            if (!FoundMusic)
            {
                lblmsgfound.Visible = true;
            }
        }
        catch
        {
            lblmsgerrorplay.Visible = true;
        }
    }

    protected void btnremove_Click(object sender, EventArgs e)
    {
        //SqlConnection cn = new SqlConnection("Data Source=PAZAHR-PC;Initial Catalog=MusicRec;Integrated Security=True");
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MusicRecCn"].ToString());
        cn.Open();
        SqlCommand cmd2 = new SqlCommand("DELETE    FROM    UserRates    WHERE    (userid = " + Session["userid"].ToString() + ")", cn);
        cmd2.ExecuteNonQuery();
        lblstats.Text = "";
    }



    protected void btngomain_Click(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MusicRecCn"].ToString());
        cn.Open();
        SqlCommand cmd = new SqlCommand("SELECT     *    FROM    UserRates WHERE    (userid = " + Session["userid"].ToString() + ")", cn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds, "UserRates");
        if (ds.Tables["UserRates"].Rows.Count > 0)
        {
            Response.Redirect("Main.aspx");
        }
        else
        {
            if (Session["lang"] == "EN")
            {
                lblstats.Text = "Please submit your rates about the recommendations before leaving the page.";
            }
            else
            {
                lblstats.Text = "لطفا قبل از خروج از صفحه نظر خود را ثبت کنید";
            }
        }
    }
}