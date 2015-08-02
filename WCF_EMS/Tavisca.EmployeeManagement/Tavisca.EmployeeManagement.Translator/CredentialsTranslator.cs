using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tavisca.EmployeeManagement.Translator
{
    public static class CredentialsTranslator
    {
        public static Model.Credentials ToDomainModel(this DataContract.Credentials credentials)
        {
            if (credentials == null) return null;
            return new Model.Credentials()
            {
                EmailId = credentials.EmailId,
                Password = credentials.Password
            };
        }

        public static DataContract.Credentials ToDataContract(this Model.Credentials credentials)
        {
            if (credentials == null) return null;
            return new DataContract.Credentials()
            {
                EmailId = credentials.EmailId,
                Password = credentials.Password
            };
        }
    }
}
