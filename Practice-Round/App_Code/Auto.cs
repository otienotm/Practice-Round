using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// Tracy Otieno
/// Lab 3
/// Honor code
public class Auto : Policy
{
    private string vinNumber;
    private string make;
    private string model;
    private int miles;

    public Auto(string effectiveDate, string terminationDate, double amount, int policyYear, string policyType,
        int insuredID, int addressID, string updatedBy, string lastUpdated, string vinNumber, string make, string model, int miles) 
        : base(effectiveDate, terminationDate, amount, policyYear, policyType, insuredID, addressID, updatedBy, lastUpdated)
    {
        SetVinNumber(vinNumber);
        SetMake(make);
        SetModel(model);
        SetMiles(miles);
    }

    public void SetVinNumber(String vinNumber)
    {
        this.vinNumber = vinNumber;
    }

    public String GetVinNumber()
    {
        return this.vinNumber;
    }

    public void SetMake(String make)
    {
        this.make = make;
    }

    public String GetMake()
    {
        return this.make;
    }

    public void SetModel(String model)
    {
        this.model = model;
    }

    public String GetModel()
    {
        return this.model;
    }

    public void SetMiles(int miles)
    {
        this.miles = miles;
    }

    public int GetMiles()
    {
        return this.miles;
    }
}