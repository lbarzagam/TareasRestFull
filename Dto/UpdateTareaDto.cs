using System.ComponentModel.DataAnnotations;

namespace TareasRestFull.Dto
{
    public class UpdateTareaDto
    {
        [Required(ErrorMessage = "El campo Id es obligatorio para actualizar la tarea")]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? UpdatedAt = DateTime.Now;
    }
}