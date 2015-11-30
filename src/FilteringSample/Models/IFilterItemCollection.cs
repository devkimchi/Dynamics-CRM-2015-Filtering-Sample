namespace DevKimchi.FilteringSample.Models
{
    /// <summary>
    /// This provides interfaces to the <see cref="FilterItemCollection" /> class.
    /// </summary>
    public interface IFilterItemCollection
    {
        /// <summary>
        /// Checks whether the entity name belongs to the filter collection or not.
        /// </summary>
        /// <param name="entityName">Entity name.</param>
        /// <returns>Returns <c>True</c>, if the entity name belongs to the filter collection; otherwise returns <c>False</c>.</returns>
        bool IsValidEntity(string entityName);
    }
}