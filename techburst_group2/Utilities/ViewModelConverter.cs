using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Enums;
using Interfaces.BLL;
using techburst_BLL.Models;
using techburst_group2.Models;

namespace techburst_group2.Utilities
{
    public  class ViewModelConverter
    {
        private static List<ITagModel> _tagList;
        private static List<TagViewModel> _viewModelList;
        private static ITagModel _tag;
        private static TagViewModel _tagViewModel;
        private static UserModel _usermodel;
        private static UservViewModel _userviewmodel;

        public ViewModelConverter(ITagModel tag)
        {
            _tag = tag;
        }
        public static List<ITagModel> ConvertTagViewModelList(List<TagViewModel> viewModelList)
        {
            foreach (var viewModel in viewModelList)
            {
                _tag.Id = viewModel.Id;
                _tag.Name = viewModel.Name;
                _tagList.Add(_tag);
            }

            return _tagList;
        }

        public static List<TagViewModel> ConvertTagModelList(List<ITagModel> modelList)
        {
            _viewModelList = new List<TagViewModel>();
            foreach (var model in modelList)
            {
                _tagViewModel = new TagViewModel();
                _tagViewModel.Id = model.Id;
                _tagViewModel.Name = model.Name;
                _viewModelList.Add(_tagViewModel);
            }

            return _viewModelList;
        }

        public static TagViewModel ConvertModelToViewModel(ITagModel tag)
        {
            return new TagViewModel() { Id = tag.Id, Name = tag.Name };
        }

        public static ITagModel ConvertTagViewModelToModel(TagViewModel tvm)
        {
            return new TagModel() { Id = tvm.Id, Name = tvm.Name };
        }
        public static UserModel ConvertUserViewModelToModel(UservViewModel model)
        {
            _usermodel = new UserModel()
            {
                UserId = model.ID,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = model.Password,
                Email = model.Email,
                Role = model.Role
            };
            return _usermodel;
        }
    }
}
