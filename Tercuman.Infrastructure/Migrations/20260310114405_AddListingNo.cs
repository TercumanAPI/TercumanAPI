using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tercuman.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddListingNo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"));

            migrationBuilder.AddColumn<long>(
                name: "ListingNo",
                table: "Listings",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4392), "Türkçe" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4395), "Arapça" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4397), "İngilizce" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4399), "Almanca" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4401), "Fransızca" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4403), "İspanyolca" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4405), "İtalyanca" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4407), "Rusça" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4410), "Çince" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4412), "Japonca" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4414), "Korece" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4416), "Portekizce" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4418), "Hollandaca" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4419), "Yunanca" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4421), "Farsça" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4458), "Hintçe" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4462), "Urduca" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4464), "İbranice" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4467), "İsveççe" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4469), "Norveççe" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4470), "Danca" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4472), "Fince" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4474), "Lehçe" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4476), "Macarca" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4480), "Romence" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4482), "Bulgarca" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4484), "Sırpça" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4486), "Hırvatça" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4488), "Boşnakça" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4489), "Arnavutça" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4491), "Ukraynaca" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4493), "Gürcüce" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4496), "Ermenice" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4498), "Tayca" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4500), "Vietnamca" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4502), "Malayca" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4504), "Endonezce" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4506), "Svahili" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4507), "Afrikanca" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4509), "Amharca" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4513), "Azerice" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4514), "Kazakça" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4516), "Özbekçe" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4518), "Türkmence" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4520), "Kürtçe" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4522), "Peştuca" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4524), "Bengalce" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4525), "Tamilce" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 10, 11, 44, 2, 801, DateTimeKind.Utc).AddTicks(4529), "Teluguca" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ListingNo",
                table: "Listings");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(501), "Turkish" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(504), "Arabic" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(507), "English" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(512), "German" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(514), "French" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(517), "Spanish" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(519), "Italian" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(522), "Russian" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(524), "Chinese" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(526), "Japanese" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(529), "Korean" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(533), "Portuguese" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(536), "Dutch" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(538), "Greek" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(540), "Persian" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(543), "Hindi" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(545), "Urdu" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(547), "Hebrew" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(550), "Swedish" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(554), "Norwegian" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(556), "Danish" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(559), "Finnish" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(561), "Polish" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(565), "Hungarian" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(568), "Romanian" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(570), "Bulgarian" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(574), "Serbian" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(577), "Croatian" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(579), "Bosnian" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(581), "Albanian" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(583), "Ukrainian" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(586), "Georgian" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(588), "Armenian" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(590), "Thai" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(595), "Vietnamese" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(597), "Malay" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(599), "Indonesian" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(602), "Swahili" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(604), "Afrikaans" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(606), "Amharic" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(608), "Azerbaijani" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(610), "Kazakh" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(615), "Uzbek" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(617), "Turkmen" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(619), "Kurdish" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(622), "Pashto" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(624), "Bengali" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(626), "Tamil" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(629), "Telugu" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "CreatedDate", "IsDeleted", "Name", "UpdatedDate" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000024"), "cs", new DateTime(2026, 3, 6, 11, 22, 55, 296, DateTimeKind.Utc).AddTicks(563), false, "Czech", null });
        }
    }
}
