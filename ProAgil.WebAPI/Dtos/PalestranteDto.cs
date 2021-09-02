using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProAgil.WebAPI.Dtos
{
    public class PalestranteDto
    {
        public int id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string miniCurriculo { get; set; }
        public string imagemUrl { get; set; }
        [Phone(ErrorMessage = "O campo {0} não corresponde a um telefone válido")]
        public string telefone { get; set; }
        [EmailAddress(ErrorMessage = "O campo {0} não corresponde a um email válido")]
        public string email { get; set; }
        public List<RedeSocialDto> redesSociais { get; set; }
        public List<EventoDto> eventos { get; set; }
    }
}