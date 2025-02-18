//
// using System;
// using System.Collections.Generic;
// using System.ComponentModel;
// using System.IO;
// using System.Linq;
// using System.Reflection;
// using System.Runtime.InteropServices;
// using System.Runtime.InteropServices.JavaScript;
// using System.Text.RegularExpressions;
// using System.Threading.Tasks;
// using SteamKit2;
// using SteamKit2.CDN;
//
// // byte[] encryptionKey = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
// //
// // unsafe
// // {
// //     var ciphertext = new byte[] { 0x8E, 0x9B, 0xA6, 0x7E, 0x93, 0x7A, 0x0F, 0x5A, 0x8E, 0x9B, 0xA6, 0x7E, 0x93, 0x7A, 0x0F, 0x5A };
// //     var bufferDecrypted = new byte[ciphertext.Length];
// //     fixed (byte* pciphertext = ciphertext, pdest = bufferDecrypted)
// //     {
// //         Console.WriteLine(NativeCrypto.AesDecryptEcb(encryptionKey.ToArray(), 16, pciphertext, ciphertext.Length, pdest));
// //     }
// //
// //     Console.WriteLine(bufferDecrypted.Length);
// //     Console.WriteLine("Decrypted: " + BitConverter.ToString(bufferDecrypted));
// // }
//
// namespace DepotDownloader
// {
//
//     partial class Program
//     {
//     [DllImport("libc")]
//     private static extern void abort();
//
//
//         static async Task<int> Main(string[] args)
//         {
//             try
//             {
//
//                 if (args.Length == 0)
//                 {
//                     PrintVersion();
//                     PrintUsage();
//
//                     // if (OperatingSystem.IsWindowsVersionAtLeast(5, 0))
//                     // {
//                     //     PlatformUtilities.VerifyConsoleLaunch();
//                     // }
//
//                     return 0;
//                 }
//
//                 // Ansi.Init();
//
//                 DebugLog.Enabled = true;
//
//                 AccountSettingsStore.LoadFromFile("account.config");
//
//                 #region Common Options
//
//                 // Not using HasParameter because it is case insensitive
//                 if (args.Length == 1 && (args[0] == "-V" || args[0] == "--version"))
//                 {
//                     PrintVersion(true);
//                     return 0;
//                 }
//
//                 if (HasParameter(args, "-debug"))
//                 {
//                     PrintVersion(true);
//
//                     DebugLog.Enabled = true;
//                     DebugLog.AddListener((category, message) =>
//                     {
//                         Console.WriteLine("[{0}] {1}", category, message);
//                     });
//
//                     // var httpEventListener = new HttpDiagnosticEventListener();
//                 }
//
//                 var username = GetParameter<string>(args, "-username") ?? GetParameter<string>(args, "-user");
//                 var password = GetParameter<string>(args, "-password") ?? GetParameter<string>(args, "-pass");
//                 ContentDownloader.Config.RememberPassword = HasParameter(args, "-remember-password");
//                 ContentDownloader.Config.UseQrCode = HasParameter(args, "-qr");
//
//                 if (username == null)
//                 {
//                     if (ContentDownloader.Config.RememberPassword)
//                     {
//                         Console.WriteLine("Error: -remember-password can not be used without -username.");
//                         return 1;
//                     }
//
//                     if (ContentDownloader.Config.UseQrCode)
//                     {
//                         Console.WriteLine("Error: -qr can not be used without -username.");
//                         return 1;
//                     }
//                 }
//
//                 ContentDownloader.Config.DownloadManifestOnly = HasParameter(args, "-manifest-only");
//
//                 var cellId = GetParameter(args, "-cellid", -1);
//                 if (cellId == -1)
//                 {
//                     cellId = 0;
//                 }
//
//                 ContentDownloader.Config.CellID = cellId;
//
//                 var fileList = GetParameter<string>(args, "-filelist");
//
//                 if (fileList != null)
//                 {
//                     const string RegexPrefix = "regex:";
//
//                     try
//                     {
//                         ContentDownloader.Config.UsingFileList = true;
//                         ContentDownloader.Config.FilesToDownload = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
//                         ContentDownloader.Config.FilesToDownloadRegex = [];
//
//                         var files = await File.ReadAllLinesAsync(fileList);
//
//                         foreach (var fileEntry in files)
//                         {
//                             if (string.IsNullOrWhiteSpace(fileEntry))
//                             {
//                                 continue;
//                             }
//
//                             if (fileEntry.StartsWith(RegexPrefix))
//                             {
//                                 var rgx = new Regex(fileEntry[RegexPrefix.Length..], RegexOptions.Compiled | RegexOptions.IgnoreCase);
//                                 ContentDownloader.Config.FilesToDownloadRegex.Add(rgx);
//                             }
//                             else
//                             {
//                                 ContentDownloader.Config.FilesToDownload.Add(fileEntry.Replace('\\', '/'));
//                             }
//                         }
//
//                         Console.WriteLine("Using filelist: '{0}'.", fileList);
//                     }
//                     catch (Exception ex)
//                     {
//                         Console.WriteLine("Warning: Unable to load filelist: {0}", ex);
//                     }
//                 }
//
//                 ContentDownloader.Config.InstallDirectory = GetParameter<string>(args, "-dir");
//
//                 ContentDownloader.Config.VerifyAll = HasParameter(args, "-verify-all") || HasParameter(args, "-verify_all") || HasParameter(args, "-validate");
//                 ContentDownloader.Config.MaxServers = GetParameter(args, "-max-servers", 20);
//
//                 if (HasParameter(args, "-use-lancache"))
//                 {
//                     await Client.DetectLancacheServerAsync();
//                     if (Client.UseLancacheServer)
//                     {
//                         Console.WriteLine("Detected Lancache server! Downloads will be directed through the Lancache.");
//
//                         // Increasing the number of concurrent downloads when the cache is detected since the downloads will likely
//                         // be served much faster than over the internet.  Steam internally has this behavior as well.
//                         if (!HasParameter(args, "-max-downloads"))
//                         {
//                             ContentDownloader.Config.MaxDownloads = 25;
//                         }
//                     }
//                 }
//
//                 ContentDownloader.Config.MaxDownloads = GetParameter(args, "-max-downloads", 8);
//                 ContentDownloader.Config.MaxServers = Math.Max(ContentDownloader.Config.MaxServers, ContentDownloader.Config.MaxDownloads);
//                 ContentDownloader.Config.LoginID = HasParameter(args, "-loginid") ? GetParameter<uint>(args, "-loginid") : null;
//
//                 #endregion
//
//                 var appId = GetParameter(args, "-app", ContentDownloader.INVALID_APP_ID);
//                 if (appId == ContentDownloader.INVALID_APP_ID)
//                 {
//                     Console.WriteLine("Error: -app not specified!");
//                     return 1;
//                 }
//
//                 var pubFile = GetParameter(args, "-pubfile", ContentDownloader.INVALID_MANIFEST_ID);
//                 var ugcId = GetParameter(args, "-ugc", ContentDownloader.INVALID_MANIFEST_ID);
//                 if (pubFile != ContentDownloader.INVALID_MANIFEST_ID)
//                 {
//                     #region Pubfile Downloading
//
//                     if (InitializeSteam(username, password))
//                     {
//                         try
//                         {
//                             await ContentDownloader.DownloadPubfileAsync(appId, pubFile).ConfigureAwait(false);
//                         }
//                         catch (Exception ex) when (
//                             ex is ContentDownloaderException
//                             || ex is OperationCanceledException)
//                         {
//                             Console.WriteLine(ex.Message);
//                             return 1;
//                         }
//                         catch (Exception e)
//                         {
//                             Console.WriteLine("Download failed to due to an unhandled exception: {0}", e.Message);
//                             throw;
//                         }
//                         finally
//                         {
//                             ContentDownloader.ShutdownSteam3();
//                         }
//                     }
//                     else
//                     {
//                         Console.WriteLine("Error: InitializeSteam failed");
//                         return 1;
//                     }
//
//                     #endregion
//                 }
//                 else if (ugcId != ContentDownloader.INVALID_MANIFEST_ID)
//                 {
//                     #region UGC Downloading
//
//                     if (InitializeSteam(username, password))
//                     {
//                         try
//                         {
//                             await ContentDownloader.DownloadUGCAsync(appId, ugcId).ConfigureAwait(false);
//                         }
//                         catch (Exception ex) when (
//                             ex is ContentDownloaderException
//                             || ex is OperationCanceledException)
//                         {
//                             Console.WriteLine(ex.Message);
//                             return 1;
//                         }
//                         catch (Exception e)
//                         {
//                             Console.WriteLine("Download failed to due to an unhandled exception: {0}", e.Message);
//                             throw;
//                         }
//                         finally
//                         {
//                             ContentDownloader.ShutdownSteam3();
//                         }
//                     }
//                     else
//                     {
//                         Console.WriteLine("Error: InitializeSteam failed");
//                         return 1;
//                     }
//
//                     #endregion
//                 }
//                 else
//                 {
//                     #region App downloading
//
//                     var branch = GetParameter<string>(args, "-branch") ?? GetParameter<string>(args, "-beta") ?? ContentDownloader.DEFAULT_BRANCH;
//                     ContentDownloader.Config.BetaPassword = GetParameter<string>(args, "-branchpassword") ?? GetParameter<string>(args, "-betapassword");
//
//                     ContentDownloader.Config.DownloadAllPlatforms = HasParameter(args, "-all-platforms");
//
//                     var os = GetParameter<string>(args, "-os");
//
//                     if (ContentDownloader.Config.DownloadAllPlatforms && !string.IsNullOrEmpty(os))
//                     {
//                         Console.WriteLine("Error: Cannot specify -os when -all-platforms is specified.");
//                         return 1;
//                     }
//
//                     ContentDownloader.Config.DownloadAllArchs = HasParameter(args, "-all-archs");
//
//                     var arch = GetParameter<string>(args, "-osarch");
//
//                     if (ContentDownloader.Config.DownloadAllArchs && !string.IsNullOrEmpty(arch))
//                     {
//                         Console.WriteLine("Error: Cannot specify -osarch when -all-archs is specified.");
//                         return 1;
//                     }
//
//                     ContentDownloader.Config.DownloadAllLanguages = HasParameter(args, "-all-languages");
//                     var language = GetParameter<string>(args, "-language");
//
//                     if (ContentDownloader.Config.DownloadAllLanguages && !string.IsNullOrEmpty(language))
//                     {
//                         Console.WriteLine("Error: Cannot specify -language when -all-languages is specified.");
//                         return 1;
//                     }
//
//                     var lv = HasParameter(args, "-lowviolence");
//
//                     var depotManifestIds = new List<(uint, ulong)>();
//                     var isUGC = false;
//
//                     var depotIdList = GetParameterList<uint>(args, "-depot");
//                     var manifestIdList = GetParameterList<ulong>(args, "-manifest");
//
//                     if (manifestIdList.Count > 0)
//                     {
//                         if (depotIdList.Count != manifestIdList.Count)
//                         {
//                             Console.WriteLine("Error: -manifest requires one id for every -depot specified");
//                             return 1;
//                         }
//
//                         var zippedDepotManifest = depotIdList.Zip(manifestIdList, (depotId, manifestId) => (depotId, manifestId));
//                         depotManifestIds.AddRange(zippedDepotManifest);
//                     }
//                     else
//                     {
//                         depotManifestIds.AddRange(depotIdList.Select(depotId => (depotId, ContentDownloader.INVALID_MANIFEST_ID)));
//                     }
//
//                     if (InitializeSteam(username, password))
//                     {
//                         try
//                         {
//                             await ContentDownloader.DownloadAppAsync(appId, depotManifestIds, branch, os, arch, language, lv, isUGC).ConfigureAwait(false);
//                         }
//                         catch (Exception ex) when (
//                             ex is ContentDownloaderException
//                             || ex is OperationCanceledException)
//                         {
//                             Console.WriteLine(ex.Message);
//                             return 1;
//                         }
//                         catch (Exception e)
//                         {
//                             Console.WriteLine("Download failed to due to an unhandled exception: {0}", e.Message);
//                             throw;
//                         }
//                         finally
//                         {
//                             ContentDownloader.ShutdownSteam3();
//                         }
//                     }
//                     else
//                     {
//                         Console.WriteLine("Error: InitializeSteam failed");
//                         return 1;
//                     }
//
//                     #endregion
//                 }
//
//
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine("Unhandled exception: {0}", ex);
//             }
//
//             return 0;
//         }
//
//         static bool InitializeSteam(string username, string password)
//         {
//             if (!ContentDownloader.Config.UseQrCode)
//             {
//                 if (username != null && password == null && (!ContentDownloader.Config.RememberPassword || !AccountSettingsStore.Instance.LoginTokens.ContainsKey(username)))
//                 {
//                     do
//                     {
//                         Console.Write("Enter account password for \"{0}\": ", username);
//                         if (Console.IsInputRedirected)
//                         {
//                             password = Console.ReadLine();
//                         }
//                         else
//                         {
//                             // Avoid console echoing of password
//                             // password = Util.ReadPassword();
//                         }
//
//                         Console.WriteLine();
//                     } while (string.Empty == password);
//                 }
//                 else if (username == null)
//                 {
//                     Console.WriteLine("No username given. Using anonymous account with dedicated server subscription.");
//                 }
//             }
//
//             return ContentDownloader.InitializeSteam3(username, password);
//         }
//
//         static int IndexOfParam(string[] args, string param)
//         {
//             for (var x = 0; x < args.Length; ++x)
//             {
//                 if (args[x].Equals(param, StringComparison.OrdinalIgnoreCase))
//                     return x;
//             }
//
//             return -1;
//         }
//
//         static bool HasParameter(string[] args, string param)
//         {
//             return IndexOfParam(args, param) > -1;
//         }
//
//         static T GetParameter<T>(string[] args, string param, T defaultValue = default)
//         {
//             var index = IndexOfParam(args, param);
//
//             if (index == -1 || index == (args.Length - 1))
//                 return defaultValue;
//
//             var strParam = args[index + 1];
//
//             var converter = TypeDescriptor.GetConverter(typeof(T));
//             if (converter != null)
//             {
//                 return (T)converter.ConvertFromString(strParam);
//             }
//
//             return default;
//         }
//
//         static List<T> GetParameterList<T>(string[] args, string param)
//         {
//             var list = new List<T>();
//             var index = IndexOfParam(args, param);
//
//             if (index == -1 || index == (args.Length - 1))
//                 return list;
//
//             index++;
//
//             while (index < args.Length)
//             {
//                 var strParam = args[index];
//
//                 if (strParam[0] == '-') break;
//
//                 var converter = TypeDescriptor.GetConverter(typeof(T));
//                 if (converter != null)
//                 {
//                     list.Add((T)converter.ConvertFromString(strParam));
//                 }
//
//                 index++;
//             }
//
//             return list;
//         }
//
//         static void PrintUsage()
//         {
//             // Do not use tabs to align parameters here because tab size may differ
//             Console.WriteLine();
//             Console.WriteLine("Usage: downloading one or all depots for an app:");
//             Console.WriteLine("       depotdownloader -app <id> [-depot <id> [-manifest <id>]]");
//             Console.WriteLine("                       [-username <username> [-password <password>]] [other options]");
//             Console.WriteLine();
//             Console.WriteLine("Usage: downloading a workshop item using pubfile id");
//             Console.WriteLine("       depotdownloader -app <id> -pubfile <id> [-username <username> [-password <password>]]");
//             Console.WriteLine("Usage: downloading a workshop item using ugc id");
//             Console.WriteLine("       depotdownloader -app <id> -ugc <id> [-username <username> [-password <password>]]");
//             Console.WriteLine();
//             Console.WriteLine("Parameters:");
//             Console.WriteLine("  -app <#>                 - the AppID to download.");
//             Console.WriteLine("  -depot <#>               - the DepotID to download.");
//             Console.WriteLine("  -manifest <id>           - manifest id of content to download (requires -depot, default: current for branch).");
//             Console.WriteLine($"  -branch <branchname>    - download from specified branch if available (default: {ContentDownloader.DEFAULT_BRANCH}).");
//             Console.WriteLine("  -branchpassword <pass>   - branch password if applicable.");
//             Console.WriteLine("  -all-platforms           - downloads all platform-specific depots when -app is used.");
//             Console.WriteLine("  -all-archs               - download all architecture-specific depots when -app is used.");
//             Console.WriteLine("  -os <os>                 - the operating system for which to download the game (windows, macos or linux, default: OS the program is currently running on)");
//             Console.WriteLine("  -osarch <arch>           - the architecture for which to download the game (32 or 64, default: the host's architecture)");
//             Console.WriteLine("  -all-languages           - download all language-specific depots when -app is used.");
//             Console.WriteLine("  -language <lang>         - the language for which to download the game (default: english)");
//             Console.WriteLine("  -lowviolence             - download low violence depots when -app is used.");
//             Console.WriteLine();
//             Console.WriteLine("  -ugc <#>                 - the UGC ID to download.");
//             Console.WriteLine("  -pubfile <#>             - the PublishedFileId to download. (Will automatically resolve to UGC id)");
//             Console.WriteLine();
//             Console.WriteLine("  -username <user>         - the username of the account to login to for restricted content.");
//             Console.WriteLine("  -password <pass>         - the password of the account to login to for restricted content.");
//             Console.WriteLine("  -remember-password       - if set, remember the password for subsequent logins of this user.");
//             Console.WriteLine("                             use -username <username> -remember-password as login credentials.");
//             Console.WriteLine();
//             Console.WriteLine("  -dir <installdir>        - the directory in which to place downloaded files.");
//             Console.WriteLine("  -filelist <file.txt>     - the name of a local file that contains a list of files to download (from the manifest).");
//             Console.WriteLine("                             prefix file path with `regex:` if you want to match with regex. each file path should be on their own line.");
//             Console.WriteLine();
//             Console.WriteLine("  -validate                - include checksum verification of files already downloaded");
//             Console.WriteLine("  -manifest-only           - downloads a human readable manifest for any depots that would be downloaded.");
//             Console.WriteLine("  -cellid <#>              - the overridden CellID of the content server to download from.");
//             Console.WriteLine("  -max-servers <#>         - maximum number of content servers to use. (default: 20).");
//             Console.WriteLine("  -max-downloads <#>       - maximum number of chunks to download concurrently. (default: 8).");
//             Console.WriteLine("  -loginid <#>             - a unique 32-bit integer Steam LogonID in decimal, required if running multiple instances of DepotDownloader concurrently.");
//             Console.WriteLine("  -use-lancache            - forces downloads over the local network via a Lancache instance.");
//         }
//
//         static void PrintVersion(bool printExtra = false)
//         {
//             var version = typeof(Program).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
//             Console.WriteLine($"DepotDownloader v{version}");
//
//             if (!printExtra)
//             {
//                 return;
//             }
//
//             Console.WriteLine($"Runtime: {RuntimeInformation.FrameworkDescription} on {RuntimeInformation.OSDescription}");
//         }
//     }
// }




using System;
using QRCoder;
using SteamKit2;
using SteamKit2.Authentication;
using SteamKit2.Internal;
using System.Security.Cryptography;
using System.Net.Http;
using System.Net.Http.Headers;

await Task.Run(async () =>
{
    // var response = await steamClient.Cloud.BeginHttpUpload(105600, "test7.txt", 1, "906faceaf874dd64e81de0048f36f4bab0f1f171");
    using var client = new HttpClient();

    var url = $"https://steamugcquincy.blob.core.windows.net/cloud/70/4B/3C/42/105600/001_9_25D6E35D_F63CA_1.dat";
    Console.WriteLine(url);

    byte[] fileData = [0];
    var content = new ByteArrayContent(fileData);
    Console.WriteLine("Sending request");
    HttpResponseMessage res = await client.PutAsync(url, content);
    Console.WriteLine("S");
});

// create our steamclient instance
var steamClient = new SteamClient();
// create the callback manager which will route callbacks to function calls
var manager = new CallbackManager(steamClient);

// get the steamuser handler, which is used for logging on after successfully connecting
var steamUser = steamClient.GetHandler<SteamUser>();

// register a few callbacks we're interested in
// these are registered upon creation to a callback manager, which will then route the callbacks
// to the functions specified
manager.Subscribe<SteamClient.ConnectedCallback>(OnConnected);
manager.Subscribe<SteamClient.DisconnectedCallback>(OnDisconnected);

manager.Subscribe<SteamUser.LoggedOnCallback>(OnLoggedOn);
manager.Subscribe<SteamUser.LoggedOffCallback>(OnLoggedOff);

var isRunning = true;

Console.WriteLine("Connecting to Steam...");

// initiate the connection
steamClient.Connect();

// create our callback handling loop
while (isRunning)
{
    // in order for the callbacks to get routed, they need to be handled by the manager
    manager.RunWaitCallbacks(TimeSpan.FromSeconds(1));
}

async void OnConnected(SteamClient.ConnectedCallback callback)
{
    // Start an authentication session by requesting a link
    var authSession = await steamClient.Authentication.BeginAuthSessionViaQRAsync(new AuthSessionDetails());

    // Steam will periodically refresh the challenge url, this callback allows you to draw a new qr code
    authSession.ChallengeURLChanged = () =>
    {
        Console.WriteLine();
        Console.WriteLine("Steam has refreshed the challenge url");

        DrawQRCode(authSession);
    };

    // Draw current qr right away
    DrawQRCode(authSession);

    // Starting polling Steam for authentication response
    // This response is later used to logon to Steam after connecting
    var pollResponse = await authSession.PollingWaitForResultAsync();

    Console.WriteLine($"Logging in as '{pollResponse.AccountName}'...");

    // Logon to Steam with the access token we have received
    steamUser.LogOn(new SteamUser.LogOnDetails
    {
        Username = pollResponse.AccountName,
        AccessToken = pollResponse.RefreshToken,
    });
}

void OnDisconnected(SteamClient.DisconnectedCallback callback)
{
    Console.WriteLine("Disconnected from Steam");

    isRunning = false;
}

void OnLoggedOn(SteamUser.LoggedOnCallback callback)
{
    if (callback.Result != EResult.OK)
    {
        Console.WriteLine("Unable to logon to Steam: {0} / {1}", callback.Result, callback.ExtendedResult);

        isRunning = false;
        return;
    }

    Console.WriteLine("Successfully logged on!");

    // at this point, we'd be able to perform actions on Steam


    var filename = "test14.txt";
    FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
    byte[] fileData = new byte[fileStream.Length];
    fileStream.Read(fileData, 0, fileData.Length);

    var sha1 = SHA1.Create();
    byte[] fileSha = sha1.ComputeHash(fileData);
    string fileShaHex = BitConverter.ToString(fileSha).Replace("-", "");

    uint fileSize = (uint)fileData.Length;
    uint appid = 105600;

    Task.Run(async () =>
    {
        try
        {
            Console.WriteLine("Uploading file {0} {1}", filename, fileShaHex);
            var response = await steamClient.Cloud.BeginHttpUpload(appid, filename, fileSize, fileShaHex);
            using var client = new HttpClient();

            var url = $"https://{response.url_host}{response.url_path}";
            Console.WriteLine(url);

            var content = new ByteArrayContent(fileData);

            content.Headers.ContentDisposition = new ContentDispositionHeaderValue("inline")
            {
                FileNameStar = filename,
            };
            content.Headers.ContentLength = fileSize;
            content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, url)
            {
                Content = content
            };

            foreach (var header in response.request_headers)
            {
                if (header.name == "Content-Disposition") continue;
                if (header.name == "Content-Length") continue;
                if (header.name == "Content-Type") continue;
                Console.WriteLine($"Adding header {header.name}: {header.value}");
                request.Headers.Add(header.name, header.value);
            }


            Console.WriteLine("Sending request");
            HttpResponseMessage res = await client.SendAsync(request);
            Console.WriteLine("Request sent");
            Console.WriteLine($"Response Status: {res.StatusCode}");
            bool success = res.IsSuccessStatusCode;
            await steamClient.Cloud.CommitHttpUpload(appid, filename, fileShaHex, success);
        }
        catch (Exception e)
        {
            Console.WriteLine("Failed to upload file {0} {1}", filename, e);
            await steamClient.Cloud.CommitHttpUpload(appid, filename, fileShaHex, false);
        }

    });



    // Task.Run(async () =>
    // {
    //     var response = await steamClient.Cloud.EnumerateUserFiles(105600, 100);
    //     Console.WriteLine(response.total_files);
    //     foreach (var file in response.files)
    //     {
    //         var filesize = file.filename;
    //
    //         if (File.Exists(file.filename))
    //         {
    //             var sha = SHA1.Create();
    //             using var stream = File.OpenRead(file.filename);
    //             var hash = sha.ComputeHash(stream);
    //             var hashString = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
    //             if (hashString == file.file_sha)
    //             {
    //                 Console.WriteLine("File {0} is already downloaded and has the correct hash", file.filename);
    //                 continue;
    //             }
    //         }
    //
    //         Console.WriteLine("Downloading file {0} {1}", file.filename, file.url);
    //         try
    //         {
    //
    //             Directory.CreateDirectory(Path.GetDirectoryName(file.filename));
    //
    //             using var fs = File.OpenWrite(file.filename);
    //             var downloadUrl = file.url;
    //             using var client = new HttpClient();
    //             var fileres = await client.GetAsync(downloadUrl);
    //             await fileres.Content.CopyToAsync(fs);
    //             fs.Close();
    //             Console.WriteLine("Downloaded file {0}", file.filename);
    //         }
    //         catch (Exception e)
    //         {
    //             Console.WriteLine("Failed to download file {0} {1}", file.filename, e);
    //         }
    //
    //     }
    // });
    // for this sample we'll just log off
    // steamUser.LogOff();
}

void OnLoggedOff(SteamUser.LoggedOffCallback callback)
{
    Console.WriteLine("Logged off of Steam: {0}", callback.Result);
}

void DrawQRCode(QrAuthSession authSession)
{
    Console.WriteLine($"Challenge URL: {authSession.ChallengeURL}");
    Console.WriteLine();

    // Encode the link as a QR code
    using var qrGenerator = new QRCodeGenerator();
    var qrCodeData = qrGenerator.CreateQrCode(authSession.ChallengeURL, QRCodeGenerator.ECCLevel.L);
    using var qrCode = new AsciiQRCode(qrCodeData);
    var qrCodeAsAsciiArt = qrCode.GetGraphic(1, drawQuietZones: false);

    Console.WriteLine("Use the Steam Mobile App to sign in via QR code:");
    Console.WriteLine(qrCodeAsAsciiArt);
}
