namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbAnaliseRisco", "Conhecimento", c => c.Boolean(nullable: false));
            AddColumn("dbo.tbAnaliseRisco", "BemEstar", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbAnaliseRisco", "BemEstar");
            DropColumn("dbo.tbAnaliseRisco", "Conhecimento");
        }
    }
}
