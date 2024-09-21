namespace NOVA_VERZIJA_IT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finalno1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FitnessUsers", "Email", c => c.String(nullable: false));
            AddColumn("dbo.FitnessUsers", "Password", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.FitnessUsers", "ConfirmPassword", c => c.String());
            AlterColumn("dbo.FitnessUsers", "contactNumber", c => c.String(nullable: false));
            DropColumn("dbo.FitnessUsers", "image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FitnessUsers", "image", c => c.String());
            AlterColumn("dbo.FitnessUsers", "contactNumber", c => c.Int(nullable: false));
            DropColumn("dbo.FitnessUsers", "ConfirmPassword");
            DropColumn("dbo.FitnessUsers", "Password");
            DropColumn("dbo.FitnessUsers", "Email");
        }
    }
}
