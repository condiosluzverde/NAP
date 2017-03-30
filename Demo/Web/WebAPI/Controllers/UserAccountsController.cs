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
    public class UserAccountsController : ApiController
    {
        private IUserAccountRepository _userAccountRepository = new UserAccountRepository();

        IEnumerable<UserAccount> GetAll()
        {
            return _userAccountRepository.GetAll();
        }
    }
}
