using BlazorToDoList.App.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace BlazorToDoList.App.Services
{
    /// <summary>
    /// Service responsible for reading and saving data from/to a file.
    /// </summary>
    public class FileService : IFileService
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor to initialize the FileService with the provided IConfiguration.
        /// </summary>
        /// <param name="configuration">The IConfiguration instance used to access configuration values.</param>
        public FileService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Read the contents of the file specified in the configuration.
        /// </summary>
        /// <returns>The content of the file as a string.</returns>
        public string ReadFromFile()
        {
            // Read all the text from the file specified in the configuration using the SampleDataFile key.
            return File.ReadAllText(_configuration["SampleDataFile"]);
        }

        /// <summary>
        /// Save the provided list of ToDoItems to a file specified in the configuration.
        /// </summary>
        /// <param name="toDoItems">The list of ToDoItems to be saved.</param>
        public void SaveToFile(List<ToDoItem> toDoItems)
        {
            // Serialize the list of ToDoItems to JSON format.
            string json = JsonConvert.SerializeObject(toDoItems);

            // Write the serialized JSON data to the file specified in the configuration using the SampleDataFile key.
            System.IO.File.WriteAllText(_configuration["SampleDataFile"], json);
        }
    }
}
