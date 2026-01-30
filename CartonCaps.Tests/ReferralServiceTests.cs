using CartonCaps.Application;
using CartonCaps.Application.Interfaces;
using CartonCaps.Data.Entities;
using CartonCaps.Data.Interfaces;
using CartonCaps.DeepLinkService.Dto;
using CartonCaps.DeepLinkService.Interface;
using CartonCaps.Dto;
using CartonCaps.Transversal;
using Moq;

namespace CartonCaps.Tests
{
    [TestClass]
    public class ReferralServiceTests
    {
        [TestMethod]
        public void GetReferralsByReferrer_ReturnsReferrals()
        {
            var referrerId = Guid.Parse("b8cbb6b9-6b22-4b71-a2c3-7f02a9c6e4f1");
            var page = 0;
            var size = 20;
            var expectedSize = 3;

            Referral[] referrals = [
                new Referral
                {
                    Channel = ReferralChannel.SMS,
                    FullName = "Joe Smith",
                    ReferrerUserId = Guid.Parse("b8cbb6b9-6b22-4b71-a2c3-7f02a9c6e4f1"),
                    Status = "Completed",
                    SubscriptionDate = DateTime.UtcNow.AddDays(-15),
                },
                new Referral
                {
                    Channel = ReferralChannel.EMAIL,
                    FullName = "Willam Parr",
                    ReferrerUserId = Guid.Parse("b8cbb6b9-6b22-4b71-a2c3-7f02a9c6e4f1"),
                    Status = "Completed",
                    SubscriptionDate = DateTime.UtcNow.AddDays(-1),
                },
                new Referral
                {
                    Channel = ReferralChannel.APP,
                    FullName = "Sonya Smith",
                    ReferrerUserId = Guid.Parse("b8cbb6b9-6b22-4b71-a2c3-7f02a9c6e4f1"),
                    Status = "Completed",
                    SubscriptionDate = DateTime.UtcNow.AddDays(-1),
                    ChannelDetail = AppChannelDetail.WHATSAPP
                }
            ];

            var referralMockRepository = new Mock<IReferralRepository>();
            var deepLinkMockService = new Mock<IDeepLinkService>();
            var templateMockService = new Mock<ITemplateService>();

            referralMockRepository.Setup(r => r.GetReferralsByReferrer(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>())).Returns(referrals);

            var referralService = new ReferralService(referralMockRepository.Object, deepLinkMockService.Object, templateMockService.Object);

            var result = referralService.GetReferralsByReferrerId(referrerId, page, size);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, expectedSize);
        }

        [TestMethod]
        public void GetReferralsByReferrer_ReturnsEmpty()
        {
            var referrerId = Guid.Parse("b8cbb6b9-6b22-4b71-a2c3-7f02a9c6e4f1");
            var page = 0;
            var size = 20;
            var expectedSize = 0;

            Referral[] referrals = [];

            var referralMockRepository = new Mock<IReferralRepository>();
            var deepLinkMockService = new Mock<IDeepLinkService>();
            var templateMockService = new Mock<ITemplateService>();

            referralMockRepository.Setup(r => r.GetReferralsByReferrer(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>())).Returns(referrals);

            var referralService = new ReferralService(referralMockRepository.Object, deepLinkMockService.Object, templateMockService.Object);

            var result = referralService.GetReferralsByReferrerId(referrerId, page, size);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, expectedSize);
        }

        [TestMethod]
        public void GetNewReferralShareMessge_ReturnsInvalidCode()
        {
            var deepLinkResponse = new DeepLinkResponseDto(false);
            var referrerId = Guid.Parse("b8cbb6b9-6b22-4b71-a2c3-7f02a9c6e4f1");
            var channel = ReferralChannel.SMS;
            var referralCode = "CODE1";

            var referralMockRepository = new Mock<IReferralRepository>();
            var deepLinkMockService = new Mock<IDeepLinkService>();
            var templateMockService = new Mock<ITemplateService>();

            deepLinkMockService.Setup(r => r.GetShareUrl(It.IsAny<Guid>(), It.IsAny<string>())).Returns(deepLinkResponse);

            var referralService = new ReferralService(referralMockRepository.Object, deepLinkMockService.Object, templateMockService.Object);

            var result = referralService.GetNewReferralShareMessge(referrerId, referralCode, channel, null);

            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void GetNewReferralShareMessge_ReturnsTemplateMessage()
        {
            var deepLinkResponse = new DeepLinkResponseDto(true, "www.share.com/CODE1");
            var templateMessage = new MessageTemplateDto("messageBody");
            var referrerId = Guid.Parse("b8cbb6b9-6b22-4b71-a2c3-7f02a9c6e4f1");
            var channel = ReferralChannel.SMS;
            var referralCode = "CODE1";

            var referralMockRepository = new Mock<IReferralRepository>();
            var deepLinkMockService = new Mock<IDeepLinkService>();
            var templateMockService = new Mock<ITemplateService>();

            deepLinkMockService.Setup(r => r.GetShareUrl(It.IsAny<Guid>(), It.IsAny<string>())).Returns(deepLinkResponse);
            templateMockService.Setup(r => r.GetMessageTemplateByChannel(It.IsAny<ReferralChannel>())).Returns(templateMessage);

            var referralService = new ReferralService(referralMockRepository.Object, deepLinkMockService.Object, templateMockService.Object);

            var result = referralService.GetNewReferralShareMessge(referrerId, referralCode, channel, null);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsValid);
        }
    }
}