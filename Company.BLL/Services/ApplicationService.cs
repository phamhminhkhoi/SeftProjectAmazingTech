using AutoMapper;
using Company.BLL.Helpers;
using Company.BLL.IServices;
using Company.DAL.DTO.Request;
using Company.DAL.Entities;
using Company.DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BLL.Services
{
    internal class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;
        private readonly ImageConvert _imageConvert;

        public ApplicationService(IApplicationRepository applicationRepository, IMapper mapper, ImageConvert imageConvert)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
            _imageConvert = imageConvert;
        }

        public async Task<List<ApplicationDTO>> GetAllApplicationsAsync()
        {
            var applications = await _applicationRepository.GetAllApplicationsAsync();
            return _mapper.Map<List<ApplicationDTO>>(applications);
        }

        public async Task<ApplicationDTO> GetApplicationByIdAsync(int id)
        {
            var application = await _applicationRepository.GetApplicationByIdAsync(id);
            return _mapper.Map<ApplicationDTO>(application);
        }

        public async Task<ApplicationDTO> AddApplicationAsync(string userId, ApplicationDTO applicationDTO)
        {
            if (!string.IsNullOrEmpty(applicationDTO.ApplicationImageUrl))
            {
                applicationDTO.ApplicationImageUrl = _imageConvert.ConvertImageToBase64(applicationDTO.ApplicationImageUrl);
            }

            var application = _mapper.Map<Application>(applicationDTO);
            application.UserId = userId;
            await _applicationRepository.AddApplicationAsync(application);
            return _mapper.Map<ApplicationDTO>(application);
        }

        public async Task<ApplicationDTO> UpdateApplicationAsync(string userId, ApplicationDTO applicationDTO)
        {
            if (!string.IsNullOrEmpty(applicationDTO.ApplicationImageUrl))
            {
                applicationDTO.ApplicationImageUrl = _imageConvert.ConvertImageToBase64(applicationDTO.ApplicationImageUrl);
            }

            var application = _mapper.Map<Application>(applicationDTO);
            application.UserId = userId;
            await _applicationRepository.UpdateApplicationAsync(application);
            return _mapper.Map<ApplicationDTO>(application);
        }

        public async Task DeleteApplicationAsync(int id)
        {
            await _applicationRepository.DeleteApplicationAsync(id);
        }
    }
}
