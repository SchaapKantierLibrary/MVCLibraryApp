namespace MVCLibraryApp.ViewModels;
using System.ComponentModel.DataAnnotations;

public class AuteurViewModel
{
    public int ID { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Bio { get; set; }
}
