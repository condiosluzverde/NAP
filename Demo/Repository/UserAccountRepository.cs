using Nap.Demo.Data;
using Nap.Demo.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nap.Demo.Repository
{
    public class UserAccountRepository : IUserAccountRepository, IDisposable
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
            foreach (UserAccountDTO dto in dtoAll)
            {
                all.Add(new UserAccount { Id = dto.Id, Name = dto.Name, Address = dto.Address, Postal = dto.Postal, Email = dto.Email });
            }
            return all as IEnumerable<UserAccount>;

        }

        UserAccount IUserAccountRepository.GetUserAccount(int id)
        {
            UserAccountDTO dto = _userAccountProvider.GetUserAccount(id);
            UserAccount userAccount = null;
            if (dto != null)
            {
                userAccount = new UserAccount { Id = dto.Id, Name = dto.Name, Address = dto.Address, Postal = dto.Postal, Email = dto.Email };
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

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // jam20170328 - do dispose here.
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UserAccountRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
        #endregion
    }
}
