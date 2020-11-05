using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces.BLL;
using Microsoft.AspNetCore.Mvc;
using techburst_BLL.Models;
using techburst_group2.Models;

namespace techburst_group2.Controllers
{
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
            return RedirectToAction("Create");
        }

        public IActionResult Edit(int id)
        {
            return View();
        }

        public IActionResult All()
        {
            var tags =_tagColl.GetAllTags();
            _tagList = new List<TagViewModel>();
            foreach (var tag in tags)
            {
                TagViewModel tvm = new TagViewModel() {Id = tag.Id, Name = tag.Name};
                _tagList.Add(tvm);
            }
            return View(_tagList);
        }

        public IActionResult Delete(int id)
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            return View();
        }



    }
}
