using System;
using System.IO;

namespace DevKimchi.FilteringSample.Models
{
    /// <summary>
    /// Gets or sets the collection entity for filter items.
    /// </summary>
    public abstract class FilterItemCollection : IFilterItemCollection
    {
        private const string Filename = "filter";
        private const string XmlExtension = "xml";
        private const string JsonExtension = "json";
        private const string YamlExtension = "yml";

        /// <summary>
        /// Initialises a new instance of the <see cref="FilterItemCollection" /> class.
        /// </summary>
        /// <param name="filename">Filename to deserialise.</param>
        protected FilterItemCollection(string filename)
        {
            this.Initialise(filename);
        }

        /// <summary>
        /// Gets or sets the <see cref="Filter" /> instance.
        /// </summary>
        protected Filter Filter { get; set; }

        /// <summary>
        /// Creates the <see cref="IFilterItemCollection" /> instance based on file type.
        /// </summary>
        /// <returns>Returns the <see cref="IFilterItemCollection" /> instance created.</returns>
        public static IFilterItemCollection CreateInstance()
        {
            string filename;
            IFilterItemCollection collection;
            if (XmlFilterExists(out filename))
            {
                collection = new XmlFilterItemCollection(filename);
            }
            else if (JsonFilterExists(out filename))
            {
                collection = new JsonFilterItemCollection(filename);
            }
            else if (YamlFilterExists(out filename))
            {
                collection = new YamlFilterItemCollection(filename);
            }
            else
            {
                throw new InvalidOperationException("No filter found");
            }

            return collection;
        }

        /// <summary>
        /// Checks whether the entity name belongs to the filter collection or not.
        /// </summary>
        /// <param name="entityName">Entity name.</param>
        /// <returns>Returns <c>True</c>, if the entity name belongs to the filter collection; otherwise returns <c>False</c>.</returns>
        public bool IsValidEntity(string entityName)
        {
            var isValid = this.Filter
                              .Items
                              .Exists(p => p.Equals(entityName, StringComparison.InvariantCultureIgnoreCase));
            return isValid;
        }

        /// <summary>
        /// Called during the initialisation.
        /// </summary>
        /// <param name="filename">Filename to deserialise.</param>
        protected abstract void OnInitialising(string filename);

        private static bool XmlFilterExists(out string filename)
        {
            filename = string.Join(".", Filename, XmlExtension);

            var exists = File.Exists(filename);
            if (!exists)
            {
                filename = null;
            }

            return exists;
        }

        private static bool JsonFilterExists(out string filename)
        {
            filename = string.Join(".", Filename, JsonExtension);

            var exists = File.Exists(filename);
            if (!exists)
            {
                filename = null;
            }

            return exists;
        }

        private static bool YamlFilterExists(out string filename)
        {
            filename = string.Join(".", Filename, YamlExtension);

            var exists = File.Exists(filename);
            if (!exists)
            {
                filename = null;
            }

            return exists;
        }

        private void Initialise(string filename)
        {
            this.OnInitialising(filename);
        }
    }
}