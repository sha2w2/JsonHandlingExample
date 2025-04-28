using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Initialize the JSON file path
            string jsonFilePath = "users_with_types.json";
            
            // 1. Create sample users
            var users = new List<User>
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

            // 2. Add users to JSON file
            Console.WriteLine("Adding users to JSON file...");
            foreach (var user in users)
            {
                JsonHandler.AddUserToJson(jsonFilePath, user);
                Console.WriteLine($"- Added {user.GetType().Name}: {user.Name}");
            }

            // 3. Display all users with type information
            Console.WriteLine("\nDisplaying all users:");
            JsonHandler.DisplayUsersWithTypes(jsonFilePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}