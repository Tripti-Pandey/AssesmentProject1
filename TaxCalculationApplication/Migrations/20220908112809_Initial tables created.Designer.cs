﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaxCalculationApplication.DataModel;

namespace TaxCalculationApplication.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220908112809_Initial tables created")]
    partial class Initialtablescreated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TaxCalculationApplication.DataModel.Model.Municipal", b =>
                {
                    b.Property<Guid>("MunicipalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Municipality")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MunicipalId");

                    b.ToTable("municipal");
                });

            modelBuilder.Entity("TaxCalculationApplication.DataModel.Model.MunicipalRules", b =>
                {
                    b.Property<Guid>("MunicipalRulesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MunicipalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RuleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MunicipalRulesId");

                    b.HasIndex("MunicipalId");

                    b.HasIndex("RuleId");

                    b.ToTable("municipalRules");
                });

            modelBuilder.Entity("TaxCalculationApplication.DataModel.Model.Rule", b =>
                {
                    b.Property<Guid>("RuleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("RuleId");

                    b.ToTable("rule");
                });

            modelBuilder.Entity("TaxCalculationApplication.DataModel.Model.TaxSchedule", b =>
                {
                    b.Property<Guid>("TaxScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MunicipalRulesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SpecificDates")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxPeriodName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("TaxRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TaxScheduleId");

                    b.HasIndex("MunicipalRulesId");

                    b.ToTable("taxSchedule");
                });

            modelBuilder.Entity("TaxCalculationApplication.DataModel.Model.MunicipalRules", b =>
                {
                    b.HasOne("TaxCalculationApplication.DataModel.Model.Municipal", "municipal")
                        .WithMany()
                        .HasForeignKey("MunicipalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaxCalculationApplication.DataModel.Model.Rule", "rule")
                        .WithMany()
                        .HasForeignKey("RuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("municipal");

                    b.Navigation("rule");
                });

            modelBuilder.Entity("TaxCalculationApplication.DataModel.Model.TaxSchedule", b =>
                {
                    b.HasOne("TaxCalculationApplication.DataModel.Model.MunicipalRules", "municipalRules")
                        .WithMany()
                        .HasForeignKey("MunicipalRulesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("municipalRules");
                });
#pragma warning restore 612, 618
        }
    }
}
