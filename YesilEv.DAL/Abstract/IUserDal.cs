using GreenHouseEntityy.Concrete.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEv.Core.Abstract;
using YesilEv.Core.Context;
using YesilEv.Entity.Concrete.DTO;

namespace YesilEv.DAL.Abstract
{
    public interface IUserDal:ISelectableRepository<User>, IDeletableRepository<User>, IInsertableRepository<User>, IUpdateRepository<User>
    {
        LoginDTO Login(string mail, string pass);
        bool UpdateMail(string mail);
        bool UpdatePassword(string pass);
        bool Register(string name, string surname, string email, string password, string socialMedia);
        void cleanerForSearchHistory(int userId);
        bool UpdateNameAndSurname(string request, string updateText);
        List<FavoriteOrBlockListDTO> ListBlockOrFavorited(int situationId);
        List<SearchHistroyList> ListSearchHistory(int userId);
        List<LoginDTO> GetAllUsers();
        List<UpdateRoleDTO> getNormalAndPremiumUser(string request);
        bool updateUserRole(string username, int roleType);
        bool addProductFavoriteorBlockList(int productId, int request);
    }
}
