using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Transactions;
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
                "4. Filter Transactions By Category\n" +
                "5. Exit\n" +
                "====================================\n" +
                "Please choose an option (1-5):");
                    byte MenuOption = Convert.ToByte(Console.ReadLine());
                    switch (MenuOption)
                    {
                        case 1:
                            AddExpense();
                            break;
                        case 2:
                            ViewTransactions();
                            break;
                        case 3:
                            ShowSummary();
                            break;
                        case 4:
                           Console.WriteLine("Enter filtering criteria:");
                           string? filteringCriteria = Console.ReadLine();
                           FilterTransactions(filteringCriteria);
                           break;
                        case 5:
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
            if (jsonContent == "")
            {
                Console.WriteLine("No transactions present");
                return;
            }
            Console.WriteLine(jsonContent);
        }
    }
}