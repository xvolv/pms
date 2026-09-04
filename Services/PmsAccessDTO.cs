using System.Collections.Generic;

namespace ERP.V7.WebPMS.Services
{
    public class AccessPermissionItem
    {
        public string? Description { get; set; }
        public string? Category { get; set; }
    }

    public class PmsAccessDTO
    {
        public List<AccessPermissionItem> AccessPermissionList { get; set; } = new();
    }
}
