namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Submissions", "ProjectID", c => c.Int(nullable: false));
            AddColumn("dbo.Submissions", "AssigmentID", c => c.Int(nullable: false));
            AddColumn("dbo.Submissions", "SubmittedCode", c => c.String());
            AddColumn("dbo.Submissions", "IsCorrect", c => c.Boolean(nullable: false));
            DropColumn("dbo.Submissions", "line");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Submissions", "line", c => c.String());
            DropColumn("dbo.Submissions", "IsCorrect");
            DropColumn("dbo.Submissions", "SubmittedCode");
            DropColumn("dbo.Submissions", "AssigmentID");
            DropColumn("dbo.Submissions", "ProjectID");
        }
    }
}
