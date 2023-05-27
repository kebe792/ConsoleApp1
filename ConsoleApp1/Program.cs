using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] Invoice = new int[5];
            List<Account> Ledger = new List<Account>();
            int Reent = 0;

            //testing respository
            //testing this again

            try
            {
                // Open the text file using a stream reader.
                using (var File = new StreamReader("AccountsDetails.txt"))
                {
                    // Read the stream as a string, and write the string to the console.

                    while (File.EndOfStream != true)
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



            while (Reent != 3)
            {
                Screen.Mainscreen();

                String Entry = Console.ReadLine();
                Reent = Convert.ToInt32(Entry);

                switch (Reent)
                {
                    case 1:
                        String Acc = "";

                        while (Acc != "Q")
                        {
                            Console.WriteLine("Please input the customer number or Q to quit:");
                            Acc = Console.ReadLine();
                            Acc = Acc.ToUpper();

                            if (Acc == "Q")
                            {
                                break;
                            }
                            else
                            {
                                try
                                {
                                    for (int i = 0; i != Ledger.Count; i++)
                                    {

                                        if (String.Compare(Acc, Ledger[i].AccNumber) == 0)
                                        {
                                            Console.WriteLine(Ledger[i].AccName + "\n" + Ledger[i].AccNumber + "\n" + Ledger[i].Address + "\n" + Ledger[i].EmailAdd + "\n" + Ledger[i].PhoneNum);
                                            Acc = null;
                                            Console.WriteLine("");
                                            break;
                                        }
                                        if (i == Ledger.Count - 1)
                                        {
                                            Console.WriteLine("That is not a valid account number..");
                                        }
                                    }
                                }
                                catch { }
                            }
                        }
                        break;

                    case 2:

                        Console.WriteLine("Please input the customer number:");




                        break;

                    case 3:
                        System.Environment.Exit(1);
                        break;

                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }


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
        Console.WriteLine("2. Invoice List");
        Console.WriteLine("3. End Program");
        Console.WriteLine("Entry: ");
        return;
    }

}