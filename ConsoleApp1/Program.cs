using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Account> Ledger = new List<Account>();
            List<Invoice_Controll> InvList = new List<Invoice_Controll>();
            var Reent = 0;

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
                try // try used as to avoid unwanted input
                {
                    Reent = int.Parse(Console.ReadLine());
                }
                    catch (Exception e) {
                        Console.WriteLine(e.Message);
                    }
                switch (Reent)
                {
                    case 1:
                        String Acc = "";
                        Reent = 0;
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
                        Reent = 0;
                        Boolean flag = false;
                        Console.WriteLine("Please input the customer number:");
                        String AccSearch = Console.ReadLine();
                        AccSearch += ".txt";

                        try
                        {
                            // Open the text file using a stream reader.
                            using (var InvFile = new StreamReader(AccSearch))
                            {
                                while (InvFile.EndOfStream != true)
                                {
                                    String tests = InvFile.ReadLine();
                                    string[] subss = tests.Split(',');
                                    InvList.Add(new Invoice_Controll(int.Parse(subss[0]), int.Parse(subss[1]), int.Parse(subss[2])));
                                }
                            }
                            flag = true;
                            for (int i = 0; i != InvList.Count; i++)
                            {
                                Console.WriteLine("Invoice Number:" + InvList[i].InvNumber + " | " + "Original Amount: $" + InvList[i].Inv_Orig_Amount + " | " + "Remainging Amount: $" + InvList[i].Inv_Rem_Amount);
                            }
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine("The file could not be read:");
                            Console.WriteLine(e.Message);
                        } // No file with that name

                        if (flag == true)
                        {
                            Console.WriteLine("\n" + "Would you like to pay an invoice on account " + AccSearch.Remove(6) + "[Y/N]");
                            String Response = Console.ReadLine();
                            Response = Response.ToUpper();
                            if(Response == "Y")
                            {
                                Console.WriteLine("Please input the invoice number");
                                int InvSearch = int.Parse(Console.ReadLine());

                                for (int i = 0; i != InvList.Count; i++)
                                {
                                    if (InvList[i].InvNumber == InvSearch)
                                    {
                                        InvList[i].Inv_Rem_Amount = 0;
                                    }
                                }
                                using (StreamWriter writer = new StreamWriter(AccSearch))
                                {
                                    for (int i = 0; i != InvList.Count; i++) {
                                        writer.WriteLine(InvList[i].InvNumber + "," + InvList[i].Inv_Orig_Amount + "," + InvList[i].Inv_Rem_Amount);
                                    }
                                }
                            }
                        }

                        break;

                    case 3:
                        System.Environment.Exit(1);
                        break;

                    default:
                        Console.WriteLine("Invalid input");
                        Reent = 0;
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

public class Invoice_Controll
{
    public int InvNumber;
    public int Inv_Orig_Amount;
    public int Inv_Rem_Amount;

    public Invoice_Controll(int InvNumber,int Inv_Orig_Amount,int Inv_Rem_Amount)
    {
        this.InvNumber = InvNumber;
        this.Inv_Orig_Amount = Inv_Orig_Amount;
        this.Inv_Rem_Amount = Inv_Rem_Amount;

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