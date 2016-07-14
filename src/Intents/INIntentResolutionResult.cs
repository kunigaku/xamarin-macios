﻿//
// INIntentResolutionResult Generic variant
//
// Authors:
//	Alex Soto  <alexsoto@microsoft.com>
//
// Copyright 2016 Xamarin Inc. All rights reserved.
//

#if XAMCORE_2_0
using System;
using XamCore.Foundation;
using XamCore.ObjCRuntime;

namespace XamCore.Intents {
	[Register ("INIntentResolutionResult", SkipRegistration = true)]
	public sealed partial class INIntentResolutionResult<ObjectType> : INIntentResolutionResult
		where ObjectType : class, INativeObject 
	{
		internal INIntentResolutionResult (IntPtr handle) : base (handle)
		{
		}
	}
}
#endif // XAMCORE_2_0
