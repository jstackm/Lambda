using Lambda.Domain;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lambda.ViewModels
{
    public class LinqAdvancedViewModel : BindableBase
    {
        private string _title = "Linq Advanced";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public LinqAdvancedViewModel()
        {
            QueryIntWhere = new DelegateCommand(QueryIntWhereExe);
            QueryStringWhere = new DelegateCommand(QueryStringWhereExe);
            QueryCustomClassWhere = new DelegateCommand(QueryCustomClassWhereExe);
        }


        public DelegateCommand QueryIntWhere { get; }
        private void QueryIntWhereExe()
        {
            var q = new L01_IntWhere();
            q.QueryIntWhere();
        }
        public DelegateCommand QueryStringWhere { get; }
        private void QueryStringWhereExe()
        {
            var q = new L02_StringWhere();
            q.QueryStringWhere();
        }
        public DelegateCommand QueryCustomClassWhere { get; }
        private void QueryCustomClassWhereExe()
        {
            var q = new L03_CustomClassWhere();
            q.QueryCustomClassWhere();
        }

    }
}
