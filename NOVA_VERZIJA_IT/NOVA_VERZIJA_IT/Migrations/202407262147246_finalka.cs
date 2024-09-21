namespace NOVA_VERZIJA_IT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finalka : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exercises", "DayOfWeek", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exercises", "DayOfWeek");
        }
    }
}
