using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml.Linq;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/XmlFile.xml"));
           GridView1.DataSource = ds;
            GridView1.DataBind();
           /* var doc = XDocument.Load(Server.MapPath("~/XmlFile.xml"));
            var result = doc.Descendants("post").Where(x => x.Element("time") != null).Select(x => new
            {
                time = x.Element("time").Value,
                date = x.Element("date").Value,
                action = x.Element("action").Value,
               
            }).OrderByDescending(x => x.time).Take(5);*/
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-11MVEKI\SQLEXPRESS;Initial Catalog=ncr;Integrated Security=True ");
            DataSet p = new DataSet();
            DataTable q = p.Tables["data"];
            p.ReadXml(Server.MapPath("~/XmlFile.xml"));
            con.Open();
            using (SqlBulkCopy bc = new SqlBulkCopy(con))
            {
                bc.DestinationTableName = "data";
                bc.ColumnMappings.Add("date", "date1");
                bc.ColumnMappings.Add("time", "time1");
                bc.ColumnMappings.Add("action", "action");
                bc.WriteToServer(q);

            }


        }
    }
}