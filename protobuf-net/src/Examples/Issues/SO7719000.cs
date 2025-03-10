﻿using ProtoBuf;
using ProtoBuf.Meta;
using System;
using System.IO;
using Xunit;

namespace Examples.Issues
{

    public class SO7719000
    {
        public abstract class Message
        {
        }

        public class SomeMessage : Message
        {
            public readonly Descriptor Desc;

            public SomeMessage(Descriptor desc)
            {
                Desc = desc;
            }
        }

        public struct Descriptor
        {
            public readonly Event EventData;

            public Descriptor(Event eventData)
            {
                EventData = eventData;
            }
        }

        public abstract class Event
        {
        }

        public class SomeEvent : Event
        {
            public int SomeField;
        }

        [Fact]
        public void Execute()
        {
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                var model = RuntimeTypeModel.Create();
                model.AutoCompile = false;
                // message hierarchy
                {
                    var messages = model.Add(typeof(Message), true);
                    messages.AddSubType(1, typeof(SomeMessage));
                    model[typeof(SomeMessage)].UseConstructor = false;
                }

                // events hierarchy
                {
                    var events = model.Add(typeof(Event), true);
                    events.AddSubType(1, typeof(SomeEvent));
                    model[typeof(SomeEvent)].Add(nameof(SomeEvent.SomeField)).UseConstructor = false;
                }
            });
            Assert.Equal("Tuple-based types cannot be used in inheritance hierarchies: Examples.Issues.SO7719000+SomeMessage", ex.Message);

            //// descriptor
            //var eventDescriptorModel = model.Add(typeof(Descriptor), true);
            //eventDescriptorModel.UseConstructor = false;

            //RunTest(model, "Runtime");

            //model.CompileInPlace();
            //RunTest(model, "CompileInPlace");

            //RunTest(model.Compile(), "Compile");

            //model.Compile("SO7719000", "SO7719000.dll");
            //PEVerify.AssertValid("SO7719000.dll");
        }
        private void RunTest(TypeModel typeModel, string caption)
        {
            const PrefixStyle prefixStyle = PrefixStyle.Base128;
            const int testValue = 5;
            using (var ms = new MemoryStream())
            {

                typeModel.SerializeWithLengthPrefix(ms, new SomeMessage(new Descriptor(new SomeEvent { SomeField = testValue })), null, prefixStyle, 0);

                ms.Seek(0, SeekOrigin.Begin);

                // fails here
                var message = (SomeMessage)typeModel.DeserializeWithLengthPrefix(ms, null, typeof(Message), prefixStyle, 0);

                Assert.Equal(testValue, ((SomeEvent)message.Desc.EventData).SomeField); //, caption);
            }
        }
    }
}
