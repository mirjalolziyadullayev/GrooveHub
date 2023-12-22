using Spectre.Console;

namespace SyncWave.ConsoleUI.SubMenu;

public class MusicMenu
{
    public MusicMenu()
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
                    .PageSize(7)
                    .AddChoices(new[] {
                        "Create music",
                        "Update music",
                        "Delete music",
                        "Get music",
                        "Get all musics",
                        "Get all musics by genre\n",
                        "[red]Go back[/]"}));
            switch (choise)
            {
                case "Create music":

                    break;
                case "Update music":

                    break;
                case "Delete music":

                    break;
                case "Get music":

                    break;
                case "Get all musics":

                    break;
                case "Get all musics by genre\n":

                    break;
                case "[red]Go back[/]":
                    return;
            }
        }
    }
}
