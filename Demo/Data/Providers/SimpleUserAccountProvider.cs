using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nap.Demo.Data
{
    class SimpleUserAccountProvider : IUserAccountProvider, IDisposable
    {
        private readonly List<UserAccountDTO> _account = null;
        private int _nextId;

        public SimpleUserAccountProvider()
        {
            _account = new List<UserAccountDTO>();
            _nextId = 1;

            ((IUserAccountProvider)this).Add(new UserAccountDTO { Name = "test guy", Address = "20 Glover Avenue", Email = "test@napower.com", Postal = "06850" });
            ((IUserAccountProvider)this).Add(new UserAccountDTO { Name = "John Doe", Address = "243 America Avenue", Email = "test@test.com", Postal = "07719" });
            ((IUserAccountProvider)this).Add(new UserAccountDTO { Name = "Jane Doe", Address = "123 USA Avenue", Email = "test2@test.com", Postal = "06890" });
        }

        #region IUserAccountProvider Implementation

        UserAccountDTO IUserAccountProvider.Add(UserAccountDTO item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            item.Id = _nextId++;
            _account.Add(item);
            return item;
        }

        IEnumerable<UserAccountDTO> IUserAccountProvider.GetAll()
        {
            return _account;
        }

        UserAccountDTO IUserAccountProvider.GetUserAccount(int id)
        {
            return _account.FirstOrDefault(p => p.Id == id);
        }

        void IUserAccountProvider.Remove(int id)
        {
            _account.RemoveAll(p => p.Id == id);
        }

        bool IUserAccountProvider.Update(UserAccountDTO item)
        {
            if (item == null)
            {
                throw new AggregateException(nameof(item));
            }
            var index = _account.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            _account.RemoveAt(index);
            _account.Add(item);  // jam20170328 - nicely adds back removed items, so we never go empty?

            return true;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // jam2017 - do dispose here.
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~SimpleUserAccountProvider() {
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
