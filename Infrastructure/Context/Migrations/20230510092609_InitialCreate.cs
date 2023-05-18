using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Context.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categeories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categeories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    DirectorId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieCategories",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCategories", x => new { x.MovieId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_MovieCategories_Categeories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categeories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCategories_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categeories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "Status", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 10, 12, 26, 8, 962, DateTimeKind.Local).AddTicks(1940), null, "Action", 1, null },
                    { 2, new DateTime(2023, 5, 10, 12, 26, 8, 962, DateTimeKind.Local).AddTicks(1943), null, "Adventure", 1, null },
                    { 3, new DateTime(2023, 5, 10, 12, 26, 8, 962, DateTimeKind.Local).AddTicks(1945), null, "Comedy", 1, null },
                    { 4, new DateTime(2023, 5, 10, 12, 26, 8, 962, DateTimeKind.Local).AddTicks(1946), null, "Fantasy", 1, null },
                    { 5, new DateTime(2023, 5, 10, 12, 26, 8, 962, DateTimeKind.Local).AddTicks(1948), null, "Horror", 1, null },
                    { 6, new DateTime(2023, 5, 10, 12, 26, 8, 962, DateTimeKind.Local).AddTicks(1950), null, "Mystery", 1, null },
                    { 7, new DateTime(2023, 5, 10, 12, 26, 8, 962, DateTimeKind.Local).AddTicks(1951), null, "Romance", 1, null }
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "DeletedDate", "FirstName", "LastName", "Status", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1928, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 10, 12, 26, 8, 962, DateTimeKind.Local).AddTicks(1053), null, "Stanley", "Kubrick", 1, null },
                    { 2, new DateTime(1933, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 10, 12, 26, 8, 962, DateTimeKind.Local).AddTicks(1073), null, "Roman", "Polanski", 1, null },
                    { 3, new DateTime(1963, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 10, 12, 26, 8, 962, DateTimeKind.Local).AddTicks(1076), null, "Quentin Jerome", "Tarantino", 1, null },
                    { 4, new DateTime(1897, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 10, 12, 26, 8, 962, DateTimeKind.Local).AddTicks(1078), null, "Frank", "Cupra", 1, null },
                    { 5, new DateTime(1962, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 10, 12, 26, 8, 962, DateTimeKind.Local).AddTicks(1080), null, "David Leo", "Fincher", 1, null }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "DirectorId", "Image", "Name", "Status", "UpdatedDate", "Year" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 10, 12, 26, 8, 962, DateTimeKind.Local).AddTicks(1578), null, "A pragmatic U.S. Marine observes the dehumanizing effects the Vietnam War has on his fellow recruits from their brutal boot camp training to the bloody street fighting in Hue.", 1, "noimage.png", "Full Metal Jacket", 1, null, 1987 },
                    { 2, new DateTime(2023, 5, 10, 12, 26, 8, 962, DateTimeKind.Local).AddTicks(1584), null, "A family heads to an isolated hotel for the winter where a sinister presence influences the father into violence, while his psychic son sees horrific forebodings from both past and future.", 1, "noimage.png", "The Shining", 1, null, 1980 },
                    { 3, new DateTime(2023, 5, 10, 12, 26, 8, 962, DateTimeKind.Local).AddTicks(1586), null, "A Polish Jewish musician struggles to survive the destruction of the Warsaw ghetto of World War II.", 2, "noimage.png", "The Pianist", 1, null, 2002 },
                    { 4, new DateTime(2023, 5, 10, 12, 26, 8, 962, DateTimeKind.Local).AddTicks(1588), null, "In 1894, French Captain Alfred Dreyfus is wrongfully convicted of treason and sentenced to life imprisonment at Devil's island.", 2, "noimage.png", "An Officer and A Spy", 1, null, 2019 },
                    { 5, new DateTime(2023, 5, 10, 12, 26, 8, 962, DateTimeKind.Local).AddTicks(1591), null, "A faded television actor and his stunt double strive to achieve fame and success in the final years of Hollywood's Golden Age in 1969 Los Angeles.", 3, "noimage.png", "Once Upon A Time In Hollywood", 1, null, 2019 },
                    { 6, new DateTime(2023, 5, 10, 12, 26, 8, 962, DateTimeKind.Local).AddTicks(1593), null, "After awakening from a four-year coma, a former assassin wreaks vengeance on the team of assassins who betrayed her.", 3, "noimage.png", "Kill Bill Volume 1", 1, null, 2003 },
                    { 7, new DateTime(2023, 5, 10, 12, 26, 8, 962, DateTimeKind.Local).AddTicks(1595), null, "A Broadway matinee idol famous for his black-face portrayals anonymously joins an amateur acting troupe and falls in love with the leading lady.", 4, "noimage.png", "The Matinee Idol", 1, null, 1928 },
                    { 8, new DateTime(2023, 5, 10, 12, 26, 8, 962, DateTimeKind.Local).AddTicks(1597), null, "Naive newspaper cub Clem lands a scoop when he's sent out to cover a murder. In his enthusiasm he writes that the main suspect is Jane. When she confronts Clem she convinces him to help her prove her innocence", 4, "noimage.png", "The Power of The Press", 1, null, 1928 },
                    { 9, new DateTime(2023, 5, 10, 12, 26, 8, 962, DateTimeKind.Local).AddTicks(1599), null, "Tells the story of Benjamin Button, a man who starts aging backwards with consequences", 5, "noimage.png", "The Curios Case of Benjamin Button", 1, null, 2008 },
                    { 10, new DateTime(2023, 5, 10, 12, 26, 8, 962, DateTimeKind.Local).AddTicks(1601), null, "As Harvard student Mark Zuckerberg creates the social networking site that would become known as Facebook, he is sued by the twins who claimed he stole their idea and by the co-founder who was later squeezed out of the business.", 5, "noimage.png", "The Social Network", 1, null, 2010 }
                });

            migrationBuilder.InsertData(
                table: "MovieCategories",
                columns: new[] { "CategoryId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 2 },
                    { 5, 2 },
                    { 6, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 6, 4 },
                    { 7, 4 },
                    { 1, 5 },
                    { 5, 5 },
                    { 2, 6 },
                    { 3, 6 },
                    { 6, 6 },
                    { 2, 7 },
                    { 6, 7 },
                    { 1, 8 },
                    { 5, 8 },
                    { 4, 9 },
                    { 5, 9 },
                    { 6, 9 },
                    { 1, 10 },
                    { 3, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieCategories_CategoryId",
                table: "MovieCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DirectorId",
                table: "Movies",
                column: "DirectorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieCategories");

            migrationBuilder.DropTable(
                name: "Categeories");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Directors");
        }
    }
}
