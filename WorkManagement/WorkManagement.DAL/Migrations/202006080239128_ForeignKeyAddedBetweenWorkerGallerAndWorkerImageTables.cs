namespace WorkManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeyAddedBetweenWorkerGallerAndWorkerImageTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkerImages", "WorkerId", "dbo.Workers");
            DropIndex("dbo.WorkerImages", new[] { "WorkerId" });
            RenameColumn(table: "dbo.WorkerImages", name: "WorkerId", newName: "Worker_WorkerId");
            AddColumn("dbo.WorkerImages", "WorkerImageGalleryId", c => c.Int(nullable: false));
            AlterColumn("dbo.WorkerImages", "Worker_WorkerId", c => c.Int());
            CreateIndex("dbo.WorkerImages", "WorkerImageGalleryId");
            CreateIndex("dbo.WorkerImages", "Worker_WorkerId");
            AddForeignKey("dbo.WorkerImages", "WorkerImageGalleryId", "dbo.WorkerGalleries", "WorkerImageGalleryId", cascadeDelete: true);
            AddForeignKey("dbo.WorkerImages", "Worker_WorkerId", "dbo.Workers", "WorkerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkerImages", "Worker_WorkerId", "dbo.Workers");
            DropForeignKey("dbo.WorkerImages", "WorkerImageGalleryId", "dbo.WorkerGalleries");
            DropIndex("dbo.WorkerImages", new[] { "Worker_WorkerId" });
            DropIndex("dbo.WorkerImages", new[] { "WorkerImageGalleryId" });
            AlterColumn("dbo.WorkerImages", "Worker_WorkerId", c => c.Int(nullable: false));
            DropColumn("dbo.WorkerImages", "WorkerImageGalleryId");
            RenameColumn(table: "dbo.WorkerImages", name: "Worker_WorkerId", newName: "WorkerId");
            CreateIndex("dbo.WorkerImages", "WorkerId");
            AddForeignKey("dbo.WorkerImages", "WorkerId", "dbo.Workers", "WorkerId", cascadeDelete: true);
        }
    }
}
