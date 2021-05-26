using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using GrandRepairAuto.Data.Models.Contracts;
using GrandRepairAuto.Repository.Contracts;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Services;
using Microsoft.EntityFrameworkCore;

namespace GrandRepairAuto.Tests.ServiceTests
{
    
    public abstract class GenericServiceTest<TService, TIRepository, TEntity, TPrimaryKey, TPrimaryDTO, TCreateDTO, TUpdateDTO, TContext> : BaseTest<TContext>
        where TContext : DbContext
        where TEntity : class, IEntity<TPrimaryKey>, ISoftDeletable
        where TIRepository : class, IGenericRepository<TEntity, TPrimaryKey>
        where TPrimaryDTO : class, IDTO
        where TCreateDTO : class, IDTO
        where TUpdateDTO : class, IDTO
        where TService : GenericService<TEntity, TPrimaryKey, TPrimaryDTO, TCreateDTO, TUpdateDTO>
    {
        private Mock<TIRepository> repoMock;

        public abstract TCreateDTO CreateInput { get; }
        public abstract TUpdateDTO UpdateInput { get; }

        protected override void SetupServices(IServiceCollection services)
        {
            repoMock = new Mock<TIRepository>();
            services.AddSingleton(repoMock.Object);
            services.AddSingleton<TService>();
        }

        [TestMethod]
        public void CreateShouldReturnValidEntity()
        {
            repoMock.Setup(r => r.Insert(It.IsAny<TEntity>())).Verifiable();
            var result = serviceProvider.GetService<TService>().Create(CreateInput);
            repoMock.Verify();
            AssertEqualProperties(result, CreateInput);
        }

        [TestMethod]
        public void GetByIdShouldReturnEntity()
        {
            var mapper = serviceProvider.GetService<IMapper>();
            repoMock.Setup(r => r.GetByID(It.IsAny<TPrimaryKey>())).Returns(mapper.Map<TEntity>(CreateInput)).Verifiable();
            var result = serviceProvider.GetService<TService>().GetByID(default);
            repoMock.Verify();
            AssertEqualProperties(result, CreateInput);
        }

        [TestMethod]
        public void GetAllShouldReturnEntitiesNoFilter()
        {
            var mapper = serviceProvider.GetService<IMapper>();
            repoMock.Setup(r =>
                r.Get(
                    It.IsAny<Expression<Func<TEntity, bool>>>(),
                    It.IsAny<Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>>(),
                    It.IsAny<string>()
                )
            ).Returns(new List<TEntity>() { mapper.Map<TEntity>(CreateInput) }.AsQueryable())
             .Verifiable();
            var result = serviceProvider.GetService<TService>().GetAll();
            Assert.AreEqual(1, result.Count());
            AssertEqualProperties(result.First(), CreateInput);
        }

        [TestMethod]
        public void UpdateShouldUpdateEntity()
        {
            var mapper = serviceProvider.GetService<IMapper>();
            repoMock.Setup(r => r.GetByID(It.IsAny<TPrimaryKey>())).Returns(mapper.Map<TEntity>(CreateInput)).Verifiable();
            repoMock.Setup(r => r.Update(It.IsAny<TEntity>())).Verifiable();
            var result = serviceProvider.GetService<TService>().Update(UpdateInput, default);
            mapper.Map(UpdateInput, CreateInput);
            AssertEqualProperties(result, CreateInput);
        }

        [TestMethod]
        public void DeleteShouldReturnTrue()
        {
            repoMock.Setup(r => r.Delete(It.IsAny<TPrimaryKey>())).Returns(true).Verifiable();
            var result = serviceProvider.GetService<TService>().Delete(default);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RestoreShouldReturnTrue()
        {
            repoMock.Setup(r => r.Restore(It.IsAny<TPrimaryKey>())).Returns(true).Verifiable();
            var result = serviceProvider.GetService<TService>().Restore(default);
            Assert.IsTrue(result);
        }
    }
}
