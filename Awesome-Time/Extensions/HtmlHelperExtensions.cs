using Awesome_Time.ServiceClasses;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

public static class HtmlExtensions
{
    public static IHtmlString DescriptionFor<TModel, TValue>(
        this HtmlHelper<TModel> html,
        Expression<Func<TModel, TValue>> expression)
    {
        var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
        var description = metadata.Description;
        return new HtmlString(description);
    }

    public static IHtmlString Pager(this HtmlHelper html, string action, string controller, Pager pager, object routeValues = null)
    {
        var first = "First";
        var previous = "Previous";
        var next = "Next";
        var last = "Last";

        var htmlAttributes = new Dictionary<string, object>();
        
        var baseRouteDictionary = new RouteValueDictionary(routeValues);
        baseRouteDictionary.Add("pageSize", pager.PageSize);

        var body = new StringBuilder();

        body.Append("<ul class=\"pagination\">");

        //Render First and Previous buttons
        if(pager.CurrentPage > 1)
        {
            body.AppendLine("<li>");
            //add pageSize = pager.PageSize
            body.AppendLine(html.ActionLink(first, action,  controller, baseRouteDictionary, htmlAttributes).ToHtmlString());
            body.AppendLine("</li>");

            body.AppendLine("<li>");
            //add page = pager.CurrentPage - 1
            //add pageSize = pager.PageSize
            var previousDictionary = new RouteValueDictionary(baseRouteDictionary);
            previousDictionary.Add("page", pager.CurrentPage - 1);
            body.AppendLine(html.ActionLink(previous, action, controller, previousDictionary, htmlAttributes).ToHtmlString());
            body.AppendLine("</li>");
        }
        //Render all page buttons
        for(var page = pager.StartPage; page <= pager.EndPage; page++)
        {
            if (page == pager.CurrentPage)
            {//Set class to active as this is the current page
                body.AppendLine("<li class=\"active\">");
            }
            else
            {
                body.AppendLine("<li>");
            }
            //add page = page
            //add pageSize = pager.PageSize
            var thisDictionary = new RouteValueDictionary(baseRouteDictionary);
            thisDictionary.Add("page", page);
            body.AppendLine(html.ActionLink(page.ToString(), action, controller, thisDictionary, htmlAttributes).ToHtmlString());
            body.AppendLine("</li>");
        }
        //Render Next and Last buttons
        if(pager.CurrentPage < pager.TotalPages)
        {
            body.AppendLine("<li>");
            //add page = page.CurrentPage + 1
            //add pageSize = pager.PageSize
            var nextDictionary = new RouteValueDictionary(baseRouteDictionary);
            nextDictionary.Add("page", pager.CurrentPage + 1);
            body.AppendLine(html.ActionLink(next, action, controller, nextDictionary, htmlAttributes).ToHtmlString());
            body.AppendLine("</li>");
            body.AppendLine("<li>");
            //add page = page.TotalPages
            //add pageSize = pager.PageSize
            var lastDictionary = new RouteValueDictionary(baseRouteDictionary);
            lastDictionary.Add("page", pager.TotalPages);
            body.AppendLine(html.ActionLink(last, action, controller, lastDictionary, htmlAttributes).ToHtmlString());
            body.AppendLine("</li>");
        }

        body.Append("</ul>");

        return new HtmlString(body.ToString());
    }
}