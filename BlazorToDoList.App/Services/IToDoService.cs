using BlazorToDoList.App.Models;
using System;
using System.Collections.Generic;

namespace BlazorToDoList.App.Services
{
    /// <summary>
    /// Interface for a service responsible for managing ToDoItems.
    /// </summary>
    public interface IToDoService
    {
        /// <summary>
        /// Get a list of all ToDoItems.
        /// </summary>
        /// <returns>A list of ToDoItems.</returns>
        List<ToDoItem> Get();

        /// <summary>
        /// Get a specific ToDoItem by its ID.
        /// </summary>
        /// <param name="ID">The ID of the ToDoItem to retrieve.</param>
        /// <returns>The ToDoItem with the specified ID, or null if not found.</returns>
        ToDoItem Get(Guid ID);

        /// <summary>
        /// Add a new ToDoItem to the list of ToDoItems.
        /// </summary>
        /// <param name="toDoItem">The ToDoItem to add.</param>
        /// <returns>The updated list of ToDoItems.</returns>
        List<ToDoItem> Add(ToDoItem toDoItem);

        /// <summary>
        /// Toggle the IsComplete status of a ToDoItem.
        /// </summary>
        /// <param name="id">The ID of the ToDoItem to toggle.</param>
        /// <returns>The updated list of ToDoItems.</returns>
        List<ToDoItem> Toggle(Guid id);

        /// <summary>
        /// Delete a ToDoItem with the specified ID from the list of ToDoItems.
        /// </summary>
        /// <param name="ID">The ID of the ToDoItem to delete.</param>
        /// <returns>The updated list of ToDoItems.</returns>
        List<ToDoItem> Delete(Guid ID);
    }
}
