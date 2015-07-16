using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomAttribute
{
    [AttributeUsage(AttributeTargets.Class |
    AttributeTargets.Method | AttributeTargets.Constructor,
     AllowMultiple = true)]
    public class TestMethod : System.Attribute
    {
        public static bool Exists(MethodInfo type)
        {
            foreach (object attribute in type.GetCustomAttributes(true))
            {
                if (attribute is TestMethod)
                {
                    return true;
                }
            }
            return false;
        }
    }
}