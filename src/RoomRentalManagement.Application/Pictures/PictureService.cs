using RoomRentalManagement.Application.Common.Interfaces;
using RoomRentalManagement.Application.Pictures.Dtos;
using RoomRentalManagement.Domain.Entities;

namespace RoomRentalManagement.Application.Pictures
{
    public class PictureService : IPictureService
    {
        private readonly IPictureRepository _pictureRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PictureService(IPictureRepository pictureRepository, IUnitOfWork unitOfWork)
        {
            _pictureRepository = pictureRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<PictureDto>> GetPicturesAsync()
        {
            var pictures = await _pictureRepository.GetAllAsync();

            return pictures.Select(ToDto).ToList();
        }

        public async Task<PictureDto?> GetPictureAsync(Guid id)
        {
            var picture = await _pictureRepository.GetByIdAsync(id);

            return picture == null ? null : ToDto(picture);
        }

        public async Task<PictureDto> CreatePictureAsync(CreatePictureRequest request)
        {
            var picture = new Picture
            {
                Id = Guid.NewGuid(),
                RoomId = request.RoomId,
                Url = request.Url,
                Tag = request.Tag
            };

            await _pictureRepository.AddAsync(picture);
            await _unitOfWork.SaveChangesAsync();

            return ToDto(picture);
        }

        public async Task<bool> UpdatePictureAsync(Guid id, UpdatePictureRequest request)
        {
            var picture = await _pictureRepository.GetByIdAsync(id);

            if (picture == null)
            {
                return false;
            }

            picture.RoomId = request.RoomId;
            picture.Url = request.Url;
            picture.Tag = request.Tag;

            _pictureRepository.Update(picture);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeletePictureAsync(Guid id)
        {
            var picture = await _pictureRepository.GetByIdAsync(id);

            if (picture == null)
            {
                return false;
            }

            _pictureRepository.Remove(picture);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        private static PictureDto ToDto(Picture picture) => new()
        {
            Id = picture.Id,
            RoomId = picture.RoomId,
            Url = picture.Url,
            Tag = picture.Tag,
            CreatedAt = picture.CreatedAt,
            UpdatedAt = picture.UpdatedAt
        };
    }
}
