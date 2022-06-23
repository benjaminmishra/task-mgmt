using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Data.Migrations
{
    public partial class AddUserInfosData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "UserId", "CreatedDate", "DisplayName", "Email", "Password", "UserName" },
                values: new object[] { 1, new DateTime(2022, 6, 23, 12, 43, 16, 936, DateTimeKind.Utc).AddTicks(6008), "John Doe", "john@abc.com", "xyz", "jhon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "UserId",
                keyValue: 1);
        }
    }
}
