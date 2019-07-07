namespace MailSenderLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rev01 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Recipients", "Description", c => c.String());
            AlterColumn("dbo.Senders", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Senders", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Recipients", "Description", c => c.String(nullable: false));
        }
    }
}
