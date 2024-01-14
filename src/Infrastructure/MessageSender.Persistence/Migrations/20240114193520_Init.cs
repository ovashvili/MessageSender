using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MessageSender.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Secret = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Config = table.Column<string>(type: "nvarchar(2000)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Alpha2Code = table.Column<string>(type: "char(2)", nullable: false),
                    DialCode = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Alpha2Code);
                });

            migrationBuilder.CreateTable(
                name: "GreyList",
                columns: table => new
                {
                    ContactIdentifier = table.Column<string>(type: "varchar(255)", nullable: false),
                    Status = table.Column<string>(type: "varchar(32)", nullable: false, comment: "Possible Values:\nBlack\nWhite"),
                    StatusNote = table.Column<string>(type: "nvarchar(511)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GreyList", x => x.ContactIdentifier);
                });

            migrationBuilder.CreateTable(
                name: "Provider",
                columns: table => new
                {
                    ProviderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(64)", nullable: false),
                    Priority = table.Column<short>(type: "SMALLINT", nullable: false, defaultValueSql: "32767"),
                    Config = table.Column<string>(type: "nvarchar(2000)", nullable: false),
                    IsGlobal = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.ProviderId);
                });

            migrationBuilder.CreateTable(
                name: "Sms",
                columns: table => new
                {
                    SmsId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "varchar(32)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sms", x => x.SmsId);
                    table.ForeignKey(
                        name: "FK_Sms_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryProvider",
                columns: table => new
                {
                    CountryProviderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Priority = table.Column<short>(type: "SMALLINT", nullable: false, defaultValueSql: "32767"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Alpha2Code = table.Column<string>(type: "char(2)", nullable: false),
                    ProviderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryProvider", x => x.CountryProviderId);
                    table.ForeignKey(
                        name: "FK_CountryProvider_Country_Alpha2Code",
                        column: x => x.Alpha2Code,
                        principalTable: "Country",
                        principalColumn: "Alpha2Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryProvider_Provider_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Provider",
                        principalColumn: "ProviderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageDelivery",
                columns: table => new
                {
                    MessageDeliveryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "varchar(32)", nullable: false, comment: "Possible Values:\nSendingToProvider\nSuccessFromProvider\nDeliveredToUser\nFailFromProvider\nFail\nUnknown"),
                    StatusNote = table.Column<string>(type: "nvarchar(511)", nullable: true),
                    ProviderMessageId = table.Column<string>(type: "varchar(64)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    SmsId = table.Column<long>(type: "bigint", nullable: true),
                    ProviderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageDelivery", x => x.MessageDeliveryId);
                    table.ForeignKey(
                        name: "FK_MessageDelivery_Provider_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Provider",
                        principalColumn: "ProviderId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_MessageDelivery_Sms_SmsId",
                        column: x => x.SmsId,
                        principalTable: "Sms",
                        principalColumn: "SmsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ClientId", "Config", "IsActive", "Secret" },
                values: new object[,]
                {
                    { new Guid("58165150-b0b2-44c8-88cd-5db0ca565899"), "{\"SmsFrom\": \"OTP\", \"field2\": \"value2\"}", true, new Guid("3dc86176-eac1-4da9-9718-542942bfa82d") },
                    { new Guid("d195a1cf-7de3-4793-a2b2-6a4c9d5fa09b"), "{\"field1\": \"value1\", \"field2\": \"value2\"}", false, new Guid("517104f3-f0c5-4fe7-b75a-76d46f3528e5") }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Alpha2Code", "DialCode", "IsActive" },
                values: new object[,]
                {
                    { "AM", (short)374, true },
                    { "GE", (short)995, true },
                    { "US", (short)1, true }
                });

            migrationBuilder.InsertData(
                table: "GreyList",
                columns: new[] { "ContactIdentifier", "IsActive", "Status", "StatusNote" },
                values: new object[] { "555444333", true, "Black", "Blocked" });

            migrationBuilder.InsertData(
                table: "Provider",
                columns: new[] { "ProviderId", "Config", "IsActive", "IsGlobal", "Name", "Priority" },
                values: new object[,]
                {
                    { 1, "{\"provider-specific-field\": \"value1\"}", true, false, "Magti", (short)1 },
                    { 2, "{\"provider-specific-field\": \"value2\"}", true, false, "Silknet", (short)2 },
                    { 3, "{\"provider-specific-field\": \"value3\"}", true, false, "Peleka", (short)3 },
                    { 4, "{\"provider-specific-field\": \"value4\"}", true, true, "Nexmo", (short)1 }
                });

            migrationBuilder.InsertData(
                table: "CountryProvider",
                columns: new[] { "CountryProviderId", "Alpha2Code", "IsActive", "Priority", "ProviderId" },
                values: new object[,]
                {
                    { 1, "GE", true, (short)1, 1 },
                    { 2, "GE", true, (short)2, 2 },
                    { 3, "AM", true, (short)1, 3 },
                    { 4, "US", true, (short)1, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Country_DialCode",
                table: "Country",
                column: "DialCode");

            migrationBuilder.CreateIndex(
                name: "IX_CountryProvider_Alpha2Code",
                table: "CountryProvider",
                column: "Alpha2Code");

            migrationBuilder.CreateIndex(
                name: "IX_CountryProvider_ProviderId",
                table: "CountryProvider",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageDelivery_ProviderId",
                table: "MessageDelivery",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageDelivery_SmsId",
                table: "MessageDelivery",
                column: "SmsId");

            migrationBuilder.CreateIndex(
                name: "IX_Provider_Name_UQ",
                table: "Provider",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sms_ClientId",
                table: "Sms",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryProvider");

            migrationBuilder.DropTable(
                name: "GreyList");

            migrationBuilder.DropTable(
                name: "MessageDelivery");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Provider");

            migrationBuilder.DropTable(
                name: "Sms");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
