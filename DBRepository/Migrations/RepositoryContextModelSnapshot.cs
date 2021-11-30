﻿// <auto-generated />
using System;
using DBRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DBRepository.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DBRepository.Models.OrderSaga", b =>
                {
                    b.Property<Guid>("CorrelationId")
                        .ValueGeneratedOnAdd();

                    b.Property<short>("CurrentState");

                    b.Property<string>("CustomerName");

                    b.Property<string>("CustomerSurname");

                    b.Property<DateTime>("OrderDate");

                    b.Property<int>("OrderNumber");

                    b.Property<DateTime?>("ShippedDate");

                    b.Property<int>("Type");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<string>("Version");

                    b.HasKey("CorrelationId");

                    b.ToTable("OrderSaga");
                });

            modelBuilder.Entity("DBRepository.Models.OrderSagaItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("OrderCorrelationId");

                    b.Property<Guid?>("OrderSagaCorrelationId");

                    b.Property<decimal>("Price");

                    b.Property<decimal>("Quantity");

                    b.Property<string>("SKU");

                    b.HasKey("id");

                    b.HasIndex("OrderSagaCorrelationId");

                    b.ToTable("OrderSagaItems");
                });

            modelBuilder.Entity("DBRepository.Models.OrderSagaItem", b =>
                {
                    b.HasOne("DBRepository.Models.OrderSaga")
                        .WithMany("OrderSagaItems")
                        .HasForeignKey("OrderSagaCorrelationId");
                });
#pragma warning restore 612, 618
        }
    }
}
