
using Microsoft.EntityFrameworkCore;
using TareasRestFull.Models;

namespace TareasRestFull.Services
{
    public class TareaService : ITareaService
    {
        private readonly TareasDbContext _context;

        public TareaService(TareasDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tarea>> GetTasksAsync()
        {
            return await _context.TareaItems.ToListAsync();
        }

        public async Task<Tarea> GetTaskByIdAsync(int id)
        {
            return await _context.TareaItems.FindAsync(id);
        }

        public async Task<Tarea> CreateTaskAsync(Tarea task)
        {
            _context.TareaItems.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<bool> UpdateTaskAsync(Tarea task)
        {
            _context.Entry(task).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskItemExists(task.Id))
                {
                    return false;
                }
                throw;
            }
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var task = await _context.TareaItems.FindAsync(id);
            if (task == null)
            {
                return false;
            }

            _context.TareaItems.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool TaskItemExists(int id)
        {
            return _context.TareaItems.Any(e => e.Id == id);
        }
    }
}