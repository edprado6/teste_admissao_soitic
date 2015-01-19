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
    /*
     * Classe que representa a tabela Livro no Banco de Dados.
     */
    public class Livro
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [DisplayName("Cód.")]
        public int LivroId { get; set; }

        [DisplayName("Livro")]
        [Required(ErrorMessage = "Informe o nome do livro.")]
        [MaxLength(100)]
        public string NomeLivro { get; set; }

        [DisplayName("Data de inserção")]
        public DateTime DataInsercao { get; set; }

        [DisplayName("Data de alteração")]
        public DateTime DataAlteracao { get; set; }

        [DisplayName("Editora")]
        [MaxLength(100)]
        public string Editora { get; set; }

        [DisplayName("Ano de publicação")]
        [MaxLength(4)]
        public string AnoPublicacao { get; set; }

        [DisplayName("Edição")]
        [MaxLength(20)]
        public string Edicao { get; set; }

        /*
         * Abaixo os dois relacionamentos que a tabela livro possui.
         * AutorId e CategoriaId são chaves estrangeiras.
         */
        // Cada livro possui um autor. 
        // Cada autor pode ter vários livros.
        public int AutorId { get; set; }
        public virtual Autor Autor { get; set; }

        // Cada livro possui uma categoria. 
        // Cada categoria pode estar relacionada a vários livros.
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; } 
    }
}
