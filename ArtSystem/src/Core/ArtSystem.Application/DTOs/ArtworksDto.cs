using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtSystem.Application.DTOs
{
    public class ArtworksDto
    {         
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }
    }
}
