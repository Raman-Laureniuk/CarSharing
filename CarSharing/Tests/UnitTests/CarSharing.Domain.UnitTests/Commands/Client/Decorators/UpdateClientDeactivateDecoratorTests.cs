namespace CarSharing.Domain.UnitTests.Commands.Client.Decorators
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Commands.Client;
    using CarSharing.Domain.Commands.Client.Impl.Decorators;
    using CarSharing.Domain.Dto.Client.Request;
    using CarSharing.Domain.Tools.Result;
    using FakeItEasy;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UpdateClientDeactivateDecoratorTests
    {
        [TestMethod]
        public async Task ExecuteAsync_NullRequest_DeactivateNotCalled()
        {
            // Arrange
            UpdateClientRequestDto        request           = null;
            IDeactivateClientCommandAsync deactivateCommand = A.Fake<IDeactivateClientCommandAsync>();
            IUpdateClientCommandAsync     decoratee         = A.Fake<IUpdateClientCommandAsync>();
            Result                        decorateeResult   = Result.Error(new ErrorDetails("test"));
            
            A.CallTo (() => decoratee.ExecuteAsync(request))
             .Returns(decorateeResult);
            
            UpdateClientDeactivateDecorator decorator = new UpdateClientDeactivateDecorator(deactivateCommand, decoratee);

            // Act
            Result result = await decorator.ExecuteAsync(request);

            // Assert
            A.CallTo(() => decoratee        .ExecuteAsync(request))                        .MustHaveHappenedOnceExactly();
            A.CallTo(() => deactivateCommand.ExecuteAsync(A<DeactivateClientRequestDto>._)).MustNotHaveHappened();
            Assert.AreEqual(decorateeResult.IsSuccess,             result.IsSuccess);
            Assert.AreEqual(decorateeResult.ErrorDetails?.Message, result.ErrorDetails?.Message);
        }

        [TestMethod]
        public async Task ExecuteAsync_SuccessFalse_DeactivateNotCalled()
        {
            // Arrange
            UpdateClientRequestDto        request           = new UpdateClientRequestDto()
            {
                ClientId = Guid.NewGuid(),
                Name = "new_name"
            };
            IDeactivateClientCommandAsync deactivateCommand = A.Fake<IDeactivateClientCommandAsync>();
            Result                        decorateeResult   = Result.Error(new ErrorDetails("test"));
            IUpdateClientCommandAsync     decoratee         = A.Fake<IUpdateClientCommandAsync>();

            A.CallTo(() => decoratee.ExecuteAsync(request))
             .Returns(decorateeResult);

            UpdateClientDeactivateDecorator decorator = new UpdateClientDeactivateDecorator(deactivateCommand, decoratee);

            // Act
            Result result = await decorator.ExecuteAsync(request);

            // Assert
            A.CallTo(() => decoratee.ExecuteAsync(request))                                .MustHaveHappenedOnceExactly();
            A.CallTo(() => deactivateCommand.ExecuteAsync(A<DeactivateClientRequestDto>._)).MustNotHaveHappened();
            Assert.AreEqual(decorateeResult.IsSuccess, result.IsSuccess);
            Assert.AreEqual(decorateeResult.ErrorDetails?.Message, result.ErrorDetails?.Message);
        }

        [TestMethod]
        public async Task ExecuteAsync_SuccessTrue_DeactivateCalled()
        {
            // Arrange
            Guid                          clientId          = Guid.NewGuid();
            UpdateClientRequestDto        request           = new UpdateClientRequestDto()
            {
                ClientId = clientId,
                Name = "new_name"
            };

            IDeactivateClientCommandAsync deactivateCommand = A.Fake<IDeactivateClientCommandAsync>();
            Result                        decorateeResult   = Result.Success();
            IUpdateClientCommandAsync     decoratee         = A.Fake<IUpdateClientCommandAsync>();
            
            A.CallTo(() => decoratee.ExecuteAsync(request))
             .Returns(decorateeResult);

            UpdateClientDeactivateDecorator decorator = new UpdateClientDeactivateDecorator(deactivateCommand, decoratee);

            // Act
            Result result = await decorator.ExecuteAsync(request);

            // Assert
            A.CallTo(() => decoratee.ExecuteAsync(request))                                                                        .MustHaveHappenedOnceExactly();
            A.CallTo(() => deactivateCommand.ExecuteAsync(A<DeactivateClientRequestDto>.That.Matches(x => x.ClientId == clientId))).MustHaveHappenedOnceExactly();
            Assert.AreEqual(decorateeResult.IsSuccess, result.IsSuccess);
            Assert.AreEqual(decorateeResult.ErrorDetails?.Message, result.ErrorDetails?.Message);
        }
    }
}
