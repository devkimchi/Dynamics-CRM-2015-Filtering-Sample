using System;
using System.Linq;

namespace DevKimchi.Crm.Proxies
{
    /// <summary>
    /// This provides interfaces to the <see cref="OrganisationServiceContext" /> class.
    /// </summary>
    public interface IOrganisationServiceContext : IDisposable
    {
        /// <summary>
        /// Gets a binding to the set of all <see cref="DevKimchi.Crm.Proxies.Account"/> entities.
        /// </summary>
        IQueryable<Account> AccountSet { get; }

        /// <summary>
        /// Gets a binding to the set of all <see cref="DevKimchi.Crm.Proxies.Contact"/> entities.
        /// </summary>
        IQueryable<Contact> ContactSet { get; }
    }
}