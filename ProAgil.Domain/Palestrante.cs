using System.Collections.Generic;

namespace ProAgil.Domain
{
    public class Palestrante
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string  miniCurriculo { get; set; }
        public string imagemUrl { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public List<RedeSocial> redesSociais { get; set; }
        public List<PalestranteEvento> palestranteEventos { get; set; }

    }
}