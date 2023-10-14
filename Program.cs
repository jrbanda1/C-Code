/*
 * Jose Roberto Banda
 * A00207755
 * CITP 4350
 * Assignment #2
 * 
 * Create a Class named Taxpayer that contains
 * Social Security number (as a string)
 * yearlyGrossIncome
 * tax owed 
 * totalTaxAmt (static variable)
 * 
 * includes the properties get and set for the first 2 data fields
 * make tax owed a read-only property.
 * the tax should be calculated whenever the income is set
 * Assume tax is 15% for <30000 & 28% for >= 30000
 * after tax is calculated is added into the totalTaxAmt
 * 
 * Write main Function that prompts user to enter the number of Taxpayer
 * creates a dynamic array of the Taxpayer objects
 * Prompt user for the data for each object and display the total tax amount
 * 
 * Write a main function that compare each object based on tax owed; then display the objects
 * in order by the amount tax owed.
 * 
 * Save program as TaxPayerDemo.cs
 */


using System;

// Create a class named Taxpayer
public class Taxpayer
{
    // Data fields for Taxpayer class
    private string socialSecurityNumber; // Social Security number (read as string not number )
    private double yearlyGrossIncome; // Yearly gross income
    private double taxOwed; // Tax owed
    private static double totalTaxAmt = 0; // Total tax amount (static variable)

    // use get and set for the first two data fields
    public string SocialSecurityNumber
    {
        get { return socialSecurityNumber; }
        set { socialSecurityNumber = value; }
    }

    public double YearlyGrossIncome
    {
        get { return yearlyGrossIncome; }
        set
        {
            yearlyGrossIncome = value;
            // Calculate the tax owed 
            if (yearlyGrossIncome < 30000)
            {
                taxOwed = yearlyGrossIncome * 0.15; // below 30000
            }
            else
            {
                taxOwed = yearlyGrossIncome * 0.28; // 30000 and up 
            }
            // Add the tax owed into totalTaxAmt
            totalTaxAmt += taxOwed;
        }
    }

    // tax owed 
    public double TaxOwed
    {
        get { return taxOwed; }
    }

    // Get the total tax amount 
    public static double TotalTaxAmt
    {
        get { return totalTaxAmt; }
    }
}
// Write a main function that prompts user to enter the number of Taxpayer and creates a dynamic array of the Taxpayer objects
class TaxPayerDemo
{
    // grab the taxpayers and put them in order 
    static void DisplayByTaxOwed(Taxpayer[] taxpayers)
    {
        Console.WriteLine("The taxpayers in order by the amount of tax owed are:");
        // sort the taxpayers
        for (int i = 0; i < taxpayers.Length - 1; i++)
        {
            for (int j = i + 1; j < taxpayers.Length; j++)
            {
                if (taxpayers[i].TaxOwed > taxpayers[j].TaxOwed) // Compare the tax owed values of two taxpayers
                {
                    // Swap the two taxpayers in the array
                    Taxpayer temp = taxpayers[i];
                    taxpayers[i] = taxpayers[j];
                    taxpayers[j] = temp;
                }
            }
        }
        // Loop to display the sorted taxpayer list
        for (int i = 0; i < taxpayers.Length; i++)
        {
            Console.Write("SSN \t\t Income\t\t Tax Owed\n");
            Console.WriteLine(taxpayers[i].SocialSecurityNumber + "\t$" + taxpayers[i].YearlyGrossIncome + "\t\t$" + taxpayers[i].TaxOwed + "\n");
        }
    }
    static void Main()
    {
        Console.WriteLine("How many taxpayers do you want to enter?");
        int n = int.Parse(Console.ReadLine()); // Get the number of taxpayers from user input
        Console.WriteLine("*********************************************************\n");
        Taxpayer[] taxpayers = new Taxpayer[n]; // Create a dynamic array of the Taxpayer objects

        // Prompt the user for data 
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Enter the data for taxpayer " + (i + 1)); // Make it easier for a normal user to read
            taxpayers[i] = new Taxpayer(); // Create a new Taxpayer object
            Console.WriteLine("Enter the Social Security number (without dashes):");
            taxpayers[i].SocialSecurityNumber = Console.ReadLine(); // Set the Social Security number from user input
            Console.WriteLine("Enter the yearly gross income:");
            taxpayers[i].YearlyGrossIncome = double.Parse(Console.ReadLine()); // Set the yearly gross income from user input
            Console.WriteLine("*****************************************************\n" );
        }

        // Display total tax amount
        Console.WriteLine("\nThe total tax amount for all taxpayers is $" + Taxpayer.TotalTaxAmt +":\n");

        // Call a function to sort and display the taxpayers
        DisplayByTaxOwed(taxpayers);

        // Adding a pause to the program when displaying 
        Console.WriteLine("Press Enter to continue...");
        Console.ReadKey();

    }
    
}