﻿using Core.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace App.Pages.Admin.Settings
{
    public class ImportModel : AdminPageModel
    {
        IUnitOfWork _db;

        public ImportModel(IUnitOfWork db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGet()
        {
            Author = await _db.Authors.GetItem(a => a.AppUserName == User.Identity.Name);

            if (!Author.IsAdmin)
                return RedirectToPage("../Shared/_Error", new { code = 403 });

            return Page();
        }
    }
}