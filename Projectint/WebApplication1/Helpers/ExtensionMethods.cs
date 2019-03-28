using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Helpers
{
    public static class ExtensionMethods
    {

        public static IEnumerable<SelectListItem> ToSelectListItems(
              this IEnumerable<Intervention> App)
        {
            return
                App.OrderBy(ar => ar.Description)
                      .Select(ar =>
                          new SelectListItem
                          {
                              
                              Text = ar.Description.ToString(),
                              Value=ar.Description.ToString()
                          });
        }
       


        public static IEnumerable<SelectListItem> ToSelectListItems(
            this IEnumerable<Availability> dispo)
        {
            return
                dispo.OrderBy(ar => ar.startHour)
                      .Select(ar =>
                          new SelectListItem
                          {

                              Text = ar.dateDisponobilite.ToString(),
                              Value = ar.dateDisponobilite.ToString()
                          });
        }
       
        public static IEnumerable<SelectListItem> ToSelectListItems(
                  this IEnumerable<Speciality> spec)
        {
            return
                spec.OrderBy(ar => ar.nom)
                      .Select(ar =>
                          new SelectListItem
                          {

                              Text = ar.nom.ToString(),
                              Value = ar.nom.ToString()
                          });
        }

    }
}