using Application.DTOs;
using Application.Interfaces;
using DataAccess;
using DataAccess.Repositories;
using Domain.Entities;
using System;
using System.Linq;

namespace Application
{
    public class BatchMover : IBatchMover
    {
        private readonly IGenericRepository<WarehouseBatch> _warehouseBatchRepo;
        private readonly IUnitOfWork _unitOfWork;

        public BatchMover(
            IGenericRepository<WarehouseBatch> warehouseBatchRepo,
            IUnitOfWork unitOfWork)
        {
            _warehouseBatchRepo = warehouseBatchRepo;
            _unitOfWork = unitOfWork;
        }

        public void MoveBatch(MoveBatchDto dto)
        {
            if (dto.FromLocationId == dto.ToLocationId)
                return;

            var source = _warehouseBatchRepo
                .Get(wb => wb.WarehouseBatchId == dto.WarehouseBatchId
                           && wb.LocationId == dto.FromLocationId)
                .FirstOrDefault();

            if (source == null)
                throw new Exception("Source warehouse batch not found");

            if (dto.Quantity == 0)
            {
                var existing = _warehouseBatchRepo
                    .Get(wb => wb.BatchId == source.BatchId
                               && wb.LocationId == dto.ToLocationId)
                    .FirstOrDefault();

                if (existing != null)
                    throw new Exception("Warehouse batch already exists at destination");

                var newBatch = new WarehouseBatch
                {
                    BatchId = source.BatchId,
                    LocationId = dto.ToLocationId,
                    Quantity = 0 
                };

                _warehouseBatchRepo.Insert(newBatch);
            }
            else
            {
                if (dto.Quantity > source.Quantity)
                    throw new Exception("Not enough quantity at source location");

                var destination = _warehouseBatchRepo
                    .Get(wb => wb.BatchId == source.BatchId
                               && wb.LocationId == dto.ToLocationId)
                    .FirstOrDefault();

                if (destination == null)
                {
                    destination = new WarehouseBatch
                    {
                        BatchId = source.BatchId,
                        LocationId = dto.ToLocationId,
                        Quantity = dto.Quantity
                    };
                    _warehouseBatchRepo.Insert(destination);
                }
                else
                {
                    destination.Quantity += dto.Quantity;
                    _warehouseBatchRepo.Update(destination);
                }

                source.Quantity -= dto.Quantity;
                _warehouseBatchRepo.Update(source);
            }

            _unitOfWork.Save();
        }
    }
}

