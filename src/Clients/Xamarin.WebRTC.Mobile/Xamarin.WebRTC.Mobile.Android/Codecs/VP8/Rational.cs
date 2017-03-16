using System;

using Android.Runtime;

namespace Xamarin.WebRTC.Mobile.Android.Codecs.VP8
{
    class Rational
    {
        private long n;
        private long d;

        public Rational()
        {
            n = 0;
            d = 1;
        }

        public Rational(long num, long den)
        {
            this.n = num;
            this.d = den;
        }

        public Rational(string num, string den)
        {
            this.n = Int64.Parse(num);
            this.d = Int64.Parse(den);
        }

        public Rational multiply(Rational b)
        {
            return new Rational(n * b.num(), d * b.den());
        }

        public Rational multiply(int b)
        {
            return new Rational(n * b, d);
        }

        public Rational reciprocal()
        {
            return new Rational(d, n);
        }

        public float toFloat()
        {
            return (float)n / (float)d;
        }

        public long toLong()
        {
            // TODO(frkoenig) : consider adding rounding to the divide.
            return n / d;
        }

        public long num()
        {
            return n;
        }

        public long den()
        {
            return d;
        }

        public String toString()
        {
            if (d == 1)
            {
                return n.ToString();
            }
            else
            {
                return string.Format("{0}/{1}", n.ToString(), d.ToString());
            }
        }

        public String toColonSeparatedString()
        {
            return string.Format("{0}:{1}", n.ToString(), d.ToString());
        }
    }
}