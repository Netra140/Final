namespace Facebuild.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedRequirements : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Build", "Photo", c => c.String());
            AlterColumn("dbo.Build", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Build", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Build", "Photo", c => c.String(nullable: false));
        }
    }
}
