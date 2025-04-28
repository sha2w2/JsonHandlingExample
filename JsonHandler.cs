using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

// Base User class
public class User
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
}

// Admin user specialization
public class AdminUser : User
{
    public string AccessLevel { get; set; } = "Full";
    public List<string> Permissions { get; set; } = new List<string>();
}

// Regular user specialization
public class RegularUser : User
{
    public bool IsVerified { get; set; }
    public DateTime MemberSince { get; set; }
}

class JsonHandler
{
    public static void AddUserToJson(string filePath, User newUser)
    {
        List<User> users;

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
            users = JsonConvert.DeserializeObject<List<User>>(json, settings) ?? new List<User>();
        }
        else
        {
            users = new List<User>();
        }

        users.Add(newUser);

        var updatedSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, Formatting = Formatting.Indented };
        string updatedJson = JsonConvert.SerializeObject(users, updatedSettings);
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

    public static void DisplayUsersWithTypes(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("No users file found.");
            return;
        }

        var settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto
        };

        string json = File.ReadAllText(filePath);
        List<User> users = JsonConvert.DeserializeObject<List<User>>(json, settings);

        Console.WriteLine("\nUsers with Types:");
        if (users != null)
        {
            foreach (var user in users)
            {
                Console.WriteLine($"Name: {user.Name}");
                Console.WriteLine($"Age: {user.Age}");
                Console.WriteLine($"City: {user.City}");

                if (user is AdminUser admin)
                {
                    Console.WriteLine($"Type: Admin");
                    Console.WriteLine($"Access Level: {admin.AccessLevel}");
                    Console.WriteLine($"Permissions: {string.Join(", ", admin.Permissions)}");
                }
                else if (user is RegularUser regular)
                {
                    Console.WriteLine($"Type: Regular User");
                    Console.WriteLine($"Verified: {regular.IsVerified}");
                    Console.WriteLine($"Member Since: {regular.MemberSince.ToShortDateString()}");
                }

                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("No user data found in the file.");
        }
    }
}