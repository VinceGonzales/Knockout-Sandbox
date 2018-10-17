using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Xolartek.Utils
{
    /// <summary>
    /// Utility for creating knockout viewmodels
    /// from Assembly classes
    /// </summary>
    class Program
    {
        public static void Main(string[] args)
        {
            string assemblyLocation = args[0];
            string className = args[1];
            // This variable holds the amount of indenting that 
            // should be used when displaying each line of information.
            Int32 indent = 0;
            // Display information about the EXE assembly.
            Assembly b = Assembly.LoadFile(assemblyLocation);

            Display(indent, "Assembly: {0}", b);

            indent += 1;
            Type t = b.GetType(className);
            ReadInfo(t, indent);
            indent = 1;
            t = b.GetType("Xolartek.Web.Models.SkillVM");
            ReadInfo(t, indent);
            Console.ReadLine();
        }
        private static void CreateVM(string assemblyLocation, string className, string jsfilename)
        {
            Assembly assembly = Assembly.LoadFile(assemblyLocation);
            List<string> properties = new List<string>();

            System.IO.TextWriter tw = new StreamWriter(Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop\" + jsfilename + ".js");

            tw.Write("function {0}(", jsfilename);

            Type t = assembly.GetType(className);

            foreach (PropertyInfo prop in t.GetProperties())
            {
                properties.Add(prop.Name);
            }

            tw.Write(string.Join(", ", properties.ToArray()).ToLower());

            tw.Write(") {" + System.Environment.NewLine);
            foreach (string _p in properties)
            {
                tw.WriteLine("\tthis.{0} = ko.observable({1});", _p, _p.ToLower());
            }
            tw.WriteLine("}" + System.Environment.NewLine);

            tw.Flush();
            tw.Close();
            tw = null;
        }

        private static void ReadInfo(Type t, Int32 indent)
        {
            Display(indent, "Type: {0}", t);
            // For each type, show its members & their custom attributes.
            indent += 1;
            foreach (MemberInfo mi in t.GetMembers())
            {
                if (mi.GetCustomAttributes(false).Length == 0)
                {
                    // If the member is a method, display information about its parameters.
                    if (mi.MemberType == MemberTypes.Method)
                    {
                        Display(indent, "Method: {0}", mi.Name);

                        foreach (ParameterInfo pi in ((MethodInfo)mi).GetParameters())
                        {
                            Display(indent + 1, "Parameter: Type={0}, Name={1}", pi.ParameterType, pi.Name);
                        }
                    }

                    // If the member is a property, display information about the property's accessor methods.
                    if (mi.MemberType == MemberTypes.Property)
                    {
                        Display(indent, "Property: {0}", mi.Name);
                        PropertyInfo info = mi as PropertyInfo;
                        string propType = info.PropertyType.Name;
                        if (propType.IndexOf("List") != -1)
                        {
                            Type genericListType = info.PropertyType.GetGenericArguments()[0];
                            Display(indent + 1, "List type: {0}", genericListType.FullName);
                        }
                        else
                        {
                            Display(indent + 1, "Property type: {0}", propType);
                        }

                    }
                }
            }
        }
        // Display a formatted string indented by the specified amount.
        private static void Display(Int32 indent, string format, params object[] param)
        {
            Console.Write(new string(' ', indent * 2));
            Console.WriteLine(format, param);
        }
    }
}
