namespace WorkManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        WorkerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Salary = c.Short(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender = c.Boolean(nullable: false),
                        WorkerImageUrl = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.WorkerId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.WorkerGalleries",
                c => new
                    {
                        WorkerImageGalleryId = c.Int(nullable: false, identity: true),
                        GalleryName = c.String(),
                        GalleryUrl = c.String(),
                        WorkerId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.WorkerImageGalleryId)
                .ForeignKey("dbo.Workers", t => t.WorkerId, cascadeDelete: true)
                .Index(t => t.WorkerId);
            
            CreateTable(
                "dbo.WorkerImages",
                c => new
                    {
                        WorkerImageId = c.Int(nullable: false, identity: true),
                        ImageName = c.String(),
                        ImageUrl = c.String(),
                        WorkerId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.WorkerImageId)
                .ForeignKey("dbo.Workers", t => t.WorkerId, cascadeDelete: true)
                .Index(t => t.WorkerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkerImages", "WorkerId", "dbo.Workers");
            DropForeignKey("dbo.WorkerGalleries", "WorkerId", "dbo.Workers");
            DropForeignKey("dbo.Workers", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.WorkerImages", new[] { "WorkerId" });
            DropIndex("dbo.WorkerGalleries", new[] { "WorkerId" });
            DropIndex("dbo.Workers", new[] { "DepartmentId" });
            DropTable("dbo.WorkerImages");
            DropTable("dbo.WorkerGalleries");
            DropTable("dbo.Workers");
            DropTable("dbo.Departments");
        }
    }
}
