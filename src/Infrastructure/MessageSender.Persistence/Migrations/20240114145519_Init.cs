using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
