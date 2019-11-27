using RuleTool.Models;
using Microsoft.EntityFrameworkCore;

namespace RuleTool.Data
{
    public class RuleToolContext : DbContext
    {
        public RuleToolContext (DbContextOptions<RuleToolContext>options) 
            : base(options)
        {
        }

        public DbSet<Rule> Rule { get; set; }
    }
}
