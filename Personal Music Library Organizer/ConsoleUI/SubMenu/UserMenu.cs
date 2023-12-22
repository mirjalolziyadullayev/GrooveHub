using Spectre.Console;

namespace SyncWave.ConsoleUI.SubMenu;

public class UserMenu
{
    public UserMenu()
    {
        
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

                    break;
                case "Update user":
                    
                    break;
                case "Delete user":

                    break;
                case "Get user":

                    break;
                case "Get all users":

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
