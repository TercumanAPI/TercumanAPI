using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tercuman.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMessageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ConversationId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Conversations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User1Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User2Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversations", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5303));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5307));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5310));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5312));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5317));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5320));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5322));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5325));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5327));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5330));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5332));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5334));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5339));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5341));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5343));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5346));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5348));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5350));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5352));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5354));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5359));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5361));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5363));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5366));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5368));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5370));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5372));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5375));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5379));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5381));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5384));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5386));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5388));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5390));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5393));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5395));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5399));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5402));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5404));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5406));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5408));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5410));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5412));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5415));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5419));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5421));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5423));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5426));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5428));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 27, 9, 59, 11, 503, DateTimeKind.Utc).AddTicks(5430));

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ConversationId",
                table: "Messages",
                column: "ConversationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Conversations_ConversationId",
                table: "Messages",
                column: "ConversationId",
                principalTable: "Conversations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Conversations_ConversationId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "Conversations");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ConversationId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ConversationId",
                table: "Messages");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4146));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4151));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4153));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4155));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4157));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4159));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4161));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4165));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4167));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4169));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4171));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4173));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4175));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4176));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4179));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4182));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4184));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4186));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4188));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4190));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4191));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4193));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4195));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4199));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4201));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4202));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4204));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4206));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4208));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4211));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4213));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4216));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4218));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4220));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4222));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4224));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4226));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4228));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4229));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4233));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4235));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4237));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4239));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4240));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4242));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4244));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4246));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4249));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4251));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                column: "CreatedDate",
                value: new DateTime(2026, 2, 26, 10, 26, 55, 299, DateTimeKind.Utc).AddTicks(4253));
        }
    }
}
