using System.Text.Json;
namespace PersonalFinanceTracker
{
    partial class Program
    {
        public static void ShowSummary()
        {
            string jsonContent = File.ReadAllText("transactions.json");
            List<Transaction>? totalTransactions = JsonSerializer.Deserialize<List<Transaction>>(jsonContent);
            float totalIncome = 0;
            float totalExpense = 0;
            foreach (var element in totalTransactions)
            {
                if (element.Type == "Income")
                {
                    totalIncome += element.Amount;
                }
                else
                {
                    totalExpense += element.Amount;
                }
            }
            Summary summary = new Summary(totalIncome, totalExpense);
            Console.WriteLine($"Income: {summary.Income}");
            Console.WriteLine($"Expenses: {summary.Expenses}");
            Console.WriteLine($"Balance: {summary.Balance}");
        }
        class Summary
        {
            public float Income { get; set; }
            public float Expenses { get; set; }
            public float Balance {get;set;}
            public Summary(float income, float expense)
            {
                this.Income = income;
                this.Expenses = expense;
                this.Balance = this.Income - this.Expenses;
            }
        }
    }
}