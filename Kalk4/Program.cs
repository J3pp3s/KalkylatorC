using System;
using System.Collections.Generic;

namespace Kalk4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ger konsollen gul text och ger konsollen en grå bakgrundsfärg
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();

            bool förstaLoop = true; //Ska kolla om det är första loopen, för att då hälsa användaren välkommen till miniräknaren
            string again = "ja"; //Skapar en string där ifall användaren skriver "ja" används även en while-loop som isådanafall körs
            List<string> historik = new List<string>();//Skapar en lista för att samla historik av tidigare uträkningar

            while (again == "ja")
            {
                //num1 och num2 är de tal användaren skriver i konsollen
                //total är variabeln för slutsiffran
                //char op används med if-satsen för att ta reda på operatoren
                double num1;
                double num2;
                double total;
                string oper = "+";

                //En if-sats som ska hälsa användare välkommen, såvida det är allra första loopen, annars rensas hela konsollen
                if (förstaLoop)
                {
                    Console.WriteLine("Välkommen till en spännande miniräknare!\n");
                    förstaLoop = false;
                }
                else
                {
                    Console.Clear(); //Rensar tidigare uträkningarna ifall detta inte är det första varvet  
                }

                //Kollar om historiken är helt tom eller inte
                //Om det finns historik så skrivs den också ut genom foreach
                if (historik.Count != 0)
                {
                    Console.WriteLine("Tidigare uträkningar: \n");
                    foreach (string s in historik)
                    {
                        Console.WriteLine(s);
                    }
                    Console.WriteLine("");
                }

                //Ber användare ange det första talet och konverterar inmatning till double 
                Console.WriteLine("Ange det första talet: ");
                num1 = Convert.ToDouble(Console.ReadLine());

                //Ber användare ange operator 
                //Konverterar användarens inmatning till string
                Console.WriteLine("Ange operator ( + - * / ): ");
                oper = Convert.ToString(Console.ReadLine());

                //Kollar om användare anger texten "MARCUS" istället för en operator
                if (oper == "MARCUS")
                {
                    Console.WriteLine("Hej!");
                    Console.ReadKey();
                    break;

                }

                //Ber användare ange det andra talet och konverterar inmatning till double
                Console.WriteLine("Ange det andra talet: ");
                num2 = Convert.ToDouble(Console.ReadLine());

                //Skapar en string för uträkning som sedan används till listan för historiken
                string uträkning;

                //Användare tillåts ange operator + - * / 
                //Tar sedan reda på vilket tecken som angavs genom en if-sats
                //Ifall användare skriver "MARCUS" skrivs texten "Hej!" ut och programmet avslutas
                if (oper == "+")
                {
                    total = num1 + num2;
                    uträkning = string.Format("{0} + {1} = {2}", num1, num2, total);
                    historik.Add(uträkning);
                    Console.WriteLine("\nDitt svar blir " + total);
                }
                else if (oper == "-")
                {
                    total = num1 - num2;
                    uträkning = string.Format("{0} - {1} = {2}", num1, num2, total);
                    historik.Add(uträkning);
                    Console.WriteLine("\nDitt svar blir " + total);
                }
                else if (oper == "*")
                {
                    total = num1 * num2;
                    uträkning = string.Format("{0} * {1} = {2}", num1, num2, total);
                    historik.Add(uträkning);
                    Console.WriteLine("\nDitt svar blir " + total);
                }
                else if (oper == "/")
                {
                    while (num2 == 0)
                    {   //Använder while-loop för att påpeka att det inte går att dividera med 0, användare får ett nytt försök på sig
                        Console.WriteLine("Det går inte att dividera med 0. Ange ett annat andratal");
                        num2 = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    total = num1 / num2;
                    uträkning = string.Format("{0} / {1} = {2}", num1, num2, total);
                    historik.Add(uträkning);
                    Console.WriteLine("\nDitt svar blir " + total);
                }
                else
                {
                    Console.WriteLine("Ogiltlig operator");
                }

                //Frågar om användare vill påbörja en ny ekvation
                //Kopplar svaret till stringen "again" och den while-loop som återfinns i kodens allra översta rader
                Console.WriteLine("\nVill du prova igen? Skriv (ja) annars tryck på valfri tangent för att avsluta");
                again = Convert.ToString(Console.ReadLine());

            }
        }
    }
}
