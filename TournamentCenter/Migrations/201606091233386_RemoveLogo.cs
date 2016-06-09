namespace TounamentCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveLogo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tournaments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TournamentName = c.String(),
                        Date = c.DateTime(nullable: false),
                        Location = c.String(),
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
