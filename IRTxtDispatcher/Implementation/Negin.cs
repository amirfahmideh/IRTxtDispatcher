using IRTxtDispatcher.DTO;
using IRTxtDispatcher.Interface;

namespace IRTxtDispatcher.Implementation;
public class Negin : IOperation
{
    public string ImplementSummery()
    {
        throw new NotImplementedException();
    }

    public Task<List<SendResult>> SendAsync(List<Send> messages)
    {
        throw new NotImplementedException();
    }
}