using FluentMigrator;

namespace ThinkCoreBE.Infrastructure.Persistance.Migrations
{
    [Migration(202411261741)]
    public class InitialMigration : Migration
    {
        public override void Down()
        {
            Delete.Table("Customers");
        }

        public override void Up()
        {
            Create.Table("Customers")
                .WithColumn("CustomerId").AsInt64().PrimaryKey().Identity()
                .WithColumn("Name").AsString(255).NotNullable()
                .WithColumn("Cpf").AsString(15).NotNullable()
                .WithColumn("BirthDate").AsDate().NotNullable()
                .WithColumn("ZipCode").AsString(10).NotNullable()
                .WithColumn("Street").AsString(255)
                .WithColumn("Number").AsString(50)
                .WithColumn("Complement").AsString(255)
                .WithColumn("City").AsString(100)
                .WithColumn("Country").AsString(100);
        }
    }
}
