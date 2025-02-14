using StardewModdingAPI;

namespace NightingaleCity;

public class Log {

    static IMonitor Monitor = null!;

    static LogLevel DesiredLogLevel(LogLevel level, bool show) {
        return show ? level : ModEntry.Config.ShowConsoleLogs ? level : LogLevel.Trace;
    }

    public static void Init(IMonitor monitor) {
        Monitor = monitor;
    }

    public static void Info(string message, bool alwaysShow) {
        Monitor.Log(message, DesiredLogLevel(LogLevel.Info, alwaysShow));
    }

    public static void Debug(string message, bool alwaysShow) {
        Monitor.Log(message, DesiredLogLevel(LogLevel.Debug, alwaysShow));
    }

    public static void Warn(string message) {
        Monitor.Log(message, LogLevel.Warn);
    }

    public static void Error(string message) {
        Monitor.Log(message, LogLevel.Error);
    }

}