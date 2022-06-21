using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class CREATE_SP_AddItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE PROCEDURE [dbo].[SP_AddItem]
            (          
                @Name VARCHAR(50),           
                @Price INT,          
                @Vat INT,          
                @ItemCategoryId INT,  
                @Created DATETIME,
	            @ImagePath VARCHAR(1000)
            )          
            AS           
            BEGIN           
                INSERT INTO Items([Name],Price,Vat,ItemCategoryId, Created,ImagePath)           
                VALUES (@Name,@Price,@Vat, @ItemCategoryId,@Created,@ImagePath)           
            End 
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
