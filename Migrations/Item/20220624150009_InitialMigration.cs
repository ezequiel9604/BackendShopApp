using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backendShopApp.Migrations.Item
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
                name: "Appearance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appearance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currancy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currancy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
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
                name: "Items",
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
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Client",
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
                    table.PrimaryKey("PK_Client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Client_Appearance_AppearanceId",
                        column: x => x.AppearanceId,
                        principalTable: "Appearance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Client_ClientType_ClientTypeId",
                        column: x => x.ClientTypeId,
                        principalTable: "ClientType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Client_Currancy_CurrancyId",
                        column: x => x.CurrancyId,
                        principalTable: "Currancy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Client_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Client_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ItemId = table.Column<string>(type: "nvarchar(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubItems",
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
                    table.PrimaryKey("PK_SubItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
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
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
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
                        name: "FK_Chat_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
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
                        name: "FK_Comment_Client_ClientId1",
                        column: x => x.ClientId1,
                        principalTable: "Client",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comment_Items_ItemId1",
                        column: x => x.ItemId1,
                        principalTable: "Items",
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
                        name: "FK_Order_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
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
                name: "Phone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phone_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wallet",
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
                    table.PrimaryKey("PK_Wallet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallet_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
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
                    table.PrimaryKey("PK_ShoppingCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCart_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCart_SubItems_SubItemId",
                        column: x => x.SubItemId,
                        principalTable: "SubItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishList",
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
                    table.PrimaryKey("PK_WishList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WishList_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishList_SubItems_SubItemId",
                        column: x => x.SubItemId,
                        principalTable: "SubItems",
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
                        name: "FK_Purchase_SubItems_SubItemId",
                        column: x => x.SubItemId,
                        principalTable: "SubItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_ClientId",
                table: "Address",
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
                name: "IX_Client_AppearanceId",
                table: "Client",
                column: "AppearanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_ClientTypeId",
                table: "Client",
                column: "ClientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_CurrancyId",
                table: "Client",
                column: "CurrancyId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_LanguageId",
                table: "Client",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_StateId",
                table: "Client",
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
                name: "IX_Images_ItemId",
                table: "Images",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_BrandId",
                table: "Items",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
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
                name: "IX_Phone_ClientId",
                table: "Phone",
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
                name: "IX_ShoppingCart_ClientId",
                table: "ShoppingCart",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_SubItemId",
                table: "ShoppingCart",
                column: "SubItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubItems_ItemId",
                table: "SubItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_ClientId",
                table: "Wallet",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_WishList_ClientId",
                table: "WishList",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_WishList_SubItemId",
                table: "WishList",
                column: "SubItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Chat");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Phone");

            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Wallet");

            migrationBuilder.DropTable(
                name: "WishList");

            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "SubItems");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Appearance");

            migrationBuilder.DropTable(
                name: "ClientType");

            migrationBuilder.DropTable(
                name: "Currancy");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
