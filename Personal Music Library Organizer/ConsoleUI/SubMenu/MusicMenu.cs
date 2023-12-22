using Spectre.Console;
using SyncWave.Models;
using SyncWave.Services;

namespace SyncWave.ConsoleUI.SubMenu;

public class MusicMenu
{
    private MusicService musicService;
    public MusicMenu(MusicService musicService)
    {
        this.musicService= musicService;
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
                    Console.Clear();

                    var CName = AnsiConsole.Ask<string>("Enter music's [green]Name[/]:");
                    var CAuthor = AnsiConsole.Ask<string>("Enter music's [green]Author[/]:");
                    var CGenre = AnsiConsole.Ask<string>("Enter music's [green]Genre[/]:");

                    Music music = new Music();
                    music.Name = CName;
                    music.Author = CAuthor;
                    music.Genre = CGenre;

                    Music newMusic = musicService.Create(music);
                    // Create a table
                    var table = new Table();

                    // Add some columns
                    table.AddColumn("Created Music");

                    // Add some rows
                    table.AddRow($"[green]MusicID[/]: {newMusic.Id}");
                    table.AddRow($"[green]Music's Name[/]: {newMusic.Name}");
                    table.AddRow($"[green]Music's Author[/]: {newMusic.Author}");
                    table.AddRow($"[green]Music's Genre[/]: {newMusic.Genre}");

                    // Render the table to the console
                    AnsiConsole.Write(table);

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
