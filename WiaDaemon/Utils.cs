using System;
using System.Collections;
using System.Diagnostics;
using System.IO;

namespace WiaDaemon {
	public static class Utils {
		public static string FormatEnvironment(String input) {
			string output = input.Clone() as string;
			
			foreach(DictionaryEntry e in Environment.GetEnvironmentVariables()) {
				output = output.Replace($"%{e.Key}%", e.Value as string);
			}

			return output;
		}
		
		
		public static string GetTempFilePathWithExtension(string extension, string basePath = null) {
			string path;
			if (basePath == null) path = Path.GetTempPath();
			else path                  = basePath;
			
			var fileName = Path.ChangeExtension(Guid.NewGuid().ToString(), extension);
			return Path.Combine(path, fileName);
		}
		
		public static void OpenWithDefaultProgram(string path) {
			using (Process fileopener = new Process()) {
				fileopener.StartInfo.FileName  = "explorer";
				fileopener.StartInfo.Arguments = "\"" + path + "\"";
				fileopener.Start();
			}
		}
		
		public class File {
			public string FullPath { set; get; }

			public string Filename {
				get {
					return System.IO.Path.GetFileName(this.FullPath);
				}
			}
			public string FilenameWithoutExtension {
				get {
					return System.IO.Path.GetFileNameWithoutExtension(this.FullPath);
				}
			}
			public string Extension {
				get {
					return System.IO.Path.GetExtension(this.FullPath);
				}
			}

			public File(string path) {
				this.FullPath = path;
			}
		}
	}
}