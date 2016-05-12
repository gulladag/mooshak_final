namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AssignmentMilestoneViewModels", "AssignmentViewModel_ID", "dbo.AssignmentViewModels");
            DropForeignKey("dbo.Assignments", "CourseViewModel_ID", "dbo.CourseViewModels");
            DropForeignKey("dbo.AspNetUsers", "CourseViewModel_ID", "dbo.CourseViewModels");
            DropIndex("dbo.AssignmentMilestoneViewModels", new[] { "AssignmentViewModel_ID" });
            DropIndex("dbo.Assignments", new[] { "CourseViewModel_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "CourseViewModel_ID" });
            DropColumn("dbo.Assignments", "CourseViewModel_ID");
            DropColumn("dbo.AspNetUsers", "CourseViewModel_ID");
            DropTable("dbo.AssignmentMilestoneViewModels");
            DropTable("dbo.AssignmentViewModels");
            DropTable("dbo.CourseViewModels");
            DropTable("dbo.CreateMilestoneViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CreateMilestoneViewModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AssignmentID = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        weight = c.Int(nullable: false),
                        Input = c.String(nullable: false),
                        Output = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CourseViewModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AssignmentViewModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CourseID = c.Int(nullable: false),
                        CourseName = c.String(),
                        Description = c.String(),
                        StartDate = c.String(),
                        StartTime = c.String(nullable: false),
                        EndDate = c.String(),
                        EndTime = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AssignmentMilestoneViewModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        weight = c.Int(nullable: false),
                        AssignmentViewModel_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.AspNetUsers", "CourseViewModel_ID", c => c.Int());
            AddColumn("dbo.Assignments", "CourseViewModel_ID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "CourseViewModel_ID");
            CreateIndex("dbo.Assignments", "CourseViewModel_ID");
            CreateIndex("dbo.AssignmentMilestoneViewModels", "AssignmentViewModel_ID");
            AddForeignKey("dbo.AspNetUsers", "CourseViewModel_ID", "dbo.CourseViewModels", "ID");
            AddForeignKey("dbo.Assignments", "CourseViewModel_ID", "dbo.CourseViewModels", "ID");
            AddForeignKey("dbo.AssignmentMilestoneViewModels", "AssignmentViewModel_ID", "dbo.AssignmentViewModels", "ID");
        }
    }
}
