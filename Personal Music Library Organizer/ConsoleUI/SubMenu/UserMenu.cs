using Spectre.Console;
using SyncWave.Models;
using SyncWave.Services;

namespace SyncWave.ConsoleUI.SubMenu;

public class UserMenu
{
    private UserService userService;
    private LibraryService libraryService;
    public UserMenu(UserService userService, LibraryService libraryService)
    {
        this.userService = userService;
        this.libraryService = libraryService;
    }
    public void Display()
    {
        bool loop = true;
        while (loop)
        {
            var choise = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Sync[green]Wave[/][grey] / [/]Users")
                    .PageSize(8)
                    .AddChoices(new[] { 
                        "Create user", 
                        "Update user", 
                        "Delete user", 
                        "Get user", 
                        "Get all users", 
                        "Add Musiclibrary to user", 
                        "Remove MusicLibrary from user\n", 
                        "[red]Go back[/]"}));
            switch (choise)
            {
                case "Create user":
                    var Cfirstname = AnsiConsole.Ask<string>("Enter your [green]Firstname[/]:");
                    var Clastname = AnsiConsole.Ask<string>("Enter your [green]Lastname[/]:");

                    User user = new User();
                    user.FirstName = Cfirstname;
                    user.LastName = Clastname;

                    User createdUser = userService.Create(user);
                    // Create a table
                    var table = new Table();

                    // Add some columns
                    table.AddColumn("Created User");

                    // Add some rows
                    table.AddRow($"[green]UserID[/]: {createdUser.Id}");
                    table.AddRow($"[green]User's Firstname[/]: {createdUser.FirstName}");
                    table.AddRow($"[green]User's Firstname[/]: {createdUser.LastName}");

                    // Render the table to the console
                    AnsiConsole.Write(table);

                    break;
                case "Update user":
                    var Uid = AnsiConsole.Ask<int>("Enter your [green]ID[/]:");
                    var Ufirstname = AnsiConsole.Ask<string>("Enter your [green]Firstname[/]:");
                    var Ulastname = AnsiConsole.Ask<string>("Enter your [green]Lastname[/]:");

                    User Updateuser = new User();
                    Updateuser.FirstName = Ufirstname;
                    Updateuser.LastName = Ulastname;

                    User updatedUser = userService.Update(Updateuser);
                    // Create a table
                    var table1 = new Table();

                    // Add some columns
                    table1.AddColumn("Updated User");

                    // Add some rows
                    table1.AddRow($"[green]UserID[/]: {updatedUser.Id}");
                    table1.AddRow($"[green]User's Firstname[/]: {updatedUser.FirstName}");
                    table1.AddRow($"[green]User's Firstname[/]: {updatedUser.LastName}");

                    // Render the table to the console
                    AnsiConsole.Write(table1);
                    break;
                case "Delete user":
                    var Did = AnsiConsole.Ask<int>("Enter your [green]ID[/]:");

                    bool deletedUser = userService.Delete(Did);
                    if (deletedUser != false)
                    {
                        var table2 = new Table();
                        table2.AddColumn("Deleted User");
                        table2.AddRow($"[green]UserID[/]: {Did}");
                        AnsiConsole.Write(table2);
                    } else
                    {
                        var table3 = new Table();
                        table3.AddColumn("Deleted User");
                        table3.AddRow($"[green]User with ID[/]: {Did} not found");
                        AnsiConsole.Write(table3);

                        Console.WriteLine("Press any key to try again...");
                        Console.ReadLine();
                        continue;
                    }

                    break;
                case "Get user":
                    var Gid = AnsiConsole.Ask<int>("Enter your [green]ID[/]:");

                    User gottenUser = userService.Get(Gid);
                    if (gottenUser != null)
                    {
                        var table4 = new Table();
                        table4.AddColumn("Found User");
                        table4.AddRow($"[green]UserID[/]: {gottenUser.Id}");
                        table4.AddRow($"[green]User's Firstname[/]: {gottenUser.FirstName}");
                        table4.AddRow($"[green]User's Firstname[/]: {gottenUser.LastName}");
                        AnsiConsole.Write(table4);
                    }
                    else
                    {
                        var table5 = new Table();
                        table5.AddColumn("Found User");
                        table5.AddRow($"[green]User with ID[/]: {Gid} not found");
                        AnsiConsole.Write(table5);

                        Console.WriteLine("Press any key to try again...");
                        Console.ReadLine();
                        continue;
                    }
                    break;
                case "Get all users":

                    List<User> users = new List<User>();
                    if (users.Count != 0)
                    {
                        foreach (User item in userService.GetAll())
                        {
                            var table6 = new Table();
                            table6.AddColumn("Found User");
                            table6.AddRow($"[green]UserID[/]: {item.Id}");
                            table6.AddRow($"[green]User's Firstname[/]: {item.FirstName}");
                            table6.AddRow($"[green]User's Firstname[/]: {item.LastName}");
                            AnsiConsole.Write(table6);
                        }
                    } else
                    {
                        var table7 = new Table();
                        table7.AddColumn("Found User");
                        table7.AddRow($"[red]User's List is empty[/]");
                        AnsiConsole.Write(table7);
                    }

                    break;
                case "Add Musiclibrary to user":

                    break;
                case "Remove MusicLibrary from user\n":

                    break;
                case "[red]Go back[/]":
                    return;
            }
        }
    }
}
