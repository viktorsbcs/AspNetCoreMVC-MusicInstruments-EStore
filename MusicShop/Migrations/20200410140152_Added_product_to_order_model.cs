﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicShop.Migrations
{
    public partial class Added_product_to_order_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        //    migrationBuilder.AddColumn<int>(
        //        name: "ProductId",
        //        table: "Orders",
        //        nullable: true);

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Orders_ProductId",
        //        table: "Orders",
        //        column: "ProductId");

        //    migrationBuilder.AddForeignKey(
        //        name: "FK_Orders_Products_ProductId",
        //        table: "Orders",
        //        column: "ProductId",
        //        principalTable: "Products",
        //        principalColumn: "ProductId",
        //        onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Orders_Products_ProductId",
            //    table: "Orders");

            //migrationBuilder.DropIndex(
            //    name: "IX_Orders_ProductId",
            //    table: "Orders");

            //migrationBuilder.DropColumn(
            //    name: "ProductId",
            //    table: "Orders");
        }
    }
}
