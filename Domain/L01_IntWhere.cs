using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda.Domain
{
    internal sealed class L01_IntWhere
    {
        int[] _nums;
        internal L01_IntWhere()
        {
            _nums = new int[] { 1, 3, 2, 5, 4, 7, 6, 5 };
        }

        internal void QueryIntWhere()
        {
            Debug.WriteLine("------------ Query Where -----------------");
            // クエリ構文での書き方：
            var result1 = from num in _nums         // foreach ( ver num in _nums ) {} と同じ意味
                          where num >= 5            // ループでとってきた num が 5 以上かどうか判定
                          select num;               // 条件に合致すれば result1 に入れる
            Debug.WriteLine(string.Join(",", result1));


            var result2 = from num in _nums         // foreach ( ver num in _nums ) {} と同じ意味
                          where num >= 3            // ループでとってきた num が 3 以上かどうか判定
                          && num <= 5               //  さらに 5 以下かどうか判定
                          || num == 7               //  加えて 7 は必ず選択
                          orderby num               //  それらを昇順で並べる
                          select num;               // 条件に合致すれば result1 に入れる
            Debug.WriteLine(string.Join(",", result2));


            var result3 = from num in _nums         // foreach ( ver num in _nums ) {} と同じ意味
                          where num >= 3            // ループでとってきた num が 3 以上かどうか判定
                          && num <= 5               //  さらに 5 以下かどうか判定
                          || num == 7               //  加えて 7 は必ず選択
                          orderby num descending    //  降順で並べタイ場合は descending を指定
                          select num;               // 条件に合致すれば result1 に入れる
            Debug.WriteLine(string.Join(",", result3));

        }

        internal void LambdaIntWhere()
        {
            Debug.WriteLine("------------ Lambda Where -----------------");
            var result1 = _nums.Where(x => x >= 5);

            Debug.WriteLine(string.Join(",", result1));

            var result2 = _nums.Where(x => x >= 3 && x <= 5 || x == 7);
            Debug.WriteLine(string.Join(",", result2));


        }



    }
}
