using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace testSite.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }
        [Display(Name = "Имя")]
        [StringLength(maximumLength:20,MinimumLength=3)]
        [Required(ErrorMessage ="Длинна имени должна находиться в пределах от 3 до 20 символов")]
        public string Name { get; set; }
        [Display(Name = "Фамилия")]
        [StringLength(maximumLength: 20, MinimumLength = 3)]
        [Required(ErrorMessage = "Длинна фамилии должна находиться в пределах от 3 до 20 символов")]
        public string Surname { get; set; }
        [Display(Name = "Адрес")]
        [StringLength(maximumLength: 50, MinimumLength = 10)]
        [Required(ErrorMessage = "Длинна адреса должна находиться в пределах от 20 до 50 символов")]
        public string Address { get; set; }
        [Display(Name = "Телефон")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Неверный формат телефона")]
        [StringLength(maximumLength: 15, MinimumLength = 7)]
        [Required(ErrorMessage = "Длинна телефона должна находиться в пределах от 7 до 15 символов")]
        public string Phone { get; set; }
        [Display(Name = "Почта")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Неверный формат почты")]
        [StringLength(maximumLength: 20, MinimumLength = 3)]
        [Required(ErrorMessage = "Длинна почты должна находиться в пределах от 3 до 20 символов")]
        public string Email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
