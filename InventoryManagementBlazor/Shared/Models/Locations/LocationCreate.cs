using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementBlazor.Shared.Models.Locations
{
    public class LocationCreate
    {
        
        [Required]
        public string Location { get; set; }
    }
}
