using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class Create_Procedure_SP_GetItemById : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE PROCEDURE SP_GetItemById
			@Id int
			AS 

			IF 1 = 0

					BEGIN

					SET FMTONLY OFF

					END

			SELECT * FROM Items
			WHERE Id = @Id

			--EXEC SP_GetItemById 1
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"      
            DROP PROCEDURE SP_GetItemById

            @Id int

            AS


            IF 1 = 0

                    BEGIN

                    SET FMTONLY OFF

                    END

            SELECT * FROM Items

            WHERE Id = @Id

            --EXEC SP_GetItemById 1
            ");
        }
    }
}
