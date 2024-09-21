namespace NOVA_VERZIJA_IT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stefcee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DietAndNutritions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CaloriesGoal = c.Double(nullable: false),
                        totalCalories = c.Double(nullable: false),
                        caloriesRemaining = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ServingSize = c.Int(nullable: false),
                        Protein = c.Double(nullable: false),
                        Carbs = c.Double(nullable: false),
                        Fats = c.Double(nullable: false),
                        Calories = c.Double(nullable: false),
                        MealType = c.String(),
                        DietAndNutrition_ID = c.Int(),
                        DietAndNutrition_ID1 = c.Int(),
                        DietAndNutrition_ID2 = c.Int(),
                        DietAndNutrition_ID3 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DietAndNutritions", t => t.DietAndNutrition_ID)
                .ForeignKey("dbo.DietAndNutritions", t => t.DietAndNutrition_ID1)
                .ForeignKey("dbo.DietAndNutritions", t => t.DietAndNutrition_ID2)
                .ForeignKey("dbo.DietAndNutritions", t => t.DietAndNutrition_ID3)
                .Index(t => t.DietAndNutrition_ID)
                .Index(t => t.DietAndNutrition_ID1)
                .Index(t => t.DietAndNutrition_ID2)
                .Index(t => t.DietAndNutrition_ID3);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Foods", "DietAndNutrition_ID3", "dbo.DietAndNutritions");
            DropForeignKey("dbo.Foods", "DietAndNutrition_ID2", "dbo.DietAndNutritions");
            DropForeignKey("dbo.Foods", "DietAndNutrition_ID1", "dbo.DietAndNutritions");
            DropForeignKey("dbo.Foods", "DietAndNutrition_ID", "dbo.DietAndNutritions");
            DropIndex("dbo.Foods", new[] { "DietAndNutrition_ID3" });
            DropIndex("dbo.Foods", new[] { "DietAndNutrition_ID2" });
            DropIndex("dbo.Foods", new[] { "DietAndNutrition_ID1" });
            DropIndex("dbo.Foods", new[] { "DietAndNutrition_ID" });
            DropTable("dbo.Foods");
            DropTable("dbo.DietAndNutritions");
        }
    }
}
