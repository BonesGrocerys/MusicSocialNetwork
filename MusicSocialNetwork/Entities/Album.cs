﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicSocialNetwork.Entities;

public class Album
{
    [Key]
    public int Id { get; set; }
    [Column("album_title")]
    public string AlbumTitle { get; set; }

    [Column("release_date")]
    public DateOnly ReleaseDate { get; set; }
    [Column("status")]
    public string Status { get; set; }
    [Column("auditions_count")]
    public int AuditionsCount { get; set; }
    public List<Genre> Genres { get; set; }
    public List<Track> TracksId { get; set; }
    public List<Musician> Musicians { get; set; }
    public List<Person> Persons { get; set; }
    

}

