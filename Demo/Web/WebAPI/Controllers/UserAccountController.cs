using Nap.Demo.Data;
using Nap.Demo.Repository;
using Nap.Demo.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nap.Demo.WebAPI.Controllers
{
    public class UserAccountController : ApiController
    {
        // For the sample, inject the simple provider literally here (requires reference to .Data (which should be encapsulated behind .Provider)
        // - for a real project we would want .net framework to be configured to inject this, or use an IoC container.
        private IUserAccountRepository _userAccountRepository
        {
            get
            {
                object repo = null;
                bool canHazUserAccountRepo = Configuration.Properties.TryGetValue("UserAccountRepository", out repo);
                if (!canHazUserAccountRepo)
                {
                    throw new WebException("WebDemoAPI: Could not obtain UserAccountRepository from configuration.");
                }
                return repo as IUserAccountRepository;
                //return new UserAccountRepository(ProviderFactory.GetSimpleUserAccountProvider());
            }
        }

        // GET: api/UserAccount
        public IEnumerable<UserAccount> Get()
        {
            //return new string[] { "value1", "value2" };
            return _userAccountRepository.GetAll();
        }

        // GET: api/UserAccount/5
        public UserAccount Get(int id)
        {
            var userAccount = _userAccountRepository.GetUserAccount(id);
            return userAccount;
        }

        // POST: api/UserAccount
        public void Post([FromBody]UserAccount value)
        {
            _userAccountRepository.Add(value);
        }

        // PUT: api/UserAccount/5
        public void Put(int id, [FromBody]UserAccount value)
        {
            _userAccountRepository.Update(value);
        }

        // DELETE: api/UserAccount/5
        public void Delete(int id)
        {
            _userAccountRepository.Remove(id);
        }
    }
}
