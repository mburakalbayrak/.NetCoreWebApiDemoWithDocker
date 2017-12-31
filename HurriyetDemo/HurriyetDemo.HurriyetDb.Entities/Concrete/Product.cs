using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using HurriyetDemo.Core.Entities;

namespace HurriyetDemo.HurriyetDb.Entities.Concrete
{
    public class Product : IEntity
    {
        //public Product()
        //{
        //    CreatedDate = DateTime.Now;
        //}

        [Key]
        [Required(ErrorMessage = "Id is required")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "CreatedDate is required")]
        [DataType(DataType.DateTime, ErrorMessage = "Created Date format is not available")]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "Modified Date format is not available")]
        public DateTime ModifiedDate { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [DataType(DataType.Currency, ErrorMessage = "Currency format is not available, Use a point(.)")]
        public double Price { get; set; }
    }
}
