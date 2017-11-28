# Lexicon-Csharp-VendingMachine
Lexicon ASP.net course assignment 4

Vending machine 
Your assignment for this week is to make a vending machine. It should be able to take requests from the user as to what product it is supposed to return. It should also take payment, and send the product back to the user with an appropriate amount of change.
Required Features:


•	Money should be input in fixed denominations:
        ○ 1kr, 5kr, 10kr, 20kr, 50kr, 100kr, 500kr and 1000kr.
• The user should be able to put any amount of money in, adding to the “money pool”.
• The user should be able to buy any number of products, as long as they have the money for it in the machine. 
• When the user decides to stop buying things, the remaining money should be returned as change.
• The vending machine should have at least three different types of product, such as drinks, snacks, food and so on. 
• Once a product has been purchased, the user should be able to use it, showing a message about how it is used (drink the drink, eat the snack / food, etc…)

Code Requirements:


• Money denominations should be defined as an array of integers.
• Each product type should be its own class.
        ○ These classes should all inherit form the same interface or abstract class, to get the methods they have in common. This base class is the type the vending machine itself should look for.
        ○ The common methods should include at least:
	Purchase, to buy the product
	Examine, to show the product’s price and info
	Use, to put the product to use once it has been purchased (output a message to the console)

Resources:


• https://msdn.microsoft.com/en-us/library/ms173152.aspx MSDN - Polymorphism
• https://msdn.microsoft.com/en-us/library/ms173149.aspx MSDN - Inheritance
• https://app.pluralsight.com/library/courses/csharp-fundamentals-csharp5/
        ○ The chapter called “Object-Oriented Programming”
Expected Duration: 5 days

Subjects Covered:


• Inheritance
• Polymorphism
• Interfaces
• Abstract Classes
