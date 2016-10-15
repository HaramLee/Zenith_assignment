namespace ZenithDataLib.Migrations.ZenithData
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activity",
                c => new
                    {
                        ActivityId = c.Int(nullable: false, identity: true),
                        ActivityDec = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ActivityId);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        FromDate = c.Time(nullable: false, precision: 7),
                        ToDate = c.Time(nullable: false, precision: 7),
                        EnteredUsername = c.String(),
                        ActivityId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        IsActive = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Activity", t => t.ActivityId, cascadeDelete: true)
                .Index(t => t.ActivityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Event", "ActivityId", "dbo.Activity");
            DropIndex("dbo.Event", new[] { "ActivityId" });
            DropTable("dbo.Event");
            DropTable("dbo.Activity");
        }
    }
}
