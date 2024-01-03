using DeskBooker.Core.Domain;
using Xunit;

namespace DeskBooker.Core.Processor
{
    
    public class DeskBookingRequestProcessorTests
    {
        private readonly DeskBookingRequestProcessor _processor;

        public DeskBookingRequestProcessorTests()
        {
            //Arrange
           _processor = new DeskBookingRequestProcessor();

        }
        [Fact]
        public void ShouldReturnDeskBookingRequestWithRequestValues()
        {
            //1- Arrange

            //1.2 Instance from class for the paramof bookdesk
            var request = new DeskBookingRequest()
            {
                FristName = "Sama",
                LastName = "Ashraf",
                Email = "Sama@outlook.com",
                Date = new DateTime(2023, 1, 5)
            };

            //1.1- Instance from class DeskBookingRequestProcessor that have BookDesk Method 
         // var Processor = new DeskBookingRequestProcessor();

            //2- Act

            //2.1- Instance from class for the Expicted Result
            DeskBookingResult result = _processor.BookDesk(request);

            //3- Assert

            Assert.NotNull(request);
            Assert.Equal(request.FristName, result.FristName);
            Assert.Equal(request.LastName, result.LastName);
            Assert.Equal(request.Email, result.Email);
            Assert.Equal(request.Date, result.Date);

        }

        [Fact]
        public void ShouldThrowExceptionIfRequestIsNull()
        {
         

            //Act
            var exception = Assert.Throws<ArgumentNullException>(()=> _processor.BookDesk(null));

            //Assert
            Assert.Equal("request", exception.ParamName);

        }
    }
}
