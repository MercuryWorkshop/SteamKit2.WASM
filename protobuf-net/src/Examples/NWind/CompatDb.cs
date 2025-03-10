﻿
#pragma warning disable IDE1006, RCS1015, RCS1020, RCS1032, RCS1037, RCS1085, RCS1163
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using ProtoBuf;
using ProtoSharp.Core;
using Serializer = ProtoBuf.Serializer;

#if !COREFX
using System.Data.Linq.Mapping;
#endif

namespace ProtoSharp.Core
{
    // throwaway [Tag] replacement from ProtoSharp
    [AttributeUsage(AttributeTargets.Property| AttributeTargets.Field)]
    internal class TagAttribute : Attribute
    {
        public int Tag { get; }
        public TagAttribute(int tag) => Tag = tag;
    }
}
namespace DAL
{
    [ProtoContract, DataContract, Serializable]
    public class DatabaseCompat
    {
        public const bool MASTER_GROUP = false;

        [ProtoMember(1, DataFormat = Database.SubObjectFormat), Tag(1), DataMember(Order = 1)]
        [XmlArray]
        public List<OrderCompat> Orders { get; set; }

        public DatabaseCompat()
        {
            Orders = new List<OrderCompat>();
        }
    }

    [ProtoContract, DataContract, Serializable]
    public class DatabaseCompatRem
#if REMOTING
        : ISerializable
#endif
#if PLAT_XMLSERIALIZER
        , IXmlSerializable
#endif
    {
        public const bool MASTER_GROUP = false;

        [ProtoMember(1, DataFormat = Database.SubObjectFormat), Tag(1), DataMember(Order = 1)]
        [XmlArray]
        public List<OrderCompat> Orders { get; set; }

        public DatabaseCompatRem()
        {
            Orders = new List<OrderCompat>();
        }

#region ISerializable Members
#if REMOTING
        protected DatabaseCompatRem(SerializationInfo info, StreamingContext context)
            : this()
        {
            Serializer.Merge<DatabaseCompatRem>(info, this);
        }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Serializer.Serialize <DatabaseCompatRem>(info, this);
        }
#endif
#endregion

#region IXmlSerializable Members

#if PLAT_XMLSERIALIZER
        System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }

        void IXmlSerializable.ReadXml(System.Xml.XmlReader reader)
        {
            Serializer.Merge(reader, this);
        }

        void IXmlSerializable.WriteXml(System.Xml.XmlWriter writer)
        {
            Serializer.Serialize(writer, this);            
        }
#endif
#endregion
    }
    
    [DataContract(), Serializable]
    public partial class OrderCompat
    {
        private int _OrderID;

        private string _CustomerID;

        private System.Nullable<int> _EmployeeID;

        private System.Nullable<System.DateTime> _OrderDate;

        private System.Nullable<System.DateTime> _RequiredDate;

        private System.Nullable<System.DateTime> _ShippedDate;

        private System.Nullable<int> _ShipVia;

        private System.Nullable<decimal> _Freight;

        private string _ShipName;

        private string _ShipAddress;

        private string _ShipCity;

        private string _ShipRegion;

        private string _ShipPostalCode;

        private string _ShipCountry;

        private List<OrderLineCompat> _Lines = new List<OrderLineCompat>();

#region Extensibility Method Definitions
        partial void OnLoaded();
#if !COREFX
        partial void OnValidate(System.Data.Linq.ChangeAction action);
#endif
        partial void OnCreated();
        partial void OnOrderIDChanging(int value);
        partial void OnOrderIDChanged();
        partial void OnCustomerIDChanging(string value);
        partial void OnCustomerIDChanged();
        partial void OnEmployeeIDChanging(System.Nullable<int> value);
        partial void OnEmployeeIDChanged();
        partial void OnOrderDateChanging(System.Nullable<System.DateTime> value);
        partial void OnOrderDateChanged();
        partial void OnRequiredDateChanging(System.Nullable<System.DateTime> value);
        partial void OnRequiredDateChanged();
        partial void OnShippedDateChanging(System.Nullable<System.DateTime> value);
        partial void OnShippedDateChanged();
        partial void OnShipViaChanging(System.Nullable<int> value);
        partial void OnShipViaChanged();
        partial void OnFreightChanging(System.Nullable<decimal> value);
        partial void OnFreightChanged();
        partial void OnShipNameChanging(string value);
        partial void OnShipNameChanged();
        partial void OnShipAddressChanging(string value);
        partial void OnShipAddressChanged();
        partial void OnShipCityChanging(string value);
        partial void OnShipCityChanged();
        partial void OnShipRegionChanging(string value);
        partial void OnShipRegionChanged();
        partial void OnShipPostalCodeChanging(string value);
        partial void OnShipPostalCodeChanged();
        partial void OnShipCountryChanging(string value);
        partial void OnShipCountryChanged();
#endregion

        public OrderCompat()
        {
            this.Initialize();
        }
#if !COREFX
        [Column(Storage = "_OrderID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
#endif
        [DataMember(Order = 1), Tag(1)]
        public int OrderID
        {
            get
            {
                return this._OrderID;
            }
            set
            {
                if ((this._OrderID != value))
                {
                    this.OnOrderIDChanging(value);
                    this.SendPropertyChanging();
                    this._OrderID = value;
                    this.SendPropertyChanged("OrderID");
                    this.OnOrderIDChanged();
                }
            }
        }

#if !COREFX
        [Column(Storage = "_CustomerID", DbType = "NChar(5)")]
#endif
        [DataMember(Order = 2), Tag(2)]
        public string CustomerID
        {
            get
            {
                return this._CustomerID;
            }
            set
            {
                if ((this._CustomerID != value))
                {
                    this.OnCustomerIDChanging(value);
                    this.SendPropertyChanging();
                    this._CustomerID = value;
                    this.SendPropertyChanged("CustomerID");
                    this.OnCustomerIDChanged();
                }
            }
        }

#if !COREFX
        [Column(Storage = "_EmployeeID", DbType = "Int")]
#endif
        [DataMember(Order = 3), Tag(3)]
        public System.Nullable<int> EmployeeID
        {
            get
            {
                return this._EmployeeID;
            }
            set
            {
                if ((this._EmployeeID != value))
                {
                    this.OnEmployeeIDChanging(value);
                    this.SendPropertyChanging();
                    this._EmployeeID = value;
                    this.SendPropertyChanged("EmployeeID");
                    this.OnEmployeeIDChanged();
                }
            }
        }

#if !COREFX
        [Column(Storage = "_OrderDate", DbType = "DateTime")]
#endif
        [DataMember(Order = 4), Tag(4), ProtoMember(4, DataFormat = Database.SubObjectFormat)]
        public System.Nullable<System.DateTime> OrderDate
        {
            get
            {
                return this._OrderDate;
            }
            set
            {
                if ((this._OrderDate != value))
                {
                    this.OnOrderDateChanging(value);
                    this.SendPropertyChanging();
                    this._OrderDate = value;
                    this.SendPropertyChanged("OrderDate");
                    this.OnOrderDateChanged();
                }
            }
        }

#if !COREFX
        [Column(Storage = "_RequiredDate", DbType = "DateTime")]
#endif
        [DataMember(Order = 5), Tag(5), ProtoMember(5, DataFormat = Database.SubObjectFormat)]
        public System.Nullable<System.DateTime> RequiredDate
        {
            get
            {
                return this._RequiredDate;
            }
            set
            {
                if ((this._RequiredDate != value))
                {
                    this.OnRequiredDateChanging(value);
                    this.SendPropertyChanging();
                    this._RequiredDate = value;
                    this.SendPropertyChanged("RequiredDate");
                    this.OnRequiredDateChanged();
                }
            }
        }

#if !COREFX
        [Column(Storage = "_ShippedDate", DbType = "DateTime")]
#endif
        [DataMember(Order = 6), Tag(6), ProtoMember(6, DataFormat = Database.SubObjectFormat)]
        public System.Nullable<System.DateTime> ShippedDate
        {
            get
            {
                return this._ShippedDate;
            }
            set
            {
                if ((this._ShippedDate != value))
                {
                    this.OnShippedDateChanging(value);
                    this.SendPropertyChanging();
                    this._ShippedDate = value;
                    this.SendPropertyChanged("ShippedDate");
                    this.OnShippedDateChanged();
                }
            }
        }

#if !COREFX
        [Column(Storage = "_ShipVia", DbType = "Int")]
#endif
        [DataMember(Order = 7), Tag(7)]
        public System.Nullable<int> ShipVia
        {
            get
            {
                return this._ShipVia;
            }
            set
            {
                if ((this._ShipVia != value))
                {
                    this.OnShipViaChanging(value);
                    this.SendPropertyChanging();
                    this._ShipVia = value;
                    this.SendPropertyChanged("ShipVia");
                    this.OnShipViaChanged();
                }
            }
        }

#if !COREFX
        [Column(Storage = "_Freight", DbType = "Money")]
#endif
        [DataMember(Order = 8), Tag(8), ProtoMember(8, DataFormat = Database.SubObjectFormat)]
        public System.Nullable<decimal> Freight
        {
            get
            {
                return this._Freight;
            }
            set
            {
                if ((this._Freight != value))
                {
                    this.OnFreightChanging(value);
                    this.SendPropertyChanging();
                    this._Freight = value;
                    this.SendPropertyChanged("Freight");
                    this.OnFreightChanged();
                }
            }
        }

#if !COREFX
        [Column(Storage = "_ShipName", DbType = "NVarChar(40)")]
#endif
        [DataMember(Order = 9), Tag(9)]
        public string ShipName
        {
            get
            {
                return this._ShipName;
            }
            set
            {
                if ((this._ShipName != value))
                {
                    this.OnShipNameChanging(value);
                    this.SendPropertyChanging();
                    this._ShipName = value;
                    this.SendPropertyChanged("ShipName");
                    this.OnShipNameChanged();
                }
            }
        }

#if !COREFX
        [Column(Storage = "_ShipAddress", DbType = "NVarChar(60)")]
#endif
        [DataMember(Order = 10), Tag(10)]
        public string ShipAddress
        {
            get
            {
                return this._ShipAddress;
            }
            set
            {
                if ((this._ShipAddress != value))
                {
                    this.OnShipAddressChanging(value);
                    this.SendPropertyChanging();
                    this._ShipAddress = value;
                    this.SendPropertyChanged("ShipAddress");
                    this.OnShipAddressChanged();
                }
            }
        }

#if !COREFX
        [Column(Storage = "_ShipCity", DbType = "NVarChar(15)")]
#endif
        [DataMember(Order = 11), Tag(11)]
        public string ShipCity
        {
            get
            {
                return this._ShipCity;
            }
            set
            {
                if ((this._ShipCity != value))
                {
                    this.OnShipCityChanging(value);
                    this.SendPropertyChanging();
                    this._ShipCity = value;
                    this.SendPropertyChanged("ShipCity");
                    this.OnShipCityChanged();
                }
            }
        }

#if !COREFX
        [Column(Storage = "_ShipRegion", DbType = "NVarChar(15)")]
#endif
        [DataMember(Order = 12), Tag(12)]
        public string ShipRegion
        {
            get
            {
                return this._ShipRegion;
            }
            set
            {
                if ((this._ShipRegion != value))
                {
                    this.OnShipRegionChanging(value);
                    this.SendPropertyChanging();
                    this._ShipRegion = value;
                    this.SendPropertyChanged("ShipRegion");
                    this.OnShipRegionChanged();
                }
            }
        }

#if !COREFX
        [Column(Storage = "_ShipPostalCode", DbType = "NVarChar(10)")]
#endif
        [DataMember(Order = 13), Tag(13)]
        public string ShipPostalCode
        {
            get
            {
                return this._ShipPostalCode;
            }
            set
            {
                if ((this._ShipPostalCode != value))
                {
                    this.OnShipPostalCodeChanging(value);
                    this.SendPropertyChanging();
                    this._ShipPostalCode = value;
                    this.SendPropertyChanged("ShipPostalCode");
                    this.OnShipPostalCodeChanged();
                }
            }
        }

#if !COREFX
        [Column(Storage = "_ShipCountry", DbType = "NVarChar(15)")]
#endif
        [DataMember(Order = 14), Tag(14)]
        public string ShipCountry
        {
            get
            {
                return this._ShipCountry;
            }
            set
            {
                if ((this._ShipCountry != value))
                {
                    this.OnShipCountryChanging(value);
                    this.SendPropertyChanging();
                    this._ShipCountry = value;
                    this.SendPropertyChanged("ShipCountry");
                    this.OnShipCountryChanged();
                }
            }
        }

#if !COREFX
        [Association(Name = "Order_Order_Detail", Storage = "_Lines", OtherKey = "OrderID")]
#endif
        [DataMember(Order = 15, EmitDefaultValue = false), Tag(15), ProtoMember(15, DataFormat = Database.SubObjectFormat)]
        [XmlArray]
        public List<OrderLineCompat> Lines
        {
            get
            {
                return this._Lines;
            }
            set { this._Lines = value; }
        }

        protected virtual void SendPropertyChanging()
        {
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
        }

        private void attach_Lines(OrderLineCompat entity)
        {
            this.SendPropertyChanging();
        }

        private void detach_Lines(OrderLineCompat entity)
        {
            this.SendPropertyChanging();
        }

        private void Initialize()
        {
            OnCreated();
        }

        [OnDeserializing()]
        [System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
        public void OnDeserializing(StreamingContext context)
        {
            this.Initialize();
        }

        [OnSerializing()]
        [System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
        public void OnSerializing(StreamingContext context)
        {
        }

        [OnSerialized()]
        [System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
        public void OnSerialized(StreamingContext context)
        {
        }
    }

#if !COREFX
    [Table(Name = "dbo.[Order Details]")]
#endif
    [DataContract(), Serializable]
    public partial class OrderLineCompat
    {
        private int _OrderID;

        private int _ProductID;

        private decimal _UnitPrice;

        private short _Quantity;

        private float _Discount;

#region Extensibility Method Definitions
        partial void OnLoaded();
#if !COREFX
        partial void OnValidate(System.Data.Linq.ChangeAction action);
#endif
        partial void OnCreated();
        partial void OnOrderIDChanging(int value);
        partial void OnOrderIDChanged();
        partial void OnProductIDChanging(int value);
        partial void OnProductIDChanged();
        partial void OnUnitPriceChanging(decimal value);
        partial void OnUnitPriceChanged();
        partial void OnQuantityChanging(short value);
        partial void OnQuantityChanged();
        partial void OnDiscountChanging(float value);
        partial void OnDiscountChanged();
#endregion

        public OrderLineCompat()
        {
            this.Initialize();
        }

#if !COREFX
        [Column(Storage = "_OrderID", DbType = "Int NOT NULL", IsPrimaryKey = true)]
#endif
        [DataMember(Order = 1), Tag(1)]
        public int OrderID
        {
            get
            {
                return this._OrderID;
            }
            set
            {
                this._OrderID = value;
            }
        }

#if !COREFX
        [Column(Storage = "_ProductID", DbType = "Int NOT NULL", IsPrimaryKey = true)]
#endif
        [DataMember(Order = 2), Tag(2)]
        public int ProductID
        {
            get
            {
                return this._ProductID;
            }
            set
            {
                if ((this._ProductID != value))
                {
                    this.OnProductIDChanging(value);
                    this.SendPropertyChanging();
                    this._ProductID = value;
                    this.SendPropertyChanged("ProductID");
                    this.OnProductIDChanged();
                }
            }
        }

#if !COREFX
        [Column(Storage = "_UnitPrice", DbType = "Money NOT NULL")]
#endif
        [DataMember(Order = 3), Tag(3), ProtoMember(3, DataFormat = Database.SubObjectFormat)]
        public decimal UnitPrice
        {
            get
            {
                return this._UnitPrice;
            }
            set
            {
                if ((this._UnitPrice != value))
                {
                    this.OnUnitPriceChanging(value);
                    this.SendPropertyChanging();
                    this._UnitPrice = value;
                    this.SendPropertyChanged("UnitPrice");
                    this.OnUnitPriceChanged();
                }
            }
        }

#if !COREFX
        [Column(Storage = "_Quantity", DbType = "SmallInt NOT NULL")]
#endif
        [DataMember(Order = 4), Tag(4)]
        public short Quantity
        {
            get
            {
                return this._Quantity;
            }
            set
            {
                if ((this._Quantity != value))
                {
                    this.OnQuantityChanging(value);
                    this.SendPropertyChanging();
                    this._Quantity = value;
                    this.SendPropertyChanged("Quantity");
                    this.OnQuantityChanged();
                }
            }
        }

#if !COREFX
        [Column(Storage = "_Discount", DbType = "Real NOT NULL")]
#endif
        [DataMember(Order = 5), Tag(5)]
        public float Discount
        {
            get
            {
                return this._Discount;
            }
            set
            {
                if ((this._Discount != value))
                {
                    this.OnDiscountChanging(value);
                    this.SendPropertyChanging();
                    this._Discount = value;
                    this.SendPropertyChanged("Discount");
                    this.OnDiscountChanged();
                }
            }
        }

        
        protected virtual void SendPropertyChanging()
        {
            
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            
        }

        private void Initialize()
        {
            OnCreated();
        }

        [OnDeserializing()]
        [System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
        public void OnDeserializing(StreamingContext context)
        {
            this.Initialize();
        }
    }
}