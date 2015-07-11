namespace Entity_HW2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lectures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryId = c.Int(nullable: false),
                        Description = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Text = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MaxTime = c.Int(nullable: false),
                        PassMark = c.Int(nullable: false),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.TestWorks",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Mark = c.Int(nullable: false),
                        Time = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tests", t => t.Id)
                .ForeignKey("dbo.Students", t => t.UserId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Age = c.Int(nullable: false),
                        Sity = c.String(),
                        Univercity = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.TeacherLectures",
                c => new
                    {
                        Teacher_Id = c.Int(nullable: false),
                        Lecture_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Teacher_Id, t.Lecture_Id })
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id, cascadeDelete: true)
                .ForeignKey("dbo.Lectures", t => t.Lecture_Id, cascadeDelete: true)
                .Index(t => t.Teacher_Id)
                .Index(t => t.Lecture_Id);
            
            CreateTable(
                "dbo.TestQuestions",
                c => new
                    {
                        Test_Id = c.Int(nullable: false),
                        Question_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Test_Id, t.Question_Id })
                .ForeignKey("dbo.Tests", t => t.Test_Id, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.Question_Id, cascadeDelete: true)
                .Index(t => t.Test_Id)
                .Index(t => t.Question_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestWorks", "UserId", "dbo.Students");
            DropForeignKey("dbo.Students", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.TestWorks", "Id", "dbo.Tests");
            DropForeignKey("dbo.TestQuestions", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.TestQuestions", "Test_Id", "dbo.Tests");
            DropForeignKey("dbo.Tests", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Questions", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.TeacherLectures", "Lecture_Id", "dbo.Lectures");
            DropForeignKey("dbo.TeacherLectures", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.Lectures", "CategoryId", "dbo.Categories");
            DropIndex("dbo.TestQuestions", new[] { "Question_Id" });
            DropIndex("dbo.TestQuestions", new[] { "Test_Id" });
            DropIndex("dbo.TeacherLectures", new[] { "Lecture_Id" });
            DropIndex("dbo.TeacherLectures", new[] { "Teacher_Id" });
            DropIndex("dbo.Students", new[] { "CategoryId" });
            DropIndex("dbo.TestWorks", new[] { "UserId" });
            DropIndex("dbo.TestWorks", new[] { "Id" });
            DropIndex("dbo.Tests", new[] { "Category_Id" });
            DropIndex("dbo.Questions", new[] { "CategoryId" });
            DropIndex("dbo.Lectures", new[] { "CategoryId" });
            DropTable("dbo.TestQuestions");
            DropTable("dbo.TeacherLectures");
            DropTable("dbo.Students");
            DropTable("dbo.TestWorks");
            DropTable("dbo.Tests");
            DropTable("dbo.Questions");
            DropTable("dbo.Teachers");
            DropTable("dbo.Lectures");
            DropTable("dbo.Categories");
        }
    }
}
