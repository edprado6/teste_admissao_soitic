using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Autor
    {
        public Autor()
        {
            this.Livros = new HashSet<Livro>();
        }

        [Key]        
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [DisplayName("Cód.")]
        public int AutorId { get; set; }

        [DisplayName("Autor")]
        [Required(ErrorMessage = "Informe o nome do autor.")]
        [MaxLength(100)]
        public string NomeAutor { get; set; }

        [DisplayName("Data de inserção")]
        public DateTime DataInsercao { get; set; }

        [DisplayName("Data de alteração")]
        public DateTime DataAlteracao { get; set; }

        // Cada autor possui 0 ou mais livros.
        public virtual ICollection<Livro> Livros { get; set; }
    }
}
