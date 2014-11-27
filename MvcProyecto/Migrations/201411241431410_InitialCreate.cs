namespace MvcProyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Salas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Aula = c.String(),
                        Salon = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Computadors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SalaId = c.Int(nullable: false),
                        Serial = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Salas", t => t.SalaId, cascadeDelete: true)
                .Index(t => t.SalaId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Computadors", new[] { "SalaId" });
            DropForeignKey("dbo.Computadors", "SalaId", "dbo.Salas");
            DropTable("dbo.Computadors");
            DropTable("dbo.Salas");
        }
    }
}
