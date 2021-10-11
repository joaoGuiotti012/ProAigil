using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProAgil.WebAPI.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }

        [Required( ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Local é entre 3 e 100 caracteres")]
        public string Local { get; set; }
        public string DataEvento { get; set; }
        [Required( ErrorMessage = "O campo {0} é obrigatório")]
        public string Tema { get; set; }

        [Range(2,120000, ErrorMessage = "Quantidade de pessoas permitidade entre 2 e 120000")]
        public int QtdPessoas { get; set; }
        public string ImagemUrl { get; set; }
        [Phone(ErrorMessage = "Telefone deve ser no formato correspondente")]
        public string Telefone { get; set; }
        // DataAnotations para Email
        [EmailAddress( ErrorMessage = "O campo {0} não corresponde a um email válido")]
        public string Email { get; set; }
        public List<LoteDto> Lotes { get; set; }
        public List<RedeSocialDto> RedesSociais { get; set; }
        public List<PalestranteDto> Palestrantes { get; set; }
    }
}