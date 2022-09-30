using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEv.Core.Context;
using YesilEv.DAL.Abstract;
using YesilEv.Entity.Concrete.DTO;

namespace YesilEv.DAL.Concrete
{
    public class ReportDal : IReportDal
    {
        public List<MostAllergenProductDTO> mostAllergenicProducts()
        {
            List<MostAllergenProductDTO> MostAllergenProduct = null;
            using (GreenHouse entity = new GreenHouse())
            {

                /*
         
Select p.[Name], s.[Name],s.[RisktType] from ProductContent pc join Product p on p.Id = pc.ProductId join Substance s on pc.SubstanceId = s.Id 
where s.RisktType = 'Yüksek'

                 */
                MostAllergenProduct = (from pc in entity.ProductContent
                                       join p in entity.Product on pc.ProductId equals p.Id
                                       join s in entity.Substance on pc.SubstanceId equals s.Id
                                       where s.RisktType == "Yüksek"
                                       select new MostAllergenProductDTO()
                                       {
                                           ProductName = p.Name,
                                           RiskType = s.RisktType,
                                           SubstanceName = s.Name
                                       }).ToList();
            }
            return MostAllergenProduct;
        }

        public List<EthanolFavoriteOrBlockDTO> EthanolFavoriteOrBlock() //kullanıcıların etanol maddesi içeren ürünü favoriyemi attığı ya da block listesinemi attığı raporu
        {/*
            Select u.[Name], p.[Name], sub.[Name], sit.Situation from UserProcess up join [User] u on up.UserId = u.Id join Situation sit on sit.Id = up.SituationId
            join Product p on p.Id = up.ProductId join ProductContent pc on pc.ProductId = p.Id join Substance sub on sub.Id = pc.SubstanceId
            where sub.Id = 3 and (sit.Id = 1 or sit.Id = 2)*/
            List<EthanolFavoriteOrBlockDTO> EthanolFavoriteOrBlock = null;
            using (GreenHouse entity = new GreenHouse())
            {
                EthanolFavoriteOrBlock = (from up in entity.UserProcess
                                          join u in entity.User on up.UserId equals u.Id
                                          join sit in entity.Situation on up.SituationId equals sit.Id
                                          join p in entity.Product on up.ProductId equals p.Id
                                          join pc in entity.ProductContent on p.Id equals pc.ProductId
                                          join sub in entity.Substance on pc.SubstanceId equals sub.Id
                                          where sub.Id == 3 && (sit.Id == 1 || sit.Id == 2)

                                          select new EthanolFavoriteOrBlockDTO()
                                          {
                                              Username = u.Name,
                                              ProductName = p.Name,
                                              SubstanceName = sub.Name,
                                              SituationType = sit.Situation1
                                          }).ToList();
            }
            return EthanolFavoriteOrBlock;

        }

        public List<MostFavoriteProducts> MostFavoriteProducts()
        {/*

            Select Count(up.SituationId) as [Favorilenme Sayısı], p.Name from UserProcess up join Product p on up.ProductId = p.Id join Situation s on up.SituationId = s.Id 
            where s.Id = 2
            group by p.Name
            order by Count(up.SituationId) desc*/

            List<MostFavoriteProducts> MostFavoriteProducts = null;
            using (GreenHouse entity = new GreenHouse())
            {
                MostFavoriteProducts = (from up in entity.UserProcess
                                        join p in entity.Product on up.ProductId equals p.Id
                                        where up.SituationId == 2

                                        group p by p.Name into pGP

                                        select new MostFavoriteProducts()
                                        {
                                            ProductName = pGP.Key,
                                            ProductFavoriteCount = pGP.Count()
                                        }).ToList();

            }
            var orderByDescLinq = MostFavoriteProducts.OrderByDescending(x => x.ProductFavoriteCount).ToList(); //aggregate functiona göre bir sıralama yapılcagından lambda ile
            return orderByDescLinq;
        }

        public List<BuAyKaraListeVeFavoriyeAlınanUrunlerDTO> BlacklistAndFavoritedProductsThisMonth()
        {
            List<BuAyKaraListeVeFavoriyeAlınanUrunlerDTO> BuAyKaraListeVeFavoriyeAlınanUrunler = null;
            using (GreenHouse entity = new GreenHouse())
            {
                BuAyKaraListeVeFavoriyeAlınanUrunler = (from up in entity.UserProcess
                                                        join u in entity.User on up.UserId equals u.Id
                                                        join sit in entity.Situation on up.SituationId equals sit.Id
                                                        join p in entity.Product on up.ProductId equals p.Id
                                                        //join pc in entity.ProductContent on p.Id equals pc.ProductId kullanılmadıgı için veri tekrarını sebebiyet veriyordu 
                                                        where (sit.Id == 1 || sit.Id == 2) && up.CreatedDate.Value.Month == DateTime.Now.Month
                                                        select new BuAyKaraListeVeFavoriyeAlınanUrunlerDTO()
                                                        {
                                                            Username = u.Name,
                                                            ProductName = p.Name,
                                                            Date = up.CreatedDate,
                                                            SituationType = sit.Situation1
                                                        }).ToList();
            }
            return BuAyKaraListeVeFavoriyeAlınanUrunler;
        }

        public List<KiminKacFavoriBlockUrunuDTO> WhoHasHowManyFavoriteBlockItems()
        {/*
select Count(up.SituationId),p.Name from UserProcess up join Product p on up.ProductId = p.Id 
where up.SituationId = 2 group by p.Name order by Count(up.SituationId) Desc*/
            List<KiminKacFavoriBlockUrunuDTO> KiminKacFavoriBlockUrunu = null;
            using (GreenHouse entity = new GreenHouse())
            {
                KiminKacFavoriBlockUrunu = (from up in entity.UserProcess
                                            join p in entity.Product on up.ProductId equals p.Id
                                            join u in entity.User on up.UserId equals u.Id
                                            where up.SituationId == 2 || up.SituationId == 1
                                            orderby up.SituationId descending
                                            group u by u.Name into pGP

                                            select new KiminKacFavoriBlockUrunuDTO()
                                            {
                                                name = (pGP.Key).ToString(),
                                                favoriteOrBlockCount = pGP.Count()


                                            }).ToList();
            }
            return KiminKacFavoriBlockUrunu;
        }
        //------------------- aşağısı bugün
        public List<HowManySubstanceDoesEachProductHaveDTO> HowManySubstanceDoesEachProductHave()
        {//Select COUNT(pc.SubstanceId) as [Madde Sayısı], p.Name from Product p join ProductContent pc on p.Id = pc.ProductId group by p.Name
            List<HowManySubstanceDoesEachProductHaveDTO> HowManySubstanceDoesEachProductHave = null;
            using (GreenHouse entity = new GreenHouse())
            {
                HowManySubstanceDoesEachProductHave = (from pro in entity.Product
                                                       join
                                                      pc in entity.ProductContent on pro.Id equals pc.ProductId
                                                       where pro.Name != null && pc.SubstanceId != null
                                                       group pro by pro.Name into p
                                                       orderby p.Count()  //ya da orderby p.Key     p.Key = pro.Name dir
                                                       select new HowManySubstanceDoesEachProductHaveDTO
                                                       {
                                                           ProductName = p.Key, //p group by ın ismidir. Key ise group pro by pro.Name kısmında pro.Name dir.
                                                           SubstanceCount = p.Count()//aggregate function ı kullanıp dto daki proeprty e atadık
                                                       }).ToList();

            }
            return HowManySubstanceDoesEachProductHave;
        }
        /*
         key e birden fazla veri vermek istenirse  aşağıdaki gibi 

         var results = 
                    from d in db.TBLDESIGNER
                    join s in db.TBLDESIGN on d.ID equals s.TBLDESIGNER.ID
                    where s.COMPLETED && d.ACTIVE
                    let value = new { s, d}
                    let key = new { d.ID, d.FIRST_NAME, d.LAST_NAME }
                    group value by key into g
                    orderby g.Key.FIRST_NAME ascending, g.Key.LAST_NAME ascending

                    select new
                    {
                        ID = g.Key.ID,
                        FirstName = g.Key.FIRST_NAME,
                        LastName = g.Key.LAST_NAME,
                        Count = g.Count()
                    };
         */

        public List<ListofProductsThatHaveEthanolDTO> ListofProductsThatHaveEthanol()
        {//select p.Name from ProductContent pc join Product p on pc.ProductId = p.Id join Substance s on s.Id = pc.SubstanceId where s.Id = 3
            List<ListofProductsThatHaveEthanolDTO> ListofProductsThatHaveEthanol = null;
            using (GreenHouse entity = new GreenHouse())
            {
                ListofProductsThatHaveEthanol = (from pc in entity.ProductContent
                                                 join
                                                 p in entity.Product on pc.ProductId equals p.Id
                                                 join s in entity.Substance on pc.SubstanceId equals s.Id
                                                 where s.Id == 3 //tablomuzda id si 3 olan ethanol dur
                                                 select new ListofProductsThatHaveEthanolDTO
                                                 {
                                                     ProductName = p.Name
                                                 }).ToList();
            }
            return ListofProductsThatHaveEthanol;
        }

        public List<NumberOfProductsNotApprovedByAdminThisMonthDTO> NumberOfProductsNotApprovedByAdminThisMonth() // isactive durumu null veya false ise onaylanmadı olarak 
        {
            List<NumberOfProductsNotApprovedByAdminThisMonthDTO> NumberOfProductsNotApprovedByAdminThisMonth = null;
            using (GreenHouse entity = new GreenHouse())
            {
                NumberOfProductsNotApprovedByAdminThisMonth = (from p in entity.Product
                                                               where (p.isActive == null || p.isActive == false) && p.CreatedDate.Value.Month == DateTime.Now.Month && p.Name != null
                                                               select new NumberOfProductsNotApprovedByAdminThisMonthDTO
                                                               {
                                                                   ProductName = p.Name,
                                                                   CreatedDate = p.CreatedDate,
                                                                   Situation = p.isActive
                                                               }).ToList();
            }
            return NumberOfProductsNotApprovedByAdminThisMonth;
        }

        public List<HowManyTimesHastheProductContainingEthanol_BeenAddedToTheFavoriteList_SameForBlockDTO> HowManyTimesHastheProductContainingEthanol_BeenAddedToTheFavoriteList_SameForBlock()
        {
            /*
            select sub.[Name] as [Madde İsmi], Count(s.Id) as [Toplam Madde], s.Situation as [Durum] from UserProcess up 
            join [User] u on up.UserId = u.Id 
            join Product p on up.ProductId = p.Id
            join Situation s on up.SituationId = s.Id
            join ProductContent pc on pc.ProductId = p.Id
            join Substance sub on pc.SubstanceId = sub.Id
            where sub.Name = 'Etanol' and (s.Id= 1 or s.Id = 2)  
            group by sub.[Name], s.Situation 
             */
            List<HowManyTimesHastheProductContainingEthanol_BeenAddedToTheFavoriteList_SameForBlockDTO> HowManyTimesHastheProductContainingEthanol_BeenAddedToTheFavoriteList_SameForBlock = null;
            using (GreenHouse entity = new GreenHouse())
            {
                HowManyTimesHastheProductContainingEthanol_BeenAddedToTheFavoriteList_SameForBlock = (from up in entity.UserProcess
                                                                                                      join
                                                                                                     u in entity.User on up.UserId equals u.Id
                                                                                                      join p in entity.Product on up.ProductId equals p.Id
                                                                                                      join s in entity.Situation on up.SituationId equals s.Id
                                                                                                      join pc in entity.ProductContent on p.Id equals pc.ProductId
                                                                                                      join sub in entity.Substance on pc.SubstanceId equals sub.Id
                                                                                                      where sub.Name == "Etanol" && (s.Id == 1 || s.Id == 2)
                                                                                                      let value = new { s, sub }
                                                                                                      let key = new { sub.Name, s.Situation1 }
                                                                                                      group value by key into g
                                                                                                      select new HowManyTimesHastheProductContainingEthanol_BeenAddedToTheFavoriteList_SameForBlockDTO
                                                                                                      {
                                                                                                          Substance = g.Key.Name,
                                                                                                          Situation = g.Key.Situation1,
                                                                                                          Quantity = g.Count()
                                                                                                      }).ToList();
            }
            return HowManyTimesHastheProductContainingEthanol_BeenAddedToTheFavoriteList_SameForBlock;
        }


        public List<MostFavoriteProducts> MostFavoriteProductsTOP3()
        {/*
            Select TOP 3 Count(up.SituationId) as [Favorilenme Sayısı], p.Name from UserProcess up join Product p on up.ProductId = p.Id join Situation s on up.SituationId = s.Id 
            where s.Id = 2
            group by p.Name
            order by Count(up.SituationId) desc*/

            List<MostFavoriteProducts> MostFavoriteProducts = null;
            using (GreenHouse entity = new GreenHouse())
            {
                MostFavoriteProducts = (from up in entity.UserProcess
                                        join p in entity.Product on up.ProductId equals p.Id
                                        where up.SituationId == 2
                                        group p by p.Name into pGP
                                        select new MostFavoriteProducts()
                                        {
                                            ProductName = pGP.Key,
                                            ProductFavoriteCount = pGP.Count()
                                        }).ToList();

            }
            var orderByDescLinq = MostFavoriteProducts.OrderByDescending(x => x.ProductFavoriteCount).Take(3).ToList();
            return orderByDescLinq;
        }

        public List<UserProductEntryDTO> Top5UsersWithTheMostProductEntries()
        {//Select Count(p.CreatedBy), u.Name, u.Email from [User] u join Product p on u.Id = p.CreatedBy group by u.Name, u.Email order by Count(p.CreatedBy) desc
            List<UserProductEntryDTO> userProductEntry = null;
            using (GreenHouse entity = new GreenHouse())
            {
                userProductEntry = (from u in entity.User
                                    join p in entity.Product
                                    on u.Id equals p.CreatedBy
                                    let value = new { p, u }
                                    let key = new { u.Name, u.Email }
                                    group value by key into g
                                    orderby g.Count() descending
                                    select new UserProductEntryDTO()
                                    {
                                        Username = g.Key.Name,
                                        Email = g.Key.Email,
                                        Quantity = g.Count()

                                    }).ToList();

            }
            var orderDescending = userProductEntry.OrderByDescending(x => x.Quantity).Take(5).ToList();
            return orderDescending;
        }

        public List<ProductsWithTheMostItemsBySubstanceCount_Last10ProductDTO> ProductsWithTheMostItemsBySubstanceCount_Last10Product()
        {/*
        Select TOP 10 Count(pc.SubstanceId), p.Name from ProductContent pc join Product p on 
        pc.ProductId = p.Id join Substance s on pc.SubstanceId = s.Id where p.Name is not null
        group by p.Name order by Count(pc.SubstanceId) 
          */
            List<ProductsWithTheMostItemsBySubstanceCount_Last10ProductDTO> ProductsWithTheMostItemsBySubstanceCount_Last10Product = null;
            using (GreenHouse entity = new GreenHouse())
            {
                ProductsWithTheMostItemsBySubstanceCount_Last10Product = (from pc in entity.ProductContent
                                                                          join
                                                                          p in entity.Product on pc.ProductId equals p.Id
                                                                          join s in entity.Substance
                                                                          on pc.SubstanceId equals s.Id
                                                                          where p.Name != null
                                                                          group p by p.Name into pGRP
                                                                          select new ProductsWithTheMostItemsBySubstanceCount_Last10ProductDTO
                                                                          {
                                                                              ProductName = pGRP.Key,
                                                                              Quantity = pGRP.Count()
                                                                          }).ToList();
            }
            var descendingProduct = ProductsWithTheMostItemsBySubstanceCount_Last10Product.OrderBy(x => x.Quantity).Take(10).ToList();
            return descendingProduct;
        }

        public List<WhoHasHowManyBlacklistedProductsAndHowManyFavoriteProductsDTO> WhoHasHowManyBlacklistedProductsAndHowManyFavoriteProducts()
        {
            /*
              select u.Name, sum(case when s.Id=1 then 1 else 0 end) as [Block Sayısı],
              sum(case when s.Id=2 then 1 else 0 end) as [Favori Sayısı]
              from 
              UserProcess up join [User] u on up.UserId = u.Id join Situation s on 
              up.SituationId = s.Id 
              group by u.Name 
             */

            List<WhoHasHowManyBlacklistedProductsAndHowManyFavoriteProductsDTO> WhoHasHowManyBlacklistedProductsAndHowManyFavoriteProducts = null;
            using (GreenHouse entity = new GreenHouse())
            {
                WhoHasHowManyBlacklistedProductsAndHowManyFavoriteProducts = (from up in entity.UserProcess
                                                                              join
                                                                              u in entity.User on up.UserId equals u.Id
                                                                              join s in entity.Situation on up.SituationId equals s.Id
                                                                              let value = new { s, u }
                                                                              let key = new { u.Name }
                                                                              group value by key into uGRP
                                                                              select new WhoHasHowManyBlacklistedProductsAndHowManyFavoriteProductsDTO
                                                                              {
                                                                                  Username = uGRP.Key.Name,
                                                                                  FavoriteQuantity = uGRP.Select(x => x.s.Id == 2 ? 1 : 0).Sum(),
                                                                                  BlockQuantity = uGRP.Select(x => x.s.Id == 1 ? 1 : 0).Sum()
                                                                              }).ToList();
            }
            return WhoHasHowManyBlacklistedProductsAndHowManyFavoriteProducts;
        }
        public List<HowManyUsersDoIHaveHowManySystemAdminsOrOthersDTO> HowManyUsersDoIHaveHowManySystemAdminsOrOthers()
        {

            /*
                select sum(case when ru.RolId = 1 then 1 else 0 end) as [Admin sayısı],
               sum(case when ru.RolId = 2 then 1 else 0 end) as [Normal Kullanıcı Sayısı],
               sum ( case when ru.RolId = 3 then 1 else 0 end) as [Premium Kullanıcı Sayısı]
               from [User] u join [RoleUser] ru on u.Id = ru.UserId
             */
            List<HowManyUsersDoIHaveHowManySystemAdminsOrOthersDTO> HowManyUsersDoIHaveHowManySystemAdminsOrOthers = null;
            using (GreenHouse entity = new GreenHouse())
            {
                HowManyUsersDoIHaveHowManySystemAdminsOrOthers = (from u in entity.User
                                                                  join
                                                                  ru in entity.RoleUser on u.Id equals ru.UserId
                                                                  //let value = new { ru }
                                                                  //let key = new {  }
                                                                  group ru by 1 into uGRP //    group ru by key into uGRP
                                                                  select new HowManyUsersDoIHaveHowManySystemAdminsOrOthersDTO
                                                                  {
                                                                      AdminCount = uGRP.Select(x => x.RolId == 1 ? 1 : 0).Sum(),
                                                                      NormalUserCount = uGRP.Select(x => x.RolId == 2 ? 1 : 0).Sum(),
                                                                      PremiumUserCount = uGRP.Select(x => x.RolId == 3 ? 1 : 0).Sum()
                                                                  }).ToList();
            }
            return HowManyUsersDoIHaveHowManySystemAdminsOrOthers;
        }


    }
}
