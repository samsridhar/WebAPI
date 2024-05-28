using WebAPI.Models.Domain;

namespace WebAPI.Repositories.Interface
{
    public interface IUser
    {
        Task<UserInfo> CreateAsync(UserInfo userInfo);

        Task<IEnumerable<UserInfo>> GetAllAsync();

        Task<UserInfo?> GetById(Guid id);

        Task<UserInfo?> UpdateAsync(UserInfo userInfo);

        Task<UserInfo?> DeleteAsync(Guid id);

    }
}
