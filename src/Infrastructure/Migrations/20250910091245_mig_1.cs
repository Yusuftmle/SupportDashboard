using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerTicket_Customer_CustomerId",
                table: "CustomerTicket");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Users_ManagerId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentUser_Department_Department1Id",
                table: "DepartmentUser");

            migrationBuilder.DropForeignKey(
                name: "FK_KnowledgeBaseArticle_TicketCategory_CategoryId",
                table: "KnowledgeBaseArticle");

            migrationBuilder.DropForeignKey(
                name: "FK_SLATicket_SLA_SLAId",
                table: "SLATicket");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketAttachment_TicketComment_CommentId",
                table: "TicketAttachment");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketAttachment_Tickets_TicketId",
                table: "TicketAttachment");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketAttachment_Users_UploadedById",
                table: "TicketAttachment");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketCategory_Department_DepartmentId",
                table: "TicketCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketComment_Tickets_TicketId",
                table: "TicketComment");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketComment_Users_UserId",
                table: "TicketComment");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketEscalation_Tickets_TicketId",
                table: "TicketEscalation");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketEscalation_Users_FromUserId",
                table: "TicketEscalation");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketEscalation_Users_ToUserId",
                table: "TicketEscalation");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketCategory_TicketCategoryId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketTicketTag_TicketTag_TicketTagId",
                table: "TicketTicketTag");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingHours_Department_DepartmentId",
                table: "WorkingHours");

            migrationBuilder.DropTable(
                name: "TicketEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketTag",
                table: "TicketTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketEscalation",
                table: "TicketEscalation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketComment",
                table: "TicketComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketCategory",
                table: "TicketCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketAttachment",
                table: "TicketAttachment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SLA",
                table: "SLA");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KnowledgeBaseArticle",
                table: "KnowledgeBaseArticle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "TicketEvents");

            migrationBuilder.RenameTable(
                name: "TicketTag",
                newName: "TicketTags");

            migrationBuilder.RenameTable(
                name: "TicketEscalation",
                newName: "TicketEscalations");

            migrationBuilder.RenameTable(
                name: "TicketComment",
                newName: "TicketComments");

            migrationBuilder.RenameTable(
                name: "TicketCategory",
                newName: "TicketCategories");

            migrationBuilder.RenameTable(
                name: "TicketAttachment",
                newName: "TicketAttachments");

            migrationBuilder.RenameTable(
                name: "SLA",
                newName: "SLAs");

            migrationBuilder.RenameTable(
                name: "KnowledgeBaseArticle",
                newName: "KnowledgeBaseArticles");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Departments");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "TicketEvents",
                newName: "TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketTag_Name",
                table: "TicketTags",
                newName: "IX_TicketTags_Name");

            migrationBuilder.RenameIndex(
                name: "IX_TicketTag_IsActive",
                table: "TicketTags",
                newName: "IX_TicketTags_IsActive");

            migrationBuilder.RenameIndex(
                name: "IX_TicketEscalation_ToUserId",
                table: "TicketEscalations",
                newName: "IX_TicketEscalations_ToUserId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketEscalation_TicketId",
                table: "TicketEscalations",
                newName: "IX_TicketEscalations_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketEscalation_FromUserId",
                table: "TicketEscalations",
                newName: "IX_TicketEscalations_FromUserId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketEscalation_EscalatedDate",
                table: "TicketEscalations",
                newName: "IX_TicketEscalations_EscalatedDate");

            migrationBuilder.RenameIndex(
                name: "IX_TicketComment_UserId",
                table: "TicketComments",
                newName: "IX_TicketComments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketComment_TicketId",
                table: "TicketComments",
                newName: "IX_TicketComments_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketComment_CreateDate",
                table: "TicketComments",
                newName: "IX_TicketComments_CreateDate");

            migrationBuilder.RenameIndex(
                name: "IX_TicketCategory_DepartmentId",
                table: "TicketCategories",
                newName: "IX_TicketCategories_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketAttachment_UploadedById",
                table: "TicketAttachments",
                newName: "IX_TicketAttachments_UploadedById");

            migrationBuilder.RenameIndex(
                name: "IX_TicketAttachment_TicketId",
                table: "TicketAttachments",
                newName: "IX_TicketAttachments_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketAttachment_CommentId",
                table: "TicketAttachments",
                newName: "IX_TicketAttachments_CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_SLA_Priority",
                table: "SLAs",
                newName: "IX_SLAs_Priority");

            migrationBuilder.RenameIndex(
                name: "IX_SLA_IsActive",
                table: "SLAs",
                newName: "IX_SLAs_IsActive");

            migrationBuilder.RenameIndex(
                name: "IX_KnowledgeBaseArticle_Subject",
                table: "KnowledgeBaseArticles",
                newName: "IX_KnowledgeBaseArticles_Subject");

            migrationBuilder.RenameIndex(
                name: "IX_KnowledgeBaseArticle_IsActive",
                table: "KnowledgeBaseArticles",
                newName: "IX_KnowledgeBaseArticles_IsActive");

            migrationBuilder.RenameIndex(
                name: "IX_KnowledgeBaseArticle_CategoryId",
                table: "KnowledgeBaseArticles",
                newName: "IX_KnowledgeBaseArticles_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Department_Name",
                table: "Departments",
                newName: "IX_Departments_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Department_ManagerId",
                table: "Departments",
                newName: "IX_Departments_ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Department_IsActive",
                table: "Departments",
                newName: "IX_Departments_IsActive");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_Tier",
                table: "Customers",
                newName: "IX_Customers_Tier");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_IsActive",
                table: "Customers",
                newName: "IX_Customers_IsActive");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_Email",
                table: "Customers",
                newName: "IX_Customers_Email");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_CompanyName",
                table: "Customers",
                newName: "IX_Customers_CompanyName");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "TicketEvents",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "TicketEvents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EventData",
                table: "TicketEvents",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventType",
                table: "TicketEvents",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TicketEvents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NewValue",
                table: "TicketEvents",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OldValue",
                table: "TicketEvents",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "TicketEvents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketTags",
                table: "TicketTags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketEscalations",
                table: "TicketEscalations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketComments",
                table: "TicketComments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketCategories",
                table: "TicketCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketAttachments",
                table: "TicketAttachments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SLAs",
                table: "SLAs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KnowledgeBaseArticles",
                table: "KnowledgeBaseArticles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TicketEvents_CreateDate",
                table: "TicketEvents",
                column: "CreateDate");

            migrationBuilder.CreateIndex(
                name: "IX_TicketEvents_EventType",
                table: "TicketEvents",
                column: "EventType");

            migrationBuilder.CreateIndex(
                name: "IX_TicketEvents_TicketId",
                table: "TicketEvents",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketEvents_UserId",
                table: "TicketEvents",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerTicket_Customers_CustomerId",
                table: "CustomerTicket",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Users_ManagerId",
                table: "Departments",
                column: "ManagerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentUser_Departments_Department1Id",
                table: "DepartmentUser",
                column: "Department1Id",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KnowledgeBaseArticles_TicketCategories_CategoryId",
                table: "KnowledgeBaseArticles",
                column: "CategoryId",
                principalTable: "TicketCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_SLATicket_SLAs_SLAId",
                table: "SLATicket",
                column: "SLAId",
                principalTable: "SLAs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketAttachments_TicketComments_CommentId",
                table: "TicketAttachments",
                column: "CommentId",
                principalTable: "TicketComments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketAttachments_Tickets_TicketId",
                table: "TicketAttachments",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketAttachments_Users_UploadedById",
                table: "TicketAttachments",
                column: "UploadedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketCategories_Departments_DepartmentId",
                table: "TicketCategories",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketComments_Tickets_TicketId",
                table: "TicketComments",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketComments_Users_UserId",
                table: "TicketComments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketEscalations_Tickets_TicketId",
                table: "TicketEscalations",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketEscalations_Users_FromUserId",
                table: "TicketEscalations",
                column: "FromUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketEscalations_Users_ToUserId",
                table: "TicketEscalations",
                column: "ToUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketEvents_Tickets_TicketId",
                table: "TicketEvents",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketEvents_Users_UserId",
                table: "TicketEvents",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketCategories_TicketCategoryId",
                table: "Tickets",
                column: "TicketCategoryId",
                principalTable: "TicketCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketTicketTag_TicketTags_TicketTagId",
                table: "TicketTicketTag",
                column: "TicketTagId",
                principalTable: "TicketTags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingHours_Departments_DepartmentId",
                table: "WorkingHours",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerTicket_Customers_CustomerId",
                table: "CustomerTicket");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Users_ManagerId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentUser_Departments_Department1Id",
                table: "DepartmentUser");

            migrationBuilder.DropForeignKey(
                name: "FK_KnowledgeBaseArticles_TicketCategories_CategoryId",
                table: "KnowledgeBaseArticles");

            migrationBuilder.DropForeignKey(
                name: "FK_SLATicket_SLAs_SLAId",
                table: "SLATicket");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketAttachments_TicketComments_CommentId",
                table: "TicketAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketAttachments_Tickets_TicketId",
                table: "TicketAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketAttachments_Users_UploadedById",
                table: "TicketAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketCategories_Departments_DepartmentId",
                table: "TicketCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketComments_Tickets_TicketId",
                table: "TicketComments");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketComments_Users_UserId",
                table: "TicketComments");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketEscalations_Tickets_TicketId",
                table: "TicketEscalations");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketEscalations_Users_FromUserId",
                table: "TicketEscalations");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketEscalations_Users_ToUserId",
                table: "TicketEscalations");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketEvents_Tickets_TicketId",
                table: "TicketEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketEvents_Users_UserId",
                table: "TicketEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketCategories_TicketCategoryId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketTicketTag_TicketTags_TicketTagId",
                table: "TicketTicketTag");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingHours_Departments_DepartmentId",
                table: "WorkingHours");

            migrationBuilder.DropIndex(
                name: "IX_TicketEvents_CreateDate",
                table: "TicketEvents");

            migrationBuilder.DropIndex(
                name: "IX_TicketEvents_EventType",
                table: "TicketEvents");

            migrationBuilder.DropIndex(
                name: "IX_TicketEvents_TicketId",
                table: "TicketEvents");

            migrationBuilder.DropIndex(
                name: "IX_TicketEvents_UserId",
                table: "TicketEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketTags",
                table: "TicketTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketEscalations",
                table: "TicketEscalations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketComments",
                table: "TicketComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketCategories",
                table: "TicketCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketAttachments",
                table: "TicketAttachments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SLAs",
                table: "SLAs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KnowledgeBaseArticles",
                table: "KnowledgeBaseArticles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "TicketEvents");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "TicketEvents");

            migrationBuilder.DropColumn(
                name: "EventData",
                table: "TicketEvents");

            migrationBuilder.DropColumn(
                name: "EventType",
                table: "TicketEvents");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TicketEvents");

            migrationBuilder.DropColumn(
                name: "NewValue",
                table: "TicketEvents");

            migrationBuilder.DropColumn(
                name: "OldValue",
                table: "TicketEvents");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TicketEvents");

            migrationBuilder.RenameTable(
                name: "TicketTags",
                newName: "TicketTag");

            migrationBuilder.RenameTable(
                name: "TicketEscalations",
                newName: "TicketEscalation");

            migrationBuilder.RenameTable(
                name: "TicketComments",
                newName: "TicketComment");

            migrationBuilder.RenameTable(
                name: "TicketCategories",
                newName: "TicketCategory");

            migrationBuilder.RenameTable(
                name: "TicketAttachments",
                newName: "TicketAttachment");

            migrationBuilder.RenameTable(
                name: "SLAs",
                newName: "SLA");

            migrationBuilder.RenameTable(
                name: "KnowledgeBaseArticles",
                newName: "KnowledgeBaseArticle");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Department");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameColumn(
                name: "TicketId",
                table: "TicketEvents",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_TicketTags_Name",
                table: "TicketTag",
                newName: "IX_TicketTag_Name");

            migrationBuilder.RenameIndex(
                name: "IX_TicketTags_IsActive",
                table: "TicketTag",
                newName: "IX_TicketTag_IsActive");

            migrationBuilder.RenameIndex(
                name: "IX_TicketEscalations_ToUserId",
                table: "TicketEscalation",
                newName: "IX_TicketEscalation_ToUserId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketEscalations_TicketId",
                table: "TicketEscalation",
                newName: "IX_TicketEscalation_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketEscalations_FromUserId",
                table: "TicketEscalation",
                newName: "IX_TicketEscalation_FromUserId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketEscalations_EscalatedDate",
                table: "TicketEscalation",
                newName: "IX_TicketEscalation_EscalatedDate");

            migrationBuilder.RenameIndex(
                name: "IX_TicketComments_UserId",
                table: "TicketComment",
                newName: "IX_TicketComment_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketComments_TicketId",
                table: "TicketComment",
                newName: "IX_TicketComment_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketComments_CreateDate",
                table: "TicketComment",
                newName: "IX_TicketComment_CreateDate");

            migrationBuilder.RenameIndex(
                name: "IX_TicketCategories_DepartmentId",
                table: "TicketCategory",
                newName: "IX_TicketCategory_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketAttachments_UploadedById",
                table: "TicketAttachment",
                newName: "IX_TicketAttachment_UploadedById");

            migrationBuilder.RenameIndex(
                name: "IX_TicketAttachments_TicketId",
                table: "TicketAttachment",
                newName: "IX_TicketAttachment_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketAttachments_CommentId",
                table: "TicketAttachment",
                newName: "IX_TicketAttachment_CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_SLAs_Priority",
                table: "SLA",
                newName: "IX_SLA_Priority");

            migrationBuilder.RenameIndex(
                name: "IX_SLAs_IsActive",
                table: "SLA",
                newName: "IX_SLA_IsActive");

            migrationBuilder.RenameIndex(
                name: "IX_KnowledgeBaseArticles_Subject",
                table: "KnowledgeBaseArticle",
                newName: "IX_KnowledgeBaseArticle_Subject");

            migrationBuilder.RenameIndex(
                name: "IX_KnowledgeBaseArticles_IsActive",
                table: "KnowledgeBaseArticle",
                newName: "IX_KnowledgeBaseArticle_IsActive");

            migrationBuilder.RenameIndex(
                name: "IX_KnowledgeBaseArticles_CategoryId",
                table: "KnowledgeBaseArticle",
                newName: "IX_KnowledgeBaseArticle_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_Name",
                table: "Department",
                newName: "IX_Department_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_ManagerId",
                table: "Department",
                newName: "IX_Department_ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_IsActive",
                table: "Department",
                newName: "IX_Department_IsActive");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_Tier",
                table: "Customer",
                newName: "IX_Customer_Tier");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_IsActive",
                table: "Customer",
                newName: "IX_Customer_IsActive");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_Email",
                table: "Customer",
                newName: "IX_Customer_Email");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_CompanyName",
                table: "Customer",
                newName: "IX_Customer_CompanyName");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "TicketEvents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketTag",
                table: "TicketTag",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketEscalation",
                table: "TicketEscalation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketComment",
                table: "TicketComment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketCategory",
                table: "TicketCategory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketAttachment",
                table: "TicketAttachment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SLA",
                table: "SLA",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KnowledgeBaseArticle",
                table: "KnowledgeBaseArticle",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TicketEvent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventData = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    EventType = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    NewValue = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OldValue = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketEvent_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketEvent_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketEvent_CreateDate",
                table: "TicketEvent",
                column: "CreateDate");

            migrationBuilder.CreateIndex(
                name: "IX_TicketEvent_EventType",
                table: "TicketEvent",
                column: "EventType");

            migrationBuilder.CreateIndex(
                name: "IX_TicketEvent_TicketId",
                table: "TicketEvent",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketEvent_UserId",
                table: "TicketEvent",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerTicket_Customer_CustomerId",
                table: "CustomerTicket",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Users_ManagerId",
                table: "Department",
                column: "ManagerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentUser_Department_Department1Id",
                table: "DepartmentUser",
                column: "Department1Id",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KnowledgeBaseArticle_TicketCategory_CategoryId",
                table: "KnowledgeBaseArticle",
                column: "CategoryId",
                principalTable: "TicketCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_SLATicket_SLA_SLAId",
                table: "SLATicket",
                column: "SLAId",
                principalTable: "SLA",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketAttachment_TicketComment_CommentId",
                table: "TicketAttachment",
                column: "CommentId",
                principalTable: "TicketComment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketAttachment_Tickets_TicketId",
                table: "TicketAttachment",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketAttachment_Users_UploadedById",
                table: "TicketAttachment",
                column: "UploadedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketCategory_Department_DepartmentId",
                table: "TicketCategory",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketComment_Tickets_TicketId",
                table: "TicketComment",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketComment_Users_UserId",
                table: "TicketComment",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketEscalation_Tickets_TicketId",
                table: "TicketEscalation",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketEscalation_Users_FromUserId",
                table: "TicketEscalation",
                column: "FromUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketEscalation_Users_ToUserId",
                table: "TicketEscalation",
                column: "ToUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketCategory_TicketCategoryId",
                table: "Tickets",
                column: "TicketCategoryId",
                principalTable: "TicketCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketTicketTag_TicketTag_TicketTagId",
                table: "TicketTicketTag",
                column: "TicketTagId",
                principalTable: "TicketTag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingHours_Department_DepartmentId",
                table: "WorkingHours",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
