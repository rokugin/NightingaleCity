using StardewModdingAPI;
using StardewModdingAPI.Events;
using NightingaleCity.ClockTower;
using NightingaleCity.Integrations;
using StardewValley;
using Microsoft.Xna.Framework.Graphics;

namespace NightingaleCity;

internal class ModEntry : Mod {

    public static ModConfig Config = new();

    public override void Entry(IModHelper helper) {
        Log.Init(Monitor);
        I18n.Init(helper.Translation);

        Config = helper.ReadConfig<ModConfig>();

        helper.Events.GameLoop.GameLaunched += OnGameLaunched;
        helper.Events.Display.RenderedWorld += OnRenderedWorld;
        helper.Events.GameLoop.SaveLoaded += OnSaveLoaded;
        helper.Events.Player.Warped += OnWarped;
    }

    private void OnSaveLoaded(object? sender, SaveLoadedEventArgs e) {
        if (ClockHands.ClockTexture == null) {
            ClockHands.ClockTexture = Game1.content.Load<Texture2D>("Maps/rokuginClockTowerTilesheet");
        }
    }

    private void OnWarped(object? sender, WarpedEventArgs e) {
        ClockHands.ShouldRender = e.NewLocation == Game1.getLocationFromName("Town");
    }

    private void OnRenderedWorld(object? sender, RenderedWorldEventArgs e) {
        ClockHands.RenderClockHands(e);
    }

    private void OnGameLaunched(object? sender, GameLaunchedEventArgs e) {
        ConfigScreen.Setup(Helper, ModManifest);
    }

}