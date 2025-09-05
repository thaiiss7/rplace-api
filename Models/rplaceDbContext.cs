using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Rplace.Models;

public class rplaceDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Profile> Profiles => Set<Profile>();
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<Pixel> Pixels => Set<Pixel>();
    public DbSet<Invite> Invites => Set<Invite>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Plan> Plans => Set<Plan>();
    public DbSet<GiftCard> GiftCards => Set<GiftCard>();
    public DbSet<ItemRoom> ItemRooms => Set<ItemRoom>();

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Profile>()
            .HasOne(p => p.Plan)
            .WithMany(p => p.Profiles)
            .HasForeignKey(p => p.PlanId)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<Profile>()
            .HasOne(p => p.ItemRoom)
            .WithMany(p => p.Members)
            .HasForeignKey(p => p.ItemRoomId)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<Room>()
            .HasOne(r => r.ItemRoom)
            .WithOne(r => r.Room)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<Room>()
            .HasOne(r => r.Owner)
            .WithMany(p => p.Rooms)
            .HasForeignKey(r => r.ProfileId)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<Pixel>()
            .HasOne(p => p.PixelRoom)
            .WithMany(p => p.Pixels)
            .HasForeignKey(p => p.RoomId)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<Invite>()
            .HasOne(i => i.InviteRoom)
            .WithMany(i => i.Invites)
            .HasForeignKey(i => i.RoomId)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<Invite>()
            .HasOne(i => i.Receiver)
            .WithMany(i => i.Invites)
            .HasForeignKey(i => i.Receiverid)
            .OnDelete(DeleteBehavior.NoAction);

        // model.Entity<Invite>()
        //     .HasOne(i => i.Sender)
        //     .WithMany(i => i.Invites)
        //     .HasForeignKey(i => i.SenderId)
        //     .OnDelete(DeleteBehavior.NoAction);

        model.Entity<Role>()
            .HasOne(r => r.ItemRoom)
            .WithMany(r => r.Roles)
            .HasForeignKey(r => r.RoomId)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<Plan>();

        model.Entity<GiftCard>()
            .HasOne(p => p.PlanGiftCard)
            .WithMany(p => p.GiftCards)
            .HasForeignKey(p => p.PlanId)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<ItemRoom>();
    }
}

public class rplaceDbContextFactory : IDesignTimeDbContextFactory<rplaceDbContext>
{
    public rplaceDbContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<rplaceDbContext>();
        var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
        options.UseSqlServer(sqlConn);
        return new rplaceDbContext(options.Options);
    }
}