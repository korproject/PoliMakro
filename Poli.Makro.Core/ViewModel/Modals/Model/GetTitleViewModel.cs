using Poli.Makro.Core.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Poli.Makro.Core.ViewModel.Modals.Model
{
    public class GetTitleViewModel : BaseViewModel, IUserDialogViewModel
    {
        #region IUserDialogViewModel Implementation

        public bool IsModal { get; private set; }
        public virtual void RequestClose()
        {
            if (this.OnCloseRequest != null)
                this.OnCloseRequest(this);
            else
                Close();
        }
        public event EventHandler DialogClosing;


        #endregion IUserDialogViewModel Implementation

        #region Commands

        public ICommand OkCommand { get { return new GalaSoft.MvvmLight.Command.RelayCommand(Ok); } }
        protected virtual void Ok()
        {
            if (this.OnOk != null)
                this.OnOk(this);
            else
                Close();
        }

        public ICommand CancelCommand { get { return new GalaSoft.MvvmLight.Command.RelayCommand(Cancel); } }
        protected virtual void Cancel()
        {
            if (this.OnCancel != null)
                this.OnCancel(this);
            else
                Close();
        }

        #endregion Commands


        private string _Message;
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }

        private string _Caption;
        public string Caption
        {
            get { return _Caption; }
            set { _Caption = value; }
        }

        public Action<GetTitleViewModel> OnOk { get; set; }
        public Action<GetTitleViewModel> OnCancel { get; set; }
        public Action<GetTitleViewModel> OnCloseRequest { get; set; }

        public GetTitleViewModel(bool isModal = true)
        {
            this.IsModal = isModal;
        }

        public void Close()
        {
            if (this.DialogClosing != null)
                this.DialogClosing(this, new EventArgs());
        }

        public void Show(IList<IDialogViewModel> collection)
        {
            collection.Add(this);
        }

    }

}
