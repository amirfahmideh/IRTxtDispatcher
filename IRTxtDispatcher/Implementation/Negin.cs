using IRTxtDispatcher.DTO;
using IRTxtDispatcher.Interface;

namespace IRTxtDispatcher.Implementation;
public class Negin : IOperation
{
    public string ServerUrl => "https://sms.3300.ir/api/wssend.ashx";

    public string ImplementSummery()
    {
        return "نگین ارتباط الماس";
    }

    public Task<List<SendResult>> SendAsync(SendConfiguration configuration, List<Send> messages)
    {
        var client = new HttpClient();
        var data = new List<KeyValuePair<string, string>>
        {
        new KeyValuePair<string, string>("username","USERNAME"),
        new KeyValuePair<string, string>("password","PASSWORD" ),
        new KeyValuePair<string, string>("mobile","09395213300" ),
        new KeyValuePair<string, string>("message","MESSAGE_TEXT" ),
        new KeyValuePair<string, string>("line","983000...." ),
        // new KeyValuePair<string, string>("type","2" ), برای ارسال پیامک فعالسازی با خط خدماتی شرکت
        };
        var response = client.PostAsync("https://sms.3300.ir/api/wssend.ashx", new FormUrlEncodedContent(data)).Result;
        Console.Write(response.Content.ReadAsStringAsync().Result);
        throw new NotImplementedException();
    }
}