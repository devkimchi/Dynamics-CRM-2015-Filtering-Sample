using System;
using System.IO;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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
            using (var reader = File.OpenText(filename))
            {
                var settings = new JsonSerializerSettings()
                                   {
                                       ContractResolver = new CamelCasePropertyNamesContractResolver()
                                   };
                this.Filter = JsonConvert.DeserializeObject<Filter>(reader.ReadToEnd(), settings);
            }
        }
    }
}