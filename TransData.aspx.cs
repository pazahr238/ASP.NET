using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TransData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnmove_Click(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MusicRecCn"].ToString());
        cn.Open();
        SqlCommand cmd = new SqlCommand("select * from UserRates", cn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds, "UserRates");

        SqlConnection cnoff = new SqlConnection(ConfigurationManager.ConnectionStrings["MusicRecCnOff"].ToString());
        cnoff.Open();

        DataTable table = new DataTable();
        table.Columns.Add(new DataColumn("userid", typeof(int)));
        table.Columns.Add(new DataColumn("musicid", typeof(int)));
        table.Columns.Add(new DataColumn("name", typeof(string)));
        table.Columns.Add(new DataColumn("artist", typeof(string)));
        table.Columns.Add(new DataColumn("userrate", typeof(int)));

        for (int i = 0; i < ds.Tables["UserRates"].Rows.Count; i++)
        {
            DataRow row = table.NewRow();
            row["userid"] = ds.Tables["UserRates"].Rows[i].ItemArray.GetValue(0).ToString();
            row["musicid"] = ds.Tables["UserRates"].Rows[i].ItemArray.GetValue(1).ToString();
            row["name"] = ds.Tables["UserRates"].Rows[i].ItemArray.GetValue(2).ToString();
            row["artist"] = ds.Tables["UserRates"].Rows[i].ItemArray.GetValue(3).ToString();
            row["userrate"] = ds.Tables["UserRates"].Rows[i].ItemArray.GetValue(4).ToString();
            table.Rows.Add(row);
        }
        
        
        using (SqlBulkCopy bulk = new SqlBulkCopy(cnoff))
        {
            bulk.DestinationTableName = "UserRates";
            bulk.WriteToServer(table);
        }

        btnmove.Enabled = false;
    }
}