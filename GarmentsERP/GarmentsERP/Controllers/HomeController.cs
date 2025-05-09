using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GarmentsERP.Model;
using ClosedXML.Excel;

namespace GarmentsERP.Controllers
{
    public class HomeController : Controller
    {
        List<student> _osStudent = new List<student>();
        public HomeController(ILogger<HomeController> logger)
        {
            for (int i = 1; i <= 9; i++)
            {
                _osStudent.Add(new student()
                {
                    studentId = i,
                    Name = "student" + i,
                    Roll = "100" + i
                });


            }
        }

        public IActionResult Index()
            {
                using (var worbook = new XLWorkbook())
                {
                    var workSheet = worbook.Worksheets.Add("student");
                    var currentRow = 1;
                    #region Header                
                    workSheet.Cell(currentRow, 1).Value = "studentId";
                    workSheet.Cell(currentRow, 2).Value = "Name";
                    workSheet.Cell(currentRow, 3).Value = "Roll";
                    #endregion

                    #region body
                    foreach (var student in _osStudent)
                    {
                        currentRow++;
                        workSheet.Cell(currentRow, 1).Value = student.studentId;
                        workSheet.Cell(currentRow, 2).Value = student.Name;
                        workSheet.Cell(currentRow, 3).Value = student.Roll;
                    }
                    #endregion

                    using (var stream = new MemoryStream())
                    {
                        worbook.SaveAs(stream);
                        var content = stream.ToArray();
                        return File(
                            content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                            "student.xlsx"

                            );
                    }
                }
            }
    }
}
