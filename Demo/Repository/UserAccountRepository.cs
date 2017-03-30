using Nap.Demo.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nap.Demo.Repository
{
    class UserAccountRepository : IUserAccountRepository
    {
        UserAccount IUserAccountRepository.Add(UserAccount item)
        {
            throw new NotImplementedException();
        }

        IEnumerable<UserAccount> IUserAccountRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        UserAccount IUserAccountRepository.GetUserAccount(int id)
        {
            throw new NotImplementedException();
        }

        void IUserAccountRepository.Remove(int id)
        {
            throw new NotImplementedException();
        }

        bool IUserAccountRepository.Update(UserAccount item)
        {
            throw new NotImplementedException();
        }
    }
}
