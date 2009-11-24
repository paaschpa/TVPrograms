using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections.Generic;
using Castle.Components.Validator;

namespace TVPrograms.UI.Models.Forms
{

    public class LoginForm
    {
            [ValidateNonEmpty]
            public string Username { get; set; }

            [ValidateNonEmpty]
            public string Password { get; set; }
        }
}