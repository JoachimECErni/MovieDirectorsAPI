using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDirectorsAPI.Migrations
{
    /// <inheritdoc />
    public partial class PostActorProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovies_Actors_ActorId",
                table: "ActorMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovies_Movies_MovieId",
                table: "ActorMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorProfile_Actors_ActorId",
                table: "ActorProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorProfile",
                table: "ActorProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorMovies",
                table: "ActorMovies");

            migrationBuilder.RenameTable(
                name: "ActorProfile",
                newName: "ActorProfiles");

            migrationBuilder.RenameTable(
                name: "ActorMovies",
                newName: "Cast");

            migrationBuilder.RenameIndex(
                name: "IX_ActorProfile_ActorId",
                table: "ActorProfiles",
                newName: "IX_ActorProfiles_ActorId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorMovies_MovieId",
                table: "Cast",
                newName: "IX_Cast_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorMovies_ActorId",
                table: "Cast",
                newName: "IX_Cast_ActorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorProfiles",
                table: "ActorProfiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cast",
                table: "Cast",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorProfiles_Actors_ActorId",
                table: "ActorProfiles",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cast_Actors_ActorId",
                table: "Cast",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cast_Movies_MovieId",
                table: "Cast",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorProfiles_Actors_ActorId",
                table: "ActorProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Cast_Actors_ActorId",
                table: "Cast");

            migrationBuilder.DropForeignKey(
                name: "FK_Cast_Movies_MovieId",
                table: "Cast");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cast",
                table: "Cast");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorProfiles",
                table: "ActorProfiles");

            migrationBuilder.RenameTable(
                name: "Cast",
                newName: "ActorMovies");

            migrationBuilder.RenameTable(
                name: "ActorProfiles",
                newName: "ActorProfile");

            migrationBuilder.RenameIndex(
                name: "IX_Cast_MovieId",
                table: "ActorMovies",
                newName: "IX_ActorMovies_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Cast_ActorId",
                table: "ActorMovies",
                newName: "IX_ActorMovies_ActorId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorProfiles_ActorId",
                table: "ActorProfile",
                newName: "IX_ActorProfile_ActorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorMovies",
                table: "ActorMovies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorProfile",
                table: "ActorProfile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovies_Actors_ActorId",
                table: "ActorMovies",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovies_Movies_MovieId",
                table: "ActorMovies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorProfile_Actors_ActorId",
                table: "ActorProfile",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
