using System.ComponentModel.DataAnnotations;

namespace ProAgil.WebAPI.Dtos
{
    public class LoteDto
    {
        public int id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal preco { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string dataInicio { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string dataFim { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int quantidade { get; set; }
        public EventoDto evento { get; }
    }
}