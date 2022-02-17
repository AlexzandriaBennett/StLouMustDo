using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace stloumustdo.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BucketList",
                columns: table => new
                {
                    BucketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BucketList", x => x.BucketId);
                });

            migrationBuilder.CreateTable(
                name: "Cafes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CafeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Neighborhood = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cafes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocalAttractions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttractionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Neighborhood = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttractionUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalAttractions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestaurantType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceRange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Neighborhood = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResturauntAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatewideOutdoors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OutdoorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistanceFromSTL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutdoorUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatewideOutdoors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfileViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BucketId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfileViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfileViewModel_BucketList_BucketId",
                        column: x => x.BucketId,
                        principalTable: "BucketList",
                        principalColumn: "BucketId");
                });

            migrationBuilder.CreateTable(
                name: "BucketListCafe",
                columns: table => new
                {
                    BucketListBucketId = table.Column<int>(type: "int", nullable: false),
                    CafesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BucketListCafe", x => new { x.BucketListBucketId, x.CafesId });
                    table.ForeignKey(
                        name: "FK_BucketListCafe_BucketList_BucketListBucketId",
                        column: x => x.BucketListBucketId,
                        principalTable: "BucketList",
                        principalColumn: "BucketId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BucketListCafe_Cafes_CafesId",
                        column: x => x.CafesId,
                        principalTable: "Cafes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BucketListLocalAttraction",
                columns: table => new
                {
                    AttractionsId = table.Column<int>(type: "int", nullable: false),
                    BucketListBucketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BucketListLocalAttraction", x => new { x.AttractionsId, x.BucketListBucketId });
                    table.ForeignKey(
                        name: "FK_BucketListLocalAttraction_BucketList_BucketListBucketId",
                        column: x => x.BucketListBucketId,
                        principalTable: "BucketList",
                        principalColumn: "BucketId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BucketListLocalAttraction_LocalAttractions_AttractionsId",
                        column: x => x.AttractionsId,
                        principalTable: "LocalAttractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BucketListRestaurants",
                columns: table => new
                {
                    BucketListBucketId = table.Column<int>(type: "int", nullable: false),
                    RestaurantsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BucketListRestaurants", x => new { x.BucketListBucketId, x.RestaurantsId });
                    table.ForeignKey(
                        name: "FK_BucketListRestaurants_BucketList_BucketListBucketId",
                        column: x => x.BucketListBucketId,
                        principalTable: "BucketList",
                        principalColumn: "BucketId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BucketListRestaurants_Restaurants_RestaurantsId",
                        column: x => x.RestaurantsId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BucketListStatewideOutdoors",
                columns: table => new
                {
                    BucketListBucketId = table.Column<int>(type: "int", nullable: false),
                    OutdoorsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BucketListStatewideOutdoors", x => new { x.BucketListBucketId, x.OutdoorsId });
                    table.ForeignKey(
                        name: "FK_BucketListStatewideOutdoors_BucketList_BucketListBucketId",
                        column: x => x.BucketListBucketId,
                        principalTable: "BucketList",
                        principalColumn: "BucketId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BucketListStatewideOutdoors_StatewideOutdoors_OutdoorsId",
                        column: x => x.OutdoorsId,
                        principalTable: "StatewideOutdoors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BucketListCafe_CafesId",
                table: "BucketListCafe",
                column: "CafesId");

            migrationBuilder.CreateIndex(
                name: "IX_BucketListLocalAttraction_BucketListBucketId",
                table: "BucketListLocalAttraction",
                column: "BucketListBucketId");

            migrationBuilder.CreateIndex(
                name: "IX_BucketListRestaurants_RestaurantsId",
                table: "BucketListRestaurants",
                column: "RestaurantsId");

            migrationBuilder.CreateIndex(
                name: "IX_BucketListStatewideOutdoors_OutdoorsId",
                table: "BucketListStatewideOutdoors",
                column: "OutdoorsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileViewModel_BucketId",
                table: "UserProfileViewModel",
                column: "BucketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BucketListCafe");

            migrationBuilder.DropTable(
                name: "BucketListLocalAttraction");

            migrationBuilder.DropTable(
                name: "BucketListRestaurants");

            migrationBuilder.DropTable(
                name: "BucketListStatewideOutdoors");

            migrationBuilder.DropTable(
                name: "UserProfileViewModel");

            migrationBuilder.DropTable(
                name: "Cafes");

            migrationBuilder.DropTable(
                name: "LocalAttractions");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "StatewideOutdoors");

            migrationBuilder.DropTable(
                name: "BucketList");
        }
    }
}
