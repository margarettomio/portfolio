using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class MainClass
{
    public static void Main()
    {
        while (true)
        {
            string strings = Console.ReadLine();
            if (strings.Equals("end"))
                break;
            var vvod = strings.Split(' ');

            string symbUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string symbLower = "abcdefghijklmnopqrstuvwxyz";
            string symbDigits = "0123456789";

            if (vvod.Length == 3)
            {
                string name = vvod[0];
                string password = vvod[1];
                string email = vvod[2];

                if (!string.IsNullOrWhiteSpace(name) && name.Length >= 4
                    && !string.IsNullOrWhiteSpace(password) && password.Length >= 6 && password.Any(symbol => symbUpper.Contains(symbol))
                    && password.Any(symbol => symbLower.Contains(symbol)) && password.Any(symbol => symbDigits.Contains(symbol)))
                {
                    Regex rgx = new Regex(@"^[-\w.]+@([A-Za-z0-9][-A-Za-z0-9]+\.)+[A-Za-z]{2,4}$"); //регулярное выражение для email
                   if (rgx.IsMatch(email) && NoobDb.SearchByEmail(email) == null)
                    {
                        NoobDb.Add(new Account(name, password, email));
                    }
                }
            }
        }
        NoobDb.PrintAll();
    }
}