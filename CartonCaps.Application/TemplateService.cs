using CartonCaps.Application.Interfaces;
using CartonCaps.Dto;
using CartonCaps.Transversal;
using Microsoft.Extensions.Options;

namespace CartonCaps.Application
{
    public class TemplateService(IOptions<MessageTemplateOptions> messageTemplateOptions) : ITemplateService
    {
        private readonly MessageTemplateOptions _messageTemplateOptions = messageTemplateOptions.Value;

        public MessageTemplateDto GetMessageTemplateByChannel(ReferralChannel channel)
        {
            return channel switch
            {
                ReferralChannel.EMAIL => new MessageTemplateDto(_messageTemplateOptions.Email, _messageTemplateOptions.Subject),
                ReferralChannel.SMS => new MessageTemplateDto(_messageTemplateOptions.Sms),
                ReferralChannel.APP => new MessageTemplateDto(_messageTemplateOptions.App),
                _ => throw new NotImplementedException("Invalid channel")
            };
        }
    }
}
