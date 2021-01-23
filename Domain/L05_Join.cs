using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda.Domain
{
    class L05_Join
    {
        internal void QueryInnerJoin()
        {
            var sales = new List<Sale>();
            sales.Add(new Sale(10, 1, 100, Convert.ToDateTime("2021/01/22 12:12:12")));
            sales.Add(new Sale(11, 1, 100, Convert.ToDateTime("2021/01/22 12:12:12")));
            sales.Add(new Sale(12, 1, 101, Convert.ToDateTime("2021/01/22 12:12:12")));

            var saleItems = new List<SaleItem>();
            saleItems.Add(new SaleItem(10, 1, 1, 2));
            saleItems.Add(new SaleItem(10, 1, 2, 3));
            saleItems.Add(new SaleItem(11, 1, 1, 5));
            saleItems.Add(new SaleItem(12, 1, 1, 4));
            saleItems.Add(new SaleItem(12, 1, 3, 2));

            // 共通するものを取得し，2つのクラスを結合する
            Debug.WriteLine("------------ Inner Join -----------------");
            var result1 = from a in sales
                          join b in saleItems
                          on a.SaleId equals b.SaleId
                          select new
                          {
                              a.SaleId,
                              a.CustomerId,
                              a.SaleDateTime,
                              b.ProductId,
                              b.SaleCount
                          };

            foreach (var val in result1)
            {
                Debug.WriteLine(val);
            }

            // 共通するものを取得し，2つのクラスを結合する
            Debug.WriteLine("------------ Inner Join 条件検索 -----------------");
            var result2 = from a in sales
                          join b in saleItems
                          on a.SaleId equals b.SaleId
                          where a.SaleId >= 11
                          orderby b.SaleCount descending
                          select new
                          {
                              a.SaleId,
                              a.CustomerId,
                              a.SaleDateTime,
                              b.ProductId,
                              b.SaleCount
                          };

            foreach (var val in result2)
            {
                Debug.WriteLine(val);
            }
        }


        internal void QueryInnerJoinMulti()
        {
            var sales = new List<Sale>();
            sales.Add(new Sale(10, 1, 100, Convert.ToDateTime("2021/01/22 12:12:12")));
            sales.Add(new Sale(11, 1, 100, Convert.ToDateTime("2021/01/22 12:12:12")));
            sales.Add(new Sale(12, 1, 101, Convert.ToDateTime("2021/01/22 12:12:12")));

            var saleItems = new List<SaleItem>();
            saleItems.Add(new SaleItem(10, 1, 1, 2));
            saleItems.Add(new SaleItem(10, 1, 2, 3));
            saleItems.Add(new SaleItem(11, 99, 1, 5));
            saleItems.Add(new SaleItem(12, 1, 1, 4));
            saleItems.Add(new SaleItem(12, 1, 3, 2));

            // 共通するものを取得し，2つのクラスを結合する
            Debug.WriteLine("------------ Inner Join 複数条件 -----------------");
            var result3 = from a in sales
                          join b in saleItems
                          on new { a.SaleId, a.Number }
                          equals new { b.SaleId, b.Number }
                          select new
                          {
                              a.SaleId,
                              a.CustomerId,
                              a.SaleDateTime,
                              b.ProductId,
                              b.SaleCount
                          };

            foreach (var val in result3)
            {
                Debug.WriteLine(val);
            }
        }

        internal void QueryLeftJoin()
        {
            var sales = new List<Sale>();
            sales.Add(new Sale(10, 1, 100, Convert.ToDateTime("2021/01/22 12:12:12")));
            sales.Add(new Sale(11, 1, 100, Convert.ToDateTime("2021/01/22 12:12:12")));
            sales.Add(new Sale(12, 1, 101, Convert.ToDateTime("2021/01/22 12:12:12")));

            var saleItems = new List<SaleItem>();
            saleItems.Add(new SaleItem(10, 1, 1, 2));
            saleItems.Add(new SaleItem(10, 1, 2, 3));
            //saleItems.Add(new SaleItem(11, 1, 1, 5));
            saleItems.Add(new SaleItem(12, 1, 1, 4));
            saleItems.Add(new SaleItem(12, 1, 3, 2));

            // 外部結合
            // 検索条件に対し，結合対象（この場合はsaleItems）に該当するものがない場合でも
            // 結合元（sales）を取得したい場合に使う．
            // saleItems は null である可能性があるので，処理をする
            Debug.WriteLine("------------ Left Join -----------------");
            var result4 = from a in sales
                          join b in saleItems
                          on a.SaleId equals b.SaleId into bb
                          from b in bb.DefaultIfEmpty()
                          select new
                          {
                              a.SaleId,
                              a.CustomerId,
                              a.SaleDateTime,
                              ProductId = b?.ProductId ?? -1,
                              SaleCount = b?.SaleCount ?? 0
                          };

            foreach (var val in result4)
            {
                Debug.WriteLine(val);
            }
        }


    }

}

