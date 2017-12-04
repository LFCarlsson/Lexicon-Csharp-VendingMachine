using System;
using System.Collections.Generic;

namespace Vending_Machine
{
    internal class VendingMachineSession
    {
        VendingMachine vendingMachine;
        Person user;

        public VendingMachineSession(int userMoney)
        {
            vendingMachine = new VendingMachine(5);
            user = new Person(userMoney);

            vendingMachine.AddProduct(new Snack("gross", "mariekex", "A box of old crackers", 34), 0);
            vendingMachine.AddProduct(new Snack("tasty", "mariekex","A box of fresh crackers", 34), 0);
            vendingMachine.AddProduct(new Drink(true, false, "coca-cola", "A can of coke", 11), 1);
            vendingMachine.AddProduct(new Hat("bowler hat", "A funny little hat", 100), 2);
        }

        /// <summary>
        /// Prompts the user for an keypress to represent a menu option
        /// </summary>
        /// <param name="numberOfOptions"> number of options in menu</param>
        /// <returns>the users choice as an integer</returns>
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

        /// <summary>
        /// The main menu of the program
        /// </summary>
        public void MainMenu()
        {
            bool keepAlive = true;
            while (keepAlive)
            {
                Console.Clear();
                System.Console.WriteLine("To the north there is a house, to the west there is a small road. In front of you there is a vending machine");
                System.Console.WriteLine("press '0' to put a coin or bill into the machine");
                System.Console.WriteLine("press '1' to get your change");
                System.Console.WriteLine("press '2' to inspect the machine");
                System.Console.WriteLine("press '3' to buy from the machine");
                System.Console.WriteLine("press '4' to check your pocket");
                System.Console.WriteLine("press '5' to go north");
                System.Console.WriteLine("press '6' to go west");
                int choice = GetMenuOption(7);

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
                        InspectMachine();
                        break;
                    case 3:
                        Buy();
                        break;
                    case 4:
                        Inventory();
                        break;
                    case 5:
                        Console.WriteLine("The house is not implemented and will not be, good day to you!");
                        Console.ReadKey();
                        keepAlive = false;
                        break;
                    case 6:
                        Console.WriteLine("You get eaten by a forest troll!");
                        Console.ReadKey();
                        keepAlive = false;
                        break;
                }

            }

        }

        /// <summary>
        /// User inventory menu
        /// </summary>
        private void Inventory()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("You have {0}kr in your wallet", user.Money);

                if (user.ownedProducts.Count > 0)
                {
                    Console.WriteLine("You also have the following in you pockets:");
                }
                user.PrintPocket();
                int quitOption = user.ownedProducts.Count;


                Console.WriteLine("Press the corresponding digit to interact with an object or {0} to go back", quitOption);
                int option = GetMenuOption(user.ownedProducts.Count + 1);

                if (option == quitOption)
                {
                    return;
                }
                else
                {
                    Interact(user.ownedProducts[option]);
                }
            }

        }

        /// <summary>
        /// Let the user examine or use a product
        /// </summary>
        /// <param name="product">the product to interact with</param>
        private void Interact(Product product)
        {
            System.Console.WriteLine("press '0' to examine");
            System.Console.WriteLine("press '1' to use");
            System.Console.WriteLine("press '2' to return");
            int choice = GetMenuOption(3);
            Console.Clear();
            switch(choice)
            {
                case 0:
                    product.Examine();
                    break;
                case 1:
                    product.Use();
                    break;
                case 2:
                    break;
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Menu to let the user examine product in the vending machine
        /// </summary>
        private void InspectMachine()
        {
            Console.Clear();
            Console.WriteLine("Machine saldo: {0}", vendingMachine.moneyPool);
            vendingMachine.PrintStock();
            int quitOption = vendingMachine.Slots;
            Console.WriteLine("Press {0} to return", quitOption);
            int choice = GetMenuOption(vendingMachine.Slots + 1);
            if (choice != quitOption)
            {
                vendingMachine.InspectProduct(choice);
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Menu to let the user buy products in the vending machine
        /// </summary>
        private void Buy()
        {
            Console.Clear();
            Console.WriteLine("Machine saldo: {0}", vendingMachine.moneyPool);
            vendingMachine.PrintStock();
            int quitOption = vendingMachine.Slots;
            Console.WriteLine("Press {0} to return", quitOption);
            int choice = GetMenuOption(vendingMachine.Slots + 1);
            if (choice != quitOption)
            {
                
                if(vendingMachine.BuyProduct(choice, user))
                {
                    Console.WriteLine("Thank you, come again!");
                }
                else
                {
                    Console.WriteLine("Purchase failed.");
                }
                Console.ReadKey();
            }
        }

        /// <summary>
        /// returns money from the machine to the user. Prints what coins and bills are returned
        /// </summary>
        private void ReturnChange()
        {
            Console.Clear();
            Console.WriteLine("You push the 'return change' button");
            user.Money += vendingMachine.ReturnChange();
            Console.ReadKey();
        }

        /// <summary>
        /// Add money from the user to the machine
        /// </summary>
        private void AddMoney()
        {
            Console.Clear();
            Console.WriteLine("Put in a coin or bill");
            int inputMoney = 0;
            if (int.TryParse(Console.ReadLine(), out inputMoney) && user.Money > inputMoney)
            {
                user.Money -= inputMoney;


                bool success = vendingMachine.AddMoney(inputMoney);
                if (success)
                {
                    Console.WriteLine("Money accepted.");
                }
                else
                {
                    Console.WriteLine("Money rejected.");
                    user.Money += inputMoney;
                }
            }
            else
                {
                Console.WriteLine("Input error or not enough money");
                }
            Console.ReadKey();
        }
    }
}