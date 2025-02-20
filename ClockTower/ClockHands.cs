using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using Microsoft.Xna.Framework;

namespace NightingaleCity.ClockTower;

public class ClockHands {

    public static Texture2D? ClockTexture;
    public static bool ShouldRender = false;

    static float hourRotation;
    static float minuteRotation;

    static Vector2 hourPosition = new Vector2(25f, 47f) * 64;
    static Vector2 minutePosition = new Vector2(25f, 47f) * 64;
    static Vector2 nubPosition = new Vector2(25f, 47f) * 64;

    static Rectangle hourSource = new Rectangle(96, 80, 7, 8);
    static Rectangle minuteSource = new Rectangle(96, 64, 7, 11);
    static Rectangle nubSource = new Rectangle(47, 79, 2, 2);

    static Color hourColor = Color.White * 1;
    static Color minuteColor = Color.White * 1;
    static Color nubColor = Color.White * 1;

    static Vector2 hourOrigin = new Vector2(3.5f, 8f);
    static Vector2 minuteOrigin = new Vector2(3.5f, 11f);
    static Vector2 nubOrigin = new Vector2(1f, 1f);

    static float hourScale = 4f;
    static float minuteScale = 4f;
    static float nubScale = 4f;

    static int towerTileHeight = 10;

    static float hourDepth = (float)((hourPosition.Y + towerTileHeight) * 64) / 10000f + 0.0001f;
    static float minuteDepth = (float)((minutePosition.Y + towerTileHeight) * 64) / 10000f + 0.00011f;
    static float nubDepth = (float)((nubPosition.Y + towerTileHeight) * 64) / 10000f + 0.00012f;

    public static void RenderClockHands(RenderedWorldEventArgs e) {
        if (!ShouldRender) return;

        SpriteBatch b = e.SpriteBatch;

        var adjustedHours = (int)(Game1.timeOfDay / 100);
        var adjustedMinutes = (float)(Game1.timeOfDay % 100) / 60f;

        hourRotation = (float)Math.Tau * (((adjustedHours + adjustedMinutes) % 12) / 12 + ((float)Game1.gameTimeInterval) / ((float)Game1.realMilliSecondsPerGameTenMinutes) / 72);
        minuteRotation = (float)Math.Tau * (adjustedMinutes + ((float)Game1.gameTimeInterval) / ((float)Game1.realMilliSecondsPerGameTenMinutes) / 6);

        b.Draw(ClockTexture,
            Game1.GlobalToLocal(Game1.viewport, hourPosition),
            hourSource,
            hourColor,
            hourRotation,
            hourOrigin,
            hourScale,
            SpriteEffects.None,
            hourDepth);

        b.Draw(ClockTexture,
            Game1.GlobalToLocal(Game1.viewport, minutePosition),
            minuteSource,
            minuteColor,
            minuteRotation,
            minuteOrigin,
            minuteScale,
            SpriteEffects.None,
            minuteDepth);

        b.Draw(ClockTexture,
            Game1.GlobalToLocal(Game1.viewport, nubPosition),
            nubSource,
            nubColor,
            0f,
            nubOrigin,
            nubScale,
            SpriteEffects.None,
            nubDepth);
    }

}