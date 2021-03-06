﻿namespace IROM.Util
{
	using System;
	using System.Collections.Generic;
	using System.Reflection;
	using System.IO;
	using IROM.Dynamix;
	
	/// <summary>
	/// Helper class that handles automatic configuration management.
	/// </summary>
	public static class AutoConfig
	{	
		/// <summary>
		/// Tries to convert the specified string representation of a Type to its object equivalent. A return value indicates whether the conversion succeeded or failed.
		/// </summary>
		/// <param name="value">A string containing the value to convert.</param>
		/// <param name="result">When this method returns, if the conversion succeeded, contains the parsed value. 
		/// If the conversion failed, undefined. The conversion fails if value is null or is not a valid string representation for the object type.</param>
		/// <returns>true if value was converted successfully; otherwise, false.</returns>
		public delegate bool Parser<T>(string value, out T result);
		/// <summary>
		/// Converts the given object to a string.
		/// </summary>
		/// <param name="value">The object.</param>
		/// <returns>The serialized version.</returns>
		public delegate string Serializer<T>(T value);
		
		//binding flags for all members
		private const BindingFlags EVERYTHING = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static;
		/// <summary>
		/// Group of configurable values for each type.
		/// </summary>
		private static Dictionary<Type, Dictionary<string, Access>> fieldLookup = new Dictionary<Type, Dictionary<string, Access>>();
		//parsers and serializers for each type
		private static Dictionary<Type, Parser<object>> parsers = new Dictionary<Type, Parser<object>>();
		private static Dictionary<Type, Serializer<object>> serializers = new Dictionary<Type, Serializer<object>>();
		
		/// <summary>
		/// Sets a parser for configuration.
		/// </summary>
		/// <param name="parser">The parsing method.</param>
		public static void SetParser<T>(Parser<T> parser)
		{
			parsers[typeof(T)] = ((string str, out object result) => 
			{
			    T typedResult;
				bool worked = parser(str, out typedResult);
				result = typedResult as object;
				return worked;
			});
		}
		
		/// <summary>
		/// Sets a serializer for configuration. If one is missing, uses ToString().
		/// </summary>
		/// <param name="serializer">The serializing method.</param>
		public static void SetSerializer<T>(Serializer<T> serializer)
		{
			serializers[typeof(T)] = (value => serializer((T)value));
		}
		
		static AutoConfig()
		{
			//set default parsers
			SetParser<bool>(bool.TryParse);
			SetParser<byte>(byte.TryParse);
			SetParser<sbyte>(sbyte.TryParse);
			SetParser<ushort>(ushort.TryParse);
			SetParser<short>(short.TryParse);
			SetParser<uint>(uint.TryParse);
			SetParser<int>(int.TryParse);
			SetParser<ulong>(ulong.TryParse);
			SetParser<long>(long.TryParse);
			SetParser<float>(float.TryParse);
			SetParser<double>(double.TryParse);
			SetParser<decimal>(decimal.TryParse);
			SetParser<DateTime>(DateTime.TryParse);
			SetParser<char>(char.TryParse);
			SetParser<string>((string v, out string r) => 
	        {
	          	r = v;
	          	return true;
	        });
		}
		
		/// <summary>
		/// Discovers all configurable fields and properties in the given <see cref="Type"/>.
		/// </summary>
		/// <param name="type">The type.</param>
		private static void Discover(Type type)
		{
			if(!fieldLookup.ContainsKey(type))
			{
				Dictionary<string, Access> fields = new Dictionary<string, Access>();
				foreach(FieldInfo info in type.GetFields(EVERYTHING))
				{
					ConfigAttribute attr = info.GetCustomAttribute(typeof(ConfigAttribute)) as ConfigAttribute;
					if(attr != null)
					{
						if(fields.ContainsKey(attr.Tag))
						{
							throw new Exception("Duplicate Config tag " + attr.Tag + " on members " + type.Name + "." + info.Name + " and " + type.Name + "." + fields[attr.Tag].Info.GetName());
						}
						fields[attr.Tag] = new Access(info, attr.FileTag);
					}
				}
				foreach(PropertyInfo info in type.GetProperties(EVERYTHING))
				{
					ConfigAttribute attr = info.GetCustomAttribute(typeof(ConfigAttribute)) as ConfigAttribute;
					if(attr != null)
					{
						if(fields.ContainsKey(attr.Tag))
						{
							throw new Exception("Duplicate Config tag " + attr.Tag + " on members " + type.Name + "." + info.Name + " and " + type.Name + "." + fields[attr.Tag].Info.GetName());
						}
						fields[attr.Tag] = new Access(info, attr.FileTag);
					}
				}
				fieldLookup[type] = fields;
			}
		}
		
		public static bool Load(Type type, object instance, string path, string prefix, string fileTag, bool isReadonly)
		{
			//assume no fields loaded
			bool fieldModified = false;
			//init
			Discover(type);
			if(File.Exists(path))
			{
				Dictionary<string, Access> fields = fieldLookup[type];
				using(StreamReader input = new StreamReader(path))
				{
					//for every line
					string line;
					while((line = input.ReadLine()) != null)
					{
						string[] parts = line.Split(new []{':'}, 2);
						//trim parts
						for(int i = 0; i < parts.Length; i++) parts[i] = parts[i].Trim();
						if(prefix != null)
						{
							if(parts[0].StartsWith(prefix, StringComparison.Ordinal))
							{
								parts[0] = parts[0].Substring(prefix.Length);
							}else
							{
								continue;
							}
						}
						
						Access config;
						//if exists and right scope (static or instance) and right file
						if(fields.TryGetValue(parts[0], out config) && 
						   ((instance == null) == config.Info.IsStatic()) && 
						   (fileTag == config.FileID))
						{
							Parser<object> parser;
							if(parsers.TryGetValue(config.GetDataType(), out parser))
							{
								//parse string
								object result;
								parser(parts[1], out result);
								//set value
								config.Set(instance, result);
								//success
								fieldModified = true;
							}else
							{
								throw new Exception("Type " + config.GetDataType() + " missing a configuration parser. Please see AutoConfig.SetParser.");
							}
						}
					}
				}
			}
			if(!isReadonly) Save(type, instance, path, prefix, fileTag);
			return fieldModified;
		}
		
		public static void Save(Type type, object instance, string path, string prefix, string fileTag)
		{
			//init
			Discover(type);
			Dictionary<string, Access> fields = fieldLookup[type];
			using(StreamWriter output = new StreamWriter(path))
			{
				foreach(var field in fields)
				{
					//if right scope (static or instance) and right file
					if((instance == null) == field.Value.Info.IsStatic() && 
					   (fileTag == field.Value.FileID))
					{
						Serializer<object> serializer;
						serializers.TryGetValue(field.Value.GetDataType(), out serializer);
						if(serializer == null)
						{
							serializer = (o => o == null ? "null" : o.ToString());
						}
						string key = field.Key;
						if(prefix != null)
						{
							key = prefix + key;
						}
						string result = serializer(field.Value.Get(instance));
						output.WriteLine(key + ": " + result);
					}
				}
			}
		}
		
		/// <summary>
		/// Loads configuration for the given obj from the given path. For static configs, obj should be the <see cref="Type"/>
		/// </summary>
		/// <param name="obj">The obj.</param>
		/// <param name="path">The path.</param>
		/// <param name="prefix">The prefix for all fields.</param>
		/// <param name="fileTag">The file tag for this configuration, limits which fields are configured.</param>
		/// <param name="isReadonly">True if the file should not be created or updated.</param>
		/// <returns>True if at least one field was loaded.</returns>
		public static bool LoadConfig(this object obj, string path, string prefix = null, string fileTag = null, bool isReadonly = false)
		{
			if(prefix != null && (prefix.Contains(":") || prefix.Contains("\n")))
			{
				throw new Exception("Config prefixes cannot contain colons or new lines.");
			}
			if(obj is Type)
			{
				return Load((Type)obj, null, path, prefix, fileTag, isReadonly);
			}else
			{
				return Load(obj.GetType(), obj, path, prefix, fileTag, isReadonly);
			}
		}
		
		/// <summary>
		/// Saves configuration for the given obj from the given path. For static configs, obj should be the <see cref="Type"/>
		/// </summary>
		/// <param name="obj">The obj.</param>
		/// <param name="path">The path.</param>
		/// <param name="prefix">The prefix for all fields, limits which fields are configured.</param>
		/// <param name="fileTag">The file tag for this configuration.</param>
		public static void SaveConfig(this object obj, string path, string prefix = null, string fileTag = null)
		{
			if(prefix != null && (prefix.Contains(":") || prefix.Contains("\n")))
			{
				throw new Exception("Config prefixes cannot contain colons or new lines.");
			}
			if(obj is Type)
			{
				Save((Type)obj, null, path, prefix, fileTag);
			}else
			{
				Save(obj.GetType(), obj, path, prefix, fileTag);
			}
		}
		
		private class Access
		{
			public DataInfo Info;
			public DataInfo SubInfo;
			public string FileID;
			
			public Access(DataInfo info, string id)
			{
				Info = info;
				if(info.GetDataType().IsGenericType && (typeof(Dynx<>) == info.GetDataType().GetGenericTypeDefinition()))
				{
					SubInfo = info.GetDataType().GetProperty("Value");
				}
				FileID = id;
			}
			
			public Type GetDataType()
			{
				if(SubInfo != null)
				{
					return SubInfo.GetDataType();
				}else
				{
					return Info.GetDataType();
				}
			}
			
			public object Get(object obj)
			{
				if(SubInfo != null)
				{
					return SubInfo.GetValue(Info.GetValue(obj));
				}else
				{
					return Info.GetValue(obj);
				}
			}
			
			public void Set(object obj, object value)
			{
				if(SubInfo != null)
				{
					SubInfo.SetValue(Info.GetValue(obj), value);
				}else
				{
					Info.SetValue(obj, value);
				}
			}
		}
	}
}
