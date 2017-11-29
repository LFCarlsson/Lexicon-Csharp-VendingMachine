using System;
using System.Collections.Generic;

namespace Vending_Machine
{
    internal class VendingMachineSession
    {
        VendingMachine vendingMachine;
        List<Product> pocket;
        int userMoney;

        public VendingMachineSession(int userMoney)
        {
            vendingMachine = new VendingMachine(5);
            pocket = new List<Product>();
            this.userMoney = userMoney;

            vendingMachine.AddProduct(new Snack("gross", "A box of old crackers", 34), 0);
            vendingMachine.AddProduct(new Snack("tasty", "A box of fresh crackers", 41), 1);
            vendingMachine.AddProduct(new Drink(true, false, "A can of coke", 11), 2);
        }

        private int GetMenuOption(int numberOfOptions)
        {
            while (true)
            {
                int digitPressed = (int)Char.GetNumericValue(Console.ReadKey(true).KeyChar);
                if (digitPressed >= 0 && digitPressed < numberOfOptions)
                {
                    return digitPressed;
                }

            }

        }

        public void InFrontOfMachine()
        {
            bool keepAlive = true;
            while (keepAlive)
            {
                Console.Clear();
                System.Console.WriteLine("To the north there is a house, to the west there is a small road. In front of you there is a vending machine");
                System.Console.WriteLine("press '0' to put a coin or bill into the machine");
                System.Console.WriteLine("press '1' to get your change");
                System.Console.WriteLine("press '2' to buy something");
                System.Console.WriteLine("press '3' to check your pocket");
                System.Console.WriteLine("press '4' to go north");
                System.Console.WriteLine("press '5' to go west");
                int choice = GetMenuOption(6);

                Console.Clear();
                switch (choice)
                {
                    case 0:
                        AddMoney();
                        break;
                    case 1:
                        ReturnChange();
                        break;
                    case 2:
                        Buy();
                        break;
                    case 3:
                        Inventory();
                        break;
                    case 4:
                        Console.WriteLine("The house is not implemented and will not be, good day to you!");
                        Console.ReadKey();
                        keepAlive = false;
                        break;
                    case 5:
                        Console.WriteLine("You get eaten by a forest troll!");
                        Console.ReadKey();
                        keepAlive = false;
                        break;
                }

            }

        }

        private void Inventory()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("You have {0}kr in your wallet", userMoney);

                if (pocket.Count > 0)
                {
                    Console.WriteLine("You also have the following in you pockets:");
                }
                for (int i = 0; i < pocket.Count; i++)
                {
                    Console.WriteLine("{0}) {1} ", i, pocket[i].description);
                }
                int quitOption = pocket.Count;


                Console.WriteLine("Press the corresponding digit to interact with an object or {0} to go back", quitOption);
                int option = GetMenuOption(pocket.Count + 1);

                if (option == quitOption)
                {
                    return;
                }
                else
                {
                    Interact(pocket[option]);
                }
            }

        }

        private void Interact(Product product)
        {
            Console.Clear();
            product.Use();
            Console.ReadKey();
        }

        private void Buy()
        {
            Console.Clear();
            vendingMachine.PrintStock();
            int quitOption = vendingMachine.Slots;
            Console.WriteLine("Press {0} to return", quitOption);
            int choice = GetMenuOption(vendingMachine.Slots + 1);
            if (choice != quitOption)
            {
                Product purchased = vendingMachine.BuyProduct(choice);
                if(purchased != null)
                {
                    pocket.Add(purchased);
                    Console.WriteLine("Thank you, come again!");
                }
                else
                {
                    Console.WriteLine("Purchase failed.");
                }
                Console.ReadKey();
            }
        }

        private void ReturnChange()
        {
            Console.Clear();
            Console.WriteLine("You push the 'return change' button");
            userMoney += vendingMachine.ReturnChange();
            Console.ReadKey();
        }

        private void AddMoney()
        {
            Console.Clear();
            Console.WriteLine("Put in a coin or bill");
            int inputMoney = 0;
            if (int.TryParse(Console.ReadLine(), out inputMoney) && userMoney > inputMoney)
            {
                userMoney -= inputMoney;
            }

            bool success = vendingMachine.AddMoney(inputMoney);
            if (success)
            {
                Console.WriteLine("Money accepted.");
            }
            else
            {
                Console.WriteLine("Money rejected.");
                userMoney += inputMoney;
            }
            Console.ReadKey();
        }
    }
}