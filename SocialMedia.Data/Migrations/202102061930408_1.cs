namespace SocialMedia.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comment", "PostId", c => c.Int(nullable: false));
            AddColumn("dbo.Reply", "ReplyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comment", "PostId");
            CreateIndex("dbo.Reply", "ReplyId");
            AddForeignKey("dbo.Comment", "PostId", "dbo.Post", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Reply", "ReplyId", "dbo.Reply", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reply", "ReplyId", "dbo.Reply");
            DropForeignKey("dbo.Comment", "PostId", "dbo.Post");
            DropIndex("dbo.Reply", new[] { "ReplyId" });
            DropIndex("dbo.Comment", new[] { "PostId" });
            DropColumn("dbo.Reply", "ReplyId");
            DropColumn("dbo.Comment", "PostId");
        }
    }
}
