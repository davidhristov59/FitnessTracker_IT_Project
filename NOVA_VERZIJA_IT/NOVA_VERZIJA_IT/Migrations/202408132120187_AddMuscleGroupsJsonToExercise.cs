namespace NOVA_VERZIJA_IT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMuscleGroupsJsonToExercise : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exercises", "muscleGroupsJson", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exercises", "muscleGroupsJson");
        }
    }
}
