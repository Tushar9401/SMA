namespace SMA.SQl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UseRR : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserRegistrations", "EmailVerfication_Length", c => c.Int(nullable: false));
            AddColumn("dbo.UserRegistrations", "ActivationCode", c => c.String());
            AddColumn("dbo.UserRegistrations", "OTP", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserRegistrations", "OTP");
            DropColumn("dbo.UserRegistrations", "ActivationCode");
            DropColumn("dbo.UserRegistrations", "EmailVerfication_Length");
        }
    }
}
