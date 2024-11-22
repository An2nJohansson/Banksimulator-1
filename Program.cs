using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banksimulator_1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // Deklaration av variabler med datatypen double och int för inmatade värden. vissa har Värde 0 tills användare matat in värden.
            double deposit = 0;
            double withdraw = 0;
            double balance = 0;
            double yearly_deposit;
            double interest_rate;
            double total_savings = 0;
            int qty_year;
            int year = 1;


            Console.WriteLine("_______________________________");
            Console.WriteLine("Välkommen till ditt Bankkonto");
            Console.WriteLine("_______________________________");

           
            // Meny med iteration while för att skapa en loop så att programmet kör tills användare avslutar med [A].
           
            string choice;

            while (true)
            {
                Console.WriteLine("Meny");

                Console.WriteLine("[I]nsättning");

                Console.WriteLine("[U]ttag");

                Console.WriteLine("[S]aldo");

                Console.WriteLine("[R]äntebetalning");

                Console.WriteLine("[A]vsluta");

                Console.WriteLine("Ange ditt val [I], [U], [S], [R] eller [A]");


                // Selektion switch för att det kan bli många olika utfall.

                choice = Console.ReadLine().ToUpper(); // Konverterar till stor bokstav så att man kan använda både stor och liten.
                switch (choice)
                {
                    case "I":
                        Console.WriteLine("Ange insättning i kr (ex. 100): ");
                        deposit = Double.Parse(Console.ReadLine()); //skriver till variabeln deposit.
                        //frågar efter användarens insättning.
                        balance += deposit; // Adderar insättningen till saldot.
                        Console.WriteLine("Din insättning är mottagen, nytt saldo: " + deposit);
                        break;

                    case "U":
                        Console.WriteLine("Ange önskat uttag i kr (ex.100): ");
                        withdraw = Double.Parse(Console.ReadLine()); //skriver till variabeln withdraw.
                        if (withdraw <= balance) // if else för att kontrollera att uttag är mindre eller lika med saldo.
                        {
                            balance -= withdraw; //subtrahera uttaget från saldot.
                            Console.WriteLine("Uttag lyckades, nytt saldo: " + balance);
                        }
                        else 
                        {
                            Console.WriteLine("Otillräckligt saldo för uttag.");
                        }
                        break;
                    
                    case "S":
                        Console.WriteLine("Ditt nuvarande saldo är: " + balance);
                        break;
                    
                    case "R":
                        Console.WriteLine("Här kan du se hur mycket önskat sparande kan växa efter x antal år med en viss ränta.");
                       
                        // do while loop som körs om till inmatat värde är större än 0.
                        do
                        {
                            Console.WriteLine("Skriv in årligt insättningsbelopp du tänkt spara ex.(15000), minsta insättning är 1kr: ");
                        }
                       while (!double.TryParse(Console.ReadLine(), out yearly_deposit) || yearly_deposit <= 0); //skriver till variabeln yearly_deposit om värdet > 0
 
                       do
                        {
                            Console.WriteLine("skriv in förväntad räntesats (avkastning) räknat i % ex.(7), minsta ränta är 1%: ");
                        }
                        while (!double.TryParse(Console.ReadLine(), out interest_rate) || interest_rate <= 0); //skriver till variabeln interest_rate om värdet > 0
                        
                       do
                        {
                            Console.WriteLine("Skriv in antal helår du tänkt spara, ex.(20),minsta antal år är 1 år: ");
                        }
                       while (!int.TryParse(Console.ReadLine(), out qty_year) || qty_year <= 0); //skriver till variabeln qty_year om värdet är > 0

                        //Ny do while loop för att beräkna sparande med ränta efter x antal år.
                        do
                        {
                            total_savings += yearly_deposit; //adderar årlig insättning

                            total_savings *= (1 + interest_rate / 100); //lägger till räntan, dividerar med 100 för att det ska räkna rätt när man multiplicerar räntan. Ex. 7% omvandlas till * 0,07.

                            year++; //öka årsräkningen med ett

                        } while (year <= qty_year); 

                        Console.WriteLine($"Efter {qty_year} år kommer ditt sparande att vara värt {total_savings:F2} kr"); //:F2 för att göra om till två decimaler.
                        


                        break;
                    
                    case "A":
                        Console.WriteLine("Du är utloggad, tryck på valfri knapp för att avsluta. Tack och välkommen åter!");
                        Console.ReadKey();
                        return; //programmet avslutas på användarens begäran.


                    default: //Ifall användaren matar in fel värde.
                        Console.WriteLine("Ogiltigt val, vänligen välj [I], [U], [S], [R] eller [A]");
                        break;


                }
            }

        }










    }
}   


