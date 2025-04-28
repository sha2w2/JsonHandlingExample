using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Add new users with type information
        var adminUser = new AdminUser { Name = "Alice Smith", Age = 35, City = "New York", AccessLevel = "Super", Permissions = new List<string> { "Read", "Write", "Delete" } };
        JsonHandler.AddUserToJson("users_with_types.json", adminUser);
        Console.WriteLine("Added new admin user to users_with_types.json");

        var regularUser = new RegularUser { Name = "Charlie Brown", Age = 28, City = "Chicago", IsVerified = true, MemberSince = new DateTime(2024, 1, 15) };
        JsonHandler.AddUserToJson("users_with_types.json", regularUser);
        Console.WriteLine("Added new regular user to users_with_types.json");

        var basicUser = new User { Name = "Diana Lee", Age = 22, City = "Seattle" };
        JsonHandler.AddUserToJson("users_with_types.json", basicUser);
        Console.WriteLine("Added new basic user to users_with_types.json");

        // Display users with types
        JsonHandler.DisplayUsersWithTypes("users_with_types.json");
    }
}