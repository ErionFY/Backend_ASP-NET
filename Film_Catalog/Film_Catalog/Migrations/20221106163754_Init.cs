using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Film_Catalog.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Genre_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Genre_Id);
                });

            migrationBuilder.CreateTable(
                name: "JwtLoggedOutTokens",
                columns: table => new
                {
                    Token = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JwtLoggedOutTokens", x => x.Token);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Movie_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Poster = table.Column<string>(type: "text", nullable: true),
                    Year = table.Column<int>(type: "integer", nullable: true),
                    country = table.Column<string>(type: "text", nullable: true),
                    Time = table.Column<int>(type: "integer", nullable: false),
                    Tagline = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Director = table.Column<string>(type: "text", nullable: true),
                    Budget = table.Column<int>(type: "integer", nullable: true),
                    Fees = table.Column<int>(type: "integer", nullable: true),
                    AgeLimit = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Movie_Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    AvatarLink = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: true),
                    IsAdmin = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_Id);
                });

            migrationBuilder.CreateTable(
                name: "GenreMovie",
                columns: table => new
                {
                    GenresGenre_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MoviesMovie_Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMovie", x => new { x.GenresGenre_Id, x.MoviesMovie_Id });
                    table.ForeignKey(
                        name: "FK_GenreMovie_Genres_GenresGenre_Id",
                        column: x => x.GenresGenre_Id,
                        principalTable: "Genres",
                        principalColumn: "Genre_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMovie_Movies_MoviesMovie_Id",
                        column: x => x.MoviesMovie_Id,
                        principalTable: "Movies",
                        principalColumn: "Movie_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieUser",
                columns: table => new
                {
                    MoviesMovie_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersUser_Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieUser", x => new { x.MoviesMovie_Id, x.UsersUser_Id });
                    table.ForeignKey(
                        name: "FK_MovieUser_Movies_MoviesMovie_Id",
                        column: x => x.MoviesMovie_Id,
                        principalTable: "Movies",
                        principalColumn: "Movie_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieUser_Users_UsersUser_Id",
                        column: x => x.UsersUser_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Review_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    ReviewText = table.Column<string>(type: "text", nullable: true),
                    IsAnonymous = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Movie_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorUser_Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Review_Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Movies_Movie_Id",
                        column: x => x.Movie_Id,
                        principalTable: "Movies",
                        principalColumn: "Movie_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_AuthorUser_Id",
                        column: x => x.AuthorUser_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreMovie_MoviesMovie_Id",
                table: "GenreMovie",
                column: "MoviesMovie_Id");

            migrationBuilder.CreateIndex(
                name: "IX_MovieUser_UsersUser_Id",
                table: "MovieUser",
                column: "UsersUser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AuthorUser_Id",
                table: "Reviews",
                column: "AuthorUser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_Movie_Id",
                table: "Reviews",
                column: "Movie_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreMovie");

            migrationBuilder.DropTable(
                name: "JwtLoggedOutTokens");

            migrationBuilder.DropTable(
                name: "MovieUser");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
