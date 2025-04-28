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

    public static void DisplayAllUsers(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("No users file found.");
            return;
        }

        string json = File.ReadAllText(filePath);
        List<User> users = JsonConvert.DeserializeObject<List<User>>(json);

        Console.WriteLine("\nAll Users:");
        if (users != null)
        {
            foreach (var user in users)
            {
                Console.WriteLine($"Name: {user.Name}");
                Console.WriteLine($"Age: {user.Age}");
                Console.WriteLine($"City: {user.City}\n");
            }
        }
        else
        {
            Console.WriteLine("No user data found in the file.");
        }
    }
}