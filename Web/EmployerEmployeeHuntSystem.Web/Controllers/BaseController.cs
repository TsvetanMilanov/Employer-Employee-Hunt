namespace EmployerEmployeeHuntSystem.Web.Controllers
{
    using System.Web.Mvc;
    using AutoMapper;
    using Constants;
    using Infrastructure.Mapping;
    using Services.Web;

    public abstract class BaseController : Controller
    {
        public ICacheService Cache { get; set; }

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }

        protected void SetTempDataSuccessMessage(string message)
        {
            this.TempData[GlobalConstants.SuccessMessageTempDataKey] = message;
        }

        protected void SetTempDataErrorMessage(string message)
        {
            this.TempData[GlobalConstants.ErrorMessageTempDataKey] = message;
        }
    }
}
