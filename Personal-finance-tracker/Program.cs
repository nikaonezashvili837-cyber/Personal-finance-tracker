using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
namespace PersonalFinanceTracker
{
    partial class Program
    {
        public static void Main()
        {
            try
            {
                bool mainLoop = true;
                while (mainLoop)
                {
                    Console.WriteLine("===== Personal Finance Tracker =====\n" +
                "1. Add Transaction\n" +
                "2. View All Transactions\n" +
                "3. View Summary\n" +
                "4. Filter Transactions\n" +
                "5. Save Data\n" +
                "6. Load Data\n" +
                "7. Exit\n" +
                "====================================\n" +
                "Please choose an option (1-7):");
                    byte MenuOption = Convert.ToByte(Console.ReadLine());
                    switch (MenuOption)
                    {
                        case 1:
                            AddExpense();
                            break;
                        case 2:
                           ViewTransactions();
                           break;
                        case 7:
                            mainLoop = false;
                            break;
                    }
                    MenuOption = 8;
                }
            }
            catch
            {
                Console.WriteLine("Error");
            }
        }
        public static void ViewTransactions()
        {
            string jsonContent = File.ReadAllText("expenses.json");
            if(jsonContent == "")
            {
                Console.WriteLine("No transactions present");
                return;
            }
            Console.WriteLine(jsonContent);
        }
    }
}