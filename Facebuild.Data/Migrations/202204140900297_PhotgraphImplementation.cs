namespace Facebuild.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhotgraphImplementation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Build", "Photo", c => c.String(nullable: false));
            AlterColumn("dbo.Build", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Build", "Description", c => c.String());
            AlterColumn("dbo.Build", "Photo", c => c.String());
        }
    }
}
