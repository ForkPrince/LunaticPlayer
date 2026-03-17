using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LunaticPlayer.Classes;
using Newtonsoft.Json;

namespace LunaticPlayer.Helpers
{
    internal static class SongActions
    {
        /// <summary>
        /// Handles the context menu click action.
        /// </summary>
        /// <param name="action">Which action should be performed.</param>
        internal static void HandleClick(CMenuAction action, Song song)
        {
            switch (action)
            {
                case CMenuAction.CopyToClipboard:
                    Clipboard.SetText($"Artist: {song.ArtistName}, Circle: {song.CircleName}, Title: {song.Title}");
                    break;
                case CMenuAction.CopyJsonToClipboard:
                    Clipboard.SetText(JsonConvert.SerializeObject(song));
                    break;
                case CMenuAction.SearchOnGoogle:
                    var psi = new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = $"https://www.google.com/search?q={Uri.EscapeDataString(song.ArtistName + " " + song.Title)}",
                        UseShellExecute = true
                    };
                    System.Diagnostics.Process.Start(psi);
                    break;
                case CMenuAction.SearchOnTw:
                    var psiTw = new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = $"https://en.touhouwiki.net/index.php?search={Uri.EscapeDataString(song.CircleName)}",
                        UseShellExecute = true
                    };
                    System.Diagnostics.Process.Start(psiTw);
                    break;
                case CMenuAction.ShowDetails:
                    var details = new SongDetailsWindow(song);
                    details.Show();
                    break;
            }
        }
    }
}
