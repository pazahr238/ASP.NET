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
using System.Net;
using System.Configuration;

public partial class AddTracksToDB : System.Web.UI.Page
{
//=========================== get track tags ====================================
    public string TrackGetTags(string mthartist, string mthtrack)
    {

        HttpWebRequest mthrq = WebRequest.Create("http://ws.audioscrobbler.com/2.0/?method=track.gettoptags&artist=" + mthartist + "&track=" + mthtrack + "&api_key=e985908239c83158e8c2ddbb8beadc73") as HttpWebRequest;
        //60 Second Timeout
        mthrq.Timeout = 60000;
        //Also note you can set the Proxy property here if required; sometimes it is, especially if you are behind a firewall - rq.Proxy = new WebProxy("proxy_address");

        try
        {
            HttpWebResponse mthresponse = mthrq.GetResponse() as HttpWebResponse;
            XmlTextReader mthreader = new XmlTextReader(mthresponse.GetResponseStream());
            XmlDocument mthmyDocument = new XmlDocument();
            mthmyDocument.Load(mthreader);

            XmlNodeList mthmyNodes = mthmyDocument.GetElementsByTagName("name");
            string strtags = "";
            for (int j = 0; j < mthmyNodes.Count; j++)
            {
                strtags += mthmyNodes[j].InnerText;
                if (j != mthmyNodes.Count - 1)
                {
                    strtags += ",";
                }
            }

            return strtags;
        }
        catch
        {
            return "AliAliAli";
        }
        
    }
//=========================== get track id ======================================
    public int getid()
    {
        string strmaxid = "";
        //SqlConnection cn = new SqlConnection("Data Source=PAZAHR-PC;Initial Catalog=MusicRec;Integrated Security=True");
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MusicRecCn"].ToString());
        cn.Open();
        SqlCommand cmd = new SqlCommand("select max(id) as maxid from Tracks", cn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds, "Tracks");

        strmaxid = ds.Tables[0].Rows[0].ItemArray.GetValue(0).ToString();
        ds.Clear();
        ds.Dispose();
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
//============================================================================
  
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
}

//--------------------------------- Start Add music Tracks to DB ------------------------------------------
        //Response.Write("Start:" + DateTime.Now.ToString("h:mm:ss tt"));

        ////------------------------ get Tracks --------------------------------
        //SqlConnection cn = new SqlConnection("Data Source=PAZAHR-PC;Initial Catalog=MusicRec;Integrated Security=True");
        //cn.Open();
        ////--------------------------------------
        //DataTable table = new DataTable();
        //table.Columns.Add(new DataColumn("id", typeof(int)));
        //table.Columns.Add(new DataColumn("name", typeof(string)));
        //table.Columns.Add(new DataColumn("artist", typeof(string)));
        //table.Columns.Add(new DataColumn("tags", typeof(string)));
        //table.Columns.Add(new DataColumn("rank", typeof(int)));

        ////------------------------ for each artist name, get his/her tracks ----------------------

        //SqlCommand cmd = new SqlCommand("select * from Artists order by id", cn);
        //SqlDataAdapter da = new SqlDataAdapter(cmd);
        //DataSet ds = new DataSet();
        //da.Fill(ds, "Artists");

        //int trackid = getid();
        //for (int w = 2100; w < ds.Tables["Artists"].Rows.Count; w++)
        //{
        //    //------------------ get track name --------------------

        //    string trackartist = ds.Tables["Artists"].Rows[w].ItemArray.GetValue(1).ToString();

        //    string trackartist_cleanch = trackartist;
        //    if ((trackartist.IndexOf("&") != -1) || (trackartist.IndexOf("+") != -1) || (trackartist.IndexOf("#") != -1))
        //    {
        //        trackartist_cleanch = trackartist.Replace("&", "%26").Replace("+", "%2B").Replace("#", "%23");
        //    }
        //    //------------ old -----------
        //    String URLString = "http://ws.audioscrobbler.com/2.0/?method=artist.gettoptracks&artist=" + trackartist_cleanch + "&api_key=e985908239c83158e8c2ddbb8beadc73&limit=1000";
        //    XmlTextReader reader = new XmlTextReader(URLString);
        //    XmlDocument myDocument = new XmlDocument();
        //    myDocument.Load(reader);
        //    //------------- new ----------
        //    ////HttpWebRequest rq = WebRequest.Create("http://ws.audioscrobbler.com/2.0/?method=artist.gettoptracks&artist=" + trackartist_cleanch + "&api_key=e985908239c83158e8c2ddbb8beadc73&limit=1000") as HttpWebRequest;
        //    ////rq.Timeout = 60000;
        //    ////HttpWebResponse response = rq.GetResponse() as HttpWebResponse;
        //    ////XmlTextReader reader = new XmlTextReader(response.GetResponseStream());
        //    ////XmlDocument myDocument = new XmlDocument();
        //    ////myDocument.Load(reader);

        //    XmlNodeList myNodes1 = myDocument.GetElementsByTagName("track");
        //    string[] trackname = new string[1000];
        //    for (int i = 0; i < myNodes1.Count; i++)
        //    {
        //        trackname[i] = myNodes1[i].SelectNodes("name").Item(0).InnerText;
        //    }

        //    //----------------------- get track rank ----------------------

        //    myDocument.Save(@"d:\temp.xml");
        //    XDocument xdoc = XDocument.Load(@"d:\temp.xml");

        //    int k = 0;
        //    string[] trackrank = new string[1000];
        //    foreach (var item in xdoc.Descendants("track"))
        //    {
        //        trackrank[k] = item.Attribute("rank").Value;
        //        k++;
        //    }

        //    for (int j = 0; j < myNodes1.Count; j++)
        //    {
        //        string trackname_cleanch = trackname[j];
        //        if ((trackname[j].IndexOf("&") != -1) || (trackname[j].IndexOf("+") != -1) || (trackname[j].IndexOf("#") != -1))
        //        {
        //            trackname_cleanch = trackname[j].Replace("&", "%26").Replace("+", "%2B").Replace("#", "%23");
        //        }

        //        DataRow row = table.NewRow();
        //        row["id"] = trackid++;
        //        row["name"] = trackname[j];
        //        row["artist"] = trackartist;
        //        row["tags"] = TrackGetTags(trackartist_cleanch, trackname_cleanch);
        //        row["rank"] = trackrank[j];
        //        table.Rows.Add(row);
        //    }

        //}

        ////--------------------------------------

        //using (SqlBulkCopy bulk = new SqlBulkCopy(cn))
        //{
        //    bulk.DestinationTableName = "Tracks";
        //    bulk.WriteToServer(table);
        //}

        ////--------------------------------------
        //ds.Clear();
        //ds.Dispose();
        //da.Dispose();
        //cn.Close();
        
        //Response.Write("End:" + DateTime.Now.ToString("h:mm:ss tt"));
        //System.Media.SystemSounds.Exclamation.Play(); 
//--------------------------------- End Add music Tracks to DB ------------------------------------------