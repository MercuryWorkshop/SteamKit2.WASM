﻿#if !COREFX
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using DAL;
using Xunit;
using ProtoBuf;
using ProtoBuf.Meta;

namespace Examples
{
    
    public class NonSeekableStreams
    {
        [Fact]
        public void ShouldNotRequireSeeking()
        {
            var model = RuntimeTypeModel.Create();
            byte[] raw;
            const int EXPECTED = 830;
            using(var fs = new FakeStream())
            {
                var db = NWindTests.LoadDatabaseFromFile<Database>(model);
                Assert.Equal(EXPECTED, db.Orders.Count);
                model.Serialize(fs, db);
                raw = fs.ToArray();
            }
            using (var fs = new FakeStream(raw))
            {
#pragma warning disable CS0618
                var db = (Database)model.Deserialize(fs, null, typeof (Database));
#pragma warning restore CS0618
                Assert.Equal(EXPECTED, db.Orders.Count);
            }
            using (var fs = new FakeStream(raw))
            {
                var db = model.Deserialize<Database>(fs);
                Assert.Equal(EXPECTED, db.Orders.Count);
            }
            using (var fs = new FakeStream(raw))
            {
                var db = Serializer.Deserialize<Database>(fs);
                Assert.Equal(EXPECTED, db.Orders.Count);
            }
        }
        private class FakeStream : MemoryStream
        {
            public FakeStream() : base()
            {
            }
            public FakeStream(byte[] data)
                : base(data)
            {
            }
            public override bool CanSeek
            {
                get { return false; }
            }

            private int writeCount;
            public override long Length
            {
                get { // MemoryStream 'Write' calls Length sometimes (indirectly, via EnsureCapacity)
                    if (writeCount == 0) throw new NotSupportedException("Length called");
                    return base.Length;
                }
            }
            public override void Write(byte[] buffer, int offset, int count)
            {
                writeCount++;
                base.Write(buffer, offset, count);
                writeCount--;
            }
            public override void WriteByte(byte value)
            {
                writeCount++;
                base.WriteByte(value);
                writeCount--;
            }
            public override long Position
            {
                get
                {
                    return base.Position;
                }
                set
                {
                    throw new NotSupportedException("Position (set) called");
                }
            }
            public override void SetLength(long value)
            {
                throw new NotSupportedException("SetLength called");
            }
            public override long Seek(long offset, SeekOrigin loc)
            {
                throw new NotSupportedException("Seek called");
            }
        }
    }
}
#endif