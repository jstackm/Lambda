using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda.Domain
{
    internal sealed class L03_CustomClassWhere
    {
        private List<Product> _products;

        internal void QueryCustomClassWhere()
        {
            _products = new List<Product>();
            _products.Add(new Product(10, "p10A", 300));
            _products.Add(new Product(20, "p20", 300));
            _products.Add(new Product(30, "x301A", 200));
            _products.Add(new Product(40, "P40A", 500));

            // カスタムクラスでの条件つき検索
            var result1 = from p in _products
                          where p.ProductName[0] == 'p'
                          select p;
            foreach (var val in result1)
            {
                Debug.WriteLine($"result1 id={val.ProductId} \t name={val.ProductName} \t price={val.Price}");
            }
            Debug.WriteLine("");


            // OrderBy の書き方：昇順
            var result2 = from p in _products
                          where p.ProductName.ToLower()[0] == 'p'   // 大文字小文字区別しない
                          orderby p.Price
                          select p;
            foreach (var val in result2)
            {
                Debug.WriteLine($"result2 id={val.ProductId} \t name={val.ProductName} \t price={val.Price}");
            }
            Debug.WriteLine("");


            // OrderBy の書き方：降順
            var result3 = from p in _products
                          where p.ProductName.ToLower()[0] == 'p'   // 大文字小文字区別しない
                          orderby p.Price descending
                          select p;
            foreach (var val in result3)
            {
                Debug.WriteLine($"result3 id={val.ProductId} \t name={val.ProductName} \t price={val.Price}");
            }
            Debug.WriteLine("");


            // OrderBy の書き方：降順＆複数条件
            var result4 = from p in _products
                          where p.ProductName.ToLower()[0] == 'p'               // 大文字小文字区別しない
                          orderby p.Price descending, p.ProductId descending    // Priceが同じときはIdで降順
                          select p;
            foreach (var val in result4)
            {
                Debug.WriteLine($"result4 id={val.ProductId} \t name={val.ProductName} \t price={val.Price}");
            }
            Debug.WriteLine("");


            // OrderBy の書き方：降順＆複数条件＆必要な項目のみを取得 
            var result5 = from p in _products
                          where p.ProductName.ToLower()[0] == 'p'               // 大文字小文字区別しない
                          orderby p.Price descending, p.ProductId descending    // Priceが同じときはIdで降順
                          select p.ProductName;
            foreach (var val in result5)
            {
                Debug.WriteLine($"result5 name={val}");
            }
            Debug.WriteLine("");


            // OrderBy の書き方：降順＆複数条件＆必要な項目を複数取得 
            var result6 = from p in _products
                          where p.ProductName.ToLower()[0] == 'p'               // 大文字小文字区別しない
                          orderby p.Price descending, p.ProductId descending    // Priceが同じときはIdで降順
                          // select p.ProductName, p.Price;                     // こんな風にかけそうだが…
                          select new { p.ProductName, p.Price };                // new {} が必要
            foreach (var val in result6)
            {
                Debug.WriteLine($"result6 name={val.ProductName} \t price={val.Price}");
            }
            Debug.WriteLine("");


            // 別名のつけ方
            var result7 = from p in _products
                          where p.ProductName.ToLower()[0] == 'p'               // 大文字小文字区別しない
                          orderby p.Price descending, p.ProductId descending    // Priceが同じときはIdで降順
                          select new { p.ProductName, AAA = p.Price + "円" };    // 別名をつけてメンバをとってくることもでき，
                                                                                // そうすると値を加工することができる
            foreach (var val in result7)
            {
                Debug.WriteLine($"result7 name={val.ProductName} \t price={val.AAA}");
            }
            Debug.WriteLine("");


            // 別のクラスに置き換える
            var result8 = from p in _products
                          where p.ProductName.ToLower()[0] == 'p'               // 大文字小文字区別しない
                          orderby p.Price descending, p.ProductId descending    // Priceが同じときはIdで降順
                          select new ProductDto(p.ProductId.ToString(), p.ProductName);
            foreach (var val in result8)
            {
                Debug.WriteLine($"result8 {val}");
            }
            Debug.WriteLine("");


            // 別のクラスに置き換える：置き換え先クラスで，処理にフィットするコンストラクタを用意しておいてもよい
            var result9 = from p in _products
                          where p.ProductName.ToLower()[0] == 'p'               // 大文字小文字区別しない
                          orderby p.Price descending, p.ProductId descending    // Priceが同じときはIdで降順
                          select new ProductDto(p);                             // 形式を考慮しておけばシンプルになる
            foreach (var val in result9)
            {
                Debug.WriteLine($"result9 {val}");
            }
            Debug.WriteLine("");


            // 別のクラスに置き換える：置き換え先クラスにコンストラクタがない場合
            var result10 = from p in _products
                           where p.ProductName.ToLower()[0] == 'p'                  // 大文字小文字区別しない
                           orderby p.Price descending, p.ProductId descending       // Priceが同じときはIdで降順
                           select new ProductEntity                                 // コンストラクタ初期化 { } が使える　
                           {                                                        // プロパティは set できるようにしておくこと
                               ProductId = p.ProductName.ToString(),
                               ProductName=p.ProductName
                           };                             // 形式を考慮しておけばシンプルになる
            foreach (var val in result10)
            {
                Debug.WriteLine($"result10 {val}");
            }
            Debug.WriteLine("");



        }

    }
}
