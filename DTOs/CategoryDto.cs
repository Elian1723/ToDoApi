﻿namespace ToDoApi.DTOs;

public class CategoryDto
{
    public int CategoryId { get; set; }
    public string Name { get; set; } = null!;
    public int TodoCount { get; set; }
}