using WebAPI.Data;
using WebAPI.Models.Domain;
using WebAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Repositories.Implementation
{
    public class UserRepository : IUser
    {
        private readonly ApplicationDbContext dbContext;
        public UserRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<UserInfo> CreateAsync(UserInfo userInfo)
        {
            await dbContext.UserInformation.AddAsync(userInfo);
            await dbContext.SaveChangesAsync();

            return userInfo;
        }

        public async Task<IEnumerable<UserInfo>> GetAllAsync()
        {
            var users = dbContext.UserInformation.AsQueryable();

            return await users.ToListAsync();
        }

        public async Task<UserInfo?> DeleteAsync(Guid id)
        {
            var existingUser = await dbContext.UserInformation.FirstOrDefaultAsync(x => x.activeDirectoryUserId == id);

            if (existingUser is null)
            {
                return null;
            }

            dbContext.UserInformation.Remove(existingUser);
            await dbContext.SaveChangesAsync();
            return existingUser;
        }

        public async Task<UserInfo?> GetById(Guid id)
        {
            return await dbContext.UserInformation.FirstOrDefaultAsync(x => x.activeDirectoryUserId == id);
        }

        public async Task<UserInfo?> UpdateAsync(UserInfo userInfo)
        {
            var existingUser = await dbContext.UserInformation.FirstOrDefaultAsync(x => x.activeDirectoryUserId == userInfo.activeDirectoryUserId);

            if (existingUser != null)
            {
                dbContext.Entry(existingUser).CurrentValues.SetValues(userInfo);
                await dbContext.SaveChangesAsync();
                return userInfo;
            }

            return null;
        }
    }
}
