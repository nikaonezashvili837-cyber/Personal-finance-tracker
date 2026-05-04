using System;
namespace PersonalFinanceTracker
{
    class Program
    {
        public static void Main()
        {
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
            }
            catch
            {
                Console.WriteLine("Error");
            }
        }
        public static void AddExpense()
        {
            Console.WriteLine("Enter amount");
            float expenseAmount = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter type of expense");
            string? expenseType = Console.ReadLine();
            Console.WriteLine("Enter category");
            string? expenseCategory = Console.ReadLine();
            if (expenseType == null || expenseCategory == null)
            {
                Console.WriteLine("error");
                return;
            }
            Expense expenseobject = new Expense();
            expenseobject.amount = expenseAmount;
            expenseobject.type = expenseType;
            expenseobject.category = expenseCategory;
            Console.WriteLine(expenseobject.amount);
        }
    }
    class Expense
    {
        public float amount;
        public string type = "";
        public string category = "";
    }
}