namespace CarSharing.Domain.UnitTests.Commands.Client
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Commands.Client.Impl;
    using CarSharing.Domain.Dto.Client.Request;
    using CarSharing.Domain.Dto.Client.Response;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Repository.Client;
    using CarSharing.Domain.RepositoryFactory.Client;
    using FakeItEasy;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ActivateClientCommandAsyncTests
    {
        [TestMethod]
        public async Task ExecuteAsync_NullRequest_ExceptionThrown()
        {
            // Arrange
            IClientRepositoryFactory repoFactory = A.Fake<IClientRepositoryFactory>();
            ActivateClientCommandAsync command = new ActivateClientCommandAsync(repoFactory);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => command.ExecuteAsync(null));
        }

        [TestMethod]
        public async Task ExecuteAsync_ClientNotFound_ExceptionThrown()
        {
            // Arrange
            IClientRepository repo = A.Fake<IClientRepository>();
            A.CallTo(() => repo.GetByIdAsync(A<object>._)).Returns<Client>(null);
            
            IClientRepositoryFactory repoFactory = A.Fake<IClientRepositoryFactory>();
            A.CallTo(() => repoFactory.CreateRepository()).Returns(repo);
            
            ActivateClientCommandAsync command = new ActivateClientCommandAsync(repoFactory);
            
            ActivateClientRequestDto request = new ActivateClientRequestDto()
            {
                ClientId = Guid.Empty
            };

            // Act & Assert
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(() => command.ExecuteAsync(request));
        }

        [TestMethod]
        public async Task ExecuteAsync_ClientActivated()
        {
            // Arrange
            Guid clientId = Guid.NewGuid();
            
            Client client = new Client()
            {
                ClientId = clientId,
                IsActive = false
            };
            
            IClientRepository repo = A.Fake<IClientRepository>();
            A.CallTo(() => repo.GetByIdAsync(clientId)).Returns(client);

            IClientRepositoryFactory repoFactory = A.Fake<IClientRepositoryFactory>();
            A.CallTo(() => repoFactory.CreateRepository()).Returns(repo);

            ActivateClientCommandAsync command = new ActivateClientCommandAsync(repoFactory);

            ActivateClientRequestDto request = new ActivateClientRequestDto()
            {
                ClientId = clientId
            };

            // Act
            ActivateClientResponseDto response = await command.ExecuteAsync(request);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
            A.CallTo(() => repo.UpdateAsync(A<Client>.That.Matches(x => x.IsActive), true)).MustHaveHappenedOnceExactly();
        }
    }
}
