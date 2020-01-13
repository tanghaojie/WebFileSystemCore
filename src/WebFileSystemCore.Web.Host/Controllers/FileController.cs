using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace WebFileSystemCore.Web.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : WebFileSystemCoreWebHostControllerBase
    {
        private readonly IRepository<Entities.File, long> _fileRepository;
        public FileController(
           IRepository<Entities.File, long> fileRepository
            )
        {
            _fileRepository = fileRepository;

        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<long> Post(IFormFile file, string permissionsStr = "rwxrwxrwx", string description = null)
        {
            try
            {
                if (file == null) { throw new UserFriendlyException("服务器必须接收一个文件"); }

                var now = DateTime.Now;
                var nowHour = now.Year.ToString("0000") + now.Month.ToString("00") + now.Day.ToString("00") + now.Hour.ToString("00");
                var dirPath = Path.Combine(Directory.GetCurrentDirectory(), WebFileSystemCoreConsts.FilePathBase, nowHour);
                if (!Directory.Exists(dirPath)) { Directory.CreateDirectory(dirPath); }

                var filename = file?.FileName ?? DateTime.Now.ToFileTime().ToString();
                string ext = Path.GetExtension(filename) ?? null;

                var localname = Path.GetFileNameWithoutExtension(filename);
                var localFilePath = Path.Combine(dirPath, localname + ext);
                var index = 1;
                while (System.IO.File.Exists(localFilePath))
                {
                    localFilePath = Path.Combine(dirPath, localname + index.ToString() + ext);
                    index++;
                }

                using (var stream = new FileStream(localFilePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                long length = file?.Length ?? 0;
                string contentType = file?.ContentType ?? null;

                try
                {
                    return await _fileRepository.InsertAndGetIdAsync(new Entities.File
                    {
                        ContentType = contentType,
                        Description = description,
                        Extension = ext,
                        Filename = filename,
                        FileType = FileType.RegularFile,
                        Length = length,
                        LocalFilePath = localFilePath,
                        PermissionsStr = permissionsStr,
                    });
                }
                catch
                {
                    try { System.IO.File.Delete(localFilePath); } catch { }
                    throw;
                }
            }
            catch
            {
                throw new UserFriendlyException("接收文件失败");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            var entity = await _fileRepository.FirstOrDefaultAsync(id);
            if (entity == null) { return NotFound(); }

            var localFilePath = entity.LocalFilePath;
            if (!System.IO.File.Exists(localFilePath)) { return NotFound(); }

            entity.LastVisitTime = DateTime.Now;
            return new FileStreamResult(System.IO.File.OpenRead(localFilePath), entity.ContentType)
            {
                FileDownloadName = entity.Filename
            };
        }

    }
}
