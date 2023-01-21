using ToDo.Domain.Entities;
// using ToDo.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using ToDo.Infra.Mappings;

namespace ToDo.Infra.Context;

public class ToDoContext : DbContext
{
    public ToDoContext(){}

    public ToDoContext(DbContextOptions<ToDoContext> options) : base(options){}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var myServerAddress = "TARDIS";
        var myDataBase = "usermanagerapi151";
        // var myUsername = @"TARDIS\mylle";
        // var myPassword = "5213";  
        
        // var str = @"Data Source=DESKTOP-652APCE\SQLEXPRESS;Initial Catalog=" + myDataBase + ";Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        var str = @"Data Source="+myServerAddress+
                  ";Initial Catalog="+myDataBase+ 
                  ";Integrated Security=True;"+
                  "Connect Timeout=30;"+
                  "Encrypt=False;"+
                  "TrustServerCertificate=False;"+
                  "ApplicationIntent=ReadWrite;"+
                  "MultiSubnetFailover=False";
        optionsBuilder.UseSqlServer(str);
    }
    public virtual DbSet<User> Users {  get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new UserMap());
    }
}