using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

using UnityEngine;

	public static class JsonUtility {
	
		public static JsonValue ToObject(string val){
			
			return new JsonValue((new JsonParser(val)).Decode() );
		}
	
	    public static JsonValue ToObjectFromJS(string val){
	        
	        return ToObject(UnEscapeJavascriptString(val));
	    }
	
		public static string ToString(JsonValue json){
			
	        return JsonWriter.Write(json);
		}
	
		public static string ToStringForJS(JsonValue json){
			return EscapeJavascriptString(ToString(json));
		}
	
		public static string EscapeJavascriptString(string jsonString){
			if (String.IsNullOrEmpty(jsonString))
	            return jsonString;
	
	        System.Text.StringBuilder builder = new System.Text.StringBuilder();
	
	        // builder.Append("\"");
	        char[] charArray = jsonString.ToCharArray();
	        for (int i = 0; i < charArray.Length; i++){
	            char c = charArray[i];
	            if (c == '"')
	                builder.Append("\\\"");
	            else if (c == '\\')
	                builder.Append("\\\\");
	            else if (c == '\b')
	                builder.Append("\\b");
	            else if (c == '\f')
	                builder.Append("\\f");
	            else if (c == '\n')
	                builder.Append("\\n");
	            else if (c == '\r')
	                builder.Append("\\r");
	            else if (c == '\t')
	                builder.Append("\\t");
	            else
	                builder.Append(c);
	        }
	        // builder.Append("\"");
	
	        return builder.ToString();
		}

		public static int GetIntOr(JsonValue jsonData, string key1, string key2 ){
			if (!jsonData.Get(key1).IsNull() ){
				return jsonData.Get(key1).GetInt();
			}

			return jsonData.Get(key2).GetInt();
		}
	
		public static string UnEscapeJavascriptString(string jsonString){
	        
	        if (String.IsNullOrEmpty(jsonString))
	            return jsonString;
	
	        System.Text.StringBuilder sb = new System.Text.StringBuilder();
	        char c;
	
	        for (int i = 0; i < jsonString.Length; )
	        {
	            c = jsonString[i++];
	
	            if (c == '\\')
	            {
	                int remainingLength = jsonString.Length - i;
	                if (remainingLength >= 2)
	                {
	                    char lookahead = jsonString[i];
	                    if (lookahead == '\\')
	                    {
	                        sb.Append('\\');
	                        ++i;
	                    }
	                    else if (lookahead == '"')
	                    {
	                        sb.Append("\"");
	                        ++i;
	                    }
	                    else if (lookahead == 't')
	                    {
	                        sb.Append('\t');
	                        ++i;
	                    }
	                    else if (lookahead == 'b')
	                    {
	                        sb.Append('\b');
	                        ++i;
	                    }
	                    else if (lookahead == 'n')
	                    {
	                        sb.Append('\n');
	                        ++i;
	                    }
	                    else if (lookahead == 'r')
	                    {
	                        sb.Append('\r');
	                        ++i;
	                    }else if (lookahead == 'u'){
	                        char[] hex = new char[4];
	
	                        for (int m=0; m< 4; m++) {
	                            hex[m] = jsonString[i+m+1];
	                        }
	
	                        sb.Append((char) Convert.ToInt32(new string(hex), 16));
	                        i++; 
	                        i += 4;
	                    }
	                }
	            }
	            else
	            {
	                sb.Append(c);
	            }
	        }
	        //Debug.Log(sb.ToString() );
	        return sb.ToString();
	    }
	
	
	    public static int GetInt(JsonValue jsonData, string key, int defaultVal) {
	        if(jsonData.Get(key).IsNull()){
	            return defaultVal;
	        }
	        return jsonData.Get(key).GetInt();
	    }
	
	    public static float GetFloat(JsonValue jsonData, string key, float defaultVal) {
	        if(jsonData.Get(key).IsNull()){
	            return defaultVal;
	        }
	        return jsonData.Get(key).GetFloat();
	    }
	
	    public static long GetLong(JsonValue jsonData, string key, long defaultVal) {
	        if(jsonData.Get(key).IsNull()){
	            return defaultVal;
	        }
	        return jsonData.Get(key).GetLong();
	    }
	
	    public static double GetDouble(JsonValue jsonData, string key, double defaultVal) {
	        if(jsonData.Get(key).IsNull()){
	            return defaultVal;
	        }
	        return jsonData.Get(key).GetDouble();
	    }
	
	    public static string GetString(JsonValue jsonData, string key, string defaultVal) {
	        if(jsonData.Get(key).IsNull()){
	            return defaultVal;
	        }
	        return jsonData.Get(key).GetString();
	    }
	
	    public static bool GetBoolean(JsonValue jsonData, string key, bool defaultVal) {
	        if(jsonData.Get(key).IsNull()){
	            return defaultVal;
	        }
	        return jsonData.Get(key).GetBoolean();
	    }
	
		public static void CopyJsonToStringList(JsonValue jsonData, List<string> intList){
	        intList.Clear();
	        if (jsonData == null){
	            return;
	        }
	        if (jsonData.IsNull()){
	            return;
	        }
	
	        for (int index = 0; index<jsonData.GetLength(); index++){
			intList.Add(jsonData.Get(index).GetString());
	        }
	
	    }
		public static void CopyJsonToIntList(JsonValue jsonData, List<int> intList){
	        intList.Clear();
	        if (jsonData == null){
	            return;
	        }
	        if (jsonData.IsNull()){
	            return;
	        }
	
	        for (int index = 0; index<jsonData.GetLength(); index++){
	            intList.Add(jsonData.Get(index).GetInt());
	        }
	
	    }
	}
