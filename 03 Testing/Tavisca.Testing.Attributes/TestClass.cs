using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace CustomAttribute
{
    [AttributeUsage(AttributeTargets.Class,

  AllowMultiple = true)]
    public class TestClassAttribute : System.Attribute
    {
        public static bool Exists(Type type)
        {
            foreach (TestClassAttribute attribute in type.GetCustomAttributes(true))
            {
                if (attribute != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}