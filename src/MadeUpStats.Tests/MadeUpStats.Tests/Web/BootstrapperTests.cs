using System;
using System.Web.Mvc;
using MadeUpStats.Web;
using MadeUpStats.Web.Controllers;
using Xunit;

namespace MadeUpStats.Tests.Web
{
    public class BootstrapperTests
    {
        public void see_what_bootstrapper_has()
        {
            var contents = Bootstrapper.Container.WhatDoIHave();
            Console.WriteLine(contents);
        }

        [Fact]
        public void can_find_objects_later_by_name()
        {
            var container = Bootstrapper.Container;
            container.GetInstance<IController>("home")
                .ShouldBeOfType<HomeController>();

            container.GetInstance<IController>("stat")
                .ShouldBeOfType<StatController>();
        }
    }
}