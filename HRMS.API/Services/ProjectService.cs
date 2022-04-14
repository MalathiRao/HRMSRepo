using AutoMapper;
using HRMS.API.Dtos;
using HRMS.API.Models;
using HRMS.API.Repositories.UnitOfWork;
using HRMS.API.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ProjectService> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public ProjectService(IUnitOfWork unitOfWork, ILogger<ProjectService> logger, IConfiguration configuration, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._logger = logger;
            this._configuration = configuration;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<ProjectsDto>> GetAllProjects()
        {
            _logger.LogInformation("GetAllProjects service started");
            var prjctlist = await _unitOfWork.ProjectsRepository.GetAll().ToListAsync();
            _logger.LogInformation("GetAllProjects service ended");
            return _mapper.Map<IEnumerable<ProjectsDto>>(prjctlist);
        }

        public async Task<ProjectsDto> GetProjectsByProjectId(int id)
        {
            _logger.LogInformation("GetProjectsByProjectId service started");
            var Project = await _unitOfWork.ProjectsRepository.Get(x => x.ProjectId == id).FirstOrDefaultAsync();
            _logger.LogInformation("GetProjectsByProjectId service ended");
            return _mapper.Map<ProjectsDto>(Project);
        }

        public async Task<ProjectsDto> CreateProject(ProjectsDto projectsDto)
        {
            _logger.LogInformation("CreateProject service started");
            var result = await _unitOfWork.ProjectsRepository.InsertAsync(_mapper.Map<Projects>(projectsDto));
            _logger.LogInformation("CreateEmployee service ended");
            return _mapper.Map<ProjectsDto>(result);
        }

        public async Task<ProjectsDto> UpdateProject(ProjectsDto projectsDto)
        {
            _logger.LogInformation("UpdateProject service started");
            var Project = await _unitOfWork.ProjectsRepository.Get(x => x.ProjectId == projectsDto.ProjectId).FirstOrDefaultAsync();
            if (Project != null)
            {
                var project = await _unitOfWork.ProjectsRepository.Update(_mapper.Map<Projects>(projectsDto));
                return _mapper.Map<ProjectsDto>(project);
            }
            _logger.LogInformation("UpdateProject service ended");
            return _mapper.Map<ProjectsDto>(Project);
        }

        public async Task<ProjectsDto> DeleteProjectByProjectId(int id)
        {
            _logger.LogInformation("DeleteProjectByProjectId service started");
            var prjct = await _unitOfWork.ProjectsRepository.Get(x => x.ProjectId == id).FirstOrDefaultAsync();
            if (prjct == null)
            {
                return _mapper.Map<ProjectsDto>(prjct);
            }
            await _unitOfWork.ProjectsRepository.DeleteAsync(prjct);
            _logger.LogInformation("DeleteProjectByProjectId service ended");
            return _mapper.Map<ProjectsDto>(prjct);
        }
    }
}
