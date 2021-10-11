using System.ComponentModel.DataAnnotations;

namespace ProAgil.WebAPI.Dtos
{
    public class LoteDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Preco { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string DataInicio { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string DataFim { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Quantidade { get; set; }
        public EventoDto Evento { get; }
    }
}