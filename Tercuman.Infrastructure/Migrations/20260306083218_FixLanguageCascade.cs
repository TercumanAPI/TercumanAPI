using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tercuman.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixLanguageCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ListingViews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Listings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ListingImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Favorites",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7641));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7646));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7649));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7654));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7657));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7659));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7662));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7666));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7669));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7672));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7674));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7678));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7681));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7683));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7685));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7688));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7690));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7692));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7695));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7699));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7701));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7704));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7707));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7710));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7713));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7715));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7718));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7722));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7724));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7726));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7729));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7731));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7733));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7736));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7738));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7743));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7746));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7749));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7751));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7754));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7756));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7758));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7761));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7843));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7846));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7849));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7851));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7854));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7856));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 6, 8, 32, 18, 227, DateTimeKind.Utc).AddTicks(7859));

            migrationBuilder.CreateIndex(
                name: "IX_Listings_SourceLanguageId",
                table: "Listings",
                column: "SourceLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_TargetLanguageId",
                table: "Listings",
                column: "TargetLanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Languages_SourceLanguageId",
                table: "Listings",
                column: "SourceLanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Languages_TargetLanguageId",
                table: "Listings",
                column: "TargetLanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Languages_SourceLanguageId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Languages_TargetLanguageId",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_Listings_SourceLanguageId",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_Listings_TargetLanguageId",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ListingViews");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ListingImages");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Favorites");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6886));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6890));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6893));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6896));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6898));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6903));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6906));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6908));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6911));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6914));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6916));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6919));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6921));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6926));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6929));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6931));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6934));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6936));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6938));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6941));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6943));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6948));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6951));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6953));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6955));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6958));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6960));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6963));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6965));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6970));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6973));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6976));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6979));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6981));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6984));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6987));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6989));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6994));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6996));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(6999));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(7001));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(7004));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(7006));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(7008));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(7011));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(7017));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(7020));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(7022));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(7024));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 2, 15, 11, 27, 534, DateTimeKind.Utc).AddTicks(7027));
        }
    }
}
