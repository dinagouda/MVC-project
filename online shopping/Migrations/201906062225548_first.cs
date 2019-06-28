namespace online_shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.categories",
                c => new
                    {
                        categorynom = c.Int(nullable: false, identity: true),
                        categoryname = c.String(),
                    })
                .PrimaryKey(t => t.categorynom);
            
            CreateTable(
                "dbo.products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Productname = c.String(),
                        productdesc = c.String(),
                        productprice = c.Int(nullable: false),
                        Image = c.String(),
                        categorynom = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.categories", t => t.categorynom, cascadeDelete: true)
                .Index(t => t.categorynom);
            
            CreateTable(
                "dbo.users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        password = c.String(),
                        email = c.String(),
                        age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.products", "categorynom", "dbo.categories");
            DropIndex("dbo.products", new[] { "categorynom" });
            DropTable("dbo.users");
            DropTable("dbo.products");
            DropTable("dbo.categories");
        }
    }
}
