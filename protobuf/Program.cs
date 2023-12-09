﻿using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Course.Protobuf.Test;

Console.WriteLine("Welcome to Protobuf test!");
var emp = new Employee();
emp.FirstName = "Ahmed";
emp.LastName = "Morshedy";
emp.IsRetired = false;
var birthdate = new DateTime(1976,7,9);
birthdate=DateTime.SpecifyKind(birthdate,DateTimeKind.Utc);
emp.BirthDate = Timestamp.FromDateTime(birthdate);
emp.Age = 20;
emp.MaritalStatus = Employee.Types.MaritalStatus.Single;
emp.PreviousEmployers.Add("Microsoft");
emp.PreviousEmployers.Add("HP");
emp.CurrentAddress = new Address();
emp.CurrentAddress.City = "New York";
emp.CurrentAddress.StreetName = "5th Avenue";
emp.CurrentAddress.HouseNumber = 42;
emp.Relatives.Add("Father","AAAAAAA");
emp.Relatives.Add("mother","MMMMMMM");

using(var output = File.Create("emp.dat"))
{
    emp.WriteTo(output);
}

Employee empFromFile;
using(var input = File.OpenRead("emp.dat"))
{
    empFromFile = Employee.Parser.ParseFrom(input);
}

Console.WriteLine("Protobuf test complete :-");