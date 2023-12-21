﻿namespace GrooveHub.Models;

internal class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<Library> SavedLibraries { get; set; }
}
