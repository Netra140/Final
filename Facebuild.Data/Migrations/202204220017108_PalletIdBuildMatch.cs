namespace Facebuild.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PalletIdBuildMatch : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Build",
                c => new
                    {
                        BuildId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Photo = c.String(nullable: false),
                        Likes = c.Int(nullable: false),
                        palletBlockCount = c.Int(nullable: false),
                        PalletId = c.Int(nullable: false),
                        Description = c.String(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.BuildId);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        BuildId = c.Int(nullable: false),
                        UserId = c.Guid(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Like",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        BuildId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pallet",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        userId = c.Guid(nullable: false),
                        BuildId = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        Stone = c.Boolean(nullable: false),
                        Granite = c.Boolean(nullable: false),
                        Diorite = c.Boolean(nullable: false),
                        Andesite = c.Boolean(nullable: false),
                        Deepslate = c.Boolean(nullable: false),
                        Calcite = c.Boolean(nullable: false),
                        Tuff = c.Boolean(nullable: false),
                        Dripstone = c.Boolean(nullable: false),
                        Grass = c.Boolean(nullable: false),
                        Dirt = c.Boolean(nullable: false),
                        Podzol = c.Boolean(nullable: false),
                        Warped_Nylium = c.Boolean(nullable: false),
                        Crimson_Nylium = c.Boolean(nullable: false),
                        Oak = c.Boolean(nullable: false),
                        Spruce = c.Boolean(nullable: false),
                        Birch = c.Boolean(nullable: false),
                        Jungle = c.Boolean(nullable: false),
                        Acacia = c.Boolean(nullable: false),
                        Dark_Oak = c.Boolean(nullable: false),
                        Mangrove = c.Boolean(nullable: false),
                        Crimson_Wood = c.Boolean(nullable: false),
                        Warped_Wood = c.Boolean(nullable: false),
                        Bedrock = c.Boolean(nullable: false),
                        Sand = c.Boolean(nullable: false),
                        Red_Sand = c.Boolean(nullable: false),
                        Gravel = c.Boolean(nullable: false),
                        Stone_Ores = c.Boolean(nullable: false),
                        Deepslate_Ores = c.Boolean(nullable: false),
                        Nether_Ores = c.Boolean(nullable: false),
                        Block = c.Boolean(nullable: false),
                        Raw_Iron = c.Boolean(nullable: false),
                        Raw_Copper = c.Boolean(nullable: false),
                        Raw_Gold = c.Boolean(nullable: false),
                        Amethyst = c.Boolean(nullable: false),
                        Iron = c.Boolean(nullable: false),
                        Gold = c.Boolean(nullable: false),
                        Diamond = c.Boolean(nullable: false),
                        Netherite = c.Boolean(nullable: false),
                        Copper = c.Boolean(nullable: false),
                        Exposed_Copper = c.Boolean(nullable: false),
                        Weathered_Copper = c.Boolean(nullable: false),
                        Oxidised = c.Boolean(nullable: false),
                        Sponge = c.Boolean(nullable: false),
                        Wet_Sponged = c.Boolean(nullable: false),
                        Glass = c.Boolean(nullable: false),
                        Tinted_Glass = c.Boolean(nullable: false),
                        Lapis_Lazuli = c.Boolean(nullable: false),
                        Sandstone = c.Boolean(nullable: false),
                        Wool = c.Boolean(nullable: false),
                        Smooth_Stone = c.Boolean(nullable: false),
                        Bricks = c.Boolean(nullable: false),
                        Bookshelf = c.Boolean(nullable: false),
                        Mossy_Cobblestone = c.Boolean(nullable: false),
                        Obsidian = c.Boolean(nullable: false),
                        Purpur = c.Boolean(nullable: false),
                        Ice = c.Boolean(nullable: false),
                        Snow = c.Boolean(nullable: false),
                        Clay = c.Boolean(nullable: false),
                        Pumpkin = c.Boolean(nullable: false),
                        Netherrack = c.Boolean(nullable: false),
                        Soul_Sand = c.Boolean(nullable: false),
                        Basalt = c.Boolean(nullable: false),
                        Glowstone = c.Boolean(nullable: false),
                        Stone_Brick = c.Boolean(nullable: false),
                        Deepslate_Brick = c.Boolean(nullable: false),
                        Melon = c.Boolean(nullable: false),
                        Mycelium = c.Boolean(nullable: false),
                        Nether_Bricks = c.Boolean(nullable: false),
                        End_Stone = c.Boolean(nullable: false),
                        End_Stone_Brick = c.Boolean(nullable: false),
                        Emerald = c.Boolean(nullable: false),
                        Quartz = c.Boolean(nullable: false),
                        Terracotta = c.Boolean(nullable: false),
                        Hay_Bale = c.Boolean(nullable: false),
                        Packed_Ice = c.Boolean(nullable: false),
                        Stained_Glass = c.Boolean(nullable: false),
                        Prismarine = c.Boolean(nullable: false),
                        Prismarine_Brick = c.Boolean(nullable: false),
                        Dark_Prismarine = c.Boolean(nullable: false),
                        Sea_Lantern = c.Boolean(nullable: false),
                        Magma_Block = c.Boolean(nullable: false),
                        Nether_Wart = c.Boolean(nullable: false),
                        Red_Nether_Brick = c.Boolean(nullable: false),
                        Bone_Block = c.Boolean(nullable: false),
                        Concrete = c.Boolean(nullable: false),
                        Concrete_Powder = c.Boolean(nullable: false),
                        Coral = c.Boolean(nullable: false),
                        Blue_Ice = c.Boolean(nullable: false),
                        Dried_Kelp = c.Boolean(nullable: false),
                        Crying_Obsidian = c.Boolean(nullable: false),
                        Blackstone = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Pallet");
            DropTable("dbo.Like");
            DropTable("dbo.Comment");
            DropTable("dbo.Build");
        }
    }
}
