using System;
using System.Collections.Generic;
using static Calculator.ChangeBase;


namespace Calculator
{
    public static class ReversePolish
    {
        public static string[] reverse_polish(string[] symbols) {
            var stack = new Stack<string>();            
            var ans = new string[symbols.Length];  
            var ind = 0;
            foreach (var t in symbols)
            {
                if (t.Equals("(")) {              
                    stack.Push(t);
                } else if (t.Equals(")")){        
                    while(!stack.Peek().Equals("(")){ 
                        ans[ind] = stack.Peek();          
                        stack.Pop();
                        ind++;
                    }
                    stack.Pop();                        
                } else if (is_operation(t)){        
                    if (stack.Count == 0 || operation_rank(t) > operation_rank(stack.Peek())){
                        stack.Push(t);    
                    } else {                       
                        ans[ind] = stack.Peek();     
                        stack.Pop();               
                        stack.Push(t);
                        ind++;
                    }
                } else {                             
                    ans[ind] = t;        
                    ind++;
                }
            }
            while (stack.Count != 0){
                ans[ind] = stack.Peek();         
                stack.Pop();
                ind++;
            }
            return ans;
        }
        
        public static int operation_rank(string oper){   //приоритет * и / самый высокий, у +, - меньше
            int rank = 0;                                //у ( - самый маленький
            if(oper.Equals("*") || oper.Equals("/")){
                rank = 2;
            } else if (oper.Equals("+") || oper.Equals("-")){
                rank = 1;
            }
            return rank;
        }
        
        public static bool is_operation(string str){
            var operation = new string[4]{"*", "/", "+", "-"};
            if (string.IsNullOrEmpty(str)) return false;
            for (int i = 0; i < operation.Length; i++) {
                if (str.Equals(operation[i])) return true;
            }
            return false;
        }

        public static bool is_number(string str) {
            if (string.IsNullOrEmpty(str)) return false;
            foreach (var t in str)
            {
                if (!Char.IsDigit(t) && !t.Equals(',') && !t.Equals('-')) return false;
            }
            return true;
        }
        
        public static double simple_calc(double x, double y, string operation)
        {
            var res = 0.0;
            switch (operation)
            {
                case "*":
                    res = y * x;
                    break;
                case "/":
                    if (x == 0)
                    {
                       Form1._Form1.update("На ноль делить нельзя!");
                       break;
                    }
                    res = y / x;
                    break;
                case "+":
                    res = y + x;
                    break;
                case "-":
                    res = y - x;
                    break;
            }
            //Form1._Form1.update(res.ToString());
            return res;
        }
        
        public static double calculation(string[] symbols)
        {
            var stack = new Stack<double>();           
            foreach (var t in symbols)
            {
                if (is_operation(t)){           
                    var tmp = stack.Pop();          
                    var res = simple_calc(tmp, stack.Pop(), t);   
                    stack.Push(res);
                }
                else if (is_number(t)) {
                    var tmp = double.Parse(t);
                    tmp = ToBase10(tmp);
                    stack.Push(tmp);
                }
            }

            return FromBase10(stack.Peek());
        }
    }
}
