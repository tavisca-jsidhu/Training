using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Tavisca.EmployeeManagement.DataContract;

namespace Tavisca.EmployeeManagement.ServiceContract
{
    [ServiceContract]
    public interface IEmployeeAuthenticateService
    {

        [WebInvoke(Method = "POST", UriTemplate = "credentials", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        EmployeeResponse AuthenticateUser(Credentials credentials);

        [WebInvoke(Method = "POST", UriTemplate = "changePassword", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ChangePasswordResponse UpdatePassword(ChangePassword change);
    }
}
