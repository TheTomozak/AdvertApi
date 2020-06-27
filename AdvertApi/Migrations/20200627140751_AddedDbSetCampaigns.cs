using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvertApi.Migrations
{
    public partial class AddedDbSetCampaigns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banners_Campaign_IdCampaing",
                table: "Banners");

            migrationBuilder.DropForeignKey(
                name: "FK_Campaign_Buildings_FromIdBuilding",
                table: "Campaign");

            migrationBuilder.DropForeignKey(
                name: "FK_Campaign_Clients_IdClient",
                table: "Campaign");

            migrationBuilder.DropForeignKey(
                name: "FK_Campaign_Buildings_ToIdBuilding",
                table: "Campaign");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Campaign",
                table: "Campaign");

            migrationBuilder.RenameTable(
                name: "Campaign",
                newName: "Campaigns");

            migrationBuilder.RenameIndex(
                name: "IX_Campaign_ToIdBuilding",
                table: "Campaigns",
                newName: "IX_Campaigns_ToIdBuilding");

            migrationBuilder.RenameIndex(
                name: "IX_Campaign_IdClient",
                table: "Campaigns",
                newName: "IX_Campaigns_IdClient");

            migrationBuilder.RenameIndex(
                name: "IX_Campaign_FromIdBuilding",
                table: "Campaigns",
                newName: "IX_Campaigns_FromIdBuilding");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Campaigns",
                table: "Campaigns",
                column: "IdCampaign");

            migrationBuilder.AddForeignKey(
                name: "FK_Banners_Campaigns_IdCampaing",
                table: "Banners",
                column: "IdCampaing",
                principalTable: "Campaigns",
                principalColumn: "IdCampaign",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_Buildings_FromIdBuilding",
                table: "Campaigns",
                column: "FromIdBuilding",
                principalTable: "Buildings",
                principalColumn: "IdBuilding",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_Clients_IdClient",
                table: "Campaigns",
                column: "IdClient",
                principalTable: "Clients",
                principalColumn: "IdClient",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_Buildings_ToIdBuilding",
                table: "Campaigns",
                column: "ToIdBuilding",
                principalTable: "Buildings",
                principalColumn: "IdBuilding",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banners_Campaigns_IdCampaing",
                table: "Banners");

            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_Buildings_FromIdBuilding",
                table: "Campaigns");

            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_Clients_IdClient",
                table: "Campaigns");

            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_Buildings_ToIdBuilding",
                table: "Campaigns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Campaigns",
                table: "Campaigns");

            migrationBuilder.RenameTable(
                name: "Campaigns",
                newName: "Campaign");

            migrationBuilder.RenameIndex(
                name: "IX_Campaigns_ToIdBuilding",
                table: "Campaign",
                newName: "IX_Campaign_ToIdBuilding");

            migrationBuilder.RenameIndex(
                name: "IX_Campaigns_IdClient",
                table: "Campaign",
                newName: "IX_Campaign_IdClient");

            migrationBuilder.RenameIndex(
                name: "IX_Campaigns_FromIdBuilding",
                table: "Campaign",
                newName: "IX_Campaign_FromIdBuilding");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Campaign",
                table: "Campaign",
                column: "IdCampaign");

            migrationBuilder.AddForeignKey(
                name: "FK_Banners_Campaign_IdCampaing",
                table: "Banners",
                column: "IdCampaing",
                principalTable: "Campaign",
                principalColumn: "IdCampaign",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Campaign_Buildings_FromIdBuilding",
                table: "Campaign",
                column: "FromIdBuilding",
                principalTable: "Buildings",
                principalColumn: "IdBuilding",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Campaign_Clients_IdClient",
                table: "Campaign",
                column: "IdClient",
                principalTable: "Clients",
                principalColumn: "IdClient",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Campaign_Buildings_ToIdBuilding",
                table: "Campaign",
                column: "ToIdBuilding",
                principalTable: "Buildings",
                principalColumn: "IdBuilding",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
