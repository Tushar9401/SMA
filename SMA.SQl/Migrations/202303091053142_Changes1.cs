namespace SMA.SQl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserRegistrations", "FirstName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserRegistrations", "FirstName", c => c.String(nullable: false));
        }
    }
}
