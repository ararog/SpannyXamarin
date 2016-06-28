using Android.Graphics;
using Android.Text;
using Android.Text.Style;
using System;

namespace SpannySampleApp
{
    public class CustomTypefaceSpan : TypefaceSpan
    {
        private Typeface newType;

		public CustomTypefaceSpan(Typeface type) : base("")
        {
            newType = type;
        }

        public CustomTypefaceSpan(String family, Typeface type) : base(family)
        {
            newType = type;
        }

		public override void UpdateDrawState(TextPaint textPaint) {
            ApplyCustomTypeFace(textPaint, newType);
        }

		public override void UpdateMeasureState(TextPaint paint) {
            ApplyCustomTypeFace(paint, newType);
        }

        private static void ApplyCustomTypeFace(Paint paint, Typeface tf) {
            TypefaceStyle oldStyle;
            Typeface old = paint.Typeface;
            if (old == null) {
                oldStyle = 0;
            } else {
                oldStyle = old.Style;
            }

            TypefaceStyle fake = oldStyle & ~tf.Style;
            if ((fake & TypefaceStyle.Bold) != 0) {
                paint.FakeBoldText = true;
            }

            if ((fake & TypefaceStyle.Italic) != 0) {
                paint.TextSkewX = -0.25f;
            }

            paint.SetTypeface(tf);
        }
    }
}