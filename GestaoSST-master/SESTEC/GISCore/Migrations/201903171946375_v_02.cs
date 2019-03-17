namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_02 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tbAnaliseRisco", "IDEventoPerigoso");
            DropColumn("dbo.tbAnaliseRisco", "IDPerigoPotencial");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbAnaliseRisco", "IDPerigoPotencial", c => c.String());
            AddColumn("dbo.tbAnaliseRisco", "IDEventoPerigoso", c => c.String());
        }
    }
}
