namespace mauiclient.Resources.Views;

public partial class BorderlessEntry : Microsoft.Maui.Controls.Entry
{
	public BorderlessEntry()
	{
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, view) =>
        {
            #if __ANDROID__
                handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);

            #elif __IOS__
                handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;

            #endif
        });
    }
}