//
// CoreFoundation.cs
//
// Author:
//       iain holmes <iain@xamarin.com>
//
// Copyright (c) 2015 Xamarin, Inc
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.IO;
using MonoDevelop.MacInterop;
using NUnit.Framework;

namespace MacPlatform.Tests
{
	public class CoreFoundationTests
	{
		[Test]
		public static void TestString ()
		{
			string test = "Test string";
			IntPtr testString = MonoDevelop.MacInterop.CoreFoundation.CreateString ("Test string");

			Assert.AreEqual (MonoDevelop.MacInterop.CoreFoundation.FetchString (testString), test);

			MonoDevelop.MacInterop.CoreFoundation.Release (testString);
		}

		[Test]
		public static void TestURL ()
		{
			string test = "http://www.monodevelop.org";
			IntPtr testUrl = MonoDevelop.MacInterop.CoreFoundation.CreatePathUrl (test);

			Assert.AreEqual (MonoDevelop.MacInterop.CoreFoundation.UrlToPath (testUrl), test);

			MonoDevelop.MacInterop.CoreFoundation.Release (testUrl);
		}

		[Test]
		public static void TestApplicationUrls ()
		{
			string dir = nameof (TestApplicationUrl);
			string test = Path.Combine (dir, "Info.plist");
			using (var helper = new PListHelper (dir, test)) {
				string [] results = MonoDevelop.MacInterop.CoreFoundation.GetApplicationUrls (test, MonoDevelop.MacInterop.CoreFoundation.LSRolesMask.All);

				Assert.Greater (results.Length, 0);
			}
		}

		[Test]
		public static void TestApplicationUrl ()
		{
			string dir = nameof (TestApplicationUrl);
			string test = Path.Combine (dir, "Info.plist");
			using (var helper = new PListHelper (dir, test)) {
				string result = MonoDevelop.MacInterop.CoreFoundation.GetApplicationUrl (test, MonoDevelop.MacInterop.CoreFoundation.LSRolesMask.All);

				Assert.NotNull (result);
			}
		}

		class PListHelper : IDisposable
		{
			static string plistFile = Path.GetFullPath (
				Path.Combine (
					Path.GetDirectoryName (typeof (PListHelper).Assembly.Location),
					"..",
					"MacOSX",
					"Info.plist.in"
				)
			);

			readonly string dir;
			public PListHelper (string dir, string path)
			{
				this.dir = dir;

				Directory.CreateDirectory (dir);
				File.Copy (plistFile, path, true);
			}

			public void Dispose ()
			{
				if (Directory.Exists (dir))
					Directory.Delete (dir, true);
			}
		}
	}
}

