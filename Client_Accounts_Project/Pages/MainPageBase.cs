using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client_Accounts_Project.Data;

namespace Client_Accounts_Project.Pages
{
    public class MainPageBase : ComponentBase
    {

        [Parameter]
        public string value { get; set; }

        [Parameter]
        public string id { get; set; }
        public string test { get; set; }



        protected override void OnParametersSet()
        {
            //the param will be set now
            test = value;


        }

    }
}
