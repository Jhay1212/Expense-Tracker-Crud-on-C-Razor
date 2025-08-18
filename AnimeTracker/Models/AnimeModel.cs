using System;
using System.ComponentModel.DataAnnotations;

namespace AnimeTracker.Models;

public class Anime
{
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    [Required]
    public required string Genre { get; set; }

    [Required]
    public required bool Status { get; set; }

    public DateOnly? LastWatched { get; set; }

    public Anime(string name, string genre)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be null or empty.", nameof(name));
        if (string.IsNullOrWhiteSpace(genre))
            throw new ArgumentException("Genre cannot be null or empty.", nameof(genre));

        Name = name;
        Genre = genre;
    }
}