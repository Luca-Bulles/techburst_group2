using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces.BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using techburst_BLL.Models;
using techburst_group2.Models;
using techburst_group2.Utilities;

namespace techburst_group2.Controllers
{
    [Authorize(Roles = "Moderator")]
    public class TagsController : Controller
    {
        private ITagCollection _tagColl;
        private ITagModel _tagModel;
        private List<TagViewModel> _tagList;
        public TagsController(ITagCollection tagColl, ITagModel tagModel)
        {
            _tagColl = tagColl;
            _tagModel = tagModel;
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateTag(TagViewModel tvm)
        {
            _tagColl.Create(_tagModel = new TagModel() {Id = tvm.Id, Name = tvm.Name});
            TempData["Create"] = "Succesfully created a tag!";
            return RedirectToAction("All");
        }

        public IActionResult Edit(int id)
        {
            return View();
        }

        public IActionResult CommitChanges(TagViewModel tvm)
        {
            if (ModelState.IsValid)
            {
                _tagModel.Edit(ViewModelConverter.ConvertTagViewModelToModel(tvm));
            }

            return RedirectToAction("All");
        }

        public IActionResult All()
        {
            var tags =_tagColl.GetAllTags();
            _tagList = new List<TagViewModel>();

            foreach (var tag in tags)
            {
                TagViewModel tvm = ViewModelConverter.ConvertModelToViewModel(tag);
                _tagList.Add(tvm);
            }
            return View(_tagList);
        }

        public IActionResult Delete(int id)
        {
            _tagModel.Delete(id);
            TempData["Delete"] = "Deleted tag!";
            return RedirectToAction("All");
        }




    }
}
