using System;
using System.Linq;
using System.Net;
using System.Web.Http;

using DevKimchi.Crm.Proxies;
using DevKimchi.FilteringSample.ApiApp.Models;

namespace DevKimchi.FilteringSample.ApiApp.Controllers
{
    /// <summary>
    /// The organisation controller.
    /// </summary>
    [RoutePrefix("accounts")]
    public class OrganisationController : ApiController
    {
        private readonly IOrganisationServiceContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrganisationController" /> class.
        /// </summary>
        /// <param name="context"><see cref="IOrganisationServiceContext" /> instance.</param>
        public OrganisationController(IOrganisationServiceContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            this._context = context;
        }

        /// <summary>
        /// Gets the list of accounts.
        /// </summary>
        /// <returns>Returns the list of accounts.</returns>
        [Route("")]
        public AccountModelCollection GetAccounts()
        {
            var accounts = this._context
                               .AccountSet
                               .Select(p => new AccountModel()
                                                {
                                                    AccountNumber = p.AccountNumber,
                                                    Email = p.EMailAddress1
                                                })
                               .ToList();
            var collection = new AccountModelCollection(accounts);
            return collection;
        }

        /// <summary>
        /// Gets the account corresponding to the given email.
        /// </summary>
        /// <param name="email">Email address.</param>
        /// <returns>Returns the <see cref="Account" /> instance.</returns>
        [Route("{email}")]
        public AccountModel GetAccount(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var account = this._context
                              .AccountSet
                              .Select(p => new AccountModel()
                                               {
                                                   AccountNumber = p.AccountNumber,
                                                   Email = p.EMailAddress1
                                               })
                              .SingleOrDefault(p => p.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase));
            return account;
        }
    }
}