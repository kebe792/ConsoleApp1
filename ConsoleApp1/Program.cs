using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool End = false, Flag = false;
            Random rnd = new Random();
            int[] Invoice = new int[5];
            List<Account> Ledger = new List<Account>();

            try
            {
                // Open the text file using a stream reader.
                using (var File = new StreamReader("AccountsDetails.txt"))
                {
                    // Read the stream as a string, and write the string to the console.
                    for (int i = 0; i != 15; i++)
                    {
                        String test = File.ReadLine();
                        string[] subs = test.Split(',');
                        Ledger.Add(new Account(subs[0], subs[1], subs[2], subs[3], subs[4], int.Parse(subs[5])));

                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            } // Import Customer Information


            Screen.Mainscreen();






        }
    }

}


public class Account
{

    public String AccName;
    public String AccNumber;
    public String Address;
    public String PhoneNum;
    public String EmailAdd;
    public int Creditlimit;
    public Account(String accname, String accnumber, String adress, String NumPhone, String AddEmail, int LimitCredit)
    {
        this.AccName = accname;
        this.AccNumber = accnumber;
        this.Address = adress;
        this.PhoneNum = NumPhone;
        this.EmailAdd = AddEmail;
        this.Creditlimit = LimitCredit;
    }

}

public class Screen
{
    public static void Mainscreen()
    {
        Console.WriteLine("1. Account Information");
        Console.WriteLine("1. Invoice List");

        return;
    }



}