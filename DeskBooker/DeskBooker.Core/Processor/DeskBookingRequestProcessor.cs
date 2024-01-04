using DeskBooker.Core.Domain;
using DeskBooker.Core.IReposatory;

namespace DeskBooker.Core.Processor
{
    public class DeskBookingRequestProcessor
    {
        private readonly IDeskBookingReposatory _iDeskBookingReposatory;

        public DeskBookingRequestProcessor(IDeskBookingReposatory iDeskBookingReposatory)
        {
            this._iDeskBookingReposatory = iDeskBookingReposatory;
        }
        //that method take the request to the resault
        public DeskBookingResult BookDesk(DeskBookingRequest request)
        {
            if (request == null) { throw new ArgumentNullException(nameof(request)); }

            _iDeskBookingReposatory.save(Create<DeskBooking>(request));

            return Create<DeskBookingResult>(request);

        }

        private static T Create<T>(DeskBookingRequest request) where T : DeskBookingBase, new()
        {
            return new T
            {
                FristName = request.FristName,
                LastName = request.LastName,
                Email = request.Email,
                Date = request.Date

            };
        }
    }
}