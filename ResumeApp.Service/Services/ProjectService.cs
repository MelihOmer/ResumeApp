using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ResumeApp.Core.Contracts;
using ResumeApp.Core.Contracts.Services;
using ResumeApp.Core.Dtos.ProjectDtos;
using ResumeApp.Core.Entities;

namespace ResumeApp.Service.Services
{
    public class ProjectService : GenericService<Project>, IProjectService
    {
        private readonly IHostingEnvironment _environment;
        private readonly IMapper _mapper;
        private readonly string _folderPath;
        private readonly string _cvPath;
        public ProjectService(IUnitOfWork unitOfWork, IMapper mapper, IHostingEnvironment environment) : base(unitOfWork)
        {
            _mapper = mapper;
            _environment = environment;
            _folderPath =  $"{_environment.WebRootPath}/ProjectFiles/";
            _cvPath = $"{_environment.WebRootPath}/CV.pdf";
            
        }

        public async Task AddProject(ProjectCreateDto dto, int resumeId)
        {
            CheckExistProjectFolder();
            var fileInfo =  await FileSave(dto.file);

            var entity = _mapper.Map<Project>(dto);
            entity.ResumeId = resumeId;
            entity.ProjectPath = fileInfo.filePath;
            entity.Guid = fileInfo.guid;
            await AddAsync(entity);
            
        }
        public async Task<ProjectUpdateDto> GetProjectUpdate(int id)
        {
            
            var project = await GetById(id);
            var projectUpdateDto = _mapper.Map<ProjectUpdateDto>(project);
            
            return projectUpdateDto;
        }
        public async Task ProjectUpdate(ProjectUpdateDto dto)
        {   
            var project = _mapper.Map<Project>(dto);
            if (dto.FileUpdate)
            {
                var fileInfo = await FileSave(dto.file);
                DeleteFile(project.Guid);
                project.ProjectPath = fileInfo.filePath;
                project.Guid = fileInfo.guid;
            }
            await Update(project);
        }
        public async Task RemoveProject(int id)
        {
            var project = await GetById(id);
            DeleteFile(project.Guid);
            await Delete(project);
        }
        public async Task<byte[]> DownloadProject(string projectName)
        {
            string path = $"{_folderPath}{projectName}";
            byte[] bytes = await File.ReadAllBytesAsync(path);
            return bytes;
        }
        public async Task<byte[]> DownloadCV()
        {
            string path = $"{_cvPath}";
            byte[] bytes = await File.ReadAllBytesAsync(path);
            return bytes;
        }
        public async Task SaveCv(IFormFile file)
        {
            File.Delete(_cvPath);
            using (var stream = new FileStream(_cvPath,FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
        }
        private void CheckExistProjectFolder()
        {
            if (!Directory.Exists(_folderPath))
                Directory.CreateDirectory(_folderPath);
        }
        private async Task<(string filePath,string guid)> FileSave(IFormFile file)
        {
            if (file != null)
            {
                var extent = Path.GetExtension(file.FileName);
                var randomName = $"{Guid.NewGuid()}{extent}";
                var path = Path.Combine(_folderPath, randomName);
                using (var stream = new FileStream(path,FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return (filePath:path,guid:randomName);
            }
            return ("","");
        }
        private void DeleteFile(string fileName)
        {
            string path = $"{_folderPath}{fileName}";
            if (File.Exists(path))
                File.Delete(path);
        }

    }
}
