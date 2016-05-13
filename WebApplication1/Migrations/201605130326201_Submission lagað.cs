namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Submissionlagað : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AssignmentMilestones", "Input");
            DropColumn("dbo.AssignmentMilestones", "Output");
            DropColumn("dbo.Submissions", "ProjectID");
            DropColumn("dbo.Submissions", "SubmittedCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Submissions", "SubmittedCode", c => c.String());
            AddColumn("dbo.Submissions", "ProjectID", c => c.Int(nullable: false));
            AddColumn("dbo.AssignmentMilestones", "Output", c => c.String());
            AddColumn("dbo.AssignmentMilestones", "Input", c => c.String());
        }
    }
}
