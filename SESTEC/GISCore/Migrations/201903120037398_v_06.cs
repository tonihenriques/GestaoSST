namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_06 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tbAnaliseRisco", "IDEmpregado");
            DropColumn("dbo.tbAnaliseRisco", "IDEmpresa");
            DropColumn("dbo.tbAnaliseRisco", "Imagem");
            DropColumn("dbo.tbAnaliseRisco", "IDRisco");
            DropColumn("dbo.tbAnaliseRisco", "IDPossiveisDanos");
            DropColumn("dbo.tbAnaliseRisco", "IDControle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbAnaliseRisco", "IDControle", c => c.String());
            AddColumn("dbo.tbAnaliseRisco", "IDPossiveisDanos", c => c.String());
            AddColumn("dbo.tbAnaliseRisco", "IDRisco", c => c.String());
            AddColumn("dbo.tbAnaliseRisco", "Imagem", c => c.String());
            AddColumn("dbo.tbAnaliseRisco", "IDEmpresa", c => c.String());
            AddColumn("dbo.tbAnaliseRisco", "IDEmpregado", c => c.String());
        }
    }
}
