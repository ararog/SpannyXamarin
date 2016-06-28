using Android.App;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using Xamarin.Spanny;
using Android.Text.Style;
using Android.Text;
using Java.Lang;

namespace SpannySampleApp
{
    [Activity(Label = "SpannySampleApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Typeface typeface = Typeface.CreateFromAsset(Assets, "fonts/Pacifico.ttf");
            ActionBar.TitleFormatted = Spanny.SpanText("Spanny", new CustomTypefaceSpan(typeface));
            TextView textView = (TextView)FindViewById(Resource.Id.textView);
            Spanny spanny = new Spanny("StyleSpan\n", new StyleSpan(TypefaceStyle.BoldItalic))
                    .Append("CustomTypefaceSpan", new CustomTypefaceSpan(typeface))
                    .Append("CustomAlignmentSpan", new CustomAlignmentSpan(CustomAlignmentSpan.RIGHT_TOP))
                    .Append("\nUnderlineSpan, ", new UnderlineSpan())
                    .Append(" TypefaceSpan, ", new TypefaceSpan("serif"))
                    .Append("URLSpan, ", new URLSpan("google.com"))
                    .Append("StrikethroughSpan", new StrikethroughSpan())
                    .Append("\nQuoteSpan", new QuoteSpan(Color.Red))
                    .Append("\nPlain text")
                    .Append("SubscriptSpan", new SubscriptSpan())
                    .Append("SuperscriptSpan", new SuperscriptSpan())
                    .Append("\n\nBackgroundSpan", new BackgroundColorSpan(Color.LightGray))
                    .Append("\n\nCustomBackgroundSpan", new CustomBackgroundSpan(Color.DarkGray, dp(16)))
                    .Append("\n\nForegroundColorSpan", new ForegroundColorSpan(Color.LightGray))
                    .Append("\nAlignmentSpan", new AlignmentSpanStandard(Layout.Alignment.AlignCenter))
                    .Append("\nTextAppearanceSpan\n", new TextAppearanceSpan(this, Android.Resource.Style.TextAppearanceMedium))
                    .Append("ImageSpan", new ImageSpan(ApplicationContext, Resource.Drawable.Icon))
                    .Append("\nRelativeSizeSpan", new RelativeSizeSpan(1.5f))
                    .Append("\n\nMultiple spans", new StyleSpan(TypefaceStyle.Italic), new UnderlineSpan(),
                            new TextAppearanceSpan(this, Android.Resource.Style.TextAppearanceLarge),
                            new AlignmentSpanStandard(Layout.Alignment.AlignCenter), new BackgroundColorSpan(Color.LightGray));
            textView.TextFormatted = spanny;

            spanny = new Spanny("\n\nFind and span the word. All appearances of the word will be spanned.");
            spanny.FindAndSpan("word", new AnotherSpan());
            
            textView.Append(spanny);
        }

        private int dp(int value)
        {
            return (int)System.Math.Ceiling(Resources.DisplayMetrics.Density * value);
        }
    }

    class AnotherSpan : Spanny.GetSpan
    {
        Java.Lang.Object Spanny.GetSpan.GetSpan()
        {
            return new UnderlineSpan();
        }
    }
}

