using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class MasterPage : System.Web.UI.MasterPage
{
    //SqlConnection sc = new SqlConnection(@"Server = Localhost; Database=Lab3; Trusted_Connection=Yes;");
    SqlConnection sc = new SqlConnection(@"Server = localhost\SQLEXPRESS; Database=Lab3; Trusted_Connection=Yes;");
    static Boolean run = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        sc.Open();
        SqlCommand sqlQuery = new SqlCommand();
        sqlQuery.Connection = sc;

        if (!IsPostBack)
        {
            if(!run)
            {
                try
                {
                    sqlQuery.CommandText = "DELETE FROM Auto";
                    sqlQuery.ExecuteNonQuery();
                    sqlQuery.CommandText = "DELETE FROM Home";
                    sqlQuery.ExecuteNonQuery();
                    sqlQuery.CommandText = "DELETE FROM Policy";
                    sqlQuery.ExecuteNonQuery();
                    sqlQuery.CommandText = "DELETE FROM Insured";
                    sqlQuery.ExecuteNonQuery();
                    sqlQuery.CommandText = "DELETE FROM Address";
                    sqlQuery.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
                }
                run = true;
            }
           
        }

    }
}
