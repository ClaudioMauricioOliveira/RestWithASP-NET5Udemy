using RestWithASPNET5Udemy.Data.VO;
using RestWithASPNET5Udemy.Model;

namespace RestWithASPNET5Udemy.Repository
{
    public interface IUserRepository
    {
        User ValidateCreditials(UserVO user);
        User ValidateCreditials(string userName);
        bool RevokeToken(string userName);

        User RefreshUserInfo(User user);
    }
}
