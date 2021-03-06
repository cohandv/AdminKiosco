﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdminKiosco.Entities;

namespace AdminKiosco.Web.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];

            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LoggedIn(object sender, EventArgs e)
        {
            if (Page.Request.IsAuthenticated)
            {
                HttpCookie cookie = new HttpCookie("Paper.Roles", AuthorizationConfig.GetRoles(Context.User.Identity.Name));
                Page.Response.Cookies.Add(cookie);
            }
        }
    }
}