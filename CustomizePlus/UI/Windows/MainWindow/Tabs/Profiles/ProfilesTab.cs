using CustomizePlus.Configuration.Data;
using CustomizePlus.Configuration.Services;

namespace CustomizePlus.UI.Windows.MainWindow.Tabs.Profiles;

public class ProfilesTab : TwoPanelLayout, ITab<MainTabType>
{
    private readonly PluginConfiguration _configuration;
    //private readonly ProfileFileSystemSelector _selector;

    public ProfilesTab(/*ProfileFileSystemSelector selector, */ProfilePanel panel, PluginConfiguration configuration)
    {
        _configuration = configuration;
       /* _selector = selector;
        LeftHeader = selector.Header;
        LeftFooter = selector.Footer;
        LeftPanel = selector;*/
        RightHeader = panel;
        RightFooter = EmptyHeaderFooter.Instance;
        RightPanel = panel;
    }

    public override ReadOnlySpan<byte> Label
        => "ProfilesTab"u8;

    public MainTabType Identifier
        => MainTabType.Profiles;

    public void DrawContent()
        => Draw(new TwoPanelWidth(_configuration.UISettings.CurrentProfileSelectorWidth, ScalingMode.Absolute));

    protected override void SetWidth(float width, ScalingMode mode)
    {
        var adaptedSize = MathF.Round(width / Im.Style.GlobalScale);
        if (Math.Abs(adaptedSize - _configuration.UISettings.CurrentProfileSelectorWidth) < 0.1f)
            return;

        _configuration.UISettings.CurrentProfileSelectorWidth = adaptedSize;
        _configuration.Save();
    }

   /* protected override void DrawPopups()
        => _selector.DrawSelectorPopups();*/

    protected override float MinimumWidth
        => Im.ContentRegion.Available.X * _configuration.UISettings.ProfileSelectorMinimumScale;

    protected override float MaximumWidth
        => MathF.Max(MinimumWidth, MathF.Min(
            Im.ContentRegion.Available.X * _configuration.UISettings.ProfileSelectorMaximumScale,
            Im.ContentRegion.Available.X - 470 * Im.Style.GlobalScale));
}
