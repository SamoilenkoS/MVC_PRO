using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_DAL.Entities
{
    public class GoodOnWarehouse
    {
        [ForeignKey("Good")]
        public Guid GoodId { get; set; }
        [ForeignKey("Warehouse")]
        public Guid WarehouseId { get; set; }
        [Required]
        public int Count { get; set; }

        public Good Good { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
