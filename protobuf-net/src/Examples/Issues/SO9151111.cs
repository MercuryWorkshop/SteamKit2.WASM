﻿using System.Data.Entity.DynamicProxies;
using Xunit;
using ProtoBuf.Meta;

namespace Examples.Issues
{
    
    public class SO9151111
    {

        public class Command<TData> : BaseCommand where TData : ISomeInterface
        {
            public string Foo { get; set; }
        }

        public interface ISomeInterface
        {
        }

        public class BaseCommand
        {
        }
        
        public class SomeData : ISomeInterface
        {
            public string Bar { get; set; }
        }
        [Fact]
        public void TestManualConstuctionClosedType()
        {
            // In runtime this class is build (with specific TDATA) and Serialized. When I'm adding this type to runtime modal : (error)
            var model = RuntimeTypeModel.Create();
            model.Add(typeof (Command<SomeData>), false).Add(1, "Foo");
        }
        [Fact]
        public void TestManualConstuctionOpenType()
        {
            // don't actually expect this to work for serialization - I'm just doing this to try to repro the error
            var model = RuntimeTypeModel.Create();
            model.Add(typeof(Command<>), false).Add(1, "Foo");
        }

        [Fact]
        public void TestCanSerializeBehaviourWithSubTypeAndBaseType()
        {
            var model = RuntimeTypeModel.Create();
            model.Add(typeof (BaseCommand), false);
            // base-type; is defined - should be able to serialize
            Assert.True(model.CanSerializeContractType(typeof(BaseCommand)), "BaseCommand");
            // derived type; not defined; should not recognise
            Assert.False(model.CanSerializeContractType(typeof(Command<SomeData>)), "Command<SomeData>");
            // proxy derived type; should work the same as BaseCommand
            Assert.True(model.CanSerializeContractType(typeof(FakeProxyClassForBaseCommand)), "FakeProxyClassForBaseCommand");
        }
    }
}
namespace System.Data.Entity.DynamicProxies
{
    public class FakeProxyClassForBaseCommand : Examples.Issues.SO9151111.BaseCommand
    {
        
    }
}