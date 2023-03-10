namespace SMA.SQl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingRoles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserRegistrations", "Roles", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserRegistrations", "Roles");
        }
    }
}
