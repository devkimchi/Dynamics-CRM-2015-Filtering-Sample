using System.Xml;
using System.Xml.Serialization;

namespace DevKimchi.FilteringSample.Models
{
    /// <summary>
    /// This represents the filter item collection entity in XML format.
    /// </summary>
    public class XmlFilterItemCollection : FilterItemCollection
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="XmlFilterItemCollection" /> class.
        /// </summary>
        /// <param name="filename">Filename to deserialise.</param>
        public XmlFilterItemCollection(string filename) : base(filename)
        {
        }

        /// <summary>
        /// Called during the initialisation.
        /// </summary>
        /// <param name="filename">Filename to deserialise.</param>
        protected override void OnInitialising(string filename)
        {
            using (var reader = XmlReader.Create(filename))
            {
                var serialiser = new XmlSerializer(typeof(Filter));
                this.Filter = serialiser.Deserialize(reader) as Filter;
            }
        }
    }
}