using GreenHouseEntityy.Concrete.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using YesilEv.Core.Concrete;
using YesilEv.Core.Context;
using YesilEv.DAL.Abstract;
using YesilEv.Entity.Concrete.DTO;

namespace YesilEv.DAL.Concrete
{
    public class ProductDal : EFRepositoryBase<Product, GreenHouse>, IProductDal
    {
        SingletonLoginInformations loginUserInfo = SingletonLoginInformations.LoginInformationWithSingleton;
        public ProductDal()
        {

        } //dal - dto
        public ProductDal(GreenHouse context) : base(context)
        {

        }
        public bool ProductSoftDelete(Product p)
        {
            using (GreenHouse db = new GreenHouse())
            {
                var productResult = db.Product.Where(x => x.BarkodNo == p.BarkodNo).FirstOrDefault();
                productResult.isActive = false;
                var res = db.Entry(productResult);
                res.State = EntityState.Modified;
                var s = db.SaveChanges();
            }
            return true;
        }
            public bool UpdateProductAprroved(string barkode)
        {
            using (GreenHouse db = new GreenHouse())
            {
                var productResult = db.Product.Where(x => x.BarkodNo == barkode).FirstOrDefault();
                productResult.ModifiedBy = loginUserInfo.Id;
                productResult.ModifiedDate = DateTime.Now;
                productResult.IsApproved = productResult.IsApproved == true ? false : true;
                productResult.isActive = productResult.IsApproved == true ? true : false;
                var res = db.Entry(productResult);
                res.State = EntityState.Modified;
                var s = db.SaveChanges();
            }
            return true;
        }

        public List<RiskProductDto> RiskProductSearch(string RiskLevel)
        {
            List<RiskProductDto> products = null;
            using (GreenHouse db = new GreenHouse())
            {

                products = (from s in db.Substance
                            where s.Name == RiskLevel
                            join pt in db.ProductContent on s.Id equals pt.SubstanceId
                            select new RiskProductDto
                            {
                                Name = s.Name
                            }).ToList();
            }
            return products;
        }
        public List<ProductsSubstanceSearchDTO> ProductsSubstanceSearch(string Name)
        {
            List<ProductsSubstanceSearchDTO> products = null;
            using (GreenHouse db = new GreenHouse())
            {


                products = (from s in db.Substance
                            where s.RisktType == Name
                            join pt in db.ProductContent on s.Id equals pt.SubstanceId
                            join pr in db.Product on pt.ProductId equals pr.Id
                            join c in db.Company on pr.CompanyId equals c.Id
                            group new { s, pr, c } by pr.Id
                                into grouping
                            select new ProductsSubstanceSearchDTO
                            {
                                NameProduct = grouping.Select(a => a.pr.Name).FirstOrDefault(),
                                BarCode = grouping.Select(a => a.pr.BarkodNo).FirstOrDefault(),
                                CompanyName = grouping.Select(a => a.c.Name).FirstOrDefault()

                            }).ToList();
            }
            return products;
        }

        public List<ProductsSubstanceSearchDTO> SubstanceProductSearch(string substanceName)
        {
            List<ProductsSubstanceSearchDTO> products = null;
            using (GreenHouse db = new GreenHouse())
            {

                products = (from s in db.Substance
                            join pt in db.ProductContent on s.Id equals pt.SubstanceId
                            join pr in db.Product on pt.ProductId equals pr.Id
                            join c in db.Company on pr.CompanyId equals c.Id
                            group new { s, pr, c } by pr.Id
                                into grouping
                            select new ProductsSubstanceSearchDTO
                            {
                                NameProduct = grouping.Select(a => a.pr.Name).FirstOrDefault(),
                                BarCode = grouping.Select(a => a.pr.BarkodNo).FirstOrDefault(),
                                CompanyName = grouping.Select(a => a.c.Name).FirstOrDefault(),
                                SubstanceName = grouping.Select(a => a.s.Name).FirstOrDefault()

                            }).Where(x => x.SubstanceName.ToUpper().Contains(substanceName.ToUpper())).ToList();
            }
            return products;
        }

        public List<ProductsSubstanceDetailDTO> ProductsSubstanceDetail()
        {


            List<ProductsSubstanceDetailDTO> products = null;
            using (GreenHouse db = new GreenHouse())
            {
                products = (from pr in db.Product
                            join pt in db.ProductContent on pr.Id equals pt.ProductId
                            join s in db.Substance on pt.SubstanceId equals s.Id
                            group new { s, pr, } by pr.Id
                                into grouping
                            select new ProductsSubstanceDetailDTO
                            {
                                ProductName = grouping.Select(a => a.pr.Name).FirstOrDefault(),
                                Barcode = grouping.Select(a => a.pr.BarkodNo).FirstOrDefault(),
                                SubstancesCount = grouping.Select(a => new SubstanceDTO() { Name = a.s.Name }).Distinct().Count()
                            }).ToList();
            }
            return products;
        }

        public List<UserProductDto> userProductAddedInfo()
        {
            List<UserProductDto> Users = null;
            using (GreenHouse db = new GreenHouse())
            {
                Users = (from p in db.Product
                         join us in db.User on p.CreatedBy equals us.Id
                         group new { p, us } by us.Id
                         into grouping
                         select new UserProductDto
                         {
                             UserName = grouping.Select(x => x.us.Name).FirstOrDefault(),
                             CalculatedProductToAdded = grouping.Select(x => x.p.Name).Distinct().Count()

                         }).ToList();
            }
            return Users;
        }

        public List<productBlockOrfavoritesDto> productBlockOrfavorites()
        {
            List<productBlockOrfavoritesDto> products = null;

            using (GreenHouse db = new GreenHouse())
            {

                //products = (from usp in db.UserProcess
                //            join u in db.User on usp.UserId equals u.Id 
                //            join pr in db.Product on usp.ProductId equals pr.Id
                //            join s in db.Situation on usp.SituationId equals s.Id
                //            group new { s, pr, u } by usp.Id
                //                into grouping
                //            select new productBlockOrfavoritesDto
                //            {
                //                ProductName = grouping.Select(a=>a.pr.Name).ToString(),
                //                SituationName = grouping.Select(a => a.s.Situation1).FirstOrDefault(),
                //                SituationId= grouping.Select(a => a.pr.Name).Count(),

                //            }).ToList();
                products = db.Database.SqlQuery<productBlockOrfavoritesDto>(@"exec FavBlock").ToList();

            }

            return products;

        }
        public ProductDetailDTO productDetail(string _guid)
        {
            ProductDetailDTO products = null;
            using (GreenHouse db = new GreenHouse())
            {

                products = (from pr in db.Product
                            where pr.BarkodNo == _guid
                            join cat in db.Category on pr.CategoryId equals cat.Id
                            join pt in db.ProductContent on pr.Id equals pt.ProductId
                            join s in db.Substance on pt.SubstanceId equals s.Id
                            join c in db.Company on pr.CompanyId equals c.Id
                            join pic in db.Picture on pr.Id equals pic.ProductId into pc
                            from pictures in pc.DefaultIfEmpty()
                            group new { pictures, s, cat, pr, c } by pr.Id
                               into grouping
                            select new ProductDetailDTO
                            {
                                Barkod = grouping.Select(a => a.pr.BarkodNo).FirstOrDefault(),
                                ProductName = grouping.Select(a => a.pr.Name).FirstOrDefault(),
                                CategoryName = grouping.Select(a => a.cat.Name).FirstOrDefault(),
                                CompanyName = grouping.Select(a => a.c.Name).FirstOrDefault(),
                                Pictures = grouping.Select(a => new PictureDTO() { PicturePath = a.pictures.PicturePath }).Distinct().ToList(),
                                Substances = grouping.Select(a => new SubstanceDTO() { Name = a.s.Name }).Distinct().ToList(),
                                Id = grouping.Select(a => a.pr.Id).FirstOrDefault()

                            }).FirstOrDefault();
            }
            return products;
        }
        public Product productUpdate(Product product, List<string> SplitedSubstances, List<Picture> pictures)
        {
            using (GreenHouse db = new GreenHouse())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Product productFromDb = db.Product.Where(x => x.Id == product.Id).FirstOrDefault();
                        PictureDal pictureDal = new PictureDal();
                        SubstanceDal substanceDal = new SubstanceDal();
                        ProductContentDal productContentDal = new ProductContentDal();
                        List<ProductContent> productContents = new List<ProductContent>();
                        List<Substance> existSubstance = new List<Substance>();
                        foreach (var item in pictures)
                        {
                            pictureDal.UpdatePicturePath(item.Id, item.PicturePath);
                        }
                        foreach (var item in productContentDal.GetAll(x => x.ProductId == product.Id).ToList())
                        {
                            //çalışmıyor productContentDal.Delete(item);
                            db.Database.ExecuteSqlCommand("delete from ProductContent where Id={0}", item.Id);
                        }
                        foreach (var item in SplitedSubstances)
                        {
                            var ResultSubstance = substanceDal.GetAll(x => x.Name == item).FirstOrDefault();
                            if (ResultSubstance is null)
                            {
                                ProductContent productContent = new ProductContent();
                                Substance sub = new Substance();
                                sub.Name = item.ToUpper();
                                sub.isActive = true;
                                sub.CreatedDate = DateTime.Now;
                                productContent.Substance = sub;
                                productContents.Add(productContent);
                            }
                            else { existSubstance.Add(ResultSubstance); }
                        }
                        foreach (var item in existSubstance)
                        {
                            ProductContent productContent = new ProductContent();
                            productContent.SubstanceId = existSubstance.Where(x => x.Name == item.Name).SingleOrDefault().Id;
                            productContent.ProductId = product.Id;
                            productContents.Add(productContent);

                        }
                        productFromDb.BarkodNo = product.BarkodNo;
                        productFromDb.CategoryId = product.CategoryId;
                        productFromDb.CompanyId = product.CompanyId;
                        productFromDb.Name = product.Name;
                        productFromDb.IsApproved = false;
                        productFromDb.ProductContent = productContents;
                        var entityUpdateResult = db.Entry(productFromDb);
                        entityUpdateResult.State = EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return null;
                        throw;
                    }


                    return product;
                }

            }
        }
        public Product ProductAdd(ProductDTO productDto, List<string> SplitedSubstances, List<Picture> PicturePaths)
        {


            Product product = new Product();
            using (GreenHouse db = new GreenHouse())
            {
                product.BarkodNo = productDto.Guid;
                product.CategoryId = productDto.CategoryId;
                product.CompanyId = productDto.CompanyId;
                product.CreatedDate = DateTime.Now;
                product.Name = productDto.Name;
                product.IsApproved = false;
                product.CreatedBy = loginUserInfo.Id;
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        SubstanceDal substanceDal = new SubstanceDal();
                        ProductContentDal productContentDal = new ProductContentDal();
                        List<ProductContent> productContents = new List<ProductContent>();
                        List<Substance> existSubstance = new List<Substance>();
                        foreach (var item in SplitedSubstances)
                        {
                            var ResultSubstance = substanceDal.GetAll(x => x.Name == item).SingleOrDefault();
                            if (ResultSubstance is null)
                            {
                                ProductContent productContent = new ProductContent();
                                Substance sub = new Substance();
                                sub.Name = item.ToUpper();
                                sub.isActive = true;
                                sub.CreatedDate = DateTime.Now;
                                productContent.Substance = sub;
                                productContents.Add(productContent);
                            }
                            else { existSubstance.Add(ResultSubstance); }
                        }
                        foreach (var item in existSubstance)
                        {
                            ProductContent productContent = new ProductContent();
                            productContent.SubstanceId = existSubstance.Where(x => x.Name == item.Name).SingleOrDefault().Id;
                            productContent.ProductId = product.Id;
                            productContents.Add(productContent);

                        }
                        product.Pictures = PicturePaths;
                        product.ProductContent = productContents;
                        product.IsApproved = false;
                        db.Product.Add(product);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return null;
                        throw;
                    }
                }
            }
            return product;
        }
        public List<ProductListDTO> GetAllProduct()
        {
            List<ProductListDTO> products = null;
            using (GreenHouse db = new GreenHouse())
            {
                products = (from product in db.Product
                            join c in db.Company on product.CompanyId equals c.Id
                            join cat in db.Category on product.CategoryId equals cat.Id
                            where product.Name != null
                            select new ProductListDTO
                            {
                                CategoryName = cat.Name,
                                CompanyName = c.Name,

                                BarkodNo = product.BarkodNo,
                                Name = product.Name,
                                isActive = product.isActive,
                                CreatedDate = product.CreatedDate,
                                // CreatedBy = product.CreatedBy,
                                //ModifiedBy = product.ModifiedBy
                                IsApproved = product.IsApproved
                            }).ToList();


            }
            return products;
        }

        public List<SearchDTO> Search(string searchBoxText)
        {
            List<SearchDTO> searches = null;
            using (GreenHouse db = new GreenHouse())
            {
                //return db.Product.Where(s=>s.Name == searchBoxText).ToList(); -- fk lar sıkıntı çıkartıyor o yüzden linq ile
                searches = (from pro in db.Product
                            join com in db.Company on pro.CompanyId equals com.Id
                            join cat in db.Category on pro.CategoryId equals cat.Id
                            where pro.Name == searchBoxText
                            select new SearchDTO()
                            {
                                Id = pro.Id,
                                CategoryName = cat.Name,
                                Name = pro.Name,
                                CompanyName = com.Name,
                                BarkodNo = pro.BarkodNo,
                                isActive = pro.isActive,
                                CreatedDate = pro.CreatedDate,
                                //   CreatedBy = pro.CreatedBy,
                                //  ModifiedBy = pro.ModifiedBy,
                                ModifiedDate = pro.ModifiedDate,

                            }).ToList();
            }
            return searches;
        }


        public SearchHistoryDTO sendSearchedValue(List<SearchDTO> searchedValueList, int userId)
        { //aranılan ürünün kaydını user için db ye çekmek için
            SearchHistoryDTO searchHistoryDTO = new SearchHistoryDTO();
            using (GreenHouse entity = new GreenHouse())
            {
                /*
                int Id = 0;
                bool? isActive = null;
                DateTime? CreatedDate = null;
                DateTime? ModifiedDate = null;
                int? CreatedBy = null;
                int? ModifiedBy = null;

                foreach(var i in searchedValueList)
                {
                    Id = i.Id;
                    isActive = i.isActive;
                    CreatedDate = i.CreatedDate;
                    ModifiedDate = i.ModifiedDate;
                    CreatedBy = i.CreatedBy;
                    ModifiedBy = i.ModifiedBy;
                }

                entity.SearchHistory.Add(new SearchHistory()
                {
                    ProductId = Id,
                    UserId = userId,
                    isActive = isActive,
                    CreatedDate = CreatedDate,
                    ModifiedDate = ModifiedDate,
                    CreatedBy = CreatedBy,
                    ModifiedBy = userId,
                });
                */

                foreach (var item in searchedValueList)
                {
                    searchHistoryDTO.ProductId = item.Id;
                    searchHistoryDTO.isActive = item.isActive;

                }
                searchHistoryDTO.UserId = userId;
                searchHistoryDTO.CreatedBy = userId;//paremetreden
                searchHistoryDTO.ModifiedBy = userId;
                entity.SearchHistory.Add(new SearchHistory()
                {
                    ProductId = searchHistoryDTO.ProductId,
                    UserId = searchHistoryDTO.UserId,
                    isActive = searchHistoryDTO.isActive,
                    CreatedDate = searchHistoryDTO.CreatedDate,
                    ModifiedDate = searchHistoryDTO.ModifiedDate,
                    CreatedBy = searchHistoryDTO.CreatedBy,
                    ModifiedBy = searchHistoryDTO.ModifiedBy,
                });
                foreach (var item in searchedValueList)
                {
                    if (item.Id != null)
                    {
                        entity.SaveChanges();
                    }
                }

                /*
            var a = (from search in entity.SearchHistory
                     select new searchHistoryDTO()
                     {
                         ProductId = search.ProductId,
                         UserId = search.UserId,
                         isActive = search.isActive,
                         CreatedDate = search.CreatedDate,
                         ModifiedDate = search.ModifiedDate,
                         CreatedBy = search.CreatedBy,
                         ModifiedBy= search.ModifiedBy,
                     }).ToList();*/
            }
            return searchHistoryDTO;

        }

        public List<productSubstancesForWhichRiskTypeHasNotBeenDeterminedDTO> productSubstancesForWhichRiskTypeHasNotBeenDetermined()
        {
            List<productSubstancesForWhichRiskTypeHasNotBeenDeterminedDTO> productSubstancesForWhichRiskTypeHasNotBeenDetermined = null;
            using (GreenHouse entity = new GreenHouse())
            {
                productSubstancesForWhichRiskTypeHasNotBeenDetermined = (from s in entity.Substance
                                                                         where s.RisktType == null
                                                                         select new productSubstancesForWhichRiskTypeHasNotBeenDeterminedDTO()
                                                                         {
                                                                             SubstanceName = s.Name
                                                                         }).ToList();
            }
            return productSubstancesForWhichRiskTypeHasNotBeenDetermined;
        }

        public bool UpdateRiskOfSubstanceWhoseRiskTypeIsNull(string substanceName, string riskType)
        {
            using (GreenHouse entity = new GreenHouse())
            {
                using (var transaction = entity.Database.BeginTransaction())
                {
                    try
                    {
                        var i = (from s in entity.Substance
                                 where s.Name == substanceName
                                 select s).SingleOrDefault();
                        i.RisktType = riskType;
                        i.ModifiedBy = loginUserInfo.Id;
                        i.ModifiedDate = DateTime.Now;
                        entity.SaveChanges();
                        transaction.Commit();
                        return true;

                    }
                    catch (Exception )
                    {
                        transaction.Rollback();
                        return false;
                    }
                }

            }
        }
        public int HowManyProductsDidTheUserAdd()
        {
            int addedProductCount;
            using (GreenHouse entity = new GreenHouse())
            {
                addedProductCount = (from p in entity.Product
                                     where p.CreatedBy == loginUserInfo.Id
                                     select p.CreatedBy).Count(); //select p de olur fakat sadece CreatedBy ları saysın, select p de aynı işlevi görür ama

                //addedProductCount = entity.Product.Select(x=>x.CreatedBy==loginUserInfo.Id).Count();
            }
            return addedProductCount;
        }

        public int HowManyHighRiskOrLowRiskOrMediumRiskSubstancesDoesTheProductHave(string riskType, int productId)
        {
            /*
             select Count(s.RisktType) from ProductContent 
             pc join Substance s on pc.SubstanceId = s.Id where RisktType = 'Yüksek' and ProductId = 1
             */
            int HowManyHighRiskOrLowRiskOrMediumRiskSubstancesDoesTheProductHave_Request;
            using (GreenHouse entity = new GreenHouse())
            {
                HowManyHighRiskOrLowRiskOrMediumRiskSubstancesDoesTheProductHave_Request = (from pc in entity.ProductContent
                                                                                            join s in entity.Substance on pc.SubstanceId equals
                                                                                            s.Id
                                                                                            where s.RisktType == riskType && pc.ProductId == productId
                                                                                            select s.RisktType).Count();
            }
            return HowManyHighRiskOrLowRiskOrMediumRiskSubstancesDoesTheProductHave_Request;
        }

    }
}
//uida core olmamalı