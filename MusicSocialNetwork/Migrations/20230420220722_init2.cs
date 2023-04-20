using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicSocialNetwork.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "playlist_image",
                table: "Playlists",
                type: "bytea",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "playlist_image",
                table: "Playlists");
        }
    }
}
