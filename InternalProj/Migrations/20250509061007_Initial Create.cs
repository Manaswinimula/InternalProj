﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InternalProj.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    SizeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Size = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Active = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.SizeId);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BranchName = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryName = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryMasters",
                columns: table => new
                {
                    DeliveryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeliveryName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Active = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryMasters", x => x.DeliveryId);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryModes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Active = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryModes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeptMasters",
                columns: table => new
                {
                    DeptId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Active = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeptMasters", x => x.DeptId);
                });

            migrationBuilder.CreateTable(
                name: "DesignationMasters",
                columns: table => new
                {
                    DesignationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Active = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignationMasters", x => x.DesignationId);
                });

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    MachineId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MachineName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Active = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.MachineId);
                });

            migrationBuilder.CreateTable(
                name: "MainHeads",
                columns: table => new
                {
                    MainHeadId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MainHeadName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Active = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainHeads", x => x.MainHeadId);
                });

            migrationBuilder.CreateTable(
                name: "OrderVias",
                columns: table => new
                {
                    OrderViaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderViaCategory = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Active = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderVias", x => x.OrderViaId);
                });

            migrationBuilder.CreateTable(
                name: "PhoneTypes",
                columns: table => new
                {
                    PhoneTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PhoneTypeName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Active = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneTypes", x => x.PhoneTypeId);
                });

            migrationBuilder.CreateTable(
                name: "RateTypeMasters",
                columns: table => new
                {
                    RateTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RateTypeName = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateTypeMasters", x => x.RateTypeId);
                });

            migrationBuilder.CreateTable(
                name: "StateMasters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false, defaultValue: "Y")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxMasters",
                columns: table => new
                {
                    TaxId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TaxName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    TaxPer = table.Column<decimal>(type: "numeric", nullable: false),
                    WefDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Active = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxMasters", x => x.TaxId);
                });

            migrationBuilder.CreateTable(
                name: "WorkTypes",
                columns: table => new
                {
                    WorkTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Active = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTypes", x => x.WorkTypeId);
                });

            migrationBuilder.CreateTable(
                name: "StaffRegs",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DeptId = table.Column<int>(type: "integer", nullable: false),
                    DesignationId = table.Column<int>(type: "integer", nullable: false),
                    DOB = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DOJ = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    BranchId = table.Column<int>(type: "integer", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Active = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffRegs", x => x.StaffId);
                    table.ForeignKey(
                        name: "FK_StaffRegs_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffRegs_DeptMasters_DeptId",
                        column: x => x.DeptId,
                        principalTable: "DeptMasters",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffRegs_DesignationMasters_DesignationId",
                        column: x => x.DesignationId,
                        principalTable: "DesignationMasters",
                        principalColumn: "DesignationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RateMasters",
                columns: table => new
                {
                    RateId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Rate = table.Column<decimal>(type: "numeric", nullable: false),
                    SizeId = table.Column<int>(type: "integer", nullable: false),
                    SubHeadId = table.Column<int>(type: "integer", nullable: false),
                    MainHeadId = table.Column<int>(type: "integer", nullable: false),
                    Details = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateMasters", x => x.RateId);
                    table.ForeignKey(
                        name: "FK_RateMasters_Albums_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Albums",
                        principalColumn: "SizeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RateMasters_MainHeads_MainHeadId",
                        column: x => x.MainHeadId,
                        principalTable: "MainHeads",
                        principalColumn: "MainHeadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RateMasters_MainHeads_SubHeadId",
                        column: x => x.SubHeadId,
                        principalTable: "MainHeads",
                        principalColumn: "MainHeadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubHeads",
                columns: table => new
                {
                    SubHeadId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubHeadName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    MainHeadId = table.Column<int>(type: "integer", nullable: false),
                    MachineId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    Details = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    AlbumSizeDetailsSizeId = table.Column<int>(type: "integer", nullable: true),
                    MainHeadRegMainHeadId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubHeads", x => x.SubHeadId);
                    table.ForeignKey(
                        name: "FK_SubHeads_Albums_AlbumSizeDetailsSizeId",
                        column: x => x.AlbumSizeDetailsSizeId,
                        principalTable: "Albums",
                        principalColumn: "SizeId");
                    table.ForeignKey(
                        name: "FK_SubHeads_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubHeads_MainHeads_MainHeadId",
                        column: x => x.MainHeadId,
                        principalTable: "MainHeads",
                        principalColumn: "MainHeadId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubHeads_MainHeads_MainHeadRegMainHeadId",
                        column: x => x.MainHeadRegMainHeadId,
                        principalTable: "MainHeads",
                        principalColumn: "MainHeadId");
                });

            migrationBuilder.CreateTable(
                name: "RegionMasters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    StateId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegionMasters_StateMasters_StateId",
                        column: x => x.StateId,
                        principalTable: "StateMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerRegs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    StudioName = table.Column<string>(type: "text", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Active = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    BranchId = table.Column<int>(type: "integer", nullable: false),
                    RateTypeId = table.Column<int>(type: "integer", nullable: false),
                    StaffId = table.Column<int>(type: "integer", nullable: false),
                    CustomerCategoryCategoryId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerRegs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerRegs_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerRegs_CustomerCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CustomerCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerRegs_CustomerCategories_CustomerCategoryCategoryId",
                        column: x => x.CustomerCategoryCategoryId,
                        principalTable: "CustomerCategories",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: "FK_CustomerRegs_RateTypeMasters_RateTypeId",
                        column: x => x.RateTypeId,
                        principalTable: "RateTypeMasters",
                        principalColumn: "RateTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerRegs_StaffRegs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "StaffRegs",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChildSubHeads",
                columns: table => new
                {
                    ChildSubHeadId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChildSubHeadName = table.Column<string>(type: "text", nullable: false),
                    SubHeadId = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildSubHeads", x => x.ChildSubHeadId);
                    table.ForeignKey(
                        name: "FK_ChildSubHeads_SubHeads_SubHeadId",
                        column: x => x.SubHeadId,
                        principalTable: "SubHeads",
                        principalColumn: "SubHeadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAddresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Address1 = table.Column<string>(type: "text", nullable: false),
                    Address2 = table.Column<string>(type: "text", nullable: true),
                    StateId = table.Column<int>(type: "integer", nullable: false),
                    RegionId = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_CustomerRegs_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerRegs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_RegionMasters_RegionId",
                        column: x => x.RegionId,
                        principalTable: "RegionMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_StateMasters_StateId",
                        column: x => x.StateId,
                        principalTable: "StateMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerContacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    Phone1 = table.Column<string>(type: "text", nullable: false),
                    Phone2 = table.Column<string>(type: "text", nullable: false),
                    Whatsapp = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneTypeId = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerContacts", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_CustomerContacts_CustomerRegs_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerRegs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerContacts_PhoneTypes_PhoneTypeId",
                        column: x => x.PhoneTypeId,
                        principalTable: "PhoneTypes",
                        principalColumn: "PhoneTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrders",
                columns: table => new
                {
                    WorkOrderId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkOrderNo = table.Column<string>(type: "text", nullable: true),
                    Studio = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NoOfSheets = table.Column<int>(type: "integer", nullable: true),
                    NoOfCopies = table.Column<int>(type: "integer", nullable: true),
                    Wdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Ddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Mobile = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    MachineId = table.Column<int>(type: "integer", nullable: true),
                    DeliveryTypeId = table.Column<int>(type: "integer", nullable: true),
                    DeliveryModeId = table.Column<int>(type: "integer", nullable: true),
                    AlbumSizeId = table.Column<int>(type: "integer", nullable: true),
                    CustomerId = table.Column<int>(type: "integer", nullable: true),
                    WorkTypeId = table.Column<int>(type: "integer", nullable: true),
                    StaffId = table.Column<int>(type: "integer", nullable: true),
                    OrderViaId = table.Column<int>(type: "integer", nullable: true),
                    BranchId = table.Column<int>(type: "integer", nullable: true),
                    Active = table.Column<string>(type: "character(1)", fixedLength: true, maxLength: 1, nullable: false, defaultValue: "Y")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrders", x => x.WorkOrderId);
                    table.ForeignKey(
                        name: "FK_WorkOrders_Albums_AlbumSizeId",
                        column: x => x.AlbumSizeId,
                        principalTable: "Albums",
                        principalColumn: "SizeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkOrders_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId");
                    table.ForeignKey(
                        name: "FK_WorkOrders_CustomerRegs_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerRegs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkOrders_DeliveryMasters_DeliveryTypeId",
                        column: x => x.DeliveryTypeId,
                        principalTable: "DeliveryMasters",
                        principalColumn: "DeliveryId");
                    table.ForeignKey(
                        name: "FK_WorkOrders_DeliveryModes_DeliveryModeId",
                        column: x => x.DeliveryModeId,
                        principalTable: "DeliveryModes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkOrders_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_WorkOrders_OrderVias_OrderViaId",
                        column: x => x.OrderViaId,
                        principalTable: "OrderVias",
                        principalColumn: "OrderViaId");
                    table.ForeignKey(
                        name: "FK_WorkOrders_StaffRegs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "StaffRegs",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkOrders_WorkTypes_WorkTypeId",
                        column: x => x.WorkTypeId,
                        principalTable: "WorkTypes",
                        principalColumn: "WorkTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkDetails",
                columns: table => new
                {
                    WorkDetailsId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkOrderId = table.Column<int>(type: "integer", nullable: false),
                    MainHeadId = table.Column<int>(type: "integer", nullable: false),
                    SubheadId = table.Column<int>(type: "integer", nullable: false),
                    ChildSubheadId = table.Column<int>(type: "integer", nullable: false),
                    Qty = table.Column<int>(type: "integer", nullable: false),
                    Rate = table.Column<double>(type: "double precision", nullable: false),
                    Tax = table.Column<double>(type: "double precision", nullable: false),
                    GTotal = table.Column<double>(type: "double precision", nullable: false),
                    Cess = table.Column<double>(type: "double precision", nullable: false),
                    Details = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkDetails", x => x.WorkDetailsId);
                    table.ForeignKey(
                        name: "FK_WorkDetails_ChildSubHeads_ChildSubheadId",
                        column: x => x.ChildSubheadId,
                        principalTable: "ChildSubHeads",
                        principalColumn: "ChildSubHeadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkDetails_MainHeads_MainHeadId",
                        column: x => x.MainHeadId,
                        principalTable: "MainHeads",
                        principalColumn: "MainHeadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkDetails_SubHeads_SubheadId",
                        column: x => x.SubheadId,
                        principalTable: "SubHeads",
                        principalColumn: "SubHeadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkDetails_WorkOrders_WorkOrderId",
                        column: x => x.WorkOrderId,
                        principalTable: "WorkOrders",
                        principalColumn: "WorkOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildSubHeads_SubHeadId",
                table: "ChildSubHeads",
                column: "SubHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_CustomerId",
                table: "CustomerAddresses",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_RegionId",
                table: "CustomerAddresses",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_StateId",
                table: "CustomerAddresses",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerContacts_CustomerId",
                table: "CustomerContacts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerContacts_PhoneTypeId",
                table: "CustomerContacts",
                column: "PhoneTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerRegs_BranchId",
                table: "CustomerRegs",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerRegs_CategoryId",
                table: "CustomerRegs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerRegs_CustomerCategoryCategoryId",
                table: "CustomerRegs",
                column: "CustomerCategoryCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerRegs_RateTypeId",
                table: "CustomerRegs",
                column: "RateTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerRegs_StaffId",
                table: "CustomerRegs",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_RateMasters_MainHeadId",
                table: "RateMasters",
                column: "MainHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_RateMasters_SizeId",
                table: "RateMasters",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_RateMasters_SubHeadId",
                table: "RateMasters",
                column: "SubHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_RegionMasters_StateId",
                table: "RegionMasters",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffRegs_BranchId",
                table: "StaffRegs",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffRegs_DeptId",
                table: "StaffRegs",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffRegs_DesignationId",
                table: "StaffRegs",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_SubHeads_AlbumSizeDetailsSizeId",
                table: "SubHeads",
                column: "AlbumSizeDetailsSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubHeads_MachineId",
                table: "SubHeads",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_SubHeads_MainHeadId",
                table: "SubHeads",
                column: "MainHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_SubHeads_MainHeadRegMainHeadId",
                table: "SubHeads",
                column: "MainHeadRegMainHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkDetails_ChildSubheadId",
                table: "WorkDetails",
                column: "ChildSubheadId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkDetails_MainHeadId",
                table: "WorkDetails",
                column: "MainHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkDetails_SubheadId",
                table: "WorkDetails",
                column: "SubheadId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkDetails_WorkOrderId",
                table: "WorkDetails",
                column: "WorkOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_AlbumSizeId",
                table: "WorkOrders",
                column: "AlbumSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_BranchId",
                table: "WorkOrders",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_CustomerId",
                table: "WorkOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_DeliveryModeId",
                table: "WorkOrders",
                column: "DeliveryModeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_DeliveryTypeId",
                table: "WorkOrders",
                column: "DeliveryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_MachineId",
                table: "WorkOrders",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_OrderViaId",
                table: "WorkOrders",
                column: "OrderViaId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_StaffId",
                table: "WorkOrders",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_WorkTypeId",
                table: "WorkOrders",
                column: "WorkTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAddresses");

            migrationBuilder.DropTable(
                name: "CustomerContacts");

            migrationBuilder.DropTable(
                name: "RateMasters");

            migrationBuilder.DropTable(
                name: "TaxMasters");

            migrationBuilder.DropTable(
                name: "WorkDetails");

            migrationBuilder.DropTable(
                name: "RegionMasters");

            migrationBuilder.DropTable(
                name: "PhoneTypes");

            migrationBuilder.DropTable(
                name: "ChildSubHeads");

            migrationBuilder.DropTable(
                name: "WorkOrders");

            migrationBuilder.DropTable(
                name: "StateMasters");

            migrationBuilder.DropTable(
                name: "SubHeads");

            migrationBuilder.DropTable(
                name: "CustomerRegs");

            migrationBuilder.DropTable(
                name: "DeliveryMasters");

            migrationBuilder.DropTable(
                name: "DeliveryModes");

            migrationBuilder.DropTable(
                name: "OrderVias");

            migrationBuilder.DropTable(
                name: "WorkTypes");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "MainHeads");

            migrationBuilder.DropTable(
                name: "CustomerCategories");

            migrationBuilder.DropTable(
                name: "RateTypeMasters");

            migrationBuilder.DropTable(
                name: "StaffRegs");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "DeptMasters");

            migrationBuilder.DropTable(
                name: "DesignationMasters");
        }
    }
}
