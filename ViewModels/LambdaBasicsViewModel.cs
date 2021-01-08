using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lambda.ViewModels
{
    public class LambdaBasicsViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public LambdaBasicsViewModel()
        {
            NoLambdaButton = new DelegateCommand(NoLambdaButtonExe);
            NoLambdaWithLengthButton = new DelegateCommand(NoLambdaWithLengthButtonExe);
            DelegateButton1 = new DelegateCommand(DelegateButton1Exe);
            DelegateButton2 = new DelegateCommand(DelegateButton2Exe);
            DelegateButton3 = new DelegateCommand(DelegateButton3Exe);
            AnonymousMethodButton = new DelegateCommand(AnonymousMethodButtonExe);
            PredicateButton = new DelegateCommand(PredicateButtonExe);
            LambdaButton = new DelegateCommand(LambdaButtonExe);
            FuncButton = new DelegateCommand(FuncButtonExe);
            FuncMultiButton = new DelegateCommand(FuncMultiButtonExe);
            ActionWithParameterButton = new DelegateCommand(ActionWithParameterButtonExe);
            ActionWithoutParameterButton = new DelegateCommand(ActionWithoutParameterButtonExe);
            LambdaCollectionButton = new DelegateCommand(LambdaCollectionButtonExe);
            LambdaCustomClassButton = new DelegateCommand(LambdaCustomClassButtonExe);
        }

        //=======================================================================
        // ストレート実装
        public DelegateCommand NoLambdaButton { get; }
        private void NoLambdaButtonExe()
        {
            var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };

            var result = new List<string>();
            foreach (var val in values)
            {
                if (val.Length >= 3)
                {
                    result.Add(val);
                }
            }

            Debug.WriteLine(string.Join(",", result));


            //------------------------------------------------
            // メソッドの共通化
            var result2 = GetValue1(values);
            Debug.WriteLine(string.Join(",", result2));
        }

        private string[] GetValue1(string[] values)
        {
            var result = new List<string>();
            foreach (var val in values)
            {
                if (val.Length >= 3)
                {
                    result.Add(val);
                }
            }
            return result.ToArray();
        }

        //=======================================================================
        // ストレート実装，判定値渡し
        public DelegateCommand NoLambdaWithLengthButton { get; }
        private void NoLambdaWithLengthButtonExe()
        {
            var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };

            //------------------------------------------------
            // メソッドの共通化
            var result2 = GetValue2(values, 4);
            Debug.WriteLine(string.Join(",", result2));
        }
        private string[] GetValue2(string[] values, int len)
        {
            var result = new List<string>();
            foreach (var val in values)
            {
                if (val.Length >= len)
                {
                    result.Add(val);
                }
            }
            return result.ToArray();
        }

        //=======================================================================
        // delegate を使う
        // 引数として式やメソッドを渡す，という考えかた
        public DelegateCommand DelegateButton1 { get; }
        private void DelegateButton1Exe()
        {
            var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };

            // 引数としての delegete に判定式を渡す
            // 方法1：delegate と同じ引数戻り値のメソッドを用意し，引数とする
            // 　　　 そのメソッドの引数は，呼び出し「先」で渡す
            var result = GetValue3(values, Equation1);

            Debug.WriteLine(string.Join(",", result));

        }
        public DelegateCommand DelegateButton2 { get; }
        private void DelegateButton2Exe()
        {
            var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };

            var result = GetValue3(values, Equation2);

            Debug.WriteLine(string.Join(",", result));

        }

        // delegate の定義：戻り値（何でも可），名前，引数（複数可） を記述する
        delegate bool LenCheck(string value);

        // delegate を引数として渡して使う
        // LenCheck は，string を渡して bool を返す判定メソッド
        // その判定結果を GetValue3 メソッド内で使う．判定基準は呼び出し元など他のところで作れることになる
        private string[] GetValue3(string[] values, LenCheck lenCheck)
        {
            var result = new List<string>();
            foreach (var val in values)
            {
                if (lenCheck(val))
                {
                    result.Add(val);
                }
            }
            return result.ToArray();
        }
        private bool Equation1(string value)
        {
            return value.Length == 3;
        }
        private bool Equation2(string value)
        {
            return value.Length >= 4;
        }


        //=======================================================================
        // delegate の内容メソッド(Equation*)に引数を渡す方法
        public DelegateCommand DelegateButton3 { get; }
        private void DelegateButton3Exe()
        {
            var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };

            var result = GetValue4(values, 2, Equation4);

            Debug.WriteLine(string.Join(",", result));
        }

        delegate bool LenCheck2(string value, int len);

        private string[] GetValue4(string[] values, int len, LenCheck2 lenCheck)
        {
            var result = new List<string>();
            foreach (var val in values)
            {
                if (lenCheck(val, len))
                {
                    result.Add(val);
                }
            }
            return result.ToArray();
        }
        private bool Equation3(string value, int len)
        {
            return value.Length == len;
        }
        private bool Equation4(string value, int len)
        {
            return value.Length >= len;
        }


        //=======================================================================
        // 匿名メソッドを使う
        public DelegateCommand AnonymousMethodButton { get; }
        private void AnonymousMethodButtonExe()
        {
            var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };

            // delegate bool LenCheck(string value);
            // の代わりに，匿名メソッドを直接引数に書いてしまう
            // delegate 定義と同じ 引数，戻り値 となるメソッドを下記書式で記述できる
            var result = GetValue3(values,
            delegate (string s)
                {
                    return s.Length >= 3;
                }
                );
            Debug.WriteLine(string.Join(",", result));
        }


        //=======================================================================
        // Predicate を使う
        public DelegateCommand PredicateButton { get; }
        private void PredicateButtonExe()
        {
            var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };

            var result = GetValue4(values,
            delegate (string s)
            {
                return s.Length <= 3;
            }
                );
            Debug.WriteLine(string.Join(",", result));
        }
        // プレディケート = あらかじめ用意されているデリゲート
        // bool を返す．引数は任意
        // delegate 定義は不要
        private string[] GetValue4(string[] values, Predicate<string> predicate)
        {
            var result = new List<string>();
            foreach (var val in values)
            {
                if (predicate(val))
                {
                    result.Add(val);
                }
            }
            return result.ToArray();
        }


        //=======================================================================
        // Lambda 式 基本形
        public DelegateCommand LambdaButton { get; }
        private void LambdaButtonExe()
        {
            var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };

            // 匿名メソッド
            var result = GetValue5(values,
            delegate (string s)
                {
                    return s.Length == 3;
                }
                );

            // Lambda 式 パターン1
            var result2 = GetValue5(values,
                (s) =>
                {
                    return s.Length == 3;
                }
                );

            // Lambda 式 パターン2
            var result3 = GetValue5(values,
                s =>
                {
                    return s.Length == 3;
                }
                );

            // Lambda 式 パターン3
            var result4 = GetValue5(values, s => s.Length == 2);

            Debug.WriteLine(string.Join(",", result4));
        }
        private string[] GetValue5(string[] values, Predicate<string> predicate)
        {
            var result = new List<string>();
            foreach (var val in values)
            {
                if (predicate(val))
                {
                    result.Add(val);
                }
            }
            return result.ToArray();
        }


        //=======================================================================
        // Func を使う
        // delegate bool LenCheck2(string value, int len);
        // Predicate は戻り値bool，引数一つに限定されているが，Funcはすべて任意
        // delegate 記述しなくてもよい
        // Func 引数に対して，匿名メソッドやラムダ式も使える
        public DelegateCommand FuncButton { get; }
        private void FuncButtonExe()
        {
            var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };

            // 匿名メソッド
            var anonymous_result = GetValue6(values, 2,
                                             delegate (string s, int len)
                                             {
                                                 return s.Length >= len;
                                             });
            // Lambda式 1
            var lambda_result1 = GetValue6(values, 2,
                                             (s, len) =>
                                             {
                                                 return s.Length >= len;
                                             });

            // Lambda式 2 = Func を使ったかたち
            var lambda_result2 = GetValue6(values, 2, (s, len) => s.Length >= len);

            Debug.WriteLine(string.Join(",", anonymous_result));
            Debug.WriteLine(string.Join(",", lambda_result1));
            Debug.WriteLine(string.Join(",", lambda_result2));
        }
        private string[] GetValue6(string[] values, int len, Func<string, int, bool> lenCheck)
        {
            var result = new List<string>();
            foreach (var val in values)
            {
                if (lenCheck(val, len))
                {
                    result.Add(val);
                }
            }
            return result.ToArray();
        }


        //=======================================================================
        // 複数行の処理を行う Func を使う
        // {}で囲み，きちんと return するように記述する
        public DelegateCommand FuncMultiButton { get; }
        private void FuncMultiButtonExe()
        {
            var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };
            var result = GetValue6(values, 2,
                            (s, len) =>
                            {
                                if (s[0] == 'E')
                                {
                                    return s.Length > len;
                                }

                                return false;
                            });

            Debug.WriteLine(string.Join(",", result));
        }


        //=======================================================================
        // Action を使う
        // delegate void ***(*** ***) と同じ役割，引数は任意にとれる
        // 引数として渡した（戻り値なしの）メソッドを，呼び出し先で呼び出せる
        public DelegateCommand ActionWithParameterButton { get; }
        private void ActionWithParameterButtonExe()
        {
            // ストレートな方法：メソッドを定義する
            GetData7(DoConsole1);

            // 匿名メソッドを使う
            GetData7(delegate (int value) { Debug.WriteLine(value + "%"); });

            // Lambda式で記述
            // "Action の引数とその処理" を引数として Lambda式で渡す
            GetData7(value => Debug.WriteLine(value + "%"));
            GetData7(x => Title = x.ToString() + " %");
        }

        private void DoConsole1(int value)
        {
            Debug.WriteLine(value + "%");
        }
        // Action を引数としたメソッド
        // Action 自体の引数はこのメソッド内で渡される
        private List<string> GetData7(Action<int> progressAction)
        {
            var result = new List<string>();
            for (int i = 1; i <= 5; i++)
            {
                result.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff"));
                System.Threading.Thread.Sleep(300);
                progressAction(i * 20);
            }

            return result;
        }



        //=======================================================================
        // パラメータなしの Action を使う
        // delegate void ***() と同じ役割
        public DelegateCommand ActionWithoutParameterButton { get; }
        private void ActionWithoutParameterButtonExe()
        {
            // ストレートな方法
            GetData8(DoConsole2);

            // 匿名メソッドを使う
            GetData8(delegate () { Debug.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff")); });

            // Lambda式を使う
            GetData8(() => Debug.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff")));
        }

        private void DoConsole2()
        {
            Debug.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff"));
        }
        private List<string> GetData8(Action progressAction)
        {
            var result = new List<string>();
            for (int i = 1; i <= 5; i++)
            {
                result.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff"));
                System.Threading.Thread.Sleep(300);
                progressAction();
            }

            return result;
        }



        //=======================================================================
        // Collection に対する Lambda の基本的な書き方
        public DelegateCommand LambdaCollectionButton { get; }
        private void LambdaCollectionButtonExe()
        {
            var values = new List<string> { "ABCDE", "AAA", "BBBB", "CCCC", "DDDD" };

            // Find(Predicate<string> match)
            //  ：boolを返す判定条件を満たすものを見つけるメソッド
            // Collection values の中で，"B" を含むものを result1 に入れる
            var result1 = values.Find(x => x.Contains("B"));
            Debug.WriteLine("Find    :" + string.Join(",", result1));

            var result2 = values.FindAll(x => x.Contains("B"));
            Debug.WriteLine("FindAll :" + string.Join(",", result2));

            var result3 = values.Exists(x => x.Contains("B"));
            Debug.WriteLine("Exists  :" + string.Join(",", result3));

            // Where：FindAll と同じだが… List だけでなく，Enumerable でも使える（Linq）
            // 遅延実行 --結果を使うときにwhereが実行される
            // result4 の例では，"EEEB" が追加されたvalues に対してWhereが実行される
            //  -> 複数条件を設定することが可能
            var result4 = values.Where(x => x.Contains("B"));
            values.Add("EEEB");
            Debug.WriteLine("Where   :" + string.Join(",", result4));
            // ただし，result5に対しToListなどの処理を行って代入する場合は，その時点でWhereが実行される
            // result5 では"EEEB2"は追加されていない
            var result5 = values.Where(x => x.Contains("B")).ToList();
            values.Add("EEEB2");
            Debug.WriteLine("Where   :" + string.Join(",", result5));

            // Any：Exists と同じだが… List だけでなく，Enumerable でも使える（Linq）
            var result6 = values.Any(x => x.Contains("B"));
            Debug.WriteLine("Any     :" + string.Join(",", result6));
        }


        //=======================================================================
        // カスタムクラス に対する Lambda の基本的な書き方
        public DelegateCommand LambdaCustomClassButton { get; }
        private void LambdaCustomClassButtonExe()
        {
            // カスタムクラス 
            var products = new List<Product>();
            products.Add(new Product(1, "P1"));
            products.Add(new Product(2, "P2"));
            products.Add(new Product(3, "P31"));

            var result1 = products.Find(x => x.ProductId == 2);
            Debug.WriteLine("Find ID=2 :" + string.Join(",", result1.ProductName));

            var result2 = products.FindAll(x => x.ProductName.Contains("1"));
            foreach (var val in result2)
            {
                Debug.WriteLine("FindAll   :" + string.Join(",", val.ProductName));
            }
        }

    }

    public class Product
    {
        public Product(int productId, string productName)
        {
            ProductId = productId;
            ProductName = productName;
        }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}


