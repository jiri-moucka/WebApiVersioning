using System.Text;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace VersionsOrchestrator;

public class NamespaceRoutingConvention : IControllerModelConvention
{
	private const string BaseNamespace = "Controllers";

	public void Apply(ControllerModel controller)
	{
		var controllerTypeNamespace = controller.ControllerType.Namespace;
		if (controllerTypeNamespace is null) return;

		var routeTemplate = new StringBuilder();

		var route = controllerTypeNamespace.Replace(BaseNamespace, string.Empty);

		routeTemplate.Append(route);
		routeTemplate.Replace(".", "/");
		routeTemplate.Append("[controller]/[action]");

		foreach (var selector in controller.Selectors)
		{
			selector.AttributeRouteModel = new AttributeRouteModel
			{
				Template = routeTemplate.ToString()
			};
		}
	}
}