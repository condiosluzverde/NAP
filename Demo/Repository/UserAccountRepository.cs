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
            IEnumerable<UserAccountDTO> dtoAll = _userAccountProvider.GetAll();
            List<UserAccount> all = new List<UserAccount>();
            foreach (UserAccountDTO uto in dtoAll)
            {
                all.Add(new UserAccount { Id = uto.Id, Name = uto.Name, Address = uto.Address, Postal = uto.Postal, Email = uto.Email });
            }
            return all as IEnumerable<UserAccount>;

        }

        UserAccount IUserAccountRepository.GetUserAccount(int id)
        {
            UserAccountDTO dto = _userAccountProvider.GetUserAccount(id);
            UserAccount userAccount = null;
            if (dto != null)
            {
                userAccount = new UserAccount { Id = dto.Id, Name = dto.Name, Address = dto.Address, Postal = dto.Postal, Email = dto.Email });
            }
            return userAccount;
        }

        void IUserAccountRepository.Remove(int id)
        {
            _userAccountProvider.Remove(id);
        }

        bool IUserAccountRepository.Update(UserAccount item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            UserAccountDTO dto = new UserAccountDTO { Id = item.Id, Name = item.Name, Address = item.Address, Postal = item.Postal, Email = item.Email };
            return _userAccountProvider.Update(dto);
        }
        #endregion
    }
}
