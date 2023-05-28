using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace LoginEncryption
{
    public class Login
    {
        List<User> users = new List<User>();
        // Test login system
        public void LoginSystem()
        {
            PrintMainMenu();
        }

        public bool HandleInput(string userName, string password)
        {
            if (userName == "Test" && password == "1234") 
            {
                return true;
            }
            return false;
        }

        public bool LoginTest()
        {
            Console.Write("Username:");
            string userName = Console.ReadLine();
            Console.Write("Password:");
            string password = Console.ReadLine();

            foreach (User user in users)
            {
                if(user.UserName == userName)
                {
                    if (BC.Verify(password + user.PasswordSalt, user.PasswordHash))
                    {
                        Console.WriteLine("Login success. Press any key to continue.");
                        Console.ReadKey();
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Username or password is wrong!");
                        Console.ReadKey();
                    }
                }
            }
            return false;
        }

        public bool Registration()
        {
            User user = new User();
            string salt = BC.GenerateSalt();
            Console.WriteLine("USER REGISTRATION");
            Console.WriteLine("Please enter a user name and a password below.");
            Console.Write("Username:");
            string userName = Console.ReadLine();
            Console.Write("Password:");
            string password = Console.ReadLine();
            Console.WriteLine("Please verify your password.");
            Console.Write("Password:");
            string passVerify = Console.ReadLine();

            if(password != passVerify)
            {
                Console.WriteLine("That went wrong");
                return false;
            }

            string passwordHash = BC.HashPassword(password + salt, workFactor: 15);
            user.UserName = userName;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = salt;
            users.Add(user);
            return true;
        }

        // Very basic menu array that prompts the user to select a menu choice
        private void PrintMainMenu()
        {
            string[] menuArr = { "1. Login", "2. Register", "E. Exit" };
            bool showMenu = true;

            while (showMenu)
            {
                Console.Clear();
                for (int i = 0; i < menuArr.Length; i++)
                {
                    Console.WriteLine(menuArr[i]);
                }
                ConsoleKey userInput = Console.ReadKey(true).Key;

                switch (userInput)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        LoginTest();
                        break;
                    case ConsoleKey.D2:
                        Registration();
                        Console.Clear();
                        break;
                    case ConsoleKey.E:
                        showMenu = false;
                        Console.WriteLine("You chose to exit the program. Press any key to continue.");
                        break;
                    default:
                        Console.WriteLine("Please enter a valid choice.");
                        break;
                }
            }
        }
    }

    public class User
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }
}
