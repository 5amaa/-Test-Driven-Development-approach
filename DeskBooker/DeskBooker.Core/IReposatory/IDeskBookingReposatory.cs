using DeskBooker.Core.Domain;

namespace DeskBooker.Core.IReposatory
{
    public interface IDeskBookingReposatory
    {
        void save(DeskBooking deskBooking);
    }
}
