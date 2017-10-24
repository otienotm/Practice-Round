using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

/// Tracy Otieno
/// Lab 3
/// Honor Code

public partial class InsuredForm : System.Web.UI.Page
{
    Insured insured;
    public static int insuredID;
    public static int policyID;
    //SqlConnection sc = new SqlConnection(@"Server = Localhost; Database=Lab3; Trusted_Connection=Yes;");
    SqlConnection sc = new SqlConnection(@"Server = localhost\SQLEXPRESS; Database=Lab3; Trusted_Connection=Yes;");

    protected void Page_Load(object sender, EventArgs e)
    {
        txtInsuredLastUpdated.Text = DateTime.Now.ToString("yyyy-MM-dd");

        if (!IsPostBack)
            LoadGridView();

        sc.Open();
        SqlCommand sqlQuery = new SqlCommand()
        {
            Connection = sc
        };

        sqlQuery.CommandText = "SELECT AddressID FROM [dbo].[Address]";
        SqlDataReader reader = sqlQuery.ExecuteReader();

        if (!IsPostBack)
        {
            drpInsuredAddressID.DataSource = reader;
            drpInsuredAddressID.DataTextField = "AddressID";
            drpInsuredAddressID.DataValueField = "AddressID";
            drpInsuredAddressID.DataBind();
            drpInsuredAddressID.SelectedValue = drpInsuredAddressID.Text;
            drpInsuredAddressID.Attributes.Remove("Select Address");
            drpInsuredAddressID.Attributes.Add("Select Address", drpInsuredAddressID.Text);
        }
        reader.Close();
        sc.Close();

    }

    protected void BtnInsuredCommit_Click(object sender, EventArgs e)
    {
        insured = new Insured(txtFirstName.Text, txtLastName.Text, txtMiddle.Text, txtDateOfBirth.Text,
                Convert.ToInt32(txtCreditScore.Text), Convert.ToInt32(drpInsuredAddressID.SelectedValue), txtLicense.Text, txtInsuredUpdatedBy.Text,
                txtInsuredLastUpdated.Text);

        sc.Open();
        String sqlQuery;
        SqlCommand command = new SqlCommand();
        command.Connection = sc;

        try
        {
            sqlQuery = "INSERT INTO [dbo].[Insured] VALUES (@firstName, @lastName, @middle, @dateOfBirth, @creditScore, @addressID, @driversLicense, @updatedBy, @lastUpdated)";
            command = new SqlCommand(sqlQuery, sc);
            command.Parameters.AddWithValue("@firstName", insured.GetFirstName());
            command.Parameters.AddWithValue("@lastName", insured.GetLastName());

            if (insured.GetMiddle().Equals('\0'))
                command.Parameters.AddWithValue("@middle", DBNull.Value);
            else
                command.Parameters.AddWithValue("@middle", insured.GetMiddle());

            command.Parameters.AddWithValue("@dateOfBirth", insured.GetDOB());
            command.Parameters.AddWithValue("@creditScore", insured.GetCreditScore());
            command.Parameters.AddWithValue("@addressID", insured.GetAddressID());

            if (insured.GetDriversLicense().Equals(""))
                command.Parameters.AddWithValue("@driversLicense", DBNull.Value);
            else
                command.Parameters.AddWithValue("@driversLicense", insured.GetDriversLicense());

            command.Parameters.AddWithValue("@updatedBy", insured.GetUpdatedBy());
            command.Parameters.AddWithValue("@lastUpdated", insured.GetLastUpdated());

            command.ExecuteNonQuery();

        }
        catch (SqlException ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
        }

        sc.Close();

        //Response.Redirect("PolicyForm.aspx");
        LoadGridView();

        ClearTextFields();
    }

    protected void LoadGridView()
    {
        sc.Open();
        SqlCommand command = new SqlCommand();
        command.Connection = sc;
        command.CommandText = "SELECT InsuredID, FirstName, LastName, MI, DateOfBirth, CreditScore, AddressID, DriversLicenseNumber FROM [dbo].[Insured]";
        SqlDataReader reader = command.ExecuteReader();

        GridViewInsured.DataSource = reader;
        GridViewInsured.DataBind();
        
        reader.Close();
        sc.Close();
    }

    protected void GridViewInsured_SelectedIndexChanged(object sender, EventArgs e)
    {
        BtnInsuredCommit.Enabled = false;
        BtnDelete.Enabled = true;
        BtnUpdate.Enabled = true;

        insuredID = Convert.ToInt32(GridViewInsured.SelectedRow.Cells[1].Text);
        txtFirstName.Text = GridViewInsured.SelectedRow.Cells[2].Text;
        txtLastName.Text = GridViewInsured.SelectedRow.Cells[3].Text;
        txtMiddle.Text = GridViewInsured.SelectedRow.Cells[4].Text;
        txtDateOfBirth.Text = GridViewInsured.SelectedRow.Cells[5].Text;
        txtCreditScore.Text = GridViewInsured.SelectedRow.Cells[6].Text;
        string drpText = GridViewInsured.SelectedRow.Cells[7].Text;
        drpInsuredAddressID.ClearSelection();
        drpInsuredAddressID.Items.FindByValue(drpText).Selected = true;
        txtLicense.Text = GridViewInsured.SelectedRow.Cells[8].Text;
  
    }

    protected void ClearTextFields()
    {
        txtFirstName.Text = String.Empty;
        txtLastName.Text = String.Empty;
        txtMiddle.Text = String.Empty;
        txtDateOfBirth.Text = String.Empty;
        txtCreditScore.Text = String.Empty;
        drpInsuredAddressID.ClearSelection();
        txtLicense.Text = String.Empty;
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        if (txtMiddle.Text.Equals("&nbsp;"))
            txtMiddle.Text = String.Empty;

        if (txtLicense.Text.Equals("&nbsp;"))
            txtLicense.Text = String.Empty;


        sc.Open();
        String sqlQuery;
        SqlCommand command = new SqlCommand();
        command.Connection = sc;
        try
        {
            sqlQuery = "UPDATE [dbo].[Insured] SET firstName = @firstName, " +
                "lastName = @lastName, MI = @middle, DateOfBirth = @dob, creditScore = @creditScore, addressID = @addressID, " +
                "driversLicenseNumber = @driversLicenseNumber WHERE insuredID = @insuredID";
            command = new SqlCommand(sqlQuery, sc);
            command.Parameters.AddWithValue("@firstName", txtFirstName.Text);
            command.Parameters.AddWithValue("@lastName", txtLastName.Text);
             
            if (txtMiddle.Text.Equals(""))
                command.Parameters.AddWithValue("@middle", DBNull.Value);
            else
                command.Parameters.AddWithValue("@middle", txtMiddle.Text);

            command.Parameters.AddWithValue("@dob", txtDateOfBirth.Text);
            command.Parameters.AddWithValue("@creditScore", txtCreditScore.Text);
            command.Parameters.AddWithValue("@addressID", drpInsuredAddressID.SelectedValue);

            if (txtLicense.Text.Equals(""))
                command.Parameters.AddWithValue("@driversLicenseNumber", DBNull.Value);
            else
                command.Parameters.AddWithValue("@driversLicenseNumber", txtLicense.Text);

            command.Parameters.AddWithValue("@insuredID", insuredID);
            command.ExecuteNonQuery();

        }
        catch (SqlException ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
        }
        sc.Close();
        LoadGridView();

        ClearTextFields();
        BtnInsuredCommit.Enabled = true;
        BtnUpdate.Enabled = false;

    }

    protected void BtnDelete_Click1(object sender, EventArgs e)
    {
        sc.Open();
        String sqlQuery;
        SqlCommand command = new SqlCommand();
        command.Connection = sc;

        command.CommandText = "SELECT i.firstName, p.policyID from Insured i INNER JOIN Policy p on i.insuredID = p.insuredID";
        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
            policyID = Convert.ToInt32(reader["policyID"]);
        reader.Close();

        sqlQuery = "Delete from Auto WHERE policyID = @PolicyID";
        command = new SqlCommand(sqlQuery, sc);
        command.Parameters.AddWithValue("@policyID", policyID);
        command.ExecuteNonQuery();

        sqlQuery = "Delete from Home WHERE policyID = @PolicyID";
        command = new SqlCommand(sqlQuery, sc);
        command.Parameters.AddWithValue("@policyID", policyID);
        command.ExecuteNonQuery();

        sqlQuery = "Delete from Policy WHERE policyID = @PolicyID";
        command = new SqlCommand(sqlQuery, sc);
        command.Parameters.AddWithValue("@policyID", policyID);
        command.ExecuteNonQuery();

        sqlQuery = "Delete from Insured WHERE insuredID = @insuredID";
        command = new SqlCommand(sqlQuery, sc);
        command.Parameters.AddWithValue("@insuredID", insuredID);
        command.ExecuteNonQuery();

        sc.Close();
        LoadGridView();

        ClearTextFields();
        BtnInsuredCommit.Enabled = true;
        BtnDelete.Enabled = false;
        BtnUpdate.Enabled = false;
    }
}