namespace NOVA_VERZIJA_IT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkoutPlans", "ImageURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkoutPlans", "ImageURL");
        }
    }
}
