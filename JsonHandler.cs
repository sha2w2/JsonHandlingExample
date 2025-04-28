using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

public class User
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
}

class JsonHandler
{
    public static void AddUserToJson(string filePath, User newUser)
    {
        List<User> users;
        
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            users = JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();
        }
        else
        {
            users = new List<User>();
        }

        users.Add(newUser);
        
        string updatedJson = JsonConvert.SerializeObject(users, Formatting.Indented);
        File.WriteAllText(filePath, updatedJson);
    }
}