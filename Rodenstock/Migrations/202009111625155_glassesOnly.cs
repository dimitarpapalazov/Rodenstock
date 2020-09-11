namespace Rodenstock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class glassesOnly : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "client_Id", "dbo.Clients");
            DropForeignKey("dbo.Glasses", "Orders_Id", "dbo.Orders");
            DropIndex("dbo.Glasses", new[] { "Orders_Id" });
            DropIndex("dbo.Orders", new[] { "client_Id" });
            DropColumn("dbo.Glasses", "Orders_Id");
            DropTable("dbo.Clients");
            DropTable("dbo.Orders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        client_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            AddColumn("dbo.Glasses", "Orders_Id", c => c.Int());
            CreateIndex("dbo.Orders", "client_Id");
            CreateIndex("dbo.Glasses", "Orders_Id");
            AddForeignKey("dbo.Glasses", "Orders_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.Orders", "client_Id", "dbo.Clients", "Id");
        }
    }
}
