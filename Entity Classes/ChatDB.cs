using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity_Classes
{
    public class ChatDB : DbContext
    {
        public ChatDB()
        {
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=DESKTOP-67V0U0H;initial catalog=ChatDBcontext;integrated security=True");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<UserToGroup> UsersToGroups { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Sender> Senders { get; set; }
        public DbSet<Receiver> Receivers { get; set; }
    }
    public class ProductImage
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
    }
    public class User
    {
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Username { get; set; }
        [Required, MaxLength(200)]
        public string Email { get; set; }
        [Required, MaxLength(200)]
        public string Hash { get; set; }
        public ProductImage ProfilePic { get; set; }
        [Required]
        public ICollection<UserToGroup> UsersToGroups { get; set; }

    }
    public class Group
    {
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Name { get; set; }
        public ProductImage GroupPic { get; set; }
        [Required]
        public ICollection<UserToGroup> UsersToGroups { get; set; }
        [Required]
        public ICollection<Message> Messages { get; set; }

    }
    public class UserToGroup
    {
        public int Id { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public Group Group { get; set; }
    }
    public class Message
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public Receiver Receiver { get; set; }
        [Required]
        public Sender Sender { get; set; }
        [Required]
        public DateTime DateTimeOfSend { get; set; }
        public Group Group { get; set; }

    }
    public class Sender
    {
        public int Id { get; set; }
        [Required]
        public ICollection<Message> Messages { get; set; }

    }
    public class Receiver
    {
        public int Id { get; set; }
        [Required]
        public ICollection<Message> Messages { get; set; }

    }
}
