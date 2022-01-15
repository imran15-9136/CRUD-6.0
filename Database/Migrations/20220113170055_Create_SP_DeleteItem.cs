using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class Create_SP_DeleteItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE PROCEDURE [dbo].[SP_DeleteItem]
	            @Id int = 0

            AS
            BEGIN
	            BEGIN TRAN
		            DELETE FROM Items WHERE Id = @Id
	            COMMIT TRAN
            END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
