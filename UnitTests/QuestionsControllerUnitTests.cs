using Microsoft.AspNetCore.Mvc;
using Moq;
using QuizPlatform.Core.Abstractions.Repositories;
using QuizPlatform.Core.Domain.QuestionManagment;
using QuizPlatformAPI.Controllers;
using QuizPlatformAPI.Models;
using System;
using Xunit;

namespace UnitTests
{
    public class QuestionsControllerUnitTests : IClassFixture<FixtureForControllers>
    {

        private QuestionsController _questionsController;

        /// <summary>
        /// Mocks
        /// </summary>
        private Mock<IRepository<Question>> _repositoryQuestionsMock = new Mock<IRepository<Question>>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="controllerFixture"></param>
        public QuestionsControllerUnitTests(FixtureForControllers controllerFixture)
        {
            var provider = controllerFixture.ServiceProvider;
            _questionsController = new QuestionsController(_repositoryQuestionsMock.Object);
        }

        [Fact]
        public async void CreatetQuestionAsync_when_questionWithTimer_and_timerEqualsNull_Return_BadRequest()
        {
            //Arrange
            var dto = new QuestionRequestDto(){Description = "string", WithTimer = true, TimerInSeconds = 0};

            //Act
            var result = await _questionsController.CreatetQuestionAsync(dto);

            //Assert
            Assert.IsType<BadRequestResult>(result.Result);
  
        }
    }
}
