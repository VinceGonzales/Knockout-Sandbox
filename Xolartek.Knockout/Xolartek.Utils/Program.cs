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
        /// <summary>
        /// 1st argument should be the absolute path of the dll
        /// 2nd argument should be the full namespace of the class
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            string assemblyLocation = args[0];
            string className = args[1];
            
            Assembly b = Assembly.LoadFile(assemblyLocation);
            
            Type t = b.GetType(className);
            CreateKnockout(assemblyLocation, t);
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

        private static void CreateKnockout(string assemblyLocation, Type t)
        {
            System.IO.TextWriter tw = new StreamWriter(Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop\" + t.Name + ".js");
            List<string> properties = new List<string>();
            tw.Write("function {0}(", t.Name);
            foreach (PropertyInfo prop in t.GetProperties())
            {
                properties.Add(prop.Name);
            }
            tw.Write(string.Join(", ", properties.ToArray()).ToLower());
            tw.Write(") {" + System.Environment.NewLine);

            // itierate through its members
            foreach (MemberInfo mi in t.GetMembers())
            {
                // make sure it is not a custom attribute
                if (mi.GetCustomAttributes(false).Length == 0)
                {
                    // If the member is a method...
                    if (mi.MemberType == MemberTypes.Method)
                    {
                        List<string> props = new List<string>();
                        tw.Write("\tthis.{0} = function(", mi.Name);
                        foreach (ParameterInfo pi in ((MethodInfo)mi).GetParameters())
                        {
                            props.Add(pi.Name);
                        }
                        tw.Write(string.Join(", ", props.ToArray()).ToLower());
                        tw.Write(") {" + System.Environment.NewLine);
                        // write code
                        tw.Write("}" + System.Environment.NewLine);
                    }

                    // If the member is a property...
                    if (mi.MemberType == MemberTypes.Property)
                    {
                        PropertyInfo info = mi as PropertyInfo;
                        string propType = info.PropertyType.Name;
                        
                        if (propType.IndexOf("List") != -1)
                        {
                            tw.WriteLine("\tthis.{0} = ko.observableArray({1});", mi.Name, mi.Name.ToLower());
                        }
                        else
                        {
                            tw.WriteLine("\tthis.{0} = ko.observable({1});", mi.Name, mi.Name.ToLower());
                        }

                    }
                }
            }

            tw.WriteLine("}" + System.Environment.NewLine);

            tw.Flush();
            tw.Close();
            tw = null;
        }
        private static void CreateTypeScript(string assemblyLocation, Type t)
        {
            // itierate through its members
            foreach (MemberInfo mi in t.GetMembers())
            {
                // make sure it is not a custom attribute
                if (mi.GetCustomAttributes(false).Length == 0)
                {
                    // If the member is a method...
                    if (mi.MemberType == MemberTypes.Method)
                    {
                        Console.WriteLine("Method {0}", mi.Name);
                        foreach (ParameterInfo pi in ((MethodInfo)mi).GetParameters())
                        {
                            Console.WriteLine("Parameter {0} : {1}", pi.Name, pi.ParameterType);
                        }
                    }

                    // If the member is a property...
                    if (mi.MemberType == MemberTypes.Property)
                    {
                        PropertyInfo info = mi as PropertyInfo;
                        string propType = info.PropertyType.Name;

                        if (propType.IndexOf("List") != -1)
                        {
                            Type genericListType = info.PropertyType.GetGenericArguments()[0];
                            Console.WriteLine("List {0} : {1}", mi.Name, genericListType.FullName);
                        }
                        else
                        {
                            Console.WriteLine("Property {0} : {1}", mi.Name, propType);
                        }

                    }
                }
            }
        }
        private static string JsType(string clrType)
        {
            string result = "any";
            switch(clrType)
            {
                case "Int32":
                    result = "number";
                    break;
                case "String":
                    result = "string";
                    break;
                case "Boolean":
                    result = "boolean";
                    break;
            }
            return result;
        }
    }
}
