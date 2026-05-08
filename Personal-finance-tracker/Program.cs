using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
namespace PersonalFinanceTracker
{
    class Program
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
        public static void AddExpense()
        {
            string jsonFile = File.ReadAllText("expenses.json");
            List<Transaction> transactions = new List<Transaction>();
            Console.WriteLine("Enter amount");
            float trasactionAmount = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter type of transaction");
            string? transactionType = Console.ReadLine();
            Console.WriteLine("Enter category of transaction");
            string? transactionCategory = Console.ReadLine();
            if (transactionType == null || transactionCategory == null)
            {
                Console.WriteLine("error");
                return;
            }
            if (transactionType != "Expense" && transactionType != "Income")
            {
                Console.WriteLine("Enter valid transaction type");
                return;
            }
            Transaction transactioneObject = new Transaction(trasactionAmount, transactionType, transactionCategory);
            string json;
            if (jsonFile == "")
            {
                transactions.Add(transactioneObject);
                json = JsonSerializer.Serialize(transactions, new JsonSerializerOptions { WriteIndented = true });
            }
            else
            {
                List<Transaction>? transactionsData = JsonSerializer.Deserialize<List<Transaction>>(jsonFile);
                transactionsData.Add(transactioneObject);
                json = JsonSerializer.Serialize(transactionsData, new JsonSerializerOptions { WriteIndented = true });
            }
            File.WriteAllText("expenses.json", json);
            return;
        }
    }
    class Transaction
    {

        public float Amount { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public Transaction(float amount, string type, string category)
        {
            Amount = amount;
            Type = type;
            Category = category;
        }
    }
}