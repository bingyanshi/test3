﻿using System;

namespace Xamarin.ProjectTools
{
	public static class KnownPackages
	{
		public static Package AndroidSupportV4Kitkat = new Package () {
			Id = "Xamarin.Android.Support.v4",
			Version = "20.0.0.4",
			TargetFramework = "MonoAndroid4487",
			References = {
				new BuildItem.Reference ("Xamarin.Android.Support.v4") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Android.Support.v4.20.0.0.4\\lib\\MonoAndroid32\\Xamarin.Android.Support.v4.dll" }
			}
		};
		public static Package AndroidSupportV4_21_0_3_0 = new Package () {
			Id = "Xamarin.Android.Support.v4",
			Version = "21.0.3.0",
			TargetFramework = "MonoAndroid10",
			References = {
				new BuildItem.Reference ("Xamarin.Android.Support.v4") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Android.Support.v4.21.0.3.0\\lib\\MonoAndroid10\\Xamarin.Android.Support.v4.dll" }
			}
		};
		public static Package AndroidSupportV4_22_1_1_1 = new Package () {
			Id = "Xamarin.Android.Support.v4",
			Version = "22.1.1.1",
			TargetFramework = "MonoAndroid10",
			References = {
				new BuildItem.Reference ("Xamarin.Android.Support.v4") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Android.Support.v4.22.1.1.1\\lib\\MonoAndroid403\\Xamarin.Android.Support.v4.dll" }
			}
		};
		public static Package AndroidSupportV4_23_1_1_0 = new Package () {
			Id = "Xamarin.Android.Support.v4",
			Version = "23.1.1.0",
			TargetFramework = "MonoAndroid10",
			References = {
				new BuildItem.Reference ("Xamarin.Android.Support.v4") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Android.Support.v4.23.1.1.0\\lib\\MonoAndroid403\\Xamarin.Android.Support.v4.dll" }
			}
		};
		public static Package AndroidSupportV4_25_4_0_1 = new Package () {
			Id = "Xamarin.Android.Support.v4",
			Version = "25.4.0.1",
			TargetFramework = "MonoAndroid70",
			References = {
				new BuildItem.Reference ("Xamarin.Android.Support.v4") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Android.Support.v4.25.4.0.1\\lib\\MonoAndroid70\\Xamarin.Android.Support.v4.dll" }
			}
		};
		public static Package AndroidSupportV4Beta = new Package () {
			Id = "Xamarin.Android.Support.v4",
			Version = "21.0.0.0-beta1",
			TargetFramework = "MonoAndroid4487",
			References = {
				new BuildItem.Reference ("Xamarin.Android.Support.v4") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Android.Support.v4.21.0.0.0-beta1\\lib\\MonoAndroid\\Xamarin.Android.Support.v4.dll" }
			}
		};
		public static Package AndroidSupportV13Kitkat = new Package () {
			Id = "Xamarin.Android.Support.v13",
			Version = "20.0.0.4",
			TargetFramework = "MonoAndroid4487",
			References = {
				new BuildItem.Reference ("Xamarin.Android.Support.v13") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Android.Support.v13.20.0.0.4\\lib\\MonoAndroid32\\Xamarin.Android.Support.v13.dll" }
				}
		};
		public static Package AndroidSupportV13Beta = new Package () {
			Id = "Xamarin.Android.Support.v13",
			Version = "21.0.0.0-beta1",
			TargetFramework = "MonoAndroid4487",
			References = {
				new BuildItem.Reference ("Xamarin.Android.Support.v13") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Android.Support.v13.20.0.0.4\\lib\\MonoAndroid32\\Xamarin.Android.Support.v13.dll" }
			}
		};
		public static Package AndroidSupportV13_21_0_3_0 = new Package () {
			Id = "Xamarin.Android.Support.v13",
			Version = "21.0.3.0",
			TargetFramework = "MonoAndroid10",
			References = {
				new BuildItem.Reference ("Xamarin.Android.Support.v13") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Android.Support.v13.21.0.3.0\\lib\\MonoAndroid10\\Xamarin.Android.Support.v4.dll" }
			}
		};
		public static Package AndroidWear = new Package () {
			Id = "Xamarin.Android.Wear",
			Version = "1.0.0-preview7",
			TargetFramework = "MonoAndroid4487",
			References = {
				new BuildItem.Reference ("Xamarin.Android.Wearable") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Android.Wear.1.0.0-preview7\\lib\\MonoAndroid10\\Xamarin.Android.Wearable.dll" }
				}
		};
		public static Package SupportV7RecyclerView = new Package {
			Id = "Xamarin.Android.Support.v7.RecyclerView",
			Version = "21.0.0.0-beta1",
			TargetFramework = "MonoAndroid523",
			References = {
				new BuildItem.Reference ("Xamarin.Android.Support.V7.RecyclerView") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Android.Support.v7.RecyclerView.21.0.0.0-beta1\\lib\\MonoAndroid\\Xamarin.Android.Support.v7.RecyclerView.dll" }
				}
		};
		public static Package SupportV7CardView = new Package {
			Id = "Xamarin.Android.Support.v7.Cardview",
			Version = "21.0.3.0",
			TargetFramework = "MonoAndroid523",
			References = {
				new BuildItem.Reference ("Xamarin.Android.Support.v7.CardView") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Android.Support.v7.CardView.21.0.3.0\\lib\\MonoAndroid403\\Xamarin.Android.Support.v7.CardView.dll" }
			}
		};
		public static Package SupportV7CardView_24_2_1 = new Package {
			Id = "Xamarin.Android.Support.v7.Cardview",
			Version = "24.2.1",
			TargetFramework = "MonoAndroid70",
			References = {
				new BuildItem.Reference ("Xamarin.Android.Support.v7.CardView") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Android.Support.v7.CardView.24.2.1\\lib\\MonoAndroid70\\Xamarin.Android.Support.v7.CardView.dll" }
			}
		};
		public static Package SupportV7CardView_25_4_0_1 = new Package {
			Id = "Xamarin.Android.Support.v7.Cardview",
			Version = "25.4.0.1",
			TargetFramework = "MonoAndroid70",
			References = {
				new BuildItem.Reference ("Xamarin.Android.Support.v7.CardView") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Android.Support.v7.CardView.25.4.0.1\\lib\\MonoAndroid70\\Xamarin.Android.Support.v7.CardView.dll" }
			}
		};
		public static Package SupportV7AppCompat_21_0_3_0 = new Package {
			Id = "Xamarin.Android.Support.v7.AppCompat",
			Version = "21.0.3.0",
			TargetFramework = "MonoAndroid403",
			References = {
				new BuildItem.Reference ("Xamarin.Android.Support.v7.AppCompat") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Android.Support.v7.AppCompat.21.0.3.0\\lib\\MonoAndroid403\\Xamarin.Android.Support.v7.AppCompat.dll" }
			}
		};
		public static Package SupportV7AppCompat_22_1_1_1 = new Package {
			Id = "Xamarin.Android.Support.v7.AppCompat",
			Version = "22.1.1.1",
			TargetFramework = "MonoAndroid403",
			References = {
				new BuildItem.Reference ("Xamarin.Android.Support.v7.AppCompat") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Android.Support.v7.AppCompat.22.1.1.1\\lib\\MonoAndroid403\\Xamarin.Android.Support.v7.AppCompat.dll" }
			}
		};
		public static Package SupportV7AppCompat_23_1_1_0 = new Package {
			Id = "Xamarin.Android.Support.v7.AppCompat",
			Version = "23.1.1.0",
			TargetFramework = "MonoAndroid403",
			References = {
				new BuildItem.Reference ("Xamarin.Android.Support.v7.AppCompat") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Android.Support.v7.AppCompat.23.1.1.0\\lib\\MonoAndroid403\\Xamarin.Android.Support.v7.AppCompat.dll" }
			}
		};
		public static Package SupportV7AppCompat_25_4_0_1 = new Package {
			Id = "Xamarin.Android.Support.v7.AppCompat",
			Version = "25.4.0.1",
			TargetFramework = "MonoAndroid70",
			References = {
				new BuildItem.Reference ("Xamarin.Android.Support.v7.AppCompat") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Android.Support.v7.AppCompat.25.4.0.1\\lib\\MonoAndroid70\\Xamarin.Android.Support.v7.AppCompat.dll" }
			}
		};
		public static Package SupportCompat_25_4_0_1 = new Package {
			Id = "Xamarin.Android.Support.Compat",
			Version = "25.4.0.1",
			TargetFramework = "MonoAndroid70",
			References = {
				new BuildItem.Reference ("Xamarin.Android.Support.Compat") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Android.Support.Compat.25.4.0.1\\lib\\MonoAndroid70\\Xamarin.Android.Support.Compat.dll" }
			}
		};
		public static Package SupportCoreUI_25_4_0_1 = new Package {
			Id = "Xamarin.Android.Support.Core.UI",
			Version = "25.4.0.1",
			TargetFramework = "MonoAndroid70",
			References = {
				new BuildItem.Reference ("Xamarin.Android.Support.Core.UI") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Android.Support.Core.UI.25.4.0.1\\lib\\MonoAndroid70\\Xamarin.Android.Support.Core.UI.dll" }
			}
		};
		public static Package SupportCoreUtils_25_4_0_1 = new Package {
			Id = "Xamarin.Android.Support.Core.Utils",
			Version = "25.4.0.1",
			TargetFramework = "MonoAndroid70",
			References = {
				new BuildItem.Reference ("Xamarin.Android.Support.Core.Utils") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Android.Support.Core.Utils.25.4.0.1\\lib\\MonoAndroid70\\Xamarin.Android.Support.Core.Utils.dll" }
			}
		};
		public static Package SupportFragment_25_4_0_1 = new Package {
			Id = "Xamarin.Android.Support.Fragment",
			Version = "25.4.0.1",
			TargetFramework = "MonoAndroid70",
			References = {
				new BuildItem.Reference ("Xamarin.Android.Support.Fragment") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Android.Support.Fragment.25.4.0.1\\lib\\MonoAndroid70\\Xamarin.Android.Support.Fragment.dll" }
			}
		};
		public static Package SupportMediaCompat_25_4_0_1 = new Package {
			Id = "Xamarin.Android.Support.Media.Compat",
			Version = "25.4.0.1",
			TargetFramework = "MonoAndroid70",
			References = {
				new BuildItem.Reference ("Xamarin.Android.Support.Media.Compat") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Android.Support.Media.Compat.25.4.0.1\\lib\\MonoAndroid70\\Xamarin.Android.Support.Media.Compat.dll" }
			}
		};
		public static Package SupportV7MediaRouter_21_0_3_0 = new Package {
			Id = "Xamarin.Android.Support.v7.MediaRouter",
			Version = "21.0.3.0",
			TargetFramework = "MonoAndroid403",
			References = {
				new BuildItem.Reference ("Xamarin.Android.Support.v7.MediaRouter") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Android.Support.v7.MediaRouter.21.0.3.0\\lib\\MonoAndroid403\\Xamarin.Android.Support.v7.MediaRouter.dll" }
			}
		};
		public static Package SupportV7Palette_22_1_1_1 = new Package {
			Id = "Xamarin.Android.Support.v7.Palette",
			Version = "22.1.1.1",
			TargetFramework = "MonoAndroid403",
			References = {
				new BuildItem.Reference ("Xamarin.Android.Support.v7.Pallette") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Android.Support.v7.Palette.22.1.1.1\\lib\\MonoAndroid403\\Xamarin.Android.Support.v7.Palette.dll" }
			}
		};
		public static Package SupportDesign_25_4_0_1 = new Package {
			Id = "Xamarin.Android.Support.Design",
			Version = "25.4.0.1",
			TargetFramework = "MonoAndroid70",
			References = {
				new BuildItem.Reference ("Xamarin.Android.Support.Design") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Android.Support.Design.25.4.0.1\\lib\\MonoAndroid70\\Xamarin.Android.Support.Design.dll" }
				}
		};
		public static Package GooglePlayServices_22_0_0_2 = new Package {
			Id = "Xamarin.GooglePlayServices",
			Version = "22.0.0.2",
			TargetFramework = "MonoAndroid41",
			References = {
				new BuildItem.Reference ("GooglePlayServicesLib") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.GooglePlayServices.22.0.0.2\\lib\\MonoAndroid41\\GooglePlayServicesLib.dll"
				}
			}
		};
		public static Package XamarinFormsPCL_1_4_2 = new Package {
			Id = "Xamarin.Forms", 
			Version = "1.4.2.6359",
			TargetFramework ="portable-net45+win+wp80+MonoAndroid10+xamarinios10+MonoTouch10",
			References = {
				new BuildItem.Reference ("Xamarin.Forms.Core") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Forms.1.4.2.6359\\lib\\portable-win+net45+wp80+win81+wpa81+MonoAndroid10+MonoTouch10+Xamarin.iOS10\\Xamarin.Forms.Core.dll"
				},
				new BuildItem.Reference ("Xamarin.Forms.Xaml") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Forms.1.4.2.6359\\lib\\portable-win+net45+wp80+win81+wpa81+MonoAndroid10+MonoTouch10+Xamarin.iOS10\\Xamarin.Forms.Xaml.dll"
				},
			}
		};
		public static Package XamarinForms_1_4_2 = new Package {
			Id = "Xamarin.Forms", 
			Version = "1.4.2.6359",
			TargetFramework ="MonoAndroid44",
			References =  {
				new BuildItem.Reference ("Xamarin.Forms.Platform.Android") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Forms.1.4.2.6359\\lib\\MonoAndroid10\\Xamarin.Forms.Platform.Android.dll"
				},
				new BuildItem.Reference ("FormsViewGroup") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Forms.1.4.2.6359\\lib\\MonoAndroid10\\FormsViewGroup.dll"
				},
				new BuildItem.Reference ("Xamarin.Forms.Core") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Forms.1.4.2.6359\\lib\\MonoAndroid10\\Xamarin.Forms.Core.dll"
				},
				new BuildItem.Reference ("Xamarin.Forms.Xaml") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Forms.1.4.2.6359\\lib\\MonoAndroid10\\Xamarin.Forms.Xaml.dll"
				},
				new BuildItem.Reference ("Xamarin.Forms.Platform") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Forms.1.4.2.6359\\lib\\MonoAndroid10\\Xamarin.Forms.Platform.dll"
				},
			}
		};
		public static Package XamarinFormsPCL_2_3_4_231 = new Package {
			Id = "Xamarin.Forms",
			Version = "2.3.4.231",
			TargetFramework = "portable-net45+win+wp80+MonoAndroid10+xamarinios10+MonoTouch10",
			References = {
				new BuildItem.Reference ("Xamarin.Forms.Core") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Forms.2.3.4.231\\lib\\portable-win+net45+wp80+win81+wpa81+MonoAndroid10+MonoTouch10+Xamarin.iOS10\\Xamarin.Forms.Core.dll"
				},
				new BuildItem.Reference ("Xamarin.Forms.Xaml") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Forms.2.3.4.231\\lib\\portable-win+net45+wp80+win81+wpa81+MonoAndroid10+MonoTouch10+Xamarin.iOS10\\Xamarin.Forms.Xaml.dll"
				},
			}
		};
		public static Package XamarinForms_2_3_4_231 = new Package {
			Id = "Xamarin.Forms",
			Version = "2.3.4.231",
			TargetFramework = "MonoAndroid44",
			References =  {
				new BuildItem.Reference ("Xamarin.Forms.Platform.Android") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Forms.2.3.4.231\\lib\\MonoAndroid10\\Xamarin.Forms.Platform.Android.dll"
				},
				new BuildItem.Reference ("FormsViewGroup") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Forms.2.3.4.231\\lib\\MonoAndroid10\\FormsViewGroup.dll"
				},
				new BuildItem.Reference ("Xamarin.Forms.Core") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Forms.2.3.4.231\\lib\\MonoAndroid10\\Xamarin.Forms.Core.dll"
				},
				new BuildItem.Reference ("Xamarin.Forms.Xaml") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Forms.2.3.4.231\\lib\\MonoAndroid10\\Xamarin.Forms.Xaml.dll"
				},
				new BuildItem.Reference ("Xamarin.Forms.Platform") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Forms.2.3.4.231\\lib\\MonoAndroid10\\Xamarin.Forms.Platform.dll"
				},
			}
		};
		public static Package CocosSharp_PCL_Shared_1_5_0_0 = new Package {
			Id = "CocosSharp.PCL.Shared", 
			Version = "1.5.0.0",
			TargetFramework ="MonoAndroid10",
			References =  {
				new BuildItem.Reference ("box2d") {
					MetadataValues = "HintPath=..\\packages\\CocosSharp.PCL.Shared.1.5.0.0\\lib\\MonoAndroid10\\box2d.dll"
				},
				new BuildItem.Reference ("CocosSharp") {
					MetadataValues = "HintPath=..\\packages\\CocosSharp.PCL.Shared.1.5.0.0\\lib\\MonoAndroid10\\CocosSharp.dll"
				},
				new BuildItem.Reference ("MonoGame.Framework") {
					MetadataValues = "HintPath=..\\packages\\CocosSharp.PCL.Shared.1.5.0.0\\lib\\MonoAndroid10\\MonoGame.Framework.dll"
				},
			}
		};
		public static Package MonoGame_Framework_Android_3_4_0_459 = new Package {
			Id = "MonoGame.Framework.Android", 
			Version = "3.4.0.459",
			TargetFramework = "MonoAndroid10",
			References = {
				new BuildItem.Reference ("MonoGame.Framework") {
					MetadataValues = "HintPath=..\\packages\\MonoGame.Framework.Android.3.4.0.459\\lib\\MonoAndroid\\MonoGame.Framework.dll"
				},
			}
		};
		public static Package Xamarin_Android_Support_v8_RenderScript_23_1_1_0 = new Package {
			Id = "Xamarin.Android.Support.v8.RenderScript", 
			Version = "23.1.1.0",
			TargetFramework = "MonoAndroid44",
			References = {
				new BuildItem.Reference ("MonoGame.Framework") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Android.Support.v8.RenderScript.23.1.1.0\\lib\\MonoAndroid403\\Xamarin.Android.Support.v8.RenderScript.dll"
				},
			}
		};
		public static Package FSharp_Core_Latest = new Package {
			Id = "FSharp.Core",
			Version = "4.0.0.1",
			TargetFramework = "monoandroid71",
			References = {
				new BuildItem.Reference ("mscorlib"),
				new BuildItem.Reference ("FSharp.Core") {
					MetadataValues = "HintPath=..\\packages\\FSharp.Core.4.0.0.1\\lib\\portable-net45+monoandroid10+monotouch10+xamarinios10\\FSharp.Core.dll"
				},
			}
		};
		public static Package Xamarin_Android_FSharp_ResourceProvider_Runtime = new Package {
			Id = "Xamarin.Android.FSharp.ResourceProvider",
			Version = "1.0.0.13",
			TargetFramework = "monoandroid71",
			References = {
				new BuildItem.Reference ("Xamarin.Android.FSharp.ResourceProvider.Runtime") {
					MetadataValues = "HintPath=..\\packages\\Xamarin.Android.FSharp.ResourceProvider.1.0.0.13\\lib\\Xamarin.Android.FSharp.ResourceProvider.Runtime.dll"
				},
			}
		};
		public static Package SQLitePCLRaw_Core = new Package {
			Id = "SQLitePCLRaw.core",
			Version = "1.1.8",
			TargetFramework = "monoandroid71",
			References = {
				new BuildItem.Reference("SQLitePCL") {
					MetadataValues = "HintPath=..\\packages\\SQLitePCLRaw.core.1.1.8\\lib\\MonoAndroid\\SQLitePCLRaw.core.dll"
				}
			}
		};
		public static Package Microsoft_Azure_EventHubs = new Package {
			Id = "Microsoft.Azure.EventHubs",
			Version = "2.0.0",
			TargetFramework = "netstandard2.0",
			References = {
				new BuildItem.Reference("Microsoft.Azure.EventHubs") {
					MetadataValues = "HintPath=..\\packages\\Microsoft.Azure.EventHubs.2.0.0\\lib\\netstandard2.0\\Microsoft.Azure.EventHubs.dll"
				}
			}
		};
	}
}

