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
        /// <summary>
        /// Get a list of all UserAccounts.
        /// </summary>
        /// <returns>List of all UserAccounts</returns>
        public IEnumerable<UserAccount> Get()
        {
            return _userAccountRepository.GetAll();
        }

        // GET: api/UserAccount/5
        /// <summary>
        /// Get a particular UserAcount by ID.
        /// </summary>
        /// <param name="id">ID number for the UserAccount to get.</param>
        /// <returns></returns>
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
        /// <summary>
        /// Add a new UserAccount to the collection of UserAccounts.
        /// </summary>
        /// <param name="value">Json document containing all the fields to populate the new UserAccount.</param>
        /// <returns></returns>
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
        /// <summary>
        /// Update the values for the given UserAccount as identified by the provided ID.
        /// </summary>
        /// <param name="id">ID of the UserAcocunt to update.</param>
        /// <param name="value">Json document containing the updated values for the UserAccount.</param>
        /// <returns></returns>
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
        /// <summary>
        /// Delete the UserAccount identified by the provided ID.
        /// </summary>
        /// <param name="id">ID of the UserAcocunt to delete.</param>
        public void Delete(int id)
        {
            _userAccountRepository.Remove(id);
        }
    }
}
