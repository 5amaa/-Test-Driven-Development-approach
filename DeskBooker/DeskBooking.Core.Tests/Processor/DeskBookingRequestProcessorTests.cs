using DeskBooker.Core.Domain;
using DeskBooker.Core.IReposatory;
using Moq;
using Xunit;

namespace DeskBooker.Core.Processor
{
    
    public class DeskBookingRequestProcessorTests
    {
        private readonly Mock<IDeskBookingReposatory> _deskBookingRepositoryMock;
        private readonly DeskBookingRequestProcessor _processor;
        private readonly DeskBookingRequest _request;

        public DeskBookingRequestProcessorTests()
        {

            _deskBookingRepositoryMock = new Mock<IDeskBookingReposatory>();
            //Arrange
           _processor = new DeskBookingRequestProcessor(_deskBookingRepositoryMock.Object) {
               
           };

            //1.2 Instance from class for the paramof bookdesk
             _request = new DeskBookingRequest()
            {
                FristName = "Sama",
                LastName = "Ashraf",
                Email = "Sama@outlook.com",
                Date = new DateTime(2023, 1, 5)
            };

            

        }
        [Fact]
        public void ShouldReturnDeskBookingRequestWithRequestValues()
        {
            //1- Arrange

            //1.2 Instance from class for the paramof bookdesk (7atetha fe el constractor 3shan 3yza ha7tago kza mara)
            //var request = new DeskBookingRequest()
            //{
            //    FristName = "Sama",
            //    LastName = "Ashraf",
            //    Email = "Sama@outlook.com",
            //    Date = new DateTime(2023, 1, 5)
            //};


            //1.1- Instance from class DeskBookingRequestProcessor that have BookDesk Method 
         // var Processor = new DeskBookingRequestProcessor();

            //2- Act

            //2.1- Instance from class for the Expicted Result
            DeskBookingResult result = _processor.BookDesk(_request);

            //3- Assert

            Assert.NotNull(_request);
            Assert.Equal(_request.FristName, result.FristName);
            Assert.Equal(_request.LastName, result.LastName);
            Assert.Equal(_request.Email, result.Email);
            Assert.Equal(_request.Date, result.Date);

        }

        [Fact]
        public void ShouldThrowExceptionIfRequestIsNull()
        {
         

            //Act
            var exception = Assert.Throws<ArgumentNullException>(()=> _processor.BookDesk(null));

            //Assert
            Assert.Equal("request", exception.ParamName);

        }

        [Fact]
        public void ShouldSaveDeskBooking()
        {
            //Arrange
            DeskBooking savedDeskBooking = null;

            //awl lma call el deskBookingRepositoryMock excute the save method 
            _deskBookingRepositoryMock.Setup(x => x.save(It.IsAny<DeskBooking>()))
                .Callback<DeskBooking>(deskBooking => { savedDeskBooking = deskBooking; });


            //Act
            _processor.BookDesk(_request);

            ////verify deskBooking saved once time
            
            _deskBookingRepositoryMock.Verify(x=> x.save(It.IsAny<DeskBooking>()), Times.Once);

            Assert.NotNull(savedDeskBooking);
            Assert.Equal(_request.FristName , savedDeskBooking.FristName);
            Assert.Equal(_request.LastName, savedDeskBooking.LastName);
            Assert.Equal(_request.Email, savedDeskBooking.Email);
            Assert.Equal(_request.Date, savedDeskBooking.Date);

        }
    }
}
