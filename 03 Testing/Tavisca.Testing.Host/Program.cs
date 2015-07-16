using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using CustomAttribute;

namespace TestMethod.Host
{
    public class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFrom(args[0]);
            Console.WriteLine("Enter the method name to be searched : ");
            var category = Console.ReadLine();

            var ignoreMethods = new List<string>();
            var executableMethods = new List<string>();
            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsClass && TestClassAttribute.Exists(type))
                {
                    foreach (MethodInfo method in (type.GetMethods()))
                    {
                        if (CustomAttribute.TestMethod.Exists(method))
                        {
                            if (Ignore.Exists(method))
                                ignoreMethods.Add(method.Name);
                            else if (string.IsNullOrWhiteSpace(category) || TestCategory.Exists(method, category))
                                executableMethods.Add(method.Name);
                        }
                    }
                }
            }
            Console.WriteLine("Ignore Methods:");
            foreach (string r in ignoreMethods)
            {
                Console.WriteLine(r);
            }
            Console.WriteLine("Executable Methods:");
            foreach (string s in executableMethods)
            {
                Console.WriteLine(s);
            }
            Console.ReadKey();
        }
    }
}