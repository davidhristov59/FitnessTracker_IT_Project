namespace NOVA_VERZIJA_IT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class daljo2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WeeklyExercises", "WorkoutPlan_ID", "dbo.WorkoutPlans");
            DropIndex("dbo.WeeklyExercises", new[] { "WorkoutPlan_ID" });
            RenameColumn(table: "dbo.WeeklyExercises", name: "WorkoutPlan_ID", newName: "WorkoutPlanID");
            AlterColumn("dbo.WeeklyExercises", "WorkoutPlanID", c => c.Int(nullable: false));
            CreateIndex("dbo.WeeklyExercises", "WorkoutPlanID");
            AddForeignKey("dbo.WeeklyExercises", "WorkoutPlanID", "dbo.WorkoutPlans", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WeeklyExercises", "WorkoutPlanID", "dbo.WorkoutPlans");
            DropIndex("dbo.WeeklyExercises", new[] { "WorkoutPlanID" });
            AlterColumn("dbo.WeeklyExercises", "WorkoutPlanID", c => c.Int());
            RenameColumn(table: "dbo.WeeklyExercises", name: "WorkoutPlanID", newName: "WorkoutPlan_ID");
            CreateIndex("dbo.WeeklyExercises", "WorkoutPlan_ID");
            AddForeignKey("dbo.WeeklyExercises", "WorkoutPlan_ID", "dbo.WorkoutPlans", "ID");
        }
    }
}
