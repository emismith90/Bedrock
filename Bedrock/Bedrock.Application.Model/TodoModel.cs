using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bedrock.Application.Model
{
    public class TodoModel
    {
        [Key]
        public Guid Id { get; set; }

        [MinLength(2)]
        [MaxLength(255)]
        [DisplayName("Title")]
        public string Title { get; set; }

        [DisplayName("IsActive")]
        public bool IsActive { get; set; }
    }
}
