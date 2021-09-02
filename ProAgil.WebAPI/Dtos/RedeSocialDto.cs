using System.ComponentModel.DataAnnotations;

namespace ProAgil.WebAPI.Dtos
{
    public class RedeSocialDto
    {
        public int id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string uRL { get; set; }
    }
}