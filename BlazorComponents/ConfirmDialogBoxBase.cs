using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorComponents
{
    public class ConfirmDialogBoxBase: ComponentBase
    {
        protected bool ShowConfirmation { get; set; } = false;

        [Parameter]
        public EventCallback<bool> ConfirmationChanged { get; set; }

        [Parameter]
        public string ModalTitle { get; set; } = "Alert";

        [Parameter]
        public string ModalMessage { get; set; } = "Are you sure ?";

        [Parameter]
        public string ModalButtonText { get; set; } = "Confirm";

        

        public void Show()
        {
            ShowConfirmation = true;
            StateHasChanged();
        }


        protected async Task OnConfirmationChanged(bool value)
        {
            ShowConfirmation = false;
           await  ConfirmationChanged.InvokeAsync(value);
        }
    }
}
