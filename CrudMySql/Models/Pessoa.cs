using System.ComponentModel.DataAnnotations;

namespace CrudMySql.Models
{
    public class Pessoa
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Obrigatorio o preenchimento do Nome")]
        public string Nome { get; set; }
    }
}