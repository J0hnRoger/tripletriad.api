﻿namespace TripleTriad.Api.Models;

public class CreateCardRequest
{
    public string Name { get; set; }
    public int Top  { get; set; }
    public int Bottom  { get; set; }
    public int Left  { get; set; }
    public int Right  { get; set; }
    public string ImageUrl { get; set; }
}