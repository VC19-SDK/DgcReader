using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using DgcReader.Interfaces.RulesValidators;

#if NETFRAMEWORK
using System.Net;
#endif

#if NET452
using System.Net.Http;
#else
using Microsoft.Extensions.DependencyInjection;
#endif

namespace DgcReader.RuleValidators.Italy.Test
{
    [TestClass]
    public class ItalianRulesValidatorTests : TestBase
    {
        DgcItalianRulesValidator Validator { get; set; }

        [TestInitialize]
        public void Initialize()
        {

#if NET452
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            var httpClient = new HttpClient();
            Validator = DgcItalianRulesValidator.Create(httpClient);
#else
            Validator = ServiceProvider.GetRequiredService<DgcItalianRulesValidator>();

#endif
        }


        [TestMethod]
        public async Task TestRefreshRulesList()
        {
            await Validator.RefreshRules();
        }

        [TestMethod]
        public async Task TestUnsupportedCountry()
        {
            var country = "DE";
            var supported = await Validator.SupportsCountry(country);

            Assert.IsFalse(supported);
        }

        [TestMethod]
        public async Task TestSupportedCountry()
        {
            var country = "IT";
            var supported = await Validator.SupportsCountry(country);

            Assert.IsTrue(supported);
        }


#if !NET452

        [TestMethod]
        public void TestGetDgcItalianRulesValidatorService()
        {
            var service = ServiceProvider.GetService<DgcItalianRulesValidator>();
            Assert.IsNotNull(service);
        }

        [TestMethod]
        public void TestGetIRulesValidatorSerice()
        {
            var interfaceService = ServiceProvider.GetService<IRulesValidator>();
            Assert.IsNotNull(interfaceService);

            var service = ServiceProvider.GetService<DgcItalianRulesValidator>();
            Assert.AreSame(service, interfaceService);
        }

        protected override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddDgcReader()
                .AddItalianRulesValidator();
        }
#endif
    }
}
