using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseLayout.Migrations
{
    /// <inheritdoc />
    public partial class database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirFlights",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirFlights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Raiting = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlaneFacilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaneFacilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Layovers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartPointCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartPointAirport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinationAirport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlightDuration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DestinationCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinationCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartPointCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirFlightId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Layovers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Layovers_AirFlights_AirFlightId",
                        column: x => x.AirFlightId,
                        principalTable: "AirFlights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Layovers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    CNP = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImage = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Document = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.CNP);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleName",
                        column: x => x.RoleName,
                        principalTable: "Roles",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LayoverPlaneFacility",
                columns: table => new
                {
                    LayoversId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlaneFacilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LayoverPlaneFacility", x => new { x.LayoversId, x.PlaneFacilityId });
                    table.ForeignKey(
                        name: "FK_LayoverPlaneFacility_Layovers_LayoversId",
                        column: x => x.LayoversId,
                        principalTable: "Layovers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LayoverPlaneFacility_PlaneFacilities_PlaneFacilityId",
                        column: x => x.PlaneFacilityId,
                        principalTable: "PlaneFacilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlaneSeats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsOcuppied = table.Column<bool>(type: "bit", nullable: false),
                    LayoverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaneSeats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaneSeats_Layovers_LayoverId",
                        column: x => x.LayoverId,
                        principalTable: "Layovers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserCNP = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Users_UserCNP",
                        column: x => x.UserCNP,
                        principalTable: "Users",
                        principalColumn: "CNP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlaneSeatReservation",
                columns: table => new
                {
                    PlaneSeatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaneSeatReservation", x => new { x.PlaneSeatId, x.ReservationId });
                    table.ForeignKey(
                        name: "FK_PlaneSeatReservation_PlaneSeats_PlaneSeatId",
                        column: x => x.PlaneSeatId,
                        principalTable: "PlaneSeats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaneSeatReservation_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LayoverPlaneFacility_PlaneFacilityId",
                table: "LayoverPlaneFacility",
                column: "PlaneFacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Layovers_AirFlightId",
                table: "Layovers",
                column: "AirFlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Layovers_CompanyId",
                table: "Layovers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaneSeatReservation_ReservationId",
                table: "PlaneSeatReservation",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaneSeats_LayoverId",
                table: "PlaneSeats",
                column: "LayoverId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserCNP",
                table: "Reservations",
                column: "UserCNP");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleName",
                table: "Users",
                column: "RoleName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LayoverPlaneFacility");

            migrationBuilder.DropTable(
                name: "PlaneSeatReservation");

            migrationBuilder.DropTable(
                name: "PlaneFacilities");

            migrationBuilder.DropTable(
                name: "PlaneSeats");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Layovers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AirFlights");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
