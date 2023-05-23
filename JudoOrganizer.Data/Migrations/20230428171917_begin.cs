using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace JudoOrganizer.Data.Migrations
{
    public partial class begin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Organizer = table.Column<string>(type: "text", nullable: false),
                    Place = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WeightValue = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TournamentResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<string>(type: "text", nullable: false),
                    TournamentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TournamentResults_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SportCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sex = table.Column<int>(type: "integer", nullable: false),
                    DateOfBirth = table.Column<string>(type: "text", nullable: false),
                    TournamentId = table.Column<int>(type: "integer", nullable: false),
                    WeightId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SportCategories_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SportCategories_Weights_WeightId",
                        column: x => x.WeightId,
                        principalTable: "Weights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Adress = table.Column<string>(type: "text", nullable: false),
                    CityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clubs_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coaches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Patronymic = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    ClubId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coaches_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sportsmen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Patronymic = table.Column<string>(type: "text", nullable: true),
                    DateOfBirth = table.Column<string>(type: "text", nullable: false),
                    Sex = table.Column<int>(type: "integer", nullable: false),
                    ClubId = table.Column<int>(type: "integer", nullable: false),
                    CoachId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sportsmen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sportsmen_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sportsmen_Coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SportsmanId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Sportsmen_SportsmanId",
                        column: x => x.SportsmanId,
                        principalTable: "Sportsmen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    TournamentId = table.Column<int>(type: "integer", nullable: false),
                    SportsmanId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    SportCategoryId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => new { x.SportsmanId, x.TournamentId, x.SportCategoryId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Registrations_SportCategories_SportCategoryId",
                        column: x => x.SportCategoryId,
                        principalTable: "SportCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registrations_Sportsmen_SportsmanId",
                        column: x => x.SportsmanId,
                        principalTable: "Sportsmen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registrations_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registrations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weighings",
                columns: table => new
                {
                    TournamentId = table.Column<int>(type: "integer", nullable: false),
                    SportsmanId = table.Column<int>(type: "integer", nullable: false),
                    SportCategoryId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<string>(type: "text", nullable: false),
                    WeightValue = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weighings", x => new { x.SportsmanId, x.TournamentId, x.SportCategoryId });
                    table.ForeignKey(
                        name: "FK_Weighings_SportCategories_SportCategoryId",
                        column: x => x.SportCategoryId,
                        principalTable: "SportCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Weighings_Sportsmen_SportsmanId",
                        column: x => x.SportsmanId,
                        principalTable: "Sportsmen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Weighings_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Draws",
                columns: table => new
                {
                    TournamentId = table.Column<int>(type: "integer", nullable: false),
                    SportsmanId = table.Column<int>(type: "integer", nullable: false),
                    MatchId = table.Column<int>(type: "integer", nullable: false),
                    DrawType = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Draws", x => new { x.SportsmanId, x.TournamentId, x.MatchId });
                    table.ForeignKey(
                        name: "FK_Draws_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Draws_Sportsmen_SportsmanId",
                        column: x => x.SportsmanId,
                        principalTable: "Sportsmen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Draws_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<string>(type: "text", nullable: false),
                    Round = table.Column<string>(type: "text", nullable: false),
                    TournamentResultId = table.Column<int>(type: "integer", nullable: false),
                    MatchId = table.Column<int>(type: "integer", nullable: false),
                    WinnerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchResults_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchResults_Sportsmen_WinnerId",
                        column: x => x.WinnerId,
                        principalTable: "Sportsmen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchResults_TournamentResults_TournamentResultId",
                        column: x => x.TournamentResultId,
                        principalTable: "TournamentResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_CityId",
                table: "Clubs",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_ClubId",
                table: "Coaches",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Draws_MatchId",
                table: "Draws",
                column: "MatchId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Draws_SportsmanId",
                table: "Draws",
                column: "SportsmanId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Draws_TournamentId",
                table: "Draws",
                column: "TournamentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_SportsmanId",
                table: "Matches",
                column: "SportsmanId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchResults_MatchId",
                table: "MatchResults",
                column: "MatchId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MatchResults_TournamentResultId",
                table: "MatchResults",
                column: "TournamentResultId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchResults_WinnerId",
                table: "MatchResults",
                column: "WinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_SportCategoryId",
                table: "Registrations",
                column: "SportCategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_SportsmanId",
                table: "Registrations",
                column: "SportsmanId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_TournamentId",
                table: "Registrations",
                column: "TournamentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_UserId",
                table: "Registrations",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SportCategories_TournamentId",
                table: "SportCategories",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_SportCategories_WeightId",
                table: "SportCategories",
                column: "WeightId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sportsmen_ClubId",
                table: "Sportsmen",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Sportsmen_CoachId",
                table: "Sportsmen",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentResults_TournamentId",
                table: "TournamentResults",
                column: "TournamentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weighings_SportCategoryId",
                table: "Weighings",
                column: "SportCategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weighings_SportsmanId",
                table: "Weighings",
                column: "SportsmanId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weighings_TournamentId",
                table: "Weighings",
                column: "TournamentId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Draws");

            migrationBuilder.DropTable(
                name: "MatchResults");

            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "Weighings");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "TournamentResults");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SportCategories");

            migrationBuilder.DropTable(
                name: "Sportsmen");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "Weights");

            migrationBuilder.DropTable(
                name: "Coaches");

            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
