using System;
namespace PersonalFinanceTracker
{
    class Program
    {
        public static void Main()
        {
            List<string[]> AllExpenses = new List<string[]>();
            try
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
                      Console.WriteLine("do something");
                      break;
                    case 2:
                      Console.WriteLine("do something");
                      break;
                }
            }
            catch
            {
                Console.WriteLine("Error");
            }
        }
    }
}