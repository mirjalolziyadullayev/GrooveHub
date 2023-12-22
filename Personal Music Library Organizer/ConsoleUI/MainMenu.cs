using SyncWave.ConsoleUI.SubMenu;
using SyncWave.Services;
using Spectre.Console;
using System.Net.Http.Headers;

namespace SyncWave.ConsoleUI;

public class MainMenu
{
    private UserService userService;
    private LibraryService libraryService;
    private MusicService musicService;

    private UserMenu userMenu;
    private LibraryMenu libraryMenu;
    private MusicMenu musicMenu;

    public MainMenu()
    {
        userService = new UserService(libraryService);
        libraryService = new LibraryService(musicService);
        musicService = new MusicService();

        userMenu = new UserMenu(userService, libraryService);
        libraryMenu = new LibraryMenu();
        musicMenu = new MusicMenu();
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

            switch(choise)
            {
                case "Manage users":
                    userMenu.Display();
                    break;
                case "Manage libraries":
                    libraryMenu.Display();
                    break;
                case "Manage musics":
                    musicMenu.Display();
                    break;
                case "[red]Exit[/]":
                    return;
            }
        }
    }
}
