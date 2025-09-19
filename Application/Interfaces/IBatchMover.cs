using Application.DTOs;

namespace Application.Interfaces
{
    public interface IBatchMover
    {
        void MoveBatch(MoveBatchDto dto);
    }
}
