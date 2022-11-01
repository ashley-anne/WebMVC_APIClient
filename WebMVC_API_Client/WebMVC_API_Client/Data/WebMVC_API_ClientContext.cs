using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebMVC_API_Client.Models;

namespace WebMVC_API_Client.Data
{
    public class WebMVC_API_ClientContext : DbContext
    {
        public WebMVC_API_ClientContext (DbContextOptions<WebMVC_API_ClientContext> options)
            : base(options)
        {
        }

        public DbSet<WebMVC_API_Client.Models.Player> Player { get; set; } = default!;
    }
}
