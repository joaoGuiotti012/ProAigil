using System;
using System.Collections.Generic;

namespace ProAgil.Domain
{
    public class Evento
    {
        public int id { get; set; }
        public string local { get; set; }
        public DateTime dataEvento { get; set; }
        public string tema { get; set; }
        public int qtdPessoas { get; set; }
        public string imagemUrl { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public List<Lote> lotes { get; set; }
        public List<RedeSocial> redesSociais { get; set; }
        public List<PalestranteEvento> palestranteEventos { get; set; }

    }
}