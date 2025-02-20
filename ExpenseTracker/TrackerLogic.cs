using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker
{
    public class TrackerLogic
    {
        public static List<double> expenses = new List<double>();

        public static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Expense Tracker");
            Console.WriteLine("***************************");
            Console.WriteLine("Created by Marc Moxey");

        }

        public static void  GetChoice()
        {
            while (true)
            {
                Console.WriteLine("\nExpense Tracker");
                Console.WriteLine("1. Add Expense");
                Console.WriteLine("2. Remove Expense");
                Console.WriteLine("3. View Expenses");
                Console.WriteLine("4. Get Total and Average Expense");
                Console.WriteLine("5. Filter Expenses");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        TrackerLogic.AddExpense();
                        break;
                    case "2":
                        TrackerLogic.RemoveExpense();
                        break;
                    case "3":
                        TrackerLogic.ViewExpenses();
                        break;
                    case "4":
                        TrackerLogic.GetTotalAndAverageExpense();
                        break;
                    case "5":
                        TrackerLogic.FilterExpenses();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option, please try again");
                        break;

                }
                

            }


        }

        public static void AddExpense()
        {
            Console.Write("Enter expense amount: ");
            if (double.TryParse(Console.ReadLine(), out double expense))
            {
                expenses.Add(expense);
                Console.WriteLine("Expense added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a numeric value.");
            }
        }

        public static void RemoveExpense()
        {
            ViewExpenses();
            Console.Write("Enter the index of expense to remove: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < expenses.Count)
            {
                expenses.RemoveAt(index);
                Console.WriteLine("Expense removed successfully.");
            }
            else
            {
                Console.WriteLine("Invalid index.");
            }
        }

        public static void ViewExpenses()
        {
            if (expenses.Count == 0)
            {
                Console.WriteLine("No expenses recorded.");
                return;
            }

            Console.WriteLine("\nExpenses List:");
            for (int i = 0; i < expenses.Count; i++)
            {
                Console.WriteLine($"{i}. {expenses[i]}");
            }
        }

        public static (double total, double average) GetTotalAndAverageExpense()
        {
            double total = expenses.Sum();
            double average = expenses.Count > 0 ? total / expenses.Count : 0;
            return (total, average);
        }

        public static void FilterExpenses()
        {
            Console.Write("Enter minimum amount to filter: ");
            if (double.TryParse(Console.ReadLine(), out double minAmount))
            {
                var filteredExpenses = expenses.Where(e => e >= minAmount).ToList();
                Console.WriteLine("Filtered Expenses:");
                foreach (var exp in filteredExpenses)
                {
                    Console.WriteLine(exp);
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }

        }
    }
}
