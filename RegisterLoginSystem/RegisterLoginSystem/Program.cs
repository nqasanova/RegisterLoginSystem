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

                    if (!IsEmailValid(email))
                    {
                        Console.WriteLine("You have entered wrong email!");
                        continue;
                    }

                    else if (!IsPasswordValid(firstPassword, secondPassword))
                    {
                        Console.WriteLine("You have entered wrong password!");
                        continue;
                    }
                }

                else if (command == "/login")
                {
                    Console.Write("Please enter email : ");
                    string email = Console.ReadLine();

                    Console.Write("Please enter password : ");
                    string firstPassword = Console.ReadLine();

                    Console.Write("Please enter password again : ");
                    string secondPassword = Console.ReadLine();

                    if (!IsEmailValid(email))
                    {
                        Console.WriteLine("You have entered wrong email!");
                        continue;
                    }

                    else if (!IsPasswordValid(firstPassword, secondPassword))
                    {
                        Console.WriteLine("You have entered wrong password!");
                        continue;
                    }

                    else
                    {
                        Console.WriteLine("You successfully logged in!");
                    }
                }

                else if(command == "/exit")
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

            string checkpassword = Console.ReadLine();

            if (firstPassword == secondPassword)
            {
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
            UserLoginValidation user = new UserLoginValidation(email, firstpassword, secondPassword);

            if (firstpassword == secondPassword)
            {
                Console.WriteLine("You successfully logged in!");
                return true;
            }

            else
            {
                Console.WriteLine("The information you have entered do not match the requirements, please try again.");
                return false;
            }
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

        class UserLoginValidation
        {
            public string Email { get; private set; }
            public string FirstPassword { get; private set; }
            public string SecondPassword { get; private set; }

            public UserLoginValidation(string email, string firstPassword, string secondPassword)
            {
                Email = email;
                FirstPassword = firstPassword;
                SecondPassword = secondPassword;
            }
        }

        class User
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

            class BaseValidator
            {
                public static bool IsTextLengthCorrect(string text, int startLength, int endLength)
                    {
                        if (!(text.Length > startLength && text.Length < endLength))
                        {
                            return false;
                        }

                        return true;
                    }
                }

            class UserValidator : BaseValidator
            {
                public static bool Validator(User user, List<User> users)
                {
                    return IsFirstNameValid(user.FirstName) && IsLastNameValid(user.LastName) && IsEmailValid(user.Email) && IsPasswordValid(user.FirstPassword, user.SecondPassword);
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
            }
        }
    }
}
