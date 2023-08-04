using System; 

namespace BlazorToDoList.App.Models
{
    // Define the ToDoItem class to represent a single to-do item.
    public class ToDoItem
    {
        public Guid ID { get; set; } // A unique identifier for the to-do item.
        public string Description { get; set; } // The description or task of the to-do item.
        public bool IsComplete { get; set; } // A flag to indicate whether the task is completed or not.
        public DateTime DateCreated { get; set; } // The date and time when the to-do item was created.
    }
}
