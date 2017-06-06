namespace BookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCode : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accommodations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Adress = c.String(),
                        AvageGrade = c.Double(nullable: false),
                        Latitude = c.Double(nullable: false),
                        Longtude = c.Double(nullable: false),
                        ImageUrl = c.String(),
                        Approved = c.Boolean(nullable: false),
                        PlaceId = c.Int(nullable: false),
                        AccommodationTypeId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccommodationTypes", t => t.AccommodationTypeId, cascadeDelete: true)
                .ForeignKey("dbo.AppUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Places", t => t.PlaceId, cascadeDelete: true)
                .ForeignKey("dbo.Regions", t => t.PlaceId, cascadeDelete: true)
                .Index(t => t.PlaceId)
                .Index(t => t.AccommodationTypeId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AccommodationTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Grade = c.Double(nullable: false),
                        Text = c.String(),
                        AccommodationId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accommodations", t => t.AccommodationId, cascadeDelete: false)
                .ForeignKey("dbo.AppUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.AccommodationId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        RegionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Regions", t => t.RegionId, cascadeDelete: false)
                .Index(t => t.RegionId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RommNumber = c.Int(nullable: false),
                        BedCount = c.Int(nullable: false),
                        Description = c.String(),
                        PricePreNight = c.Double(nullable: false),
                        AccommodationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accommodations", t => t.AccommodationId, cascadeDelete: false)
                .Index(t => t.AccommodationId);
            
            CreateTable(
                "dbo.RoomReservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Timestamp = c.DateTime(nullable: false),
                        RoomId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.AppUsers", "Email", c => c.String());
            AddColumn("dbo.AppUsers", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoomReservations", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.RoomReservations", "UserId", "dbo.AppUsers");
            DropForeignKey("dbo.Rooms", "AccommodationId", "dbo.Accommodations");
            DropForeignKey("dbo.Accommodations", "PlaceId", "dbo.Regions");
            DropForeignKey("dbo.Places", "RegionId", "dbo.Regions");
            DropForeignKey("dbo.Accommodations", "PlaceId", "dbo.Places");
            DropForeignKey("dbo.Regions", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Comments", "UserId", "dbo.AppUsers");
            DropForeignKey("dbo.Comments", "AccommodationId", "dbo.Accommodations");
            DropForeignKey("dbo.Accommodations", "UserId", "dbo.AppUsers");
            DropForeignKey("dbo.Accommodations", "AccommodationTypeId", "dbo.AccommodationTypes");
            DropIndex("dbo.RoomReservations", new[] { "UserId" });
            DropIndex("dbo.RoomReservations", new[] { "RoomId" });
            DropIndex("dbo.Rooms", new[] { "AccommodationId" });
            DropIndex("dbo.Places", new[] { "RegionId" });
            DropIndex("dbo.Regions", new[] { "CountryId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "AccommodationId" });
            DropIndex("dbo.Accommodations", new[] { "UserId" });
            DropIndex("dbo.Accommodations", new[] { "AccommodationTypeId" });
            DropIndex("dbo.Accommodations", new[] { "PlaceId" });
            DropColumn("dbo.AppUsers", "Password");
            DropColumn("dbo.AppUsers", "Email");
            DropTable("dbo.RoomReservations");
            DropTable("dbo.Rooms");
            DropTable("dbo.Places");
            DropTable("dbo.Countries");
            DropTable("dbo.Regions");
            DropTable("dbo.Comments");
            DropTable("dbo.AccommodationTypes");
            DropTable("dbo.Accommodations");
        }
    }
}
