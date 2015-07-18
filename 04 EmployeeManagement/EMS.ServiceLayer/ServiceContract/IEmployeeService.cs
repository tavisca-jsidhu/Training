using DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace ServiceContract
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [WebInvoke(Method = "GET", UriTemplate = "/get_record/{id}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        Employee Get(string id);

        [WebInvoke(Method = "GET", UriTemplate = "/get_record_all", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        List<Employee> GetAll();
    }
}