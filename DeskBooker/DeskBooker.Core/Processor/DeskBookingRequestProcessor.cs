using DeskBooker.Core.Domain;

namespace DeskBooker.Core.Processor
{
    public class DeskBookingRequestProcessor
    {
        public DeskBookingRequestProcessor()
        {
        }
        //that method take the request to the resault
        public DeskBookingResult BookDesk(DeskBookingRequest request)
        {
            if (request == null) { throw new ArgumentNullException(nameof(request)); }


            return new DeskBookingResult
            {
                FristName = request.FristName,
                LastName = request.LastName,
                Email = request.Email,
                Date = request.Date
            };
        }
    }
}