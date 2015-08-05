using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Remark
    {
        public string Text { get; set; }

        public DateTime CreateTimeStamp { set {CreateTimeStamp=DateTime.UtcNow;} }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(this.Text))
                throw new Exception("Text cannot be null or empty.");
        }
    }
}
