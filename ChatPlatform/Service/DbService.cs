using ChatPlatform.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatPlatform.Service
{
    public class DbService :DbContext
    {
        public DbService(DbContextOptions<DbService> options):base(options)
        {

        }
        public DbSet<Chat> Chats { get; set; }
    }
}
