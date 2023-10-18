using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace NorthwindService.Tester.Handlers.CustomerHandlers
{
    [TestClass]
    public class CustomerCreateTester
    {
        [Fact]
        public async Task Handle_ValidRequest_ReturnsSuccessResponse()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork<ApplicationDbContext>>();
            var mapperMock = new Mock<IMapper>();
            var loggerMock = new Mock<ILogger<CustomerCreateCommandHandler>>();

            var handler = new CustomerCreateCommandHandler(unitOfWorkMock.Object, mapperMock.Object, loggerMock.Object);

            var request = new CustomerCreateCommand(); // Geçerli bir request nesnesi oluşturmalısınız.

            // Unit test için uygun bir DbContext ve DbSet (mock veya hafıza veritabanı kullanabilirsiniz) oluşturmalısınız.

            // Simülasyon: InsertAsync çağrısını taklit ediyoruz
            unitOfWorkMock.Setup(uow => uow.GetRepositoryAsync<Customer>().InsertAsync(It.IsAny<Customer>()))
                         .ReturnsAsync((Customer customer) => new RepositoryEntity<Customer> { Entity = customer });

            // Simülasyon: CommitAsync çağrısını taklit ediyoruz
            unitOfWorkMock.Setup(uow => uow.CommitAsync());

            // Simülasyon: Mapper.Map çağrısını taklit ediyoruz
            mapperMock.Setup(mapper => mapper.Map<Customer>(It.IsAny<CustomerCreateCommand>()))
                      .Returns((CustomerCreateCommand request) => new Customer());

            // Act
            var response = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(response);
            Assert.True(response.IsSuccessful);
            Assert.Equal(StatusCodes.Status200OK, response.StatusCode);
            // Diğer doğrulamaları ekleyebilirsiniz.
        }
    }
}
