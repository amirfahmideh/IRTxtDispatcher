using IRTxtDispatcher.DTO;
using IRTxtDispatcher.Interface;
using PaymentTerminalManager.Factory;

namespace IRTxtDispatcher;

public class IRTxtDispatcherOperation
{
    private readonly SendConfiguration configuration;
    private readonly IOperation operation;
    public IRTxtDispatcherOperation(SupportedImplementationType _type, SendConfiguration _configuration)
    {
        configuration = _configuration;
        operation = OperationFactory.CreateOperation(_type);
    }
    public async Task<List<SendResult>> SendAsync(List<Send> messages)
    {
        return await operation.SendAsync(configuration, messages);
    }
}
