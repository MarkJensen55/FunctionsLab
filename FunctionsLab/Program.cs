using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionsLab
{
    class Program
    {
        // expense appproval work flow program
        static void Main(string[] args)
        {
            // get the expense amount and description .
            bool validEntry = false;
            Decimal expenseAmt = 0.00m;
            string expenseString = null;
            string expenseDesc = null;



            while (validEntry == false)
            {
                Console.WriteLine("Enter your expense amount: ");
                expenseString = Console.ReadLine();

                validEntry = Decimal.TryParse(expenseString, out expenseAmt);
            }

            validEntry = false;

            while (validEntry == false)
            {
                Console.WriteLine("What is the expense for: ");
                expenseDesc = Console.ReadLine();
                if (expenseDesc != "")
                {
                    validEntry = true;
                }
            }    
            
            

            // Approval can be "Approved", "Rejected" or "Escalate"
            string approval = null;

            approval = ManagerTest(expenseAmt, expenseDesc);

            if (approval == "Escalate")
            {
                approval = Manager2Test(expenseAmt, expenseDesc);
            }
            if (approval == "Escalate")
            {
                approval = DirectorTest(expenseAmt, expenseDesc);
            }
            if (approval == "Escalate")
            {
                approval = CeoTest(expenseAmt, expenseDesc);
            }

            Console.WriteLine("Your expense is " + approval);
            Console.ReadLine();
        }

        private static string ManagerTest(decimal expenseAmt, string expenseDesc)
        {
            if (expenseAmt <= 250 && (!expenseDesc.ToUpper().Contains("ENTERTAINMENT")))
            {
                return "Approved";
            }
            else if (expenseDesc.ToUpper().Contains("ENTERTAINMENT"))
            {
                return "Rejected";
            }
            else 
            {
                return "Escalate";
            }
        }

        private static string Manager2Test(decimal expenseAmt, string expenseDesc)
        {
            if (expenseAmt <= 500 && (!expenseDesc.ToUpper().Contains("TOWNCAR")))
            {
                return "Approved";
            }
            else if (expenseDesc.ToUpper().Contains("TOWNCAR"))
            {
                return "Rejected";
            }
            else
            {
                return "Escalate";
            }
        }

        private static string DirectorTest(decimal expenseAmt, string expenseDesc)
        {
            if (expenseAmt <= 1000 && (!expenseDesc.ToUpper().Contains("HARDWARE")))
            {
                return "Approved";
            }
            else if (expenseAmt > 5000 && (expenseDesc.ToUpper().Contains("HARDWARE")))
            {
                return "Rejected";
            }
            else
            {
                return "Escalate";
            }
        }

        private static string CeoTest(decimal expenseAmt, string expenseDesc)
        {
            return "Approved";
        }
    }
}
