namespace Antix.EASI.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExaminerDatas",
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
                        ExaminerData_Id = c.Guid(),
                        PatientData_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Keywords", t => t.Keyword_Id)
                .ForeignKey("dbo.ExaminerDatas", t => t.ExaminerData_Id, cascadeDelete: true)
                .ForeignKey("dbo.PatientDatas", t => t.PatientData_Id, cascadeDelete: true)
                .Index(t => t.Keyword_Id)
                .Index(t => t.ExaminerData_Id)
                .Index(t => t.PatientData_Id);
            
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
                        Identifier = c.String(),
                        Person_Name = c.String(maxLength: 50),
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
                        Examiner_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExaminerDatas", t => t.Examiner_Id)
                .Index(t => t.Examiner_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ScoreDatas", "Examiner_Id", "dbo.ExaminerDatas");
            DropForeignKey("dbo.IndexedEntityKeywords", "PatientData_Id", "dbo.PatientDatas");
            DropForeignKey("dbo.IndexedEntityKeywords", "ExaminerData_Id", "dbo.ExaminerDatas");
            DropForeignKey("dbo.IndexedEntityKeywords", "Keyword_Id", "dbo.Keywords");
            DropIndex("dbo.ScoreDatas", new[] { "Examiner_Id" });
            DropIndex("dbo.IndexedEntityKeywords", new[] { "PatientData_Id" });
            DropIndex("dbo.IndexedEntityKeywords", new[] { "ExaminerData_Id" });
            DropIndex("dbo.IndexedEntityKeywords", new[] { "Keyword_Id" });
            DropTable("dbo.ScoreDatas");
            DropTable("dbo.PatientDatas");
            DropTable("dbo.Keywords");
            DropTable("dbo.IndexedEntityKeywords");
            DropTable("dbo.ExaminerDatas");
        }
    }
}
