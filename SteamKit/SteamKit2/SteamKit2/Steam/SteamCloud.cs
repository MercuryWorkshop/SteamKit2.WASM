/*
 * This file is subject to the terms and conditions defined in
 * file 'license.txt', which is part of this source code package.
 */

using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SteamKit2.Internal;
using System.Runtime.InteropServices.JavaScript;

namespace SteamKit2
{
    /// <summary>
    /// This handler is used for authenticating on Steam.
    /// </summary>
    public sealed class SteamCloudS
    {
        SteamClient Client;
        internal Internal.Cloud CloudService { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SteamAuthentication"/> class.
        /// </summary>
        /// <param name="steamClient">The <see cref="SteamClient"/> this instance will be associated with.</param>
        internal SteamCloudS( SteamClient steamClient )
        {
            ArgumentNullException.ThrowIfNull( steamClient );

            Client = steamClient;

            var unifiedMessages = steamClient.GetHandler<SteamUnifiedMessages>()!;
            CloudService = unifiedMessages.CreateService<Internal.Cloud>();
        }

        public async Task<CCloud_EnumerateUserFiles_Response> EnumerateUserFiles() {
            var request = new CCloud_EnumerateUserFiles_Request {
                appid = 105600,
                count = 20,
                start_index = 0,
                extended_details = true,
            };

            var response = await CloudService.EnumerateUserFiles(request);

            if ( response.Result != EResult.OK )
            {
                Console.WriteLine("Failed to generate token");
                // throw new AuthenticationException( "Failed to generate token", response.Result );
            }
            Console.WriteLine(response.Body.total_files);
            foreach (var file in response.Body.files) {
                Console.WriteLine(file.filename);
                Console.WriteLine(file.file_size);
                Console.WriteLine(file.url);
                Console.WriteLine(file.file_sha);
                Console.WriteLine(file.ugcid);
            }

            return response.Body;
        }

    }
}


