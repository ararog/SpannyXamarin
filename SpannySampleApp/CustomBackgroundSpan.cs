using Android.Graphics;
using Android.Text.Style;
using Java.Lang;
using System;

namespace SpannySampleApp
{
    public class CustomBackgroundSpan : ReplacementSpan
    {

        private Color color;
        private int corner;

        public CustomBackgroundSpan(Color color, int corner)
        {
            this.color = color;
            this.corner = corner;
        }

        override public int GetSize(Paint paint, ICharSequence text, int start, int end, Paint.FontMetricsInt fm)
        {
            return (int) System.Math.Round(paint.TextSize);
        }

        override public void Draw(Canvas canvas, ICharSequence text, int start, int end, float x, int top, int y, int bottom, Paint paint)
        {
            paint.Color = color;
            RectF rect = new RectF(x, top, x + paint.MeasureText(text, start, end) + corner, bottom);
            canvas.DrawRoundRect(rect, corner, corner, paint);
            paint.Color = Color.White;
            canvas.DrawText(text, start, end, x + corner / 2, y, paint);
        }
    }
}
