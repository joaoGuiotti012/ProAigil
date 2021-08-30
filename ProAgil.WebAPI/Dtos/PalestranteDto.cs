using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProAgil.WebAPI.Dtos
{
    public class PalestranteDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string MiniCurriculo { get; set; }
        public string ImagemUrl { get; set; }
        [Phone(ErrorMessage = "O campo {0} não corresponde a um telefone válido")]
        public string Telefone { get; set; }
        [EmailAddress(ErrorMessage = "O campo {0} não corresponde a um email válido")]
        public string Email { get; set; }
        public List<RedeSocialDto> RedesSociais { get; set; }
        public List<EventoDto> Eventos { get; set; }
    }
}