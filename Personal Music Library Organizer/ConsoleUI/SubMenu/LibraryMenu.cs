using Spectre.Console;

namespace SyncWave.ConsoleUI.SubMenu;

public class LibraryMenu 
{
    public LibraryMenu()
    {
        
    }
    public void Display()
    {
        bool loop = true;
        while (loop)
        {
            var choise = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Sync[green]Wave[/][grey] / [/]Music")
                    .PageSize(8)
                    .AddChoices(new[] {
                        "Create library",
                        "Update library",
                        "Delete library",
                        "Get library",
                        "Get all libraries",
                        "Add music to library",
                        "Remove music from library\n",
                        "[red]Go back[/]"}));
            switch (choise)
            {
                case "Create library":

                    break;
                case "Update library":

                    break;
                case "Delete library":

                    break;
                case "Get library":

                    break;
                case "Get all libraries":

                    break;
                case "Add music to library":

                    break;
                case "Remove music from library\n":

                    break;
                case "[red]Go back[/]":
                    return;
            }
        }
    }
}
