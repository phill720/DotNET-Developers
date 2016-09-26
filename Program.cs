﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTerminal

{
    public class Program
    {
        static void Main(string[] args)
        {
            String filePath = "LibratyTerminalTextDeposit.txt";
            
            Library library = new Library();
            Admin admin = new Admin();
            //Admin.library = library;
            Library.writeToFile(filePath);
            Library.ReadFromFile(filePath);
           

            string name = " ";
            string userResponse = "";
            string chosenBook;
            string Responce = "";
            string userSelectedBook = " ";
            int accountNumber = 0;

            Console.WriteLine("Welcome to Grand Circus Online Library!");

            Console.WriteLine("Please Enter Your Name:");
            name = Console.ReadLine();

            Console.WriteLine("Please Enter Your Account Number");
            bool accountN= int.TryParse(Console.ReadLine(), out accountNumber );

            Console.WriteLine("Welcome " + name + " user # " + accountNumber);
            selection:
            Console.WriteLine("What would you like to do? (1) List All Books (2) Search (3) Return a Book");
            int choice = int.Parse(Console.ReadLine());
            start:
            if (choice == 1)
            {
                library.displayBooks();
                Console.WriteLine("Please enter a book name to add to the cart");
                string selectedBook = Console.ReadLine();

                library.takeBook(selectedBook);

                Console.WriteLine("Search another book? (y/n)");
                userResponse = Console.ReadLine();

                if (userResponse == "y")
                    goto start;
                else
                    Console.WriteLine("Proceed to check-out? (y/n)");
                Responce = Console.ReadLine();
                if (Responce == "y")
                {
                    library.displayCheckout(name, accountNumber);
                }
                else Console.WriteLine("Thank You.");
            }

            else if (choice == 2)
            {
                Console.WriteLine("How would you like to search the book?");
                Console.WriteLine("By Category (1) or by Author(2) or by Title (3)");

                string seachCriteria = Console.ReadLine().ToUpper();
                switch (seachCriteria)
                {
                    case "1":
                    case "CATEGORY":
                        Console.WriteLine("The available categories are:");
                        library.displayCategories();

                        Console.WriteLine("Please select One Category");

                        string selectedCategory = Console.ReadLine();

                        Console.WriteLine("The books in {0} Category are: ", selectedCategory);

                        foreach (Books book in Admin.listOfBooks)
                        {
                            if (book.category == selectedCategory)

                                Console.WriteLine("Book #:\t" + book.BookNumber + "\t" + book.title + "\t\t" + book.availability);

                        }
                        Console.WriteLine("Choose a book to add to cart");

                        chosenBook = Console.ReadLine();
                        library.takeBook(chosenBook);


                        Console.WriteLine("Would you like to search another book?(Enter yes/no)");
                        string searchAnotherBook = Console.ReadLine().ToLower();
                        if (searchAnotherBook == "yes")
                            goto start;
                        else
                        {
                            library.displayCheckout(name, accountNumber);
                            Console.WriteLine("Thank You");
                        }

                        break;

                    case "2":
                    case "AUTHOR":
                        AuthorName:
                        Console.WriteLine("Would you like to check the available authors in our Library? (y/n)");
                        string yes = Console.ReadLine();
                        if (yes == "y")
                        {
                            Console.WriteLine("The available authorList:");
                            library.displayAuthorList();
                            Console.WriteLine("Please enter the Author Name");
                        }
                        else
                            Console.WriteLine("Please enter the Author Name");
                        string selectedAuthorName = Console.ReadLine();

                        foreach (Books book in Admin.listOfBooks)
                        {

                            if (book.author == selectedAuthorName)

                                Console.WriteLine("Title:" + book.title + "\t" + book.availability);

                        }
                        Console.WriteLine("Choose a book to add to cart");

                        chosenBook = Console.ReadLine();
                        library.takeBook(chosenBook);

                        Console.WriteLine("Would You like to check out another book? (y/n)");
                        string checkAnotherBook = Console.ReadLine();
                        if (checkAnotherBook == "y")
                            goto AuthorName;
                        else
                            library.displayCheckout(name, accountNumber);

                        break;

                    case "3":
                    case "TITLE":
                        title:
                        Console.WriteLine("Would you like to see all the books in the library?(Enter y/n)");
                        string y = Console.ReadLine();

                        if (y == "y")
                        {
                            library.displayBooks();
                            Console.WriteLine("Enter Book Title or Book Number:");
                             userSelectedBook = Console.ReadLine();
                        }
                        else
                            Console.WriteLine("Enter the book Title:");

                         userSelectedBook = Console.ReadLine();
                        if (string.IsNullOrEmpty(userSelectedBook))
                            Console.WriteLine("Enter valid data");
                        else
                        {
                            foreach (Books book in Admin.listOfBooks)
                            {

                                if (book.title == userSelectedBook)

                                    Console.WriteLine("Title/t:" + book.BookNumber + "/t" + book.title + "\t" + book.availability);

                            }
                            Console.WriteLine("Choose a book to add to cart");

                            chosenBook = Console.ReadLine();

                            library.takeBook(chosenBook);

                        }

                        Console.WriteLine("Would you like to check another book books in GC Library? (y/n)");
                        string yup = Console.ReadLine().ToLower();
                        if (yup == "y")
                        {
                            goto title;
                        }
                        else
                            library.displayCheckout(name, accountNumber);

                        break;

                    default:
                        Console.WriteLine("OOPS! Curently we do not have {0}. Would you like to seach another book?", seachCriteria);
                        break;
                } }
            else if (choice == 3)
            {
                Console.WriteLine("Enter Book Title or Book Number");
                string returnBook = Console.ReadLine();
                library.submitBook(returnBook);
            }
                    Console.WriteLine("Do you want to search another book? (yes/no)");
                    userResponse = Console.ReadLine().ToLower();
            if (userResponse == "yes")
                goto selection;

            else
                Console.WriteLine("Thank You for using our Grand Circus Library!");
        }
    }
}


            
                
                       
                    
    


