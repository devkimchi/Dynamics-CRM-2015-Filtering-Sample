using System;

namespace DevKimchi.FilteringSample.Models
{
    /// <summary>
    /// This represents the filter item collection entity in JSON format.
    /// </summary>
    public class JsonFilterItemCollection : FilterItemCollection
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="JsonFilterItemCollection" /> class.
        /// </summary>
        /// <param name="filename">Filename to deserialise.</param>
        public JsonFilterItemCollection(string filename) : base(filename)
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