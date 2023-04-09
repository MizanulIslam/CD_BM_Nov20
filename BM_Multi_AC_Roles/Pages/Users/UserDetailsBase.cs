using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BM_Multi_AC_Roles.Pages.Users
{
    public class UserDetailsBase : ComponentBase
    {

        [Parameter]
        public string Id { get; set; }

        [Parameter]
        public string SaveButtonText { get; set; } = "Save";


        [Parameter]
        public string DeleteButtonText { get; set; } = "Delete";


        [Parameter]
        public string DetailsButtonText { get; set; } = "Details";
    }
}
