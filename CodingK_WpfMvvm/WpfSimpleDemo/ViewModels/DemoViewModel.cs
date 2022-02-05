using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingK_WpfMvvmBase;
using Microsoft.Win32;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace WpfSimpleDemo.ViewModels
{
    public class DemoViewModel : ViewModelBase
    {
        public ReactiveProperty<string> InputPath { get; set; }
        public ReactiveCommand SendCommand { get; set; }

        protected override void InitData()
        {
            InputPath = new ReactiveProperty<string>("test").AddTo(Disposables);
        }

        protected override void RegisterCommand()
        {
            SendCommand = new ReactiveCommand().WithSubscribe(Send).AddTo(Disposables);
        }

        void Send()
        {
            var dlg = new DialogWindow();
            dlg.Content = InputPath;
            dlg.Show();
        }
    }
}
