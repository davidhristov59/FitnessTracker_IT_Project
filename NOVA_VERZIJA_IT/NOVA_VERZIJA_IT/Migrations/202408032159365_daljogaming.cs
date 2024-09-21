namespace NOVA_VERZIJA_IT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class daljogaming : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WeeklyExercises", "Sets", c => c.Int(nullable: false));
            AddColumn("dbo.WeeklyExercises", "Reps", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WeeklyExercises", "Reps");
            DropColumn("dbo.WeeklyExercises", "Sets");
        }
    }
}
