using System.Threading.Tasks;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public interface IProAgilRepository
    {

        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T[] entity) where T : class;
        void SaveChanges();
        Task<bool> SaveChangesAsync();
        void Save(Evento evento);

        //EVENTOS
        Task<Evento[]> GetAllEventoAsync(bool includePalestrantes);
        Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool includePalestrantes);
        Task<Evento> GetEventosAsyncById(int EventoId, bool includePalestrantes);


        //PALESTRANTE
        Task<Palestrante> GetPalestranteAsync(int PalestranteId, bool includeEventos);
        Task<Palestrante[]> GetAllPalestrantesAsyncByName(string name, bool includeEventos);


    }
}