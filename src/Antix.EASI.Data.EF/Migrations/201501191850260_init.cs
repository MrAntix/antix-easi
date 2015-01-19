namespace Antix.EASI.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClinicianDatas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Identifier = c.String(),
                        Person_Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IndexedEntityKeywords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Frequency = c.Int(nullable: false),
                        Keyword_Id = c.Int(),
                        ClinicianData_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Keywords", t => t.Keyword_Id)
                .ForeignKey("dbo.ClinicianDatas", t => t.ClinicianData_Id)
                .Index(t => t.Keyword_Id)
                .Index(t => t.ClinicianData_Id);
            
            CreateTable(
                "dbo.Keywords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        Frequency = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PatientDatas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Person_Name = c.String(maxLength: 50),
                        Identifier = c.String(maxLength: 50),
                        DateOfBirth = c.DateTimeOffset(nullable: false, precision: 7),
                        Gender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ScoreDatas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TakenOn = c.DateTimeOffset(nullable: false, precision: 7),
                        HeadNeck_Erthema = c.Int(nullable: false),
                        HeadNeck_EdemaPapulation = c.Int(nullable: false),
                        HeadNeck_Excoriation = c.Int(nullable: false),
                        HeadNeck_Lichenification = c.Int(nullable: false),
                        HeadNeck_Region = c.Int(nullable: false),
                        Trunk_Erthema = c.Int(nullable: false),
                        Trunk_EdemaPapulation = c.Int(nullable: false),
                        Trunk_Excoriation = c.Int(nullable: false),
                        Trunk_Lichenification = c.Int(nullable: false),
                        Trunk_Region = c.Int(nullable: false),
                        UpperExtremities_Erthema = c.Int(nullable: false),
                        UpperExtremities_EdemaPapulation = c.Int(nullable: false),
                        UpperExtremities_Excoriation = c.Int(nullable: false),
                        UpperExtremities_Lichenification = c.Int(nullable: false),
                        UpperExtremities_Region = c.Int(nullable: false),
                        LowerExtremities_Erthema = c.Int(nullable: false),
                        LowerExtremities_EdemaPapulation = c.Int(nullable: false),
                        LowerExtremities_Excoriation = c.Int(nullable: false),
                        LowerExtremities_Lichenification = c.Int(nullable: false),
                        LowerExtremities_Region = c.Int(nullable: false),
                        Notes = c.String(maxLength: 500),
                        Clinician_Id = c.Guid(),
                        Patient_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClinicianDatas", t => t.Clinician_Id)
                .ForeignKey("dbo.PatientDatas", t => t.Patient_Id)
                .Index(t => t.Clinician_Id)
                .Index(t => t.Patient_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ScoreDatas", "Patient_Id", "dbo.PatientDatas");
            DropForeignKey("dbo.ScoreDatas", "Clinician_Id", "dbo.ClinicianDatas");
            DropForeignKey("dbo.IndexedEntityKeywords", "ClinicianData_Id", "dbo.ClinicianDatas");
            DropForeignKey("dbo.IndexedEntityKeywords", "Keyword_Id", "dbo.Keywords");
            DropIndex("dbo.ScoreDatas", new[] { "Patient_Id" });
            DropIndex("dbo.ScoreDatas", new[] { "Clinician_Id" });
            DropIndex("dbo.IndexedEntityKeywords", new[] { "ClinicianData_Id" });
            DropIndex("dbo.IndexedEntityKeywords", new[] { "Keyword_Id" });
            DropTable("dbo.ScoreDatas");
            DropTable("dbo.PatientDatas");
            DropTable("dbo.Keywords");
            DropTable("dbo.IndexedEntityKeywords");
            DropTable("dbo.ClinicianDatas");
        }
    }
}
