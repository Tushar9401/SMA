namespace SMA.SQl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeEnabled : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserRegistrations", "FirstName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserRegistrations", "FirstName");
        }
    }
}
