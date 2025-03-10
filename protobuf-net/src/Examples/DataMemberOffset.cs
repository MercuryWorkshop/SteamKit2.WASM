﻿using System.Runtime.Serialization;
using Xunit;
using ProtoBuf;

namespace Examples
{
    public class DataMemberOffset
    {
        [Fact]
        public void TestOffset()
        {
            DMO_First first = new DMO_First {Foo = 12};
            DMO_Second second = Serializer.ChangeType<DMO_First, DMO_Second>(first);

            Assert.Equal(first.Foo, second.Bar);
        }
    }

    [DataContract]
    internal class DMO_First
    {
        [DataMember(Order = 5)]
        public int Foo { get; set; }
    }
    [DataContract]
    [ProtoContract(DataMemberOffset = 2)]
    internal class DMO_Second
    {
        [DataMember(Order = 3)]
        public int Bar { get; set; }
    }

    [DataContract, ProtoContract]
    internal class TypeWithProtosAndDataContract_UseAny
    {
        [ProtoMember(1)]
        public int Foo { get; set; }
        [DataMember(Order=2)]
        public int Bar { get; set; }
    }
    [DataContract, ProtoContract(UseProtoMembersOnly=true)]
    internal class TypeWithProtosAndDataContract_UseProtoOnly
    {
        [ProtoMember(1)]
        public int Foo { get; set; }
        [DataMember(Order = 2)]
        public int Bar { get; set; }
    }

    public class TestWeCanTurnOffNonProtoMarkers
    {
        [Fact]
        public void TypeWithProtosAndDataContract_UseAny_ShouldSerializeBoth()
        {
            var orig = new TypeWithProtosAndDataContract_UseAny { Foo = 123, Bar = 456 };
            var clone = Serializer.DeepClone(orig);
            Assert.Equal(123, clone.Foo);
            Assert.Equal(456, clone.Bar);
        }
        [Fact]
        public void TypeWithProtosAndDataContract_UseProtoOnly_ShouldSerializeFooOnly()
        {
            var orig = new TypeWithProtosAndDataContract_UseProtoOnly { Foo = 123, Bar = 456 };
            var clone = Serializer.DeepClone(orig);
            Assert.Equal(123, clone.Foo);
            Assert.Equal(0, clone.Bar);
        }
    }
}
