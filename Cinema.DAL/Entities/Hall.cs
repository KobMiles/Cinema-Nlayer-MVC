﻿namespace Cinema.DAL.Entities;

public class Hall
{
    public int Id { get; set; }

    public ICollection<Session> Sessions { get; set; } = [];
}
