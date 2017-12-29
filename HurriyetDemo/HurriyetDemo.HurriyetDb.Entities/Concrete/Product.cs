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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "CreatedDate is required")]
        [DataType(DataType.DateTime, ErrorMessage = "")]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "")]
        public DateTime ModifiedDate { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [DataType(DataType.Currency, ErrorMessage = "")]
        public double Price { get; set; }
    }
}
