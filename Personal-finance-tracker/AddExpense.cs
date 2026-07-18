using System.Text.Json;
namespace PersonalFinanceTracker
{
    partial class Program
    {
        public static void AddExpense()
        {
            string jsonFile = File.ReadAllText("transactions.json");
            List<Transaction> transactions = new List<Transaction>();
            Console.WriteLine("Enter amount");
            float trasactionAmount;
            string? transactionInput = Console.ReadLine();
            if (transactionInput != null)
            {
                trasactionAmount = float.Parse(transactionInput);
            }
            else
            {
                Console.WriteLine("error");
                return;
            }
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
                transactionsData?.Add(transactioneObject);
                json = JsonSerializer.Serialize(transactionsData, new JsonSerializerOptions { WriteIndented = true });
            }
            File.WriteAllText("transactions.json", json);
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