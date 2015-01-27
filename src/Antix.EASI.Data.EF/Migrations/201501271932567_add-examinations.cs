using System.Data.Entity.Migrations;

namespace Antix.EASI.Data.EF.Migrations
{
    public partial class addexaminations : DbMigration
    {
        public override void Up()
        {
            RenameTable("dbo.ScoreDatas", "ExaminationDatas");
            DropIndex("dbo.ExaminationDatas", new[] {"Examiner_Id"});
            RenameColumn("dbo.ExaminationDatas", "Examiner_Id", "ExaminerId");
            AddColumn("dbo.ExaminationDatas", "PatientId", c => c.Guid(false));
            AlterColumn("dbo.ExaminationDatas", "ExaminerId", c => c.Guid(false));
            CreateIndex("dbo.ExaminationDatas", "ExaminerId");
            CreateIndex("dbo.ExaminationDatas", "PatientId");
            AddForeignKey("dbo.ExaminationDatas", "PatientId", "dbo.PatientDatas", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.ExaminationDatas", "PatientId", "dbo.PatientDatas");
            DropIndex("dbo.ExaminationDatas", new[] {"PatientId"});
            DropIndex("dbo.ExaminationDatas", new[] {"ExaminerId"});
            AlterColumn("dbo.ExaminationDatas", "ExaminerId", c => c.Guid());
            DropColumn("dbo.ExaminationDatas", "PatientId");
            RenameColumn("dbo.ExaminationDatas", "ExaminerId", "Examiner_Id");
            CreateIndex("dbo.ExaminationDatas", "Examiner_Id");
            RenameTable("dbo.ExaminationDatas", "ScoreDatas");
        }
    }
}