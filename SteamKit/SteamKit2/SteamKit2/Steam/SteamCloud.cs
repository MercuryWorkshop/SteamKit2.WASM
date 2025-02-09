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

        public async Task<CCloud_EnumerateUserFiles_Response> EnumerateUserFiles( uint appid, uint count )
        {
            var request = new CCloud_EnumerateUserFiles_Request
            {
                appid = appid,
                count = count,
                start_index = 0,
                extended_details = true,
            };

            var response = await CloudService.EnumerateUserFiles( request );

            if ( response.Result != EResult.OK )
            {
                throw new Exception( "Failed to enumerate: " + response.Result );
            }

            return response.Body;
        }

    }
}


