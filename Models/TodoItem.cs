using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models;

public class TodoItem
{
    [Required]
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; } = false;
}