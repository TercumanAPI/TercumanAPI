using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tercuman.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialLanguagesAndListingUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExperienceLevel",
                table: "Listings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServiceType",
                table: "Listings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "SourceLanguageId",
                table: "Listings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TargetLanguageId",
                table: "Listings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "CreatedDate", "IsDeleted", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "tr", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4146), false, "Turkish", null },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "ar", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4151), false, "Arabic", null },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "en", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4153), false, "English", null },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "de", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4155), false, "German", null },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "fr", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4157), false, "French", null },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "es", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4159), false, "Spanish", null },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "it", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4161), false, "Italian", null },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "ru", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4165), false, "Russian", null },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "zh", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4167), false, "Chinese", null },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "ja", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4169), false, "Japanese", null },
                    { new Guid("00000000-0000-0000-0000-000000000011"), "ko", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4171), false, "Korean", null },
                    { new Guid("00000000-0000-0000-0000-000000000012"), "pt", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4173), false, "Portuguese", null },
                    { new Guid("00000000-0000-0000-0000-000000000013"), "nl", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4175), false, "Dutch", null },
                    { new Guid("00000000-0000-0000-0000-000000000014"), "el", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4176), false, "Greek", null },
                    { new Guid("00000000-0000-0000-0000-000000000015"), "fa", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4179), false, "Persian", null },
                    { new Guid("00000000-0000-0000-0000-000000000016"), "hi", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4182), false, "Hindi", null },
                    { new Guid("00000000-0000-0000-0000-000000000017"), "ur", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4184), false, "Urdu", null },
                    { new Guid("00000000-0000-0000-0000-000000000018"), "he", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4186), false, "Hebrew", null },
                    { new Guid("00000000-0000-0000-0000-000000000019"), "sv", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4188), false, "Swedish", null },
                    { new Guid("00000000-0000-0000-0000-000000000020"), "no", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4190), false, "Norwegian", null },
                    { new Guid("00000000-0000-0000-0000-000000000021"), "da", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4191), false, "Danish", null },
                    { new Guid("00000000-0000-0000-0000-000000000022"), "fi", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4193), false, "Finnish", null },
                    { new Guid("00000000-0000-0000-0000-000000000023"), "pl", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4195), false, "Polish", null },
                    { new Guid("00000000-0000-0000-0000-000000000024"), "cs", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4199), false, "Czech", null },
                    { new Guid("00000000-0000-0000-0000-000000000025"), "hu", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4201), false, "Hungarian", null },
                    { new Guid("00000000-0000-0000-0000-000000000026"), "ro", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4202), false, "Romanian", null },
                    { new Guid("00000000-0000-0000-0000-000000000027"), "bg", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4204), false, "Bulgarian", null },
                    { new Guid("00000000-0000-0000-0000-000000000028"), "sr", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4206), false, "Serbian", null },
                    { new Guid("00000000-0000-0000-0000-000000000029"), "hr", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4208), false, "Croatian", null },
                    { new Guid("00000000-0000-0000-0000-000000000030"), "bs", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4211), false, "Bosnian", null },
                    { new Guid("00000000-0000-0000-0000-000000000031"), "sq", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4213), false, "Albanian", null },
                    { new Guid("00000000-0000-0000-0000-000000000032"), "uk", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4216), false, "Ukrainian", null },
                    { new Guid("00000000-0000-0000-0000-000000000033"), "ka", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4218), false, "Georgian", null },
                    { new Guid("00000000-0000-0000-0000-000000000034"), "hy", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4220), false, "Armenian", null },
                    { new Guid("00000000-0000-0000-0000-000000000035"), "th", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4222), false, "Thai", null },
                    { new Guid("00000000-0000-0000-0000-000000000036"), "vi", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4224), false, "Vietnamese", null },
                    { new Guid("00000000-0000-0000-0000-000000000037"), "ms", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4226), false, "Malay", null },
                    { new Guid("00000000-0000-0000-0000-000000000038"), "id", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4228), false, "Indonesian", null },
                    { new Guid("00000000-0000-0000-0000-000000000039"), "sw", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4229), false, "Swahili", null },
                    { new Guid("00000000-0000-0000-0000-000000000040"), "af", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4233), false, "Afrikaans", null },
                    { new Guid("00000000-0000-0000-0000-000000000041"), "am", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4235), false, "Amharic", null },
                    { new Guid("00000000-0000-0000-0000-000000000042"), "az", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4237), false, "Azerbaijani", null },
                    { new Guid("00000000-0000-0000-0000-000000000043"), "kk", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4239), false, "Kazakh", null },
                    { new Guid("00000000-0000-0000-0000-000000000044"), "uz", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4240), false, "Uzbek", null },
                    { new Guid("00000000-0000-0000-0000-000000000045"), "tk", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4242), false, "Turkmen", null },
                    { new Guid("00000000-0000-0000-0000-000000000046"), "ku", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4244), false, "Kurdish", null },
                    { new Guid("00000000-0000-0000-0000-000000000047"), "ps", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4246), false, "Pashto", null },
                    { new Guid("00000000-0000-0000-0000-000000000048"), "bn", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4249), false, "Bengali", null },
                    { new Guid("00000000-0000-0000-0000-000000000049"), "ta", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4251), false, "Tamil", null },
                    { new Guid("00000000-0000-0000-0000-000000000050"), "te", new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4253), false, "Telugu", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropColumn(
                name: "ExperienceLevel",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "ServiceType",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "SourceLanguageId",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "TargetLanguageId",
                table: "Listings");
        }
    }
}
