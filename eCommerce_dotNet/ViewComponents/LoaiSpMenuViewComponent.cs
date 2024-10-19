using eCommerce_dotNet.Repository;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce_dotNet.ViewComponents
{
    public class LoaiSpMenuViewComponent : ViewComponent
    {
        private readonly ILoaiSpRepository loaiSpRepository;

        public LoaiSpMenuViewComponent(ILoaiSpRepository loaiSpRepository) => this.loaiSpRepository = loaiSpRepository;

        public IViewComponentResult Invoke()
        {
            var loaiSps = loaiSpRepository.GetAllLoaiSp().OrderBy(x => x.Loai);
            return View(loaiSps);
        }
    }
}
