namespace SMA.SQl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUSerRR : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserRegistrations", "EmailVerfication", c => c.Boolean(nullable: false));
            DropColumn("dbo.UserRegistrations", "EmailVerfication_Length");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserRegistrations", "EmailVerfication_Length", c => c.Int(nullable: false));
            DropColumn("dbo.UserRegistrations", "EmailVerfication");
        }
    }
}
