using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public DateTime UploadTime { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsDelete { get; set; }

    }
}
