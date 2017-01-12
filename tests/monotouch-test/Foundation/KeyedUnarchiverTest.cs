//
// Unit tests for NSKeyedUnarchiver
//
// Authors:
//	Rolf Bjarne Kvinge <rolf@xamarin.com>
//
// Copyright 2012 Xamarin Inc. All rights reserved.
//

using System;
using System.Net;
using System.IO;

#if XAMCORE_2_0
using Foundation;
using ObjCRuntime;
#if MONOMAC
using AppKit;
using PlatformException=Foundation.ObjCException;
#else
using UIKit;
using PlatformException=Foundation.MonoTouchException;
#endif
#else
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using PlatformException=MonoTouch.Foundation.MonoTouchException;
#endif

using NUnit.Framework;

namespace MonoTouchFixtures.Foundation {
	
	[TestFixture]
	[Preserve (AllMembers = true)]
	public class KeyedUnarchiverTest {

		[Test]
		public void Exceptions ()
		{
			var data = NSData.FromString ("dummy string");
			if (TestRuntime.CheckXcodeVersion (7, 0)) {
				// iOS9 does not throw if it cannot get correct data, it simply returns null (much better)
				Assert.Null (NSKeyedUnarchiver.UnarchiveFile (Path.Combine (NSBundle.MainBundle.ResourcePath, "basn3p08.png")), "UnarchiveFile");
				Assert.Null (NSKeyedUnarchiver.UnarchiveObject (data), "UnarchiveObject");
			} else {
				Assert.Throws<PlatformException> (() => NSKeyedUnarchiver.UnarchiveFile (Path.Combine (NSBundle.MainBundle.ResourcePath, "basn3p08.png")), "UnarchiveFile");
				Assert.Throws<PlatformException> (() => NSKeyedUnarchiver.UnarchiveObject (data), "UnarchiveObject");
			}
		}
	}
}
