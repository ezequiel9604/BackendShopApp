using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backendShopApp.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appearances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appearances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currancies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currancies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Quality = table.Column<double>(type: "float", nullable: false),
                    State = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Item_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    AppearanceId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    CurrancyId = table.Column<int>(type: "int", nullable: false),
                    ClientTypeId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Appearances_AppearanceId",
                        column: x => x.AppearanceId,
                        principalTable: "Appearances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_Currancies_CurrancyId",
                        column: x => x.CurrancyId,
                        principalTable: "Currancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_Types_ClientTypeId",
                        column: x => x.ClientTypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ItemId = table.Column<string>(type: "nvarchar(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Descount = table.Column<double>(type: "float", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Size = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Capacity = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ItemId = table.Column<string>(type: "nvarchar(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubItem_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    State = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Department = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chat",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sender = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    AdministratorId = table.Column<string>(type: "nvarchar(8)", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chat_Administrator_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Administrator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chat_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    ItemId1 = table.Column<string>(type: "nvarchar(8)", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ClientId1 = table.Column<string>(type: "nvarchar(8)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Clients_ClientId1",
                        column: x => x.ClientId1,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comment_Item_ItemId1",
                        column: x => x.ItemId1,
                        principalTable: "Item",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    SubTotal = table.Column<double>(type: "float", nullable: false),
                    Descount = table.Column<double>(type: "float", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShipmentMethod = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(8)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phones_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditCardNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    CreditCardOwner = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ExpirationDate = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    SecurityCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallets_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    SubItemId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_SubItem_SubItemId",
                        column: x => x.SubItemId,
                        principalTable: "SubItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubItemId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WishLists_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishLists_SubItem_SubItemId",
                        column: x => x.SubItemId,
                        principalTable: "SubItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    OrderId = table.Column<string>(type: "nvarchar(8)", nullable: false),
                    SubItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchase_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchase_SubItem_SubItemId",
                        column: x => x.SubItemId,
                        principalTable: "SubItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ClientId",
                table: "Addresses",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_AdministratorId",
                table: "Chat",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_ClientId",
                table: "Chat",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AppearanceId",
                table: "Clients",
                column: "AppearanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientTypeId",
                table: "Clients",
                column: "ClientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CurrancyId",
                table: "Clients",
                column: "CurrancyId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Email",
                table: "Clients",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_LanguageId",
                table: "Clients",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_StateId",
                table: "Clients",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ClientId1",
                table: "Comment",
                column: "ClientId1");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ItemId1",
                table: "Comment",
                column: "ItemId1");

            migrationBuilder.CreateIndex(
                name: "IX_Image_ItemId",
                table: "Image",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_BrandId",
                table: "Item",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_CategoryId",
                table: "Item",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ClientId",
                table: "Order",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_StatusId",
                table: "Order",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_ClientId",
                table: "Phones",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_OrderId",
                table: "Purchase",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_SubItemId",
                table: "Purchase",
                column: "SubItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_ClientId",
                table: "ShoppingCarts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_SubItemId",
                table: "ShoppingCarts",
                column: "SubItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryId",
                table: "SubCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubItem_ItemId",
                table: "SubItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_ClientId",
                table: "Wallets",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_ClientId",
                table: "WishLists",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_SubItemId",
                table: "WishLists",
                column: "SubItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Chat");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "WishLists");

            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "SubItem");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Appearances");

            migrationBuilder.DropTable(
                name: "Currancies");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
