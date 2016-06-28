using Android.Graphics;
using Android.Text.Style;
using Java.Lang;
using System;

namespace SpannySampleApp
{
    public class CustomAlignmentSpan : ReplacementSpan
    {
        public const int RIGHT_TOP = 1;
        public const int RIGHT_CENTER = 2;
        public const int RIGHT_BOTTOM = 3;

        private Color color = Color.White;
        private int position;

        public CustomAlignmentSpan(int position) {
            this.position = position;
        }

        public CustomAlignmentSpan(int position, Color color) {
            this.position = position;
            this.color = color;
        }

        override public int GetSize(Paint paint, ICharSequence text, int start, int end, Paint.
                FontMetricsInt fm) {
            return 0;
        }

        override public void Draw(Canvas canvas, ICharSequence text, int start, int end,
                                   float defaultX, int top, int defaultY, int bottom, Paint paint) {
            float x = 0;
            float y = 0;
            switch (position) {
                case RIGHT_TOP:
                    x = canvas.Width - paint.MeasureText(text, start, end);
                    y = paint.TextSize;
                    break;
                case RIGHT_CENTER:
                    x = canvas.Width - paint.MeasureText(text, start, end);
                    y = canvas.Height / 2;
                    break;
                case RIGHT_BOTTOM:
                    x = canvas.Width - paint.MeasureText(text, start, end);
                    y = canvas.Height - paint.GetFontMetricsInt().Bottom;
                    break;
            }
            if (color != -1)
                paint.Color = color;
            canvas.DrawText(text, start, end, x, y, paint);
        }
    }
}