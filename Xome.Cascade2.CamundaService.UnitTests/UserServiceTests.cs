using NUnit.Framework;
using Moq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xome.Cascade2.CamundaService.Application.Services;
using Xome.Cascade2.CamundaService.Domain.Interfaces;
using Xome.Cascade2.CamundaService.Domain.Entities;
using Microsoft.Extensions.Options;

namespace UserManagementService.UnitTests
{
    [TestFixture]
    public class UserServiceTests
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;

        [SetUp]
        public void SetUp()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
        }
    }
}
