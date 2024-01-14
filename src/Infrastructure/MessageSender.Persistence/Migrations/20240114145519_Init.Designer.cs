﻿// <auto-generated />
using System;
using MessageSender.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MessageSender.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240114145519_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MessageSender.Domain.Entities.Client", b =>
                {
                    b.Property<Guid>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ClientId");

                    b.Property<string>("Config")
                        .IsRequired()
                        .HasColumnType("nvarchar(2000)")
                        .HasColumnName("Config");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<Guid>("Secret")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Secret");

                    b.HasKey("ClientId")
                        .HasName("PK_Client");

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("MessageSender.Domain.Entities.Country", b =>
                {
                    b.Property<string>("Alpha2Code")
                        .HasColumnType("char(2)")
                        .HasColumnName("Alpha2Code");

                    b.Property<short>("DialCode")
                        .HasColumnType("smallint")
                        .HasColumnName("DialCode");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.HasKey("Alpha2Code")
                        .HasName("PK_Country");

                    b.HasIndex("DialCode")
                        .HasDatabaseName("IX_Country_DialCode");

                    b.ToTable("Country", (string)null);
                });

            modelBuilder.Entity("MessageSender.Domain.Entities.CountryProvider", b =>
                {
                    b.Property<int>("CountryProviderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CountryProviderId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CountryProviderId"));

                    b.Property<string>("Alpha2Code")
                        .IsRequired()
                        .HasColumnType("char(2)")
                        .HasColumnName("Alpha2Code");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<short>("Priority")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("SMALLINT")
                        .HasColumnName("Priority")
                        .HasDefaultValueSql("32767");

                    b.Property<int>("ProviderId")
                        .HasColumnType("int")
                        .HasColumnName("ProviderId");

                    b.HasKey("CountryProviderId")
                        .HasName("PK_CountryProvider");

                    b.HasIndex("Alpha2Code")
                        .HasDatabaseName("IX_CountryProvider_Alpha2Code");

                    b.HasIndex("ProviderId")
                        .HasDatabaseName("IX_CountryProvider_ProviderId");

                    b.ToTable("CountryProvider", (string)null);
                });

            modelBuilder.Entity("MessageSender.Domain.Entities.GreyList", b =>
                {
                    b.Property<string>("ContactIdentifier")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("ContactIdentifier");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CreateDate")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<DateTime>("ModifyDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("ModifyDate")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(32)")
                        .HasColumnName("Status")
                        .HasComment("Possible Values:\nBlack\nWhite");

                    b.Property<string>("StatusNote")
                        .IsRequired()
                        .HasColumnType("nvarchar(511)")
                        .HasColumnName("StatusNote");

                    b.HasKey("ContactIdentifier")
                        .HasName("PK_GreyList");

                    b.ToTable("GreyList", (string)null);
                });

            modelBuilder.Entity("MessageSender.Domain.Entities.MessageDelivery", b =>
                {
                    b.Property<long>("MessageDeliveryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("MessageDeliveryId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("MessageDeliveryId"));

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CreateDate")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime>("ModifyDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("ModifyDate")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int?>("ProviderId")
                        .HasColumnType("int")
                        .HasColumnName("ProviderId");

                    b.Property<string>("ProviderMessageId")
                        .HasColumnType("varchar(64)")
                        .HasColumnName("ProviderMessageId");

                    b.Property<long?>("SmsId")
                        .HasColumnType("bigint")
                        .HasColumnName("SmsId");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(32)")
                        .HasColumnName("Status")
                        .HasComment("Possible Values:\nSendingToProvider\nSuccessFromProvider\nDeliveredToUser\nFailFromProvider\nFail\nUnknown");

                    b.Property<string>("StatusNote")
                        .HasColumnType("nvarchar(511)")
                        .HasColumnName("StatusNote");

                    b.HasKey("MessageDeliveryId")
                        .HasName("PK_MessageDelivery");

                    b.HasIndex("ProviderId")
                        .HasDatabaseName("IX_MessageDelivery_ProviderId");

                    b.HasIndex("SmsId")
                        .HasDatabaseName("IX_MessageDelivery_SmsId");

                    b.ToTable("MessageDelivery", (string)null);
                });

            modelBuilder.Entity("MessageSender.Domain.Entities.Provider", b =>
                {
                    b.Property<int>("ProviderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProviderId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProviderId"));

                    b.Property<string>("Config")
                        .IsRequired()
                        .HasColumnType("nvarchar(2000)")
                        .HasColumnName("Config");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<bool>("IsGlobal")
                        .HasColumnType("bit")
                        .HasColumnName("IsGlobal");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(64)")
                        .HasColumnName("Name");

                    b.Property<short>("Priority")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("SMALLINT")
                        .HasColumnName("Priority")
                        .HasDefaultValueSql("32767");

                    b.HasKey("ProviderId")
                        .HasName("PK_Provider");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("IX_Provider_Name_UQ");

                    b.ToTable("Provider", (string)null);
                });

            modelBuilder.Entity("MessageSender.Domain.Entities.Sms", b =>
                {
                    b.Property<long>("SmsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("SmsId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("SmsId"));

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ClientId");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CreateDate")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Message");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(32)")
                        .HasColumnName("PhoneNumber");

                    b.HasKey("SmsId")
                        .HasName("PK_Sms");

                    b.HasIndex("ClientId")
                        .HasDatabaseName("IX_Sms_ClientId");

                    b.ToTable("Sms", (string)null);
                });

            modelBuilder.Entity("MessageSender.Domain.Entities.CountryProvider", b =>
                {
                    b.HasOne("MessageSender.Domain.Entities.Country", "Country")
                        .WithMany("CountryProviders")
                        .HasForeignKey("Alpha2Code")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_CountryProvider_Country_Alpha2Code");

                    b.HasOne("MessageSender.Domain.Entities.Provider", "Provider")
                        .WithMany("CountryProviders")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_CountryProvider_Provider_ProviderId");

                    b.Navigation("Country");

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("MessageSender.Domain.Entities.MessageDelivery", b =>
                {
                    b.HasOne("MessageSender.Domain.Entities.Provider", "Provider")
                        .WithMany("MessageDeliveries")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK_MessageDelivery_Provider_ProviderId");

                    b.HasOne("MessageSender.Domain.Entities.Sms", "Sms")
                        .WithMany("MessageDeliveries")
                        .HasForeignKey("SmsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_MessageDelivery_Sms_SmsId");

                    b.Navigation("Provider");

                    b.Navigation("Sms");
                });

            modelBuilder.Entity("MessageSender.Domain.Entities.Sms", b =>
                {
                    b.HasOne("MessageSender.Domain.Entities.Client", "Client")
                        .WithMany("Smses")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Sms_Client_ClientId");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("MessageSender.Domain.Entities.Client", b =>
                {
                    b.Navigation("Smses");
                });

            modelBuilder.Entity("MessageSender.Domain.Entities.Country", b =>
                {
                    b.Navigation("CountryProviders");
                });

            modelBuilder.Entity("MessageSender.Domain.Entities.Provider", b =>
                {
                    b.Navigation("CountryProviders");

                    b.Navigation("MessageDeliveries");
                });

            modelBuilder.Entity("MessageSender.Domain.Entities.Sms", b =>
                {
                    b.Navigation("MessageDeliveries");
                });
#pragma warning restore 612, 618
        }
    }
}
