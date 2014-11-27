namespace MvcProyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migra : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Computadors", "Serial", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Computadors", "Serial", c => c.String());
        }
    }
}
