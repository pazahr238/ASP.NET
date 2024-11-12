using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class AddCBRecs : System.Web.UI.Page
{
    //public int FindRow(int userid, int mthm)
    //{
    //    for (int mthi=0; mthi<mthm; mthi++)
    //    {
    //        if 
    //    }
    //    return;
    //}

    protected void Page_Load(object sender, EventArgs e)
    {

        //------------- Find CB recs based on favorite user's tag --------------
        //SqlConnection cn = new SqlConnection("Data Source=PAZAHR-PC;Initial Catalog=MusicRec;Integrated Security=True");
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MusicRecCn"].ToString());
        cn.Open();
        SqlCommand cmduserlikes = new SqlCommand("Select * from View_Interests_Tracks where (userid='" + Session["userid"].ToString() + "') and (irank <= 3)", cn);
        SqlDataAdapter dauserlikes = new SqlDataAdapter(cmduserlikes);
        DataSet dsuserlikes = new DataSet();
        dauserlikes.Fill(dsuserlikes, "View_Interests_Tracks");

        for (int i = 0; i < dsuserlikes.Tables[0].Rows.Count; i++)
        {
            string s = dsuserlikes.Tables[0].Rows[i].ItemArray.GetValue(3).ToString();
            char[] chr = { ',' };
            string[] arrtags = s.Split(chr);
            for (int j = 0; j < arrtags.Length; j++)
            {
                SqlCommand cmdextracttags = new SqlCommand("Insert Into CBTags(tag) Values ('" + arrtags[j] + "')", cn);
                cmdextracttags.ExecuteNonQuery();
                cmdextracttags.Dispose();
            }
        }

        SqlCommand cmdtags = new SqlCommand("Select tag, count(tag) as count from CBTags Group By tag Order By count DESC", cn);
        SqlDataAdapter datags = new SqlDataAdapter(cmdtags);
        DataSet dstags = new DataSet();
        datags.Fill(dstags, "CBTags");

        for (int i = 0; i < dstags.Tables[0].Rows.Count; i++)
        {
            string strtag = dstags.Tables[0].Rows[i].ItemArray.GetValue(0).ToString();
            if (strtag == "") continue;
            
            //-------------- Find 3 best tracks whose tags are of interest of the user, except the tracks which have been interested by the user ---------- 3 track bartar az nazare tag morede alaghe user, gheir az unaei ke like karde, peida mishe
            SqlCommand cmdothertracks = new SqlCommand("Select TOP (3) id, name, artist, tags, rank From Tracks WHERE (tags LIKE '%" + strtag + "%') AND (id NOT IN (SELECT  musicid  FROM    View_Interests_Tracks    WHERE   (userid='" + Session["userid"].ToString() + "') and (irank <= 3))) Order BY rank", cn);
            SqlDataAdapter daothertracks = new SqlDataAdapter(cmdothertracks);
            DataSet dsothertracks = new DataSet();
            daothertracks.Fill(dsothertracks, "Tracks");
            for (int j = 0; j < dsothertracks.Tables[0].Rows.Count; j++)
            {
                int trank = Convert.ToInt16(dsothertracks.Tables[0].Rows[j].ItemArray.GetValue(4));
                SqlCommand cmdCBRecs = new SqlCommand("Insert Into Recs(userid, musicid, itrate, rx) Values (" + Session["userid"].ToString() + ", " + dsothertracks.Tables[0].Rows[j].ItemArray.GetValue(0).ToString() + ", " + Decimal.Divide(1, 6 * trank).ToString() + ", 'cb')", cn);
                cmdCBRecs.ExecuteNonQuery();
                cmdCBRecs.Dispose();
            }
            cmdothertracks.Dispose();
            daothertracks.Dispose();
            dsothertracks.Dispose();
        }
        //------------ delete all temp data from table CBTags -----------------
        SqlCommand cmdDelTags = new SqlCommand("Delete from CBTags", cn);
        cmdDelTags.ExecuteNonQuery();
        cmdDelTags.Dispose();

        cmduserlikes.Dispose();
        dauserlikes.Dispose();
        dsuserlikes.Dispose();
        cmdtags.Dispose();
        datags.Dispose();
        dstags.Dispose();

        //------------- Find CB recs: consider the musics which the user has rated them, find the other musics with the same artist ------------
        SqlCommand cmdUserLikesArtist = new SqlCommand("SELECT Distinct artist FROM View_Interests_Tracks WHERE (userid='" + Session["userid"].ToString() + "') AND (irank <= 3)", cn);
        SqlDataAdapter daUserLikesArtist = new SqlDataAdapter(cmdUserLikesArtist);
        DataSet dsUserLikesArtist = new DataSet();
        daUserLikesArtist.Fill(dsUserLikesArtist, "View_Interests_Tracks");

        for (int i = 0; i < dsUserLikesArtist.Tables[0].Rows.Count; i++)
        {
            string artist = dsUserLikesArtist.Tables[0].Rows[i].ItemArray.GetValue(0).ToString();
            SqlCommand cmdOtherTracksByArtist = new SqlCommand("Select TOP (3) id, name, artist, tags, rank From Tracks WHERE (artist=N'" + artist + "') AND (id NOT IN (SELECT  musicid  FROM    View_Interests_Tracks    WHERE   (userid='" + Session["userid"].ToString() + "') and (irank <= 3))) Order BY rank", cn);
            SqlDataAdapter daOtherTracksByArtist = new SqlDataAdapter(cmdOtherTracksByArtist);
            DataSet dsOtherTracksByArtist = new DataSet();
            daOtherTracksByArtist.Fill(dsOtherTracksByArtist, "Tracks");
            for (int j = 0; j < dsOtherTracksByArtist.Tables[0].Rows.Count; j++)
            {
                int trank = Convert.ToInt16(dsOtherTracksByArtist.Tables[0].Rows[j].ItemArray.GetValue(4));
                //------------- check if the rec has not been added before then add the rec ----------
                string strsql = "Select * From Recs Where (userid = " + Session["userid"].ToString() + ") and (musicid = " + dsOtherTracksByArtist.Tables[0].Rows[j].ItemArray.GetValue(0).ToString() + ") and (rx = 'cb')";
                SqlDataAdapter dacheck = new SqlDataAdapter(strsql, cn);
                DataSet dscheck = new DataSet();
                dacheck.Fill(dscheck, "Recs");

                if (dscheck.Tables[0].Rows.Count == 0)
                {
                    SqlCommand cmdCBRecs = new SqlCommand("Insert Into Recs(userid, musicid, itrate, rx) Values (" + Session["userid"].ToString() + ", " + dsOtherTracksByArtist.Tables[0].Rows[j].ItemArray.GetValue(0).ToString() + ", " + Decimal.Divide(1, 6 * trank).ToString() + ", 'cb')", cn);
                    cmdCBRecs.ExecuteNonQuery();
                    cmdCBRecs.Dispose();
                }
            }
            cmdOtherTracksByArtist.Dispose();
            daOtherTracksByArtist.Dispose();
            dsOtherTracksByArtist.Dispose();
        }
        cmdUserLikesArtist.Dispose();
        daUserLikesArtist.Dispose();
        dsUserLikesArtist.Dispose();
        
        //--------------------------- Go to calculate Collaborative Filtering Recommendations -------------------------
        Response.Redirect("AddCFRecs.aspx");

    }
}


