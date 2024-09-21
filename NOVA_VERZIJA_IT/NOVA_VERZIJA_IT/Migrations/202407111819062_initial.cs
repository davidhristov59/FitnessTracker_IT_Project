namespace NOVA_VERZIJA_IT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exercises",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Category = c.String(),
                        Description = c.String(),
                        VideoUrl = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.WorkoutPlans",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FitnessUsers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        contactNumber = c.Int(nullable: false),
                        image = c.String(),
                        dateOfBirth = c.DateTime(nullable: false),
                        membershipCreated = c.DateTime(nullable: false),
                        Height = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.WorkoutPlanExercises",
                c => new
                    {
                        WorkoutPlan_ID = c.Int(nullable: false),
                        Exercise_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WorkoutPlan_ID, t.Exercise_ID })
                .ForeignKey("dbo.WorkoutPlans", t => t.WorkoutPlan_ID, cascadeDelete: true)
                .ForeignKey("dbo.Exercises", t => t.Exercise_ID, cascadeDelete: true)
                .Index(t => t.WorkoutPlan_ID)
                .Index(t => t.Exercise_ID);
            
            CreateTable(
                "dbo.FitnessUserWorkoutPlans",
                c => new
                    {
                        FitnessUser_ID = c.Int(nullable: false),
                        WorkoutPlan_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FitnessUser_ID, t.WorkoutPlan_ID })
                .ForeignKey("dbo.FitnessUsers", t => t.FitnessUser_ID, cascadeDelete: true)
                .ForeignKey("dbo.WorkoutPlans", t => t.WorkoutPlan_ID, cascadeDelete: true)
                .Index(t => t.FitnessUser_ID)
                .Index(t => t.WorkoutPlan_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.FitnessUserWorkoutPlans", "WorkoutPlan_ID", "dbo.WorkoutPlans");
            DropForeignKey("dbo.FitnessUserWorkoutPlans", "FitnessUser_ID", "dbo.FitnessUsers");
            DropForeignKey("dbo.WorkoutPlanExercises", "Exercise_ID", "dbo.Exercises");
            DropForeignKey("dbo.WorkoutPlanExercises", "WorkoutPlan_ID", "dbo.WorkoutPlans");
            DropIndex("dbo.FitnessUserWorkoutPlans", new[] { "WorkoutPlan_ID" });
            DropIndex("dbo.FitnessUserWorkoutPlans", new[] { "FitnessUser_ID" });
            DropIndex("dbo.WorkoutPlanExercises", new[] { "Exercise_ID" });
            DropIndex("dbo.WorkoutPlanExercises", new[] { "WorkoutPlan_ID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.FitnessUserWorkoutPlans");
            DropTable("dbo.WorkoutPlanExercises");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.FitnessUsers");
            DropTable("dbo.WorkoutPlans");
            DropTable("dbo.Exercises");
        }
    }
}
