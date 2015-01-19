using Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contexto
{
    /*
     * A classe DBLivro é a classe que representa o Banco de Dados.
     * Aqui também é feita a conexão com o DB por meio da ConnectionString do 
     * arquivo web.config
     */
    public class DBLivro: DbContext
    {
        public DBLivro()
            : base("TesteAdmissaoDb")
        {

        }

        /*
         * Tabelas
         */
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Livro> Livros { get; set; }  
    }
}
