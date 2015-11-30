using System.Collections.Generic;
using System.Xml.Serialization;

namespace DevKimchi.FilteringSample.Models
{
    /// <summary>
    /// This represents the model entity for filter.
    /// </summary>
    [XmlRoot("filter")]
    public class Filter
    {
        /// <summary>
        /// Gets or sets the list of entity items.
        /// </summary>
        [XmlArray("items")]
        [XmlArrayItem("item")]
        public List<string> Items { get; set; }
    }
}