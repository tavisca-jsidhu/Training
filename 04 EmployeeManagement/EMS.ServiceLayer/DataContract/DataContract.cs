using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DataContract
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        public string Id
        {
            get;
            set;
        }

        [DataMember]
        public string Title
        {
            get;
            set;
        }

        [DataMember]
        public string FirstName
        {
            get;
            set;
        }

        [DataMember]
        public string LastName
        {
            get;
            set;
        }

        [DataMember]
        public string Email
        {
            get;
            set;
        }

        [DataMember]
        public string EmployeeRemark
        {
            get;
            set;
        }

    }

    [DataContract]
    public class Remark
    {
        [DataMember]
        public DateTime UtcTime
        {
            get;
            set;
        }
        [DataMember]
        public string Text
        {
            get;
            set;
        }

    }
}
