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
    public class UpdateClientCommandAsyncTests
    {
        [TestMethod]
        public async Task ExecuteAsync_NullRequest_ExceptionThrown()
        {
            // Arrange
            IClientRepositoryFactory repoFactory = A.Fake<IClientRepositoryFactory>();
            UpdateClientCommandAsync command = new UpdateClientCommandAsync(repoFactory);

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

            UpdateClientCommandAsync command = new UpdateClientCommandAsync(repoFactory);

            UpdateClientRequestDto request = new UpdateClientRequestDto()
            {
                ClientId = Guid.NewGuid()
            };

            // Act & Assert
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(() => command.ExecuteAsync(request));
        }

        [TestMethod]
        public async Task ExeecuteAsync_ClientUpdated()
        {
            // Arrange
            Guid clientId = Guid.NewGuid();
            
            Client client = new Client()
            {
                ClientId = clientId,
                Name = "old_name",
                Surname = "old_surname",
                LicenseNumber = "old_license_number",
                PhoneNumber = "old_phone_number",
                Email = "old_email",
                IsActive = true
            };

            IClientRepository repo = A.Fake<IClientRepository>();
            A.CallTo(() => repo.GetByIdAsync(clientId)).Returns(client);

            IClientRepositoryFactory repoFactory = A.Fake<IClientRepositoryFactory>();
            A.CallTo(() => repoFactory.CreateRepository()).Returns(repo);

            UpdateClientCommandAsync command = new UpdateClientCommandAsync(repoFactory);

            UpdateClientRequestDto request = new UpdateClientRequestDto()
            {
                ClientId = clientId,
                Name = "new_name",
                Surname = null,
                LicenseNumber = "new_license_number",
                PhoneNumber = null,
                Email = "new_email"
            };

            // Act
            UpdateClientResponseDto response = await command.ExecuteAsync(request);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
            A.CallTo(() => repo.UpdateAsync(A<Client>.That.Matches(x => x.ClientId == clientId &&
                                                                        x.Name == "new_name" &&
                                                                        x.Surname == "old_surname" &&
                                                                        x.LicenseNumber == "new_license_number" &&
                                                                        x.PhoneNumber == "old_phone_number" &&
                                                                        x.Email == "new_email"),
                                            true))
             .MustHaveHappenedOnceExactly();
        }
    }
}
