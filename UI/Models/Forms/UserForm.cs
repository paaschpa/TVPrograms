using System;
using Castle.Components.Validator;

namespace TVPrograms.UI.Models.Forms
{
    //    [TypeConverter(typeof(UserFormTypeConverter))]
    public class UserForm
    {
        public virtual string FullName { get; set; }

        [ValidateEmail]
        public virtual string EmailAddress { get; set; }

        public virtual int id { get; set; }

        public virtual string Password { get; set; }

        [ValidateRegExp(@"^([a-zA-Z])[a-zA-Z_-]*[\w_-]*[\S]$|^([a-zA-Z])[0-9_-]*[\S]$|^[a-zA-Z]*[\S]$",
            "Username is not valid.")]
        public virtual string Username { get; set; }

        [ValidateSameAs("Password")]
        public virtual string ConfirmPassword { get; set; }
    }
}