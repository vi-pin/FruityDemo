using FruityDemo.Controllers;
using FruityDemo.Models;
using FruityDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruityDemo.Tests.Controllers
{
    public class FruitControllerTests
    {
        private readonly Mock<IFruitService> _fruitServiceMock = new Mock<IFruitService>();
        private readonly Mock<ILogger<FruitController>> _loggerMock = new Mock<ILogger<FruitController>>();

        [Fact]
        public async Task GetAllFruits_ReturnsOkResultWithFruits()
        {
            // Arrange
            var expectedFruits = MockFruitResult();

            _fruitServiceMock.Setup(s => s.GetAllFruits()).ReturnsAsync(expectedFruits);

            FruitController _controller = new FruitController(_fruitServiceMock.Object, _loggerMock.Object);
            // Act
            var result = await _controller.GetAllFruits();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var fruits = Assert.IsAssignableFrom<List<Fruit>>(okResult.Value);
            Assert.Equal(expectedFruits, fruits);
        }

        [Fact]
        public async Task GetAllFruits_ReturnsStatusCode500_WhenServiceThrowsException()
        {
            // Arrange
            _fruitServiceMock.Setup(s => s.GetAllFruits()).ThrowsAsync(new Exception("Test exception"));
            FruitController _controller = new FruitController(_fruitServiceMock.Object, _loggerMock.Object);

            // Act
            var result = await _controller.GetAllFruits();
            // Assert
            
            var statusCodeResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task GetFruitsByFamily_ReturnsOkResultWithMatchingFruits()
        {
            // Arrange
            var fruitFamily = "Rutaceae";
            // Arrange
            var expectedFruits = MockFruitResult();
            var request = new FruitFamilyRequest { FruitFamily = fruitFamily };
            FruitController _controller = new FruitController(_fruitServiceMock.Object, _loggerMock.Object);

            _fruitServiceMock.Setup(s => s.GetFruitsByFamily(fruitFamily)).ReturnsAsync(expectedFruits);

            // Act
            var result = await _controller.GetFruitsByFamily(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var fruits = Assert.IsAssignableFrom<List<Fruit>>(okResult.Value);
            Assert.Equal(expectedFruits, fruits);
        }

        [Fact]
        public async Task GetFruitsByFamily_ReturnsStatusCode500_WhenServiceThrowsException()
        {
            // Arrange
            var fruitFamily = "Rutaceae";
            var request = new FruitFamilyRequest { FruitFamily = fruitFamily };
            FruitController _controller = new FruitController(_fruitServiceMock.Object, _loggerMock.Object);

            _fruitServiceMock.Setup(s => s.GetFruitsByFamily(fruitFamily))
                .ThrowsAsync(new Exception("Test exception"));

            // Act
            var result = await _controller.GetFruitsByFamily(request);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        private List<Fruit> MockFruitResult()
        {
            return new List<Fruit> {
            new Fruit{
                Family = "",
                Genus = "",
                Id = 1,
                Name = "",
                Nutritions = new Nutritions
                {
                       Calories = 23,
                       Carbohydrates = 2,
                       Fat = 3,
                       Protein = 4,
                       Sugar = 5,
                },
                Order   = ""
            }
            };
        }

    }
}
