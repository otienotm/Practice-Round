using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class PolicyForm : System.Web.UI.Page
{ 
    Auto auto;
    Home home;
    public static int policyID;
    //SqlConnection sc = new SqlConnection(@"Server = Localhost; Database=Lab3; Trusted_Connection=Yes;");
    SqlConnection sc = new SqlConnection(@"Server = localhost\SQLEXPRESS; Database=Lab3; Trusted_Connection=Yes;");

    protected void Page_Load(object sender, EventArgs e)
    {
        txtPolicyLastUpdated.Text = DateTime.Now.ToString("yyyy-MM-dd");
        LoadAutoGridView();
        LoadHomeGridView();

        sc.Open();
        SqlCommand sqlQuery = new SqlCommand(){
            Connection = sc
        };

        try
        {
            sqlQuery.CommandText = "SELECT InsuredID FROM [dbo].[Insured]";
            SqlDataReader readPolicy = sqlQuery.ExecuteReader();

            if (!IsPostBack)
            {
                drpPolicyInsuredID.DataSource = readPolicy;
                drpPolicyInsuredID.DataTextField = "InsuredID";
                drpPolicyInsuredID.DataValueField = "InsuredID";
                drpPolicyInsuredID.DataBind();
            }
            readPolicy.Close();

            sqlQuery.CommandText = "SELECT AddressID FROM [dbo].[Address]";
            SqlDataReader reader = sqlQuery.ExecuteReader();

            if (!IsPostBack)
            {
                drpPolicyAddressID.DataSource = reader;
                drpPolicyAddressID.DataTextField = "AddressID";
                drpPolicyAddressID.DataValueField = "AddressID";
                drpPolicyAddressID.DataBind();
            }
            reader.Close();

        }
        catch (SqlException ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
        }

        sc.Close();
    }

    protected void BtndisplayAmounts_Click(object sender, EventArgs e)
    {
        sc.Open();
        SqlCommand sqlQuery = new SqlCommand(){
            Connection = sc
        };

        sqlQuery.CommandText = "SELECT SUM(Amount) from [dbo].[Policy]";
        SqlDataReader read = sqlQuery.ExecuteReader();
        
        try
        {
            while (read.Read())
                txtPolicyAmounts.Text = read.GetValue(0).ToString();

            if (txtPolicyAmounts.Text.Equals(""))
                txtPolicyAmounts.Text = "No amounts to display";
        }
        catch(SqlException ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
        }
       
        read.Close();
        sc.Close();
    }

    protected void BtnContinue_Click(object sender, EventArgs e)
    {
        if (drpPolicyType.SelectedValue.Equals("Auto"))
            BtnAutoCommit.Enabled = true;
        else if(drpPolicyType.SelectedValue.Equals("Home"))
            BtnHomeCommit.Enabled = true;

        BtnContinue.Enabled = false;
    }

    protected void BtnAutoCommit_Click(object sender, EventArgs e)
    {
        auto = new Auto(txtTerminationDate.Text, txtEffectiveDate.Text, Convert.ToDouble(txtAmount.Text), Convert.ToInt32(txtPolicyYear.Text),
               drpPolicyType.SelectedValue, Convert.ToInt32(drpPolicyInsuredID.SelectedValue), Convert.ToInt32(drpPolicyAddressID.SelectedValue),
               txtPolicyUpdatedBy.Text, txtPolicyLastUpdated.Text, txtVinNumber.Text, txtMake.Text, txtModel.Text, Convert.ToInt32(txtMiles.Text));

        sc.Open();
        String sqlQuery;
        SqlCommand command = new SqlCommand();
        command.Connection = sc;

        try
        {
            sqlQuery = "INSERT INTO [dbo].[Policy] VALUES (@effectiveDate, @terminationDate, @amount, @PolicyYear, @PolicyType, @insuredID, @addressID, @updatedBy, @lastUpdated)";
            command = new SqlCommand(sqlQuery, sc);
            command.Parameters.AddWithValue("@effectiveDate", auto.GetEffectiveDate());
            command.Parameters.AddWithValue("@terminationDate", auto.GetTerminationDate());
            command.Parameters.AddWithValue("@amount", auto.GetAmount());
            command.Parameters.AddWithValue("@policyYear", auto.GetPolicyYear());
            command.Parameters.AddWithValue("@policyType", auto.GetPolicyType());
            command.Parameters.AddWithValue("@insuredID", auto.GetInsuredID());
            command.Parameters.AddWithValue("@addressID", auto.GetAddressID());
            command.Parameters.AddWithValue("@updatedBy", auto.GetUpdatedBy());
            command.Parameters.AddWithValue("@lastUpdated", auto.GetLastUpdated());
            command.ExecuteNonQuery();

            getAutoPolicyID();
            sqlQuery = "INSERT INTO [dbo].[Auto] VALUES (@policyId, @VinNumber, @make, @model, @miles, @updatedByAuto, @lastUpdatedAuto)";
            command = new SqlCommand(sqlQuery, sc);
            command.Parameters.AddWithValue("@policyId", txtAutoPolicyID.Text);
            command.Parameters.AddWithValue("@VinNumber", auto.GetVinNumber());
            command.Parameters.AddWithValue("@make", auto.GetMake());
            command.Parameters.AddWithValue("@model", auto.GetModel());
            command.Parameters.AddWithValue("@miles", auto.GetMiles());
            command.Parameters.AddWithValue("@updatedByAuto", "Tracy Otieno");
            command.Parameters.AddWithValue("@lastUpdatedAuto", DateTime.Now);
            command.ExecuteNonQuery();

            sc.Close();
        }
        catch (SqlException ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
        }


        ClearTextFields();
        LoadAutoGridView();
        JoinStatement();
        BtnContinue.Enabled = true;
        BtnAutoCommit.Enabled = false;
    }

    protected void getAutoPolicyID()
    {
        SqlCommand sqlQuery = new SqlCommand();
        sqlQuery.Connection = sc;
        sqlQuery.CommandText = "SELECT MAX(PolicyID) FROM [dbo].[Policy]";
        SqlDataReader reader = sqlQuery.ExecuteReader();

        try
        {
            while (reader.Read())
                txtAutoPolicyID.Text = reader.GetValue(0).ToString();

        }
        catch (SqlException ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
        }

        reader.Close();
    }

    protected void BtnHomeCommit_Click(object sender, EventArgs e)
    {
        home = new Home(txtTerminationDate.Text, txtEffectiveDate.Text, Convert.ToDouble(txtAmount.Text), Convert.ToInt32(txtPolicyYear.Text),
               drpPolicyType.SelectedValue, Convert.ToInt32(drpPolicyInsuredID.SelectedValue), Convert.ToInt32(drpPolicyAddressID.SelectedValue),
               txtPolicyUpdatedBy.Text, txtPolicyLastUpdated.Text, DropExteriorType.SelectedValue, DropAlarm.SelectedValue, Convert.ToInt32(txtDistance.Text));

        sc.Open();
        String sqlQuery;
        SqlCommand command = new SqlCommand();
        command.Connection = sc;

        try
        {
            sqlQuery = "INSERT INTO [dbo].[Policy] VALUES (@effectiveDate, @terminationDate, @amount, @PolicyYear, @PolicyType, @insuredID, @addressID, @updatedBy, @lastUpdated)";
            command = new SqlCommand(sqlQuery, sc);
            command.Parameters.AddWithValue("@effectiveDate", home.GetEffectiveDate());
            command.Parameters.AddWithValue("@terminationDate", home.GetTerminationDate());
            command.Parameters.AddWithValue("@amount", home.GetAmount());
            command.Parameters.AddWithValue("@policyYear", home.GetPolicyYear());
            command.Parameters.AddWithValue("@policyType", home.GetPolicyType());
            command.Parameters.AddWithValue("@insuredID", home.GetInsuredID());
            command.Parameters.AddWithValue("@addressID", home.GetAddressID());
            command.Parameters.AddWithValue("@updatedBy", home.GetUpdatedBy());
            command.Parameters.AddWithValue("@lastUpdated", home.GetLastUpdated());
            command.ExecuteNonQuery();

            getHomePolicyID();
            sqlQuery = "INSERT INTO [dbo].[Home] VALUES (@policyId, @exteriorType, @alarm, @distance, @updatedByHome, @lastUpdatedHome)";
            command = new SqlCommand(sqlQuery, sc);
            command.Parameters.AddWithValue("@policyId", txtHomePolicyID.Text);
            command.Parameters.AddWithValue("@exteriorType", home.GetExteriorType());
            command.Parameters.AddWithValue("@alarm", home.GetAlarm());
            command.Parameters.AddWithValue("@distance", home.GetDistance());
            command.Parameters.AddWithValue("@updatedByHome", "Tracy Otieno");
            command.Parameters.AddWithValue("@lastUpdatedHome", DateTime.Now);
            command.ExecuteNonQuery();

            sc.Close();
        }
        catch (SqlException ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
        }

        LoadHomeGridView();
        JoinStatement();
        ClearTextFields();
        BtnContinue.Enabled = true;
        BtnHomeCommit.Enabled = false;
    }

    protected void getHomePolicyID()
    {
        SqlCommand sqlQuery = new SqlCommand();
        sqlQuery.Connection = sc;
        sqlQuery.CommandText = "SELECT MAX(PolicyID) FROM [dbo].[Policy]";
        SqlDataReader reader = sqlQuery.ExecuteReader();

        try
        {
            while (reader.Read())
                txtHomePolicyID.Text = reader.GetValue(0).ToString();

        }
        catch (SqlException ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
        }

        reader.Close();
    }

    protected void BtnPolicyDisplay_Click(object sender, EventArgs e)
    {
        JoinStatement();
    }

    protected void JoinStatement()
    {
        sc.Open();
        SqlCommand sqlQuery = new SqlCommand()
        {
            Connection = sc
        };

        sqlQuery.CommandText = "SELECT i.FirstName, i.LastName, a.HouseNumber, a.Street, a.CityCounty, a.StateAbb, a.CountryAbb, a.Zip, h.ExteriorType, h.Alarm, " +
            "h.DistanceToFireStation FROM Insured i, Address a, Policy p LEFT JOIN Home h ON p.PolicyID = h.PolicyID " +
            "WHERE i.AddressID = a.AddressID AND i.InsuredID = p.InsuredID; ";

        SqlDataReader reader = sqlQuery.ExecuteReader();

        GridViewPolicy.DataSource = reader;
        GridViewPolicy.DataBind();

        reader.Close();
        sc.Close();
    }

    protected void ClearTextFields()
    {
        txtTerminationDate.Text = String.Empty;
        txtEffectiveDate.Text = String.Empty;
        txtAmount.Text = String.Empty;
        txtPolicyYear.Text = String.Empty;
        drpPolicyType.ClearSelection();
        drpPolicyInsuredID.ClearSelection();
        drpPolicyAddressID.ClearSelection();
        txtAutoPolicyID.Text = String.Empty;
        txtVinNumber.Text = String.Empty;
        txtMake.Text = String.Empty;
        txtModel.Text = String.Empty;
        txtMiles.Text = String.Empty;
        txtPolicyAmounts.Text = String.Empty;
        txtHomePolicyID.Text = String.Empty;
        DropExteriorType.ClearSelection();
        DropAlarm.ClearSelection();
        txtDistance.Text = String.Empty;
    }
   
    protected void GridViewAuto_SelectedIndexChanged(object sender, EventArgs e)
    {
         BtnContinue.Enabled = false;
         BtnUpdateAuto.Enabled = true;

        policyID = Convert.ToInt32(GridViewAuto.SelectedRow.Cells[1].Text);
        txtEffectiveDate.Text = GridViewAuto.SelectedRow.Cells[2].Text;
        txtTerminationDate.Text = GridViewAuto.SelectedRow.Cells[3].Text;
        txtAmount.Text = GridViewAuto.SelectedRow.Cells[4].Text;
        txtPolicyYear.Text = GridViewAuto.SelectedRow.Cells[5].Text;
        string drpText = "Auto";
        drpPolicyType.ClearSelection();
        drpPolicyType.Items.FindByValue(drpText).Selected = true;
        string drpTextInsured = GridViewAuto.SelectedRow.Cells[7].Text;
        drpPolicyInsuredID.ClearSelection();
        drpPolicyInsuredID.Items.FindByValue(drpTextInsured).Selected = true;
        string drpTextAddress = GridViewAuto.SelectedRow.Cells[8].Text;
        drpPolicyAddressID.ClearSelection();
        drpPolicyAddressID.Items.FindByValue(drpTextAddress).Selected = true;
        txtVinNumber.Text = GridViewAuto.SelectedRow.Cells[9].Text;
        txtMake.Text = GridViewAuto.SelectedRow.Cells[10].Text;
        txtModel.Text = GridViewAuto.SelectedRow.Cells[11].Text;
        txtMiles.Text = GridViewAuto.SelectedRow.Cells[12].Text;
    }

    protected void LoadAutoGridView()
    {
        sc.Open();
        SqlCommand command = new SqlCommand();
        command.Connection = sc;
        command.CommandText = "SELECT p.PolicyID, p.EffectiveDate, p.TerminationDate, p.Amount, p.PolicyYear, p.PolicyType, p.InsuredID, p.AddressID, a.VinNumber, " +
            "a.Make, a.Model, a.MilesPerYear FROM Policy p INNER JOIN Auto a ON p.policyID = a.policyID";
        SqlDataReader reader = command.ExecuteReader();

       GridViewAuto.DataSource = reader;
       GridViewAuto.DataBind();
       
        reader.Close();
        sc.Close();
        
    }

    protected void LoadHomeGridView()
    {
        sc.Open();
        SqlCommand command = new SqlCommand();
        command.Connection = sc;
        command.CommandText = "SELECT p.PolicyID, p.EffectiveDate, p.TerminationDate, p.Amount, p.PolicyYear, p.PolicyType, p.InsuredID, p.AddressID, h.ExteriorType, " +
            "h.Alarm, h.DistanceToFireStation FROM Policy p INNER JOIN Home h ON p.policyID = h.policyID";
        SqlDataReader reader = command.ExecuteReader();

        GridViewHome.DataSource = reader;
        GridViewHome.DataBind();
       
        reader.Close();
        sc.Close();
    }

    protected void GridViewHome_SelectedIndexChanged(object sender, EventArgs e)
    {
        BtnContinue.Enabled = false;
        BtnUpdateHome.Enabled = true;

        policyID = Convert.ToInt32(GridViewHome.SelectedRow.Cells[1].Text);
        txtEffectiveDate.Text = GridViewHome.SelectedRow.Cells[2].Text;
        txtTerminationDate.Text = GridViewHome.SelectedRow.Cells[3].Text;
        txtAmount.Text = GridViewHome.SelectedRow.Cells[4].Text;
        txtPolicyYear.Text = GridViewHome.SelectedRow.Cells[5].Text;

        string drpText = "Home";
        drpPolicyType.ClearSelection();
        drpPolicyType.Items.FindByValue(drpText).Selected = true;

        string drpTextInsured = GridViewHome.SelectedRow.Cells[7].Text;
        drpPolicyInsuredID.ClearSelection();
        drpPolicyInsuredID.Items.FindByValue(drpTextInsured).Selected = true;

        string drpTextAddress = GridViewHome.SelectedRow.Cells[8].Text;
        drpPolicyAddressID.ClearSelection();
        drpPolicyAddressID.Items.FindByValue(drpTextAddress).Selected = true;

        string drpTextExterior = GridViewHome.SelectedRow.Cells[9].Text;
        DropExteriorType.ClearSelection();
        DropExteriorType.Items.FindByValue(drpTextExterior).Selected = true;

        string drpTextAlarm = GridViewHome.SelectedRow.Cells[10].Text;
        //.ClearSelection();
        //DropAlarm.Items.FindByValue(drpTextAlarm).Selected = true;
        DropAlarm.Items.FindByText(drpTextAlarm).Selected = true;

        txtDistance.Text = GridViewHome.SelectedRow.Cells[11].Text;
    }

    protected void BtnUpdateAuto_Click(object sender, EventArgs e)
    {
        sc.Open();
        String sqlQuery;
        SqlCommand command = new SqlCommand();
        command.Connection = sc;
        try
        {
            sqlQuery = "UPDATE [dbo].[Policy] SET effectiveDate = @effectiveDate, terminationDate = @terminationDate, amount=@amount, policyYear=@policyYear, " +
                "insuredID = @insuredID, addressID = @addressID WHERE policyID = @policyID";
            command = new SqlCommand(sqlQuery, sc);
            command.Parameters.AddWithValue("@effectiveDate", txtEffectiveDate.Text);
            command.Parameters.AddWithValue("@terminationDate", txtTerminationDate.Text);
            command.Parameters.AddWithValue("@amount", txtAmount.Text);
            command.Parameters.AddWithValue("@policyYear", txtPolicyYear.Text);
            command.Parameters.AddWithValue("@insuredID", drpPolicyInsuredID.SelectedValue);
            command.Parameters.AddWithValue("@addressID", drpPolicyAddressID.SelectedValue);
            command.Parameters.AddWithValue("@policyID", policyID);
            command.ExecuteNonQuery();

            sqlQuery = "UPDATE [dbo].[Auto] SET vinNumber = @vinNumber, make =@make, model = @model, milesPerYear = @miles WHERE policyID = @policyID";
            command = new SqlCommand(sqlQuery, sc);
            command.Parameters.AddWithValue("@vinNumber", txtVinNumber.Text);
            command.Parameters.AddWithValue("@make", txtMake.Text);
            command.Parameters.AddWithValue("@model", txtModel.Text);
            command.Parameters.AddWithValue("@miles", txtMiles.Text);
            command.Parameters.AddWithValue("@policyID", policyID);
            command.ExecuteNonQuery();

        }
        catch (SqlException ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
        }
        sc.Close();

        LoadAutoGridView();
        JoinStatement();
        ClearTextFields();
       
        BtnContinue.Enabled = true;
        BtnUpdateAuto.Enabled = false;
    }

    protected void BtnUpdateHome_Click(object sender, EventArgs e)
    {
        sc.Open();
        String sqlQuery;
        SqlCommand command = new SqlCommand();
        command.Connection = sc;
        try
        {
            sqlQuery = "UPDATE [dbo].[Policy] SET effectiveDate = @effectiveDate, terminationDate = @terminationDate, amount=@amount, policyYear=@policyYear, " +
                "insuredID = @insuredID, addressID = @addressID WHERE policyID = @policyID";
            command = new SqlCommand(sqlQuery, sc);
            command.Parameters.AddWithValue("@effectiveDate", txtEffectiveDate.Text);
            command.Parameters.AddWithValue("@terminationDate", txtTerminationDate.Text);
            command.Parameters.AddWithValue("@amount", txtAmount.Text);
            command.Parameters.AddWithValue("@policyYear", txtPolicyYear.Text);
            command.Parameters.AddWithValue("@insuredID", drpPolicyInsuredID.SelectedValue);
            command.Parameters.AddWithValue("@addressID", drpPolicyAddressID.SelectedValue);
            command.Parameters.AddWithValue("@policyID", policyID);
            command.ExecuteNonQuery();

            sqlQuery = "UPDATE [dbo].[Home] SET exteriorType = @exteriorType, alarm = @alarm, distanceToFireStation = @distance WHERE policyID = @policyID";
            command = new SqlCommand(sqlQuery, sc);
            command.Parameters.AddWithValue("@exteriorType", DropExteriorType.SelectedValue);
            command.Parameters.AddWithValue("@alarm", DropAlarm.SelectedValue);
            command.Parameters.AddWithValue("@distance", txtDistance.Text);
            command.Parameters.AddWithValue("@policyID", policyID);
            command.ExecuteNonQuery();

        }
        catch (SqlException ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
        }
        sc.Close();

        LoadHomeGridView();
        JoinStatement();
        ClearTextFields();

        BtnContinue.Enabled = true;
        BtnUpdateHome.Enabled = false;
    }
}
