namespace Antix.EASI.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Patient_DoB_And_Gender : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PatientDatas", "DateOfBirth", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.PatientDatas", "Gender", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PatientDatas", "Gender");
            DropColumn("dbo.PatientDatas", "DateOfBirth");
        }
    }
}
