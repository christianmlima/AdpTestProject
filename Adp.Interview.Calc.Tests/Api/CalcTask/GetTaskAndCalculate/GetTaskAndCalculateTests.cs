using Adp.Interview.Calc.App.Api.CalcTask.GetTaskAndCalculate;
using Adp.Interview.Calc.Domain.Models.CalcTaskAggregate;
using Adp.Interview.Calc.Integrations.Task;
using Adp.Interview.Calc.Shared.ApiUtilities;
using Moq;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Adp.Interview.Calc.Tests.Api.CalcTask.GetTaskAndCalculate
{
    public class GetTaskAndCalculateTests
    {
        private readonly Mock<ITaskClient> _clientMock;
        private readonly Mock<ICalcTaskRepository> _repositoryMock;
        private readonly GetTaskAndCalculateHandler _handler;

        public GetTaskAndCalculateTests()
        {
            _clientMock = new Mock<ITaskClient>();
            _repositoryMock = new Mock<ICalcTaskRepository>();

            _handler = new GetTaskAndCalculateHandler(_clientMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async void GetTaskAndCalculateHandler_Addition_Success()
        {
            //Arrange
            using var cts = new CancellationTokenSource();

            var calcTask = Domain.Models.CalcTaskAggregate.CalcTask.Create(Guid.NewGuid(), "addition", 2, 2);
            var httpResponseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.OK);

            _clientMock.Setup(x => x.GetTaskAsync())
                .Returns(new ValueTask<Domain.Models.CalcTaskAggregate.CalcTask>(calcTask));
            _clientMock.Setup(x => x.SubmitTaskAsync(It.IsAny<CalcTaskResult>(), cts.Token))
                .ReturnsAsync(httpResponseMessage);

            _repositoryMock.Setup(x => x.AddCalcTaskAsync(It.IsAny<Domain.Models.CalcTaskAggregate.CalcTask>(), cts.Token))
                .Returns(new ValueTask());
            _repositoryMock.Setup(x => x.AddCalcTaskResultAsync(It.IsAny<CalcTaskResult>(), cts.Token))
                .Returns(new ValueTask());

            var message = "Success - The result was validated";
            //Act
            var r = await _handler.Handle(new GetTaskAndCalculateRequestDto(), cts.Token);

            //Assert
            Assert.Equal(ResponseStatus.OK, r.Status);
            Assert.Equal(message, r.AdpResponseDescription);
            Assert.Equal(4, r.Result);
            Assert.Null(r.BadRequestReason);
        }

        [Fact]
        public async void GetTaskAndCalculateHandler_Multiplication_Success()
        {
            //Arrange
            using var cts = new CancellationTokenSource();

            var calcTask = Domain.Models.CalcTaskAggregate.CalcTask.Create(Guid.NewGuid(), "multiplication", 3, 3);
            var httpResponseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.OK);

            _clientMock.Setup(x => x.GetTaskAsync())
                .Returns(new ValueTask<Domain.Models.CalcTaskAggregate.CalcTask>(calcTask));
            _clientMock.Setup(x => x.SubmitTaskAsync(It.IsAny<CalcTaskResult>(), cts.Token))
                .ReturnsAsync(httpResponseMessage);

            _repositoryMock.Setup(x => x.AddCalcTaskAsync(It.IsAny<Domain.Models.CalcTaskAggregate.CalcTask>(), cts.Token))
                .Returns(new ValueTask());
            _repositoryMock.Setup(x => x.AddCalcTaskResultAsync(It.IsAny<CalcTaskResult>(), cts.Token))
                .Returns(new ValueTask());

            var message = "Success - The result was validated";
            //Act
            var r = await _handler.Handle(new GetTaskAndCalculateRequestDto(), cts.Token);

            //Assert
            Assert.Equal(message, r.AdpResponseDescription);
            Assert.Equal(ResponseStatus.OK, r.Status);
            Assert.Equal(9, r.Result);
            Assert.Null(r.BadRequestReason);

        }

        [Fact]
        public async void GetTaskAndCalculateHandler_Subtraction_Success()
        {
            //Arrange
            using var cts = new CancellationTokenSource();

            var calcTask = Domain.Models.CalcTaskAggregate.CalcTask.Create(Guid.NewGuid(), "subtraction", 4, 2);
            var httpResponseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.OK);

            _clientMock.Setup(x => x.GetTaskAsync())
                .Returns(new ValueTask<Domain.Models.CalcTaskAggregate.CalcTask>(calcTask));
            _clientMock.Setup(x => x.SubmitTaskAsync(It.IsAny<CalcTaskResult>(), cts.Token))
                .ReturnsAsync(httpResponseMessage);

            _repositoryMock.Setup(x => x.AddCalcTaskAsync(It.IsAny<Domain.Models.CalcTaskAggregate.CalcTask>(), cts.Token))
                .Returns(new ValueTask());
            _repositoryMock.Setup(x => x.AddCalcTaskResultAsync(It.IsAny<CalcTaskResult>(), cts.Token))
                .Returns(new ValueTask());

            var message = "Success - The result was validated";
            //Act
            var r = await _handler.Handle(new GetTaskAndCalculateRequestDto(), cts.Token);

            //Assert
            Assert.Equal(ResponseStatus.OK, r.Status);
            Assert.Equal(message, r.AdpResponseDescription);
            Assert.Equal(2, r.Result);
            Assert.Null(r.BadRequestReason);
        }

        [Fact]
        public async void GetTaskAndCalculateHandler_Remainder_Success()
        {
            //Arrange
            using var cts = new CancellationTokenSource();

            var calcTask = Domain.Models.CalcTaskAggregate.CalcTask.Create(Guid.NewGuid(), "remainder", 9, 2);
            var httpResponseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.OK);

            _clientMock.Setup(x => x.GetTaskAsync())
                .Returns(new ValueTask<Domain.Models.CalcTaskAggregate.CalcTask>(calcTask));
            _clientMock.Setup(x => x.SubmitTaskAsync(It.IsAny<CalcTaskResult>(), cts.Token))
                .ReturnsAsync(httpResponseMessage);

            _repositoryMock.Setup(x => x.AddCalcTaskAsync(It.IsAny<Domain.Models.CalcTaskAggregate.CalcTask>(), cts.Token))
                .Returns(new ValueTask());
            _repositoryMock.Setup(x => x.AddCalcTaskResultAsync(It.IsAny<CalcTaskResult>(), cts.Token))
                .Returns(new ValueTask());

            var message = "Success - The result was validated";
            //Act
            var r = await _handler.Handle(new GetTaskAndCalculateRequestDto(), cts.Token);

            //Assert
            Assert.Equal(ResponseStatus.OK, r.Status);
            Assert.Equal(message, r.AdpResponseDescription);
            Assert.Equal(1, r.Result);
            Assert.Null(r.BadRequestReason);
        }

        [Fact]
        public async void GetTaskAndCalculateHandler_Division_Success()
        {
            //Arrange
            using var cts = new CancellationTokenSource();

            var calcTask = Domain.Models.CalcTaskAggregate.CalcTask.Create(Guid.NewGuid(), "division", 6, 2);
            var httpResponseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.OK);

            _clientMock.Setup(x => x.GetTaskAsync())
                .Returns(new ValueTask<Domain.Models.CalcTaskAggregate.CalcTask>(calcTask));
            _clientMock.Setup(x => x.SubmitTaskAsync(It.IsAny<CalcTaskResult>(), cts.Token))
                .ReturnsAsync(httpResponseMessage);

            _repositoryMock.Setup(x => x.AddCalcTaskAsync(It.IsAny<Domain.Models.CalcTaskAggregate.CalcTask>(), cts.Token))
                .Returns(new ValueTask());
            _repositoryMock.Setup(x => x.AddCalcTaskResultAsync(It.IsAny<CalcTaskResult>(), cts.Token))
                .Returns(new ValueTask());

            var message = "Success - The result was validated";
            //Act
            var r = await _handler.Handle(new GetTaskAndCalculateRequestDto(), cts.Token);

            //Assert
            Assert.Equal(ResponseStatus.OK, r.Status);
            Assert.Equal(message, r.AdpResponseDescription);
            Assert.Equal(3, r.Result);
            Assert.Null(r.BadRequestReason);
        }
        [Fact]
        public async void GetTaskAndCalculateHandler_BadRequest()
        {
            //Arrange
            using var cts = new CancellationTokenSource();

            var calcTask = Domain.Models.CalcTaskAggregate.CalcTask.Create(Guid.NewGuid(), "addition", 876876, 76876);
            var httpResponseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);

            _clientMock.Setup(x => x.GetTaskAsync())
                .Returns(new ValueTask<Domain.Models.CalcTaskAggregate.CalcTask>(calcTask));
            _clientMock.Setup(x => x.SubmitTaskAsync(It.IsAny<CalcTaskResult>(), cts.Token))
                .ReturnsAsync(httpResponseMessage);

            _repositoryMock.Setup(x => x.AddCalcTaskAsync(It.IsAny<Domain.Models.CalcTaskAggregate.CalcTask>(), cts.Token))
                .Returns(new ValueTask());
            _repositoryMock.Setup(x => x.AddCalcTaskResultAsync(It.IsAny<CalcTaskResult>(), cts.Token))
                .Returns(new ValueTask());

            var message = "BadRequest - Incorrect value in result; No ID specified;Value is invalid";

            //Act
            var r = await _handler.Handle(new GetTaskAndCalculateRequestDto(), cts.Token);

            //Assert
            Assert.Equal(message, r.AdpResponseDescription);
            Assert.Equal(ResponseStatus.OK, r.Status);
        }

        [Fact]
        public async void GetTaskAndCalculateHandler_NotFound()
        {
            //Arrange
            using var cts = new CancellationTokenSource();

            var calcTask = Domain.Models.CalcTaskAggregate.CalcTask.Create(Guid.NewGuid(), "addition", 876876, 76876);
            var httpResponseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);

            _clientMock.Setup(x => x.GetTaskAsync())
                .Returns(new ValueTask<Domain.Models.CalcTaskAggregate.CalcTask>(calcTask));
            _clientMock.Setup(x => x.SubmitTaskAsync(It.IsAny<CalcTaskResult>(), cts.Token))
                .ReturnsAsync(httpResponseMessage);

            _repositoryMock.Setup(x => x.AddCalcTaskAsync(It.IsAny<Domain.Models.CalcTaskAggregate.CalcTask>(), cts.Token))
                .Returns(new ValueTask());
            _repositoryMock.Setup(x => x.AddCalcTaskResultAsync(It.IsAny<CalcTaskResult>(), cts.Token))
                .Returns(new ValueTask());

            var message = "NotFound - Value not found for specified ID";

            //Act
            var r = await _handler.Handle(new GetTaskAndCalculateRequestDto(), cts.Token);

            //Assert
            Assert.Equal(message, r.AdpResponseDescription);
            Assert.Equal(ResponseStatus.OK, r.Status);
        }
        [Fact]
        public async void GetTaskAndCalculateHandler_ServiceUnavailable()
        {
            //Arrange
            using var cts = new CancellationTokenSource();

            var calcTask = Domain.Models.CalcTaskAggregate.CalcTask.Create(Guid.NewGuid(), "addition", 876876, 76876);
            var httpResponseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.ServiceUnavailable);

            _clientMock.Setup(x => x.GetTaskAsync())
                .Returns(new ValueTask<Domain.Models.CalcTaskAggregate.CalcTask>(calcTask));
            _clientMock.Setup(x => x.SubmitTaskAsync(It.IsAny<CalcTaskResult>(), cts.Token))
                .ReturnsAsync(httpResponseMessage);

            _repositoryMock.Setup(x => x.AddCalcTaskAsync(It.IsAny<Domain.Models.CalcTaskAggregate.CalcTask>(), cts.Token))
                .Returns(new ValueTask());
            _repositoryMock.Setup(x => x.AddCalcTaskResultAsync(It.IsAny<CalcTaskResult>(), cts.Token))
                .Returns(new ValueTask());

            var message = "ServiceUnavailable - Error communicating with database";

            //Act
            var r = await _handler.Handle(new GetTaskAndCalculateRequestDto(), cts.Token);

            //Assert
            Assert.Equal(message, r.AdpResponseDescription);
            Assert.Equal(ResponseStatus.OK, r.Status);
        }
    }
}
