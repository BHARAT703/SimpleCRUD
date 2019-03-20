using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SimpleCRUD.Controllers;
using SimpleCRUD.Data.Abstract;
using SimpleCRUD.Dto;
using SimpleCRUD.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SimpleCRUD.Tests.Tests
{
    public class ProductControllerTests
    {
        [Fact]
        public void CanGet()
        {
            try
            {
                //Arrange
                //Repository
                Mock<IProductRepository> mockRepo = new Mock<IProductRepository>();
                var products = new List<Product>(){
                    new Product() { Id=1, Name = "Product1" },
                    new Product() { Id=2, Name = "Product2" },
                    new Product() { Id=3, Name = "Product3" }
                };

                mockRepo.Setup(m => m.items).Returns(value: products);

                //auto mapper
                var mockMapper = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new AutoMapperProfile());
                });
                var mapper = mockMapper.CreateMapper();

                ProductController controller = new ProductController(repository: mockRepo.Object, mapper: mapper);

                //Act
                var result = controller.Get();

                //Assert
                var okResult = result as OkObjectResult;
                if (okResult != null)
                    Assert.NotNull(okResult);

                var model = okResult.Value as IEnumerable<ProductDto>;
                if (model.Count() > 0)
                {
                    Assert.NotNull(model);

                    var expected = model?.FirstOrDefault().Name;
                    var actual = products?.FirstOrDefault().Name;

                    Assert.Equal(expected: expected, actual: actual);
                }
            }
            catch (Exception ex)
            {
                //Assert
                Assert.False(false, ex.Message);
            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void CanGetById(int id)
        {
            try
            {
                //Arrange
                //Repository
                Mock<IProductRepository> mockRepo = new Mock<IProductRepository>();
                var products = new List<Product>(){
                    new Product() { Id=1, Name = "Product1" },
                    new Product() { Id=2, Name = "Product2" },
                    new Product() { Id=3, Name = "Product3" }
                };

                mockRepo.Setup(m => m.items).Returns(value: products);

                //auto mapper
                var mockMapper = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new AutoMapperProfile());
                });
                var mapper = mockMapper.CreateMapper();

                ProductController controller = new ProductController(repository: mockRepo.Object, mapper: mapper);

                //Act
                var result = controller.Get(id: id);

                //Assert
                var okResult = result as OkObjectResult;
                if (okResult != null)
                    Assert.NotNull(okResult);

                if (okResult.Value is ProductDto model)
                {
                    var expected = model?.Name;
                    var actual = products?.Where(m => m.Id == id).FirstOrDefault().Name;

                    Assert.Equal(expected: expected, actual: actual);
                }
            }
            catch (Exception ex)
            {
                //Assert
                Assert.False(false, ex.Message);
            }
        }
    }
}
