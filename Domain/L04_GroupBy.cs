using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda.Domain
{
    class L04_GroupBy
    {
        private List<Product> _products;

        internal void QueryGroupBy()
        {
            _products = new List<Product>();
            _products.Add(new Product(10, "p10A", 300));
            _products.Add(new Product(20, "p20", 300));
            _products.Add(new Product(30, "x301A", 200));
            _products.Add(new Product(40, "P40A", 500));
            _products.Add(new Product(50, "P50", 200));

            //単純なグループ化
            Debug.WriteLine("------------ Groupby -----------------");
            var result1 = from p in _products
                          group p by p.Price;
            foreach (var group in result1)
            {
                // グループごとにループ

                Debug.WriteLine("Groupe Key=" + group.Key);        // Key : groupしたプロパティ

                foreach (var row in group)
                {
                    Debug.WriteLine($"id={row.ProductId}\tname={row.ProductName}\tprice={row.Price}");
                }
            }
            Debug.WriteLine("");

            // 条件付きグループ化
            Debug.WriteLine("------------ Groupby 条件付き-----------------");
            var result2 = from p in _products
                          where p.Price > 250
                          orderby p.Price descending
                          group p by p.Price;
            foreach (var group in result2)
            {
                // グループごとにループ

                Debug.WriteLine("Groupe Key=" + group.Key);        // Key : groupしたプロパティ

                foreach (var row in group)
                {
                    Debug.WriteLine($"id={row.ProductId}\tname={row.ProductName}\tprice={row.Price}");
                }
            }
            Debug.WriteLine("");

        }
        internal void QueryGroupByMulti()
        {
            _products = new List<Product>();
            _products.Add(new Product(10, "p200", 200));
            _products.Add(new Product(20, "p200", 200));
            _products.Add(new Product(30, "p200", 220));
            _products.Add(new Product(40, "p200", 220));
            _products.Add(new Product(50, "p200", 300));
            _products.Add(new Product(60, "p300", 320));
            _products.Add(new Product(70, "p400", 320));

            //複数条件のグループ化
            Debug.WriteLine("------------ Groupby Multi ------------");
            var result2 = from p in _products
                          group p by new { p.ProductName, p.Price };

            foreach (var group in result2)
            {
                // グループごとにループ

                Debug.WriteLine("Groupe Key=" + group.Key);        // Key : groupしたプロパティ

                foreach (var row in group)
                {
                    Debug.WriteLine($"id={row.ProductId}\tname={row.ProductName}\tprice={row.Price}");
                }
            }
        }


    }

}
