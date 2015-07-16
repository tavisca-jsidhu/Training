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
    public class TestCategory : System.Attribute
    {
        private string _category;
        public TestCategory(string category)
        {
            this._category = category;
        }
        public string Category
        {
            get
            {
                return _category;
            }

        }
        public static bool Exists(MethodInfo memberInfo, string category)
        {
            foreach (object attribute in memberInfo.GetCustomAttributes(true))
            {
                if (attribute is TestCategory)
                {
                    var attr = attribute as TestCategory;
                    return attr._category.Equals(category, StringComparison.OrdinalIgnoreCase);
                }
            }
            return false;
        }
    }
}