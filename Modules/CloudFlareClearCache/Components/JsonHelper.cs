﻿/*
MIT License

Copyright (c) Upendo Ventures, LLC

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
using System;
using System.IO;
using System.Web.Script.Serialization;

namespace Upendo.Modules.CloudFlareClearCache.Components
{
    public static class JsonHelper
    {
        private static int MAX_LENGTH = Int32.MaxValue;

        public static string ObjectToJson(this object target)
        {
            var ser = new JavaScriptSerializer();

            ser.MaxJsonLength = MAX_LENGTH;

            return ser.Serialize(target);
        }

        public static T ObjectFromJson<T>(string json)
        {
            if (string.IsNullOrEmpty(json))
                return default(T);

            var ser = new JavaScriptSerializer();

            ser.MaxJsonLength = MAX_LENGTH;

            return ser.Deserialize<T>(json);
        }

        public static T ObjectFromJson<T>(Stream stream)
        {
            var rdr = new StreamReader(stream);

            return ObjectFromJson<T>(rdr.ReadToEnd());
        }
    }
}