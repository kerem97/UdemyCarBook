﻿using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _UILayoutScriptsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
