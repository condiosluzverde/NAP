using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nap.Demo.Data
{
    public interface IUserAccountProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        IEnumerable<UserAccountDTO> GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        UserAccountDTO GetUserAccount(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        UserAccountDTO Add(UserAccountDTO item);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        void Remove(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        bool Update(UserAccountDTO item);
    }
}
