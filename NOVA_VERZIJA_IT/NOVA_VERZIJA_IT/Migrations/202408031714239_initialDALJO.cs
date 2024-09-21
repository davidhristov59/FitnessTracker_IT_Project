namespace NOVA_VERZIJA_IT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialDALJO : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WeeklyExercises",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ExerciseId = c.Int(nullable: false),
                        DayOfWeek = c.String(),
                        WorkoutPlan_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Exercises", t => t.ExerciseId, cascadeDelete: true)
                .ForeignKey("dbo.WorkoutPlans", t => t.WorkoutPlan_ID)
                .Index(t => t.ExerciseId)
                .Index(t => t.WorkoutPlan_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WeeklyExercises", "WorkoutPlan_ID", "dbo.WorkoutPlans");
            DropForeignKey("dbo.WeeklyExercises", "ExerciseId", "dbo.Exercises");
            DropIndex("dbo.WeeklyExercises", new[] { "WorkoutPlan_ID" });
            DropIndex("dbo.WeeklyExercises", new[] { "ExerciseId" });
            DropTable("dbo.WeeklyExercises");
        }
    }
}
