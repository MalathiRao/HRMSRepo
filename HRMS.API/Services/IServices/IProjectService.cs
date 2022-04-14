using HRMS.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Services.IServices
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectsDto>>GetAllProjects();

        Task<ProjectsDto> GetProjectsByProjectId(int Id);
        Task<ProjectsDto> CreateProject(ProjectsDto projectsDto);
        Task<ProjectsDto> UpdateProject(ProjectsDto projectsDto);
        Task<ProjectsDto> DeleteProjectByProjectId(int Id);
    }
}
