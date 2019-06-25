using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class keyboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/XmlKeyFile.xml"));
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string consString = @"Data Source=DESKTOP-11MVEKI\SQLEXPRESS;Initial Catalog=USB;Integrated Security=True;Pooling=False";
            DataSet p = new DataSet();
            p.ReadXml(Server.MapPath("~/XmlKeyFile.xml"));
            Response.Write(p.Tables[0]);
            DataTable q = p.Tables["keyBoardActions"];
            using (SqlConnection con = new SqlConnection(consString))
            {
                con.Open();
                using (SqlTransaction sqlTransaction = con.BeginTransaction())
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con, SqlBulkCopyOptions.Default, sqlTransaction))
                    {
                        //Set the database table name
                        sqlBulkCopy.DestinationTableName = "dbo.KeyTable";

                        //[OPTIONAL]: Map the DataTable columns with that of the database table
                        sqlBulkCopy.ColumnMappings.Add("date", "dateKey");
                        sqlBulkCopy.ColumnMappings.Add("time", "timeKey");
                        sqlBulkCopy.ColumnMappings.Add("action", "actionKey");
                        try
                        {
                            sqlBulkCopy.WriteToServer(q);
                            sqlTransaction.Commit();
                        }
                        catch
                        {
                            sqlTransaction.Rollback();
                        }
                    }
                }
                con.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string consString = @"Data Source=DESKTOP-11MVEKI\SQLEXPRESS;Initial Catalog=USB;Integrated Security=True;Pooling=False";
            SqlConnection con = new SqlConnection(consString);
            string Start, End;
            //Start = TextBox1.Text;
            //End = TextBox2.Text;
            con.Open();
            SqlCommand cmd = new SqlCommand("select top 10 actionKey from KeyTable order by timeKey Desc", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}