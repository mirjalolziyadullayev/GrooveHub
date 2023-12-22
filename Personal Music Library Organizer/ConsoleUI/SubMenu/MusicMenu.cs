using Spectre.Console;
using SyncWave.Models;
using SyncWave.Services;

namespace SyncWave.ConsoleUI.SubMenu;

public class MusicMenu
{
    private MusicService musicService;
    public MusicMenu(MusicService musicService)
    {
        this.musicService = musicService;
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

                    var table = new Table();

                    table.AddColumn("Created Music");

                    table.AddRow($"[green]MusicID[/]: {newMusic.Id}");
                    table.AddRow($"[green]Music's Name[/]: {newMusic.Name}");
                    table.AddRow($"[green]Music's Author[/]: {newMusic.Author}");
                    table.AddRow($"[green]Music's Genre[/]: {newMusic.Genre}");

                    AnsiConsole.Write(table);

                    break;
                case "Update music":
                    Console.Clear();
                    var Uid = AnsiConsole.Ask<int>("Enter music's [green]ID[/]:");
                    var UName = AnsiConsole.Ask<string>("Enter music's [green]Name[/]:");
                    var UAuthor = AnsiConsole.Ask<string>("Enter music's [green]Author[/]:");
                    var UGenre = AnsiConsole.Ask<string>("Enter music's [green]Genre[/]:");

                    Music Umusic = new Music();
                    Umusic.Id = Uid;
                    Umusic.Name = UName;
                    Umusic.Author = UAuthor;
                    Umusic.Genre = UGenre;

                    Music UpdatedMusic = musicService.Update(Umusic);
                    if (UpdatedMusic != null)
                    {
                        var table1 = new Table();

                        table1.AddColumn("Updated Music");

                        table1.AddRow($"[green]MusicID[/]: {UpdatedMusic.Id}");
                        table1.AddRow($"[green]Music's Name[/]: {UpdatedMusic.Name}");
                        table1.AddRow($"[green]Music's Author[/]: {UpdatedMusic.Author}");
                        table1.AddRow($"[green]Music's Genre[/]: {UpdatedMusic.Genre}");

                        AnsiConsole.Write(table1);
                    }
                    else
                    {
                        var table2 = new Table();
                        table2.AddColumn("Updated Music");
                        table2.AddRow($"[green]Music with ID[/]: {Uid} not found");
                        AnsiConsole.Write(table2);

                        Console.WriteLine("Press any key to try again...");
                        Console.ReadLine();
                        continue;
                    }

                    break;
                case "Delete music":
                    Console.Clear();

                    var Did = AnsiConsole.Ask<int>("Enter music's [green]ID[/]:");

                    bool deletedMusic = musicService.Delete(Did);
                    if (deletedMusic != false)
                    {
                        var table3 = new Table();
                        table3.AddColumn("Deleted Music");
                        table3.AddRow($"[green]MusicID[/]: {Did}");
                        AnsiConsole.Write(table3);
                    }
                    else
                    {
                        var table4 = new Table();
                        table4.AddColumn("Deleted Music");
                        table4.AddRow($"[green]Music with ID[/]: {Did} not found");
                        AnsiConsole.Write(table4);

                        Console.WriteLine("Press any key to try again...");
                        Console.ReadLine();
                        continue;
                    }
                    break;
                case "Get music":
                    Console.Clear();

                    var Gid = AnsiConsole.Ask<int>("Enter music's [green]ID[/]:");

                    Music gottenMusic = musicService.GetMusic(Gid);
                    if (gottenMusic != null)
                    {
                        var table4 = new Table();
                        table4.AddColumn("Found Music");

                        table4.AddRow($"[green]MusicID[/]: {gottenMusic.Id}");
                        table4.AddRow($"[green]Music's Name[/]: {gottenMusic.Name}");
                        table4.AddRow($"[green]Music's Author[/]: {gottenMusic.Author}");
                        table4.AddRow($"[green]Music's Genre[/]: {gottenMusic.Genre}");
                        AnsiConsole.Write(table4);
                    }
                    else
                    {
                        var table5 = new Table();
                        table5.AddColumn("Found Music");
                        table5.AddRow($"[green]Music with ID[/]: {Gid} not found");
                        AnsiConsole.Write(table5);

                        Console.WriteLine("Press any key to try again...");
                        Console.ReadLine();
                        continue;
                    }
                    break;
                case "Get all musics":
                    Console.Clear();
                    List<Music> getallmusics = musicService.GetAll();
                    if (getallmusics.Count != 0)
                    {
                        foreach (Music item in getallmusics)
                        {
                            var table6 = new Table();
                            table6.AddColumn("Found Music");

                            table6.AddRow($"[green]MusicID[/]: {item.Id}");
                            table6.AddRow($"[green]Music's Name[/]: {item.Name}");
                            table6.AddRow($"[green]Music's Author[/]: {item.Author}");
                            table6.AddRow($"[green]Music's Genre[/]: {item.Genre}");
                            AnsiConsole.Write(table6);
                        }
                    }
                    else
                    {
                        var table7 = new Table();
                        table7.AddColumn("Found Music");
                        table7.AddRow($"[red]Music List is empty[/]");
                        AnsiConsole.Write(table7);
                    }
                    break;
                case "Get all musics by genre\n":
                    Console.Clear();
                    var Ggenre = AnsiConsole.Ask<string>("Enter music's [green]Genre[/]:");

                    List<Music> getallmusicsbygenre = musicService.GetAllByGenre(Ggenre);
                    if (getallmusicsbygenre.Count != 0)
                    {
                        foreach (Music item in getallmusicsbygenre)
                        {
                            var table8 = new Table();
                            table8.AddColumn("Found Music");

                            table8.AddRow($"[green]MusicID[/]: {item.Id}");
                            table8.AddRow($"[green]Music's Name[/]: {item.Name}");
                            table8.AddRow($"[green]Music's Author[/]: {item.Author}");
                            table8.AddRow($"[green]Music's Genre[/]: {item.Genre}");
                            AnsiConsole.Write(table8);
                        }
                    }
                    else
                    {
                        var table9 = new Table();
                        table9.AddColumn("Found Music");
                        table9.AddRow($"[red]Wrong, Genre name![/] MusicList with genre: {Ggenre} not generated");
                        AnsiConsole.Write(table9);

                        Console.WriteLine("Press any key to try again...");
                        Console.ReadLine();
                        continue;
                    }
                    break;
                case "[red]Go back[/]":
                    return;
            }
        }
    }
}
