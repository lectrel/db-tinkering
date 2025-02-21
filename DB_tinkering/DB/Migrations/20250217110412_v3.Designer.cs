﻿// <auto-generated />
using System;
using DB_tinkering.DB.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DB_tinkering.DB.Migrations
{
    [DbContext(typeof(OrderProposalContext))]
    [Migration("20250217110412_v3")]
    partial class v3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DB_tinkering.DB.Models.Location", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("text")
                        .HasColumnName("code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Code")
                        .HasName("pk_locations");

                    b.ToTable("locations", (string)null);
                });

            modelBuilder.Entity("DB_tinkering.DB.Models.OrderProposal", b =>
                {
                    b.Property<string>("OrderNumber")
                        .HasColumnType("text")
                        .HasColumnName("order_number");

                    b.Property<float>("BatchSize")
                        .HasColumnType("real")
                        .HasColumnName("batch_size");

                    b.Property<float>("CorrectedQuantity")
                        .HasColumnType("real")
                        .HasColumnName("corrected_quantity");

                    b.Property<DateOnly>("DeliveryDate")
                        .HasColumnType("date")
                        .HasColumnName("delivery_date");

                    b.Property<TimeOnly>("EditableFrom")
                        .HasColumnType("time without time zone")
                        .HasColumnName("editable_from");

                    b.Property<TimeOnly>("EditableTo")
                        .HasColumnType("time without time zone")
                        .HasColumnName("editable_to");

                    b.Property<string>("LocationCode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("location_code");

                    b.Property<DateOnly>("OrderDate")
                        .HasColumnType("date")
                        .HasColumnName("order_date");

                    b.Property<string>("ProductCode")
                        .HasColumnType("text")
                        .HasColumnName("product_code");

                    b.Property<float>("ProposedQuantity")
                        .HasColumnType("real")
                        .HasColumnName("proposed_quantity");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.HasKey("OrderNumber")
                        .HasName("pk_order_proposals");

                    b.HasIndex("LocationCode")
                        .HasDatabaseName("ix_order_proposals_location_code");

                    b.HasIndex("ProductCode")
                        .HasDatabaseName("ix_order_proposals_product_code");

                    b.ToTable("order_proposals", (string)null);
                });

            modelBuilder.Entity("DB_tinkering.DB.Models.Product", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("text")
                        .HasColumnName("code");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("category");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("ProductGroupCode")
                        .HasColumnType("text")
                        .HasColumnName("product_group_code");

                    b.Property<float>("PurchasePrice")
                        .HasColumnType("real")
                        .HasColumnName("purchase_price");

                    b.Property<float>("SalesPrice")
                        .HasColumnType("real")
                        .HasColumnName("sales_price");

                    b.Property<string>("SupplierCode")
                        .HasColumnType("text")
                        .HasColumnName("supplier_code");

                    b.HasKey("Code")
                        .HasName("pk_products");

                    b.HasIndex("ProductGroupCode")
                        .HasDatabaseName("ix_products_product_group_code");

                    b.HasIndex("SupplierCode")
                        .HasDatabaseName("ix_products_supplier_code");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("DB_tinkering.DB.Models.ProductGroup", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("text")
                        .HasColumnName("code");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Code")
                        .HasName("pk_product_groups");

                    b.ToTable("product_groups", (string)null);
                });

            modelBuilder.Entity("DB_tinkering.DB.Models.Supplier", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("text")
                        .HasColumnName("code");

                    b.Property<float>("MaxOrderQuantity")
                        .HasColumnType("real")
                        .HasColumnName("max_order_quantity");

                    b.Property<float>("MinOrderQuantity")
                        .HasColumnType("real")
                        .HasColumnName("min_order_quantity");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Code")
                        .HasName("pk_suppliers");

                    b.ToTable("suppliers", (string)null);
                });

            modelBuilder.Entity("DB_tinkering.DB.Models.OrderProposal", b =>
                {
                    b.HasOne("DB_tinkering.DB.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_order_proposals_locations_location_code");

                    b.HasOne("DB_tinkering.DB.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductCode")
                        .HasConstraintName("fk_order_proposals_products_product_code");

                    b.Navigation("Location");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DB_tinkering.DB.Models.Product", b =>
                {
                    b.HasOne("DB_tinkering.DB.Models.ProductGroup", "ProductGroup")
                        .WithMany()
                        .HasForeignKey("ProductGroupCode")
                        .HasConstraintName("fk_products_product_groups_product_group_code");

                    b.HasOne("DB_tinkering.DB.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierCode")
                        .HasConstraintName("fk_products_suppliers_supplier_code");

                    b.Navigation("ProductGroup");

                    b.Navigation("Supplier");
                });
#pragma warning restore 612, 618
        }
    }
}
