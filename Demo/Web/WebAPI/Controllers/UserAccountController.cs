using Nap.Demo.Data;
using Nap.Demo.Repository;
using Nap.Demo.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Nap.Demo.WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:9001", headers: "*", methods: "*")]
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
            }
        }

        // GET: api/UserAccount
        public IEnumerable<UserAccount> Get()
        {
            return _userAccountRepository.GetAll();
        }

        // GET: api/UserAccount/5
        public UserAccount Get(int id)
        {
            var userAccount = _userAccountRepository.GetUserAccount(id);
            if (userAccount == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return userAccount;
        }

        // POST: api/UserAccount
        public void Post([FromBody]UserAccount value)
        {
            UserAccount uaAdded = _userAccountRepository.Add(value);

            if (uaAdded == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(string.Format("Add failed for UserAccount with Name: {0}", value.Name)),
                    ReasonPhrase = "Repository error during Add."
                };
                throw new HttpResponseException(resp);
            }
        }

        // PUT: api/UserAccount/5
        public void Put(int id, [FromBody]UserAccount value)
        {
            if (!_userAccountRepository.Update(value))
            {
                var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(string.Format("Update failed for UserAccount with Id: {0} / Name: {1}", value.Id, value.Name)),
                    ReasonPhrase = "Repository error during Update."
                };
                throw new HttpResponseException(resp);
            }
        }

        // DELETE: api/UserAccount/5
        public void Delete(int id)
        {
            _userAccountRepository.Remove(id);
        }
    }
}
