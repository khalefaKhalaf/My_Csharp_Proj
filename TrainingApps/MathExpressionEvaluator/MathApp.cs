using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MY_C_.TrainingApps.MathExpressionEvaluator
{
    internal class MathApp
    {
        public static void Run(string[] args)
        {
            int opt = 0;
            do
            {
                Console.WriteLine("[1] Exepression Evaluation.");
                Console.WriteLine("[0] Exit program.");
                opt = int.Parse(Console.ReadLine());
                if (opt == 1)
                {
                    Console.Write("Enter expression that you want evaluate it : ");
                    string exepression = Console.ReadLine().Trim();
                    string tocken = "";
                    double left = 0; bool le = false;
                    double right = 0; bool ri = false;
                    char CHoperation = '0'; bool cha = false;
                    string SToperation = ""; bool sto = false;

                    string opreration = "+*/%^";
                    for (int i = 0; i < exepression.Length; i++)
                    {
                        char ch = exepression[i];
                        if (char.IsDigit(ch))
                        {
                            tocken += ch;
                            if (exepression.Length - 1 == i)
                            {
                                right = double.Parse(tocken);
                            }
                        }
                        else if (char.IsLetter(ch))
                        {
                            tocken += ch;
                            sto = true;
                        }
                        else if (opreration.Contains(ch))
                        {
                            CHoperation = ch;
                            cha = true;
                            left = double.Parse(tocken);
                            le = true;
                            tocken = "";
                        }
                        else if (char.IsWhiteSpace(ch))
                        {
                            if (sto)
                            {
                                SToperation = tocken;
                                tocken = "";
                            }
                        }
                        else if (ch == '-')
                        {
                            if (i == 0)
                            {
                                tocken += ch;
                            }
                            else
                            {
                                if (cha)
                                    tocken += ch;
                                else
                                {
                                    CHoperation = ch;
                                    cha = true;
                                    left = double.Parse(tocken);
                                    le = true;
                                    tocken = "";
                                }
                            }
                        }
                    }
                    //Console.WriteLine($"left = {left}");
                    //Console.WriteLine($"rigth = {right}");
                    //Console.WriteLine($"Charoperation = {cha} ---->{CHoperation}");
                    //Console.WriteLine($"Stringoperation = {sto} ----->{SToperation}");

                    if (cha)
                    {
                        if (CHoperation == '+')
                        {
                            Console.WriteLine($"{left} + {right} = {left + right}");
                        }
                        else if (CHoperation == '-')
                        {
                            Console.WriteLine($"{left} - {right} = {left - right}");
                        }
                        else if (CHoperation == '*')
                        {
                            Console.WriteLine($"{left} * {right} = {left * right}");
                        }
                        else if (CHoperation == '/')
                        {
                            Console.WriteLine($"{left} / {right} = {left / right}");
                        }
                        else if (CHoperation == '%')
                        {
                            Console.WriteLine($"{left} % {right} = {left % right}");
                        }
                        else if (CHoperation == '^')
                        {
                            Console.WriteLine($"{left} ^ {right} = {Math.Pow(left, right)}");
                        }
                    }
                    else
                    {
                        if (SToperation == "sin")
                        {
                            Console.WriteLine($"{SToperation} {right} = {Math.Sin(right)}");
                        }
                        else if (SToperation == "cos")
                        {
                            Console.WriteLine($"{SToperation} {right} = {Math.Cos(right)}");
                        }
                        else if (SToperation == "tan")
                        {
                            Console.WriteLine($"{SToperation} {right} = {Math.Tan(right)}");
                        }
                    }
                }
                else if(opt==0)
                {
                    Console.WriteLine("End program,thank you.");
                }
                else
                {
                    Console.WriteLine("Invalid Option , Try Again.");
                }
                Console.WriteLine("----------------------------------------------------------------");
            } while (opt != 0);
            
        }

    }
}