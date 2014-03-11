using System;
using System.Text;
using DotNetNuke;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Controllers;
using DotNetNuke.Framework.Providers;

public class Module_Info : DotNetNuke.Entities.Modules.PortalModuleBase
{
	public void get_info(string AuthKey, int ModuleID = 0, int TabID = 0)
	{

		if (AuthKey.Trim().ToLower() == "true") 
		{
			StringBuilder str_debug = new StringBuilder();
			str_debug.AppendLine("<table>");
			str_debug.AppendLine("<tr><td>Version:</td><td>" + "" + "</td></tr>");
			str_debug.AppendLine("<tr><td>Data Provider:</td><td>" +  ProviderConfiguration.GetProviderConfiguration("data").DefaultProvider + "</td></tr>");
			str_debug.AppendLine("<tr><td>.NET Framework:</td><td>" + Environment.Version.ToString() + "</td></tr>");
			str_debug.AppendLine("<tr><td>Identity:</td><td>" + WindowsIdentity.GetCurrent().Name + "</td></tr>");
			str_debug.AppendLine("<tr><td>DNS Host Name:</td><td>" + Dns.GetHostName() + "</td></tr>");
			str_debug.AppendLine("<tr><td>SMTP Server:</td><td>" + HostController.Instance.GetString("SMTPServer") + "</td></tr>");
			str_debug.AppendLine("<tr><td>Performance Setting:</td><td>" + HostController.Instance.GetString("PerformanceSetting") + "</td></tr>");
			str_debug.AppendLine("<tr><td colspan=\"2\"><hr></td></tr>");
			str_debug.AppendLine("<tr><td>Host Title:</td><td>" + HostController.Instance.GetString("HostTitle") + "</td></tr>");
			str_debug.AppendLine("<tr><td>Host Email:</td><td><a href=\"mailto:" + HostController.Instance.GetString("HostEmail") + "\">" + HostController.Instance.GetString("HostEmail") + "</a></td></tr>");
			str_debug.AppendLine("<tr><td>Host URL:</td><td>" + HostController.Instance.GetString("HostURL") + "</td></tr>");
			str_debug.AppendLine("<tr><td>Friendly URLs:</td><td>" + HostController.Instance.GetString("UseFriendlyUrls") + "</td></tr>");
			str_debug.AppendLine("<tr><td colspan=\"2\"><hr></td></tr>");
			str_debug.AppendLine("<tr><td>Portal Title:</td><td>" + PortalSettings.PortalName + "</td></tr>");
			str_debug.AppendLine("<tr><td>Portal Email:</td><td><a href=\"mailto:" + PortalSettings.Email + "\">" + PortalSettings.Email + "</a></td></tr>");
			str_debug.AppendLine("<tr><td>Portal Alias:</td><td>" + PortalSettings.PortalAlias.HTTPAlias + "</td></tr>");
			str_debug.AppendLine("<tr><td>Portal ID:</td><td>" + PortalSettings.PortalAlias.PortalID.ToString() + "</td></tr>");
				
			if (ModuleID > 0 & TabID > 0) 
			{
				ModuleController obj_module = new ModuleController();
				DesktopModuleInfo obj_module_info = DesktopModuleController.GetDesktopModule(ModuleID, PortalId);
				Hashtable obj_module_settings = new Hashtable();
				obj_module_settings = obj_module.GetModuleSettings(ModuleID);

				str_debug.AppendLine("<tr><td colspan=\"2\"><hr></td></tr>");
				str_debug.AppendLine("<tr><td>Module Name:</td><td>" + obj_module_info.FriendlyName + "</td></tr>");
				str_debug.AppendLine("<tr><td>Module Version:</td><td>" + obj_module_info.Version + "</td></tr>");
				foreach (DictionaryEntry obj_module_setting in obj_module_settings)
				{
					str_debug.AppendLine("<tr><td>" + obj_module_setting.Key.ToString().Trim() + "</td><td>" + obj_module_setting.Value.ToString().Trim() + "</td></tr>");
				}
				str_debug.AppendLine("<tr><td colspan=\"2\"><hr></td></tr>");
			}

			str_debug.AppendLine("<tr><td colspan=\"2\"><hr></td></tr>");
			str_debug.AppendLine("<tr><td>Application Directory:</td><td>" + DotNetNuke.Common.Globals.ApplicationPath + "</td></tr>");
			str_debug.AppendLine("<tr><td>Application Path:</td><td>" + DotNetNuke.Common.Globals.ApplicationMapPath + "</td></tr>");
			str_debug.AppendLine("<tr><td>Host Directory:</td><td>" + DotNetNuke.Common.Globals.HostPath + "</td></tr>");
			str_debug.AppendLine("<tr><td>Host Path:</td><td>" + DotNetNuke.Common.Globals.HostMapPath + "</td></tr>");
			str_debug.AppendLine("<tr><td>Portal Directory:</td><td>" + PortalSettings.HomeDirectory + "</td></tr>");
			str_debug.AppendLine("<tr><td>Portal Path:</td><td>" + PortalSettings.HomeDirectoryMapPath + "</td></tr>");
			str_debug.AppendLine("<tr><td colspan=\"2\"><hr></td></tr>");
			str_debug.AppendLine("</table>");
				
			System.Web.HttpContext.Current.Response.Write(str_debug.ToString() + "<br />");
		}

	}



}

