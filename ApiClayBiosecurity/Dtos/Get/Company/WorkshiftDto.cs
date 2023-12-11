using System;
using System.Collections.Generic;

namespace ApiClayBiosecurity.Dtos.Get.Company;

public class WorkshiftDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime ShiftStartTime { get; set; }
    public DateTime ShiftEndTime { get; set; }

}
