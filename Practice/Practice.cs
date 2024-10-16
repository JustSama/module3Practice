using System;
using System.Collections.Generic;

public class User
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }

    public User(string name, string email, string role)
    {
        Name = name;
        Email = email;
        Role = role;
    }
}

public class UserManager
{
    private List<User> users = new List<User>();

    public void AddUser(string name, string email, string role)
    {
        users.Add(new User(name, email, role));
    }

    public void RemoveUser(string email)
    {
        users.RemoveAll(u => u.Email == email);
    }

    public void UpdateUser(string email, string newName, string newRole)
    {
        User user = users.Find(u => u.Email == email);
        if (user != null)
        {
            user.Name = newName;
            user.Role = newRole;
        }
    }

    public void DisplayUsers()
    {
        foreach (var user in users)
        {
            Console.WriteLine($"Name: {user.Name}, Email: {user.Email}, Role: {user.Role}");
        }
    }
}

public class Program
{
    public static void Main()
    {
        UserManager userManager = new UserManager();
        userManager.AddUser("Samat", "samat@example.com", "Admin");
        userManager.AddUser("Aza", "Aza@example.com", "User");

        Console.WriteLine("Users after adding:");
        userManager.DisplayUsers();

        userManager.UpdateUser("samat@example.com", "Samat Smith", "Super Admin");
        Console.WriteLine("\nUsers after updating Samat:");
        userManager.DisplayUsers();

        userManager.RemoveUser("Aza@example.com");
        Console.WriteLine("\nUsers after removing Aza:");
        userManager.DisplayUsers();
    }
}
