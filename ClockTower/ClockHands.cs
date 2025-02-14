using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using Microsoft.Xna.Framework;

namespace NightingaleCity.ClockTower;

public class ClockHands {

    static GameLocation clockLocation = Game1.getLocationFromName("Town");

    static float hourRotation;
    static float minuteRotation;

    static Vector2 hourPosition = new Vector2(24.5f, 50.5f) * 64;
    static Vector2 minutePosition = new Vector2(24.5f, 50.5f) * 64;

    static Rectangle hourSource = new Rectangle(369, 399, 5, 9);
    static Rectangle minuteSource = new Rectangle(363, 395, 5, 13);

    static Color hourColor = Color.White * 1;
    static Color minuteColor = Color.White * 1;

    static Vector2 hourOrigin = new Vector2(2.5f, 8f);
    static Vector2 minuteOrigin = new Vector2(2.5f, 12f);
    
    static float hourScale = 10f;
    static float minuteScale = 10f;
    
    static float hourDepth = 1f;/*(float)((Game1.player.Position.Y + 5) * 64) / 10000f + 0.0001f*/
    static float minuteDepth = 1f;/*(float)((Game1.player.Position.Y + 5) * 64) / 10000f + 0.00011f*/

    public static void RenderClockHands(RenderedWorldEventArgs e) {
        if (!Context.IsWorldReady || Game1.player.currentLocation != clockLocation) return;

        SpriteBatch b = e.SpriteBatch;

        switch (ModEntry.Config.ClockMovementStyle) {
            case "Snap":
                hourRotation = (float)(Math.PI * 2.0 * (double)((float)(Game1.timeOfDay % 1200) / 1200f) + (double)(Game1.gameTimeInterval / Game1.realMilliSecondsPerGameTenMinutes / 23f));
                minuteRotation = (float)(Math.PI * 2.0 * (double)((float)(Game1.timeOfDay % 1000 % 100 % 60) / 60f) + (double)(Game1.gameTimeInterval / Game1.realMilliSecondsPerGameTenMinutes * 1.02f));
                break;
            case "Smooth":
                hourRotation = (float)(Math.PI * 2.0 * (double)((float)(Game1.timeOfDay % 1200) / 1200f) + (double)((float)Game1.gameTimeInterval / (float)Game1.realMilliSecondsPerGameTenMinutes / 23f));
                minuteRotation = (float)(Math.PI * 2.0 * (double)((float)(Game1.timeOfDay % 1000 % 100 % 60) / 60f) + (double)((float)Game1.gameTimeInterval / (float)Game1.realMilliSecondsPerGameTenMinutes * 1.02f));
                break;
            case "Mix":
                hourRotation = (float)(Math.PI * 2.0 * (double)((float)(Game1.timeOfDay % 1200) / 1200f) + (double)(Game1.gameTimeInterval / Game1.realMilliSecondsPerGameTenMinutes / 23f));
                minuteRotation = (float)(Math.PI * 2.0 * (double)((float)(Game1.timeOfDay % 1000 % 100 % 60) / 60f) + (double)((float)Game1.gameTimeInterval / (float)Game1.realMilliSecondsPerGameTenMinutes * 1.02f));
                break;
        }
        
        b.Draw(Game1.mouseCursors,
            Game1.GlobalToLocal(Game1.viewport, hourPosition),
            hourSource,
            hourColor,
            hourRotation,
            hourOrigin,
            hourScale,
            SpriteEffects.None,
            hourDepth);
        
        b.Draw(Game1.mouseCursors,
            Game1.GlobalToLocal(Game1.viewport, minutePosition),
            minuteSource,
            minuteColor,
            minuteRotation,
            minuteOrigin,
            minuteScale,
            SpriteEffects.None,
            minuteDepth);

        //b.Draw(Game1.mouseCursors,
        //Game1.GlobalToLocal(Game1.viewport, Game1.player.Position),
        //Town.clockNub,
        //Color.White * 1,
        //0f,
        //new Vector2(2f, 2f),
        //4f,
        //SpriteEffects.None,
        //(float)((Game1.player.Position.Y + 5) * 64) / 10000f + 0.00012f);
    }

}