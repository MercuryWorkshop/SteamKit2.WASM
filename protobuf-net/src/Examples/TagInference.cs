﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;
using System.Runtime.Serialization;
using Xunit;

namespace Examples
{
    [ProtoContract(InferTagFromName=true)]
    [DataContract]
    class TagData
    {
        [DataMember(Order = 1)]
        public int Bravo { get; set; }

        [DataMember(Order = 1, Name="Alpha")]
        public int Delta { get; set; }

        [DataMember]
        public int Zulu { get; set; }

        [DataMember(Order = 2)]
        public int Charlie { get; set; }
    }

    [ProtoContract]
    [DataContract]
    class TagDataWithoutInfer
    {
        [DataMember(Order = 1)]
        public int Bravo { get; set; }

        [DataMember(Order = 1, Name = "Alpha")]
        public int Delta { get; set; }

        [DataMember]
        public int Zulu { get; set; }

        [DataMember(Order = 2)]
        public int Charlie { get; set; }
    }

    [ProtoContract]
    class TagDataExpected
    {
        [ProtoMember(3)]
        public int Bravo { get; set; }

        [ProtoMember(2)]
        public int Delta { get; set; }

        [ProtoMember(1)]
        public int Zulu { get; set; }

        [ProtoMember(4)]
        public int Charlie { get; set; }
    }

    
    public class TagInference
    {
        [Fact]
        public void TestTagWithoutInference()
        {
            Program.ExpectFailure<InvalidOperationException>(() =>
            {
                TagDataWithoutInfer data = new TagDataWithoutInfer();
                Serializer.DeepClone(data);
            });
        }

        [Fact]
        public void TestTagWithInferenceRoundtrip()
        {
            TagData data = new TagData
            {
                Bravo = 15,
                Charlie = 17,
                Delta = 4,
                Zulu = 9
            };
            TagData clone = Serializer.DeepClone(data);
            Assert.Equal(data.Bravo, clone.Bravo); //, "Bravo");
            Assert.Equal(data.Charlie, clone.Charlie); //, "Charlie");
            Assert.Equal(data.Delta, clone.Delta); //, "Delta");
            Assert.Equal(data.Zulu, clone.Zulu); //, "Zulu");
        }

        [Fact]
        public void TestTagWithInferenceBinary()
        {
            TagData data = new TagData
            {
                Bravo = 15,
                Charlie = 17,
                Delta = 4,
                Zulu = 9
            };
            TagDataExpected clone = Serializer.ChangeType<TagData, TagDataExpected>(data);
            Assert.Equal(data.Bravo, clone.Bravo); //, "Bravo");
            Assert.Equal(data.Charlie, clone.Charlie); //, "Charlie");
            Assert.Equal(data.Delta, clone.Delta); //, "Delta");
            Assert.Equal(data.Zulu, clone.Zulu); //, "Zulu");
        }

        [Fact]
        public void RoundTripWithImplicitFields()
        {
            var obj = new WithImplicitFields {X = 123, Y = "abc"};
            var clone = Serializer.DeepClone(obj);
            Assert.Equal(123, clone.X);
            Assert.Equal("abc", clone.Y);
        }

        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class WithImplicitFields
        {
            public int X { get; set; }
            public string Y { get; set; }
        }
    }




}
