using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class AddArtistsToDB : System.Web.UI.Page
{
    public int getid()
    {
        string strmaxid = "";
        //SqlConnection cn = new SqlConnection("Data Source=PAZAHR-PC;Initial Catalog=MusicRec;Integrated Security=True");
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MusicRecCn"].ToString());
        cn.Open();
        SqlCommand cmd = new SqlCommand("select max(id) as maxid from Artists", cn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds, "Artists");

        strmaxid = ds.Tables[0].Rows[0].ItemArray.GetValue(0).ToString();
        ds.Clear();
        ds.Dispose();
        da.Dispose();
        cn.Close();

        if (strmaxid == "")
        {
            return 1;
        }
        else
        {
            return int.Parse(strmaxid) + 1;
        }

    }
    //=======================================================================
    protected void Page_Load(object sender, EventArgs e)
    {
        //===================== get Artists ==============================
        //SqlConnection cn = new SqlConnection("Data Source=PAZAHR-PC;Initial Catalog=MusicRec;Integrated Security=True");
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MusicRecCn"].ToString());
        cn.Open();
        SqlCommand cmd = new SqlCommand("select * from Artists", cn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds, "Artists");
        //--------------------------------------
        DataTable table = new DataTable();
        table.Columns.Add(new DataColumn("id", typeof(int)));
        table.Columns.Add(new DataColumn("name", typeof(string)));
        table.Columns.Add(new DataColumn("url", typeof(string)));
        table.Columns.Add(new DataColumn("img", typeof(string)));
        //--------------------------------------
        String URLString = "http://ws.audioscrobbler.com/2.0/?method=tag.gettopartists&tag=iranian folk&api_key=6f22d776c23b3336e131cfb6ce6ed990&limit=1000";

        XmlTextReader reader = new XmlTextReader(URLString);
        XmlDocument myDocument = new XmlDocument();
        myDocument.Load(reader);
        XmlNodeList myNodes1 = myDocument.GetElementsByTagName("name");
        XmlNodeList myNodes2 = myDocument.GetElementsByTagName("url");

        myDocument.Save(@"d:\temp.xml");
        XDocument xdoc = XDocument.Load(@"d:\temp.xml");

        int k = 0;
        string[] ss = new string[1000];
        foreach (var item in xdoc.Descendants("image"))
        {
            if (item.Attribute("size").Value == "large")
            {
                ss[k] = item.Value;
                k++;
            }
        }

        int number = getid();
        for (int j = 0; j < myNodes1.Count; j++)
        {
            DataRow row = table.NewRow();
            row["id"] = number++;
            row["name"] = myNodes1[j].InnerText;
            row["url"] = myNodes2[j].InnerText;
            row["img"] = ss[j];
            table.Rows.Add(row);
        }

        //--------------------------------------

        using (SqlBulkCopy bulk = new SqlBulkCopy(cn))
        {
            bulk.DestinationTableName = "Artists";
            bulk.WriteToServer(table);
        }

        //--------------------------------------
        ds.Clear();
        ds.Dispose();
        da.Dispose();
        cn.Close();

    }
}


//-----------------khundane text haye elemente name ---------------------------------
//String URLString = "http://ws.audioscrobbler.com/2.0/?method=artist.getinfo&artist=Cher&api_key=6f22d776c23b3336e131cfb6ce6ed990&limit=1";

//     XmlTextReader reader = new XmlTextReader(URLString);
//     XmlDocument myDocument = new XmlDocument();
//     myDocument.Load(reader);
//     XmlNodeList myNodes = myDocument.GetElementsByTagName("name");

//     for (int j = 0; j < myNodes.Count; j++)
//     {
//                string track = myNodes[j].InnerText;
//                 lst.Items.Add(track);
//     }

//------------------- khundane url axaye large har record -----------------
//        String URLString = "http://ws.audioscrobbler.com/2.0/?method=artist.getinfo&artist=Cher&api_key=6f22d776c23b3336e131cfb6ce6ed990&limit=1";

//        XmlTextReader reader = new XmlTextReader(URLString);
//        XmlDocument myDocument = new XmlDocument();
//        myDocument.Load(reader);

//        myDocument.Save(@"d:\temp.xml");
//        XDocument xdoc = XDocument.Load(@"d:\temp.xml");

//        foreach (var item in xdoc.Descendants("image"))
//        {
//            if (item.Attribute("size").Value == "large")
//            {
//                lst.Items.Add(item.Value);
//            }
//        } 