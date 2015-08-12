using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Basic_Login.Model;
using PagedList;

namespace RoleBased.Controllers
{
    public class HRController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult AddEmployee(Employee employee)
        {
            Employee.AddEmployee(employee);
            return View("AddEmployee");
        }

        [Authorize]
        public ActionResult AddRemark()
        {
            var response = GetEmpListResponse.GetEmployeeList();
            List<SelectListItem> allEmployeeList = new List<SelectListItem>();

            foreach (var employee in response.RequestedEmployeeList)
            {
                allEmployeeList.Add(new SelectListItem { Value = Convert.ToString(employee.Id), Text = employee.Id + ". " + employee.FirstName + "  " + employee.LastName });
            }
            ViewData["EmpList"] = allEmployeeList;
            return View();
        }

        public ActionResult SaveRemark(Remark remark)
        {
            string employeeId = Request["Employee"];
            remark.CreateTimeStamp = DateTime.UtcNow;
            var response = Remark.AddRemark(employeeId, remark);
            ViewData["StatusMsg"] = response.ResponseStatus.Message;
            return View("SaveRemark");
        }

        [Authorize]
        public ActionResult ViewRemark(int ? pageIndex)
        {
            //if (string.Equals(response.RequestedEmployee.Title, "hr", StringComparison.OrdinalIgnoreCase))
            string employeeId = "1";  //value from cookie
            int pageNumber = (pageIndex ?? 1);
            var response = Pagination.ViewRemark(employeeId, Convert.ToString(pageNumber));
            var remarkList = response.RequestedPagination.Remarks;
            var count = response.RequestedPagination.Count;

            var pageSize = 4;
            var pageList = new StaticPagedList<Remark>(remarkList, pageNumber, pageSize, count);
            return View(pageList);
        }
    }
}
