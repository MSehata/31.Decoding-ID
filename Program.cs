using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31.Decoding_ID
{
    internal class Program
    {
        static void Main(string[] args)
        {

            
            Console.Write("Please enter an ID number with the format YYMMDDSSSSCAZ: ");
            string idNumber = Console.ReadLine();

            //Validating the ID Number
            bool isValid = ValidateIDNumber(idNumber);
            Console.WriteLine("Is ID Number Valid: " + isValid);

            // Extracting components
            string birthDate = idNumber.Substring(0, 6);
            string genderDigit = idNumber.Substring(6, 1);
            string citizenshipStatus = idNumber.Substring(10, 1);

            // Determining gender
            string gender = (int.Parse(genderDigit) <= 4) ? "Female" : "Male";

            // Determine citizenship status
            string citizenship = (citizenshipStatus == "0") ? "SA Citizen" : "Permanent Resident";

            Console.WriteLine("Birth Date: " + birthDate);
            Console.WriteLine("Gender: " + gender);
            Console.WriteLine("Citizenship Status: " + citizenship);

            

            
        }

        static bool ValidateIDNumber(string idNumber)
        {
            int sum = 0;
            bool doubleDigit = false;

            for (int i = idNumber.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(idNumber[i].ToString());

                if (doubleDigit)
                {
                    digit *= 2;
                    if (digit > 9)
                        digit -= 9;
                }

                sum += digit;
                doubleDigit = !doubleDigit;
            }

            return (sum % 10 == 0);
        }
    }
}
