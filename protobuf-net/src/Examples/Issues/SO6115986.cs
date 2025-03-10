﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using ProtoBuf.Meta;
using System.IO;
using ProtoBuf;

namespace Examples.Issues
{
    
    public class SO6115986
    {
        public interface IYObject
        {
            string X { get; }
            int Z { get; set; }
        }

        public class YObject : IYObject
        {
            public string X { get; set; }

            int z;
            int IYObject.Z { get { return z; } set { z = value; } }
        }

        public class D
        {
            public IYObject Y { get; set; }
        }
        [Fact]
        public void Execute()
        {
            var m = RuntimeTypeModel.Create();
            m.Add(typeof(D), false).Add("Y");
            m.Add(typeof(IYObject), false).AddSubType(1, typeof(YObject)).Add(2, "Z");
            m.Add(typeof(YObject), false).Add("X");
            var d = new D { Y = new YObject { X = "a" } };
            d.Y.Z = 123;
            using var ms = new MemoryStream();
            m.Serialize(ms, d);
            ms.Position = 0;
#pragma warning disable CS0618
            var d2 = (D)m.Deserialize(ms, null, typeof(D));
#pragma warning restore CS0618
            Assert.Equal("a", d2.Y.X);
            Assert.Equal(123, d2.Y.Z);
        }
    }

    
    public class SO6115986_WithAttributes
    {
        [ProtoContract, ProtoInclude(1, typeof(YObject))]
        public interface IYObject
        {
            string X { get; }
            [ProtoMember(2)]
            int Z { get; set; }
        }
        [ProtoContract]
        public class YObject : IYObject
        {
            [ProtoMember(1)]
            public string X { get; set; }

            int z;
            int IYObject.Z { get { return z; } set { z = value; } }
        }
        [ProtoContract]
        public class D
        {
            [ProtoMember(1)]
            public IYObject Y { get; set; }
        }
        [Fact]
        public void Execute()
        {
            var m = RuntimeTypeModel.Create();
            var d = new D { Y = new YObject { X = "a" } };
            d.Y.Z = 123;
            using var ms = new MemoryStream();
            m.Serialize(ms, d);
            ms.Position = 0;
#pragma warning disable CS0618
            var d2 = (D)m.Deserialize(ms, null, typeof(D));
#pragma warning disable CS0618
            Assert.Equal("a", d2.Y.X);
            Assert.Equal(123, d2.Y.Z);
        }
    }
}
