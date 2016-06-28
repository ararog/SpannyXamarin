using Android.Text;
using Android.Text.Style;
using Java.Lang;

namespace Xamarin.Spanny
{
    public class Spanny : SpannableStringBuilder
    {
        private SpanTypes flag = SpanTypes.ExclusiveExclusive;

        public Spanny() : base("")
        {

        }

        public Spanny(string text) : base(text)
        {
            
        }

        public Spanny(string text, params Object[] spans) : base(text)
        {
            foreach (Object span in spans)
            {
                SetSpan(span, 0, Length());
            }
        }

        public Spanny(string text, Object span) : base(text)
        {
            SetSpan(span, 0, text.Length);
        }

        public Spanny Append(string text, params Object[] spans)
        {
            Append(text);
            foreach (Object span in spans)
            {
                SetSpan(span, Length() - text.Length, Length());
            }
            return this;
        }

        public Spanny Append(string text, Object span)
        {
            Append(text);
            SetSpan(span, Length() - text.Length, Length());
            return this;
        }

        public Spanny Append(string text, ImageSpan imageSpan)
        {
            text = "." + text;
            Append(text);
            SetSpan(imageSpan, Length() - text.Length, Length() - text.Length + 1);
            return this;
        }

        public new Spanny Append(string text)
        {
            base.Append(text);
            return this;
        }

        public Spanny AppendText(string text)
        {
            Append(text);
            return this;
        }

        public void SetFlag(SpanTypes flag)
        {
            this.flag = flag;
        }

        private void SetSpan(Object span, int start, int end)
        {
            SetSpan(span, start, end, flag);
        }

        public Spanny FindAndSpan(string textToSpan, GetSpan getSpan)
        {
            int lastIndex = 0;
            while (lastIndex != -1)
            {
                lastIndex = ToString().IndexOf(textToSpan.ToString(), lastIndex);
                if (lastIndex != -1)
                {
                    SetSpan(getSpan.GetSpan(), lastIndex, lastIndex + textToSpan.Length);
                    lastIndex += textToSpan.Length;
                }
            }
            return this;
        }

        public interface GetSpan
        {
            Object GetSpan();
        }

        public static SpannableString SpanText(string text, params Object[] spans)
        {
            SpannableString spannableString = new SpannableString(text);
            foreach (Object span in spans)
            {
                spannableString.SetSpan(span, 0, text.Length, SpanTypes.ExclusiveExclusive);
            }
            return spannableString;
        }

        public static SpannableString SpanText(string text, Object span)
        {
            SpannableString spannableString = new SpannableString(text);
            spannableString.SetSpan(span, 0, text.Length, SpanTypes.ExclusiveExclusive);
            return spannableString;
        }
    }
}
