using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Write("<script>alert('Your paper '" + txt_title.Text + "' has been submitted.');</script>");
        //--------------------------------------
        if (! Page.IsPostBack)
        {
            rblang.SelectedIndex = 0;
        }
        //--------------------------------------

        if (rblang.SelectedIndex == 0)
        {
            Session["lang"] = "EN";
        }
        else
        {
            Session["lang"] = "FA";
        }
        
        //-------------------------------------------
        if (Session["lang"] == "EN")
        {
            lblusername.Text = "Username";
            lblpassword.Text = "Password";
            btnlogin.Text = "Login";
            btnreg.Text = "Register";
            lblmsg.Text = "No user has been registered with these specifications";
            RegularExpressionValidator1.ErrorMessage = "Please enter your username correctly!";
            RegularExpressionValidator1.Font.Name = "Times New Roman";
            RequiredFieldValidator1.ErrorMessage = "Please enter your username!";
            RequiredFieldValidator1.Font.Name = "Times New Roman";
            Panelusr.Direction = ContentDirection.LeftToRight;
            txtusername.EmptyMessage = "Please enter a username";
            txtusername.Font.Name = "Times New Roman";
            txtpassword.EmptyMessage = "Please enter the password";
            rblang.Font.Name = "Times New Roman";
            lnkhelp.Text = "Help";
            lnkhelp.Font.Name = "Times New Roman";
            lnkhelp.NavigateUrl = "Help_en.aspx";
            Page.Title = "Welcome to SARSIS";
            lbllang.Text = "Language";
        }
        else
        {
            lblusername.Text = "نام کاربری";
            lblpassword.Text = "رمز عبور";
            btnlogin.Text = "ورود";
            btnreg.Text = "ثبت نام";
            lblmsg.Text = "کاربری با این مشخصات ثبت نشده است";
            RegularExpressionValidator1.ErrorMessage = "لطفا شماره کاربری خود را به طور صحیح وارد نمایید";
            RegularExpressionValidator1.Font.Name = "B Mitra";
            RequiredFieldValidator1.ErrorMessage = "لطفا نام کاربری را وارد نمایید";
            RequiredFieldValidator1.Font.Name = "B Mitra";
            Panelusr.Direction = ContentDirection.RightToLeft;
            txtusername.EmptyMessage = "لطفا نام کاربری را وارد نمایید";
            txtusername.Font.Name = "B Mitra";
            txtpassword.EmptyMessage = "لطفا رمز عبور را وارد نمایید";
            rblang.Font.Name = "B Mitra";
            lnkhelp.Text = "راهنما";
            lnkhelp.Font.Name = "B Mitra";
            lnkhelp.NavigateUrl = "Help_fa.aspx";
            Page.Title = "Welcome to SARSIS";
            lbllang.Text = "زبان";
        }

    }

    protected void btnlogin_Click(object sender, EventArgs e)
    {
        //SqlConnection cn = new SqlConnection("Data Source=PAZAHR-PC;Initial Catalog=MusicRec;Integrated Security=True");
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MusicRecCn"].ToString());
        cn.Open();
        SqlCommand cmd = new SqlCommand("select * from Users where (id="+ txtusername.Text + ") and (password='"+ txtpassword.Text +"')", cn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds, "Users");
        if (ds.Tables[0].Rows.Count > 0)
        {
            Session["userid"]       = ds.Tables[0].Rows[0].ItemArray.GetValue(0).ToString();
            Session["ctxheartime"]  = ds.Tables[0].Rows[0].ItemArray.GetValue(3).ToString();
            Session["ctxlonewith"]  = ds.Tables[0].Rows[0].ItemArray.GetValue(4).ToString();
            Session["ctxmentcond"]  = ds.Tables[0].Rows[0].ItemArray.GetValue(5).ToString();
            Session["ctxway"]       = ds.Tables[0].Rows[0].ItemArray.GetValue(6).ToString();
            Session["ctxonsite"]    = ds.Tables[0].Rows[0].ItemArray.GetValue(7).ToString();
            Session["ctxoffdev"]    = ds.Tables[0].Rows[0].ItemArray.GetValue(8).ToString();
            Session["demolocation"] = ds.Tables[0].Rows[0].ItemArray.GetValue(9).ToString();
            Session["demoage"]      = ds.Tables[0].Rows[0].ItemArray.GetValue(10).ToString();
            Session["demolooking"]  = ds.Tables[0].Rows[0].ItemArray.GetValue(11).ToString();
            Session["demorelig"]    = ds.Tables[0].Rows[0].ItemArray.GetValue(12).ToString();
            Session["demoedu"]      = ds.Tables[0].Rows[0].ItemArray.GetValue(13).ToString();

           

            Response.Redirect("main.aspx");
        }
        else
        {
            lblmsg.Visible = true;
        }
        //strmaxid = ds.Tables[0].Rows[0].ItemArray.GetValue(0).ToString();
        ds.Clear();
        ds.Dispose();
        cn.Close();
    }

   



}
//==================================== Find URL of music on spotify ==========================================
        //Uri uri = new Uri(@"https://api.spotify.com/v1/search?q=benevis%20ali%20lohrasbi&type=track");
        //WebRequest webRequest = WebRequest.Create(uri);
        //WebResponse response = webRequest.GetResponse();
        //StreamReader streamReader = new StreamReader(response.GetResponseStream());
        //do 
        //{
        //    string ss = streamReader.ReadLine();
        //    if (ss.IndexOf("preview_url") != -1)
        //    {
        //        string sss = ss.Substring(23);
        //        Response.Write(sss.Substring(0, sss.IndexOf('"') ));
        //        break;
        //    }
        //} while (!streamReader.EndOfStream);
//=============================================================================================================

