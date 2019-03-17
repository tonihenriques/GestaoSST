namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbAnaliseRisco", "IDEventoPerigoso", c => c.String());
            DropColumn("dbo.tbEmpregado", "Imagem");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbEmpregado", "Imagem", c => c.String());
            DropColumn("dbo.tbAnaliseRisco", "IDEventoPerigoso");
        }
    }
}
