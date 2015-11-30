using System.Collections.Generic;
using System.Linq;

namespace DevKimchi.FilteringSample.ApiApp.Models
{
    /// <summary>
    /// This represents the model collection entity for account.
    /// </summary>
    public class AccountModelCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountModelCollection" /> class.
        /// </summary>
        public AccountModelCollection()
        {
            this.Items = new List<AccountModel>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountModelCollection" /> class.
        /// </summary>
        /// <param name="items">The list of <see cref="AccountModel" /> items.</param>
        public AccountModelCollection(IEnumerable<AccountModel> items)
        {
            this.Items = items.ToList();
        }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public List<AccountModel> Items { get; set; }
    }
}