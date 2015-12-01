using System;

using DevKimchi.FilteringSample.Models;

using Microsoft.Crm.Services.Utility;
using Microsoft.Xrm.Sdk.Metadata;

namespace DevKimchi.FilteringSample
{
    /// <summary>
    /// This represents the filtering service entity.
    /// </summary>
    public class EntityFilteringService : ICodeWriterFilterService
    {
        private readonly IFilterItemCollection _collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityFilteringService" /> class.
        /// </summary>
        /// <param name="defaultService"><see cref="ICodeWriterFilterService" /> instance.</param>
        public EntityFilteringService(ICodeWriterFilterService defaultService)
        {
            this.DefaultService = defaultService;

            this._collection = FilterItemCollection.CreateInstance();
        }

        private ICodeWriterFilterService DefaultService { get; set; }

        /// <summary>
        /// Generates attributes.
        /// </summary>
        /// <param name="attributeMetadata"><see cref="AttributeMetadata" /> instance.</param>
        /// <param name="services"><see cref="IServiceProvider" /> instance.</param>
        /// <returns>Returns <c>True</c>, if successfully generated; otherwise returns <c>False</c>.</returns>
        public bool GenerateAttribute(AttributeMetadata attributeMetadata, IServiceProvider services)
        {
            return this.DefaultService.GenerateAttribute(attributeMetadata, services);
        }

        /// <summary>
        /// Generates attributes.
        /// </summary>
        /// <param name="entityMetadata"><see cref="EntityMetadata" /> instance.</param>
        /// <param name="services"><see cref="IServiceProvider" /> instance.</param>
        /// <returns>Returns <c>True</c>, if successfully generated; otherwise returns <c>False</c>.</returns>
        public bool GenerateEntity(EntityMetadata entityMetadata, IServiceProvider services)
        {
            var isValidEntity = this.IsValidEntity(entityMetadata.LogicalName);
            return isValidEntity && this.DefaultService.GenerateEntity(entityMetadata, services);
        }

        /// <summary>
        /// Generates attributes.
        /// </summary>
        /// <param name="optionMetadata"><see cref="OptionMetadata" /> instance.</param>
        /// <param name="services"><see cref="IServiceProvider" /> instance.</param>
        /// <returns>Returns <c>True</c>, if successfully generated; otherwise returns <c>False</c>.</returns>
        public bool GenerateOption(OptionMetadata optionMetadata, IServiceProvider services)
        {
            return this.DefaultService.GenerateOption(optionMetadata, services);
        }

        /// <summary>
        /// Generates attributes.
        /// </summary>
        /// <param name="optionSetMetadata"><see cref="OptionSetMetadataBase" /> instance.</param>
        /// <param name="services"><see cref="IServiceProvider" /> instance.</param>
        /// <returns>Returns <c>True</c>, if successfully generated; otherwise returns <c>False</c>.</returns>
        public bool GenerateOptionSet(OptionSetMetadataBase optionSetMetadata, IServiceProvider services)
        {
            return this.DefaultService.GenerateOptionSet(optionSetMetadata, services);
        }

        /// <summary>
        /// Generates attributes.
        /// </summary>
        /// <param name="relationshipMetadata"><see cref="RelationshipMetadataBase" /> instance.</param>
        /// <param name="otherEntityMetadata"><see cref="EntityMetadata" /> instance.</param>
        /// <param name="services"><see cref="IServiceProvider" /> instance.</param>
        /// <returns>Returns <c>True</c>, if successfully generated; otherwise returns <c>False</c>.</returns>
        public bool GenerateRelationship(RelationshipMetadataBase relationshipMetadata, EntityMetadata otherEntityMetadata, IServiceProvider services)
        {
            return this.DefaultService.GenerateRelationship(relationshipMetadata, otherEntityMetadata, services);
        }

        /// <summary>
        /// Generates attributes.
        /// </summary>
        /// <param name="services"><see cref="IServiceProvider" /> instance.</param>
        /// <returns>Returns <c>True</c>, if successfully generated; otherwise returns <c>False</c>.</returns>
        public bool GenerateServiceContext(IServiceProvider services)
        {
            return this.DefaultService.GenerateServiceContext(services);
        }

        private bool IsValidEntity(string entityName)
        {
            var isValidEntity = this._collection.IsValidEntity(entityName);
            return isValidEntity;
        }
    }
}