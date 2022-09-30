using GreenHouseEntityy.Concrete.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEv.Core.Concrete;
using YesilEv.Core.Context;
using YesilEv.DAL.Abstract;
using YesilEv.Entity.Concrete.DTO;

namespace YesilEv.DAL.Concrete
{
    public class UserDal : EFRepositoryBase<User, GreenHouse>, IUserDal
    {
        SingletonLoginInformations loginUserInformationSingleton = SingletonLoginInformations.LoginInformationWithSingleton;
        public LoginDTO Login(string mail, string pass)
        {
            LoginDTO loginList = null;

            using (GreenHouse db = new GreenHouse())
            {
                loginList = (from u in db.User
                             join ru in db.RoleUser on u.Id equals ru.UserId
                             join rl in db.Role on ru.RolId equals rl.Id
                             where u.Email == mail && u.Password == pass
                             select new LoginDTO
                             {
                                 Email = u.Email,
                                 Password = u.Password,
                                 Type = ru.RolId == 1 ? "Admin" : ru.RolId == 2 ? "Normal" : "Premium",
                                 KayıtTarihi = u.CreatedDate.ToString(),
                                 Id = u.Id,
                                 Name = u.Name,
                                 Surname = u.Surname,
                             }).SingleOrDefault();

            }
            if (loginList != null)
            {
                loginUserInformationSingleton.Email = loginList.Email;
                loginUserInformationSingleton.Password = loginList.Password;
                loginUserInformationSingleton.Type = loginList.Type;
                loginUserInformationSingleton.KayıtTarihi = loginList.KayıtTarihi;
                loginUserInformationSingleton.Id = loginList.Id;
                loginUserInformationSingleton.Name = loginList.Name;
                loginUserInformationSingleton.Surname = loginList.Surname;
            }
            return loginList;
        }
        public List<LoginDTO> GetAllUsers()
        {
            List<LoginDTO> userlist = null;
            using (GreenHouse db = new GreenHouse())
            {
                userlist = (from u in db.User
                            join ru in db.RoleUser on u.Id equals ru.UserId
                            join rl in db.Role on ru.RolId equals rl.Id
                            select new LoginDTO
                            {
                                Email = u.Email,
                                Password = u.Password,
                                Type = ru.RolId == 1 ? "Admin" : ru.RolId == 2 ? "Normal" : "Premium",
                                KayıtTarihi = u.CreatedDate.ToString(),
                                Id = u.Id,
                                Name = u.Name,
                                Surname = u.Surname,
                            }).ToList();

            }
            return userlist;
        }
        public bool UpdateMail(string mail)
        {
            using (GreenHouse db = new GreenHouse())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var user = db.User.Where(w => w.Id == loginUserInformationSingleton.Id).FirstOrDefault();
                        user.Email = mail;
                        db.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        transaction.Rollback();
                        return false;
                    }
                }

            }
        }
        public bool UpdatePassword(string pass)
        {
            using (GreenHouse db = new GreenHouse())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var user = db.User.Where(w => w.Id == loginUserInformationSingleton.Id).FirstOrDefault();
                        user.Password = pass;
                        db.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        transaction.Rollback();
                        return false;
                    }
                }

            }
        }

        public bool Register(string name, string surname, string email, string password, string socialMedia)
        {
            /*
            RegisterDTO register = new RegisterDTO();
            register.Name = name;
            register.Surname = surname;
            register.Email = email;
            register.Password = password;
            register.SocialMediaAcc = socialMedia;
            register.isActive = true;
            register.CreatedBy = 1;
            register.ModifiedBy = 1;
            using (GreenHouse db = new GreenHouse())
            {
                db.User.Add(new User()
                {
                    Name = register.Name = name,
                    Surname = register.Surname = surname,
                    Email = register.Email = email,
                    Password = register.Password = password,
                    SocialMedia = register.SocialMediaAcc = socialMedia,
                    isActive = register.isActive,
                    CreatedDate = register.CreatedDate,
                    ModifiedDate = register.ModifiedDate,
                    CreatedBy = register.CreatedBy,
                    ModifiedBy = register.ModifiedBy

                });

                db.SaveChanges();
            
            }
            */
            using (GreenHouse db = new GreenHouse())
            {

                UserDal udal = new UserDal();
                User u = new User();
                u.Name = name;
                u.Surname = surname;
                u.Email = email;
                u.Password = password;
                u.SocialMedia = socialMedia;
                u.isActive = true;
                u.CreatedDate = DateTime.Now;
                u.ModifiedDate = DateTime.Now;
                u.CreatedBy = u.Id;
                u.ModifiedBy = u.Id;

                using (var transaction = db.Database.BeginTransaction())
                {
                    /*  var CheckingWhetherTheRegisteredEMailAndOtherUsersEMailsMatch = (from user in db.User
                                                                                       where user.Email == email
                                                                                       select user).Any();*/
                    try
                    {
                        u.RoleUser.Add(new RoleUser()
                        {
                            RolId = 2,
                            UserId = u.Id,
                            CreatedBy = u.Id,
                            ModifiedBy = u.Id,
                            ModifiedDate = DateTime.Now,
                            CreatedDate = DateTime.Now,
                            isActive = true,
                        }); ;
                        db.User.Add(u);
                        db.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception )
                    {
                        //Console.WriteLine(e.Message);
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }
        public void cleanerForSearchHistory(int userId)
        {
            using (GreenHouse db = new GreenHouse())
            {
                var deleteHistory = (from i in db.SearchHistory
                                     where i.UserId == userId
                                     select i).ToList();
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var history in deleteHistory)
                        {
                            db.SearchHistory.Remove(history);
                        }
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        transaction.Rollback();
                    }
                }
            }

        }

        public bool UpdateNameAndSurname(string request, string updateText)
        {
            using (GreenHouse db = new GreenHouse())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        if (updateText != "")
                        {
                            if (request == "Name")
                            {
                                var user = db.User.Where(w => w.Id == loginUserInformationSingleton.Id).FirstOrDefault();
                                user.Name = updateText;
                            }
                            else
                            {
                                var user = db.User.Where(w => w.Id == loginUserInformationSingleton.Id).FirstOrDefault();
                                user.Surname = updateText;
                            }
                            db.SaveChanges();
                            transaction.Commit();
                        }
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        transaction.Rollback();
                        return false;
                    }
                }

            }
        }

        public List<FavoriteOrBlockListDTO> ListBlockOrFavorited(int situationId)
        {
            List<FavoriteOrBlockListDTO> favoriteList = null;
            using (GreenHouse db = new GreenHouse())
            {
                favoriteList = (from up in db.UserProcess
                                join
                                product in db.Product on up.ProductId equals product.Id
                                where up.SituationId == situationId
                                where up.UserId == loginUserInformationSingleton.Id
                                select new FavoriteOrBlockListDTO()
                                {
                                    BarCode = product.BarkodNo,
                                    productName = product.Name
                                }).ToList();

            }
            return favoriteList;
        }


        public List<SearchHistroyList> ListSearchHistory(int userId)
        {//select p.Name, sh.CreatedDate, u.Name from SearchHistory sh join [user] u on sh.UserId = u.Id join Product p on sh.ProductId = p.Id where sh.UserId = 3
            using (GreenHouse db = new GreenHouse())
            {
                var searchHistroyList = (from sh in db.SearchHistory
                                         join u in db.User on sh.UserId equals u.Id
                                         join p in db.Product on sh.ProductId equals p.Id
                                         where sh.UserId == userId
                                         select new SearchHistroyList()
                                         {
                                             Name = u.Name,
                                             productName = p.Name,
                                             CreatedDate = sh.CreatedDate

                                         }).ToList();
                return searchHistroyList;
            }
        }
        /*
    public void GetUserTableInfo(int id)
    {
       List<UserPageDTO> userTableList = new List<UserPageDTO>();
       UserPageDTO userTable = new UserPageDTO();
       using (GreenHouse entity = new GreenHouse())
       {
           var user = (from User in entity.User
                       where User.Id == id
                       select User).ToList();
           foreach(var i in user)
           {
               userTable.Email = i.Email;
               userTable.Id = i.Id;
               userTable.Password = i.Password;

           }
       }

    }*/
        public List<UpdateRoleDTO> getNormalAndPremiumUser(string request)
        {
            List<UpdateRoleDTO> updateUserRole = null;
            using (GreenHouse entity = new GreenHouse())
            {
                updateUserRole = (from u in entity.User
                                  join ru in entity.RoleUser on
                                  u.Id equals ru.UserId
                                  join role
                                  in entity.Role on ru.RolId equals role.Id
                                  where role.RoleName == request
                                  select new UpdateRoleDTO()
                                  {
                                      Name = u.Name
                                  }).ToList();
            }
            return updateUserRole;
        }

        public bool updateUserRole(string username, int roleType)
        {
            SingletonLoginInformations loginUser = SingletonLoginInformations.LoginInformationWithSingleton;
            using (GreenHouse entity = new GreenHouse())
            {
                using (var transaction = entity.Database.BeginTransaction())
                {
                    try
                    {
                        var updateRole = (from u in entity.User
                                          join ru in entity.RoleUser on
                                          u.Id equals ru.UserId
                                          join
                                          rol in entity.Role on ru.RolId equals
                                          rol.Id
                                          where u.Name == username
                                          select new { ru }).SingleOrDefault(); //      select new {rol}).SingleOrDefault();
                        updateRole.ru.RolId = roleType;
                        updateRole.ru.ModifiedDate = DateTime.Now;
                        updateRole.ru.ModifiedBy = loginUser.Id;
                        entity.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        transaction.Rollback();
                        return false;
                    }
                }


            }
        }
        public bool addProductFavoriteorBlockList(int productId, int request)
        {//Select * from UserProcess where ProductId = 2039 and SituationId = 1
            using (GreenHouse entity = new GreenHouse())
            {
                using (var transaction = entity.Database.BeginTransaction())
                {
                    try //   Type = ru.RolId == 1 ? "Admin" : ru.RolId == 2 ? "Normal" : "Premium",
                    {
                        int a = 0;
                        if (request == 1)
                            a = 2;
                        else
                            a = 1;
                        var dahaÖncedenAynıÜrünBlockYadaFavoriListeyeEklendiyseKontrolü = (from up in entity.UserProcess
                                                                                           where up.ProductId == productId && up.UserId == loginUserInformationSingleton.Id
                                                                                           && (up.SituationId == a || up.SituationId == request)
                                                                                           select up).Any();
                        if (!dahaÖncedenAynıÜrünBlockYadaFavoriListeyeEklendiyseKontrolü)
                        {
                            UserProcess addProductFavoriteOrBlockList = new UserProcess();
                            addProductFavoriteOrBlockList.UserId = loginUserInformationSingleton.Id;
                            addProductFavoriteOrBlockList.ProductId = productId;
                            addProductFavoriteOrBlockList.SituationId = request;
                            addProductFavoriteOrBlockList.isActive = true;
                            addProductFavoriteOrBlockList.CreatedDate = DateTime.Now;
                            addProductFavoriteOrBlockList.ModifiedDate = DateTime.Now;
                            addProductFavoriteOrBlockList.CreatedBy = loginUserInformationSingleton.Id;
                            addProductFavoriteOrBlockList.ModifiedBy = loginUserInformationSingleton.Id;
                            entity.UserProcess.Add(addProductFavoriteOrBlockList);
                            entity.SaveChanges();
                            transaction.Commit();
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

    }
}