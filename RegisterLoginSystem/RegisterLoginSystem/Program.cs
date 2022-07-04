using System;
using System.Collections.Generic;

namespace PersonManagement
{
    internal class Program
    {
        private static List<User> users = new List<User>();

        static void Main(string[] args)
        {
            Console.WriteLine("Available commands in the system :");
            Console.WriteLine("/register");
            Console.WriteLine("/login");
            Console.WriteLine("/exit");

            while (true)
            {
                Console.WriteLine();
                Console.Write("Please enter command : ");
                string command = Console.ReadLine();

                if (command == "/register")
                {
                    Console.Write("Please enter first name :");
                    string firstName = Console.ReadLine();

                    Console.Write("Please enter last name :");
                    string lastName = Console.ReadLine();

                    Console.Write("Please enter email address :");
                    string email = Console.ReadLine();

                    Console.Write("Please enter password : ");
                    string firstPassword = Console.ReadLine();

                    Console.WriteLine("Please enter password again : ");
                    string secondPassword = Console.ReadLine();

                    RegisterUser(firstName, lastName, email, firstPassword, secondPassword);
                }

                else if (command == "/login")
                {
                    Console.Write("Please enter email : ");
                    string email = Console.ReadLine();

                    Console.Write("Please enter password : ");
                    string firstPassword = Console.ReadLine();

                    Console.Write("Please enter password again : ");
                    string secondPassword = Console.ReadLine();

                    LoginUser(email, firstPassword, secondPassword);

                }

                else if (command == "/exit")
                {
                    Console.WriteLine("Thank you for using our website!");
                    break;
                }

                else
                {
                    Console.WriteLine("Command is not found, please enter another command!");
                    Console.WriteLine();
                }
            }
        }

        public static bool RegisterUser(string firstName, string lastName, string email, string firstPassword, string secondPassword)
        {
            User user = new User(firstName, lastName, email, firstPassword, secondPassword);

            if (firstPassword == secondPassword)
            {
                users.Add(user);
                Console.WriteLine("You successfully registered, now you can login with your new account!");
                return true;
            }

            else
            {
                Console.WriteLine("The information you have entered do not match the requirements, please try again.");
                return false;
            }
        }

        public static bool LoginUser(string email, string firstpassword, string secondPassword)
        {
            if (firstpassword == secondPassword)
            {
                Console.WriteLine("You successfully logged in!");
                LoginConfirmation(email);
                return true;
            }

            else
            {
                Console.WriteLine("The information you have entered do not match the requirements, please try again.");
                return false;
            }
        }

        public static void LoginConfirmation(string email)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Email == email)
                {
                    Console.WriteLine($"Welcome to your account {users[i].FirstName} {users[i].LastName} ");
                }
            }
        }

        class IsTextLengthValid
        {
            public static bool IsTextLengthCorrect(string text, int startLength, int endLength)
            {
                if (!(text.Length > startLength && text.Length < endLength))
                {
                    return false;
                }

                return true;
            }

            public static bool IsFirstNameValid(string FirstName)
            {
                if (!IsTextLengthCorrect(FirstName, 3, 30))
                {
                    Console.WriteLine("Entered first name does not match the requirements!");
                    return false;
                }

                return true;
            }

            public static bool IsLastNameValid(string lastName)
            {
                if (!IsTextLengthCorrect(lastName, 5, 20))
                {
                    Console.WriteLine("Entered last name does not match the requirements!");
                    return false;
                }

                return true;
            }

            public static bool IsEmailValid(string email)
            {
                for (int i = 0; i < email.Length; i++)
                {
                    if (email[i] == '@')
                    {
                        return true;
                    }
                }

                Console.WriteLine("Your email must contain '@'!");
                return false;
            }

            /*public static bool IsEmailUnique(string email, List<User> users)
            {
                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].Email == email)
                    {
                        Console.WriteLine("This email has already been registered, try to register with another email!");
                        return false;
                    }

                    return true;
                }
            }*/

            public static bool IsPasswordValid(string firstPassword, string secondPassword)
            {
                if (firstPassword == secondPassword)
                {
                    return true;
                }

                else
                {
                    Console.WriteLine("The passwords you have entered do not match!");
                    return false;
                }
            }
        }

        class User : IsTextLengthValid
        {
            public string FirstName { get; private set; } = "Super";
            public string LastName { get; private set; } = "Admin";
            public string Email { get; private set; } = "admin@gmail.com";
            public string FirstPassword { get; private set; } = "123321";
            public string SecondPassword { get; private set; } = "123321";

            public User(string firstName, string lastName, string email, string firstPassword, string secondPassword)
            {
                FirstName = firstName;
                LastName = lastName;
                Email = email;
                FirstPassword = firstPassword;
                SecondPassword = secondPassword;
            }

        }
    }
}
