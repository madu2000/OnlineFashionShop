﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OS.Infastructures.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address1 = table.Column<string>(maxLength: 200, nullable: false),
                    Address2 = table.Column<string>(maxLength: 200, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    ModifiedOnUTC = table.Column<DateTime>(nullable: false),
                    ZipPostalCode = table.Column<int>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOnUTC = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 300, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    UpdatedOnUTC = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttribute",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttribute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    PerentProductTypeId = table.Column<int>(nullable: false),
                    UpdatedOnUTC = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<int>(nullable: false),
                    FreeShipping = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    SystemName = table.Column<string>(maxLength: 100, nullable: true),
                    TaxEnabled = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    ContactNumber = table.Column<int>(maxLength: 10, nullable: false),
                    CreatedByUTC = table.Column<DateTime>(nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 150, nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    HashedPassword = table.Column<string>(maxLength: 100, nullable: false),
                    LastLoginUTC = table.Column<DateTime>(nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    PasswordSalt = table.Column<string>(maxLength: 15, nullable: false),
                    Username = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountUser_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressId = table.Column<int>(nullable: false),
                    CreatedOnUTC = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    StoreContactNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Store_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AllowCustomerReview = table.Column<int>(nullable: false),
                    ApprovedRatingSum = table.Column<decimal>(nullable: false),
                    ApprovedTotalReview = table.Column<int>(nullable: false),
                    CreatedOnUTC = table.Column<DateTime>(nullable: false),
                    ManufacturerId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    ProductTypeId = table.Column<int>(nullable: false),
                    ShortDescription = table.Column<string>(maxLength: 150, nullable: true),
                    ShowOnCategoryPage = table.Column<int>(nullable: false),
                    TaxIncluded = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountUserRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountUserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountUserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountUserRole_AccountUser_AccountUserId",
                        column: x => x.AccountUserId,
                        principalTable: "AccountUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountUserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountUserCurrencyCode = table.Column<string>(nullable: true),
                    AccountUserId = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    AllowStoringCreditCardNumber = table.Column<int>(nullable: false),
                    AuthenticationTransactionCode = table.Column<string>(nullable: true),
                    AuthenticationTransactionId = table.Column<string>(nullable: true),
                    AuthenticationTransactionResult = table.Column<string>(nullable: true),
                    CaptureTransactionId = table.Column<string>(nullable: true),
                    CaptureTransactionResult = table.Column<string>(nullable: true),
                    CardCvv2 = table.Column<int>(nullable: false),
                    CardExpirationMonth = table.Column<string>(nullable: true),
                    CardExpirationYear = table.Column<string>(nullable: true),
                    CardName = table.Column<string>(nullable: true),
                    CardNumber = table.Column<int>(nullable: false),
                    CardType = table.Column<string>(nullable: true),
                    CreatedOnUTC = table.Column<DateTime>(nullable: false),
                    CurrencyRate = table.Column<decimal>(nullable: false),
                    MaskedCreditCardNumber = table.Column<int>(nullable: false),
                    OrderDiscount = table.Column<decimal>(nullable: false),
                    OrderStatus = table.Column<string>(nullable: true),
                    OrderSubTotal = table.Column<decimal>(nullable: false),
                    OrderSubTotalDiscount = table.Column<decimal>(nullable: false),
                    OrderTotal = table.Column<decimal>(nullable: false),
                    PaidDateUTC = table.Column<DateTime>(nullable: false),
                    PaymentMethodAdditionalFee = table.Column<decimal>(nullable: false),
                    PaymentMethodSystemName = table.Column<string>(nullable: true),
                    PaymentStatus = table.Column<string>(nullable: true),
                    PickupInStore = table.Column<int>(nullable: false),
                    RefundableAmmount = table.Column<decimal>(nullable: false),
                    StoreId = table.Column<int>(nullable: false),
                    SubscriptionTransactionId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_AccountUser_AccountUserId",
                        column: x => x.AccountUserId,
                        principalTable: "AccountUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOnUTC = table.Column<DateTime>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    ProductTypeId = table.Column<int>(nullable: false),
                    UpdatedOnUTC = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Picture_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Picture_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product_ProductAttributeMapping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsRequired = table.Column<int>(nullable: false),
                    ProductAttributeId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_ProductAttributeMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ProductAttributeMapping_ProductAttribute_ProductAttributeId",
                        column: x => x.ProductAttributeId,
                        principalTable: "ProductAttribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_ProductAttributeMapping_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttributeCombination",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttributeXml = table.Column<string>(maxLength: 2147483647, nullable: true),
                    AvailableQuentity = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributeCombination", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAttributeCombination_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductReview",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountUserId = table.Column<int>(nullable: false),
                    CreatedOnUTC = table.Column<DateTime>(nullable: false),
                    IsApproved = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    ReviewText = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductReview_AccountUser_AccountUserId",
                        column: x => x.AccountUserId,
                        principalTable: "AccountUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductReview_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountUserId = table.Column<int>(nullable: false),
                    AttributeXml = table.Column<string>(maxLength: 2147483647, nullable: true),
                    CreatedOnUTC = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ProductPrice = table.Column<decimal>(nullable: false),
                    Quentity = table.Column<int>(nullable: false),
                    ShoppingCartTypeId = table.Column<int>(nullable: false),
                    StoreId = table.Column<int>(nullable: false),
                    UpdatedOnUTC = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_AccountUser_AccountUserId",
                        column: x => x.AccountUserId,
                        principalTable: "AccountUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiscountAmount = table.Column<decimal>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quentity = table.Column<int>(nullable: false),
                    SubTotalPrice = table.Column<decimal>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderNote",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOnUTC = table.Column<DateTime>(nullable: false),
                    DisplayToCustomer = table.Column<int>(nullable: false),
                    Note = table.Column<string>(maxLength: 50, nullable: true),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderNote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderNote_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockItemMapping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttributeCombinationId = table.Column<int>(nullable: false),
                    StoreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockItemMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockItemMapping_ProductAttributeCombination_AttributeCombinationId",
                        column: x => x.AttributeCombinationId,
                        principalTable: "ProductAttributeCombination",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockItemMapping_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountUser_AddressId",
                table: "AccountUser",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountUserRole_AccountUserId",
                table: "AccountUserRole",
                column: "AccountUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountUserRole_RoleId",
                table: "AccountUserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_AccountUserId",
                table: "Order",
                column: "AccountUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_AddressId",
                table: "Order",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_StoreId",
                table: "Order",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                table: "OrderItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderNote_OrderId",
                table: "OrderNote",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Picture_ProductId",
                table: "Picture",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Picture_ProductTypeId",
                table: "Picture",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ManufacturerId",
                table: "Product",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductTypeId",
                table: "Product",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductAttributeMapping_ProductAttributeId",
                table: "Product_ProductAttributeMapping",
                column: "ProductAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductAttributeMapping_ProductId",
                table: "Product_ProductAttributeMapping",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeCombination_ProductId",
                table: "ProductAttributeCombination",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReview_AccountUserId",
                table: "ProductReview",
                column: "AccountUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReview_ProductId",
                table: "ProductReview",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_AccountUserId",
                table: "ShoppingCartItem",
                column: "AccountUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_ProductId",
                table: "ShoppingCartItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_StoreId",
                table: "ShoppingCartItem",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StockItemMapping_AttributeCombinationId",
                table: "StockItemMapping",
                column: "AttributeCombinationId");

            migrationBuilder.CreateIndex(
                name: "IX_StockItemMapping_StoreId",
                table: "StockItemMapping",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Store_AddressId",
                table: "Store",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountUserRole");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "OrderNote");

            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.DropTable(
                name: "Product_ProductAttributeMapping");

            migrationBuilder.DropTable(
                name: "ProductReview");

            migrationBuilder.DropTable(
                name: "ShoppingCartItem");

            migrationBuilder.DropTable(
                name: "StockItemMapping");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "ProductAttribute");

            migrationBuilder.DropTable(
                name: "ProductAttributeCombination");

            migrationBuilder.DropTable(
                name: "AccountUser");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Manufacturer");

            migrationBuilder.DropTable(
                name: "ProductType");
        }
    }
}
