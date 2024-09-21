namespace NOVA_VERZIJA_IT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class novo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Foods", "ImageUrl", c => c.String());
            AddColumn("dbo.Foods", "Ingredients", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Foods", "Ingredients");
            DropColumn("dbo.Foods", "ImageUrl");
        }
    }
}
