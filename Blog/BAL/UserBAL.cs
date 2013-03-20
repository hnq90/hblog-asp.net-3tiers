using System.Collections.Generic;
using DAL;
using Entities;

namespace BAL
{
    public class UserBAL
    {
        /*
         * CRUD Users
         */

        public static void CreateUser(User user)
        {
            UserDAL.CreateUser(user);
        }

        public static void EditUser(int id, User user)
        {
            UserDAL.EditUser(id, user);
        }

        public static void DeleteUser(int id)
        {
            UserDAL.DeleteUser(id);
        }

        public static List<User> ListUsers()
        {
            return UserDAL.ListUsers();
        }

        public static List<User> GetUserInfoById(int id)
        {
            return UserDAL._get_user_info_by_id(id);
        }

        public static int CountUser()
        {
            return UserDAL.CountUser();
        }
    }
}