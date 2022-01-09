using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace VendingMachine
{
    class Program
    {

        static void Main(string[] args)
        {
            int moneyPool = 0;
            Product[] items = { new Kexchoklad(), new Marabou(), new Fanta() };
            List<Product> cart = new List<Product>();


            Console.WriteLine("Välkommen till Vending Machine. Välj något av följande alternativ:");
            while (true)
            {
                Console.WriteLine("\n1-Lägg in pengar. \n2-Köp varor. \n3-Visa inventory och använd produkter. \n4-Mata ut resterande pengar.");


                int[] money = { 1, 5, 10, 20, 50, 100, 200, 500, 1000 };

                int option = Convert.ToInt32(Console.ReadLine());


                if (option == 1)
                {

                    while (true)
                    {
                        Console.WriteLine("Mata in pengar i maskinen (1, 5, 10, 20, 50, 100, 200, 500 eller 1000 kr). Skriv in 0 för att gå vidare.");

                        int input = Convert.ToInt32(Console.ReadLine());

                        if (money.Contains(input))
                        {

                            moneyPool = moneyPool + input;

                            Console.WriteLine("Inmatad summa: " + moneyPool);
                        }
                        else if (input == 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Mata in existerande valuta-sedlar eller mynt som visas ovanför.");
                        }

                    }
                }

                else if (option == 2)
                {

                    while (true)
                    {


                        Console.WriteLine("Du har totalt: " + moneyPool + " kr. \n Var vänlig och välj vad du vill köpa: \n 1: Kexchoklad - 10kr \n 2: Marabou - 15kr \n 3: Fanta - 20kr \n Tryck 0 för att gå tillbaka. ");
                        string choice = Console.ReadLine();

                        if (choice == "1")
                        {
                            Console.WriteLine("Hur många vill du ha? ");
                            int amount = Convert.ToInt32(Console.ReadLine());

                            int KexchokladPrice = items[0].GetPrice();
                            int total = KexchokladPrice * amount;
                            if (moneyPool >= total)
                            {
                                moneyPool = moneyPool - total;
                                for (int i = 0; i < amount; i++)
                                {
                                    cart.Add(items[0]);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Du har inte tillräckligt med pengar för att köpa detta. Var vänlig mata in mer pengar eller välj ett lägre antal.");
                            }
                        }
                        else if (choice == "2")
                        {
                            Console.WriteLine("Hur många vill du ha? ");
                            int amount = Convert.ToInt32(Console.ReadLine());

                            int MarabouPrice = items[1].GetPrice();
                            int total = MarabouPrice * amount;
                            if (moneyPool >= total)
                            {
                                moneyPool = moneyPool - total;
                                for (int i = 0; i < amount; i++)
                                {
                                    cart.Add(items[1]);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Du har inte tillräckligt med pengar för att köpa detta. Var vänlig mata in mer pengar eller välj ett lägre antal.");
                            }
                        }
                        else if (choice == "3")
                        {
                            Console.WriteLine("Hur många vill du ha? ");
                            int amount = Convert.ToInt32(Console.ReadLine());

                            int FantaPrice = items[2].GetPrice();
                            int total = FantaPrice * amount;
                            if (moneyPool >= total)
                            {
                                moneyPool = moneyPool - total;
                                for (int i = 0; i < amount; i++)
                                {
                                    cart.Add(items[2]);
                                }
                            }
                        }
                        else if (choice == "0")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Skriv in ett av alternativen i listan.\n");
                        }
                    }
                }
                else if (option == 3)
                {
                    Console.WriteLine("Detta finns i din inventory: \n");

                    foreach (Product product in cart)
                        Console.WriteLine(product.GetName());

                    while (true)
                    {

                        Console.WriteLine("\nAlternativ för att konsumera:\n 1 - Kexchoklad. \n 2 - Marabou. \n 3 - Fanta. \n 0 - Gå tillbaka till menyn.");

                        int Use = Convert.ToInt32(Console.ReadLine());


                        if (Use == 1 && cart.Contains(items[0]))
                        {
                            cart.Remove(items[0]);
                            Console.WriteLine("Du åt en Kexchoklad.");

                            foreach (Product product in cart)
                                Console.WriteLine(product.GetName());

                        }
                        else if (Use == 2 && cart.Contains(items[1]))
                        {
                            cart.Remove(items[1]);
                            Console.WriteLine("Du åt en Marabou.");

                            foreach (Product product in cart)
                                Console.WriteLine(product.GetName());
                        }
                        else if (Use == 3 && cart.Contains(items[2]))
                        {
                            cart.Remove(items[2]);
                            Console.WriteLine("Du drack en Fanta.");

                            foreach (Product product in cart)
                                Console.WriteLine(product.GetName());
                        }
                        else if (Use == 0)
                        {
                            break;
                        }
                        else if(Use > 3)
                        {
                            Console.WriteLine("Välj ett av de specifierade alternativen.");
                        }
                        else
                        {
                            Console.WriteLine("Denna produkten finns inte i din inventory");
                        }
                    }



                }
                else if (option == 4)
                {
                    Console.WriteLine("Du har " + moneyPool + " kr inmatat. Vill du ta ut pengarna? [Y/N]");

                    string GetChange = Console.ReadLine();
                    List<int> Change = new List<int>();

                    if (GetChange.ToUpper() == "Y")
                    {
                        while (moneyPool > 0)
                        {
                            if (moneyPool >= 1000)
                            {
                                moneyPool = moneyPool - 1000;
                                Change.Add(1000);
                            }
                            else if (moneyPool >= 500)
                            {
                                moneyPool = moneyPool - 500;
                                Change.Add(500);
                            }
                            else if (moneyPool >= 200)
                            {
                                moneyPool = moneyPool - 200;
                                Change.Add(200);
                            }
                            else if (moneyPool >= 100)
                            {
                                moneyPool = moneyPool - 100;
                                Change.Add(100);
                            }
                            else if (moneyPool >= 50)
                            {
                                moneyPool = moneyPool - 50;
                                Change.Add(50);
                            }
                            else if (moneyPool >= 20)
                            {
                                moneyPool = moneyPool - 20;
                                Change.Add(20);
                            }
                            else if (moneyPool >= 10)
                            {
                                moneyPool = moneyPool - 10;
                                Change.Add(10);
                            }
                            else if (moneyPool >= 5)
                            {
                                moneyPool = moneyPool - 5;
                                Change.Add(5);
                            }
                            else if (moneyPool >= 1)
                            {
                                moneyPool = moneyPool - 1;
                                Change.Add(1);
                            }
                        }
                        Console.WriteLine("Detta får du tillbaka:");
                        for (int i = 0; i < Change.Count; i++)
                        {
                            Console.WriteLine(Change[i] + " kr");
                        }
                    }
                    else if (GetChange.ToUpper() == "N")
                    {

                    }
                    else
                    {
                        Console.WriteLine("Du måste välja Y eller N.");

                    }

                }
            }




        }
    }
}
