﻿using System.Linq;
using System.Collections.Generic;
using System;

namespace Assignment;
public class Person(string firstName, string lastName, IAddress address, string emailAddress) : IPerson
{
    public static Person FromCsvRow(string row)
    {
        ArgumentException.ThrowIfNullOrEmpty(row);
        string[] columns = row.Split(',');
        if(columns.Length != 8)
        {
            throw new Exception($"Row requires 8 columns, got {columns.Length} columns");
        }
        return new(columns[1], columns[2],
            new Address(columns[4], columns[5], columns[6], columns[7]),
            columns[3]);
    }

    public void Deconstruct(out string FirstName, out string LastName, out string EmailAddress,
        out string StreetAddress, out string City, out string State, out string Zip)
    {
        FirstName = this.FirstName;
        LastName = this.LastName;
        EmailAddress = this.EmailAddress;
        StreetAddress = Address.StreetAddress;
        City = Address.City;
        State = Address.State;
        Zip = Address.Zip;
    }

    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public IAddress Address { get; set; } = address;
    public string EmailAddress { get; set; } = emailAddress;
}
