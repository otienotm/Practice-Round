using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// Tracy Otieno
/// Lab 3
/// Honor Code
public class Home : Policy
{
    private string exteriorType;
    private string alarm;
    private int distance;

    public Home(string effectiveDate, string terminationDate, double amount, int policyYear, string policyType,
        int insuredID, int addressID, string updatedBy, string lastUpdated, string exteriorType, string alarm, int distance)
        : base(effectiveDate, terminationDate, amount, policyYear, policyType, insuredID, addressID, updatedBy, lastUpdated)
    {
        SetExteriorType(exteriorType);
        SetAlarm(alarm);
        SetDistance(distance);
    }

    public void SetExteriorType(string type)
    {
        this.exteriorType = type;
    }

    public string GetExteriorType()
    {
        return this.exteriorType;
    }

    public void SetAlarm(string alarm)
    {
        this.alarm = alarm;
    }

    public string GetAlarm()
    {
        return this.alarm;
    }

    public void SetDistance(int distance)
    {
        this.distance = distance;
    }

    public int GetDistance()
    {
        return this.distance;
    }
}