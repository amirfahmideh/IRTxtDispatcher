namespace IRTxtDispatcher.Test;

using System.Configuration;
using IRTxtDispatcher;
using IRTxtDispatcher.DTO;

public class KaveNegarTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task SendingMessage()
    {
        IRTxtDispatcherOperation operation = new IRTxtDispatcherOperation(DTO.SupportedImplementationType.KAVENEGAR, new DTO.SendConfiguration()
        {
            ApiKey = "",
            LineNumber = "213123",
            Password = "12312323123",
            Username = "123123123"
        });

        var sendingMessage = new List<Send>
        {
            new Send()
            {
                Message = "تست سامانه ارسال پیام کوتاه",
                Number = string.Empty
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