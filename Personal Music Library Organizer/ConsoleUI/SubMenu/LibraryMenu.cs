using Spectre.Console;
using SyncWave.Interfaces;
using SyncWave.Models;
using SyncWave.Services;

namespace SyncWave.ConsoleUI.SubMenu;

public class LibraryMenu 
{
    private LibraryService libraryService;
    public LibraryMenu(LibraryService libraryService)
    {
        this.libraryService = libraryService;
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
                    Console.Clear();

                    var CName = AnsiConsole.Ask<string>("Enter Library's [green]Name[/]:");
                    var CGenre = AnsiConsole.Ask<string>("Enter Library's [green]Genre[/]:");

                    Library library = new Library();
                    library.Name = CName;
                    library.Genre = CGenre;

                    Library newLibrary = libraryService.Create(library);
                   
                    var table = new Table();

                    table.AddColumn("Created Library");

                    table.AddRow($"[green]LibraryID[/]: {newLibrary.Id}");
                    table.AddRow($"[green]Library's Name[/]: {newLibrary.Name}");
                    table.AddRow($"[green]Library's Genre[/]: {newLibrary.Genre}");

                    AnsiConsole.Write(table);
                   
                    break;
                case "Update library":
                    Console.Clear();
                    var Uid = AnsiConsole.Ask<int>("Enter Library's [green]ID[/]:");
                    var UName = AnsiConsole.Ask<string>("Enter Library's [green]Name[/]:");
                    var UGenre = AnsiConsole.Ask<string>("Enter Library's [green]Genre[/]:");

                    Library updatelibrary = new Library();
                    updatelibrary.Name = UName;
                    updatelibrary.Genre = UGenre;

                    Library updatedLibrary = libraryService.Update(updatelibrary);

                    if (updatedLibrary != null)
                    {
                        var table1 = new Table();

                        table1.AddColumn("Updated Library");

                        table1.AddRow($"[green]LibraryID[/]: {updatelibrary.Id}");
                        table1.AddRow($"[green]Library's Name[/]: {updatelibrary.Name}");
                        table1.AddRow($"[green]Library's Genre[/]: {updatelibrary.Genre}");

                        AnsiConsole.Write(table1);
                    }
                    else
                    {
                        var table2 = new Table();
                        table2.AddColumn("Updated Library");
                        table2.AddRow($"[green]Library with ID[/]: {Uid} not found");
                        AnsiConsole.Write(table2);

                        Console.WriteLine("Press any key to try again...");
                        Console.ReadLine();
                        continue;
                    }

                    break;
                case "Delete library":
                    Console.Clear();

                    var Did = AnsiConsole.Ask<int>("Enter Library's [green]ID[/]:");

                    bool deletedLibrary = libraryService.Delete(Did);
                    if (deletedLibrary != false)
                    {
                        var table3 = new Table();
                        table3.AddColumn("Deleted Library");
                        table3.AddRow($"[green]LibraryID[/]: {Did}");
                        AnsiConsole.Write(table3);
                    }
                    else
                    {
                        var table4 = new Table();
                        table4.AddColumn("Deleted Library");
                        table4.AddRow($"[green]Library with ID[/]: {Did} not found");
                        AnsiConsole.Write(table4);

                        Console.WriteLine("Press any key to try again...");
                        Console.ReadLine();
                        continue;
                    }
                    break;
                case "Get library":
                    Console.Clear();

                    var Gid = AnsiConsole.Ask<int>("Enter Library's [green]ID[/]:");

                    Library gottenLibrary = libraryService.GetLibrary(Gid);
                    if (gottenLibrary != null)
                    {
                        var table5 = new Table();
                        table5.AddColumn("Found Library");

                        table5.AddRow($"[green]LibraryID[/]: {gottenLibrary.Id}");
                        table5.AddRow($"[green]Library's Name[/]: {gottenLibrary.Name}");
                        table5.AddRow($"[green]Library's Genre[/]: {gottenLibrary.Genre}");
                        AnsiConsole.Write(table5);
                    }
                    else
                    {
                        var table6 = new Table();
                        table6.AddColumn("Found Library");
                        table6.AddRow($"[green]Library with ID[/]: {Gid} not found");
                        AnsiConsole.Write(table6);

                        Console.WriteLine("Press any key to try again...");
                        Console.ReadLine();
                        continue;
                    }
                    break;
                case "Get all libraries":
                    Console.Clear();
                    List<Library> getalllibraries = libraryService.GetAll();
                    if (getalllibraries.Count != 0)
                    {
                        foreach (Library item in getalllibraries)
                        {
                            var table7 = new Table();
                            table7.AddColumn("Found Library");

                            table7.AddRow($"[green]LibraryID[/]: {item.Id}");
                            table7.AddRow($"[green]Library's Name[/]: {item.Name}");
                            table7.AddRow($"[green]Library's Genre[/]: {item.Genre}");
                            AnsiConsole.Write(table7);
                        }
                    }
                    else
                    {
                        var table8 = new Table();
                        table8.AddColumn("Found Library");
                        table8.AddRow($"[red]Library List is empty[/]");
                        AnsiConsole.Write(table8);
                    }
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
