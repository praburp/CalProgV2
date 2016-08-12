using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {

            double i;
            double number,number1;
            int[] array = new int[2];
            int[] array1 = new int[2];
            int[] array2 = new int[3];

            
            int n, p = 0, m = 0;
            int j;
            string z, t;
            
//getting the input and storing it in a string
            Console.WriteLine("enter the input:");
            string s = Console.ReadLine();
            
            z = string.Copy(s);
//finding the sqrt function in the string and replace it with its value in the string 
            for (j = 0; j < s.Length; j++)
            {
                string c = s.Substring(j, 1);
                if (c.Equals("s"))
                {
                    array[m] = j;
                    m++;
                    //Flag = 1;
                }
                if (c.Equals(")"))
                {

                    array[m] = j + 1;
                    string e = s.Substring(array[0], array[1] - array[0]);
                    for (n = 0; n < e.Length; n++)
                    {
                        string d = e.Substring(n, 1);
                        if (d.Equals("("))
                        {
                            array1[p] = n + 1;
                            p++;
                        }
                        if (d.Equals(")"))
                        {

                            array1[p] = n;

                        }



                    }
                    string f = e.Substring(array1[0], array1[1] - array1[0]);
                    Double.TryParse(f, out number);
                    //Console.WriteLine(number);
                    i = Math.Sqrt(number);
                    t = i.ToString();
                    z = z.Replace(e, t);
                    m = 0; p = 0;
                    //Console.WriteLine(z);



                }


            }

            s = string.Copy(z);
            z = string.Copy(s);

            //finding exponent in the string and replace its value in the string 


            for (j = 0; j < s.Length; j++)
            {
                string c = s.Substring(j, 1);
                if (c.Equals("^"))
                {
                    array2[m] = j;
                    m++;
                    for (int r = j; r>=0; r--) 
                    {
                        string q = s.Substring(r, 1);

                        if (q.Equals("+") || q.Equals("-") || q.Equals("*") || q.Equals("/")||r==0)
                        {

                            array2[m] = r;
                            m++;
                            break;

                        }                           
                    }

                    for (int r = j; r < s.Length; r++)
                    {
                        string q = s.Substring(r, 1);

                        if (q.Equals("+") || q.Equals("-") || q.Equals("*") || q.Equals("/") || r == s.Length-1)
                        {

                            array2[m] = r;
                            break;

                        }
                    }

                    //m = 0;
                    if (array2[1] == 0 || array2[2] == s.Length-1)
                    {
                        if (array2[1] == 0) 
                        {
                            string e = s.Substring(array2[1], (array2[0] - array2[1]));
                            string f = s.Substring(array2[0] + 1, (array2[0] - array2[1]));
                            string u = s.Substring(array2[1] , (array2[2] - array2[1]));
                            Double.TryParse(e, out number1);
                            Double.TryParse(f, out number);


                            i = Math.Pow(number1, number);
                            t = i.ToString();
                            z = z.Replace(u, t);
                        }

                        if (array2[2] == s.Length-1)
                        {
                            string e = s.Substring(array2[1]+1, (array2[0]- array2[1]-1));
                            string f = s.Substring(array2[0] + 1, (array2[0] - array2[1])-1);
                            string u = s.Substring(array2[1]+1, (array2[2] - array2[1]));
                            Double.TryParse(e, out number1);
                            Double.TryParse(f, out number);


                            i = Math.Pow(number1, number);
                            t = i.ToString();
                            z = z.Replace(u, t);
                        }

                    }

                    else
                    {

                        string e = s.Substring(array2[1] + 1, (array2[0] - array2[1] - 1));
                        string f = s.Substring(array2[0] + 1, (array2[0] - array2[1] - 1));
                        string u = s.Substring(array2[1] + 1, (array2[2] - array2[1] - 1));
                        Double.TryParse(e, out number1);
                        Double.TryParse(f, out number);


                        i = Math.Pow(number1, number);
                        t = i.ToString();
                        z = z.Replace(u, t);
                    }
                  m = 0;
                    //Console.WriteLine("help");


            
                
                
                }
                
                    



                


            }

            s = string.Copy(z);
// passing the string after replacing the sqrt function and exponent value to the Datatable to calculate the value of the expression.
            try
            {

                var nam = new DataTable().Compute(s, null);
               // Console.WriteLine("given string with solution for squareroot and exponent "+ s);
                Console.WriteLine(nam);
                
                Console.Read();

            }
            catch (Exception e) {

                Console.WriteLine("invalid input");
                Console.Read();
            
            }
            
            
           

        }
    }
}

