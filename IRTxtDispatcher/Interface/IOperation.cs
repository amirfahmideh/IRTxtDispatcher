using IRTxtDispatcher.DTO;

namespace IRTxtDispatcher.Interface
{
    internal interface IOperation
    {
        Task<List<SendResult>> SendAsync(SendConfiguration configuration, List<Send> messages);
        string ImplementSummery();
        string ServerUrl { get; }
    }
}