// <auto-generated>
//   This file was generated by a tool; you should avoid making direct changes.
//   Consider using 'partial classes' to extend these types
//   Input: steammessages_site_license.steamclient.proto
// </auto-generated>

#region Designer generated code
#pragma warning disable CS0612, CS0618, CS1591, CS3021, CS8981, IDE0079, IDE1006, RCS1036, RCS1057, RCS1085, RCS1192
namespace SteamKit2.Internal
{

    [global::ProtoBuf.ProtoContract()]
    public partial class CSiteManagerClient_IncomingClient_Request : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
        public ulong site_instanceid
        {
            get => __pbn__site_instanceid.GetValueOrDefault();
            set => __pbn__site_instanceid = value;
        }
        public bool ShouldSerializesite_instanceid() => __pbn__site_instanceid != null;
        public void Resetsite_instanceid() => __pbn__site_instanceid = null;
        private ulong? __pbn__site_instanceid;

        [global::ProtoBuf.ProtoMember(2, DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
        public ulong client_steamid
        {
            get => __pbn__client_steamid.GetValueOrDefault();
            set => __pbn__client_steamid = value;
        }
        public bool ShouldSerializeclient_steamid() => __pbn__client_steamid != null;
        public void Resetclient_steamid() => __pbn__client_steamid = null;
        private ulong? __pbn__client_steamid;

        [global::ProtoBuf.ProtoMember(3, DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
        public uint client_local_ip
        {
            get => __pbn__client_local_ip.GetValueOrDefault();
            set => __pbn__client_local_ip = value;
        }
        public bool ShouldSerializeclient_local_ip() => __pbn__client_local_ip != null;
        public void Resetclient_local_ip() => __pbn__client_local_ip = null;
        private uint? __pbn__client_local_ip;

        [global::ProtoBuf.ProtoMember(4)]
        public byte[] connection_key
        {
            get => __pbn__connection_key;
            set => __pbn__connection_key = value;
        }
        public bool ShouldSerializeconnection_key() => __pbn__connection_key != null;
        public void Resetconnection_key() => __pbn__connection_key = null;
        private byte[] __pbn__connection_key;

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class CSiteManagerClient_IncomingClient_Response : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class CSiteLicense_ClientSeatCheckout_Notification : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1)]
        public uint appid
        {
            get => __pbn__appid.GetValueOrDefault();
            set => __pbn__appid = value;
        }
        public bool ShouldSerializeappid() => __pbn__appid != null;
        public void Resetappid() => __pbn__appid = null;
        private uint? __pbn__appid;

        [global::ProtoBuf.ProtoMember(2)]
        public uint eresult
        {
            get => __pbn__eresult.GetValueOrDefault();
            set => __pbn__eresult = value;
        }
        public bool ShouldSerializeeresult() => __pbn__eresult != null;
        public void Reseteresult() => __pbn__eresult = null;
        private uint? __pbn__eresult;

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class CSiteManagerClient_TrackedPayments_Notification : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
        public ulong site_id
        {
            get => __pbn__site_id.GetValueOrDefault();
            set => __pbn__site_id = value;
        }
        public bool ShouldSerializesite_id() => __pbn__site_id != null;
        public void Resetsite_id() => __pbn__site_id = null;
        private ulong? __pbn__site_id;

        [global::ProtoBuf.ProtoMember(2)]
        public global::System.Collections.Generic.List<Payment> payments { get; } = new global::System.Collections.Generic.List<Payment>();

        [global::ProtoBuf.ProtoContract()]
        public partial class Payment : global::ProtoBuf.IExtensible
        {
            private global::ProtoBuf.IExtension __pbn__extensionData;
            global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
                => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

            [global::ProtoBuf.ProtoMember(1)]
            public ulong transid
            {
                get => __pbn__transid.GetValueOrDefault();
                set => __pbn__transid = value;
            }
            public bool ShouldSerializetransid() => __pbn__transid != null;
            public void Resettransid() => __pbn__transid = null;
            private ulong? __pbn__transid;

            [global::ProtoBuf.ProtoMember(2)]
            public ulong steamid
            {
                get => __pbn__steamid.GetValueOrDefault();
                set => __pbn__steamid = value;
            }
            public bool ShouldSerializesteamid() => __pbn__steamid != null;
            public void Resetsteamid() => __pbn__steamid = null;
            private ulong? __pbn__steamid;

            [global::ProtoBuf.ProtoMember(3)]
            public long amount
            {
                get => __pbn__amount.GetValueOrDefault();
                set => __pbn__amount = value;
            }
            public bool ShouldSerializeamount() => __pbn__amount != null;
            public void Resetamount() => __pbn__amount = null;
            private long? __pbn__amount;

            [global::ProtoBuf.ProtoMember(4)]
            public uint ecurrency
            {
                get => __pbn__ecurrency.GetValueOrDefault();
                set => __pbn__ecurrency = value;
            }
            public bool ShouldSerializeecurrency() => __pbn__ecurrency != null;
            public void Resetecurrency() => __pbn__ecurrency = null;
            private uint? __pbn__ecurrency;

            [global::ProtoBuf.ProtoMember(5)]
            public int time_created
            {
                get => __pbn__time_created.GetValueOrDefault();
                set => __pbn__time_created = value;
            }
            public bool ShouldSerializetime_created() => __pbn__time_created != null;
            public void Resettime_created() => __pbn__time_created = null;
            private int? __pbn__time_created;

            [global::ProtoBuf.ProtoMember(6)]
            public int purchase_status
            {
                get => __pbn__purchase_status.GetValueOrDefault();
                set => __pbn__purchase_status = value;
            }
            public bool ShouldSerializepurchase_status() => __pbn__purchase_status != null;
            public void Resetpurchase_status() => __pbn__purchase_status = null;
            private int? __pbn__purchase_status;

            [global::ProtoBuf.ProtoMember(7)]
            [global::System.ComponentModel.DefaultValue("")]
            public string machine_name
            {
                get => __pbn__machine_name ?? "";
                set => __pbn__machine_name = value;
            }
            public bool ShouldSerializemachine_name() => __pbn__machine_name != null;
            public void Resetmachine_name() => __pbn__machine_name = null;
            private string __pbn__machine_name;

            [global::ProtoBuf.ProtoMember(8)]
            [global::System.ComponentModel.DefaultValue("")]
            public string persona_name
            {
                get => __pbn__persona_name ?? "";
                set => __pbn__persona_name = value;
            }
            public bool ShouldSerializepersona_name() => __pbn__persona_name != null;
            public void Resetpersona_name() => __pbn__persona_name = null;
            private string __pbn__persona_name;

            [global::ProtoBuf.ProtoMember(9)]
            [global::System.ComponentModel.DefaultValue("")]
            public string profile_url
            {
                get => __pbn__profile_url ?? "";
                set => __pbn__profile_url = value;
            }
            public bool ShouldSerializeprofile_url() => __pbn__profile_url != null;
            public void Resetprofile_url() => __pbn__profile_url = null;
            private string __pbn__profile_url;

            [global::ProtoBuf.ProtoMember(10)]
            [global::System.ComponentModel.DefaultValue("")]
            public string avatar_url
            {
                get => __pbn__avatar_url ?? "";
                set => __pbn__avatar_url = value;
            }
            public bool ShouldSerializeavatar_url() => __pbn__avatar_url != null;
            public void Resetavatar_url() => __pbn__avatar_url = null;
            private string __pbn__avatar_url;

        }

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class CSiteLicense_InitiateAssociation_Request : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
        public ulong site_steamid
        {
            get => __pbn__site_steamid.GetValueOrDefault();
            set => __pbn__site_steamid = value;
        }
        public bool ShouldSerializesite_steamid() => __pbn__site_steamid != null;
        public void Resetsite_steamid() => __pbn__site_steamid = null;
        private ulong? __pbn__site_steamid;

        [global::ProtoBuf.ProtoMember(2, DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
        public ulong site_instanceid
        {
            get => __pbn__site_instanceid.GetValueOrDefault();
            set => __pbn__site_instanceid = value;
        }
        public bool ShouldSerializesite_instanceid() => __pbn__site_instanceid != null;
        public void Resetsite_instanceid() => __pbn__site_instanceid = null;
        private ulong? __pbn__site_instanceid;

        [global::ProtoBuf.ProtoMember(3, DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
        public uint client_local_ip
        {
            get => __pbn__client_local_ip.GetValueOrDefault();
            set => __pbn__client_local_ip = value;
        }
        public bool ShouldSerializeclient_local_ip() => __pbn__client_local_ip != null;
        public void Resetclient_local_ip() => __pbn__client_local_ip = null;
        private uint? __pbn__client_local_ip;

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class CSiteLicense_InitiateAssociation_Response : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1)]
        public byte[] connection_key
        {
            get => __pbn__connection_key;
            set => __pbn__connection_key = value;
        }
        public bool ShouldSerializeconnection_key() => __pbn__connection_key != null;
        public void Resetconnection_key() => __pbn__connection_key = null;
        private byte[] __pbn__connection_key;

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class CSiteLicense_LCSAuthenticate_Request : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
        public ulong instanceid
        {
            get => __pbn__instanceid.GetValueOrDefault();
            set => __pbn__instanceid = value;
        }
        public bool ShouldSerializeinstanceid() => __pbn__instanceid != null;
        public void Resetinstanceid() => __pbn__instanceid = null;
        private ulong? __pbn__instanceid;

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class CSiteLicense_LCSAuthenticate_Response : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1)]
        public ulong site_id
        {
            get => __pbn__site_id.GetValueOrDefault();
            set => __pbn__site_id = value;
        }
        public bool ShouldSerializesite_id() => __pbn__site_id != null;
        public void Resetsite_id() => __pbn__site_id = null;
        private ulong? __pbn__site_id;

        [global::ProtoBuf.ProtoMember(2)]
        [global::System.ComponentModel.DefaultValue("")]
        public string site_name
        {
            get => __pbn__site_name ?? "";
            set => __pbn__site_name = value;
        }
        public bool ShouldSerializesite_name() => __pbn__site_name != null;
        public void Resetsite_name() => __pbn__site_name = null;
        private string __pbn__site_name;

        [global::ProtoBuf.ProtoMember(3)]
        public bool new_session
        {
            get => __pbn__new_session.GetValueOrDefault();
            set => __pbn__new_session = value;
        }
        public bool ShouldSerializenew_session() => __pbn__new_session != null;
        public void Resetnew_session() => __pbn__new_session = null;
        private bool? __pbn__new_session;

        [global::ProtoBuf.ProtoMember(4)]
        public bool no_site_licenses
        {
            get => __pbn__no_site_licenses.GetValueOrDefault();
            set => __pbn__no_site_licenses = value;
        }
        public bool ShouldSerializeno_site_licenses() => __pbn__no_site_licenses != null;
        public void Resetno_site_licenses() => __pbn__no_site_licenses = null;
        private bool? __pbn__no_site_licenses;

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class CSiteLicense_LCSAssociateUser_Request : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
        public ulong steamid
        {
            get => __pbn__steamid.GetValueOrDefault();
            set => __pbn__steamid = value;
        }
        public bool ShouldSerializesteamid() => __pbn__steamid != null;
        public void Resetsteamid() => __pbn__steamid = null;
        private ulong? __pbn__steamid;

        [global::ProtoBuf.ProtoMember(2, DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
        public uint local_ip
        {
            get => __pbn__local_ip.GetValueOrDefault();
            set => __pbn__local_ip = value;
        }
        public bool ShouldSerializelocal_ip() => __pbn__local_ip != null;
        public void Resetlocal_ip() => __pbn__local_ip = null;
        private uint? __pbn__local_ip;

        [global::ProtoBuf.ProtoMember(3, DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
        public ulong instanceid
        {
            get => __pbn__instanceid.GetValueOrDefault();
            set => __pbn__instanceid = value;
        }
        public bool ShouldSerializeinstanceid() => __pbn__instanceid != null;
        public void Resetinstanceid() => __pbn__instanceid = null;
        private ulong? __pbn__instanceid;

        [global::ProtoBuf.ProtoMember(4)]
        [global::System.ComponentModel.DefaultValue("")]
        public string machine_name
        {
            get => __pbn__machine_name ?? "";
            set => __pbn__machine_name = value;
        }
        public bool ShouldSerializemachine_name() => __pbn__machine_name != null;
        public void Resetmachine_name() => __pbn__machine_name = null;
        private string __pbn__machine_name;

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class CSiteLicense_LCSAssociateUser_Response : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class CSiteLicense_ClientSeatCheckout_Request : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
        public ulong steamid
        {
            get => __pbn__steamid.GetValueOrDefault();
            set => __pbn__steamid = value;
        }
        public bool ShouldSerializesteamid() => __pbn__steamid != null;
        public void Resetsteamid() => __pbn__steamid = null;
        private ulong? __pbn__steamid;

        [global::ProtoBuf.ProtoMember(2, DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
        public ulong instanceid
        {
            get => __pbn__instanceid.GetValueOrDefault();
            set => __pbn__instanceid = value;
        }
        public bool ShouldSerializeinstanceid() => __pbn__instanceid != null;
        public void Resetinstanceid() => __pbn__instanceid = null;
        private ulong? __pbn__instanceid;

        [global::ProtoBuf.ProtoMember(3)]
        public uint appid
        {
            get => __pbn__appid.GetValueOrDefault();
            set => __pbn__appid = value;
        }
        public bool ShouldSerializeappid() => __pbn__appid != null;
        public void Resetappid() => __pbn__appid = null;
        private uint? __pbn__appid;

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class CSiteLicense_ClientSeatCheckout_Response : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class CSiteLicense_ClientGetAvailableSeats_Request : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
        public ulong steamid
        {
            get => __pbn__steamid.GetValueOrDefault();
            set => __pbn__steamid = value;
        }
        public bool ShouldSerializesteamid() => __pbn__steamid != null;
        public void Resetsteamid() => __pbn__steamid = null;
        private ulong? __pbn__steamid;

        [global::ProtoBuf.ProtoMember(2, DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
        public ulong instanceid
        {
            get => __pbn__instanceid.GetValueOrDefault();
            set => __pbn__instanceid = value;
        }
        public bool ShouldSerializeinstanceid() => __pbn__instanceid != null;
        public void Resetinstanceid() => __pbn__instanceid = null;
        private ulong? __pbn__instanceid;

        [global::ProtoBuf.ProtoMember(3)]
        public uint appid
        {
            get => __pbn__appid.GetValueOrDefault();
            set => __pbn__appid = value;
        }
        public bool ShouldSerializeappid() => __pbn__appid != null;
        public void Resetappid() => __pbn__appid = null;
        private uint? __pbn__appid;

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class CSiteLicense_ClientGetAvailableSeats_Response : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1)]
        public uint available_seats
        {
            get => __pbn__available_seats.GetValueOrDefault();
            set => __pbn__available_seats = value;
        }
        public bool ShouldSerializeavailable_seats() => __pbn__available_seats != null;
        public void Resetavailable_seats() => __pbn__available_seats = null;
        private uint? __pbn__available_seats;

    }

    public class SiteManagerClient : SteamUnifiedMessages.UnifiedService
    {
        public override string ServiceName { get; } = "SiteManagerClient";

        public AsyncJob<SteamUnifiedMessages.ServiceMethodResponse<CSiteManagerClient_IncomingClient_Response>> IncomingClient( CSiteManagerClient_IncomingClient_Request request )
        {
            return UnifiedMessages.SendMessage<CSiteManagerClient_IncomingClient_Request, CSiteManagerClient_IncomingClient_Response>( "SiteManagerClient.IncomingClient#1", request );
        }

        public void ClientSeatCheckoutNotification(CSiteLicense_ClientSeatCheckout_Notification request )
        {
            UnifiedMessages.SendNotification<CSiteLicense_ClientSeatCheckout_Notification>( "SiteManagerClient.ClientSeatCheckoutNotification#1", request );
        }

        public void TrackedPaymentsNotification(CSiteManagerClient_TrackedPayments_Notification request )
        {
            UnifiedMessages.SendNotification<CSiteManagerClient_TrackedPayments_Notification>( "SiteManagerClient.TrackedPaymentsNotification#1", request );
        }

        public override void HandleResponseMsg( string methodName, PacketClientMsgProtobuf packetMsg )
        {
            switch ( methodName )
            {
                case "IncomingClient":
                    PostResponseMsg<CSiteManagerClient_IncomingClient_Response>( packetMsg );
                    break;
            }
        }

        public override void HandleNotificationMsg( string methodName, PacketClientMsgProtobuf packetMsg )
        {
            switch ( methodName )
            {
                case "ClientSeatCheckoutNotification":
                    PostNotificationMsg<CSiteLicense_ClientSeatCheckout_Notification>( packetMsg );
                    break;
                case "TrackedPaymentsNotification":
                    PostNotificationMsg<CSiteManagerClient_TrackedPayments_Notification>( packetMsg );
                    break;
            }
        }
    }

    public class SiteLicense : SteamUnifiedMessages.UnifiedService
    {
        public override string ServiceName { get; } = "SiteLicense";

        public AsyncJob<SteamUnifiedMessages.ServiceMethodResponse<CSiteLicense_InitiateAssociation_Response>> InitiateAssociation( CSiteLicense_InitiateAssociation_Request request )
        {
            return UnifiedMessages.SendMessage<CSiteLicense_InitiateAssociation_Request, CSiteLicense_InitiateAssociation_Response>( "SiteLicense.InitiateAssociation#1", request );
        }

        public AsyncJob<SteamUnifiedMessages.ServiceMethodResponse<CSiteLicense_LCSAuthenticate_Response>> LCSAuthenticate( CSiteLicense_LCSAuthenticate_Request request )
        {
            return UnifiedMessages.SendMessage<CSiteLicense_LCSAuthenticate_Request, CSiteLicense_LCSAuthenticate_Response>( "SiteLicense.LCSAuthenticate#1", request );
        }

        public AsyncJob<SteamUnifiedMessages.ServiceMethodResponse<CSiteLicense_LCSAssociateUser_Response>> LCSAssociateUser( CSiteLicense_LCSAssociateUser_Request request )
        {
            return UnifiedMessages.SendMessage<CSiteLicense_LCSAssociateUser_Request, CSiteLicense_LCSAssociateUser_Response>( "SiteLicense.LCSAssociateUser#1", request );
        }

        public AsyncJob<SteamUnifiedMessages.ServiceMethodResponse<CSiteLicense_ClientSeatCheckout_Response>> ClientSeatCheckout( CSiteLicense_ClientSeatCheckout_Request request )
        {
            return UnifiedMessages.SendMessage<CSiteLicense_ClientSeatCheckout_Request, CSiteLicense_ClientSeatCheckout_Response>( "SiteLicense.ClientSeatCheckout#1", request );
        }

        public AsyncJob<SteamUnifiedMessages.ServiceMethodResponse<CSiteLicense_ClientGetAvailableSeats_Response>> ClientGetAvailableSeats( CSiteLicense_ClientGetAvailableSeats_Request request )
        {
            return UnifiedMessages.SendMessage<CSiteLicense_ClientGetAvailableSeats_Request, CSiteLicense_ClientGetAvailableSeats_Response>( "SiteLicense.ClientGetAvailableSeats#1", request );
        }

        public override void HandleResponseMsg( string methodName, PacketClientMsgProtobuf packetMsg )
        {
            switch ( methodName )
            {
                case "InitiateAssociation":
                    PostResponseMsg<CSiteLicense_InitiateAssociation_Response>( packetMsg );
                    break;
                case "LCSAuthenticate":
                    PostResponseMsg<CSiteLicense_LCSAuthenticate_Response>( packetMsg );
                    break;
                case "LCSAssociateUser":
                    PostResponseMsg<CSiteLicense_LCSAssociateUser_Response>( packetMsg );
                    break;
                case "ClientSeatCheckout":
                    PostResponseMsg<CSiteLicense_ClientSeatCheckout_Response>( packetMsg );
                    break;
                case "ClientGetAvailableSeats":
                    PostResponseMsg<CSiteLicense_ClientGetAvailableSeats_Response>( packetMsg );
                    break;
            }
        }

        public override void HandleNotificationMsg( string methodName, PacketClientMsgProtobuf packetMsg )
        {
        }
    }

}

#pragma warning restore CS0612, CS0618, CS1591, CS3021, CS8981, IDE0079, IDE1006, RCS1036, RCS1057, RCS1085, RCS1192
#endregion
