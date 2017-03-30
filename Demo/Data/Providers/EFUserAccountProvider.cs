using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nap.Demo.Data
{
    class EFUserAccountProvider : IUserAccountProvider
    {
        UserAccountDTO IUserAccountProvider.Add(UserAccountDTO item)
        {
            throw new NotImplementedException();
        }

        IEnumerable<UserAccountDTO> IUserAccountProvider.GetAll()
        {
            throw new NotImplementedException();
        }

        UserAccountDTO IUserAccountProvider.GetUserAccount(int id)
        {
            throw new NotImplementedException();
        }

        void IUserAccountProvider.Remove(int id)
        {
            throw new NotImplementedException();
        }

        bool IUserAccountProvider.Update(UserAccountDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
