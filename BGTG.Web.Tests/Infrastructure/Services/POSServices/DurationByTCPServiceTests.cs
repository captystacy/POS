﻿using BGTG.POS.DurationTools.DurationByTCPTool;
using BGTG.POS.DurationTools.DurationByTCPTool.Interfaces;
using BGTG.Web.Infrastructure.Services.POSServices;
using BGTG.Web.ViewModels.POSViewModels.DurationByTCPViewModels;
using Microsoft.AspNetCore.Hosting;
using Moq;
using NUnit.Framework;

namespace BGTG.Web.Tests.Infrastructure.Services.POSServices
{
    public class DurationByTCPServiceTests
    {
        private DurationByTCPService _durationByTCPService;
        private Mock<IDurationByTCPCreator> _durationByTCPCreatorMock;
        private Mock<IDurationByTCPWriter> _durationByTCPWriterMock;
        private Mock<IWebHostEnvironment> _webHostEnvironmentMock;

        [SetUp]
        public void SetUp()
        {
            _durationByTCPCreatorMock = new Mock<IDurationByTCPCreator>();
            _durationByTCPWriterMock = new Mock<IDurationByTCPWriter>();
            _webHostEnvironmentMock = new Mock<IWebHostEnvironment>();
            _durationByTCPService = new DurationByTCPService(_durationByTCPCreatorMock.Object, _durationByTCPWriterMock.Object, _webHostEnvironmentMock.Object);
        }

        [Test]
        public void Write()
        {
            var durationByTCP = new InterpolationDurationByTCP("", 0, "", 0, null,
                DurationCalculationType.Interpolation, 0, 0, 0, 0, 0, 'A', 0);

            var durationByTCPCreateViewModel = new DurationByTCPCreateViewModel();
            var identityName = "BGTG\\kss";

            var templatePath = @"wwwroot\AppData\Templates\DurationByTCPTemplates\Interpolation.docx";
            var savePath = @"wwwroot\AppData\UserFiles\DurationByTCPFiles\BGTGkss.docx";

            _webHostEnvironmentMock.Setup(x => x.ContentRootPath).Returns("wwwroot");

            _durationByTCPCreatorMock.Setup(x => x.Create(durationByTCPCreateViewModel.PipelineMaterial,
                durationByTCPCreateViewModel.PipelineDiameter, durationByTCPCreateViewModel.PipelineLength, durationByTCPCreateViewModel.AppendixKey,
                durationByTCPCreateViewModel.PipelineCategoryName)).Returns(durationByTCP);

            var result = _durationByTCPService.Write(durationByTCPCreateViewModel, identityName);

            Assert.AreEqual(durationByTCP, result);
            _webHostEnvironmentMock.VerifyGet(x => x.ContentRootPath, Times.Exactly(2));
            _durationByTCPCreatorMock.Verify(x => x.Create(durationByTCPCreateViewModel.PipelineMaterial,
                durationByTCPCreateViewModel.PipelineDiameter, durationByTCPCreateViewModel.PipelineLength, durationByTCPCreateViewModel.AppendixKey,
                durationByTCPCreateViewModel.PipelineCategoryName), Times.Once);
            _durationByTCPWriterMock.Verify(x => x.Write(durationByTCP, templatePath , savePath), Times.Once);
        }

        [Test]
        public void GetSavePath()
        {
            _webHostEnvironmentMock.Setup(x => x.ContentRootPath).Returns("wwwroot");
            var identityName = "BGTG\\kss";

            var savePath = _durationByTCPService.GetSavePath(identityName);

            _webHostEnvironmentMock.VerifyGet(x => x.ContentRootPath, Times.Once);
            Assert.AreEqual(@"wwwroot\AppData\UserFiles\DurationByTCPFiles\BGTGkss.docx", savePath);
        }
    }
}
