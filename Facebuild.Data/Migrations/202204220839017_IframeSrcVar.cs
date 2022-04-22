namespace Facebuild.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IframeSrcVar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Like", "like", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Like", "like");
        }
    }
}
