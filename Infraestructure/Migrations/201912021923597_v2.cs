namespace Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BillDetails",
                c => new
                    {
                        BillDetailID = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        State = c.Boolean(nullable: false),
                        ProductID = c.Int(nullable: false),
                        BillID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BillDetailID)
                .ForeignKey("dbo.Bills", t => t.BillID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.BillID);
            
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        BillID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Comments = c.String(),
                        IGV = c.Decimal(nullable: false, precision: 18, scale: 2),
                        State = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        SalesManID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BillID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.SalesMen", t => t.SalesManID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.SalesManID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Phone = c.String(),
                        Address = c.String(),
                        State = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.SalesMen",
                c => new
                    {
                        SalesManID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        State = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SalesManID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Stock = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        State = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BillDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Bills", "SalesManID", "dbo.SalesMen");
            DropForeignKey("dbo.Bills", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.BillDetails", "BillID", "dbo.Bills");
            DropIndex("dbo.Bills", new[] { "SalesManID" });
            DropIndex("dbo.Bills", new[] { "CustomerID" });
            DropIndex("dbo.BillDetails", new[] { "BillID" });
            DropIndex("dbo.BillDetails", new[] { "ProductID" });
            DropTable("dbo.Products");
            DropTable("dbo.SalesMen");
            DropTable("dbo.Customers");
            DropTable("dbo.Bills");
            DropTable("dbo.BillDetails");
        }
    }
}
