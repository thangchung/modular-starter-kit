using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MSK.Samples.BiMonetary.Migrator.Migrations.AppDb
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "msk_AuthorIds",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_msk_AuthorIds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "msk_Links",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Updated = table.Column<DateTime>(nullable: false),
                    Uri = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_msk_Links", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "msk_Relationships",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_msk_Relationships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "msk_TickerIds",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_msk_TickerIds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "msk_Tickers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AvailableSupply = table.Column<double>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    LastSyncWithService = table.Column<DateTime>(nullable: false),
                    MarketCapUsd = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PercentChange1h = table.Column<string>(nullable: true),
                    PercentChange24h = table.Column<string>(nullable: true),
                    PercentChange7d = table.Column<string>(nullable: true),
                    PriceBtc = table.Column<double>(nullable: false),
                    PriceUsd = table.Column<double>(nullable: false),
                    Rank = table.Column<int>(nullable: false),
                    Symbol = table.Column<string>(nullable: true),
                    TotalSupply = table.Column<double>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Volumn24hUsd = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_msk_Tickers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "msk_UserIds",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_msk_UserIds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "msk_Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AuthorId = table.Column<Guid>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_msk_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_msk_Posts_msk_AuthorIds_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "msk_AuthorIds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    RelationshipId = table.Column<Guid>(nullable: true),
                    RelationshipId1 = table.Column<Guid>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_msk_Relationships_RelationshipId",
                        column: x => x.RelationshipId,
                        principalTable: "msk_Relationships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_msk_Relationships_RelationshipId1",
                        column: x => x.RelationshipId1,
                        principalTable: "msk_Relationships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "msk_LinkIds",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TickerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_msk_LinkIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_msk_LinkIds_msk_Tickers_TickerId",
                        column: x => x.TickerId,
                        principalTable: "msk_Tickers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "msk_PostIds",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TickerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_msk_PostIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_msk_PostIds_msk_Tickers_TickerId",
                        column: x => x.TickerId,
                        principalTable: "msk_Tickers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "msk_LinkLikes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    LinkId = table.Column<Guid>(nullable: true),
                    Updated = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_msk_LinkLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_msk_LinkLikes_msk_Links_LinkId",
                        column: x => x.LinkId,
                        principalTable: "msk_Links",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_msk_LinkLikes_msk_UserIds_UserId",
                        column: x => x.UserId,
                        principalTable: "msk_UserIds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "msk_TickerLikes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    TickerId = table.Column<Guid>(nullable: true),
                    Updated = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_msk_TickerLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_msk_TickerLikes_msk_TickerIds_TickerId",
                        column: x => x.TickerId,
                        principalTable: "msk_TickerIds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_msk_TickerLikes_msk_UserIds_UserId",
                        column: x => x.UserId,
                        principalTable: "msk_UserIds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "msk_Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AuthorId = table.Column<Guid>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LinkId = table.Column<Guid>(nullable: true),
                    PostId = table.Column<Guid>(nullable: true),
                    Updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_msk_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_msk_Comments_msk_AuthorIds_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "msk_AuthorIds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_msk_Comments_msk_Links_LinkId",
                        column: x => x.LinkId,
                        principalTable: "msk_Links",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_msk_Comments_msk_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "msk_Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "msk_PostLikes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    PostId = table.Column<Guid>(nullable: true),
                    Updated = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_msk_PostLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_msk_PostLikes_msk_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "msk_Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_msk_PostLikes_msk_UserIds_UserId",
                        column: x => x.UserId,
                        principalTable: "msk_UserIds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RelationshipId",
                table: "AspNetUsers",
                column: "RelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RelationshipId1",
                table: "AspNetUsers",
                column: "RelationshipId1");

            migrationBuilder.CreateIndex(
                name: "IX_msk_Comments_AuthorId",
                table: "msk_Comments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_msk_Comments_LinkId",
                table: "msk_Comments",
                column: "LinkId");

            migrationBuilder.CreateIndex(
                name: "IX_msk_Comments_PostId",
                table: "msk_Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_msk_LinkIds_TickerId",
                table: "msk_LinkIds",
                column: "TickerId");

            migrationBuilder.CreateIndex(
                name: "IX_msk_LinkLikes_LinkId",
                table: "msk_LinkLikes",
                column: "LinkId");

            migrationBuilder.CreateIndex(
                name: "IX_msk_LinkLikes_UserId",
                table: "msk_LinkLikes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_msk_PostIds_TickerId",
                table: "msk_PostIds",
                column: "TickerId");

            migrationBuilder.CreateIndex(
                name: "IX_msk_PostLikes_PostId",
                table: "msk_PostLikes",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_msk_PostLikes_UserId",
                table: "msk_PostLikes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_msk_Posts_AuthorId",
                table: "msk_Posts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_msk_TickerLikes_TickerId",
                table: "msk_TickerLikes",
                column: "TickerId");

            migrationBuilder.CreateIndex(
                name: "IX_msk_TickerLikes_UserId",
                table: "msk_TickerLikes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "msk_Comments");

            migrationBuilder.DropTable(
                name: "msk_LinkIds");

            migrationBuilder.DropTable(
                name: "msk_LinkLikes");

            migrationBuilder.DropTable(
                name: "msk_PostIds");

            migrationBuilder.DropTable(
                name: "msk_PostLikes");

            migrationBuilder.DropTable(
                name: "msk_TickerLikes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "msk_Links");

            migrationBuilder.DropTable(
                name: "msk_Tickers");

            migrationBuilder.DropTable(
                name: "msk_Posts");

            migrationBuilder.DropTable(
                name: "msk_TickerIds");

            migrationBuilder.DropTable(
                name: "msk_UserIds");

            migrationBuilder.DropTable(
                name: "msk_Relationships");

            migrationBuilder.DropTable(
                name: "msk_AuthorIds");
        }
    }
}
