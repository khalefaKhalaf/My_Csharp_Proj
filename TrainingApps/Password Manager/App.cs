using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY_C_.TrainingApps.Password_Manager
{
    internal class App
    {
        private static readonly Dictionary<string, string> PasswordEntries=new Dictionary<string, string>();
        public static void Run(string[] args)
        {
            if (ReadPasswords())
            {
                int opt;
                do
                {
                    Console.WriteLine("[1] List All Passwords.");
                    Console.WriteLine("[2] Add Or Change Password.");
                    Console.WriteLine("[3] Get Password.");
                    Console.WriteLine("[4] Delete Password.");
                    Console.WriteLine("[0] Exit And End Program.");
                    Console.Write("Please Select An Option : ");
                    opt = int.Parse(Console.ReadLine());
                    if (opt == 1)
                        ListAllPasswords();

                    else if (opt == 2)
                        AddOrChangePassword();

                    else if (opt == 3)
                        GetPassword();

                    else if (opt == 4)
                        DeletePassword();
                    else if (opt == 0)
                        Console.WriteLine("End Program, Thank You.");
                    else
                        Console.WriteLine("Invalid Option.");

                    Console.WriteLine("--------------------------------------------");

                } while (opt != 0);
            }
            else
                Console.WriteLine("Your Password For MasterKey Is False.");

        }
  
        private static void AddOrChangePassword()
        {
            Console.Write("Enter Wepsite Name : ");
            var WepName=Console.ReadLine();
            Console.Write("Enter Password : ");
            var Password = Console.ReadLine();
            if (PasswordEntries.ContainsKey(WepName))
                PasswordEntries[WepName] = Password;
            else
                PasswordEntries.Add(WepName, Password);
            SavePasswords();
        }

        private static void GetPassword()
        {
            Console.Write("Enter Wepsite Name That You Want : ");
            var WepName = Console.ReadLine();
            if (PasswordEntries.ContainsKey(WepName))
                Console.WriteLine("Your Password is : " + PasswordEntries[WepName]);
            else
                Console.WriteLine("Password is not Found.");

        }

        private static void DeletePassword()
        {
            Console.Write("Enter Wepsite Name That You Want : ");
            var WepName = Console.ReadLine();
            if (PasswordEntries.ContainsKey(WepName))
            {
                PasswordEntries.Remove(WepName);
                Console.WriteLine("Your Password Is Deleted.");
                SavePasswords();
            }
                
            else
                Console.WriteLine("Password is not Found.");
        }

        private static void ListAllPasswords()
        {
            if (PasswordEntries.Count == 0)
                Console.WriteLine("Not Passwords Yet.");
            
            foreach (var pass in PasswordEntries)
                Console.WriteLine($"{pass.Key} = {pass.Value}");
        }

        public static string path = @"E:\Passwords.txt";
        public static bool ReadPasswords()
        {
            if(File.Exists(path))
            {
                string PassLine=File.ReadAllText(path);
                foreach(var line in PassLine.Split(Environment.NewLine))
                {
                    if(!String.IsNullOrEmpty(line))
                    {
                        var EqualIndex=line.IndexOf('=');
                        var WpName=line.Substring(0, EqualIndex);
                        var Pas=line.Substring(EqualIndex+1);
                        PasswordEntries.Add(WpName, Pas);
                    }
                   
                }
                if (PasswordEntries.ContainsKey("MasterKey"))
                {
                    Console.Write("Enter Old password of MasterKey : ");
                    string pass=Console.ReadLine();
                    if (PasswordEntries["MasterKey"]==pass)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    Console.WriteLine("Enter New Password of MasterKey : ");
                    string Pass=Console.ReadLine();
                    PasswordEntries.Add("MasterKey", Pass);     
                    return true;
                }
             
            }
            return true;
        }
        private static void SavePasswords()
        {
            var sb= new StringBuilder();
            foreach(var pass in PasswordEntries)
            {
                sb.AppendLine($"{pass.Key}={pass.Value}");
            }            
            File.WriteAllText(path, sb.ToString());
        }
    }
}