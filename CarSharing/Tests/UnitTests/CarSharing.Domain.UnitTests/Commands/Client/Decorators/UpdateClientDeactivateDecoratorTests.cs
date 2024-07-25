namespace CarSharing.Domain.UnitTests.Commands.Client.Decorators
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Commands.Client;
    using CarSharing.Domain.Commands.Client.Impl.Decorators;
    using CarSharing.Domain.Dto.Client.Request;
    using CarSharing.Domain.Dto.Client.Response;
    using FakeItEasy;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UpdateClientDeactivateDecoratorTests
    {
        [TestMethod]
        public async Task ExecuteAsync_NullRequest_DeactivateNotCalled()
        {
            // Arrange
            UpdateClientRequestDto request = null;
            
            IDeactivateClientCommandAsync deactivateCommand = A.Fake<IDeactivateClientCommandAsync>();
            
            UpdateClientResponseDto decorateeResponse = new UpdateClientResponseDto()
            {
                Success = false
            };
            
            IUpdateClientCommandAsync decoratee = A.Fake<IUpdateClientCommandAsync>();
            A.CallTo(() => decoratee.ExecuteAsync(request)).Returns(decorateeResponse);
            
            UpdateClientDeactivateDecorator decorator = new UpdateClientDeactivateDecorator(deactivateCommand, decoratee);

            // Act
            UpdateClientResponseDto response = await decorator.ExecuteAsync(request);

            // Assert
            A.CallTo(() => decoratee.ExecuteAsync(request)).MustHaveHappenedOnceExactly();
            A.CallTo(() => deactivateCommand.ExecuteAsync(A<DeactivateClientRequestDto>._)).MustNotHaveHappened();
            Assert.AreEqual(decorateeResponse, response);
        }

        [TestMethod]
        public async Task ExecuteAsync_SuccessFalse_DeactivateNotCalled()
        {
            // Arrange
            UpdateClientRequestDto request = new UpdateClientRequestDto()
            {
                ClientId = Guid.NewGuid(),
                Name = "new_name"
            };

            IDeactivateClientCommandAsync deactivateCommand = A.Fake<IDeactivateClientCommandAsync>();

            UpdateClientResponseDto decorateeResponse = new UpdateClientResponseDto()
            {
                Success = false
            };

            IUpdateClientCommandAsync decoratee = A.Fake<IUpdateClientCommandAsync>();
            A.CallTo(() => decoratee.ExecuteAsync(request)).Returns(decorateeResponse);

            UpdateClientDeactivateDecorator decorator = new UpdateClientDeactivateDecorator(deactivateCommand, decoratee);

            // Act
            UpdateClientResponseDto response = await decorator.ExecuteAsync(request);

            // Assert
            A.CallTo(() => decoratee.ExecuteAsync(request)).MustHaveHappenedOnceExactly();
            A.CallTo(() => deactivateCommand.ExecuteAsync(A<DeactivateClientRequestDto>._)).MustNotHaveHappened();
            Assert.AreEqual(decorateeResponse, response);
        }

        [TestMethod]
        public async Task ExecuteAsync_SuccessTrue_DeactivateCalled()
        {
            // Arrange
            Guid clientId = Guid.NewGuid();
            
            UpdateClientRequestDto request = new UpdateClientRequestDto()
            {
                ClientId = clientId,
                Name = "new_name"
            };

            IDeactivateClientCommandAsync deactivateCommand = A.Fake<IDeactivateClientCommandAsync>();

            UpdateClientResponseDto decorateeResponse = new UpdateClientResponseDto()
            {
                Success = true
            };

            IUpdateClientCommandAsync decoratee = A.Fake<IUpdateClientCommandAsync>();
            A.CallTo(() => decoratee.ExecuteAsync(request)).Returns(decorateeResponse);

            UpdateClientDeactivateDecorator decorator = new UpdateClientDeactivateDecorator(deactivateCommand, decoratee);

            // Act
            UpdateClientResponseDto response = await decorator.ExecuteAsync(request);

            // Assert
            A.CallTo(() => decoratee.ExecuteAsync(request)).MustHaveHappenedOnceExactly();
            A.CallTo(() => deactivateCommand.ExecuteAsync(A<DeactivateClientRequestDto>.That.Matches(x => x.ClientId == clientId))).MustHaveHappenedOnceExactly();
            Assert.AreEqual(decorateeResponse, response);
        }
    }
}
