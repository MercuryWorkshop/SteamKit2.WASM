// <auto-generated>
//   This file was generated by a tool; you should avoid making direct changes.
//   Consider using 'partial classes' to extend these types
//   Input: offline_ticket.proto
// </auto-generated>

#region Designer generated code
#pragma warning disable CS0612, CS0618, CS1591, CS3021, CS8981, IDE0079, IDE1006, RCS1036, RCS1057, RCS1085, RCS1192
namespace SteamKit2.Internal
{

    [global::ProtoBuf.ProtoContract()]
    public partial class Offline_Ticket : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1)]
        public byte[] encrypted_ticket
        {
            get => __pbn__encrypted_ticket;
            set => __pbn__encrypted_ticket = value;
        }
        public bool ShouldSerializeencrypted_ticket() => __pbn__encrypted_ticket != null;
        public void Resetencrypted_ticket() => __pbn__encrypted_ticket = null;
        private byte[] __pbn__encrypted_ticket;

        [global::ProtoBuf.ProtoMember(2)]
        public byte[] signature
        {
            get => __pbn__signature;
            set => __pbn__signature = value;
        }
        public bool ShouldSerializesignature() => __pbn__signature != null;
        public void Resetsignature() => __pbn__signature = null;
        private byte[] __pbn__signature;

        [global::ProtoBuf.ProtoMember(3)]
        public int kdf1
        {
            get => __pbn__kdf1.GetValueOrDefault();
            set => __pbn__kdf1 = value;
        }
        public bool ShouldSerializekdf1() => __pbn__kdf1 != null;
        public void Resetkdf1() => __pbn__kdf1 = null;
        private int? __pbn__kdf1;

        [global::ProtoBuf.ProtoMember(4)]
        public byte[] salt1
        {
            get => __pbn__salt1;
            set => __pbn__salt1 = value;
        }
        public bool ShouldSerializesalt1() => __pbn__salt1 != null;
        public void Resetsalt1() => __pbn__salt1 = null;
        private byte[] __pbn__salt1;

        [global::ProtoBuf.ProtoMember(5)]
        public int kdf2
        {
            get => __pbn__kdf2.GetValueOrDefault();
            set => __pbn__kdf2 = value;
        }
        public bool ShouldSerializekdf2() => __pbn__kdf2 != null;
        public void Resetkdf2() => __pbn__kdf2 = null;
        private int? __pbn__kdf2;

        [global::ProtoBuf.ProtoMember(6)]
        public byte[] salt2
        {
            get => __pbn__salt2;
            set => __pbn__salt2 = value;
        }
        public bool ShouldSerializesalt2() => __pbn__salt2 != null;
        public void Resetsalt2() => __pbn__salt2 = null;
        private byte[] __pbn__salt2;

    }

}

#pragma warning restore CS0612, CS0618, CS1591, CS3021, CS8981, IDE0079, IDE1006, RCS1036, RCS1057, RCS1085, RCS1192
#endregion
