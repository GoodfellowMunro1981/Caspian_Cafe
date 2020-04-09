using System;
using Caspian_Cafe.Services;
using Caspian_Cafe.Validations;

namespace Caspian_Cafe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var validationResults = new ValidationResults();
            var totalCost = MenuService.ProcessOrder(args, validationResults);

            Console.WriteLine(totalCost);
        }
    }
}
