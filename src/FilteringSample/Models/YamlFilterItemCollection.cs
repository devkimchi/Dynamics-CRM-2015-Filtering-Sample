using System;

namespace DevKimchi.FilteringSample.Models
{
    /// <summary>
    /// This represents the filter item collection entity in YAML format.
    /// </summary>
    public class YamlFilterItemCollection : FilterItemCollection
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="YamlFilterItemCollection" /> class.
        /// </summary>
        /// <param name="filename">Filename to deserialise.</param>
        public YamlFilterItemCollection(string filename) : base(filename)
        {
        }

        /// <summary>
        /// Called during the initialisation.
        /// </summary>
        /// <param name="filename">Filename to deserialise.</param>
        protected override void OnInitialising(string filename)
        {
            throw new NotImplementedException();
        }
    }
}