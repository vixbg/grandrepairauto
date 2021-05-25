using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using GrandRepairAuto.Data.Models.Contracts;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Services;

namespace GrandRepairAuto.Tests.ServiceTests
{
    
    public abstract class GenericServiceTest<TService, TEntity, TPrimaryKey, TPrimaryDTO, TCreateDTO, TUpdateDTO> 
        where TEntity : class, IEntity<TPrimaryKey>, ISoftDeletable
        where TPrimaryDTO : class, IDTO
        where TCreateDTO : class, IDTO
        where TUpdateDTO : class, IDTO
        where TService : GenericService<TEntity, TPrimaryKey, TPrimaryDTO, TCreateDTO, TUpdateDTO>
    {
        protected ServiceProvider serviceProvider;
        protected TService service;

        [TestInitialize]
        public void TestSetup()
        {
            var services = new ServiceCollection();
            services.AddSingleton(Mock.Of<IMapper>());
            services.AddSingleton<TService>();
            serviceProvider = services.BuildServiceProvider();

            service = serviceProvider.GetRequiredService<TService>();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            serviceProvider.Dispose();
            serviceProvider = null;
        }
    }
}
