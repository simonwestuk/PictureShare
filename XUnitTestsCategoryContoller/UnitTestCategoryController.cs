using Microsoft.AspNetCore.Mvc;
using PictureShare.Areas.Admin.Views;
using PictureShare.Models;
using PictureShare.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestsPictureShare
{
    public class UnitTestCategoryController
    {
        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfCategories()
        {
            //Arrange
            var mockRepo = new MockUnitOfWork();
            var controller = new CategoryController(mockRepo);

            //Act
            var result = await controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<CategoryModel>>(viewResult.ViewData.Model);
            Assert.Equal(3, model.Count());
        }

        [Fact]

        public async Task EditPost_ReturnsNotFoundResult_WhenModelIdIsIncorrect()
        {
            //Arrange
            var mockRepo = new MockUnitOfWork();
            var controller = new CategoryController(mockRepo);
            var category = new CategoryModel()
            {
                Id = 4,
                Name = "TestCat4"
            };

            //Act
            var result = await controller.Edit(-1, category);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task EditPost_ReturnsRedirectToIndexAction_WhenModelIsValid()
        {
            //Arrange
            var mockRepo = new MockUnitOfWork();
            var controller = new CategoryController(mockRepo);
            var category = new CategoryModel()
            {
                Id = 4,
                Name = "TestCat4"
            };

            //Act
            var result = await controller.Edit(4, category);

            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }
    }
}
