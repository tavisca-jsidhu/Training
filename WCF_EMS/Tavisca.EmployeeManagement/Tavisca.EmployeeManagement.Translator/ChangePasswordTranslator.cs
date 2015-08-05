using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tavisca.EmployeeManagement.Translator
{
    public static class ChangePasswordTranslator
    {
        public static Model.ChangePassword ToDomainModel(this DataContract.ChangePassword change)
        {
            if (change == null) return null;
            return new Model.ChangePassword()
            {
                EmailId = change.EmailId,
                OldPassword = change.OldPassword,
                NewPassword = change.NewPassword
            };
        }

        public static DataContract.ChangePassword ToDataContract(this DataContract.ChangePassword change)
        {
            if (change == null) return null;
            return new DataContract.ChangePassword()
            {
                EmailId = change.EmailId,
                OldPassword = change.OldPassword,
                NewPassword = change.NewPassword
            };
        }
    }
}
