﻿#if !COREFX
using Xunit;
using ProtoBuf;
using ProtoBuf.Meta;
using System.Collections.Generic;

namespace Examples.Issues
{
    
    public class SO13275299
    {
        [ProtoContract]
        public class Foo
        {
            [ProtoMember(1)]
            public List<System.Drawing.Point> Points { get; set; }
        }
        [ProtoContract]
        public class Bar
        {
            [ProtoMember(1)]
            public List<System.Windows.Point> Points { get; set; }
        }
        [Fact]
        public void TestSystemDrawingPoint()
        {
            var model = RuntimeTypeModel.Create();
            model.Add(typeof(System.Drawing.Point), false).Add("X", "Y");
            model.AutoCompile = false;
            ExecSystemDrawing(model, "Runtime");
            model.CompileInPlace();
            ExecSystemDrawing(model, "CompileInPlace");
            ExecSystemDrawing(model.Compile(), "Compile");
        }
        [Fact]
        public void TestSystemWindowsPoint()
        {
            var model = RuntimeTypeModel.Create();
            model.Add(typeof(System.Windows.Point), false).Add("X", "Y");
            model.AutoCompile = false;
            ExecSystemWindows(model, "Runtime");
            model.CompileInPlace();
            ExecSystemWindows(model, "CompileInPlace");
            ExecSystemWindows(model.Compile(), "Compile");
        }

        private void ExecSystemDrawing(TypeModel typeModel, string caption)
        {
            var obj = new Foo
            {
                Points = new List<System.Drawing.Point>
                {
                    new System.Drawing.Point(1,2),
                    new System.Drawing.Point(3,4),
                    new System.Drawing.Point(5,6),
                }
            };
            var clone = (Foo)typeModel.DeepClone(obj);
            Assert.Equal(3, clone.Points.Count); //, caption);
            Assert.Equal(1, clone.Points[0].X); //, caption);
            Assert.Equal(2, clone.Points[0].Y); //, caption);
            Assert.Equal(3, clone.Points[1].X); //, caption);
            Assert.Equal(4, clone.Points[1].Y); //, caption);
            Assert.Equal(5, clone.Points[2].X); //, caption);
            Assert.Equal(6, clone.Points[2].Y); //, caption);
        }
        private void ExecSystemWindows(TypeModel typeModel, string caption)
        {
            var obj = new Bar
            {
                Points = new List<System.Windows.Point>
                {
                    new System.Windows.Point(1,2),
                    new System.Windows.Point(3,4),
                    new System.Windows.Point(5,6),
                }
            };
            var clone = (Bar)typeModel.DeepClone(obj);
            Assert.Equal(3, clone.Points.Count); //, caption);
            Assert.Equal(1, clone.Points[0].X); //, caption);
            Assert.Equal(2, clone.Points[0].Y); //, caption);
            Assert.Equal(3, clone.Points[1].X); //, caption);
            Assert.Equal(4, clone.Points[1].Y); //, caption);
            Assert.Equal(5, clone.Points[2].X); //, caption);
            Assert.Equal(6, clone.Points[2].Y); //, caption);
        }
    }


}
#endif