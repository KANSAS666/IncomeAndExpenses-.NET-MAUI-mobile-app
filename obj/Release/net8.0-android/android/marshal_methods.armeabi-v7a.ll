; ModuleID = 'marshal_methods.armeabi-v7a.ll'
source_filename = "marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [134 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [268 x i32] [
	i32 38948123, ; 0: ar\Microsoft.Maui.Controls.resources.dll => 0x2524d1b => 0
	i32 39109920, ; 1: Newtonsoft.Json.dll => 0x254c520 => 50
	i32 42244203, ; 2: he\Microsoft.Maui.Controls.resources.dll => 0x284986b => 9
	i32 42639949, ; 3: System.Threading.Thread => 0x28aa24d => 124
	i32 67008169, ; 4: zh-Hant\Microsoft.Maui.Controls.resources => 0x3fe76a9 => 33
	i32 72070932, ; 5: Microsoft.Maui.Graphics.dll => 0x44bb714 => 49
	i32 83839681, ; 6: ms\Microsoft.Maui.Controls.resources.dll => 0x4ff4ac1 => 17
	i32 117431740, ; 7: System.Runtime.InteropServices => 0x6ffddbc => 116
	i32 136584136, ; 8: zh-Hans\Microsoft.Maui.Controls.resources.dll => 0x8241bc8 => 32
	i32 140062828, ; 9: sk\Microsoft.Maui.Controls.resources.dll => 0x859306c => 25
	i32 165246403, ; 10: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 62
	i32 182336117, ; 11: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 80
	i32 205061960, ; 12: System.ComponentModel => 0xc38ff48 => 94
	i32 230752869, ; 13: Microsoft.CSharp.dll => 0xdc10265 => 87
	i32 317674968, ; 14: vi\Microsoft.Maui.Controls.resources => 0x12ef55d8 => 30
	i32 318968648, ; 15: Xamarin.AndroidX.Activity.dll => 0x13031348 => 58
	i32 321963286, ; 16: fr\Microsoft.Maui.Controls.resources.dll => 0x1330c516 => 8
	i32 342366114, ; 17: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 69
	i32 347068432, ; 18: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0x14afd810 => 54
	i32 379916513, ; 19: System.Threading.Thread.dll => 0x16a510e1 => 124
	i32 385762202, ; 20: System.Memory.dll => 0x16fe439a => 106
	i32 393699800, ; 21: Firebase => 0x177761d8 => 35
	i32 395744057, ; 22: _Microsoft.Android.Resource.Designer => 0x17969339 => 34
	i32 409257351, ; 23: tr\Microsoft.Maui.Controls.resources.dll => 0x1864c587 => 28
	i32 442565967, ; 24: System.Collections => 0x1a61054f => 91
	i32 450948140, ; 25: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 68
	i32 459347974, ; 26: System.Runtime.Serialization.Primitives.dll => 0x1b611806 => 120
	i32 469710990, ; 27: System.dll => 0x1bff388e => 128
	i32 489220957, ; 28: es\Microsoft.Maui.Controls.resources.dll => 0x1d28eb5d => 6
	i32 498788369, ; 29: System.ObjectModel => 0x1dbae811 => 111
	i32 513247710, ; 30: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 44
	i32 530272170, ; 31: System.Linq.Queryable => 0x1f9b4faa => 104
	i32 538707440, ; 32: th\Microsoft.Maui.Controls.resources.dll => 0x201c05f0 => 27
	i32 539058512, ; 33: Microsoft.Extensions.Logging => 0x20216150 => 41
	i32 610194910, ; 34: System.Reactive.dll => 0x245ed5de => 57
	i32 627609679, ; 35: Xamarin.AndroidX.CustomView => 0x2568904f => 66
	i32 627931235, ; 36: nl\Microsoft.Maui.Controls.resources => 0x256d7863 => 19
	i32 672442732, ; 37: System.Collections.Concurrent => 0x2814a96c => 88
	i32 690569205, ; 38: System.Xml.Linq.dll => 0x29293ff5 => 126
	i32 722857257, ; 39: System.Runtime.Loader.dll => 0x2b15ed29 => 117
	i32 748832960, ; 40: SQLitePCLRaw.batteries_v2 => 0x2ca248c0 => 52
	i32 752882528, ; 41: SQLitePCLRaw.provider.dynamic_cdecl.dll => 0x2ce01360 => 55
	i32 759454413, ; 42: System.Net.Requests => 0x2d445acd => 109
	i32 775507847, ; 43: System.IO.Compression => 0x2e394f87 => 102
	i32 777317022, ; 44: sk\Microsoft.Maui.Controls.resources => 0x2e54ea9e => 25
	i32 777371128, ; 45: Chugun_CourseWork.dll => 0x2e55bdf8 => 86
	i32 789151979, ; 46: Microsoft.Extensions.Options => 0x2f0980eb => 43
	i32 804715423, ; 47: System.Data.Common => 0x2ff6fb9f => 96
	i32 823281589, ; 48: System.Private.Uri.dll => 0x311247b5 => 112
	i32 830298997, ; 49: System.IO.Compression.Brotli => 0x317d5b75 => 101
	i32 869139383, ; 50: hi\Microsoft.Maui.Controls.resources.dll => 0x33ce03b7 => 10
	i32 880668424, ; 51: ru\Microsoft.Maui.Controls.resources.dll => 0x347def08 => 24
	i32 904024072, ; 52: System.ComponentModel.Primitives.dll => 0x35e25008 => 92
	i32 918734561, ; 53: pt-BR\Microsoft.Maui.Controls.resources.dll => 0x36c2c6e1 => 21
	i32 955402788, ; 54: Newtonsoft.Json => 0x38f24a24 => 50
	i32 961460050, ; 55: it\Microsoft.Maui.Controls.resources.dll => 0x394eb752 => 14
	i32 967690846, ; 56: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 69
	i32 990727110, ; 57: ro\Microsoft.Maui.Controls.resources.dll => 0x3b0d4bc6 => 23
	i32 992768348, ; 58: System.Collections.dll => 0x3b2c715c => 91
	i32 1012816738, ; 59: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 79
	i32 1019214401, ; 60: System.Drawing => 0x3cbffa41 => 100
	i32 1028951442, ; 61: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 40
	i32 1035644815, ; 62: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 59
	i32 1036536393, ; 63: System.Drawing.Primitives.dll => 0x3dc84a49 => 99
	i32 1043950537, ; 64: de\Microsoft.Maui.Controls.resources.dll => 0x3e396bc9 => 4
	i32 1044663988, ; 65: System.Linq.Expressions.dll => 0x3e444eb4 => 103
	i32 1052210849, ; 66: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 71
	i32 1082857460, ; 67: System.ComponentModel.TypeConverter => 0x408b17f4 => 93
	i32 1084122840, ; 68: Xamarin.Kotlin.StdLib => 0x409e66d8 => 84
	i32 1098259244, ; 69: System => 0x41761b2c => 128
	i32 1108272742, ; 70: sv\Microsoft.Maui.Controls.resources.dll => 0x420ee666 => 26
	i32 1117529484, ; 71: pl\Microsoft.Maui.Controls.resources.dll => 0x429c258c => 20
	i32 1118262833, ; 72: ko\Microsoft.Maui.Controls.resources => 0x42a75631 => 16
	i32 1168523401, ; 73: pt\Microsoft.Maui.Controls.resources => 0x45a64089 => 22
	i32 1178241025, ; 74: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 76
	i32 1260983243, ; 75: cs\Microsoft.Maui.Controls.resources => 0x4b2913cb => 2
	i32 1292207520, ; 76: SQLitePCLRaw.core.dll => 0x4d0585a0 => 53
	i32 1293217323, ; 77: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 67
	i32 1308624726, ; 78: hr\Microsoft.Maui.Controls.resources.dll => 0x4e000756 => 11
	i32 1324164729, ; 79: System.Linq => 0x4eed2679 => 105
	i32 1336711579, ; 80: zh-HK\Microsoft.Maui.Controls.resources.dll => 0x4fac999b => 31
	i32 1373134921, ; 81: zh-Hans\Microsoft.Maui.Controls.resources => 0x51d86049 => 32
	i32 1376866003, ; 82: Xamarin.AndroidX.SavedState => 0x52114ed3 => 79
	i32 1406073936, ; 83: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 63
	i32 1408764838, ; 84: System.Runtime.Serialization.Formatters.dll => 0x53f80ba6 => 119
	i32 1430672901, ; 85: ar\Microsoft.Maui.Controls.resources => 0x55465605 => 0
	i32 1461004990, ; 86: es\Microsoft.Maui.Controls.resources => 0x57152abe => 6
	i32 1462112819, ; 87: System.IO.Compression.dll => 0x57261233 => 102
	i32 1469204771, ; 88: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 60
	i32 1470490898, ; 89: Microsoft.Extensions.Primitives => 0x57a5e912 => 44
	i32 1480492111, ; 90: System.IO.Compression.Brotli.dll => 0x583e844f => 101
	i32 1526286932, ; 91: vi\Microsoft.Maui.Controls.resources.dll => 0x5af94a54 => 30
	i32 1543031311, ; 92: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 123
	i32 1622152042, ; 93: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 73
	i32 1624863272, ; 94: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 82
	i32 1636350590, ; 95: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 65
	i32 1639515021, ; 96: System.Net.Http.dll => 0x61b9038d => 107
	i32 1639986890, ; 97: System.Text.RegularExpressions => 0x61c036ca => 123
	i32 1657153582, ; 98: System.Runtime => 0x62c6282e => 121
	i32 1658251792, ; 99: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 83
	i32 1677501392, ; 100: System.Net.Primitives.dll => 0x63fca3d0 => 108
	i32 1679769178, ; 101: System.Security.Cryptography => 0x641f3e5a => 122
	i32 1711441057, ; 102: SQLitePCLRaw.lib.e_sqlite3.android => 0x660284a1 => 54
	i32 1729485958, ; 103: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 61
	i32 1743415430, ; 104: ca\Microsoft.Maui.Controls.resources => 0x67ea6886 => 1
	i32 1763938596, ; 105: System.Diagnostics.TraceSource.dll => 0x69239124 => 98
	i32 1766324549, ; 106: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 80
	i32 1770582343, ; 107: Microsoft.Extensions.Logging.dll => 0x6988f147 => 41
	i32 1780572499, ; 108: Mono.Android.Runtime.dll => 0x6a216153 => 132
	i32 1782862114, ; 109: ms\Microsoft.Maui.Controls.resources => 0x6a445122 => 17
	i32 1788241197, ; 110: Xamarin.AndroidX.Fragment => 0x6a96652d => 68
	i32 1793755602, ; 111: he\Microsoft.Maui.Controls.resources => 0x6aea89d2 => 9
	i32 1808609942, ; 112: Xamarin.AndroidX.Loader => 0x6bcd3296 => 73
	i32 1813058853, ; 113: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 84
	i32 1813201214, ; 114: Xamarin.Google.Android.Material => 0x6c13413e => 83
	i32 1818569960, ; 115: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 77
	i32 1824722060, ; 116: System.Runtime.Serialization.Formatters => 0x6cc30c8c => 119
	i32 1828688058, ; 117: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 42
	i32 1853025655, ; 118: sv\Microsoft.Maui.Controls.resources => 0x6e72ed77 => 26
	i32 1858542181, ; 119: System.Linq.Expressions => 0x6ec71a65 => 103
	i32 1875935024, ; 120: fr\Microsoft.Maui.Controls.resources => 0x6fd07f30 => 8
	i32 1893218855, ; 121: cs\Microsoft.Maui.Controls.resources.dll => 0x70d83a27 => 2
	i32 1910275211, ; 122: System.Collections.NonGeneric.dll => 0x71dc7c8b => 89
	i32 1939592360, ; 123: System.Private.Xml.Linq => 0x739bd4a8 => 113
	i32 1953182387, ; 124: id\Microsoft.Maui.Controls.resources.dll => 0x746b32b3 => 13
	i32 1968388702, ; 125: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 37
	i32 2003115576, ; 126: el\Microsoft.Maui.Controls.resources => 0x77651e38 => 5
	i32 2019465201, ; 127: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 71
	i32 2026516816, ; 128: Chugun_CourseWork => 0x78ca3150 => 86
	i32 2045470958, ; 129: System.Private.Xml => 0x79eb68ee => 114
	i32 2055257422, ; 130: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 70
	i32 2066184531, ; 131: de\Microsoft.Maui.Controls.resources => 0x7b277953 => 4
	i32 2070888862, ; 132: System.Diagnostics.TraceSource => 0x7b6f419e => 98
	i32 2079903147, ; 133: System.Runtime.dll => 0x7bf8cdab => 121
	i32 2090495875, ; 134: SQLitePCLRaw.provider.dynamic_cdecl => 0x7c9a6f83 => 55
	i32 2090596640, ; 135: System.Numerics.Vectors => 0x7c9bf920 => 110
	i32 2103459038, ; 136: SQLitePCLRaw.provider.e_sqlite3.dll => 0x7d603cde => 56
	i32 2127167465, ; 137: System.Console => 0x7ec9ffe9 => 95
	i32 2142473426, ; 138: System.Collections.Specialized => 0x7fb38cd2 => 90
	i32 2159891885, ; 139: Microsoft.Maui => 0x80bd55ad => 47
	i32 2169148018, ; 140: hu\Microsoft.Maui.Controls.resources => 0x814a9272 => 12
	i32 2181898931, ; 141: Microsoft.Extensions.Options.dll => 0x820d22b3 => 43
	i32 2192057212, ; 142: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 42
	i32 2193016926, ; 143: System.ObjectModel.dll => 0x82b6c85e => 111
	i32 2201107256, ; 144: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 85
	i32 2201231467, ; 145: System.Net.Http => 0x8334206b => 107
	i32 2207618523, ; 146: it\Microsoft.Maui.Controls.resources => 0x839595db => 14
	i32 2266799131, ; 147: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 38
	i32 2279755925, ; 148: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 78
	i32 2303942373, ; 149: nb\Microsoft.Maui.Controls.resources => 0x89535ee5 => 18
	i32 2305521784, ; 150: System.Private.CoreLib.dll => 0x896b7878 => 130
	i32 2340441535, ; 151: System.Runtime.InteropServices.RuntimeInformation.dll => 0x8b804dbf => 115
	i32 2353062107, ; 152: System.Net.Primitives => 0x8c40e0db => 108
	i32 2366048013, ; 153: hu\Microsoft.Maui.Controls.resources.dll => 0x8d07070d => 12
	i32 2368005991, ; 154: System.Xml.ReaderWriter.dll => 0x8d24e767 => 127
	i32 2371007202, ; 155: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 37
	i32 2395872292, ; 156: id\Microsoft.Maui.Controls.resources => 0x8ece1c24 => 13
	i32 2427813419, ; 157: hi\Microsoft.Maui.Controls.resources => 0x90b57e2b => 10
	i32 2435356389, ; 158: System.Console.dll => 0x912896e5 => 95
	i32 2465273461, ; 159: SQLitePCLRaw.batteries_v2.dll => 0x92f11675 => 52
	i32 2471841756, ; 160: netstandard.dll => 0x93554fdc => 129
	i32 2475788418, ; 161: Java.Interop.dll => 0x93918882 => 131
	i32 2480646305, ; 162: Microsoft.Maui.Controls => 0x93dba8a1 => 45
	i32 2503351294, ; 163: ko\Microsoft.Maui.Controls.resources.dll => 0x95361bfe => 16
	i32 2550873716, ; 164: hr\Microsoft.Maui.Controls.resources => 0x980b3e74 => 11
	i32 2562349572, ; 165: Microsoft.CSharp => 0x98ba5a04 => 87
	i32 2576534780, ; 166: ja\Microsoft.Maui.Controls.resources.dll => 0x9992ccfc => 15
	i32 2593496499, ; 167: pl\Microsoft.Maui.Controls.resources => 0x9a959db3 => 20
	i32 2605712449, ; 168: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 85
	i32 2617129537, ; 169: System.Private.Xml.dll => 0x9bfe3a41 => 114
	i32 2620871830, ; 170: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 65
	i32 2626831493, ; 171: ja\Microsoft.Maui.Controls.resources => 0x9c924485 => 15
	i32 2663698177, ; 172: System.Runtime.Loader => 0x9ec4cf01 => 117
	i32 2665622720, ; 173: System.Drawing.Primitives => 0x9ee22cc0 => 99
	i32 2676780864, ; 174: System.Data.Common.dll => 0x9f8c6f40 => 96
	i32 2724373263, ; 175: System.Runtime.Numerics.dll => 0xa262a30f => 118
	i32 2732626843, ; 176: Xamarin.AndroidX.Activity => 0xa2e0939b => 58
	i32 2737747696, ; 177: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 60
	i32 2740698338, ; 178: ca\Microsoft.Maui.Controls.resources.dll => 0xa35bbce2 => 1
	i32 2752995522, ; 179: pt-BR\Microsoft.Maui.Controls.resources => 0xa41760c2 => 21
	i32 2758225723, ; 180: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 46
	i32 2764765095, ; 181: Microsoft.Maui.dll => 0xa4caf7a7 => 47
	i32 2778768386, ; 182: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 81
	i32 2785988530, ; 183: th\Microsoft.Maui.Controls.resources => 0xa60ecfb2 => 27
	i32 2801831435, ; 184: Microsoft.Maui.Graphics => 0xa7008e0b => 49
	i32 2810250172, ; 185: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 63
	i32 2853208004, ; 186: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 81
	i32 2861189240, ; 187: Microsoft.Maui.Essentials => 0xaa8a4878 => 48
	i32 2909740682, ; 188: System.Private.CoreLib => 0xad6f1e8a => 130
	i32 2916838712, ; 189: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 82
	i32 2919462931, ; 190: System.Numerics.Vectors.dll => 0xae037813 => 110
	i32 2959614098, ; 191: System.ComponentModel.dll => 0xb0682092 => 94
	i32 2978675010, ; 192: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 67
	i32 3038032645, ; 193: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 34
	i32 3053864966, ; 194: fi\Microsoft.Maui.Controls.resources.dll => 0xb6064806 => 7
	i32 3057625584, ; 195: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 74
	i32 3059408633, ; 196: Mono.Android.Runtime => 0xb65adef9 => 132
	i32 3059793426, ; 197: System.ComponentModel.Primitives => 0xb660be12 => 92
	i32 3178803400, ; 198: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 75
	i32 3220365878, ; 199: System.Threading => 0xbff2e236 => 125
	i32 3258312781, ; 200: Xamarin.AndroidX.CardView => 0xc235e84d => 61
	i32 3265493905, ; 201: System.Linq.Queryable.dll => 0xc2a37b91 => 104
	i32 3286872994, ; 202: SQLite-net.dll => 0xc3e9b3a2 => 51
	i32 3305363605, ; 203: fi\Microsoft.Maui.Controls.resources => 0xc503d895 => 7
	i32 3316684772, ; 204: System.Net.Requests.dll => 0xc5b097e4 => 109
	i32 3317135071, ; 205: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 66
	i32 3322403133, ; 206: Firebase.dll => 0xc607d93d => 35
	i32 3346324047, ; 207: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 76
	i32 3357674450, ; 208: ru\Microsoft.Maui.Controls.resources => 0xc8220bd2 => 24
	i32 3360279109, ; 209: SQLitePCLRaw.core => 0xc849ca45 => 53
	i32 3362522851, ; 210: Xamarin.AndroidX.Core => 0xc86c06e3 => 64
	i32 3366347497, ; 211: Java.Interop => 0xc8a662e9 => 131
	i32 3374999561, ; 212: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 78
	i32 3381016424, ; 213: da\Microsoft.Maui.Controls.resources => 0xc9863768 => 3
	i32 3428513518, ; 214: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 39
	i32 3430777524, ; 215: netstandard => 0xcc7d82b4 => 129
	i32 3458724246, ; 216: pt\Microsoft.Maui.Controls.resources.dll => 0xce27f196 => 22
	i32 3471940407, ; 217: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 93
	i32 3476120550, ; 218: Mono.Android => 0xcf3163e6 => 133
	i32 3484440000, ; 219: ro\Microsoft.Maui.Controls.resources => 0xcfb055c0 => 23
	i32 3509114376, ; 220: System.Xml.Linq => 0xd128d608 => 126
	i32 3580758918, ; 221: zh-HK\Microsoft.Maui.Controls.resources => 0xd56e0b86 => 31
	i32 3592228221, ; 222: zh-Hant\Microsoft.Maui.Controls.resources.dll => 0xd61d0d7d => 33
	i32 3596207933, ; 223: LiteDB.dll => 0xd659c73d => 36
	i32 3608519521, ; 224: System.Linq.dll => 0xd715a361 => 105
	i32 3624195450, ; 225: System.Runtime.InteropServices.RuntimeInformation => 0xd804d57a => 115
	i32 3629588173, ; 226: LiteDB => 0xd8571ecd => 36
	i32 3641597786, ; 227: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 70
	i32 3643446276, ; 228: tr\Microsoft.Maui.Controls.resources => 0xd92a9404 => 28
	i32 3643854240, ; 229: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 75
	i32 3657292374, ; 230: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 38
	i32 3672681054, ; 231: Mono.Android.dll => 0xdae8aa5e => 133
	i32 3724971120, ; 232: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 74
	i32 3731644420, ; 233: System.Reactive => 0xde6c6004 => 57
	i32 3748608112, ; 234: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 97
	i32 3751619990, ; 235: da\Microsoft.Maui.Controls.resources.dll => 0xdf9d2d96 => 3
	i32 3754567612, ; 236: SQLitePCLRaw.provider.e_sqlite3 => 0xdfca27bc => 56
	i32 3786282454, ; 237: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 62
	i32 3792276235, ; 238: System.Collections.NonGeneric => 0xe2098b0b => 89
	i32 3802395368, ; 239: System.Collections.Specialized.dll => 0xe2a3f2e8 => 90
	i32 3823082795, ; 240: System.Security.Cryptography.dll => 0xe3df9d2b => 122
	i32 3841636137, ; 241: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 40
	i32 3849253459, ; 242: System.Runtime.InteropServices.dll => 0xe56ef253 => 116
	i32 3876362041, ; 243: SQLite-net => 0xe70c9739 => 51
	i32 3896106733, ; 244: System.Collections.Concurrent.dll => 0xe839deed => 88
	i32 3896760992, ; 245: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 64
	i32 3920221145, ; 246: nl\Microsoft.Maui.Controls.resources.dll => 0xe9a9d3d9 => 19
	i32 3928044579, ; 247: System.Xml.ReaderWriter => 0xea213423 => 127
	i32 3931092270, ; 248: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 77
	i32 3955647286, ; 249: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 59
	i32 4025784931, ; 250: System.Memory => 0xeff49a63 => 106
	i32 4046471985, ; 251: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 46
	i32 4068434129, ; 252: System.Private.Xml.Linq.dll => 0xf27f60d1 => 113
	i32 4073602200, ; 253: System.Threading.dll => 0xf2ce3c98 => 125
	i32 4091086043, ; 254: el\Microsoft.Maui.Controls.resources.dll => 0xf3d904db => 5
	i32 4094352644, ; 255: Microsoft.Maui.Essentials.dll => 0xf40add04 => 48
	i32 4099507663, ; 256: System.Drawing.dll => 0xf45985cf => 100
	i32 4100113165, ; 257: System.Private.Uri => 0xf462c30d => 112
	i32 4103439459, ; 258: uk\Microsoft.Maui.Controls.resources.dll => 0xf4958463 => 29
	i32 4126470640, ; 259: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 39
	i32 4150914736, ; 260: uk\Microsoft.Maui.Controls.resources => 0xf769eeb0 => 29
	i32 4181436372, ; 261: System.Runtime.Serialization.Primitives => 0xf93ba7d4 => 120
	i32 4182413190, ; 262: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 72
	i32 4213026141, ; 263: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 97
	i32 4249188766, ; 264: nb\Microsoft.Maui.Controls.resources.dll => 0xfd45799e => 18
	i32 4271975918, ; 265: Microsoft.Maui.Controls.dll => 0xfea12dee => 45
	i32 4274976490, ; 266: System.Runtime.Numerics => 0xfecef6ea => 118
	i32 4292120959 ; 267: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 72
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [268 x i32] [
	i32 0, ; 0
	i32 50, ; 1
	i32 9, ; 2
	i32 124, ; 3
	i32 33, ; 4
	i32 49, ; 5
	i32 17, ; 6
	i32 116, ; 7
	i32 32, ; 8
	i32 25, ; 9
	i32 62, ; 10
	i32 80, ; 11
	i32 94, ; 12
	i32 87, ; 13
	i32 30, ; 14
	i32 58, ; 15
	i32 8, ; 16
	i32 69, ; 17
	i32 54, ; 18
	i32 124, ; 19
	i32 106, ; 20
	i32 35, ; 21
	i32 34, ; 22
	i32 28, ; 23
	i32 91, ; 24
	i32 68, ; 25
	i32 120, ; 26
	i32 128, ; 27
	i32 6, ; 28
	i32 111, ; 29
	i32 44, ; 30
	i32 104, ; 31
	i32 27, ; 32
	i32 41, ; 33
	i32 57, ; 34
	i32 66, ; 35
	i32 19, ; 36
	i32 88, ; 37
	i32 126, ; 38
	i32 117, ; 39
	i32 52, ; 40
	i32 55, ; 41
	i32 109, ; 42
	i32 102, ; 43
	i32 25, ; 44
	i32 86, ; 45
	i32 43, ; 46
	i32 96, ; 47
	i32 112, ; 48
	i32 101, ; 49
	i32 10, ; 50
	i32 24, ; 51
	i32 92, ; 52
	i32 21, ; 53
	i32 50, ; 54
	i32 14, ; 55
	i32 69, ; 56
	i32 23, ; 57
	i32 91, ; 58
	i32 79, ; 59
	i32 100, ; 60
	i32 40, ; 61
	i32 59, ; 62
	i32 99, ; 63
	i32 4, ; 64
	i32 103, ; 65
	i32 71, ; 66
	i32 93, ; 67
	i32 84, ; 68
	i32 128, ; 69
	i32 26, ; 70
	i32 20, ; 71
	i32 16, ; 72
	i32 22, ; 73
	i32 76, ; 74
	i32 2, ; 75
	i32 53, ; 76
	i32 67, ; 77
	i32 11, ; 78
	i32 105, ; 79
	i32 31, ; 80
	i32 32, ; 81
	i32 79, ; 82
	i32 63, ; 83
	i32 119, ; 84
	i32 0, ; 85
	i32 6, ; 86
	i32 102, ; 87
	i32 60, ; 88
	i32 44, ; 89
	i32 101, ; 90
	i32 30, ; 91
	i32 123, ; 92
	i32 73, ; 93
	i32 82, ; 94
	i32 65, ; 95
	i32 107, ; 96
	i32 123, ; 97
	i32 121, ; 98
	i32 83, ; 99
	i32 108, ; 100
	i32 122, ; 101
	i32 54, ; 102
	i32 61, ; 103
	i32 1, ; 104
	i32 98, ; 105
	i32 80, ; 106
	i32 41, ; 107
	i32 132, ; 108
	i32 17, ; 109
	i32 68, ; 110
	i32 9, ; 111
	i32 73, ; 112
	i32 84, ; 113
	i32 83, ; 114
	i32 77, ; 115
	i32 119, ; 116
	i32 42, ; 117
	i32 26, ; 118
	i32 103, ; 119
	i32 8, ; 120
	i32 2, ; 121
	i32 89, ; 122
	i32 113, ; 123
	i32 13, ; 124
	i32 37, ; 125
	i32 5, ; 126
	i32 71, ; 127
	i32 86, ; 128
	i32 114, ; 129
	i32 70, ; 130
	i32 4, ; 131
	i32 98, ; 132
	i32 121, ; 133
	i32 55, ; 134
	i32 110, ; 135
	i32 56, ; 136
	i32 95, ; 137
	i32 90, ; 138
	i32 47, ; 139
	i32 12, ; 140
	i32 43, ; 141
	i32 42, ; 142
	i32 111, ; 143
	i32 85, ; 144
	i32 107, ; 145
	i32 14, ; 146
	i32 38, ; 147
	i32 78, ; 148
	i32 18, ; 149
	i32 130, ; 150
	i32 115, ; 151
	i32 108, ; 152
	i32 12, ; 153
	i32 127, ; 154
	i32 37, ; 155
	i32 13, ; 156
	i32 10, ; 157
	i32 95, ; 158
	i32 52, ; 159
	i32 129, ; 160
	i32 131, ; 161
	i32 45, ; 162
	i32 16, ; 163
	i32 11, ; 164
	i32 87, ; 165
	i32 15, ; 166
	i32 20, ; 167
	i32 85, ; 168
	i32 114, ; 169
	i32 65, ; 170
	i32 15, ; 171
	i32 117, ; 172
	i32 99, ; 173
	i32 96, ; 174
	i32 118, ; 175
	i32 58, ; 176
	i32 60, ; 177
	i32 1, ; 178
	i32 21, ; 179
	i32 46, ; 180
	i32 47, ; 181
	i32 81, ; 182
	i32 27, ; 183
	i32 49, ; 184
	i32 63, ; 185
	i32 81, ; 186
	i32 48, ; 187
	i32 130, ; 188
	i32 82, ; 189
	i32 110, ; 190
	i32 94, ; 191
	i32 67, ; 192
	i32 34, ; 193
	i32 7, ; 194
	i32 74, ; 195
	i32 132, ; 196
	i32 92, ; 197
	i32 75, ; 198
	i32 125, ; 199
	i32 61, ; 200
	i32 104, ; 201
	i32 51, ; 202
	i32 7, ; 203
	i32 109, ; 204
	i32 66, ; 205
	i32 35, ; 206
	i32 76, ; 207
	i32 24, ; 208
	i32 53, ; 209
	i32 64, ; 210
	i32 131, ; 211
	i32 78, ; 212
	i32 3, ; 213
	i32 39, ; 214
	i32 129, ; 215
	i32 22, ; 216
	i32 93, ; 217
	i32 133, ; 218
	i32 23, ; 219
	i32 126, ; 220
	i32 31, ; 221
	i32 33, ; 222
	i32 36, ; 223
	i32 105, ; 224
	i32 115, ; 225
	i32 36, ; 226
	i32 70, ; 227
	i32 28, ; 228
	i32 75, ; 229
	i32 38, ; 230
	i32 133, ; 231
	i32 74, ; 232
	i32 57, ; 233
	i32 97, ; 234
	i32 3, ; 235
	i32 56, ; 236
	i32 62, ; 237
	i32 89, ; 238
	i32 90, ; 239
	i32 122, ; 240
	i32 40, ; 241
	i32 116, ; 242
	i32 51, ; 243
	i32 88, ; 244
	i32 64, ; 245
	i32 19, ; 246
	i32 127, ; 247
	i32 77, ; 248
	i32 59, ; 249
	i32 106, ; 250
	i32 46, ; 251
	i32 113, ; 252
	i32 125, ; 253
	i32 5, ; 254
	i32 48, ; 255
	i32 100, ; 256
	i32 112, ; 257
	i32 29, ; 258
	i32 39, ; 259
	i32 29, ; 260
	i32 120, ; 261
	i32 72, ; 262
	i32 97, ; 263
	i32 18, ; 264
	i32 45, ; 265
	i32 118, ; 266
	i32 72 ; 267
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 4

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 4

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 4

; Functions

; Function attributes: "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 4, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 1

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }

; Metadata
!llvm.module.flags = !{!0, !1, !7}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.1xx @ f68622cf6b97fa23cc3d3105a52ef5b2e31d52a1"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"min_enum_size", i32 4}
