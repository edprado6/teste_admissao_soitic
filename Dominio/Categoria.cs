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
    public class Categoria
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [DisplayName("Cód.")]
        public int CategoriaId { get; set; }

        [DisplayName("Categoria")]
        [Required(ErrorMessage = "Informe um nome para a categoria.")]
        [MaxLength(100)]
        public string NomeCategoria { get; set; }

        [DisplayName("Data de inserção")]
        public DateTime DataInsercao { get; set; }

        [DisplayName("Data de alteração")]
        public DateTime DataAlteracao { get; set; }

        // Cada categoria pode estar em vários livros.        
        public virtual ICollection<Livro> Livros { get; set; }  
    }
}
