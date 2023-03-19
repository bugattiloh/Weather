using MediatR;

namespace Application.MediatR.SaveTemperatureByDate;

public record SaveTemperatureByDateCommand(DateTime Date) : IRequest;

    
