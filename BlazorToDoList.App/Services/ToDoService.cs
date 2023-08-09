using BlazorToDoList.App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorToDoList.App.Services
{
    /// <summary>
    /// This service class handles the management of ToDoItems.
    /// </summary>
    public class ToDoService : IToDoService
    {
        private readonly IFileService _fileService; // A reference to the file service.
        private List<ToDoItem> _toDoItems; // A list to hold ToDoItems.

        /// <summary>
        /// Initializes a new instance of the ToDoService class.
        /// </summary>
        /// <param name="fileService">An instance of the file service.</param>
        public ToDoService(IFileService fileService)
        {
            _fileService = fileService; // Inject the file service dependency.
        }

        /// <summary>
        /// Retrieves a list of all ToDoItems.
        /// </summary>
        public List<ToDoItem> Get()
        {
            // Read JSON data from the file, deserialize it into a list of ToDoItems.
            string json = _fileService.ReadFromFile();
            _toDoItems = JsonConvert.DeserializeObject<List<ToDoItem>>(json);
            return _toDoItems; // Return the list of ToDoItems.
        }

        /// <summary>
        /// Retrieves a ToDoItem by its unique ID.
        /// </summary>
        /// <param name="ID">The unique ID of the ToDoItem.</param>
        public ToDoItem Get(Guid ID)
        {
            // Find and return the ToDoItem with the specified ID.
            return _toDoItems.First(x => x.ID == ID);
        }

        /// <summary>
        /// Adds a new ToDoItem to the list.
        /// </summary>
        /// <param name="toDoItem">The ToDoItem to be added.</param>
        public List<ToDoItem> Add(ToDoItem toDoItem)
        {
            _toDoItems.Add(toDoItem);
            _fileService.SaveToFile(_toDoItems); 
            return _toDoItems; 
        }

        /// <summary>
        /// Toggles the completion status of a ToDoItem.
        /// </summary>
        /// <param name="ID">The unique ID of the ToDoItem to be toggled.</param>
        public List<ToDoItem> Toggle(Guid ID)
        {
            var toDoItemToUpdate = Get(ID);

            // Toggle the IsComplete status of the specified ToDoItem.
            if (toDoItemToUpdate != null)
            {
                toDoItemToUpdate.IsComplete = !toDoItemToUpdate.IsComplete;
                _fileService.SaveToFile(_toDoItems); 
            }

            return _toDoItems; 
        }

        /// <summary>
        /// Deletes a ToDoItem by its unique ID.
        /// </summary>
        /// <param name="ID">The unique ID of the ToDoItem to be deleted.</param>
        public List<ToDoItem> Delete(Guid ID)
        {
            var toDoItemToRemove = Get(ID);

            if (toDoItemToRemove != null)
            {
                _toDoItems.Remove(Get(ID)); 
                _fileService.SaveToFile(_toDoItems); 
            }

            return _toDoItems; 
        }
    }
}
