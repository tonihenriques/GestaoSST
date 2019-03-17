namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_03 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbAnaliseRisco", "IDEventoPerigoso", c => c.String());
            AddColumn("dbo.tbAnaliseRisco", "IDPerigoPotencial", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbAnaliseRisco", "IDPerigoPotencial");
            DropColumn("dbo.tbAnaliseRisco", "IDEventoPerigoso");
        }
    }
}
