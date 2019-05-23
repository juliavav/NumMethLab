using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumMethLab1.Services
{
    static class ReadingService
    {
        public static void ReadLab1()
        {
            try
            {   // Open the text file using a stream reader.C:\Users\user\Source\Repos\NumMethLab1\NumMethLab1\Data\lab5.txt
                using (StreamReader sr = new StreamReader("C:\\Users\\user\\Source\\Repos\\NumMethLab1\\NumMethLab1\\Data\\lab1.txt"))
                //using (StreamReader sr = new StreamReader("C:\\Users\\julia\\source\\repos\\NumMethLab\\NumMethLab1\\Data\\lab1.txt"))
                {

                    var size = Convert.ToInt32(sr.ReadLine());

                    var input = sr.ReadLine();

                    if (input == null) return;

                    var listResult = new List<double>();
                    foreach (var number in input.Split())
                    {
                            listResult.Add(Convert.ToDouble(number));
                    }

                    MatrixConstants.Lab1Vector = listResult.ToArray();

                    input = sr.ReadToEnd();
                    int i = 0;
                    MatrixConstants.Lab1Matrix = new double[size, size];
                    foreach (var row in input.Split('\n'))
                    {
                        var j = 0;
                        foreach (var col in row.Trim().Split(' '))
                        {
                            MatrixConstants.Lab1Matrix[i, j] = int.Parse(col.Trim());
                            j++;
                        }
                        i++;
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public static void ReadLab3()
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("C:\\Users\\user\\Source\\Repos\\NumMethLab1\\NumMethLab1\\Data\\lab3.txt"))
                    //using (StreamReader sr = new StreamReader("C:\\Users\\julia\\source\\repos\\NumMethLab\\NumMethLab1\\Data\\lab3.txt"))
                {

                    var size = Convert.ToInt32(sr.ReadLine());

                    var input = sr.ReadLine();

                    if (input == null) return;

                    var listResult = new List<double>();
                    foreach (var number in input.Split())
                    {
                        listResult.Add(Convert.ToDouble(number));
                    }

                    MatrixConstants.Lab3Vector = listResult.ToArray();

                    input = sr.ReadToEnd();
                    int i = 0;
                    MatrixConstants.Lab3Matrix = new double[size, size];
                    foreach (var row in input.Split('\n'))
                    {
                        var j = 0;
                        foreach (var col in row.Trim().Split(' '))
                        {
                            MatrixConstants.Lab3Matrix[i, j] = int.Parse(col.Trim());
                            j++;
                        }
                        i++;
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public static void ReadLab4()
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("C:\\Users\\user\\Source\\Repos\\NumMethLab1\\NumMethLab1\\Data\\lab4.txt"))
                    //using (StreamReader sr = new StreamReader("C:\\Users\\julia\\source\\repos\\NumMethLab\\NumMethLab1\\Data\\lab4.txt"))
                {

                    var size = Convert.ToInt32(sr.ReadLine());
                    
                    var input = sr.ReadToEnd();
                    int i = 0;
                    MatrixConstants.Lab4Matrix = new double[size, size];
                    foreach (var row in input.Split('\n'))
                    {
                        var j = 0;
                        foreach (var col in row.Trim().Split(' '))
                        {
                            MatrixConstants.Lab4Matrix[i, j] = int.Parse(col.Trim());
                            j++;
                        }
                        i++;
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public static void ReadLab5()
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("C:\\Users\\user\\Source\\Repos\\NumMethLab1\\NumMethLab1\\Data\\lab5.txt"))
                    //using (StreamReader sr = new StreamReader("C:\\Users\\julia\\source\\repos\\NumMethLab\\NumMethLab1\\Data\\lab5.txt"))
                {

                    var size = Convert.ToInt32(sr.ReadLine());

                    var input = sr.ReadToEnd();
                    int i = 0;
                    MatrixConstants.Lab5Matrix = new double[size, size];
                    foreach (var row in input.Split('\n'))
                    {
                        var j = 0;
                        foreach (var col in row.Trim().Split(' '))
                        {
                            MatrixConstants.Lab5Matrix[i, j] = int.Parse(col.Trim());
                            j++;
                        }
                        i++;
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
