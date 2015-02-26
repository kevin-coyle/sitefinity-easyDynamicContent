using System;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.DynamicModules.Model;
using Telerik.Sitefinity.Modules.Libraries;
using Telerik.Sitefinity.Utilities.TypeConverters;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Data.Linq.Dynamic;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Security;
using Telerik.Sitefinity.Lifecycle;
using Telerik.Sitefinity.Taxonomies;
using Telerik.Sitefinity.Taxonomies.Model;
using Telerik.OpenAccess;
using System.Collections.Generic;
using Telerik.Sitefinity.Data.ContentLinks;
using Telerik.Sitefinity.Libraries.Model;

namespace SitefinityWebApp.Custom.Helpers
{
    public static class EasyDynamicContent
    {
        public static IQueryable<DynamicContent> GetAllContentByType(String contentType, Boolean justLive = true)
        {
            //Just use an empty string for the provider.
            var providerName = String.Empty;

            DynamicModuleManager dynamicModuleManager = DynamicModuleManager.GetManager(providerName);
            Type resourceType = TypeResolutionService.ResolveType(contentType);

            // Get all live items
            if (justLive)
            {
            return dynamicModuleManager.GetDataItems(resourceType)
                                                    .Where(d => d.Status == Telerik.Sitefinity.GenericContent.Model.ContentLifecycleStatus.Live);
            }

            return dynamicModuleManager.GetDataItems(resourceType);

        }

        public static IQueryable<DynamicContent> GetContentByFlatTaxonomyTerm(String contentType, String term, String fieldName)
        {
            var providerName = String.Empty;

            DynamicModuleManager dynamicModuleManager = DynamicModuleManager.GetManager(providerName);
            Type resourceType = TypeResolutionService.ResolveType(contentType);

            // This is how we get the resource items through filtering

            var manager = TaxonomyManager.GetManager();
            //Get the GUID of the desired category
            var category = manager.GetTaxa<FlatTaxon>().Where(t => t.Name.ToLower() == term).SingleOrDefault();

            if (category == null)
            {
                throw new InvalidProgramException("No category found");
            }
                var categoryId = category.Id;
                return dynamicModuleManager.GetDataItems(resourceType)
                                                    .Where(d => d.GetValue<TrackedList<Guid>>(fieldName).Contains(categoryId)
                                                                && d.Status == Telerik.Sitefinity.GenericContent.Model.ContentLifecycleStatus.Live);
            

            
        }
        
    }
    
}