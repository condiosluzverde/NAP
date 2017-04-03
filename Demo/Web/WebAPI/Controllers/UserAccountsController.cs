using Nap.Demo.Repository;
using Nap.Demo.Data;
using Nap.Demo.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Http.Description;

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

        [ResponseType(typeof(void))]
        public IHttpActionResult Update(int id, UserAccountDTO userAccountDTO)
        {
            // not using model binding in this demo.
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (id != userAccountDTO.Id)
            {
                return BadRequest();
            }

            UserAccount userAccount = _userAccountRepository.GetUserAccount(id);
            if (userAccount == null)
            {
                return NotFound();
            }

            if (_userAccountRepository.Update(userAccount))
            {
                return StatusCode(HttpStatusCode.OK);
            }
            return StatusCode(HttpStatusCode.NotModified);
        }

        [ResponseType(typeof(UserAccount))]
        public IHttpActionResult Add(UserAccount userAccount)
        {
            // Not using model binding in the demo app
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            UserAccount newUserAccount = _userAccountRepository.Add(userAccount);

            return CreatedAtRoute("DefaultApi", new { id = newUserAccount.Id }, newUserAccount);
        }

        [ResponseType(typeof(UserAccount))]
        public IHttpActionResult Removed(int id)
        {
            UserAccount userAccount = _userAccountRepository.GetUserAccount(id);
            if (userAccount == null)
            {
                return NotFound();
            }

            _userAccountRepository.Remove(id);

            return Ok(userAccount);
        }
    }
}
