using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda.Domain
{
    internal sealed class L02_StringWhere
    {
        string[] _values;
        internal L02_StringWhere()
        {
            _values = new string[] { "A", "BB", "CCC", "DDDD", "EEEE", "ABC" };
        }

        internal void QueryStringWhere()
        {
            // クエリ構文での書き方
            // 全文字をとってくる
            var result1 = from s in _values
                          select s;
            Debug.WriteLine(string.Join(",", result1));

            // 検索条件あり：大文字小文字関係なし
            var result2 = from s in _values
                          where s.ToLower().Contains("a")             // 条件は from と select の間に持ってくる
                          select s;
            Debug.WriteLine(string.Join(",", result2));

            // 検索条件あり：文字列の長さ判定
            var result3 = from s in _values
                          where s.ToLower().Contains("a")             // 条件は from と select の間に持ってくる
                          && s.Length >= 3
                          select s;
            Debug.WriteLine(string.Join(",", result3));

        }

    }
}
