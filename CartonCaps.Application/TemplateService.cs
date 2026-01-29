using CartonCaps.Application.Interfaces;
using CartonCaps.Dto;
using CartonCaps.Transversal;
using Microsoft.Extensions.Options;

namespace CartonCaps.Application
{
    public class TemplateService(IOptions<MessageTemplateOptions> messageTemplateOptions) : ITemplateService
    {
        private readonly MessageTemplateOptions _messageTemplateOptions = messageTemplateOptions.Value;

        public MessageTemplate GetMessageTemplateByChannel(ReferralChannel channel)
        {
            return channel switch
            {
                ReferralChannel.EMAIL => new MessageTemplate(_messageTemplateOptions.Email, _messageTemplateOptions.Subject),
                ReferralChannel.SMS => new MessageTemplate(_messageTemplateOptions.Sms),
                ReferralChannel.APP => new MessageTemplate(_messageTemplateOptions.App),
                _ => throw new NotImplementedException("Invalid channel")
            };
        }
    }
}
