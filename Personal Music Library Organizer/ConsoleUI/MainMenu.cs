using Spectre.Console;
using SyncWave.ConsoleUI.SubMenu;
using SyncWave.Services;

namespace SyncWave.ConsoleUI;

public class MainMenu
{
    private UserService userService;
    private LibraryService libraryService;
    private MusicService musicService;

    private readonly UserMenu userMenu;
    private readonly LibraryMenu libraryMenu;
    private readonly MusicMenu musicMenu;

    public MainMenu()
    {
        musicService = new MusicService();
        libraryService = new LibraryService(musicService);
        userService = new UserService(libraryService);

        userMenu = new UserMenu(userService, libraryService);
        libraryMenu = new LibraryMenu(libraryService);
        musicMenu = new MusicMenu(musicService);
    }

    public void Display()
    {
        bool loop = true;
        while (loop)
        {
            var choise = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Sync[green]Wave[/]")
                    .PageSize(4)
                    .AddChoices(new[] {
                        "Manage users",
                        "Manage libraries",
                        "Manage musics\n",
                        "[red]Exit[/]"}));

            switch (choise)
            {
                case "Manage users":
                    userMenu.Display();
                    break;
                case "Manage libraries":
                    libraryMenu.Display();
                    break;
                case "Manage musics\n":
                    musicMenu.Display();
                    break;
                case "[red]Exit[/]":
                    return;
            }
        }
    }
}
