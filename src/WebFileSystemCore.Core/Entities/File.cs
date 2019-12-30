using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebFileSystemCore.Entities
{
    public class File : Entity<long>, IHasCreationTime
    {
        [Required]
        public string Filename { get; set; }

        [Required]
        public string LocalFilePath { get; set; }

        public string Extension { get; set; }

        /// <summary>
        /// bytes
        /// </summary>
        [Required]
        public long Length { get; set; } = 0;

        public string ContentType { get; set; }

        [Required]
        public int PermissionsInt {
            get {
                return Permissions.ToInt();
            }
            set {
                Permissions = new Permissions(value);
            }
        }
        [NotMapped]
        public virtual Permissions Permissions { get; set; } = new Permissions();

        public string Owner { get; set; }


        public string Description { get; set; }


        [Required]
        public DateTime CreationTime { get; set; } = DateTime.Now;

        public DateTime? LastUpdationTime { get; set; }

        public DateTime? LastVisitTime { get; set; }
    }

}
