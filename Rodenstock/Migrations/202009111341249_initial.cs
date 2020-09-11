namespace Rodenstock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Gender = c.String(),
                        Age = c.Int(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Glasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                        Color = c.String(),
                        Material = c.String(),
                        Sex = c.String(),
                        Price = c.Int(nullable: false),
                        ImageUrl = c.String(),
                        Orders_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Orders_Id)
                .Index(t => t.Orders_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        client_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.client_Id)
                .Index(t => t.client_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Glasses", "Orders_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "client_Id", "dbo.Clients");
            DropIndex("dbo.Orders", new[] { "client_Id" });
            DropIndex("dbo.Glasses", new[] { "Orders_Id" });
            DropTable("dbo.Orders");
            DropTable("dbo.Glasses");
            DropTable("dbo.Clients");
        }
    }
}
