using Microsoft.EntityFrameworkCore;
using Xome.Cascade2.CamundaService.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Xome.Cascade2.CamundaService.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ManualTask> ManualTasks => Set<ManualTask>();

        public DbSet<TaskFields> TaskFields => Set<TaskFields>();

        public DbSet<UserTaskFieldMapping> UserTaskFieldMappings => Set<UserTaskFieldMapping>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            modelBuilder.Entity<ManualTask>().HasData(
                new ManualTask { Id = 1, TaskId = 1, TaskName = "MarketingRequestTask" },
                new ManualTask { Id = 2, TaskId = 2, TaskName = "LoadValuationTask" }
            );
            modelBuilder.Entity<TaskFields>().HasData(
                new TaskFields { Id = 1 , TaskId = 1, TaskMappingFields = ["valuationEffectiveDate", "valuationType", "valuationExpires", "inspectionType", "preparedBy", "company", "asIsValue", "repairedValue", "repairedEstimate", "condition", "comments"] },
                new TaskFields { Id = 2, TaskId = 2, TaskMappingFields = ["address1", "address2", "valuationExpires", "city", "state", "zipCode", "county", "apn", "bpoValue", "transactionSubType", "sellerCode", "sellerSubCode", "propertyType", "bedRooms", "fullBathrooms", "partialBathrooms", "emv"] }
            );
            modelBuilder.Entity<UserTaskFieldMapping>().HasData(
                new UserTaskFieldMapping { Id = 1, UserId = 4, TaskId = 1, AccessTaskFields = ["valuationEffectiveDate", "valuationType", "valuationExpires", "inspectionType", "preparedBy", "company", "asIsValue", "repairedValue", "repairedEstimate", "condition", "comments"] },
                new UserTaskFieldMapping { Id = 2, UserId = 4, TaskId = 2, AccessTaskFields = [""] }
            );
        }


    }
}
