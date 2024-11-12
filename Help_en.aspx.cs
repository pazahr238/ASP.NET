using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Help_en : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Help";
        btnreturn.Font.Name = "Times New Roman"; 
    }
    protected void btnreturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("default.aspx");
    }
}