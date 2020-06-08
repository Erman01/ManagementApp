namespace WorkManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteWorkerImageTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkerImages", "WorkerImageGalleryId", "dbo.WorkerGalleries");
            DropForeignKey("dbo.WorkerImages", "Worker_WorkerId", "dbo.Workers");
            DropIndex("dbo.WorkerImages", new[] { "WorkerImageGalleryId" });
            DropIndex("dbo.WorkerImages", new[] { "Worker_WorkerId" });
            DropTable("dbo.WorkerImages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WorkerImages",
                c => new
                    {
                        WorkerImageId = c.Int(nullable: false, identity: true),
                        ImageName = c.String(),
                        ImageUrl = c.String(),
                        WorkerImageGalleryId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        Worker_WorkerId = c.Int(),
                    })
                .PrimaryKey(t => t.WorkerImageId);
            
            CreateIndex("dbo.WorkerImages", "Worker_WorkerId");
            CreateIndex("dbo.WorkerImages", "WorkerImageGalleryId");
            AddForeignKey("dbo.WorkerImages", "Worker_WorkerId", "dbo.Workers", "WorkerId");
            AddForeignKey("dbo.WorkerImages", "WorkerImageGalleryId", "dbo.WorkerGalleries", "WorkerImageGalleryId", cascadeDelete: true);
        }
    }
}
