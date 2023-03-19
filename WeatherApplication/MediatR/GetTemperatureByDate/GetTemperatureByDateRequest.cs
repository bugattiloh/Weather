using MediatR;

namespace Application.MediatR.GetTemperatureByDate;

public record GetTemperatureByDateRequest(DateTime Date) : IRequest<double>;