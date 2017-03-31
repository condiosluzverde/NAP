using Nap.Demo.Repository;
using Nap.Demo.Data;
using Nap.Demo.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nap.Demo.WebAPI.Controllers
{
    public class UserAccountsController : ApiController
    {
        // For the sample, inject the simple provider
        private IUserAccountRepository _userAccountRepository = new UserAccountRepository(ProviderFactory.GetSimpleUserAccountProvider());

        public IEnumerable<UserAccount> GetAll()
        {
            return _userAccountRepository.GetAll();
        }

        public IHttpActionResult GetUserAccount(int id)
        {
            var userAccount = _userAccountRepository.GetUserAccount(id);
            if (userAccount == null)
            {
                return NotFound();
            }
            return Ok(userAccount);
        }
    }
}
