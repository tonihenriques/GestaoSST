namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insereImagenEmpregado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbEmpregado", "Imagem", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbEmpregado", "Imagem");
        }
    }
}
