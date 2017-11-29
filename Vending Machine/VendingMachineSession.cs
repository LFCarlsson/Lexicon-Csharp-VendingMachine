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
        }

        private int GetMenuOption(int numberOfOptions)
        {
            while(true)
            {
                int digitPressed = (int) Char.GetNumericValue(Console.ReadKey(true).KeyChar);
                if ( 0 < digitPressed && digitPressed > numberOfOptions - 1)
                {
                    return digitPressed;
                }

            }
            
        }

        public void InFrontOfMachine()
        {
            System.Console.WriteLine("To the north there is a house, to the west there is a small road. In front of you there is a vending machine");
            bool keepAlive = true;
            while (keepAlive)
            {
                System.Console.WriteLine("press '0' to put a coin or bill into the machine");
                System.Console.WriteLine("press '1' to get your change");
                System.Console.WriteLine("press '2' to buy something");
                System.Console.WriteLine("press '3' to check your pocket");
                System.Console.WriteLine("press '4' to go north");
                int choice = GetMenuOption(5);

                switch(choice)
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
                        keepAlive = false;
                        break;
                }

            }

        }

        private void Inventory()
        {
            Console.Clear();
            Console.WriteLine("You have {0}kr in your wallet",userMoney);

            if(pocket.Count > 0)
            {
                Console.WriteLine("You also have the following in you pockets:");
            }
            for(int i = 0; i < pocket.Count; i++)
            {
                Console.WriteLine("{0}) {1} ",i,pocket[i].Name);
            }
            int quitOption = pocket.Count;

            while (true)
            {
                Console.WriteLine("Press the corresponding digit to interact with an object or {0} to go back", quitOption);
                int option = GetMenuOption(pocket.Count);

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
            throw new NotImplementedException();
        }

        private void Buy()
        {
            throw new NotImplementedException();
        }

        private void ReturnChange()
        {
            throw new NotImplementedException();
        }

        private void AddMoney()
        {
            throw new NotImplementedException();
        }
    }
}