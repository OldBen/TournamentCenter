namespace TounamentCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tournaments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Players = c.Int(nullable: false),
                        SponsorLogoUrl = c.String(),
                        Organizer = c.String(nullable: false),
                        Deadline = c.DateTime(nullable: false),
                        Sport = c.String(nullable: false),
                        TournamentName = c.String(nullable: false, maxLength: 60),
                        Date = c.DateTime(nullable: false),
                        Location = c.String(nullable: false, maxLength: 60),
                        ParticipantsLimit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tournaments");
        }
    }
}
