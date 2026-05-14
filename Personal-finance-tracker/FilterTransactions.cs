using System.Text.Json;
using System.Transactions;
namespace PersonalFinanceTracker
{
    partial class Program
    {
        public static void FilterTransactions(string filteringCriteria)
        {
            string jsonContent = File.ReadAllText("transactions.json");
            if (jsonContent.Length == 0)
            {
                Console.WriteLine("Nothing to show");
                return;
            }
            List<Transaction>? transactions = JsonSerializer.Deserialize<List<Transaction>>(jsonContent);
            List<Transaction> filteredTransactions = new List<Transaction>();
            foreach (Transaction element in transactions)
            {
                if (element.Category == filteringCriteria)
                {
                    filteredTransactions.Add(element);
                }
            }
            string filteredJson = JsonSerializer.Serialize(filteredTransactions, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("FilteredTransactions.json", filteredJson);
        }
    }
}