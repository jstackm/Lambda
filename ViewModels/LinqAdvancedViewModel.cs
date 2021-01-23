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
            LambdaIntWhere = new DelegateCommand(LambdaIntWhereExe);
            QueryStringWhere = new DelegateCommand(QueryStringWhereExe);
            QueryCustomClassWhere = new DelegateCommand(QueryCustomClassWhereExe);
            QueryGroupBy = new DelegateCommand(QueryGroupByExe);
            QueryGroupByMulti = new DelegateCommand(QueryGroupByMultiExe);
            QueryInnerJoin = new DelegateCommand(QueryInnerJoinExe);
            QueryInnerJoinMulti = new DelegateCommand(QueryInnerJoinMultiExe);
            QueryLeftJoin = new DelegateCommand(QueryLeftJoinExe);
        }


        public DelegateCommand QueryIntWhere { get; }
        private void QueryIntWhereExe()
        {
            var q = new L01_IntWhere();
            q.QueryIntWhere();
        }
        public DelegateCommand LambdaIntWhere { get; }
        private void LambdaIntWhereExe()
        {
            var q = new L01_IntWhere();
            q.LambdaIntWhere();
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
        public DelegateCommand QueryGroupBy { get; }
        private void QueryGroupByExe()
        {
            var q = new L04_GroupBy();
            q.QueryGroupBy();
        }
        public DelegateCommand QueryGroupByMulti { get; }
        private void QueryGroupByMultiExe()
        {
            var q = new L04_GroupBy();
            q.QueryGroupByMulti();
        }
        public DelegateCommand QueryInnerJoin { get; }
        private void QueryInnerJoinExe()
        {
            var q = new L05_Join();
            q.QueryInnerJoin();
        }
        public DelegateCommand QueryInnerJoinMulti { get; }
        private void QueryInnerJoinMultiExe()
        {
            var q = new L05_Join();
            q.QueryInnerJoinMulti();
        }
        public DelegateCommand QueryLeftJoin { get; }
        private void QueryLeftJoinExe()
        {
            var q = new L05_Join();
            q.QueryLeftJoin();
        }


    }
}
