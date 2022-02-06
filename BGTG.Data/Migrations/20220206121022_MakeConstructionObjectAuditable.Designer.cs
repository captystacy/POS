﻿// <auto-generated />
using System;
using BGTG.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BGTG.POS.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220206121022_MakeConstructionObjectAuditable")]
    partial class MakeConstructionObjectAuditable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BGTG.Entities.ConstructionObjectEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cipher")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("ConstructionObjects");
                });

            modelBuilder.Entity("BGTG.Entities.POSEntities.CalendarPlanToolEntities.CalendarPlanEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ConstructionDuration")
                        .HasColumnType("money");

                    b.Property<int>("ConstructionDurationCeiling")
                        .HasColumnType("int");

                    b.Property<DateTime>("ConstructionStartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<Guid>("POSId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("POSId")
                        .IsUnique();

                    b.ToTable("CalendarPlans");
                });

            modelBuilder.Entity("BGTG.Entities.POSEntities.CalendarPlanToolEntities.MainCalendarWorkEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CalendarPlanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("EstimateChapter")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("money");

                    b.Property<decimal>("TotalCostIncludingCAIW")
                        .HasColumnType("money");

                    b.Property<string>("WorkName")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("CalendarPlanId");

                    b.ToTable("MainCalendarWorks");
                });

            modelBuilder.Entity("BGTG.Entities.POSEntities.CalendarPlanToolEntities.MainConstructionMonthEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CreationIndex")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("InvestmentVolume")
                        .HasColumnType("money");

                    b.Property<Guid>("MainCalendarWorkId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("PercentPart")
                        .HasColumnType("money");

                    b.Property<decimal>("VolumeCAIW")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("MainCalendarWorkId");

                    b.ToTable("MainConstructionMonths");
                });

            modelBuilder.Entity("BGTG.Entities.POSEntities.CalendarPlanToolEntities.PreparatoryCalendarWorkEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CalendarPlanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("EstimateChapter")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("money");

                    b.Property<decimal>("TotalCostIncludingCAIW")
                        .HasColumnType("money");

                    b.Property<string>("WorkName")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("CalendarPlanId");

                    b.ToTable("PreparatoryCalendarWorks");
                });

            modelBuilder.Entity("BGTG.Entities.POSEntities.CalendarPlanToolEntities.PreparatoryConstructionMonthEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CreationIndex")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("InvestmentVolume")
                        .HasColumnType("money");

                    b.Property<decimal>("PercentPart")
                        .HasColumnType("money");

                    b.Property<Guid>("PreparatoryCalendarWorkId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("VolumeCAIW")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("PreparatoryCalendarWorkId");

                    b.ToTable("PreparatoryConstructionMonths");
                });

            modelBuilder.Entity("BGTG.Entities.POSEntities.DurationByLCToolEntities.DurationByLCEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("AcceptanceTime")
                        .HasColumnType("money");

                    b.Property<bool>("AcceptanceTimeIncluded")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<decimal>("Duration")
                        .HasColumnType("money");

                    b.Property<decimal>("EstimateLaborCosts")
                        .HasColumnType("money");

                    b.Property<int>("NumberOfEmployees")
                        .HasColumnType("int");

                    b.Property<decimal>("NumberOfWorkingDays")
                        .HasColumnType("money");

                    b.Property<Guid>("POSId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("PreparatoryPeriod")
                        .HasColumnType("money");

                    b.Property<decimal>("RoundedDuration")
                        .HasColumnType("money");

                    b.Property<bool>("RoundingIncluded")
                        .HasColumnType("bit");

                    b.Property<decimal>("Shift")
                        .HasColumnType("money");

                    b.Property<decimal>("TechnologicalLaborCosts")
                        .HasColumnType("money");

                    b.Property<decimal>("TotalDuration")
                        .HasColumnType("money");

                    b.Property<decimal>("TotalLaborCosts")
                        .HasColumnType("money");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<decimal>("WorkingDayDuration")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("POSId")
                        .IsUnique();

                    b.ToTable("DurationByLCs");
                });

            modelBuilder.Entity("BGTG.Entities.POSEntities.DurationByTCPToolEntities.ExtrapolationDurationByTCPEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AppendixKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("AppendixPage")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<decimal>("Duration")
                        .HasColumnType("money");

                    b.Property<int>("DurationCalculationType")
                        .HasColumnType("int");

                    b.Property<Guid>("POSId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PipelineDiameter")
                        .HasColumnType("int");

                    b.Property<string>("PipelineDiameterPresentation")
                        .IsRequired()
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.Property<decimal>("PipelineLength")
                        .HasColumnType("money");

                    b.Property<string>("PipelineMaterial")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<decimal>("PreparatoryPeriod")
                        .HasColumnType("money");

                    b.Property<decimal>("RoundedDuration")
                        .HasColumnType("money");

                    b.Property<decimal>("StandardChangePercent")
                        .HasColumnType("money");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<decimal>("VolumeChangePercent")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("POSId")
                        .IsUnique();

                    b.ToTable("ExtrapolationDurationByTCPs");
                });

            modelBuilder.Entity("BGTG.Entities.POSEntities.DurationByTCPToolEntities.ExtrapolationPipelineStandardEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Duration")
                        .HasColumnType("money");

                    b.Property<Guid>("ExtrapolationDurationByTCPId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("PipelineLength")
                        .HasColumnType("money");

                    b.Property<decimal>("PreparatoryPeriod")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("ExtrapolationDurationByTCPId");

                    b.ToTable("ExtrapolationPipelineStandards");
                });

            modelBuilder.Entity("BGTG.Entities.POSEntities.DurationByTCPToolEntities.InterpolationDurationByTCPEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AppendixKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("AppendixPage")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<decimal>("Duration")
                        .HasColumnType("money");

                    b.Property<int>("DurationCalculationType")
                        .HasColumnType("int");

                    b.Property<decimal>("DurationChange")
                        .HasColumnType("money");

                    b.Property<Guid>("POSId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PipelineDiameter")
                        .HasColumnType("int");

                    b.Property<string>("PipelineDiameterPresentation")
                        .IsRequired()
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.Property<decimal>("PipelineLength")
                        .HasColumnType("money");

                    b.Property<string>("PipelineMaterial")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<decimal>("PreparatoryPeriod")
                        .HasColumnType("money");

                    b.Property<decimal>("RoundedDuration")
                        .HasColumnType("money");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<decimal>("VolumeChange")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("POSId")
                        .IsUnique();

                    b.ToTable("InterpolationDurationByTCPs");
                });

            modelBuilder.Entity("BGTG.Entities.POSEntities.DurationByTCPToolEntities.InterpolationPipelineStandardEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Duration")
                        .HasColumnType("money");

                    b.Property<Guid>("InterpolationDurationByTCPId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("PipelineLength")
                        .HasColumnType("money");

                    b.Property<decimal>("PreparatoryPeriod")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("InterpolationDurationByTCPId");

                    b.ToTable("InterpolationPipelineStandards");
                });

            modelBuilder.Entity("BGTG.Entities.POSEntities.DurationByTCPToolEntities.StepwiseExtrapolationDurationByTCPEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AppendixKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("AppendixPage")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<decimal>("Duration")
                        .HasColumnType("money");

                    b.Property<int>("DurationCalculationType")
                        .HasColumnType("int");

                    b.Property<Guid>("POSId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PipelineDiameter")
                        .HasColumnType("int");

                    b.Property<string>("PipelineDiameterPresentation")
                        .IsRequired()
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.Property<decimal>("PipelineLength")
                        .HasColumnType("money");

                    b.Property<string>("PipelineMaterial")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<decimal>("PreparatoryPeriod")
                        .HasColumnType("money");

                    b.Property<decimal>("RoundedDuration")
                        .HasColumnType("money");

                    b.Property<decimal>("StandardChangePercent")
                        .HasColumnType("money");

                    b.Property<decimal>("StepwiseDuration")
                        .HasColumnType("money");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<decimal>("VolumeChangePercent")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("POSId")
                        .IsUnique();

                    b.ToTable("StepwiseExtrapolationDurationByTCPs");
                });

            modelBuilder.Entity("BGTG.Entities.POSEntities.DurationByTCPToolEntities.StepwiseExtrapolationPipelineStandardEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Duration")
                        .HasColumnType("money");

                    b.Property<decimal>("PipelineLength")
                        .HasColumnType("money");

                    b.Property<decimal>("PreparatoryPeriod")
                        .HasColumnType("money");

                    b.Property<Guid>("StepwiseExtrapolationDurationByTCPId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StepwiseExtrapolationDurationByTCPId");

                    b.ToTable("StepwiseExtrapolationPipelineStandards");
                });

            modelBuilder.Entity("BGTG.Entities.POSEntities.DurationByTCPToolEntities.StepwisePipelineStandardEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Duration")
                        .HasColumnType("money");

                    b.Property<decimal>("PipelineLength")
                        .HasColumnType("money");

                    b.Property<decimal>("PreparatoryPeriod")
                        .HasColumnType("money");

                    b.Property<Guid>("StepwiseExtrapolationDurationByTCPId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StepwiseExtrapolationDurationByTCPId")
                        .IsUnique();

                    b.ToTable("StepwisePipelineStandards");
                });

            modelBuilder.Entity("BGTG.Entities.POSEntities.EnergyAndWaterToolEntities.EnergyAndWaterEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("CompressedAir")
                        .HasColumnType("money");

                    b.Property<int>("ConstructionYear")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<decimal>("Energy")
                        .HasColumnType("money");

                    b.Property<decimal>("Oxygen")
                        .HasColumnType("money");

                    b.Property<Guid>("POSId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<decimal>("VolumeCAIW")
                        .HasColumnType("money");

                    b.Property<decimal>("Water")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("POSId")
                        .IsUnique();

                    b.ToTable("EnergyAndWaters");
                });

            modelBuilder.Entity("BGTG.Entities.POSEntities.POSEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ConstructionObjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ConstructionObjectId")
                        .IsUnique();

                    b.ToTable("POSes");
                });

            modelBuilder.Entity("Microsoft.EntityFrameworkCore.AutoHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Changed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("Kind")
                        .HasColumnType("int");

                    b.Property<string>("RowId")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("AutoHistory");
                });

            modelBuilder.Entity("BGTG.Entities.POSEntities.CalendarPlanToolEntities.CalendarPlanEntity", b =>
                {
                    b.HasOne("BGTG.Entities.POSEntities.POSEntity", "POS")
                        .WithOne("CalendarPlan")
                        .HasForeignKey("BGTG.Entities.POSEntities.CalendarPlanToolEntities.CalendarPlanEntity", "POSId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BGTG.Entities.POSEntities.CalendarPlanToolEntities.MainCalendarWorkEntity", b =>
                {
                    b.HasOne("BGTG.Entities.POSEntities.CalendarPlanToolEntities.CalendarPlanEntity", "CalendarPlan")
                        .WithMany("MainCalendarWorks")
                        .HasForeignKey("CalendarPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BGTG.Entities.POSEntities.CalendarPlanToolEntities.MainConstructionMonthEntity", b =>
                {
                    b.HasOne("BGTG.Entities.POSEntities.CalendarPlanToolEntities.MainCalendarWorkEntity", "MainCalendarWork")
                        .WithMany("ConstructionMonths")
                        .HasForeignKey("MainCalendarWorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BGTG.Entities.POSEntities.CalendarPlanToolEntities.PreparatoryCalendarWorkEntity", b =>
                {
                    b.HasOne("BGTG.Entities.POSEntities.CalendarPlanToolEntities.CalendarPlanEntity", "CalendarPlan")
                        .WithMany("PreparatoryCalendarWorks")
                        .HasForeignKey("CalendarPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BGTG.Entities.POSEntities.CalendarPlanToolEntities.PreparatoryConstructionMonthEntity", b =>
                {
                    b.HasOne("BGTG.Entities.POSEntities.CalendarPlanToolEntities.PreparatoryCalendarWorkEntity", "PreparatoryCalendarWork")
                        .WithMany("ConstructionMonths")
                        .HasForeignKey("PreparatoryCalendarWorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BGTG.Entities.POSEntities.DurationByLCToolEntities.DurationByLCEntity", b =>
                {
                    b.HasOne("BGTG.Entities.POSEntities.POSEntity", "POS")
                        .WithOne("DurationByLC")
                        .HasForeignKey("BGTG.Entities.POSEntities.DurationByLCToolEntities.DurationByLCEntity", "POSId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BGTG.Entities.POSEntities.DurationByTCPToolEntities.ExtrapolationDurationByTCPEntity", b =>
                {
                    b.HasOne("BGTG.Entities.POSEntities.POSEntity", "POS")
                        .WithOne("ExtrapolationDurationByTCP")
                        .HasForeignKey("BGTG.Entities.POSEntities.DurationByTCPToolEntities.ExtrapolationDurationByTCPEntity", "POSId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BGTG.Entities.POSEntities.DurationByTCPToolEntities.ExtrapolationPipelineStandardEntity", b =>
                {
                    b.HasOne("BGTG.Entities.POSEntities.DurationByTCPToolEntities.ExtrapolationDurationByTCPEntity", "ExtrapolationDurationByTCP")
                        .WithMany("CalculationPipelineStandards")
                        .HasForeignKey("ExtrapolationDurationByTCPId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BGTG.Entities.POSEntities.DurationByTCPToolEntities.InterpolationDurationByTCPEntity", b =>
                {
                    b.HasOne("BGTG.Entities.POSEntities.POSEntity", "POS")
                        .WithOne("InterpolationDurationByTCP")
                        .HasForeignKey("BGTG.Entities.POSEntities.DurationByTCPToolEntities.InterpolationDurationByTCPEntity", "POSId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BGTG.Entities.POSEntities.DurationByTCPToolEntities.InterpolationPipelineStandardEntity", b =>
                {
                    b.HasOne("BGTG.Entities.POSEntities.DurationByTCPToolEntities.InterpolationDurationByTCPEntity", "InterpolationDurationByTCP")
                        .WithMany("CalculationPipelineStandards")
                        .HasForeignKey("InterpolationDurationByTCPId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BGTG.Entities.POSEntities.DurationByTCPToolEntities.StepwiseExtrapolationDurationByTCPEntity", b =>
                {
                    b.HasOne("BGTG.Entities.POSEntities.POSEntity", "POS")
                        .WithOne("StepwiseExtrapolationDurationByTCP")
                        .HasForeignKey("BGTG.Entities.POSEntities.DurationByTCPToolEntities.StepwiseExtrapolationDurationByTCPEntity", "POSId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BGTG.Entities.POSEntities.DurationByTCPToolEntities.StepwiseExtrapolationPipelineStandardEntity", b =>
                {
                    b.HasOne("BGTG.Entities.POSEntities.DurationByTCPToolEntities.StepwiseExtrapolationDurationByTCPEntity", "StepwiseExtrapolationDurationByTCP")
                        .WithMany("CalculationPipelineStandards")
                        .HasForeignKey("StepwiseExtrapolationDurationByTCPId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BGTG.Entities.POSEntities.DurationByTCPToolEntities.StepwisePipelineStandardEntity", b =>
                {
                    b.HasOne("BGTG.Entities.POSEntities.DurationByTCPToolEntities.StepwiseExtrapolationDurationByTCPEntity", "StepwiseExtrapolationDurationByTCP")
                        .WithOne("StepwisePipelineStandard")
                        .HasForeignKey("BGTG.Entities.POSEntities.DurationByTCPToolEntities.StepwisePipelineStandardEntity", "StepwiseExtrapolationDurationByTCPId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BGTG.Entities.POSEntities.EnergyAndWaterToolEntities.EnergyAndWaterEntity", b =>
                {
                    b.HasOne("BGTG.Entities.POSEntities.POSEntity", "POS")
                        .WithOne("EnergyAndWater")
                        .HasForeignKey("BGTG.Entities.POSEntities.EnergyAndWaterToolEntities.EnergyAndWaterEntity", "POSId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BGTG.Entities.POSEntities.POSEntity", b =>
                {
                    b.HasOne("BGTG.Entities.ConstructionObjectEntity", "ConstructionObject")
                        .WithOne("POS")
                        .HasForeignKey("BGTG.Entities.POSEntities.POSEntity", "ConstructionObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
