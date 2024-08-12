
using TareasRestFull.Models;

namespace TareasRestFull.Services
{
   public interface ITareaService
    {
        Task<IEnumerable<Tarea>> GetTasksAsync();
        Task<Tarea> GetTaskByIdAsync(int id);
        Task<Tarea> CreateTaskAsync(Tarea task);
        Task<bool> UpdateTaskAsync(Tarea task);
        Task<bool> DeleteTaskAsync(int id);
    }
}