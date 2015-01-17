namespace Contexto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BDInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autors",
                c => new
                    {
                        AutorId = c.Int(nullable: false, identity: true),
                        NomeAutor = c.String(nullable: false, maxLength: 100),
                        DataInsercao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AutorId);
            
            CreateTable(
                "dbo.Livroes",
                c => new
                    {
                        LivroId = c.Int(nullable: false, identity: true),
                        NomeLivro = c.String(nullable: false, maxLength: 100),
                        DataInsercao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                        Editora = c.String(maxLength: 100),
                        AnoPublicacao = c.String(maxLength: 4),
                        Edicao = c.String(maxLength: 20),
                        AutorId = c.Int(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LivroId)
                .ForeignKey("dbo.Autors", t => t.AutorId, cascadeDelete: true)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId, cascadeDelete: true)
                .Index(t => t.AutorId)
                .Index(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        NomeCategoria = c.String(nullable: false, maxLength: 100),
                        DataInsercao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Livroes", "CategoriaId", "dbo.Categorias");
            DropForeignKey("dbo.Livroes", "AutorId", "dbo.Autors");
            DropIndex("dbo.Livroes", new[] { "CategoriaId" });
            DropIndex("dbo.Livroes", new[] { "AutorId" });
            DropTable("dbo.Categorias");
            DropTable("dbo.Livroes");
            DropTable("dbo.Autors");
        }
    }
}
