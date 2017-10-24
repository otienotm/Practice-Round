using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// Tracy Otieno
/// Lab 3
/// Honor Code
public class Policy
{
    private string effectiveDate;
    private string terminationDate;
    private double amount;
    private int policyYear;
    private char policyType;
    private int insuredID;
    private int addressID;
    private string updatedBy;
    private string lastUpdated;

    public Policy(string effectiveDate, string terminationDate, double amount, int policyYear, string policyType,
        int insuredID, int addressID, string updatedBy, string lastUpdated)
    {
        SetEffectiveDate(effectiveDate);
        SetTerminationDate(terminationDate);
        SetAmount(amount);
        SetPolicyYear(policyYear);
        SetPolicyType(policyType);
        SetInsuredID(insuredID);
        SetAddressID(addressID);
        SetUpdatedBy(updatedBy);
        SetLastUpdated(lastUpdated);

    }
    public void SetEffectiveDate(string effectiveDate)
    {
        this.effectiveDate = effectiveDate;
    }

    public string GetEffectiveDate()
    {
        return this.effectiveDate;
    }

    public void SetTerminationDate(string terminationDate)
    {
        this.terminationDate = terminationDate;
    }

    public string GetTerminationDate()
    {
        return this.terminationDate;
    }

    public void SetAmount(double amount)
    {
        this.amount = amount;
    }

    public double GetAmount()
    {
        return this.amount;
    }

    public void SetPolicyYear(int policyYear)
    {
        this.policyYear = policyYear;
    }

    public int GetPolicyYear()
    {
        return this.policyYear;
    }

    public void SetInsuredID(int insuredID)
    {
        this.insuredID = insuredID;
    }

    public int GetInsuredID()
    {
        return this.insuredID;
    }

    public void SetAddressID(int addressID)
    {
        this.addressID = addressID;
    }

    public int GetAddressID()
    {
        return this.addressID;
    }

    public void SetPolicyType(string policyType)
    {
        this.policyType = policyType[0];
    }

    public char GetPolicyType()
    {
        return this.policyType;
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