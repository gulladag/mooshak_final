namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseAssignments", "Course_ID", "dbo.Courses");
            DropForeignKey("dbo.CourseAssignments", "Assignment_ID", "dbo.Assignments");
            DropIndex("dbo.CourseAssignments", new[] { "Course_ID" });
            DropIndex("dbo.CourseAssignments", new[] { "Assignment_ID" });
            AddColumn("dbo.Assignments", "Courses_ID", c => c.Int());
            CreateIndex("dbo.Assignments", "Courses_ID");
            AddForeignKey("dbo.Assignments", "Courses_ID", "dbo.Courses", "ID");
            DropTable("dbo.CourseAssignments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CourseAssignments",
                c => new
                    {
                        Course_ID = c.Int(nullable: false),
                        Assignment_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Course_ID, t.Assignment_ID });
            
            DropForeignKey("dbo.Assignments", "Courses_ID", "dbo.Courses");
            DropIndex("dbo.Assignments", new[] { "Courses_ID" });
            DropColumn("dbo.Assignments", "Courses_ID");
            CreateIndex("dbo.CourseAssignments", "Assignment_ID");
            CreateIndex("dbo.CourseAssignments", "Course_ID");
            AddForeignKey("dbo.CourseAssignments", "Assignment_ID", "dbo.Assignments", "ID", cascadeDelete: true);
            AddForeignKey("dbo.CourseAssignments", "Course_ID", "dbo.Courses", "ID", cascadeDelete: true);
        }
    }
}
