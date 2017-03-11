using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Backlog.Features.Epics.GetEpicsQuery;
using Backlog.UnitTests.Mocks;
using Backlog.Data;
using Moq;
using Backlog.Data.Model;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using EntityFramework.Testing;

namespace Backlog.UnitTests.Features.Epics
{
    [TestClass]
    public class GetEpicsQueryTest
    {        
        [TestMethod]
        public async System.Threading.Tasks.Task HandleGetEpicsQuery()
        {
            var epics = new List<Epic> {
                new Epic() {
                    Product = new Product(),
                    Stories = new List<Story>()
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Epic>>();

            mockSet.As<IDbAsyncEnumerable<Epic>>().Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<Epic>(epics.GetEnumerator()));

            mockSet.As<IQueryable<Epic>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<Epic>(epics.Provider));

            mockSet.As<IQueryable<Epic>>().Setup(m => m.Expression).Returns(epics.Expression);

            mockSet.As<IQueryable<Epic>>().Setup(m => m.ElementType).Returns(epics.ElementType);

            mockSet.As<IQueryable<Epic>>().Setup(m => m.GetEnumerator()).Returns(epics.GetEnumerator());
            
            Mock<IBacklogContext> mockContext = new Mock<IBacklogContext>();

            mockContext.Setup(c => c.Epics).Returns(mockSet.Object);
            
            _getEpicsHandler = new GetEpicsHandler(mockContext.Object, new MockCache());

            var results = await _getEpicsHandler.Handle(new GetEpicsRequest());

            Assert.AreEqual(results.Epics.Count(), 1);
            
        }

        private GetEpicsHandler _getEpicsHandler;
    }
}
