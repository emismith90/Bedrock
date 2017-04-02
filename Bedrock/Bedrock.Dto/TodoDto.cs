using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bedrock.Dto
{
    public class TodoDto
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
