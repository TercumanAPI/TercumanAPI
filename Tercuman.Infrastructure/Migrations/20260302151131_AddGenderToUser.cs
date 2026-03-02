using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tercuman.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddGenderToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7413));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7416));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7418));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7420));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7422));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7424));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7426));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7430));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7432));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7434));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7436));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7437));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7439));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7441));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7443));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7447));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7448));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7450));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7452));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7454));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7456));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7457));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7459));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7463));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7465));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7467));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7469));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7471));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7472));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7474));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7476));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7480));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7482));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7484));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7486));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7488));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7490));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7491));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7493));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7497));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7499));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7501));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7503));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7504));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7506));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7508));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7510));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7513));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7515));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 13, 8, 22, 900, DateTimeKind.Utc).AddTicks(7517));
        }
    }
}
