using Microsoft.EntityFrameworkCore;
using RoomRentalManagement.Application.Common.Interfaces;
using RoomRentalManagement.Domain.Entities;

namespace RoomRentalManagement.Infrastructure.Persistence
{
    public class ApplicationDBContext : DbContext, IUnitOfWork
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        Task<int> IUnitOfWork.SaveChangesAsync() => SaveChangesAsync();

        public DbSet<Contract> Contracts { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }

        public DbSet<Picture> Pictures { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<ServiceDetail> ServiceDetails { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contract>(entity =>
            {
                entity.ToTable("Contract");

                entity.HasIndex(e => e.CustomerId, "IX_Contract_customer_id");

                entity.HasIndex(e => e.RoomId, "IX_Contract_room_id");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("(newid())")
                    .HasColumnName("id");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("(sysutcdatetime())")
                    .HasColumnName("created_at");
                entity.Property(e => e.CustomerId).HasColumnName("customer_id");
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
                entity.Property(e => e.Deposit)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("deposit");
                entity.Property(e => e.EndDate).HasColumnName("end_date");
                entity.Property(e => e.MonthlyRent)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("monthly_rent");
                entity.Property(e => e.RoomId).HasColumnName("room_id");
                entity.Property(e => e.StartDate).HasColumnName("start_date");
                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .HasColumnName("status");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.HasOne(d => d.Customer).WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contract_Customer");

                entity.HasOne(d => d.Room).WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contract_Room");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice");

                entity.HasIndex(e => e.ContractId, "IX_Invoice_contract_id");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("(newid())")
                    .HasColumnName("id");
                entity.Property(e => e.ContractId).HasColumnName("contract_id");
                entity.Property(e => e.DueDate).HasColumnName("due_date");
                entity.Property(e => e.Month).HasColumnName("month");
                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .HasColumnName("status");
                entity.Property(e => e.TotalAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("total_amount");
                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.Contract).WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.ContractId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoice_Contract");
            });

            modelBuilder.Entity<InvoiceDetail>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_InvoiceDetails");

                entity.ToTable("Invoice_Details");

                entity.HasIndex(e => e.InvoiceId, "IX_InvoiceDetails_invoice_id");

                entity.HasIndex(e => e.ServiceId, "IX_InvoiceDetails_service_id");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("(newid())")
                    .HasColumnName("id");
                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("amount");
                entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");
                entity.Property(e => e.Quantity)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("quantity");
                entity.Property(e => e.ServiceId).HasColumnName("service_id");
                entity.Property(e => e.UnitPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("unit_price");

                entity.HasOne(d => d.Invoice).WithMany(p => p.InvoiceDetails)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceDetails_Invoice");

                entity.HasOne(d => d.Service).WithMany(p => p.InvoiceDetails)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceDetails_Service");
            });

            modelBuilder.Entity<Picture>(entity =>
            {
                entity.ToTable("Picture");

                entity.HasIndex(e => e.RoomId, "IX_Picture_room_id");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("(newid())")
                    .HasColumnName("id");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("(sysutcdatetime())")
                    .HasColumnName("created_at");
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
                entity.Property(e => e.RoomId).HasColumnName("room_id");
                entity.Property(e => e.Tag)
                    .HasMaxLength(100)
                    .HasColumnName("tag");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.Property(e => e.Url)
                    .HasMaxLength(500)
                    .HasColumnName("url");

                entity.HasOne(d => d.Room).WithMany(p => p.Pictures)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Picture_Room");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.HasIndex(e => e.RoomNumber, "UQ_Room_roomNumber").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("(newid())")
                    .HasColumnName("id");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("(sysutcdatetime())")
                    .HasColumnName("created_at");
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
                entity.Property(e => e.MaxOccupants).HasColumnName("max_occupants");
                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("price");
                entity.Property(e => e.RoomNumber)
                    .HasMaxLength(20)
                    .HasColumnName("room_number");
                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .HasColumnName("status");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("(newid())")
                    .HasColumnName("id");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("(sysutcdatetime())")
                    .HasColumnName("created_at");
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
                entity.Property(e => e.Unit)
                    .HasMaxLength(20)
                    .HasColumnName("unit");
                entity.Property(e => e.UnitPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("unit_price");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<ServiceDetail>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_ServiceDetails");

                entity.ToTable("Service_Details");

                entity.HasIndex(e => e.RoomId, "IX_ServiceDetails_room_id");

                entity.HasIndex(e => e.ServiceId, "IX_ServiceDetails_service_id");

                entity.HasIndex(e => new { e.RoomId, e.ServiceId, e.Month }, "UQ_ServiceDetails_Room_Service_Month").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("(newid())")
                    .HasColumnName("id");
                entity.Property(e => e.Month)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("month");
                entity.Property(e => e.NewIndex)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("new_index");
                entity.Property(e => e.OldIndex)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("old_index");
                entity.Property(e => e.RoomId).HasColumnName("room_id");
                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.HasOne(d => d.Room).WithMany(p => p.ServiceDetails)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceDetails_Room");

                entity.HasOne(d => d.Service).WithMany(p => p.ServiceDetails)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceDetails_Service");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.Email, "UQ_User_email").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("(newid())")
                    .HasColumnName("id");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("(sysutcdatetime())")
                    .HasColumnName("created_at");
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");
                entity.Property(e => e.FullName)
                    .HasMaxLength(150)
                    .HasColumnName("fullName");
                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");
                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .HasColumnName("phone");
                entity.Property(e => e.Role)
                    .HasMaxLength(20)
                    .HasColumnName("role");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });
        }
    }
}
