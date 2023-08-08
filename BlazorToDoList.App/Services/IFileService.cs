using BlazorToDoList.App.Models;
using System.Collections.Generic;

namespace BlazorToDoList.App.Services
{
    /// <summary>
    /// Interface for a service responsible for reading and saving data from/to a file.
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Read the contents of the file and return it as a string.
        /// </summary>
        /// <returns>The content of the file as a string.</returns>
        string ReadFromFile();

        /// <summary>
        /// Save the provided list of ToDoItems to a file.
        /// </summary>
        /// <param name="toDoItems">The list of ToDoItems to be saved.</param>
        void SaveToFile(List<ToDoItem> toDoItems);
    }
}
