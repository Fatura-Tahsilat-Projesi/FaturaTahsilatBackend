using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.DTOs
{
    public class CategoryDto
    {

        public int Id { get; set; }

        //Required, koydukki kategori ismi zorunlu olsun
        [Required]
        public string Name { get; set; }

    }
}
