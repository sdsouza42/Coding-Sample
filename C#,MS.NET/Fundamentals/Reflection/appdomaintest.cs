using System;
using System.Reflection;
using System.Security;
using System.Security.Permissions;

static class Test
{
	public static void Main()
	{
		AppDomainSetup setup = new AppDomainSetup();
		setup.ApplicationBase = "commands";

		PermissionSet permissions = new PermissionSet(PermissionState.None);
		permissions.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));
		permissions.AddPermission(new UIPermission(PermissionState.Unrestricted));

		for(;;)
		{
			Console.Write("COMMAND: ");
			string cmd = Console.ReadLine();
			if(cmd.ToLower() == "quit") break;

			AppDomain sandbox = AppDomain.CreateDomain(cmd, null, setup, permissions);
			try
			{
				sandbox.ExecuteAssemblyByName(cmd);
			}
			catch(Exception ex)
			{
				Console.WriteLine("ERROR: {0}", ex.Message);
			}
			AppDomain.Unload(sandbox);

			Console.WriteLine();
		}
	}
}
