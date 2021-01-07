using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using techburst_BLL.Collections;
using techburst_BLL.Models;

namespace techburst_group2.Models
{
    public class ContactViewModel
    {
        private static ContactViewModel _viewmodel;
        private static ContactModel _model;

        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Question { get; set; }



        public static ContactViewModel ConvertModelToContactViewModel(ContactModel model)
        {
            _viewmodel = new ContactViewModel()
            {
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Email = model.Email,
                Question = model.Question
            };
            return _viewmodel;
        }
        public static ContactModel ConvertContactViewModelToModel(ContactViewModel viewmodel)
        {
            _model = new ContactModel()
            {
                Firstname = viewmodel.Firstname,
                Lastname = viewmodel.Lastname,
                Email = viewmodel.Email,
                Question = viewmodel.Question
            };
            return _model;
        }
    }
}
