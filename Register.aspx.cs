using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["lang"] == "EN")
        {
            lblname.Text = "Full Name";
            lblname.ToolTip = "Please enter your full name";
            lblid.Text = "Username";
            lblid.ToolTip = "Please enter your 10-digit ID number";
            lblpassword.Text = "Password";
            lblage.Text = "Age";
            lblcity.Text = "Current City";
            lbllooking.Text = "You're in social media for";
            lblrelig.Text = "Religion";
            lbledu.Text = "Education Level";
            lblheartime.Text = "Usual time of hearing music";
            lblhearmth.Text = "Method of hearing musics";
            lbllonewith.Text = "Accompanying Type";
            lblmentcond.Text = "Hearing Mood";
            btnret.Text = "Return";
            btnreg.Text = "Register";
            RegularExpressionValidator1.ErrorMessage = "Please enter the username correctly";
            lblmsg.Text = "Please enter the fields completely";

            txtname.EmptyMessage = "Please enter Full Name";
            txtusername.EmptyMessage = "Please enter Username";
            txtcity.EmptyMessage = "Please enter your current city";

            txtage.Font.Name = "Times New Roman";
            cbooffdev.Font.Name = "Times New Roman";
            cbolooking.Items.Clear();
            cbolooking.Items.Add("communication with friends");
            cbolooking.Items.Add("dating");
            cbolooking.Items.Add("network connections");
            cbolooking.Items.Add("entertainment");
            cbolooking.Items.Add("finding favorite musics");
            cborelig.Items.Clear();
            cborelig.Items.Add("Christianity");
            cborelig.Items.Add("Other");
            cboedu.Items.Clear();
            cboedu.Items.Add("Diploma");
            cboedu.Items.Add("Technician");
            cboedu.Items.Add("Bachelor");
            cboedu.Items.Add("Master");
            cboedu.Items.Add("PhD");
            cboheartime.Items.Clear();
            cboheartime.Items.Add("Day");
            cboheartime.Items.Add("Night");
            cboheartime.Items.Add("Does not matter");
            //rdolisthearmth.Items.Clear();
            //rdolisthearmth.Items.Add("Online");
            //rdolisthearmth.Items.Add("Offline");
            rdolisthearmth.Items[0].Text = "Online";
            rdolisthearmth.Items[1].Text = "Offline";
            cboonsite.Items.Clear();
            cboonsite.Items.Add("Usually from a specific website");
            cboonsite.Items.Add("With search / Does not matter");
            cbooffdev.Items.Clear();
            cbooffdev.Items.Add("Laptop / PC");
            cbooffdev.Items.Add("iPod / iPad");
            cbooffdev.Items.Add("Mobile / MP3 / MP4 Player");
            cbolonewith.Items.Clear();
            cbolonewith.Items.Add("Lonely");
            cbolonewith.Items.Add("With others");
            cbomentcond.Items.Clear();
            cbomentcond.Items.Add("Specific conditions like happiness/sadness/gloom");
            cbomentcond.Items.Add("Does not matter / Everytime I like");
            lblrepeateduser.Text = "This user has been registered before!";
            lblrepeateduser.Font.Name = "Times New Roman";

            Panelusr.Direction = ContentDirection.LeftToRight;

        }
        else
        {
            lblname.Text = "نام و نام خانوادگی";
            lblid.Text = "شماره کاربری";
            lblid.ToolTip = "لطفا کد ملی خود را وارد نمایید";
            lblpassword.Text = "رمز عبور";
            lblage.Text = "سن";
            txtage.Font.Name = "B Mitra";
            lblcity.Text = "محل سکونت";
            lbllooking.Text = "علاقه به فعالیت";
            lblrelig.Text = "دین";
            lbledu.Text = "سطح تحصیلات";
            lblheartime.Text = "زمان معمول شنیدن موسیقی";
            lblhearmth.Text = "روشهای شنیدن موسیقی";
            lbllonewith.Text = "همراهی";
            lblmentcond.Text = "حالت روحی برای شنیدن";
            btnret.Text = "بازگشت";
            btnreg.Text = "ثبت نام";
            RegularExpressionValidator1.ErrorMessage = "لطفا شماره کاربری خود را به طور صحیح وارد نمایید";
            lblmsg.Text = "لطفا مشخصات را به طور کامل وارد نمایید";

            txtname.EmptyMessage = "لطفا نام و نام خانوادگی را وارد نمایید";
            txtusername.EmptyMessage = "لطفا شماره کاربری را وارد نمایید";
            txtcity.EmptyMessage = "لطفا شهر محل سکونت خود را وارد کنید";

            cbolooking.Items.Clear();
            cbolooking.Items.Add("ارتباط با دوستان");
            cbolooking.Items.Add("دوست یابی");
            cbolooking.Items.Add("ارتباطات شبکه ای");
            cbolooking.Items.Add("تفریح");
            cbolooking.Items.Add("یافتن موسیقی های مورد علاقه");
            cbolooking.ToolTip = "با چه انگیزه ای به فعالیت در این شبکه اجتماعی موسیقی می پردازید؟ نزدیک ترین یا مهم ترین مورد را انتخاب کنید";
            cborelig.Items.Clear();
            cborelig.Items.Add("اسلام");
            cborelig.Items.Add("غیر اسلام");
            cboedu.Items.Clear();
            cboedu.Items.Add("دیپلم");
            cboedu.Items.Add("کاردانی");
            cboedu.Items.Add("کارشناسی");
            cboedu.Items.Add("کارشناسی ارشد");
            cboedu.Items.Add("دکترا");
            cboedu.ToolTip = "در چه مقطع تحصیلی ای قرار دارید؟ دانشجو یا دارای چه مدرکی هستید؟";
            cboheartime.Items.Clear();
            cboheartime.Items.Add("روز");
            cboheartime.Items.Add("شب");
            cboheartime.Items.Add("فرقی ندارد");
            cboheartime.ToolTip = "بیشتر ترجیح می دهید که چه موقعی از شبانه روز را برای گوش دادن به موسیقی مورد علاقه خود اختصاص دهید؟";
            rdolisthearmth.Items[0].Text = "آنلاین";
            rdolisthearmth.Items[1].Text = "آفلاین";
            rdolisthearmth.ToolTip = "معمولا موسیقی جدید مورد علاقه خود را مستقیما از روی سایت گوش می دهید (آنلاین)؟ یا ابتدا دانلود می کنید و از روی سیستم خود می شنوید (آفلاین)؟";
            cboonsite.Items.Clear();
            cboonsite.Items.Add("معمولا از یک سایت خاص");
            cboonsite.Items.Add("با جستجو در وب و فرقی ندارد");
            cbooffdev.Items.Clear();
            cbooffdev.Items.Add("Laptop / PC");
            cbooffdev.Items.Add("iPod / iPad");
            cbooffdev.Items.Add("Mobile / MP3 / MP4 Player");
            cboonsite.ToolTip = "نوع روش شنیدن موسیقی به طور آنلاین را مشخص کنید";
            cbooffdev.ToolTip = "نوع روش شنیدن موسیقی به طور آفلاین را مشخص کنید";
            cbolonewith.Items.Clear();
            cbolonewith.Items.Add("تنها");
            cbolonewith.Items.Add("همراه دیگران");
            cbolonewith.ToolTip = "موسیقی های مورد علاقه خود را معمولا تنهایی گوش می دهید یا همراه کسی؟";
            cbomentcond.Items.Clear();
            cbomentcond.Items.Add("شرایط خاص مثل شادی / ناراحتی / دلتنگی");
            cbomentcond.Items.Add("بستگی ندارد و هروقت دلم بخواهد");
            cbomentcond.ToolTip = "موسیقی مورد علاقه خود را در چه شرایط روحی می شنوید؟ در موقعیت خاص مثل شادی یا ناراحتی یا دلتنگی؟ یا هر موقعی می تواند باشد، بستگی به شرایط ندارد؟";
            lblrepeateduser.Text = "این نام کاربری قبلا ثبت شده است";
            lblrepeateduser.Font.Name = "B Mitra";
            
            Panelusr.Direction = ContentDirection.RightToLeft;

        }
    }


    protected void btnreg_Click(object sender, EventArgs e)
    {
        //SqlConnection cn = new SqlConnection("Data Source=PAZAHR-PC;Initial Catalog=MusicRec;Integrated Security=True");
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MusicRecCn"].ToString());
        cn.Open();

        SqlCommand cmdselect = new SqlCommand("select * from Users where (id=" + txtusername.Text + ")", cn);
        SqlDataAdapter da = new SqlDataAdapter(cmdselect);
        DataSet ds = new DataSet();
        da.Fill(ds, "Users");
        if (ds.Tables[0].Rows.Count == 0)
        {

            SqlCommand cmdinsert = new SqlCommand();
            try
            {
                cmdinsert.Connection = cn;
                cmdinsert.CommandText = "INSERT INTO Users(id, password, name, ctxheartime, ctxlonewith, ctxmentcond, ctxway, ctxonsite, ctxoffdev, demolocation, demoage, demolooking, demorelig, demoedu)   VALUES(" + txtusername.Text + ", N'" + txtpassword.Text + "', N'" + txtname.Text + "', N'" + cboheartime.Text + "', N'" + cbolonewith.Text + "', N'" + cbomentcond.Text + "', N'" + rdolisthearmth.SelectedValue + "', N'" + cboonsite.Text + "', N'" + cbooffdev.Text + "', N'" + txtcity.Text + "', " + txtage.Text + " , N'" + cbolooking.Text + "', N'" + cborelig.Text + "', N'" + cboedu.Text + "')";
                cmdinsert.ExecuteNonQuery();

                cn.Close();

                Response.Redirect("default.aspx");
            }
            catch
            {
                //lblmsg.Text = "مشخصات را کامل و صحیح وارد نمایید";
                lblmsg.Visible = true;
                //Label1.Text = "INSERT INTO Users(id, password, name, ctxheartime, ctxlonewith, ctxmentcond, ctxway, ctxonsite, ctxoffdev, demolocation, demoage, demolooking, demorelig, demoedu)   VALUES(" + txtusername.Text + ", N'" + txtpassword.Text + "', N'" + txtname.Text + "', N'" + cboheartime.Text + "', N'" + cbolonewith.Text + "', N'" + cbomentcond.Text + "', N'" + rdolisthearmth.SelectedValue + "', N'" + cboonsite.Text + "', N'" + cbooffdev.Text + "', N'" + txtcity.Text + "', " + txtage.Text + " , N'" + cbolooking.Text + "', N'" + cborelig.Text + "', N'" + cboedu.Text + "')";

            }
        }
        else
        {
            lblrepeateduser.Visible = true;
        }
        
    }


    protected void rdolisthearmth_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdolisthearmth.SelectedIndex == 0)
        {
            cboonsite.Visible = true;
            cbooffdev.Visible = false;
            cboonsite.Width = 350;
        }
        else
        {
            cboonsite.Visible = false;
            cbooffdev.Visible = true;
            cbooffdev.Width = 350;
        }
        
    }

  
}