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

        public async Task<CCloud_BeginHTTPUpload_Response> BeginHttpUpload( uint appid, string filename, uint file_size, string file_sha )
        {
            var request = new CCloud_BeginHTTPUpload_Request
            {
                appid = appid,
                file_size = file_size,
                filename = filename,
                is_public = true,
                file_sha = file_sha,
            };

            var response = await CloudService.BeginHTTPUpload( request );

            if ( response.Result != EResult.OK )
            {
                throw new Exception( "Failed to upload: " + response.Result );
            }

            return response.Body;
        }

        public async Task<CCloud_CommitHTTPUpload_Response> CommitHttpUpload( uint appid, string filename, string file_sha, bool success )
        {
            var request = new CCloud_CommitHTTPUpload_Request
            {
                appid = appid,
                filename = filename,
                file_sha = file_sha,
                transfer_succeeded = success,
            };

            var response = await CloudService.CommitHTTPUpload( request );

            if ( response.Result != EResult.OK )
            {
                throw new Exception( "Failed to commit upload: " + response.Result );
            }

            return response.Body;
        }
    }

}


