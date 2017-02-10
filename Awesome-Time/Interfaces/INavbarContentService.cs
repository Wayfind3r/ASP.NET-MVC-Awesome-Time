using Awesome_Time.NavbarContentServiceClasses;
using System.Collections.Generic;

namespace Awesome_Time.Interfaces
{
    public interface INavbarContentService
    {
        /// <summary>
        /// Creates a new element and returns the Id. Returns 0, if element was not created.
        /// </summary>
        int CreateElement(NavbarNewElementViewModel newEntity);
        /// <summary>
        /// Returns true, if an element with that Id exists or the id is null.
        /// </summary>
        bool DoesElementExistOrIsNull(int? id);
        /// <summary>
        /// Deletes an element by Id and returns true, if successful.
        /// </summary>
        bool DeleteElement(int id);
        /// <summary>
        /// Makes changes to a given entity and returns true, if successful.
        /// </summary>
        bool EditElement(NavbarSingleElementViewModel target);
        /// <summary>
        /// Returns all navbar elements in a structured format or child elements of a given parent.
        /// </summary>
        List<NavbarElementViewModel> GetElements(int? parentId = null);
    }
}