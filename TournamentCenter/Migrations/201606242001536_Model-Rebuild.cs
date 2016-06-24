namespace TounamentCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelRebuild : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tournaments", "Players", c => c.Int(nullable: false));
            AddColumn("dbo.Tournaments", "SponsorLogoUrl", c => c.String());
            AddColumn("dbo.Tournaments", "Organizer", c => c.String(nullable: false));
            AddColumn("dbo.Tournaments", "Deadline", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tournaments", "Sport", c => c.String(nullable: false));
            AlterColumn("dbo.Tournaments", "TournamentName", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Tournaments", "Location", c => c.String(nullable: false, maxLength: 60));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tournaments", "Location", c => c.String());
            AlterColumn("dbo.Tournaments", "TournamentName", c => c.String());
            DropColumn("dbo.Tournaments", "Sport");
            DropColumn("dbo.Tournaments", "Deadline");
            DropColumn("dbo.Tournaments", "Organizer");
            DropColumn("dbo.Tournaments", "SponsorLogoUrl");
            DropColumn("dbo.Tournaments", "Players");
        }
    }
}
