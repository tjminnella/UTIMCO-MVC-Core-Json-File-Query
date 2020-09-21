using System;
using System.IO;
using System.Collections.Generic;
using UTIMCO.Models;
using UTIMCO.ViewModel;
using Newtonsoft.Json;
using System.Linq;

namespace UTIMCO.Utilities
{
    public static class Utility
    {
        public static string ProcessUploadedFile(JsonEvaluateViewModel model, string directoryPath)
        {
            string uniqueFileName = null;
            if (model.JsonFile != null)
            {
                string uploadsFolder = Path.Combine(directoryPath, "Json");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.JsonFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                //using disposes file stream properly
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.JsonFile.CopyTo(fileStream);
                }
                uniqueFileName = filePath;
            }
            return uniqueFileName;
        }

        public static List<MyArray> GetMenus(string path)
        {
            string jsonString = File.ReadAllText(path);
            return GetJsonMenus(jsonString);
        }

        public static List<MyArray> GetJsonMenus(string jsonString)
        {
            List<MyArray> root = JsonConvert.DeserializeObject<List<MyArray>>(jsonString);
            return root;
        }

        public static List<ResultLine> GetResults(List<MyArray> root)
        {
            List<ResultLine>  results = new List<ResultLine>();
            foreach (MyArray myArray in root)
            {
                //get all the valid items
                List<Item> allItems = myArray.menu.items.Where(x => x != null).ToList();
                ResultLine rl = new ResultLine
                {
                    Name = myArray.menu.header,
                    TotalId = (from item in allItems
                               where item.label != null && !item.label.Equals(string.Empty)
                               select item.id).Sum()
                };
                results.Add(rl);
            }
            return results;
        }
    }
}
