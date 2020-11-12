using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces.BLL;
using techburst_group2.Models;

namespace techburst_group2.Utilities
{
    public  class ViewModelConverter
    {
        private static List<ITagModel> _tagList;
        private static List<TagViewModel> _viewModelList;
        private static ITagModel _tag;
        private static TagViewModel _tagViewModel;

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
            foreach (var model in modelList)
            {
                _tagViewModel.Id = model.Id;
                _tagViewModel.Name = model.Name;
                _viewModelList.Add(_tagViewModel);
            }

            return _viewModelList;
        }
    }
}
