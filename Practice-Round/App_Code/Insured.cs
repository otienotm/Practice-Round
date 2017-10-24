using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// Tracy Otieno
/// Lab 3
/// Honor Code
public class Insured
{
    private string firstName;
    private string lastName;
    private char middle;
    private string dateOfBirth;
    private int creditScore;
    private int addressID;
    private string driverLicense;
    private string updatedBy;
    private string lastUpdated;

    public Insured(string firstName, string lastName, string middle,
        string dateOfBirth, int creditScore, int addressID, string driverLicense,
        string updatedBy, string lastUpdated)
    {
        SetFirstName(firstName);
        SetLastName(lastName);
        SetMiddle(middle);
        SetDOB(dateOfBirth);
        SetCreditScore(creditScore);
        SetAddressID(addressID);
        SetDriversLicense(driverLicense);
        SetUpdatedBy(updatedBy);
        SetLastUpdated(lastUpdated);
    }

    public void SetFirstName(string firstName)
    {
        this.firstName = firstName;
    }
    public string GetFirstName()
    {
        return this.firstName;
    }

    public void SetLastName(string lastName)
    {
        this.lastName = lastName;
    }

    public string GetLastName()
    {
        return this.lastName;
    }

    public void SetMiddle(string middle)
    {
        if (middle != string.Empty)
            this.middle = middle[0];
    }

    public char GetMiddle()
    {
        return this.middle;
    }

    public void SetDOB(string DOB)
    {
        this.dateOfBirth = DOB;
    }

    public string GetDOB()
    {
        return this.dateOfBirth;
    }

    public void SetCreditScore(int creditScore)
    {
        this.creditScore = creditScore;
    }

    public int GetCreditScore()
    {
        return this.creditScore;
    }

    public void SetAddressID(int addressID)
    {
        this.addressID = addressID;
    }

    public int GetAddressID()
    {
        return this.addressID;
    }

    public void SetDriversLicense(string driverLicense)
    {
        this.driverLicense = driverLicense;
    }

    public string GetDriversLicense()
    {
        return this.driverLicense;
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