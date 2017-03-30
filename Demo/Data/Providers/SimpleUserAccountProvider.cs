using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nap.Demo.Data
{
    class SimpleUserAccountProvider : IUserAccountProvider
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

        #endregion
    }
}
