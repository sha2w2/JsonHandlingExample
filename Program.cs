using System;

class Program
{
    static void Main(string[] args)
    {
        // Add new user
        var newUser = new User { Name = "Bob Johnson", Age = 40, City = "Los Angeles" };
        JsonHandler.AddUserToJson("users.json", newUser);
        Console.WriteLine("Added new user to users.json");

        // Display all users
        JsonHandler.DisplayAllUsers("users.json");
    }
}
