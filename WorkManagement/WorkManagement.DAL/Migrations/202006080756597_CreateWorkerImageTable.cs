namespace WorkManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateWorkerImageTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorkerImages",
                c => new
                    {
                        WorkerImageId = c.Int(nullable: false, identity: true),
                        ImageName = c.String(),
                        ImageUrl = c.String(),
                        WorkerImageGalleryId = c.Int(nullable: false),
                        WorkerId = c.Int(),
                    })
                .PrimaryKey(t => t.WorkerImageId)
                .ForeignKey("dbo.Workers", t => t.WorkerId)
                .ForeignKey("dbo.WorkerGalleries", t => t.WorkerImageGalleryId, cascadeDelete: true)
                .Index(t => t.WorkerImageGalleryId)
                .Index(t => t.WorkerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkerImages", "WorkerImageGalleryId", "dbo.WorkerGalleries");
            DropForeignKey("dbo.WorkerImages", "WorkerId", "dbo.Workers");
            DropIndex("dbo.WorkerImages", new[] { "WorkerId" });
            DropIndex("dbo.WorkerImages", new[] { "WorkerImageGalleryId" });
            DropTable("dbo.WorkerImages");
        }
    }
}
