using CartonCaps.Application;
using CartonCaps.Transversal;

namespace CartonCaps.Tests
{
    [TestClass]
    public class RegisterServiceTests
    {
        [TestMethod]
        public void GetOnboardingForm_ReturnsReferred()
        {
            var onboardingFormExpected = OnboardingForm.REFERRED;

            var registerService = new RegisterService();

            var result = registerService.GetOnboardingForm("CODE1");

            Assert.IsNotNull(result);
            Assert.AreEqual(onboardingFormExpected, result);
        }

        [TestMethod]
        public void GetOnboardingForm_ReturnsDefault()
        {
            var onboardingFormExpected = OnboardingForm.DEFAULT;

            var registerService = new RegisterService();

            var result = registerService.GetOnboardingForm(null);

            Assert.IsNotNull(result);
            Assert.AreEqual(onboardingFormExpected, result);
        }
    }
}
