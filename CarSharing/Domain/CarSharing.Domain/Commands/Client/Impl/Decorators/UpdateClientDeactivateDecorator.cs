namespace CarSharing.Domain.Commands.Client.Impl.Decorators
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Client.Request;
    using CarSharing.Domain.Dto.Client.Response;

    internal class UpdateClientDeactivateDecorator : IUpdateClientCommandAsync
    {
        private readonly IDeactivateClientCommandAsync _deactivateClientCommand;
        private readonly IUpdateClientCommandAsync _decoratee;

        public UpdateClientDeactivateDecorator(IDeactivateClientCommandAsync deactivateClientCommand,
            IUpdateClientCommandAsync decoratee)
        {
            _deactivateClientCommand = deactivateClientCommand ?? throw new ArgumentNullException(nameof(deactivateClientCommand));
            _decoratee = decoratee ?? throw new ArgumentNullException(nameof(decoratee));
        }

        public async Task<UpdateClientResponseDto> ExecuteAsync(UpdateClientRequestDto request)
        {
            UpdateClientResponseDto response = await _decoratee.ExecuteAsync(request).ConfigureAwait(false);

            if (response.Success && request != null)
            {
                DeactivateClientRequestDto deactivateRequest = new DeactivateClientRequestDto()
                {
                    ClientId = request.ClientId
                };

                await _deactivateClientCommand.ExecuteAsync(deactivateRequest).ConfigureAwait(false);
            }

            return response;
        }
    }
}
