using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TareasRestFull.Models;

[Table("Tarea")]
public  class Tarea {
    [Key]
    public int Id { get; set; }
    public string Title {get; set;}
    public string Description {get; set;}
    public DateTime CreatedAt { get; set;}
    public DateTime UpdatedAt   { get; set;}
}