using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        const string JsonFilePath = "users_with_types.json";
        
        try
        {
            // Clear existing file if it exists to start fresh
            if (File.Exists(JsonFilePath))
            {
                File.Delete(JsonFilePath);
                Console.WriteLine("Cleared existing JSON file.");
            }

            // Create sample users
            var usersToAdd = new List<User>
            {
                new AdminUser 
                { 
                    Name = "Alice Smith", 
                    Age = 35, 
                    City = "New York", 
                    AccessLevel = "Super", 
                    Permissions = new List<string> { "Read", "Write", "Delete" } 
                },
                new RegularUser 
                { 
                    Name = "Charlie Brown", 
                    Age = 28, 
                    City = "Chicago", 
                    IsVerified = true, 
                    MemberSince = new DateTime(2024, 1, 15) 
                },
                new User 
                { 
                    Name = "Diana Lee", 
                    Age = 22, 
                    City = "Seattle" 
                }
            };

            // Add users to JSON file
            Console.WriteLine("\nAdding users to JSON file:");
            foreach (var user in usersToAdd)
            {
                JsonHandler.AddUserToJson(JsonFilePath, user);
                Console.WriteLine($"- Added {user.GetType().Name}: {user.Name}");
            }

            // Display all users with type information
            Console.WriteLine("\nCurrent users in JSON file:");
            JsonHandler.DisplayUsersWithTypes(JsonFilePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
            Console.WriteLine(ex.StackTrace);
        }
        finally
        {
            Console.WriteLine("\nProgram execution completed.");
        }
    }
}

public class User
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
}

public class AdminUser : User
{
    public string AccessLevel { get; set; }
    public List<string> Permissions { get; set; }
}

public class RegularUser : User
{
    public bool IsVerified { get; set; }
    public DateTime MemberSince { get; set; }
}

static class JsonHandler
{
    private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    {
        TypeNameHandling = TypeNameHandling.Auto,
        Formatting = Formatting.Indented
    };

    public static void AddUserToJson(string filePath, User newUser)
    {
        List<User> users = File.Exists(filePath)
            ? JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(filePath), Settings)
            : new List<User>();

        users.Add(newUser);
        File.WriteAllText(filePath, JsonConvert.SerializeObject(users, Settings));
    }

    public static void DisplayUsersWithTypes(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("No users file found.");
            return;
        }

        var users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(filePath), Settings);

        foreach (var user in users)
        {
            Console.WriteLine($"\nType: {user.GetType().Name}");
            Console.WriteLine($"Name: {user.Name}");
            Console.WriteLine($"Age: {user.Age}");
            Console.WriteLine($"City: {user.City}");

            switch (user)
            {
                case AdminUser admin:
                    Console.WriteLine($"Access Level: {admin.AccessLevel}");
                    Console.WriteLine($"Permissions: {string.Join(", ", admin.Permissions)}");
                    break;
                
                case RegularUser regular:
                    Console.WriteLine($"Verified: {regular.IsVerified}");
                    Console.WriteLine($"Member Since: {regular.MemberSince:d}");
                    break;
            }
        }
    }
}