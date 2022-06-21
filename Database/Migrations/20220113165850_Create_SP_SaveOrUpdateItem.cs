using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class Create_SP_SaveOrUpdateItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE PROCEDURE [dbo].[SP_SaveOrUpdateItem]
	            @Id int = 0,
	            @Name varchar(50) = '',
	            @Price int = 0,
	            @Vat int = 0,
	            @ItemCategoryId int = 0,
	            @Created Datetime = 0,
	            @ImagePath varchar = ''

            AS
            BEGIN
	            BEGIN TRAN
		            IF(@Id = 0)
		            BEGIN
			            INSERT INTO Items([Name],Price,Vat,ItemCategoryId,Created,ImagePath) VALUES (@Name,@Price,@Vat,@ItemCategoryId,@Created,@ImagePath)
			            SET @Id = (SELECT SCOPE_IDENTITY())
		            END
		            ELSE
		            BEGIN
			            UPDATE Items SET [Name]=@Name, Price = @Price, Vat = @Vat, ItemCategoryId = @ItemCategoryId, Created = @Created, ImagePath = @ImagePath
		            END
			            SELECT * FROM Items
		            COMMIT TRAN
            END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
