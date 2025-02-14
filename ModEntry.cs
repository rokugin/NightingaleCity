using StardewModdingAPI;
using StardewModdingAPI.Events;
using NightingaleCity.ClockTower;
using NightingaleCity.Integrations;

namespace NightingaleCity;

internal class ModEntry : Mod {

    public static ModConfig Config = new();

    public override void Entry(IModHelper helper) {
        Log.Init(Monitor);
        I18n.Init(helper.Translation);

        Config = helper.ReadConfig<ModConfig>();

        helper.Events.GameLoop.GameLaunched += OnGameLaunched;
        helper.Events.Display.RenderedWorld += OnRenderedWorld;
    }

    private void OnRenderedWorld(object? sender, RenderedWorldEventArgs e) {
        ClockHands.RenderClockHands(e);
    }

    private void OnGameLaunched(object? sender, GameLaunchedEventArgs e) {
        ConfigScreen.Setup(Helper, ModManifest);
    }

}