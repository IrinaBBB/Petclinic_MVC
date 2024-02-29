using Microsoft.AspNetCore.Mvc;

namespace Petclinic.Extensions
{
    public static class ControllerExtensions
    {
        public static void ReturnTempMessage(this Controller controller, string type, string message)
        {
            controller.TempData["Message"] = message;
            controller.TempData["Type"] = type;
        }
    }
}
