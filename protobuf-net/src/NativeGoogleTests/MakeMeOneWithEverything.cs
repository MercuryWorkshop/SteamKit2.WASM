﻿// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: my.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, CS8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace ProtoBuf.Test
{

    /// <summary>Holder for reflection information generated from my.proto</summary>
    public static partial class MyReflection
    {

        #region Descriptor
        /// <summary>File descriptor for my.proto</summary>
        public static pbr::FileDescriptor Descriptor
        {
            get { return descriptor; }
        }
        private static pbr::FileDescriptor descriptor;

        static MyReflection()
        {
            byte[] descriptorData = global::System.Convert.FromBase64String(
                string.Concat(
                  "CghteS5wcm90bxINUHJvdG9CdWYuVGVzdBoeZ29vZ2xlL3Byb3RvYnVmL2R1",
                  "cmF0aW9uLnByb3RvGh9nb29nbGUvcHJvdG9idWYvdGltZXN0YW1wLnByb3Rv",
                  "GhZnb29nbGUvdHlwZS9kYXRlLnByb3RvGhtnb29nbGUvdHlwZS9kYXlvZndl",
                  "ZWsucHJvdG8aG2dvb2dsZS90eXBlL3RpbWVvZmRheS5wcm90byLyAQoXTWFr",
                  "ZU1lT25lV2l0aEV2ZXJ5dGhpbmcSKwoIRHVyYXRpb24YASABKAsyGS5nb29n",
                  "bGUucHJvdG9idWYuRHVyYXRpb24SKwoHSW5zdGFudBgCIAEoCzIaLmdvb2ds",
                  "ZS5wcm90b2J1Zi5UaW1lc3RhbXASJAoJTG9jYWxEYXRlGAMgASgLMhEuZ29v",
                  "Z2xlLnR5cGUuRGF0ZRIpCglMb2NhbFRpbWUYBCABKAsyFi5nb29nbGUudHlw",
                  "ZS5UaW1lT2ZEYXkSLAoMSXNvRGF5T2ZXZWVrGAUgASgOMhYuZ29vZ2xlLnR5",
                  "cGUuRGF5T2ZXZWVrYgZwcm90bzM="));
            descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
                new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.DurationReflection.Descriptor, global::Google.Protobuf.WellKnownTypes.TimestampReflection.Descriptor, global::Google.Type.DateReflection.Descriptor, global::Google.Type.DayofweekReflection.Descriptor, global::Google.Type.TimeofdayReflection.Descriptor, },
                new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::ProtoBuf.Test.MakeMeOneWithEverything), global::ProtoBuf.Test.MakeMeOneWithEverything.Parser, new[]{ "Duration", "Instant", "LocalDate", "LocalTime", "IsoDayOfWeek" }, null, null, null, null)
                }));
        }
        #endregion

    }
    #region Messages
    public sealed partial class MakeMeOneWithEverything : pb::IMessage<MakeMeOneWithEverything>
    {
        private static readonly pb::MessageParser<MakeMeOneWithEverything> _parser = new pb::MessageParser<MakeMeOneWithEverything>(() => new MakeMeOneWithEverything());
        private pb::UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pb::MessageParser<MakeMeOneWithEverything> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pbr::MessageDescriptor Descriptor
        {
            get { return global::ProtoBuf.Test.MyReflection.Descriptor.MessageTypes[0]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        pbr::MessageDescriptor pb::IMessage.Descriptor
        {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public MakeMeOneWithEverything()
        {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public MakeMeOneWithEverything(MakeMeOneWithEverything other) : this()
        {
            duration_ = other.duration_ != null ? other.duration_.Clone() : null;
            instant_ = other.instant_ != null ? other.instant_.Clone() : null;
            localDate_ = other.localDate_ != null ? other.localDate_.Clone() : null;
            localTime_ = other.localTime_ != null ? other.localTime_.Clone() : null;
            isoDayOfWeek_ = other.isoDayOfWeek_;
            _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public MakeMeOneWithEverything Clone()
        {
            return new MakeMeOneWithEverything(this);
        }

        /// <summary>Field number for the "Duration" field.</summary>
        public const int DurationFieldNumber = 1;
        private global::Google.Protobuf.WellKnownTypes.Duration duration_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public global::Google.Protobuf.WellKnownTypes.Duration Duration
        {
            get { return duration_; }
            set
            {
                duration_ = value;
            }
        }

        /// <summary>Field number for the "Instant" field.</summary>
        public const int InstantFieldNumber = 2;
        private global::Google.Protobuf.WellKnownTypes.Timestamp instant_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public global::Google.Protobuf.WellKnownTypes.Timestamp Instant
        {
            get { return instant_; }
            set
            {
                instant_ = value;
            }
        }

        /// <summary>Field number for the "LocalDate" field.</summary>
        public const int LocalDateFieldNumber = 3;
        private global::Google.Type.Date localDate_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public global::Google.Type.Date LocalDate
        {
            get { return localDate_; }
            set
            {
                localDate_ = value;
            }
        }

        /// <summary>Field number for the "LocalTime" field.</summary>
        public const int LocalTimeFieldNumber = 4;
        private global::Google.Type.TimeOfDay localTime_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public global::Google.Type.TimeOfDay LocalTime
        {
            get { return localTime_; }
            set
            {
                localTime_ = value;
            }
        }

        /// <summary>Field number for the "IsoDayOfWeek" field.</summary>
        public const int IsoDayOfWeekFieldNumber = 5;
        private global::Google.Type.DayOfWeek isoDayOfWeek_ = global::Google.Type.DayOfWeek.Unspecified;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public global::Google.Type.DayOfWeek IsoDayOfWeek
        {
            get { return isoDayOfWeek_; }
            set
            {
                isoDayOfWeek_ = value;
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other)
        {
            return Equals(other as MakeMeOneWithEverything);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(MakeMeOneWithEverything other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(other, this))
            {
                return true;
            }
            if (!object.Equals(Duration, other.Duration)) return false;
            if (!object.Equals(Instant, other.Instant)) return false;
            if (!object.Equals(LocalDate, other.LocalDate)) return false;
            if (!object.Equals(LocalTime, other.LocalTime)) return false;
            if (IsoDayOfWeek != other.IsoDayOfWeek) return false;
            return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode()
        {
            int hash = 1;
            if (duration_ != null) hash ^= Duration.GetHashCode();
            if (instant_ != null) hash ^= Instant.GetHashCode();
            if (localDate_ != null) hash ^= LocalDate.GetHashCode();
            if (localTime_ != null) hash ^= LocalTime.GetHashCode();
            if (IsoDayOfWeek != global::Google.Type.DayOfWeek.Unspecified) hash ^= IsoDayOfWeek.GetHashCode();
            if (_unknownFields != null)
            {
                hash ^= _unknownFields.GetHashCode();
            }
            return hash;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override string ToString()
        {
            return pb::JsonFormatter.ToDiagnosticString(this);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void WriteTo(pb::CodedOutputStream output)
        {
            if (duration_ != null)
            {
                output.WriteRawTag(10);
                output.WriteMessage(Duration);
            }
            if (instant_ != null)
            {
                output.WriteRawTag(18);
                output.WriteMessage(Instant);
            }
            if (localDate_ != null)
            {
                output.WriteRawTag(26);
                output.WriteMessage(LocalDate);
            }
            if (localTime_ != null)
            {
                output.WriteRawTag(34);
                output.WriteMessage(LocalTime);
            }
            if (IsoDayOfWeek != global::Google.Type.DayOfWeek.Unspecified)
            {
                output.WriteRawTag(40);
                output.WriteEnum((int)IsoDayOfWeek);
            }
            if (_unknownFields != null)
            {
                _unknownFields.WriteTo(output);
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize()
        {
            int size = 0;
            if (duration_ != null)
            {
                size += 1 + pb::CodedOutputStream.ComputeMessageSize(Duration);
            }
            if (instant_ != null)
            {
                size += 1 + pb::CodedOutputStream.ComputeMessageSize(Instant);
            }
            if (localDate_ != null)
            {
                size += 1 + pb::CodedOutputStream.ComputeMessageSize(LocalDate);
            }
            if (localTime_ != null)
            {
                size += 1 + pb::CodedOutputStream.ComputeMessageSize(LocalTime);
            }
            if (IsoDayOfWeek != global::Google.Type.DayOfWeek.Unspecified)
            {
                size += 1 + pb::CodedOutputStream.ComputeEnumSize((int)IsoDayOfWeek);
            }
            if (_unknownFields != null)
            {
                size += _unknownFields.CalculateSize();
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(MakeMeOneWithEverything other)
        {
            if (other == null)
            {
                return;
            }
            if (other.duration_ != null)
            {
                if (duration_ == null)
                {
                    Duration = new global::Google.Protobuf.WellKnownTypes.Duration();
                }
                Duration.MergeFrom(other.Duration);
            }
            if (other.instant_ != null)
            {
                if (instant_ == null)
                {
                    Instant = new global::Google.Protobuf.WellKnownTypes.Timestamp();
                }
                Instant.MergeFrom(other.Instant);
            }
            if (other.localDate_ != null)
            {
                if (localDate_ == null)
                {
                    LocalDate = new global::Google.Type.Date();
                }
                LocalDate.MergeFrom(other.LocalDate);
            }
            if (other.localTime_ != null)
            {
                if (localTime_ == null)
                {
                    LocalTime = new global::Google.Type.TimeOfDay();
                }
                LocalTime.MergeFrom(other.LocalTime);
            }
            if (other.IsoDayOfWeek != global::Google.Type.DayOfWeek.Unspecified)
            {
                IsoDayOfWeek = other.IsoDayOfWeek;
            }
            _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(pb::CodedInputStream input)
        {
            uint tag;
            while ((tag = input.ReadTag()) != 0)
            {
                switch (tag)
                {
                    default:
                        _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
                        break;
                    case 10:
                        {
                            if (duration_ == null)
                            {
                                Duration = new global::Google.Protobuf.WellKnownTypes.Duration();
                            }
                            input.ReadMessage(Duration);
                            break;
                        }
                    case 18:
                        {
                            if (instant_ == null)
                            {
                                Instant = new global::Google.Protobuf.WellKnownTypes.Timestamp();
                            }
                            input.ReadMessage(Instant);
                            break;
                        }
                    case 26:
                        {
                            if (localDate_ == null)
                            {
                                LocalDate = new global::Google.Type.Date();
                            }
                            input.ReadMessage(LocalDate);
                            break;
                        }
                    case 34:
                        {
                            if (localTime_ == null)
                            {
                                LocalTime = new global::Google.Type.TimeOfDay();
                            }
                            input.ReadMessage(LocalTime);
                            break;
                        }
                    case 40:
                        {
                            IsoDayOfWeek = (global::Google.Type.DayOfWeek)input.ReadEnum();
                            break;
                        }
                }
            }
        }

    }

    #endregion

}

#endregion Designer generated code
