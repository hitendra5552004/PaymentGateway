using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentGateway.Domain.Entities;

namespace PaymentGateway.Infrastructure.Data
{
    public class PaymentGatewayContext : DbContext
    {

        public DbSet<CreditCardBrand> CreditCardBrands { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<CreditCardPayment> CreditCardPayments { get; set; }
        public DbSet<StoreAcquirer> StoreAcquirers { get; set; }
        public DbSet<Acquirer> Acquirers { get; set; }

        public PaymentGatewayContext(DbContextOptions<PaymentGatewayContext> options)
    : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoreConfiguration());
            modelBuilder.ApplyConfiguration(new CreditCardBrandConfiguration());
            modelBuilder.ApplyConfiguration(new CreditCardConfiguration());
            modelBuilder.ApplyConfiguration(new CreditCardPaymentConfiguration());
            modelBuilder.ApplyConfiguration(new AcquirerConfiguration());
            modelBuilder.ApplyConfiguration(new AcquirerSaleConfiguration());
            modelBuilder.ApplyConfiguration(new StoreAcquirerConfiguration());
        }

    }

    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable("Store");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(30);
            builder.Property(t => t.AntifraudEnabled);
        }
    }

    public class CreditCardBrandConfiguration : IEntityTypeConfiguration<CreditCardBrand>
    {
        public void Configure(EntityTypeBuilder<CreditCardBrand> builder)
        {
            builder.ToTable("CreditCardBrand");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(30);
            builder.Property(t => t.Description).HasMaxLength(30);
        }
    }

    public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.ToTable("CreditCard");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.CreditCardNumber).HasMaxLength(30);
            builder.HasOne(t => t.CreditCardBrand).WithMany();
            builder.Property(t => t.ExpMonth);
            builder.Property(t => t.ExpYear);
            builder.Property(t => t.SecurityCode);
            builder.Property(t => t.HolderName).HasMaxLength(30);
        }
    }

    public class CreditCardPaymentConfiguration : IEntityTypeConfiguration<CreditCardPayment>
    {
        public void Configure(EntityTypeBuilder<CreditCardPayment> builder)
        {
            builder.ToTable("CreditCardPayment");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.AmountInCents);
            builder.HasOne(t => t.CreditCard).WithMany();
            builder.HasOne(t => t.Acquirer).WithMany();
        }
    }

    public class AcquirerConfiguration : IEntityTypeConfiguration<Acquirer>
    {
        public void Configure(EntityTypeBuilder<Acquirer> builder)
        {
            builder.ToTable("Acquirer");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(30);
        }
    }

    public class AcquirerSaleConfiguration : IEntityTypeConfiguration<AcquirerSale>
    {
        public void Configure(EntityTypeBuilder<AcquirerSale> builder)
        {
            builder.ToTable("AcquirerSale");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.DateTime);
            builder.HasOne(t => t.Store).WithMany();
            builder.Property(t => t.AcquirerSuccess);
            builder.Property(t => t.AcquirerRawResponse);
            builder.HasMany(t => t.CreditCardPayments);

        }
    }

    public class StoreAcquirerConfiguration : IEntityTypeConfiguration<StoreAcquirer>
    {
        public void Configure(EntityTypeBuilder<StoreAcquirer> builder)
        {
            builder.ToTable("StoreAcquirer");
            builder.HasKey(t => t.Id);
            builder.HasOne(t => t.Store).WithMany();
            builder.HasOne(t => t.CreditCardBrand).WithMany(j => j.StoreAcquirer).HasForeignKey(j => j.IdCreditCardBrand);
            builder.HasOne(t => t.Acquirer).WithMany(j => j.StoreAcquirer).HasForeignKey(j => j.IdAcquirer);
            builder.HasOne(t => t.Store).WithMany(j => j.StoreAcquirer).HasForeignKey(j => j.IdStore);
        }
    }

}
