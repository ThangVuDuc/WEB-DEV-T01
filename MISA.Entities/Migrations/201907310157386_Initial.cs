namespace MISA.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RefDetails",
                c => new
                    {
                        RefDetailID = c.Guid(nullable: false, defaultValueSql:"newid()", identity: true),
                        Description = c.String(),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CollectionType = c.String(),
                        RefID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.RefDetailID)
                .ForeignKey("dbo.Refs", t => t.RefID, cascadeDelete: true)
                .Index(t => t.RefID);
            
            CreateTable(
                "dbo.Refs",
                c => new
                    {
                        RefID = c.Guid(nullable: false, defaultValueSql: "newid()", identity: true),
                        RefDate = c.DateTime(nullable: false, defaultValueSql:"getdate()"),
                        RefNo = c.String(),
                        RefType = c.String(),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ContactName = c.String(),
                        Reason = c.String(),
                    })
                .PrimaryKey(t => t.RefID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RefDetails", "RefID", "dbo.Refs");
            DropIndex("dbo.RefDetails", new[] { "RefID" });
            DropTable("dbo.Refs");
            DropTable("dbo.RefDetails");
        }
    }
}
