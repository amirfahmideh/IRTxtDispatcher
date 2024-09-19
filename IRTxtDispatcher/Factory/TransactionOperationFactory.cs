using IRTxtDispatcher.DTO;
using IRTxtDispatcher.Exceptions;
using IRTxtDispatcher.Implementation;
using IRTxtDispatcher.Interface;
namespace PaymentTerminalManager.Factory;
internal class OperationFactory
{
    internal static IOperation CreateOperation(SupportedImplementationType supported)
    {
        return supported switch
        {
            SupportedImplementationType.NEGIN => new Negin(),
            _ => throw new NotImplementException($"درگاه ارسال از نوع {supported} پیاده سازی نشده است"),
        };
    }
}