using System.ComponentModel.DataAnnotations;

namespace IRTxtDispatcher.DTO;
public enum SupportedImplementationType
{
    [Display(Name = "نگین ارتباط الماس")]
    NEGIN = 1,
    [Display(Name = "کاوه نگار")]
    KAVENEGAR = 2
}