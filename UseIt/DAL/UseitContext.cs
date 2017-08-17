using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UseIt.Models;

namespace UseIt.DAL
{
    public class UseitContext:DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<UITask> Tasks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
    }
}