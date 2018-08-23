using System;

namespace Poli.Makro.Core.ViewModel.Modals.Model
{
    public interface IUserDialogViewModel : IDialogViewModel
    {
        bool IsModal { get; }
        void RequestClose();
        event EventHandler DialogClosing;
    }
}
