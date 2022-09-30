using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEv.Entity.Concrete.DTO;

namespace YesilEv.DAL.Abstract
{
    public interface IReportDal
    {
        List<MostAllergenProductDTO> mostAllergenicProducts();
        List<EthanolFavoriteOrBlockDTO> EthanolFavoriteOrBlock();
        List<MostFavoriteProducts> MostFavoriteProducts();
        List<BuAyKaraListeVeFavoriyeAlınanUrunlerDTO> BlacklistAndFavoritedProductsThisMonth();
        List<KiminKacFavoriBlockUrunuDTO> WhoHasHowManyFavoriteBlockItems();
        List<HowManySubstanceDoesEachProductHaveDTO> HowManySubstanceDoesEachProductHave();
        List<ListofProductsThatHaveEthanolDTO> ListofProductsThatHaveEthanol();
        List<NumberOfProductsNotApprovedByAdminThisMonthDTO> NumberOfProductsNotApprovedByAdminThisMonth();
        List<HowManyTimesHastheProductContainingEthanol_BeenAddedToTheFavoriteList_SameForBlockDTO> HowManyTimesHastheProductContainingEthanol_BeenAddedToTheFavoriteList_SameForBlock();
        List<MostFavoriteProducts> MostFavoriteProductsTOP3();
        List<UserProductEntryDTO> Top5UsersWithTheMostProductEntries();
        List<ProductsWithTheMostItemsBySubstanceCount_Last10ProductDTO> ProductsWithTheMostItemsBySubstanceCount_Last10Product();
        List<WhoHasHowManyBlacklistedProductsAndHowManyFavoriteProductsDTO> WhoHasHowManyBlacklistedProductsAndHowManyFavoriteProducts();
        List<HowManyUsersDoIHaveHowManySystemAdminsOrOthersDTO> HowManyUsersDoIHaveHowManySystemAdminsOrOthers();

    }
}
