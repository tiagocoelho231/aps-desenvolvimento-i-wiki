namespace Wiki.Data.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCharacterType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CharacterType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Character", "IdType", c => c.Int(nullable: false));
            CreateIndex("dbo.Character", "IdType");
            AddForeignKey("dbo.Character", "IdType", "dbo.CharacterType", "Id", cascadeDelete: true);
            DropColumn("dbo.Character", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Character", "Type", c => c.String(nullable: false, maxLength: 50));
            DropForeignKey("dbo.Character", "IdType", "dbo.CharacterType");
            DropIndex("dbo.Character", new[] { "IdType" });
            DropColumn("dbo.Character", "IdType");
            DropTable("dbo.CharacterType");
        }
    }
}
