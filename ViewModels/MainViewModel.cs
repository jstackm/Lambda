using Lambda.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lambda.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private IRegionManager _regionManager;
        public MainViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            LambdaBasicsView = new DelegateCommand(LambdaBasicsViewExe);
            LinqAdvancedView = new DelegateCommand(LinqAdvancedViewExe);
        }

        private string _title = "Lambda/LINQ Example";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        // Navigation Window
        public DelegateCommand LambdaBasicsView { get; }
        private void LambdaBasicsViewExe()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(LambdaBasics));
        }

        public DelegateCommand LinqAdvancedView { get; }
        private void LinqAdvancedViewExe()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(LinqAdvanced));
        }
    }
}
