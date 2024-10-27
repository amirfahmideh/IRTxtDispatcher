using System.Net;
using IRTxtDispatcher.DTO;
using IRTxtDispatcher.Interface;
using Microsoft.VisualBasic;
using System.Text.Json;

namespace IRTxtDispatcher.Implementation;

public class KavenegarImpl : IOperation
{
    public KavenegarImpl()
    {

    }
    public string ServerUrl => string.Empty;

    public string ImplementSummery()
    {
        return "کاوه نگار";
    }

    public async Task<List<SendResult>> SendAsync(SendConfiguration configuration, List<Send> messages)
    {
        Kavenegar.KavenegarApi api = new Kavenegar.KavenegarApi(configuration.ApiKey);
        List<SendResult> sendingResults = [];
        foreach (var message in messages)
        {
            try
            {
                var result = await api.Send(configuration.LineNumber, message.Number, message.Message);
                if (result != null)
                {
                    sendingResults.Add(new SendResult
                    {
                        UniqueId = result.Messageid.ToString(),
                        Message = result.Message,
                        IsSuccess = true,
                        LineNumber = configuration.LineNumber ?? string.Empty,
                        Number = result.Receptor
                    });
                }
            }
            catch (Kavenegar.Core.Exceptions.ApiException ex)
            {
                sendingResults.Add(new SendResult()
                {
                    IsSuccess = false,
                    ErrorCode = message.Number,
                    ErrorTitle = ex.Message,
                });
                continue;
            }
            catch (Kavenegar.Core.Exceptions.KavenegarException ex)
            {
                sendingResults.Add(new SendResult()
                {
                    IsSuccess = false,
                    ErrorCode = message.Number,
                    ErrorTitle = ex.Message,
                });
                continue;
            }
            catch (Exception ex)
            {
                sendingResults.Add(new SendResult()
                {
                    IsSuccess = false,
                    ErrorCode = message.Number,
                    ErrorTitle = ex.Message,
                });
                continue;
            }
        }
        return sendingResults;
    }
}