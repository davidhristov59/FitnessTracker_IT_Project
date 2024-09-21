namespace NOVA_VERZIJA_IT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class one : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.WorkoutPlanExercises", newName: "WorkoutPlanExercises1");
            CreateTable(
                "dbo.WorkoutPlanExercises",
                c => new
                    {
                        workoutPlanID = c.Int(nullable: false, identity: true),
                        exerciseID = c.Int(nullable: false),
                        dayOfWeek = c.String(),
                        WorkoutPlan_ID = c.Int(),
                    })
                .PrimaryKey(t => t.workoutPlanID)
                .ForeignKey("dbo.WorkoutPlans", t => t.WorkoutPlan_ID)
                .Index(t => t.WorkoutPlan_ID);
            
            AddColumn("dbo.Exercises", "WorkoutPlanExercises_workoutPlanID", c => c.Int());
            CreateIndex("dbo.Exercises", "WorkoutPlanExercises_workoutPlanID");
            AddForeignKey("dbo.Exercises", "WorkoutPlanExercises_workoutPlanID", "dbo.WorkoutPlanExercises", "workoutPlanID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkoutPlanExercises", "WorkoutPlan_ID", "dbo.WorkoutPlans");
            DropForeignKey("dbo.Exercises", "WorkoutPlanExercises_workoutPlanID", "dbo.WorkoutPlanExercises");
            DropIndex("dbo.WorkoutPlanExercises", new[] { "WorkoutPlan_ID" });
            DropIndex("dbo.Exercises", new[] { "WorkoutPlanExercises_workoutPlanID" });
            DropColumn("dbo.Exercises", "WorkoutPlanExercises_workoutPlanID");
            DropTable("dbo.WorkoutPlanExercises");
            RenameTable(name: "dbo.WorkoutPlanExercises1", newName: "WorkoutPlanExercises");
        }
    }
}
