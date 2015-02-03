namespace Antix.EASI.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExaminationDatas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ExaminerId = c.Guid(nullable: false),
                        PatientId = c.Guid(nullable: false),
                        TakenOn = c.DateTimeOffset(nullable: false, precision: 7),
                        HeadNeck_Erthema = c.Int(),
                        HeadNeck_EdemaPapulation = c.Int(),
                        HeadNeck_Excoriation = c.Int(),
                        HeadNeck_Lichenification = c.Int(),
                        HeadNeck_Area = c.Int(),
                        Trunk_Erthema = c.Int(),
                        Trunk_EdemaPapulation = c.Int(),
                        Trunk_Excoriation = c.Int(),
                        Trunk_Lichenification = c.Int(),
                        Trunk_Area = c.Int(),
                        UpperExtremities_Erthema = c.Int(),
                        UpperExtremities_EdemaPapulation = c.Int(),
                        UpperExtremities_Excoriation = c.Int(),
                        UpperExtremities_Lichenification = c.Int(),
                        UpperExtremities_Area = c.Int(),
                        LowerExtremities_Erthema = c.Int(),
                        LowerExtremities_EdemaPapulation = c.Int(),
                        LowerExtremities_Excoriation = c.Int(),
                        LowerExtremities_Lichenification = c.Int(),
                        LowerExtremities_Area = c.Int(),
                        Notes = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExaminerDatas", t => t.ExaminerId)
                .ForeignKey("dbo.PatientDatas", t => t.PatientId)
                .Index(t => t.ExaminerId)
                .Index(t => t.PatientId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IndexedEntityKeywords", "PatientData_Id", "dbo.PatientDatas");
            DropForeignKey("dbo.ExaminationDatas", "PatientId", "dbo.PatientDatas");
            DropForeignKey("dbo.IndexedEntityKeywords", "ExaminerData_Id", "dbo.ExaminerDatas");
            DropForeignKey("dbo.IndexedEntityKeywords", "Keyword_Id", "dbo.Keywords");
            DropForeignKey("dbo.ExaminationDatas", "ExaminerId", "dbo.ExaminerDatas");
            DropIndex("dbo.IndexedEntityKeywords", new[] { "PatientData_Id" });
            DropIndex("dbo.IndexedEntityKeywords", new[] { "ExaminerData_Id" });
            DropIndex("dbo.IndexedEntityKeywords", new[] { "Keyword_Id" });
            DropIndex("dbo.ExaminationDatas", new[] { "PatientId" });
            DropIndex("dbo.ExaminationDatas", new[] { "ExaminerId" });
            DropTable("dbo.PatientDatas");
            DropTable("dbo.Keywords");
            DropTable("dbo.IndexedEntityKeywords");
            DropTable("dbo.ExaminerDatas");
            DropTable("dbo.ExaminationDatas");
        }
    }
}
