namespace MyAspMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        FacultyId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.FacultyId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderMasterId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.OrderMasters", t => t.OrderMasterId, cascadeDelete: true)
                .Index(t => t.OrderMasterId);
            
            CreateTable(
                "dbo.OrderMasters",
                c => new
                    {
                        OrderMasterId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        Note = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.OrderMasterId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        BookName = c.String(),
                        FacultyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "OrderMasterId", "dbo.OrderMasters");
            DropIndex("dbo.OrderDetails", new[] { "OrderMasterId" });
            DropTable("dbo.Books");
            DropTable("dbo.OrderMasters");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Faculties");
        }
    }
}
