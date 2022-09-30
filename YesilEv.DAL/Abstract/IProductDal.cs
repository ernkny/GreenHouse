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
    public interface IProductDal : ISelectableRepository<Product>, IDeletableRepository<Product>, IInsertableRepository<Product>, IUpdateRepository<Product>
    {
        List<ProductsSubstanceDetailDTO> ProductsSubstanceDetail();
        Product ProductAdd(ProductDTO product, List<string> SplitedSubstances, List<Picture> PicturePaths);
        ProductDetailDTO productDetail(string _guid);
        List<ProductListDTO> GetAllProduct(); //for list page

        List<SearchDTO> Search(string searchBoxText);
        SearchHistoryDTO sendSearchedValue(List<SearchDTO> searchedValueList, int userId);
        List<productBlockOrfavoritesDto> productBlockOrfavorites();
        List<UserProductDto> userProductAddedInfo();
        bool UpdateProductAprroved(string barkode);
        List<productSubstancesForWhichRiskTypeHasNotBeenDeterminedDTO> productSubstancesForWhichRiskTypeHasNotBeenDetermined();
        bool UpdateRiskOfSubstanceWhoseRiskTypeIsNull(string substanceName, string riskType);
        int HowManyProductsDidTheUserAdd();
        int HowManyHighRiskOrLowRiskOrMediumRiskSubstancesDoesTheProductHave(string riskType, int productId);
        Product productUpdate(Product product, List<string> SplitedSubstances, List<Picture> pictures);
        bool ProductSoftDelete(Product p);
    }
}
