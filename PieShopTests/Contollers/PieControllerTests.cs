using Microsoft.AspNetCore.Mvc;
using PieShop.Controllers;
using PieShop.ViewModels;
using PieShopTests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShopTests.Contollers
{
    public class PieControllerTests
    {
        [Fact]
        public void List_EmptyCategpry_ReturnAllPies()
        {
            var mockPieRepo = RepositoryMocks.GetPieRepository();
            var mockCategoryRepo = RepositoryMocks.GetCategoryRepository();
            var pieController = new PieController(mockPieRepo.Object, mockCategoryRepo.Object);
            var result = pieController.List("");
            var viewResult = Assert.IsType<ViewResult>(result);
            var pieListViewModel = Assert.IsAssignableFrom<PieListViewModel>(viewResult.ViewData.Model);
            Assert.Equal(10, pieListViewModel.Pies.Count());
        }
    }
}
