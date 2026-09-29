using System.ComponentModel.DataAnnotations;

namespace SupportWebApp.Models;

public class SupportMessage
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Required]
    public string Category { get; set; } = string.Empty;

    [Required]
    public string Customer { get; set; } = string.Empty;

    [Required]
    public string Subject { get; set; } = string.Empty;

    [Required]
    public string Status { get; set; } = "Open";
}