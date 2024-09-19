using IRTxtDispatcher.DTO;

namespace IRTxtDispatcher.Interface
{
    internal interface IOperation
    {
        Task<List<SendResult>> SendAsync(List<Send> messages);
        string ImplementSummery();
    }
}