namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class j1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbUsuario",
                c => new
                    {
                        IDUsuario = c.String(nullable: false, maxLength: 128),
                        CPF = c.String(nullable: false),
                        Nome = c.String(nullable: false),
                        Login = c.String(nullable: false),
                        Senha = c.String(),
                        Email = c.String(nullable: false),
                        IDEmpresa = c.String(nullable: false),
                        IDDepartamento = c.String(nullable: false),
                        TipoDeAcesso = c.Int(nullable: false),
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDUsuario);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbUsuario");
        }
    }
}
