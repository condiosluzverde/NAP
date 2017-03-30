using Nap.Demo.Data;
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
        // internals - for the demo sample code, just using the Simple provider, use ProviderFactory to get it.
        private IUserAccountProvider _userAccountProvider = ProviderFactory.GetSimpleUserAccountProvider();

        #region IUserAccountRepository Implementation
        UserAccount IUserAccountRepository.Add(UserAccount item)
        {
            var userAccountDTO = _userAccountProvider.Add(new UserAccountDTO { Id = item.Id, Name = item.Name, Address = item.Address, Postal = item.Postal, Email = item.Email });
            return new UserAccount
            {
                Id = userAccountDTO.Id,
                Name = userAccountDTO.Name,
                Address = userAccountDTO.Address,
                Postal = userAccountDTO.Postal,
                Email = userAccountDTO.Email
            };
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
        #endregion
    }
}
