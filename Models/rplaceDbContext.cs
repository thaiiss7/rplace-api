// using Microsoft.EntityFrameworkCore;

// namespace Rplace.Models;

// public class rplaceDbContext(DbContextOptions options) : DbContext(options)
// {
//     public DbSet<Profile> Profiles => Set<Profile>();
//     public DbSet<Room> Rooms => Set<Room>();
//     public DbSet<Pixel> Pixels => Set<Pixel>();
//     public DbSet<Invite> Invites => Set<Invite>();
//     public DbSet<Role> Roles => Set<Role>();
//     public DbSet<Plan> Plans => Set<Plan>();
//     public DbSet<GiftCard> GiftCards => Set<GiftCard>();
//     public DbSet<ItemRoom> itemRooms => Set<ItemRoom>();

//     protected override void OnModelCreating(ModelBuilder model)
//     {
//         model.Entity<Profile>();

//         model.Entity<Room>()
//             .HasOne(r => r.Owner)
//             .WithMany(p => p.Rooms)
//             .HasForeignKey(r => r.ProfileId)
//             .OnDelete(DeleteBehavior.NoAction);

//         model.Entity<Pixel>();

//         model.Entity<Invite>();

//         model.Entity<Role>();

//         model.Entity<Plan>();

//         model.Entity<GiftCard>();
//     }
// }