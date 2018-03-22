using System.Collections.Generic;

namespace MSK.Core.Module.ESAPI.ObjectReference
{
    /// <summary>
    /// The IAccessReferenceMap interface is used to map from a set of internal direct object references to a 
    /// set of indirect references that are safe to disclose publicly. This can be used to help protect database 
    /// keys, filenames, and other types of direct object references.
    /// </summary>
    public interface IAccessReferenceMap
    {
        /// <summary> 
        /// Get a safe indirect reference to use in place of a potentially sensitive
        /// direct object reference.
        /// </summary>
        /// <param name="directReference">The direct reference.</param>
        /// <returns> The indirect reference.</returns>
        string GetIndirectReference(object directReference);

        /// <summary> 
        /// Get the original direct object reference from an indirect reference.
        /// Developers should use this when they get an indirect reference to translate
        /// it back into the real direct reference. If an
        /// invalid indirectReference is requested, then an AccessControlException is
        /// thrown.
        /// </summary>
        /// <param name="indirectReference">The indirect reference.</param>
        /// <returns> The direct reference.</returns>
        object GetDirectReference(string indirectReference);

        /// <summary> Returns a collection of the indirect object references.</summary>
        /// <returns> The collection of indirect object references.</returns>        
        ICollection<T> GetIndirectReferences<T>();

        /// <summary> Returns a collection of the direct object references.</summary>
        /// <returns> The collection of direct object references.</returns>
		ICollection<T> GetDirectReferences<T>();

        /// <summary> Adds a direct reference and a new random indirect reference, overwriting any existing values.</summary>
        /// <param name="direct"> The direct reference to add.</param>
        string AddDirectReference(object direct);

        /// <summary> Remove a direct reference and the corresponding indirect reference.</summary>
        /// <param name="direct">The direct reference.</param>
        string RemoveDirectReference(object direct);

        /// <summary> 
        /// Update the refrences. This preserves any existing mappings for items that are still in the new
        /// list. You could regenerate new indirect references every time, but that might break anything 
        /// that previously used an indirect reference, such as a URL parameter.
        /// </summary>
        /// <param name="directReferences">The direct references.</param>
        void Update<T>(ICollection<T> directReferences);
    }
}