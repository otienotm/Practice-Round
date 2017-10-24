using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class AddressForm : System.Web.UI.Page
{
    Address address;
    public static int addressID;
    //SqlConnection sc = new SqlConnection(@"Server = Localhost; Database=Lab3; Trusted_Connection=Yes;");
    SqlConnection sc = new SqlConnection(@"Server = localhost\SQLEXPRESS; Database=Lab3; Trusted_Connection=Yes;");

    protected void Page_Load(object sender, EventArgs e)
    {
        txtLastUpdated.Text = DateTime.Now.ToString("yyyy-MM-dd");
        LoadGridView();
    }

    protected void BtnAddressCommit_Click(object sender, EventArgs e)
    {
        address = new Address(Convert.ToInt32(txtHouseNumber.Text), txtStreet.Text, txtCityCounty.Text, DropStateAbb.SelectedValue, txtCountryAbb.Text,
            txtZip.Text, txtUpdatedBy.Text, txtLastUpdated.Text);

        sc.Open();
        SqlCommand command = new SqlCommand();
        try
        { 
            command.Connection = sc;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "address_insert";
            command.Parameters.AddWithValue("@addressID", address.GetAddressId());
            command.Parameters.AddWithValue("@houseNumber", address.GetHouseNumber());
            command.Parameters.AddWithValue("@street", address.GetStreet());
            command.Parameters.AddWithValue("@cityCounty", address.GetCityCounty());
            command.Parameters.AddWithValue("@stateAbb", address.GetStateAbb());
            command.Parameters.AddWithValue("@countryAbb", address.GetCountryAbb());
            command.Parameters.AddWithValue("@zip", address.GetZip());
            command.Parameters.AddWithValue("@updatedBy", address.GetUpdatedBy());
            command.Parameters.AddWithValue("@lastUpdated", address.GetLastUpdated());
            command.ExecuteNonQuery();
            sc.Close();
        }
        catch (SqlException ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
        }

        LoadGridView();
        ClearTextFields();
    }

    protected void GridViewAddress_SelectedIndexChanged(object sender, EventArgs e)
    {
        BtnAddressCommit.Enabled = false;
        BtnUpdate.Enabled = true;

        addressID = Convert.ToInt32(GridViewAddress.SelectedRow.Cells[1].Text);
        txtHouseNumber.Text = GridViewAddress.SelectedRow.Cells[2].Text;
        txtStreet.Text = GridViewAddress.SelectedRow.Cells[3].Text;
        txtCityCounty.Text = GridViewAddress.SelectedRow.Cells[4].Text;
        string drpText = GridViewAddress.SelectedRow.Cells[5].Text;
        DropStateAbb.ClearSelection();
        DropStateAbb.Items.FindByValue(drpText).Selected = true;
        txtCountryAbb.Text = GridViewAddress.SelectedRow.Cells[6].Text;
        txtZip.Text = GridViewAddress.SelectedRow.Cells[7].Text;
        
    }

    protected void LoadGridView()
    {
        sc.Open();
        SqlCommand command = new SqlCommand();
        command.Connection = sc;
        command.CommandText = "SELECT AddressID, HouseNumber, Street, CityCounty, StateAbb, CountryAbb, Zip FROM [dbo].[Address]";
        SqlDataReader reader = command.ExecuteReader();
        
        GridViewAddress.DataSource = reader;
        GridViewAddress.DataBind();
       
        reader.Close();
        sc.Close();
    }

    protected void ClearTextFields()
    {
        txtHouseNumber.Text = String.Empty;
        txtStreet.Text = String.Empty;
        txtCityCounty.Text = String.Empty;
        DropStateAbb.ClearSelection();
        txtCountryAbb.Text = String.Empty;
        txtZip.Text = String.Empty;
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        sc.Open();
        String sqlQuery;
        SqlCommand command = new SqlCommand();
        command.Connection = sc;
        try
        {
            sqlQuery = "UPDATE [dbo].[Address] SET houseNumber = @houseNumber, " +
                "street =@street, cityCounty = @cityCounty, stateAbb = @stateAbb, countryAbb = @countryAbb, zip =@zip " +
                "WHERE addressID = @addressID";
            command = new SqlCommand(sqlQuery, sc);
            command.Parameters.AddWithValue("@houseNumber", txtHouseNumber.Text);
            command.Parameters.AddWithValue("@street", txtStreet.Text);
            command.Parameters.AddWithValue("@cityCounty", txtCityCounty.Text);
            command.Parameters.AddWithValue("@stateAbb", DropStateAbb.SelectedValue);
            command.Parameters.AddWithValue("@countryAbb", txtCountryAbb.Text);
            command.Parameters.AddWithValue("@zip", txtZip.Text);
            command.Parameters.AddWithValue("@addressID", addressID);
            command.ExecuteNonQuery();

        }
        catch (SqlException ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
        }
        sc.Close();
        LoadGridView();

        ClearTextFields();
        BtnAddressCommit.Enabled = true;
        BtnUpdate.Enabled = false;

    }
}