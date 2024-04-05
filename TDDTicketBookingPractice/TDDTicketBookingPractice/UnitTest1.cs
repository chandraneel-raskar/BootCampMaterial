using TicketBookingCore;

namespace TDDTicketBookingPractice
{
    public class TicketBookingRequestProcessorTests
    {
        private readonly TicketBookingRequestProcessor _processor;
        private readonly Mock<ITicketBookingRepository> _ticketBookingRepositoryMock;

        public TicketBookingRequestProcessorTests()
        {
            _ticketBookingRepositoryMock = new Mock<ITicketBookingRepository>();
            _processor = new TicketBookingRequestProcessor(_ticketBookingRepositoryMock.Object);
        }

        [Fact]
        public void ShouldReturnTicketBookingResultWithRequestValues()
        {
            var request = new TicketBookingRequest
            {
                FirstName = "Neel",
                LastName = "Raskar",
                Email = "chandraneel.ras@gmail.com"
            };

            TicketBookingResponse response = _processor.Book(request);

            Assert.NotNull(response);
            Assert.Equal(request.FirstName, response.FirstName);
            Assert.Equal(request.LastName, response.LastName);
            Assert.Equal(request.Email,response.Email);
        }

        [Fact]
        public void ShouldThrowExceptionIfRequestIsNull()
        {

            var exception = Assert.Throws<ArgumentNullException>(() => _processor.Book(null));

            Assert.Equal("request", exception.ParamName);
        }

        [Fact]
        public void ShouldSaveToDatabase()
        {
            var request = new TicketBookingRequest
            {
                FirstName = "Neel",
                LastName = "Raskar",
                Email = "chandraneel.ras@gmail.com"
            };

            TicketBookingResponse response = _processor.Book(request);
        }
    }

    internal class Mock<T>
    {
        public Mock()
        {
        }
    }
}