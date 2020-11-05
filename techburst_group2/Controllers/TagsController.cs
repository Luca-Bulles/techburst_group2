using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces.BLL;
using Microsoft.AspNetCore.Mvc;
using techburst_group2.Models;

namespace techburst_group2.Controllers
{
    public class TagsController : Controller
    {
        private ITagCollection _tagColl;
        private ITagModel _tagModel;
        public TagsController(ITagCollection tagColl, ITagModel tagModel)
        {
            _tagColl = tagColl;
            _tagModel = tagModel;
        }
        public IActionResult Create()
        {
            return View();
        }

        public void CreateTag(TagViewModel tvm)
        {

        }

        public IActionResult Edit(int id)
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            return View();
        }

        public IActionResult Tag(int id)
        {
            return View();
        }



    }
}
