namespace IRTxtDispatcher.Test;
using IRTxtDispatcher;
using IRTxtDispatcher.DTO;

public class NeginTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task SendingMessage()
    {
        IRTxtDispatcherOperation operation = new IRTxtDispatcherOperation(DTO.SupportedImplementationType.NEGIN, new DTO.SendConfiguration()
        {
            LineNumber = "83743847847348",
            Password = "45613781238",
            Username = "some user name"
        });

        var sendingMessage = new List<Send>
        {
            new Send()
            {
                Message = "323223",
                Number = "2323"
            }
        };
        var result = await operation.SendAsync(sendingMessage);
        if (result.Count > 0 && result.First().IsSuccess == false)
            Assert.Pass(result.FirstOrDefault().ErrorTitle);
        else
        {
            Assert.Fail();
        }
    }
}