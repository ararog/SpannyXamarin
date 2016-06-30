# Spanny
A helper class that extends SpannableStringBuilder and adds methods to easily mark the text with multiple spans.

![example](http://i.imgur.com/NPnl0yy.png?1)

### Download
[Download from NuGet](https://www.nuget.org/packages/SpannyXamarin/)
```
Install-Package SpannyXamarin
```

### Usage
Use `.Append(text, span)` to add and mark the text with any span:
```csharp
Spanny spanny = new Spanny("Underline text", new UnderlineSpan())
                .Append("\nRed text", new ForegroundColorSpan(Color.Red))
                .Append("\nPlain text");
textView.TextFormatted = spanny;
```
Mark the text with multiple spans:
```csharp
spanny.Append("Blue underlined text", new ForegroundColorSpan(Color.Blue), new UnderlineSpan());
```
If you need a single SpannableString you can use a static method `.SpanText`:
```csharp
textView.TextFormatted = Spanny.SpanText("Underline text", new UnderlineSpan());
```
Find and span multiple appearences of a string:
```csharp
Spanny spanny = new Spanny("All 'a' will be red.")
spanny.FindAndSpan("a", () => {
    return new ForegroundColorSpan(Color.RED);
});
```

Example
--------
List of all available spans: [http://developer.android.com/reference/android/text/style/package-summary.html][3]

Check the [sample app][2] for custom spannables.

You can easily make a text with over 20 styles in a single TextView:

```csharp
Spanny spanny = new Spanny("StyleSpan", new StyleSpan(Typeface.BoldItalic))
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
                .Append("\n\nMultiple spans", new StyleSpan(Typeface.Italic), new UnderlineSpan(),
                        new TextAppearanceSpan(this, Android.Resource.Style.TextAppearanceLarge),
                        new AlignmentSpanStandard(Layout.Alignment.AlignCenter), new BackgroundColorSpan(Color.LightGray));
        textView.TextFormatted = spanny;
```

Feel free to pull request a custom spannable.

License
--------

    Copyright 2015 Pavlovsky Ivan

    Licensed under the Apache License, Version 2.0 (the "License");
    you may not use this file except in compliance with the License.
    You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

    Unless required by applicable law or agreed to in writing, software
    distributed under the License is distributed on an "AS IS" BASIS,
    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    See the License for the specific language governing permissions and
    limitations under the License.

 [1]: https://github.com/ararog/SpannyXamarin/blob/master/SpannyXamarin/Spanny.cs
 [2]: https://github.com/ararog/SpannyXamarin/tree/master/SpannySampleApp
 [3]: http://developer.android.com/reference/android/text/style/package-summary.html
