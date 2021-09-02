using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProAgil.WebAPI.Dtos
{
    public class EventoDto
    {
        public int id { get; set; }

        [Required( ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Local é entre 3 e 100 caracteres")]
        public string local { get; set; }
        public string dataEvento { get; set; }
        [Required( ErrorMessage = "O campo {0} é obrigatório")]
        public string tema { get; set; }

        [Range(2,120000, ErrorMessage = "Quantidade de pessoas permitidade entre 2 e 120000")]
        public int qtdPessoas { get; set; }
        public string imagemUrl { get; set; }
        [Phone(ErrorMessage = "Telefone deve ser no formato correspondente")]
        public string telefone { get; set; }
        // DataAnotations para Email
        [EmailAddress( ErrorMessage = "O campo {0} não corresponde a um email válido")]
        public string email { get; set; }
        public List<LoteDto> lotes { get; set; }
        public List<RedeSocialDto> redesSociais { get; set; }
        public List<PalestranteDto> palestrantes { get; set; }
    }
}