#Sitefinity Easy Dynamic Content

Grabbing content from Dynamic Content Modules in sitefinity is needlessly verbose.
This static helper class will provide an easy method to grab content from dyanmic modules.

## Installation ##

1. Clone the repo into your custom directory for application
2. Change the namespace to where you have put the class

## Usage ##

To get all live content from the custom content type "Resource":

````c#
EasyDynamicContent.GetAllContentByDyanamicType("Telerik.Sitefinity.DynamicTypes.Model.Resources.Resource");
````

To get all content from the custom content type "Resource":

````c#
EasyDynamicContent.GetAllContentByDyanamicType("Telerik.Sitefinity.DynamicTypes.Model.Resources.Resource", false);
````
To get all content from the custom content type "Resource" with flat taxonomy term "test" in the field categories:

````c#
EasyDynamicContent.GetContentByFlatTaxonomyTerm("Telerik.Sitefinity.DynamicTypes.Model.Resources.Resource", "test", "categories");
````

If the taxonomy term is not found it will throw an exception