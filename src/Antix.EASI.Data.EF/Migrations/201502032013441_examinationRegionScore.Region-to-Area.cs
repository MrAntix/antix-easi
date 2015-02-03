namespace Antix.EASI.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class examinationRegionScoreRegiontoArea : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExaminationDatas", "HeadNeck_Area", c => c.Int(nullable: false));
            AddColumn("dbo.ExaminationDatas", "Trunk_Area", c => c.Int(nullable: false));
            AddColumn("dbo.ExaminationDatas", "UpperExtremities_Area", c => c.Int(nullable: false));
            AddColumn("dbo.ExaminationDatas", "LowerExtremities_Area", c => c.Int(nullable: false));
            DropColumn("dbo.ExaminationDatas", "HeadNeck_Region");
            DropColumn("dbo.ExaminationDatas", "Trunk_Region");
            DropColumn("dbo.ExaminationDatas", "UpperExtremities_Region");
            DropColumn("dbo.ExaminationDatas", "LowerExtremities_Region");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExaminationDatas", "LowerExtremities_Region", c => c.Int(nullable: false));
            AddColumn("dbo.ExaminationDatas", "UpperExtremities_Region", c => c.Int(nullable: false));
            AddColumn("dbo.ExaminationDatas", "Trunk_Region", c => c.Int(nullable: false));
            AddColumn("dbo.ExaminationDatas", "HeadNeck_Region", c => c.Int(nullable: false));
            DropColumn("dbo.ExaminationDatas", "LowerExtremities_Area");
            DropColumn("dbo.ExaminationDatas", "UpperExtremities_Area");
            DropColumn("dbo.ExaminationDatas", "Trunk_Area");
            DropColumn("dbo.ExaminationDatas", "HeadNeck_Area");
        }
    }
}
