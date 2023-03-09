﻿namespace SMA.SQl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRRR : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserRegistrations", "FirstName", c => c.String());
            AlterColumn("dbo.UserRegistrations", "LastName", c => c.String());
            AlterColumn("dbo.UserRegistrations", "Email", c => c.String());
            AlterColumn("dbo.UserRegistrations", "Password", c => c.String());
            AlterColumn("dbo.UserRegistrations", "ConfirmPassword", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserRegistrations", "ConfirmPassword", c => c.String(nullable: false));
            AlterColumn("dbo.UserRegistrations", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.UserRegistrations", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.UserRegistrations", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.UserRegistrations", "FirstName", c => c.String(nullable: false));
        }
    }
}
