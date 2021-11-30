using System;


namespace Calculator
{
    public class ChangeBase
    {
        public static double ToBase(double number)
        {
            var base10 = ToBase10(number);
            var rtn = FromBase10(base10);
            return rtn;
        }

        public static double ToBase10(double number)
        {
            var sign = Math.Sign(number);
            number = Math.Abs(number);
            int m;
            var res = 0.0;
            var str_number = number.ToString();
            if (str_number.Contains(",")) {
                m = str_number.IndexOf(",") - 1;
                foreach (var c in str_number)
                {
                    if (c.Equals(',')) continue;
                    res += (c - '0') *  Math.Pow(9, m);
                    m--;
                }
            } else {
                m = str_number.Length - 1; 
                foreach (var c in str_number)
                {
                    res += (c - '0') * Math.Pow(9, m);
                    m--;
                }
            }

            return res * sign;
        }

        public static double FromBase10(double number)
        {
            var q = 0;
            var sign = Math.Sign(number);
            number = Math.Abs(number);
            // пытаемся работать с double , но при смене сс приходится использовать int 
            // если число не может быть аккуратно приведено к int'у, то выдаём исключение
            try
            {
                 q = Convert.ToInt32(Math.Floor(number));
            }
            catch
            {
                Form1._Form1.update("Результат является слишком большим числом :(");
                return 0;
            }
            var r = 0;
            var res = "";
            if (q == 0) {
                res += "0";
            } else {
                while (q != 0) {
                    r = q % 9;
                    q = q / 9;
                    res = r + res;
                }
            }
            
            if (number - Math.Floor(number) > Math.Pow(10, -6)) {
                res += ',';
                var v =  number - Math.Floor(number);
                var counter = 0;
                while (counter < 5){
                    res += Math.Floor(v * 9);
                    v = v * 9 - Math.Floor(v * 9);
                    counter++;
                }
            }
            var separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];
            res = res.Replace( ',' , separator);
            return Convert.ToDouble(res) * sign;
        }
    }
}
