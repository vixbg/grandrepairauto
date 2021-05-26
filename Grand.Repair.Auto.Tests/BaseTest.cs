using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrandRepairAuto.Tests
{
    public abstract class BaseTest<TDatabaseContext>
        where TDatabaseContext : DbContext
    {
        protected ServiceProvider serviceProvider;

        protected virtual void SetupServices(IServiceCollection services) {}

        [TestInitialize]
        public void TestSetup()
        {
            var builder = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .AddDbContext<TDatabaseContext>(options =>
                    options.UseInMemoryDatabase("GrandRepairAuto")
                        .UseInternalServiceProvider(serviceProvider));

            Startup.AddAutomapper(builder);

            SetupServices(builder);

            serviceProvider = builder.BuildServiceProvider();
        }

        [TestCleanup]
        public void TestClean()
        {
            serviceProvider?.Dispose();
        }

        protected void AssertEqualProperties(object left, object right)
        {
            Assert.IsNotNull(right, "Right compare object is null");
            Assert.IsNotNull(left, "Left compare object is null");

            var leftProps = left.GetType().GetProperties();
            var rightProps = right.GetType().GetProperties();

            foreach (var leftProp in leftProps)
            {
                var rightProp = rightProps.FirstOrDefault(p => p.Name == leftProp.Name);
                if (rightProp == null) continue;
                if (leftProp.PropertyType != rightProp.PropertyType) continue;

                var leftValue = leftProp.GetValue(left);
                var rightValue = rightProp.GetValue(right);

                Assert.AreEqual(leftValue, rightValue, 
                    $"Object property mismatch: {leftProp.Name} in object {left.GetType().Name}");
            }
        }
    }
}
