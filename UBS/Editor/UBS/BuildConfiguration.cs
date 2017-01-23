using System;
using UnityEngine;
using System.IO;


namespace UBS
{
	[Serializable]
	public class BuildConfiguration
	{
		public void Initialize ()
		{
			DirectoryInfo di = new DirectoryInfo( Application.dataPath );

			AssetsDirectory = di.FullName;
			ResourcesDirectory = Path.Combine( AssetsDirectory , "Resources");
			ProjectDirectory = di.Parent.FullName;
		}

		/// <summary>
		/// Params can be set in the Build Collection editor for each build step. Your build step can read the params from the collection. 
		/// </summary>
		/// <value>The parameters.</value>
		public string Params {
			get;
			private set;
		}

		internal void SetParams(string pParams)
		{
			Params = pParams;
		}

		[SerializeField]
		string mResourcesDirectory;

		
		[SerializeField]
		string mAssetsDirectory;

		[SerializeField]
		string mProjectDirectory;

		public string ResourcesDirectory
		{
			get { return mResourcesDirectory; }
			private set { mResourcesDirectory = value; }
		}

		public string AssetsDirectory
		{
			get { return mAssetsDirectory; }
			private set { mAssetsDirectory = value; }
		}

		public string ProjectDirectory
		{
			get { return mProjectDirectory; }
			private set { mProjectDirectory = value; }
		}

		public BuildProcess GetCurrentBuildProcess()
		{
			
			UBSProcess ubs = UBSProcess.LoadUBSProcess();
			BuildProcess process = ubs.GetCurrentProcess();
			return process;
		}

		public BuildCollection GetCurrentBuildCollection()
		{
			UBSProcess ubs = UBSProcess.LoadUBSProcess();
			return ubs.BuildCollection;
		}

		public void Cancel(string pMessage)
		{
			UBSProcess ubs = UBSProcess.LoadUBSProcess();
			ubs.Cancel(pMessage);
		}

		/// <summary>
		/// Returns an instance of a class you define, which has the start up parameters set in its properties. 
		/// The class should derive from ProgramOptions and have atleast on OptionAttribute on one of its properties. 
		/// </summary>
		/// <returns>The program options.</returns>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static T GetProgramOptions<T>() where T : ProgramOptions
		{
			string[] arguments = System.Environment.GetCommandLineArgs();
			ProgramOptions po = ProgramOptions.CreateInstance<T>(arguments);
			return po as T;
		}
	}
}

