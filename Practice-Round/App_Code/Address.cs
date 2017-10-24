using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// Tracy Otieno
/// Lab 3
/// Honor Code
public class Address
{ 
    private int addressID;
    private static int nextID = 101;
    private int houseNumber;
    private string street;
    private string cityCounty;
    private string stateAbb;
    private string countryAbb;
    private string zip;
    private string updatedBy;
    private string lastUpdated;
    public Address(int houseNumber, string street, string cityCounty, string stateAbb,
        string countryAbb, string zip, string updatedBy, string lastUpdated)
    {
        SetHouseNumber(houseNumber);
        SetStreet(street);
        SetCityCounty(cityCounty);
        SetStateAbb(stateAbb);
        SetCountryAbb(countryAbb);
        SetZip(zip);
        SetUpdatedBy(updatedBy);
        SetLastUpdated(lastUpdated);
    }

    public int GetAddressId()
    {
        return this.addressID = nextID++;
    }
    public void SetHouseNumber(int houseNumber)
    {
        this.houseNumber = houseNumber;
    }

    public int GetHouseNumber()
    {
        return this.houseNumber;
    }

    public void SetStreet(string street)
    {
        this.street = street;
    }

    public string GetStreet()
    {
        return this.street;
    }

    public void SetCityCounty(string cityCounty)
    {
        this.cityCounty = cityCounty;
    }

    public string GetCityCounty()
    {
        return this.cityCounty;
    }

    public void SetStateAbb(string stateAbb)
    {
        this.stateAbb = stateAbb;
    }

    public string GetStateAbb()
    {
        return this.stateAbb;
    }

    public void SetCountryAbb(string countryAbb)
    {
        this.countryAbb = countryAbb.ToUpper();
    }

    public string GetCountryAbb()
    {
        return this.countryAbb;
    }

    public void SetZip(string zip)
    {
        this.zip = zip;
    }

    public string GetZip()
    {
        return this.zip;
    }

    public void SetUpdatedBy(string updatedBy)
    {
        this.updatedBy = updatedBy;
    }

    public string GetUpdatedBy()
    {
        return this.updatedBy;
    }

    public void SetLastUpdated(string lastUpdated)
    {
        this.lastUpdated = lastUpdated;
    }

    public string GetLastUpdated()
    {
        return this.lastUpdated;
    }
}