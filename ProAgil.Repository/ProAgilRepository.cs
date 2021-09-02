using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public class ProAgilRepository : IProAgilRepository
    {
        public ProAgilContext _context { get; }

        public ProAgilRepository(ProAgilContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        //GERAIS
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        //EVENTO
        public async Task<Evento[]> GetAllEventoAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(c => c.lotes)
                .Include(c => c.redesSociais);

            if (includePalestrantes)
            {
                query = query.
                    Include(p => p.palestranteEventos).
                    ThenInclude(p => p.palestrante);
            }

            query = query.OrderByDescending(c => c.id);

            return await query.ToArrayAsync();
        }
        public async Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(c => c.lotes)
                .Include(c => c.redesSociais);

            if (includePalestrantes)
            {
                query = query.
                    Include(p => p.palestranteEventos).
                    ThenInclude(p => p.palestrante);
            }

            query = query.OrderByDescending(c => c.dataEvento)
                .Where(c => c.tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Evento> GetAllEventoAsyncById(int EventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(c => c.lotes)
                .Include(c => c.redesSociais);

            if (includePalestrantes)
            {
                query = query.
                    Include(p => p.palestranteEventos).
                    ThenInclude(p => p.palestrante);
            }

            query = query.OrderBy(c => c.dataEvento)
                .Where(c => c.id == EventoId);

            return await query.FirstOrDefaultAsync();
        }


        //PALESTRANTE
        public async Task<Palestrante> GetPalestranteAsync(int PalestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(c => c.redesSociais);

            if (includeEventos)
            {
                query = query.
                    Include(p => p.palestranteEventos).
                    ThenInclude(p => p.evento);
            }

            query = query.OrderBy(p => p.nome)
                .Where(p => p.id == PalestranteId);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Palestrante[]> GetAllPalestrantesAsyncByName(string name, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(c => c.redesSociais);

            if (includeEventos)
            {
                query = query.
                    Include(p => p.palestranteEventos).
                    ThenInclude(p => p.evento);
            }

            query = query.Where(p => p.nome.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }

    }
}