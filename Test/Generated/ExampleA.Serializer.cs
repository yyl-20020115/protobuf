﻿//
//	This is the backend code for reading and writing
//	Report bugs to: https://silentorbit.com/protobuf/
//
//	Generated by ProtocolBuffer
//	- a pure c# code generation implementation of protocol buffers
//
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using ProtocolBuffers;

namespace Personal
{
	public partial class Person
	{
		public static Person Deserialize (Stream stream)
		{
			Person instance = new Person ();
			Deserialize (stream, instance);
			return instance;
		}
		
		public static Person Deserialize (byte[] buffer)
		{
			using (MemoryStream ms = new MemoryStream(buffer))
				return Deserialize (ms);
		}
		
		public static T Deserialize<T> (Stream stream) where T : Personal.Person, new()
		{
			T instance = new T ();
			Deserialize (stream, instance);
			return instance;
		}
		
		public static T Deserialize<T> (byte[] buffer) where T : Personal.Person, new()
		{
			T instance = new T ();
			Deserialize (buffer, instance);
			return instance;
		}
		
		public static Personal.Person Deserialize (byte[] buffer, Personal.Person instance)
		{
			using (MemoryStream ms = new MemoryStream(buffer))
				Deserialize (ms, instance);
			return instance;
		}
		
		public static Personal.Person Deserialize (Stream stream, Personal.Person instance)
		{
			if (instance.Phone == null)
				instance.Phone = new List<Personal.Person.PhoneNumber> ();
			while (true) {
				ProtocolBuffers.Key key = null;
				int keyByte = stream.ReadByte ();
				if (keyByte == -1)
					break;
				//Optimized reading of known fields with field ID < 16
				switch (keyByte) {
				case 10: //Field 1 LengthDelimited
					instance.Name = ProtocolParser.ReadString (stream);
					break;
				case 16: //Field 2 Varint
					instance.Id = (int)ProtocolParser.ReadUInt32 (stream);
					break;
				case 26: //Field 3 LengthDelimited
					instance.Email = ProtocolParser.ReadString (stream);
					break;
				case 34: //Field 4 LengthDelimited
					instance.Phone.Add (Personal.Person.PhoneNumber.Deserialize (ProtocolParser.ReadBytes (stream)));
		
					break;
				default:
					key = ProtocolParser.ReadKey ((byte)keyByte, stream);
					break;
				}
		
				if (key == null)
					continue;
		
				//Reading field ID > 16 and unknown field ID/wire type combinations
				switch (key.Field) {
				case 0:
					throw new InvalidDataException ("Invalid field id: 0, something went wrong in the stream");
				default:
					ProtocolParser.SkipKey (stream, key);
					break;
				}
			}
			
			return instance;
		}
		
		public static Personal.Person Read (byte[] buffer, Personal.Person instance)
		{
			using (MemoryStream ms = new MemoryStream(buffer))
				Deserialize (ms, instance);
			return instance;
		}
	
		public static void Serialize (Stream stream, Person instance)
		{
			if (instance.Name == null)
				throw new ArgumentNullException ("Name", "Required by proto specification.");
			ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (1, Wire.LengthDelimited));
			ProtocolParser.WriteString (stream, instance.Name);
			ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (2, Wire.Varint));
			ProtocolParser.WriteUInt32 (stream, (uint)instance.Id);
			if (instance.Email != null) {
				ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (3, Wire.LengthDelimited));
				ProtocolParser.WriteString (stream, instance.Email);
			}
			if (instance.Phone != null) {
				foreach (Personal.Person.PhoneNumber i4 in instance.Phone) {
					ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (4, Wire.LengthDelimited));
					using (MemoryStream ms4 = new MemoryStream()) {
						Personal.Person.PhoneNumber.Serialize (ms4, i4);
						ProtocolParser.WriteBytes (stream, ms4.ToArray ());
					}
			
				}
			}
		}
		
		public static byte[] SerializeToBytes (Person instance)
		{
			using (MemoryStream ms = new MemoryStream()) {
				Serialize (ms, instance);
				return ms.ToArray ();
			}
		}
	
		public partial class PhoneNumber
		{
			public static PhoneNumber Deserialize (Stream stream)
			{
				PhoneNumber instance = new PhoneNumber ();
				Deserialize (stream, instance);
				return instance;
			}
			
			public static PhoneNumber Deserialize (byte[] buffer)
			{
				using (MemoryStream ms = new MemoryStream(buffer))
					return Deserialize (ms);
			}
			
			public static T Deserialize<T> (Stream stream) where T : Personal.Person.PhoneNumber, new()
			{
				T instance = new T ();
				Deserialize (stream, instance);
				return instance;
			}
			
			public static T Deserialize<T> (byte[] buffer) where T : Personal.Person.PhoneNumber, new()
			{
				T instance = new T ();
				Deserialize (buffer, instance);
				return instance;
			}
			
			public static Personal.Person.PhoneNumber Deserialize (byte[] buffer, Personal.Person.PhoneNumber instance)
			{
				using (MemoryStream ms = new MemoryStream(buffer))
					Deserialize (ms, instance);
				return instance;
			}
			
			public static Personal.Person.PhoneNumber Deserialize (Stream stream, Personal.Person.PhoneNumber instance)
			{
				instance.Type = Personal.Person.PhoneType.HOME;
				while (true) {
					ProtocolBuffers.Key key = null;
					int keyByte = stream.ReadByte ();
					if (keyByte == -1)
						break;
					//Optimized reading of known fields with field ID < 16
					switch (keyByte) {
					case 10: //Field 1 LengthDelimited
						instance.Number = ProtocolParser.ReadString (stream);
						break;
					case 16: //Field 2 Varint
						instance.Type = (Personal.Person.PhoneType)ProtocolParser.ReadUInt32 (stream);
						break;
					default:
						key = ProtocolParser.ReadKey ((byte)keyByte, stream);
						break;
					}
			
					if (key == null)
						continue;
			
					//Reading field ID > 16 and unknown field ID/wire type combinations
					switch (key.Field) {
					case 0:
						throw new InvalidDataException ("Invalid field id: 0, something went wrong in the stream");
					default:
						ProtocolParser.SkipKey (stream, key);
						break;
					}
				}
				
				return instance;
			}
			
			public static Personal.Person.PhoneNumber Read (byte[] buffer, Personal.Person.PhoneNumber instance)
			{
				using (MemoryStream ms = new MemoryStream(buffer))
					Deserialize (ms, instance);
				return instance;
			}
		
			public static void Serialize (Stream stream, PhoneNumber instance)
			{
				if (instance.Number == null)
					throw new ArgumentNullException ("Number", "Required by proto specification.");
				ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (1, Wire.LengthDelimited));
				ProtocolParser.WriteString (stream, instance.Number);
				if (instance.Type != Personal.Person.PhoneType.HOME) {
					ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (2, Wire.Varint));
					ProtocolParser.WriteUInt32 (stream, (uint)instance.Type);
				}
			}
			
			public static byte[] SerializeToBytes (PhoneNumber instance)
			{
				using (MemoryStream ms = new MemoryStream()) {
					Serialize (ms, instance);
					return ms.ToArray ();
				}
			}
		}
		
	}
	

}
namespace ExampleNamespaceA
{
	public partial class AddressBook
	{
		public static AddressBook Deserialize (Stream stream)
		{
			AddressBook instance = new AddressBook ();
			Deserialize (stream, instance);
			return instance;
		}
		
		public static AddressBook Deserialize (byte[] buffer)
		{
			using (MemoryStream ms = new MemoryStream(buffer))
				return Deserialize (ms);
		}
		
		public static T Deserialize<T> (Stream stream) where T : ExampleNamespaceA.AddressBook, new()
		{
			T instance = new T ();
			Deserialize (stream, instance);
			return instance;
		}
		
		public static T Deserialize<T> (byte[] buffer) where T : ExampleNamespaceA.AddressBook, new()
		{
			T instance = new T ();
			Deserialize (buffer, instance);
			return instance;
		}
		
		public static ExampleNamespaceA.AddressBook Deserialize (byte[] buffer, ExampleNamespaceA.AddressBook instance)
		{
			using (MemoryStream ms = new MemoryStream(buffer))
				Deserialize (ms, instance);
			return instance;
		}
		
		public static ExampleNamespaceA.AddressBook Deserialize (Stream stream, ExampleNamespaceA.AddressBook instance)
		{
			if (instance.List == null)
				instance.List = new List<Personal.Person> ();
			while (true) {
				ProtocolBuffers.Key key = null;
				int keyByte = stream.ReadByte ();
				if (keyByte == -1)
					break;
				//Optimized reading of known fields with field ID < 16
				switch (keyByte) {
				case 10: //Field 1 LengthDelimited
					instance.List.Add (Personal.Person.Deserialize (ProtocolParser.ReadBytes (stream)));
		
					break;
				default:
					key = ProtocolParser.ReadKey ((byte)keyByte, stream);
					break;
				}
		
				if (key == null)
					continue;
		
				//Reading field ID > 16 and unknown field ID/wire type combinations
				switch (key.Field) {
				case 0:
					throw new InvalidDataException ("Invalid field id: 0, something went wrong in the stream");
				default:
					ProtocolParser.SkipKey (stream, key);
					break;
				}
			}
			
			return instance;
		}
		
		public static ExampleNamespaceA.AddressBook Read (byte[] buffer, ExampleNamespaceA.AddressBook instance)
		{
			using (MemoryStream ms = new MemoryStream(buffer))
				Deserialize (ms, instance);
			return instance;
		}
	
		public static void Serialize (Stream stream, AddressBook instance)
		{
			if (instance.List != null) {
				foreach (Personal.Person i1 in instance.List) {
					ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (1, Wire.LengthDelimited));
					using (MemoryStream ms1 = new MemoryStream()) {
						Personal.Person.Serialize (ms1, i1);
						ProtocolParser.WriteBytes (stream, ms1.ToArray ());
					}
			
				}
			}
		}
		
		public static byte[] SerializeToBytes (AddressBook instance)
		{
			using (MemoryStream ms = new MemoryStream()) {
				Serialize (ms, instance);
				return ms.ToArray ();
			}
		}
	}
	

}
namespace Mine
{
	public partial class MyMessageV1
	{
		public static MyMessageV1 Deserialize (Stream stream)
		{
			MyMessageV1 instance = new MyMessageV1 ();
			Deserialize (stream, instance);
			return instance;
		}
		
		public static MyMessageV1 Deserialize (byte[] buffer)
		{
			using (MemoryStream ms = new MemoryStream(buffer))
				return Deserialize (ms);
		}
		
		public static T Deserialize<T> (Stream stream) where T : Mine.MyMessageV1, new()
		{
			T instance = new T ();
			Deserialize (stream, instance);
			return instance;
		}
		
		public static T Deserialize<T> (byte[] buffer) where T : Mine.MyMessageV1, new()
		{
			T instance = new T ();
			Deserialize (buffer, instance);
			return instance;
		}
		
		public static Mine.MyMessageV1 Deserialize (byte[] buffer, Mine.MyMessageV1 instance)
		{
			using (MemoryStream ms = new MemoryStream(buffer))
				Deserialize (ms, instance);
			return instance;
		}
		
		public static Mine.MyMessageV1 Deserialize (Stream stream, Mine.MyMessageV1 instance)
		{
			while (true) {
				ProtocolBuffers.Key key = null;
				int keyByte = stream.ReadByte ();
				if (keyByte == -1)
					break;
				//Optimized reading of known fields with field ID < 16
				switch (keyByte) {
				case 8: //Field 1 Varint
					instance.FieldA = (int)ProtocolParser.ReadUInt32 (stream);
					break;
				default:
					key = ProtocolParser.ReadKey ((byte)keyByte, stream);
					break;
				}
		
				if (key == null)
					continue;
		
				//Reading field ID > 16 and unknown field ID/wire type combinations
				switch (key.Field) {
				case 0:
					throw new InvalidDataException ("Invalid field id: 0, something went wrong in the stream");
				default:
					if(instance.PreservedFields == null)
						instance.PreservedFields = new List<KeyValue>();
					instance.PreservedFields.Add(new KeyValue(key, ProtocolParser.ReadValueBytes (stream, key)));
					break;
				}
			}
			
			return instance;
		}
		
		public static Mine.MyMessageV1 Read (byte[] buffer, Mine.MyMessageV1 instance)
		{
			using (MemoryStream ms = new MemoryStream(buffer))
				Deserialize (ms, instance);
			return instance;
		}
	
		public static void Serialize (Stream stream, MyMessageV1 instance)
		{
			ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (1, Wire.Varint));
			ProtocolParser.WriteUInt32 (stream, (uint)instance.FieldA);
			if (instance.PreservedFields != null)
			{
				foreach (KeyValue kv in instance.PreservedFields)	{
					ProtocolParser.WriteKey (stream, kv.Key);
					stream.Write (kv.Value, 0, kv.Value.Length);
				}
			}
		}
		
		public static byte[] SerializeToBytes (MyMessageV1 instance)
		{
			using (MemoryStream ms = new MemoryStream()) {
				Serialize (ms, instance);
				return ms.ToArray ();
			}
		}
	}
	

}
namespace Yours
{
	public partial class MyMessageV2
	{
		public static MyMessageV2 Deserialize (Stream stream)
		{
			MyMessageV2 instance = new MyMessageV2 ();
			Deserialize (stream, instance);
			return instance;
		}
		
		public static MyMessageV2 Deserialize (byte[] buffer)
		{
			using (MemoryStream ms = new MemoryStream(buffer))
				return Deserialize (ms);
		}
		
		public static T Deserialize<T> (Stream stream) where T : Yours.MyMessageV2, new()
		{
			T instance = new T ();
			Deserialize (stream, instance);
			return instance;
		}
		
		public static T Deserialize<T> (byte[] buffer) where T : Yours.MyMessageV2, new()
		{
			T instance = new T ();
			Deserialize (buffer, instance);
			return instance;
		}
		
		public static Yours.MyMessageV2 Deserialize (byte[] buffer, Yours.MyMessageV2 instance)
		{
			using (MemoryStream ms = new MemoryStream(buffer))
				Deserialize (ms, instance);
			return instance;
		}
		
		public static Yours.MyMessageV2 Deserialize (Stream stream, Yours.MyMessageV2 instance)
		{
			BinaryReader br = new BinaryReader (stream);
			instance.FieldR = Yours.MyMessageV2.MyEnum.ETest2;
			if (instance.FieldS == null)
				instance.FieldS = new List<uint> ();
			if (instance.FieldT == null)
				instance.FieldT = new List<uint> ();
			if (instance.FieldV == null)
				instance.FieldV = new List<Theirs.TheirMessage> ();
			while (true) {
				ProtocolBuffers.Key key = null;
				int keyByte = stream.ReadByte ();
				if (keyByte == -1)
					break;
				//Optimized reading of known fields with field ID < 16
				switch (keyByte) {
				case 8: //Field 1 Varint
					instance.FieldA = (int)ProtocolParser.ReadUInt32 (stream);
					break;
				case 17: //Field 2 Fixed64
					instance.FieldB = br.ReadDouble ();
					break;
				case 29: //Field 3 Fixed32
					instance.FieldC = br.ReadSingle ();
					break;
				case 32: //Field 4 Varint
					instance.FieldD = (int)ProtocolParser.ReadUInt32 (stream);
					break;
				case 40: //Field 5 Varint
					instance.FieldE = (long)ProtocolParser.ReadUInt64 (stream);
					break;
				case 48: //Field 6 Varint
					instance.FieldF = ProtocolParser.ReadUInt32 (stream);
					break;
				case 56: //Field 7 Varint
					instance.FieldG = ProtocolParser.ReadUInt64 (stream);
					break;
				case 64: //Field 8 Varint
					instance.FieldH = ProtocolParser.ReadSInt32 (stream);
					break;
				case 72: //Field 9 Varint
					instance.FieldI = ProtocolParser.ReadSInt64 (stream);
					break;
				case 85: //Field 10 Fixed32
					instance.FieldJ = br.ReadUInt32 ();
					break;
				case 89: //Field 11 Fixed64
					instance.FieldK = br.ReadUInt64 ();
					break;
				case 101: //Field 12 Fixed32
					instance.FieldL = br.ReadInt32 ();
					break;
				case 105: //Field 13 Fixed64
					instance.FieldM = br.ReadInt64 ();
					break;
				case 112: //Field 14 Varint
					instance.FieldN = ProtocolParser.ReadBool (stream);
					break;
				case 122: //Field 15 LengthDelimited
					instance.FieldO = ProtocolParser.ReadString (stream);
					break;
				default:
					key = ProtocolParser.ReadKey ((byte)keyByte, stream);
					break;
				}
		
				if (key == null)
					continue;
		
				//Reading field ID > 16 and unknown field ID/wire type combinations
				switch (key.Field) {
				case 0:
					throw new InvalidDataException ("Invalid field id: 0, something went wrong in the stream");
				case 16:
					instance.FieldP = ProtocolParser.ReadBytes (stream);
					break;
				case 17:
					instance.FieldQ = (Yours.MyMessageV2.MyEnum)ProtocolParser.ReadUInt32 (stream);
					break;
				case 18:
					instance.FieldR = (Yours.MyMessageV2.MyEnum)ProtocolParser.ReadUInt32 (stream);
					break;
				case 19:
					instance.Dummy = ProtocolParser.ReadString (stream);
					break;
				case 20:
					instance.FieldS.Add (ProtocolParser.ReadUInt32 (stream));
		
					break;
				case 21:
					using (MemoryStream ms21 = new MemoryStream(ProtocolParser.ReadBytes(stream))) {
						while(true)
						{
							if (ms21.Position == ms21.Length)
								break;
							instance.FieldT.Add (ProtocolParser.ReadUInt32 (ms21));
						}
					}
		
					break;
				case 22:
					if (instance.FieldU == null)
						instance.FieldU = Theirs.TheirMessage.Deserialize (ProtocolParser.ReadBytes (stream));
					else
						Theirs.TheirMessage.Deserialize (ProtocolParser.ReadBytes (stream), instance.FieldU);
					break;
				case 23:
					instance.FieldV.Add (Theirs.TheirMessage.Deserialize (ProtocolParser.ReadBytes (stream)));
		
					break;
				default:
					ProtocolParser.SkipKey (stream, key);
					break;
				}
			}
			
			return instance;
		}
		
		public static Yours.MyMessageV2 Read (byte[] buffer, Yours.MyMessageV2 instance)
		{
			using (MemoryStream ms = new MemoryStream(buffer))
				Deserialize (ms, instance);
			return instance;
		}
	
		public static void Serialize (Stream stream, MyMessageV2 instance)
		{
			BinaryWriter bw = new BinaryWriter(stream);
			ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (1, Wire.Varint));
			ProtocolParser.WriteUInt32 (stream, (uint)instance.FieldA);
			ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (2, Wire.Fixed64));
			bw.Write (instance.FieldB);
			ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (3, Wire.Fixed32));
			bw.Write (instance.FieldC);
			ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (4, Wire.Varint));
			ProtocolParser.WriteUInt32 (stream, (uint)instance.FieldD);
			ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (5, Wire.Varint));
			ProtocolParser.WriteUInt64 (stream, (ulong)instance.FieldE);
			ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (6, Wire.Varint));
			ProtocolParser.WriteUInt32 (stream, instance.FieldF);
			ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (7, Wire.Varint));
			ProtocolParser.WriteUInt64 (stream, instance.FieldG);
			ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (8, Wire.Varint));
			ProtocolParser.WriteSInt32 (stream, instance.FieldH);
			ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (9, Wire.Varint));
			ProtocolParser.WriteSInt64 (stream, instance.FieldI);
			ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (10, Wire.Fixed32));
			bw.Write (instance.FieldJ);
			ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (11, Wire.Fixed64));
			bw.Write (instance.FieldK);
			ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (12, Wire.Fixed32));
			bw.Write (instance.FieldL);
			ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (13, Wire.Fixed64));
			bw.Write (instance.FieldM);
			ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (14, Wire.Varint));
			ProtocolParser.WriteBool (stream, instance.FieldN);
			if (instance.FieldO == null)
				throw new ArgumentNullException ("FieldO", "Required by proto specification.");
			ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (15, Wire.LengthDelimited));
			ProtocolParser.WriteString (stream, instance.FieldO);
			if (instance.FieldP == null)
				throw new ArgumentNullException ("FieldP", "Required by proto specification.");
			ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (16, Wire.LengthDelimited));
			ProtocolParser.WriteBytes (stream, instance.FieldP);
			ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (17, Wire.Varint));
			ProtocolParser.WriteUInt32 (stream, (uint)instance.FieldQ);
			if (instance.FieldR != Yours.MyMessageV2.MyEnum.ETest2) {
				ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (18, Wire.Varint));
				ProtocolParser.WriteUInt32 (stream, (uint)instance.FieldR);
			}
			if (instance.Dummy != null) {
				ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (19, Wire.LengthDelimited));
				ProtocolParser.WriteString (stream, instance.Dummy);
			}
			if (instance.FieldS != null) {
				foreach (uint i20 in instance.FieldS) {
					ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (20, Wire.Varint));
					ProtocolParser.WriteUInt32 (stream, i20);
			
				}
			}
			if (instance.FieldT != null) {
				ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (21, Wire.LengthDelimited));
				using (MemoryStream ms21 = new MemoryStream())
				{	
					foreach (uint i21 in instance.FieldT) {
						ProtocolParser.WriteUInt32 (ms21, i21);
			
					}
					ProtocolParser.WriteBytes (stream, ms21.ToArray ());
				}
			}
			if (instance.FieldU != null) {
				ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (22, Wire.LengthDelimited));
				using (MemoryStream ms22 = new MemoryStream()) {
					Theirs.TheirMessage.Serialize (ms22, instance.FieldU);
					ProtocolParser.WriteBytes (stream, ms22.ToArray ());
				}
			}
			if (instance.FieldV != null) {
				foreach (Theirs.TheirMessage i23 in instance.FieldV) {
					ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (23, Wire.LengthDelimited));
					using (MemoryStream ms23 = new MemoryStream()) {
						Theirs.TheirMessage.Serialize (ms23, i23);
						ProtocolParser.WriteBytes (stream, ms23.ToArray ());
					}
			
				}
			}
		}
		
		public static byte[] SerializeToBytes (MyMessageV2 instance)
		{
			using (MemoryStream ms = new MemoryStream()) {
				Serialize (ms, instance);
				return ms.ToArray ();
			}
		}
	}
	

}
namespace Local
{
	internal partial class LocalFeatures
	{
		internal static LocalFeatures Deserialize (Stream stream)
		{
			LocalFeatures instance = new LocalFeatures ();
			Deserialize (stream, instance);
			return instance;
		}
		
		internal static LocalFeatures Deserialize (byte[] buffer)
		{
			using (MemoryStream ms = new MemoryStream(buffer))
				return Deserialize (ms);
		}
		
		internal static T Deserialize<T> (Stream stream) where T : Local.LocalFeatures, new()
		{
			T instance = new T ();
			Deserialize (stream, instance);
			return instance;
		}
		
		internal static T Deserialize<T> (byte[] buffer) where T : Local.LocalFeatures, new()
		{
			T instance = new T ();
			Deserialize (buffer, instance);
			return instance;
		}
		
		internal static Local.LocalFeatures Deserialize (byte[] buffer, Local.LocalFeatures instance)
		{
			using (MemoryStream ms = new MemoryStream(buffer))
				Deserialize (ms, instance);
			return instance;
		}
		
		internal static Local.LocalFeatures Deserialize (Stream stream, Local.LocalFeatures instance)
		{
			BinaryReader br = new BinaryReader (stream);
			while (true) {
				ProtocolBuffers.Key key = null;
				int keyByte = stream.ReadByte ();
				if (keyByte == -1)
					break;
				//Optimized reading of known fields with field ID < 16
				switch (keyByte) {
				case 8: //Field 1 Varint
					instance.Uptime = new TimeSpan((long)ProtocolParser.ReadUInt64 (stream));
					break;
				case 16: //Field 2 Varint
					instance.DueDate = new DateTime((long)ProtocolParser.ReadUInt64 (stream));
					break;
				case 25: //Field 3 Fixed64
					instance.Amount = br.ReadDouble ();
					break;
				case 34: //Field 4 LengthDelimited
					instance.Denial = ProtocolParser.ReadString (stream);
					break;
				case 42: //Field 5 LengthDelimited
					instance.Secret = ProtocolParser.ReadString (stream);
					break;
				case 50: //Field 6 LengthDelimited
					instance.Internal = ProtocolParser.ReadString (stream);
					break;
				case 58: //Field 7 LengthDelimited
					instance.PR = ProtocolParser.ReadString (stream);
					break;
				case 66: //Field 8 LengthDelimited
					Mine.MyMessageV1.Deserialize (ProtocolParser.ReadBytes (stream), instance.TestingReadOnly);
					break;
				default:
					key = ProtocolParser.ReadKey ((byte)keyByte, stream);
					break;
				}
		
				if (key == null)
					continue;
		
				//Reading field ID > 16 and unknown field ID/wire type combinations
				switch (key.Field) {
				case 0:
					throw new InvalidDataException ("Invalid field id: 0, something went wrong in the stream");
				default:
					if(instance.PreservedFields == null)
						instance.PreservedFields = new List<KeyValue>();
					instance.PreservedFields.Add(new KeyValue(key, ProtocolParser.ReadValueBytes (stream, key)));
					break;
				}
			}
			
			instance.AfterDeserialize ();
			return instance;
		}
		
		internal static Local.LocalFeatures Read (byte[] buffer, Local.LocalFeatures instance)
		{
			using (MemoryStream ms = new MemoryStream(buffer))
				Deserialize (ms, instance);
			return instance;
		}
	
		internal static void Serialize (Stream stream, LocalFeatures instance)
		{
			instance.BeforeSerialize ();
		
			BinaryWriter bw = new BinaryWriter(stream);
			ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (1, Wire.Varint));
			ProtocolParser.WriteUInt64 (stream, (ulong)instance.Uptime.Ticks);
			ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (2, Wire.Varint));
			ProtocolParser.WriteUInt64 (stream, (ulong)instance.DueDate.Ticks);
			ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (3, Wire.Fixed64));
			bw.Write (instance.Amount);
			if (instance.Denial != null) {
				ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (4, Wire.LengthDelimited));
				ProtocolParser.WriteString (stream, instance.Denial);
			}
			if (instance.Secret != null) {
				ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (5, Wire.LengthDelimited));
				ProtocolParser.WriteString (stream, instance.Secret);
			}
			if (instance.Internal != null) {
				ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (6, Wire.LengthDelimited));
				ProtocolParser.WriteString (stream, instance.Internal);
			}
			if (instance.PR != null) {
				ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (7, Wire.LengthDelimited));
				ProtocolParser.WriteString (stream, instance.PR);
			}
			if (instance.TestingReadOnly != null) {
				ProtocolParser.WriteKey (stream, new ProtocolBuffers.Key (8, Wire.LengthDelimited));
				using (MemoryStream ms8 = new MemoryStream()) {
					Mine.MyMessageV1.Serialize (ms8, instance.TestingReadOnly);
					ProtocolParser.WriteBytes (stream, ms8.ToArray ());
				}
			}
			if (instance.PreservedFields != null)
			{
				foreach (KeyValue kv in instance.PreservedFields)	{
					ProtocolParser.WriteKey (stream, kv.Key);
					stream.Write (kv.Value, 0, kv.Value.Length);
				}
			}
		}
		
		internal static byte[] SerializeToBytes (LocalFeatures instance)
		{
			using (MemoryStream ms = new MemoryStream()) {
				Serialize (ms, instance);
				return ms.ToArray ();
			}
		}
	}
	

}

namespace ProtocolBuffers
{
	public static partial class Serializer
	{
		public static Personal.Person Read (Stream stream, Personal.Person instance)
		{
			return Personal.Person.Deserialize (stream, instance);
		}
		
		public static Personal.Person Read (byte[] buffer, Personal.Person instance)
		{
			using (MemoryStream ms = new MemoryStream(buffer))
				Personal.Person.Deserialize (ms, instance);
			return instance;
		}
		
		public static void Write (Stream stream, Personal.Person instance)
		{
			Personal.Person.Serialize (stream, instance);
		}
		
		public static Personal.Person.PhoneNumber Read (Stream stream, Personal.Person.PhoneNumber instance)
		{
			return Personal.Person.PhoneNumber.Deserialize (stream, instance);
		}
		
		public static Personal.Person.PhoneNumber Read (byte[] buffer, Personal.Person.PhoneNumber instance)
		{
			using (MemoryStream ms = new MemoryStream(buffer))
				Personal.Person.PhoneNumber.Deserialize (ms, instance);
			return instance;
		}
		
		public static void Write (Stream stream, Personal.Person.PhoneNumber instance)
		{
			Personal.Person.PhoneNumber.Serialize (stream, instance);
		}

		public static ExampleNamespaceA.AddressBook Read (Stream stream, ExampleNamespaceA.AddressBook instance)
		{
			return ExampleNamespaceA.AddressBook.Deserialize (stream, instance);
		}
		
		public static ExampleNamespaceA.AddressBook Read (byte[] buffer, ExampleNamespaceA.AddressBook instance)
		{
			using (MemoryStream ms = new MemoryStream(buffer))
				ExampleNamespaceA.AddressBook.Deserialize (ms, instance);
			return instance;
		}
		
		public static void Write (Stream stream, ExampleNamespaceA.AddressBook instance)
		{
			ExampleNamespaceA.AddressBook.Serialize (stream, instance);
		}

		public static Mine.MyMessageV1 Read (Stream stream, Mine.MyMessageV1 instance)
		{
			return Mine.MyMessageV1.Deserialize (stream, instance);
		}
		
		public static Mine.MyMessageV1 Read (byte[] buffer, Mine.MyMessageV1 instance)
		{
			using (MemoryStream ms = new MemoryStream(buffer))
				Mine.MyMessageV1.Deserialize (ms, instance);
			return instance;
		}
		
		public static void Write (Stream stream, Mine.MyMessageV1 instance)
		{
			Mine.MyMessageV1.Serialize (stream, instance);
		}

		public static Yours.MyMessageV2 Read (Stream stream, Yours.MyMessageV2 instance)
		{
			return Yours.MyMessageV2.Deserialize (stream, instance);
		}
		
		public static Yours.MyMessageV2 Read (byte[] buffer, Yours.MyMessageV2 instance)
		{
			using (MemoryStream ms = new MemoryStream(buffer))
				Yours.MyMessageV2.Deserialize (ms, instance);
			return instance;
		}
		
		public static void Write (Stream stream, Yours.MyMessageV2 instance)
		{
			Yours.MyMessageV2.Serialize (stream, instance);
		}

		internal static Local.LocalFeatures Read (Stream stream, Local.LocalFeatures instance)
		{
			return Local.LocalFeatures.Deserialize (stream, instance);
		}
		
		internal static Local.LocalFeatures Read (byte[] buffer, Local.LocalFeatures instance)
		{
			using (MemoryStream ms = new MemoryStream(buffer))
				Local.LocalFeatures.Deserialize (ms, instance);
			return instance;
		}
		
		internal static void Write (Stream stream, Local.LocalFeatures instance)
		{
			Local.LocalFeatures.Serialize (stream, instance);
		}


	}
}