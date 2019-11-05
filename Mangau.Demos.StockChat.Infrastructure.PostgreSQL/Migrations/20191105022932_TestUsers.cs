using Microsoft.EntityFrameworkCore.Migrations;

namespace Mangau.Demos.StockChat.Infrastructure.PostgreSQL.Migrations
{
    public partial class TestUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "secgroup",
                columns: new[] { "Id", "Active", "Description", "Name" },
                values: new object[,]
                {
                    { 3L, true, "System's Internal Users", "Internals" },
                    { 4L, true, "Users for Testing", "TestUsers" }
                });

            migrationBuilder.UpdateData(
                table: "secuser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2y$12$NisvmmSjik8b3FMY8Muhb.tvuW/FDQyMhvM879rRVaaBSXajktHYy");

            migrationBuilder.InsertData(
                table: "secuser",
                columns: new[] { "Id", "Active", "FirstName", "LastName", "Password", "UserName" },
                values: new object[] { 3L, true, "Test", "02", "$2y$12$NisvmmSjik8b3FMY8Muhb.tvuW/FDQyMhvM879rRVaaBSXajktHYy", "test02" });

            migrationBuilder.InsertData(
                table: "secuser",
                columns: new[] { "Id", "Active", "FirstName", "LastName", "Password", "UserName" },
                values: new object[] { 4L, true, "Test", "03", "$2y$12$NisvmmSjik8b3FMY8Muhb.tvuW/FDQyMhvM879rRVaaBSXajktHYy", "test03" });

            migrationBuilder.InsertData(
                table: "secuser",
                columns: new[] { "Id", "Active", "FirstName", "LastName", "Password", "UserName" },
                values: new object[] { 5L, true, "Test", "04", "$2y$12$NisvmmSjik8b3FMY8Muhb.tvuW/FDQyMhvM879rRVaaBSXajktHYy", "test04" });

            migrationBuilder.InsertData(
                table: "secuser",
                columns: new[] { "Id", "Active", "FirstName", "LastName", "Password", "UserName" },
                values: new object[] { 6L, true, "Test", "05", "$2y$12$NisvmmSjik8b3FMY8Muhb.tvuW/FDQyMhvM879rRVaaBSXajktHYy", "test05" });

            migrationBuilder.InsertData(
                table: "secuser",
                columns: new[] { "Id", "Active", "FirstName", "LastName", "Password", "UserName" },
                values: new object[] { 7L, true, "Test", "06", "$2y$12$NisvmmSjik8b3FMY8Muhb.tvuW/FDQyMhvM879rRVaaBSXajktHYy", "test06" });

            migrationBuilder.InsertData(
                table: "secuser",
                columns: new[] { "Id", "Active", "FirstName", "LastName", "Password", "UserName" },
                values: new object[] { 8L, true, "Test", "07", "$2y$12$NisvmmSjik8b3FMY8Muhb.tvuW/FDQyMhvM879rRVaaBSXajktHYy", "test07" });

            migrationBuilder.InsertData(
                table: "secuser",
                columns: new[] { "Id", "Active", "FirstName", "LastName", "Password", "UserName" },
                values: new object[] { 9L, true, "Test", "08", "$2y$12$NisvmmSjik8b3FMY8Muhb.tvuW/FDQyMhvM879rRVaaBSXajktHYy", "test08" });

            migrationBuilder.InsertData(
                table: "secuser",
                columns: new[] { "Id", "Active", "FirstName", "LastName", "Password", "UserName" },
                values: new object[] { 10L, true, "Test", "09", "$2y$12$NisvmmSjik8b3FMY8Muhb.tvuW/FDQyMhvM879rRVaaBSXajktHYy", "test09" });

            migrationBuilder.InsertData(
                table: "secuser",
                columns: new[] { "Id", "Active", "FirstName", "LastName", "Password", "UserName" },
                values: new object[] { 11L, true, "Test", "10", "$2y$12$NisvmmSjik8b3FMY8Muhb.tvuW/FDQyMhvM879rRVaaBSXajktHYy", "test10" });

            migrationBuilder.InsertData(
                table: "secuser",
                columns: new[] { "Id", "Active", "FirstName", "LastName", "Password", "UserName" },
                values: new object[] { 12L, true, "Chat", "Bot", "", "chatbot" });

            migrationBuilder.InsertData(
                table: "secgrouppermission",
                columns: new[] { "GroupId", "PermissionId" },
                values: new object[] { 4L, 1L });

            migrationBuilder.InsertData(
                table: "secgroupuser",
                columns: new[] { "GroupId", "UserId" },
                values: new object[,]
                {
                    { 1L, 11L },
                    { 4L, 10L },
                    { 1L, 10L },
                    { 4L, 9L },
                    { 1L, 9L },
                    { 4L, 8L },
                    { 1L, 8L },
                    { 4L, 7L },
                    { 4L, 11L },
                    { 1L, 7L },
                    { 1L, 6L },
                    { 4L, 5L },
                    { 1L, 5L },
                    { 4L, 4L },
                    { 1L, 4L },
                    { 4L, 3L },
                    { 1L, 3L },
                    { 4L, 2L },
                    { 4L, 6L },
                    { 3L, 12L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "secgrouppermission",
                keyColumns: new[] { "GroupId", "PermissionId" },
                keyValues: new object[] { 4L, 1L });

            migrationBuilder.DeleteData(
                table: "secgroupuser",
                keyColumns: new[] { "GroupId", "UserId" },
                keyValues: new object[] { 1L, 3L });

            migrationBuilder.DeleteData(
                table: "secgroupuser",
                keyColumns: new[] { "GroupId", "UserId" },
                keyValues: new object[] { 1L, 4L });

            migrationBuilder.DeleteData(
                table: "secgroupuser",
                keyColumns: new[] { "GroupId", "UserId" },
                keyValues: new object[] { 1L, 5L });

            migrationBuilder.DeleteData(
                table: "secgroupuser",
                keyColumns: new[] { "GroupId", "UserId" },
                keyValues: new object[] { 1L, 6L });

            migrationBuilder.DeleteData(
                table: "secgroupuser",
                keyColumns: new[] { "GroupId", "UserId" },
                keyValues: new object[] { 1L, 7L });

            migrationBuilder.DeleteData(
                table: "secgroupuser",
                keyColumns: new[] { "GroupId", "UserId" },
                keyValues: new object[] { 1L, 8L });

            migrationBuilder.DeleteData(
                table: "secgroupuser",
                keyColumns: new[] { "GroupId", "UserId" },
                keyValues: new object[] { 1L, 9L });

            migrationBuilder.DeleteData(
                table: "secgroupuser",
                keyColumns: new[] { "GroupId", "UserId" },
                keyValues: new object[] { 1L, 10L });

            migrationBuilder.DeleteData(
                table: "secgroupuser",
                keyColumns: new[] { "GroupId", "UserId" },
                keyValues: new object[] { 1L, 11L });

            migrationBuilder.DeleteData(
                table: "secgroupuser",
                keyColumns: new[] { "GroupId", "UserId" },
                keyValues: new object[] { 3L, 12L });

            migrationBuilder.DeleteData(
                table: "secgroupuser",
                keyColumns: new[] { "GroupId", "UserId" },
                keyValues: new object[] { 4L, 2L });

            migrationBuilder.DeleteData(
                table: "secgroupuser",
                keyColumns: new[] { "GroupId", "UserId" },
                keyValues: new object[] { 4L, 3L });

            migrationBuilder.DeleteData(
                table: "secgroupuser",
                keyColumns: new[] { "GroupId", "UserId" },
                keyValues: new object[] { 4L, 4L });

            migrationBuilder.DeleteData(
                table: "secgroupuser",
                keyColumns: new[] { "GroupId", "UserId" },
                keyValues: new object[] { 4L, 5L });

            migrationBuilder.DeleteData(
                table: "secgroupuser",
                keyColumns: new[] { "GroupId", "UserId" },
                keyValues: new object[] { 4L, 6L });

            migrationBuilder.DeleteData(
                table: "secgroupuser",
                keyColumns: new[] { "GroupId", "UserId" },
                keyValues: new object[] { 4L, 7L });

            migrationBuilder.DeleteData(
                table: "secgroupuser",
                keyColumns: new[] { "GroupId", "UserId" },
                keyValues: new object[] { 4L, 8L });

            migrationBuilder.DeleteData(
                table: "secgroupuser",
                keyColumns: new[] { "GroupId", "UserId" },
                keyValues: new object[] { 4L, 9L });

            migrationBuilder.DeleteData(
                table: "secgroupuser",
                keyColumns: new[] { "GroupId", "UserId" },
                keyValues: new object[] { 4L, 10L });

            migrationBuilder.DeleteData(
                table: "secgroupuser",
                keyColumns: new[] { "GroupId", "UserId" },
                keyValues: new object[] { 4L, 11L });

            migrationBuilder.DeleteData(
                table: "secgroup",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "secgroup",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "secuser",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "secuser",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "secuser",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "secuser",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "secuser",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "secuser",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "secuser",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "secuser",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "secuser",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "secuser",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.UpdateData(
                table: "secuser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2y$10$qrGKsfUDysr7fR18ZWlkxOYWMg6D.Of3CeCUzZLGC27xS4VV4AzqW");
        }
    }
}
