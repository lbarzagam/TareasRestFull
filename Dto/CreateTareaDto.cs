namespace TareasRestFull.Dto;

using System.ComponentModel.DataAnnotations;

public class CreateTareaDto {

    [Required(ErrorMessage = "Debe completar el campo Título")]
    [MinLength(5, ErrorMessage = "El Titulo debe contener al menos 5 caracteres")]
    [MaxLength(100, ErrorMessage = "La longitud del titulo no debe ser mayor a 100 caracteres")]
    public required string Title { get; set;}

    [Required(ErrorMessage = "Debe completar el campo descripción")]
    public required string Description { get; set;}  

    public DateTime CreatedAt = DateTime.Now;
}