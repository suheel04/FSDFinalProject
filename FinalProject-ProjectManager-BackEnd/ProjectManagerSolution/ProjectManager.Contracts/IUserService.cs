using ProjectManager.Entities;
using System.Collections.Generic;

namespace ProjectManager.Contracts
{
    public interface IUserService
    {
        IEnumerable<UserEntity> GetAllUsers();
        UserEntity GetUser(int userID);
        int AddUser(UserEntity userEntity);
        int UpdateUser(UserEntity userEntity);
        int DeleteTask(int ID);
    }
}
