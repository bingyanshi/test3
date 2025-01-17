using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

using Microsoft.Build.Framework;
using NUnit.Framework;

using Xamarin.ProjectTools;

using XABuildPaths = global::Xamarin.Android.Build.Paths;

namespace CodeBehindUnitTests
{
	sealed class LocalBuilder : Builder
	{
		public bool Build (string projectOrSolution, string target, string[] parameters = null, Dictionary<string, string> environmentVariables = null)
		{
			return BuildInternal (projectOrSolution, target, parameters, environmentVariables);
		}
	}

	sealed class SourceFileMember
	{
		public string Visibility { get; }
		public string Type { get; }
		public string Name { get; }
		public string Arguments { get; }
		public bool IsExpressionBody { get; }
		public bool IsMethod { get; }

		public SourceFileMember (string visibility, string type, string name, bool isExpressionBody)
		{
			if (String.IsNullOrEmpty (visibility))
				throw new ArgumentException (nameof (visibility));
			if (String.IsNullOrEmpty (type))
				throw new ArgumentException (nameof (type));
			if (String.IsNullOrEmpty (name))
				throw new ArgumentException (nameof (name));
			Visibility = visibility;
			Type = type;
			Name = name;
			IsExpressionBody = isExpressionBody;
			IsMethod = false;
		}

		public SourceFileMember (string visibility, string type, string name, string arguments)
		{
			if (String.IsNullOrEmpty (visibility))
				throw new ArgumentException (nameof (visibility));
			if (String.IsNullOrEmpty (type))
				throw new ArgumentException (nameof (type));
			if (String.IsNullOrEmpty (name))
				throw new ArgumentException (nameof (name));
			Visibility = visibility;
			Type = type;
			Name = name;
			Arguments = arguments ?? String.Empty;
			IsExpressionBody = false;
			IsMethod = true;
		}
	}

	sealed class SourceFile : IEnumerable<SourceFileMember>
	{
		readonly List<SourceFileMember> properties;

		public string Path { get; }
		public bool ForMany { get; }

		public SourceFile (string path, bool forMany = false)
		{
			if (String.IsNullOrEmpty (path))
				throw new ArgumentException (nameof (path));
			Path = path;
			ForMany = forMany;
			properties = new List <SourceFileMember> ();
		}

		public void Add (string visibility, string type, string name, bool isExpressionBody = true)
		{
			properties.Add (new SourceFileMember (visibility, type, name, isExpressionBody));
		}

		public void Add (string visibility, string type, string name, string arguments)
		{
			properties.Add (new SourceFileMember (visibility, type, name, arguments));
		}

		public IEnumerator<SourceFileMember> GetEnumerator()
		{
			return ((IEnumerable<SourceFileMember>)properties).GetEnumerator ();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<SourceFileMember>)properties).GetEnumerator ();
		}
	}

	public class BuildTests_CodeBehindBuildTests
	{
		const string ProjectName = "CodeBehindBuildTests";

		static readonly string TestProjectRootDirectory;
		static readonly string TestProjectObjPath;
		static readonly string TestProjectBinPath;
		static readonly string TestProjectPath;
		static readonly string TestOutputDir;

		static readonly List <SourceFile> generated_sources;
		static readonly List <string> produced_binaries;

		static readonly List <string> log_files = new List <string> {
			"process.log",
			"msbuild.binlog",
		};

		static BuildTests_CodeBehindBuildTests ()
		{
			TestProjectRootDirectory = Path.GetFullPath (Path.Combine (XABuildPaths.TopDirectory, "tests", "CodeBehind", "BuildTests"));
			TestProjectObjPath = Path.Combine ("obj", XABuildPaths.Configuration);
			TestProjectBinPath = Path.Combine ("bin", XABuildPaths.Configuration);
			TestProjectPath = Path.Combine (TestProjectRootDirectory, $"{ProjectName}.sln");
			TestOutputDir = Path.Combine (XABuildPaths.TestOutputDirectory, "CodeBehind");

			string generatedSourcesDir = Path.Combine (TestProjectObjPath, "generated");
			generated_sources = new List <SourceFile> {
				new SourceFile (Path.Combine (generatedSourcesDir, "Binding.Main.g.cs")) {
					{"public", "Button", "myButton"},
					{"public", "CommonSampleLibrary.LogFragment", "log_fragment"},
					{"public", "global::Android.App.Fragment", "secondary_log_fragment"},
					{"public", "CommonSampleLibrary.LogFragment", "tertiary_log_fragment"},
				},
				new SourceFile (Path.Combine (generatedSourcesDir, "Binding.onboarding_info.g.cs")) {
					{"public", "LinearLayout", "onboarding_stations_info_inner"},
					{"public", "ImageView", "icon_view"},
					{"public", "TextView", "intro_highlighted_text"},
					{"public", "TextView", "intro_primary_text"},
				},
				new SourceFile (Path.Combine (generatedSourcesDir, "Binding.onboarding_intro.g.cs")) {
					{"public", "LinearLayout", "onboarding_intro_View"},
					{"public", "TextView", "title"},
					{"public", "TextView", "welcome"},
					{"public", "global::Android.Views.View", "different_view_types"},
					{"public", "global::Android.Views.View", "onboarding_info"},
					{"public", "TextView", "intro_highlighted_text"},
					{"public", "TextView", "intro_primary_text"},
					{"public", "TextView", "intro_secondary_text"},
					{"public", "RelativeLayout", "more_info"},
					{"public", "TextView", "more_highlighted_text"},
					{"public", "TextView", "more_intro_primary_text"},
					{"public", "TextView", "more_intro_secondary_text"},

				},
				new SourceFile (Path.Combine (generatedSourcesDir, "Binding.settings.g.cs")) {
					{"public", "ScrollView", "settings_container"},
					{"public", "TextView", "title"},
					{"public", "TextView", "account_type"},
					{"public", "TextView", "account_type_subtitle"},
					{"public", "TextView", "account_email"},
					{"public", "Button", "subscribe_button"},
					{"public", "TextView", "stream_quality_item_title"},
				},
				new SourceFile (Path.Combine (generatedSourcesDir, "Xamarin.Android.Tests.CodeBehindBuildTests.AnotherMainActivity.Main.g.cs")) {
					// Properties
					{"public", "Button", "myButton"},
					{"public", "CommonSampleLibrary.LogFragment", "log_fragment"},
					{"public", "global::Android.App.Fragment", "secondary_log_fragment"},
					{"public", "CommonSampleLibrary.LogFragment", "tertiary_log_fragment"},

					// Methods
					{"public override", "void", "SetContentView", "global::Android.Views.View view"},
					{"public override", "void", "SetContentView", "global::Android.Views.View view, global::Android.Views.ViewGroup.LayoutParams @params"},
					{"public override", "void", "SetContentView", "int layoutResID"},
					{"partial", "void", "OnSetContentView", "global::Android.Views.View view, ref bool callBaseAfterReturn"},
					{"partial", "void", "OnSetContentView", "global::Android.Views.View view, global::Android.Views.ViewGroup.LayoutParams @params, ref bool callBaseAfterReturn"},
					{"partial", "void", "OnSetContentView", "int layoutResID, ref bool callBaseAfterReturn"},
				},
				new SourceFile (Path.Combine (generatedSourcesDir, "Xamarin.Android.Tests.CodeBehindBuildTests.MainActivity.Main.g.cs")) {
					// Properties
					{"public", "Button", "myButton"},
					{"public", "CommonSampleLibrary.LogFragment", "log_fragment"},
					{"public", "global::Android.App.Fragment", "secondary_log_fragment"},
					{"public", "CommonSampleLibrary.LogFragment", "tertiary_log_fragment"},

					// Methods
					{"public override", "void", "SetContentView", "global::Android.Views.View view"},
					{"public override", "void", "SetContentView", "global::Android.Views.View view, global::Android.Views.ViewGroup.LayoutParams @params"},
					{"public override", "void", "SetContentView", "int layoutResID"},
					{"partial", "void", "OnSetContentView", "global::Android.Views.View view, ref bool callBaseAfterReturn"},
					{"partial", "void", "OnSetContentView", "global::Android.Views.View view, global::Android.Views.ViewGroup.LayoutParams @params, ref bool callBaseAfterReturn"},
					{"partial", "void", "OnSetContentView", "int layoutResID, ref bool callBaseAfterReturn"},
				},
				new SourceFile (Path.Combine (generatedSourcesDir, "Xamarin.Android.Tests.CodeBehindBuildTests.OnboardingActivityPartial.onboarding_intro.g.cs")) {
					// Properties
					{"public", "LinearLayout", "onboarding_intro_View"},
					{"public", "TextView", "title"},
					{"public", "TextView", "welcome"},
					{"public", "global::Android.Views.View", "different_view_types"},
					{"public", "global::Android.Views.View", "onboarding_info"},
					{"public", "TextView", "intro_highlighted_text"},
					{"public", "TextView", "intro_primary_text"},
					{"public", "TextView", "intro_secondary_text"},
					{"public", "RelativeLayout", "more_info"},
					{"public", "TextView", "more_highlighted_text"},
					{"public", "TextView", "more_intro_primary_text"},
					{"public", "TextView", "more_intro_secondary_text"},

					// Methods
					{"public override", "void", "SetContentView", "global::Android.Views.View view"},
					{"public override", "void", "SetContentView", "global::Android.Views.View view, global::Android.Views.ViewGroup.LayoutParams @params"},
					{"public override", "void", "SetContentView", "int layoutResID"},
					{"partial", "void", "OnSetContentView", "global::Android.Views.View view, ref bool callBaseAfterReturn"},
					{"partial", "void", "OnSetContentView", "global::Android.Views.View view, global::Android.Views.ViewGroup.LayoutParams @params, ref bool callBaseAfterReturn"},
					{"partial", "void", "OnSetContentView", "int layoutResID, ref bool callBaseAfterReturn"},
				},
			};

			produced_binaries = new List <string> {
				Path.Combine (TestProjectBinPath, $"{ProjectName}.dll"),
				Path.Combine (TestProjectBinPath, "CommonSampleLibrary.dll"),
				Path.Combine (TestProjectBinPath, $"com.xamarin.{ProjectName}-Signed.apk"),
				Path.Combine (TestProjectBinPath, $"com.xamarin.{ProjectName}.apk"),
			};
		}

		[Test]
		public void SuccessfulBuildFew ()
		{
			RunTest ("SuccessfulBuildFew", false, SuccessfulBuild_RunTest);
		}

		[Test]
		public void SuccessfulBuildMany ()
		{
			RunTest ("SuccessfulBuildMany", true, SuccessfulBuild_RunTest);
		}

		void SuccessfulBuild_RunTest (string testName, bool many, LocalBuilder builder)
		{
			string[] parameters = GetBuildProperties (many);
			bool success = builder.Build (TestProjectPath, "SignAndroidPackage", parameters);

			CopyLogs (testName, true);
			Assert.That (success, Is.True, "Build should have succeeded");

			CopyGeneratedFiles (testName);

			foreach (SourceFile src in generated_sources) {
				foreach (SourceFileMember member in src) {
					if (member.IsMethod)
						Assert.That (SourceHasMethod (Path.Combine (TestProjectRootDirectory, src.Path), member.Visibility, member.Type, member.Name, member.Arguments), Is.True, $"Method {member.Name} must exist in {src.Path}");
					else
						Assert.That (SourceHasProperty (Path.Combine (TestProjectRootDirectory, src.Path), member.Visibility, member.Type, member.Name, member.IsExpressionBody), Is.True, $"Property {member.Name} must exist in {src.Path}");
				}
			}

			foreach (string binPath in produced_binaries)
				AssertExists (testName, Path.Combine (TestProjectRootDirectory, binPath));
		}

		[Test]
		public void FailedBuildFew_ConflictingFragment ()
		{
			RunTest ("FailedBuildFew_ConflictingFragment", false, FailedBuild_ConflictingFragment_RunTest);
		}

		[Test]
		public void FailedBuildMany_ConflictingFragment ()
		{
			RunTest ("FailedBuildMany_ConflictingFragment", true, FailedBuild_ConflictingFragment_RunTest);
		}

		void FailedBuild_ConflictingFragment_RunTest (string testName, bool many, LocalBuilder builder)
		{
			string[] parameters = GetBuildProperties (many, "NOT_CONFLICTING_FRAGMENT");
			bool success = builder.Build (TestProjectPath, "SignAndroidPackage", parameters);

			CopyLogs (testName, true);
			Assert.That (success, Is.False, "Build should have failed");

			string logPath = GetTestLogPath (testName);
			bool haveError = HaveCompilerError_CS0266 (logPath, "MainActivity.cs", 26, "Android.App.Fragment", "CommonSampleLibrary.LogFragment");
			AssertHaveCompilerError (haveError, "MainActivity.cs", 26);

			haveError = HaveCompilerError_CS0266 (logPath, "AnotherMainActivity.cs", 23, "Android.App.Fragment", "CommonSampleLibrary.LogFragment");
			AssertHaveCompilerError (haveError, "AnotherMainActivity.cs", 23);
		}

		[Test]
		public void FailedBuildFew_ConflictingTextView ()
		{
			RunTest ("FailedBuildFew_ConflictingTextView", false, FailedBuild_ConflictingTextView_RunTest);
		}

		[Test]
		public void FailedBuildMany_ConflictingTextView ()
		{
			RunTest ("FailedBuildMany_ConflictingTextView", true, FailedBuild_ConflictingTextView_RunTest);
		}

		void FailedBuild_ConflictingTextView_RunTest (string testName, bool many, LocalBuilder builder)
		{
			string[] parameters = GetBuildProperties (many, "NOT_CONFLICTING_TEXTVIEW");
			bool success = builder.Build (TestProjectPath, "SignAndroidPackage", parameters);

			CopyLogs (testName, true);
			Assert.That (success, Is.False, "Build should have failed");

			string logPath = GetTestLogPath (testName);
			bool haveError = HaveCompilerError_CS0266 (logPath, "OnboardingActivityPartial.cs", 32, "Android.Views.View", "Android.Widget.TextView");
			AssertHaveCompilerError (haveError, "OnboardingActivityPartial.cs", 32);

			haveError = HaveCompilerError_CS0266 (logPath, "OnboardingActivity.cs", 26, "Android.Views.View", "Android.Widget.TextView");
			AssertHaveCompilerError (haveError, "OnboardingActivity.cs", 26);
		}

		[Test]
		public void FailedBuildFew_ConflictingButton ()
		{
			RunTest ("FailedBuildFew_ConflictingButton", false, FailedBuild_ConflictingButton_RunTest);
		}

		[Test]
		public void FailedBuildMany_ConflictingButton ()
		{
			RunTest ("FailedBuildMany_ConflictingButton", true, FailedBuild_ConflictingButton_RunTest);
		}

		void FailedBuild_ConflictingButton_RunTest (string testName, bool many, LocalBuilder builder)
		{
			string[] parameters = GetBuildProperties (many, "NOT_CONFLICTING_BUTTON");
			bool success = builder.Build (TestProjectPath, "SignAndroidPackage", parameters);

			CopyLogs (testName, true);
			Assert.That (success, Is.False, "Build should have failed");

			string logPath = GetTestLogPath (testName);
			bool haveError = HaveCompilerError_CS0266 (logPath, "OnboardingActivityPartial.cs", 34, "Android.Views.View", "Android.Widget.Button");
			AssertHaveCompilerError (haveError, "OnboardingActivityPartial.cs", 34);

			haveError = HaveCompilerError_CS0266 (logPath, "OnboardingActivity.cs", 28, "Android.Views.View", "Android.Widget.Button");
			AssertHaveCompilerError (haveError, "OnboardingActivity.cs", 28);
		}

		[Test]
		public void FailedBuildFew_ConflictingLinearLayout ()
		{
			RunTest ("FailedBuildFew_ConflictingLinearLayout", false, FailedBuild_ConflictingLinearLayout_RunTest);
		}

		[Test]
		public void FailedBuildMany_ConflictingLinearLayout ()
		{
			RunTest ("FailedBuildMany_ConflictingLinearLayout", true, FailedBuild_ConflictingLinearLayout_RunTest);
		}

		void FailedBuild_ConflictingLinearLayout_RunTest (string testName, bool many, LocalBuilder builder)
		{
			string[] parameters = GetBuildProperties (many, "NOT_CONFLICTING_LINEARLAYOUT");
			bool success = builder.Build (TestProjectPath, "SignAndroidPackage", parameters);

			CopyLogs (testName, true);
			Assert.That (success, Is.False, "Build should have failed");

			string logPath = GetTestLogPath (testName);
			bool haveError = HaveCompilerError_CS0266 (logPath, "OnboardingActivityPartial.cs", 41, "Android.Views.View", "Android.Widget.LinearLayout");
			AssertHaveCompilerError (haveError, "OnboardingActivityPartial.cs", 41);

			haveError = HaveCompilerError_CS0266 (logPath, "OnboardingActivity.cs", 35, "Android.Views.View", "Android.Widget.LinearLayout");
			AssertHaveCompilerError (haveError, "OnboardingActivity.cs", 35);
		}

		[Test]
		public void FailedBuildFew_ConflictingRelativeLayout ()
		{
			RunTest ("FailedBuildFew_ConflictingRelativeLayout", false, FailedBuild_ConflictingRelativeLayout_RunTest);
		}

		[Test]
		public void FailedBuildMany_ConflictingRelativeLayout ()
		{
			RunTest ("FailedBuildMany_ConflictingRelativeLayout", true, FailedBuild_ConflictingRelativeLayout_RunTest);
		}

		void FailedBuild_ConflictingRelativeLayout_RunTest (string testName, bool many, LocalBuilder builder)
		{
			string[] parameters = GetBuildProperties (many, "NOT_CONFLICTING_RELATIVELAYOUT");
			bool success = builder.Build (TestProjectPath, "SignAndroidPackage", parameters);

			CopyLogs (testName, true);
			Assert.That (success, Is.False, "Build should have failed");

			string logPath = GetTestLogPath (testName);
			bool haveError = HaveCompilerError_CS0266 (logPath, "OnboardingActivityPartial.cs", 43, "Android.Views.View", "Android.Widget.RelativeLayout");
			AssertHaveCompilerError (haveError, "OnboardingActivityPartial.cs", 43);

			haveError = HaveCompilerError_CS0266 (logPath, "OnboardingActivity.cs", 37, "Android.Views.View", "Android.Widget.RelativeLayout");
			AssertHaveCompilerError (haveError, "OnboardingActivity.cs", 37);
		}

		string[] GetBuildProperties (bool manyBuild, params string[] extraConstants)
		{
			var ret = new List <string> ();
			if (manyBuild)
				ret.Add ("ForceParallelBuild=true");

			if (extraConstants != null && extraConstants.Length > 0) {
				string extras = String.Join (";", extraConstants);
				ret.Add ($"ExtraConstants={extras}");
			}

			return ret.ToArray ();
		}

		void AssertHaveCompilerError (bool haveError, string fileName, int line)
		{
			Assert.That (haveError, Is.True, $"Expected compiler error CS0266 in {fileName}({line},?)");
		}

		void RunTest (string testName, bool many, Action<string, bool, LocalBuilder> runner)
		{
			ResetProject (testName);
			LocalBuilder builder = GetBuilder ($"{ProjectName}.{testName}");

			try {
				runner (testName, many, builder);

				if (many) {
					Assert.That (WasParsedInParallel (testName), Is.True, "Should have been parsed in parallel");
					Assert.That (WasGeneratedInParallel (testName), Is.True, "Should have been generated in parallel");
				} else {
					Assert.That (WasParsedInParallel (testName), Is.False, "Should have been parsed in serial manner");
					Assert.That (WasGeneratedInParallel (testName), Is.False, "Should have been generated in serial manner");
				}
			} catch {
				CopyLogs (testName, false);
				throw;
			}
		}

		bool WasParsedInParallel (string testName)
		{
			var regex = new Regex ($"^\\s*Parsing layouts in parallel.*$", RegexOptions.Compiled);
			return FileMatches (regex, GetTestLogPath (testName));
		}

		bool WasGeneratedInParallel (string testName)
		{
			var regex = new Regex ($"^\\s*Generating binding code in parallel.*$", RegexOptions.Compiled);
			return FileMatches (regex, GetTestLogPath (testName));
		}

		bool HaveCompilerError_CS0266 (string logFile, string sourceFile, int line, string typeFrom, string typeTo)
		{
			var regex = new Regex ($"^{Regexify(sourceFile)}\\({line},\\d+\\): [^\\s]+ CS0266:[^']+'{Regexify(typeFrom)}'[^']+'{Regexify(typeTo)}'.*$", RegexOptions.Compiled);
			return FileMatches (regex, logFile);
		}

		bool SourceHasProperty (string sourceFile, string visibility, string typeName, string propertyName, bool isExpression = true)
		{
			return SourceHasMember (sourceFile, visibility, typeName, propertyName, false, null, isExpression);
		}

		bool SourceHasMethod (string sourceFile, string visibility, string typeName, string methodName, string arguments)
		{
			return SourceHasMember (sourceFile, visibility, typeName, methodName, true, arguments, false);
		}

		bool SourceHasMember (string sourceFile, string visibility, string typeName, string memberName, bool isMethod, string arguments, bool isExpression)
		{
			Regex regex;

			if (isMethod) {
				regex = new Regex ($"^\\s+{visibility}\\s+{Regexify(typeName)}\\s+{Regexify(memberName)}\\s+\\({Regexify(arguments)}\\).*$");
			} else {
				string propertyCodeStart = isExpression ? "=>" : "{";
				regex = new Regex ($"^\\s+{visibility}\\s+{Regexify(typeName)}\\s+{Regexify(memberName)}\\s+{propertyCodeStart}.*$", RegexOptions.Compiled);
			}
			return FileMatches (regex, sourceFile);
		}

		bool FileMatches (Regex regex, string inputFile)
		{
			using (var sr = new StreamReader (inputFile)) {
				string text;
				while ((text = sr.ReadLine ()) != null) {
					if (regex.IsMatch (text))
						return true;
				}
			}

			return false;
		}

		string Regexify (string input)
		{
			if (input == null)
				throw new ArgumentNullException (nameof (input));
			return input
				.Replace (".", "\\.")
				.Replace ("(", "\\(")
				.Replace (")", "\\)")
				.Replace ("[", "\\[")
				.Replace ("]", "\\]")
				.Replace ("{", "\\{")
				.Replace ("}", "\\}");
		}

		[OneTimeSetUp]
		public void BuildTestsSetUp ()
		{
			if (!File.Exists (TestProjectPath))
				throw new InvalidOperationException ($"Test project '{TestProjectPath}' not found");
		}

		void ResetProject (string testName)
		{
			RemoveDir (TestProjectObjPath);
			RemoveDir (TestProjectBinPath);

			string outputDir = GetTestOutputDir (testName);
			if (Directory.Exists (outputDir))
				Directory.Delete (outputDir, true);

			RemoveLogs (testName);
		}

		void RemoveLogs (string testName)
		{
			RemoveFile (GetTestLogName (testName));
			foreach (string log in log_files) {
				RemoveFile (log);
			}

			foreach (string logFile in Directory.EnumerateFiles (TestProjectRootDirectory, $"{ProjectName}.*.log")) {
				File.Delete (logFile);
			}
		}

		LocalBuilder GetBuilder (string baseLogFileName)
		{
			return new LocalBuilder {
				Verbosity = LoggerVerbosity.Diagnostic,
				BuildLogFile = $"{baseLogFileName}.log"
			};
		}

		void CopyLogs (string testName, bool assert)
		{
			string destDir = GetTestOutputDir (testName);

			AssertExistsAndCopy (testName, GetTestLogName (testName), destDir, assert);
			foreach (string log in log_files) {
				AssertExistsAndCopy (testName, log, destDir, assert);
			}
		}

		string GetTestLogName (string testName)
		{
			return $"{ProjectName}.{testName}.log";
		}

		string GetTestLogPath (string testName)
		{
			return Path.Combine (TestProjectRootDirectory, GetTestLogName (testName));
		}

		string GetTestOutputDir (string testName)
		{
			return Path.Combine (TestOutputDir, testName, XABuildPaths.Configuration);
		}

		void CopyGeneratedFiles (string testName)
		{
			string destDir = Path.Combine (GetTestOutputDir (testName), "generated");

			foreach (SourceFile src in generated_sources) {
				AssertExistsAndCopy (testName, src.Path, destDir);
			}
		}

		void AssertExistsAndCopy (string testName, string relativeFilePath, string destDir, bool nunitAssert = true)
		{
			string source = Path.Combine (TestProjectRootDirectory, relativeFilePath);
			if (nunitAssert)
				AssertExists (testName, source);
			else if (!File.Exists (source))
				return;

			if (!Directory.Exists (destDir))
				Directory.CreateDirectory (destDir);
			string destination = Path.Combine (destDir, Path.GetFileName (relativeFilePath));
			File.Copy (source, destination, true);
		}

		void AssertExists (string testName, string filePath)
		{
			Assert.That (new FileInfo (filePath), Does.Exist, $"file {filePath} should exist");
		}

		void RemoveFile (string relativeFilePath)
		{
			string path = Path.Combine (TestProjectRootDirectory, relativeFilePath);
			if (!File.Exists (path))
				return;
			File.Delete (path);
		}

		void RemoveDir (string relativeDirPath)
		{
			string path = Path.Combine (TestProjectRootDirectory, relativeDirPath);
			if (!Directory.Exists (path))
				return;
			Directory.Delete (path, true);
		}
	}
}
