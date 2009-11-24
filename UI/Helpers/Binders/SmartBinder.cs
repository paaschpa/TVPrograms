using System.Web.Mvc;
using Castle.Components.Validator;

namespace TVPrograms.Helpers.Binders
{
    public class SmartBinder : DefaultModelBinder
    {
        protected override void OnModelUpdated(
            ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            var runner = new ValidatorRunner(new CachedValidationRegistry());
            if (!runner.IsValid(bindingContext.Model))
            {
                var summary = runner.GetErrorSummary(bindingContext.Model);

                foreach (var invalidProperty in summary.InvalidProperties)
                {
                    foreach (var error in summary.GetErrorsForProperty(invalidProperty))
                    {
                        bindingContext.ModelState.AddModelError(invalidProperty, error);
                    }
                }
            }
        }
    }
}