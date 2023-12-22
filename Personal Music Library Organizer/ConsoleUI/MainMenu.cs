using SyncWave.ConsoleUI.SubMenu;
using SyncWave.Services;
using Spectre.Console;

namespace SyncWave.ConsoleUI;

internal class MainMenu
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

        musicMenu = new MusicMenu();
        libraryMenu = new LibraryMenu();
        musicMenu = new MusicMenu();


    }

    public void Display()
    {
        bool loop = false;
        while (true)
        {
            var table = new Table();

            
            var choise = AnsiConsole.Prompt(

            new SelectionPrompt<string>()
            .Title("[grey] Groove[/][yellow]Hub[/]")
            .PageSize(10)
            .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
            .AddChoices(new[] {
            "Apple", "Apricot", "Avocado",
            "Banana", "Blackcurrant", "Blueberry",
            "Cherry", "Cloudberry", "Cocunut",
            }));

            // Echo the fruit back to the terminal
            AnsiConsole.WriteLine($"I agree. {choise} is tasty!");
        }
    }
}
