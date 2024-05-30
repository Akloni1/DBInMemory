using Apache.Ignite.Core;
using Apache.Ignite.Core.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;

namespace NoSqlDBInMemory.Controllers
{
    [ApiController]
    [Route("/api")]
    public class NoSqlDbController : ControllerBase
    {
        [HttpGet]
        [Route("Products")]
        public async Task<IActionResult> GetProducts()
        {
            var clientConfiguration = new IgniteClientConfiguration
            {
                Endpoints = new List<string>
                    {
                    "apache"
                    }
            };

            using (var igniteClient = Ignition.StartClient(clientConfiguration))
            {
                var cacheClient = igniteClient.GetOrCreateCache<string, string>("Marketplace");
                var contentCache = Task.Run(() =>
                {
                    return cacheClient.GetAsync("Products");
                });
                await contentCache;
            }

            return NoContent();
        }

        [HttpGet]
        [Route("Page")]
        public async Task<IActionResult> GetPage()
        {



            var clientConfiguration = new IgniteClientConfiguration
            {
                Endpoints = new List<string>
                    {
                    "apache"
                    }
            };

            using (var igniteClient = Ignition.StartClient(clientConfiguration))
            {
                var cacheClient = igniteClient.GetOrCreateCache<string, byte[]>("Marketplace");
                var content = Task.Run(() =>
                {
                    return cacheClient.GetAsync("https://localhost:7025/home/render");
                });
                await content;
            }





            return NoContent();
        }

        [HttpGet]
        [Route("Doc")]
        public async Task<IActionResult> GetDoc()
        {
            var clientConfiguration = new IgniteClientConfiguration
            {
                Endpoints = new List<string>
                    {
                    "apache"
                    }
            };

            using (var igniteClient = Ignition.StartClient(clientConfiguration))
            {
                var cacheClient = igniteClient.GetOrCreateCache<string, byte[]>("Marketplace");
                var contentCache = Task.Run(() =>
                {
                    return cacheClient.GetAsync("content");
                });
                await contentCache;
            }

            return NoContent();
        }

        [HttpGet]
        [Route("Set")]
        public async Task<IActionResult> Set()
        {

            var page = "&lt;!DOCTYPE html&gt;\r\n&lt;html lang=&quot;en&quot;&gt;\r\n&lt;head&gt;\r\n    &lt;meta charset=&quot;utf-8&quot; /&gt;\r\n    &lt;meta name=&quot;viewport&quot; content=&quot;width=device-width, initial-scale=1.0&quot; /&gt;\r\n    &lt;title&gt; - Marketplace.Web&lt;/title&gt;\r\n    &lt;link rel=&quot;stylesheet&quot; href=&quot;/lib/bootstrap/dist/css/bootstrap.min.css&quot; /&gt;\r\n    &lt;link rel=&quot;stylesheet&quot; href=&quot;/css/site.css?v=AKvNjO3dCPPS0eSU1Ez8T2wI280i08yGycV9ndytL-c&quot; /&gt;\r\n    &lt;link rel=&quot;stylesheet&quot; href=&quot;/css/bootstrap-datetimepicker.css&quot; /&gt;\r\n    &lt;link rel=&quot;stylesheet&quot; href=&quot;/Marketplace.Web.styles.css?v=hsdQ8HMZWw4g6_ni5itcP-5JZJVNLQRS10ALbTZSsnM&quot; /&gt;\r\n    &lt;link rel=&quot;stylesheet&quot; href=&quot;https://use.fontawesome.com/releases/v5.15.3/css/all.css&quot; integrity=&quot;sha384-SZXxX4whJ79/gErwcOYf+zWLeJdY/qpuqC4cAa9rOGUstPomtqpuNWT9wdPEn2fk&quot; crossorigin=&quot;anonymous&quot;&gt;\r\n&lt;/head&gt;\r\n&lt;body&gt;\r\n    &lt;header b-0amikuq6jw&gt;\r\n        &lt;nav b-0amikuq6jw class=&quot;navbar navbar-expand-sm navbar-toggleable-sm navbar-dark bg-dark border-bottom box-shadow mb-3&quot;&gt;\r\n            &lt;div b-0amikuq6jw class=&quot;container-fluid&quot;&gt;\r\n                &lt;a class=&quot;navbar-brand&quot; href=&quot;/&quot;&gt;&lt;img b-0amikuq6jw width=&quot;35px&quot; src=&quot;/Images/logo.png&quot; /&gt; Marketplace&lt;/a&gt;\r\n                &lt;button b-0amikuq6jw class=&quot;navbar-toggler&quot; type=&quot;button&quot; data-bs-toggle=&quot;collapse&quot; data-bs-target=&quot;.navbar-collapse&quot; aria-controls=&quot;navbarSupportedContent&quot;\r\n                        aria-expanded=&quot;false&quot; aria-label=&quot;Toggle navigation&quot;&gt;\r\n                    &lt;span b-0amikuq6jw class=&quot;navbar-toggler-icon&quot;&gt;&lt;/span&gt;\r\n                &lt;/button&gt;\r\n                &lt;div b-0amikuq6jw class=&quot;navbar-collapse collapse d-sm-inline-flex flex-sm-row-reverse&quot;&gt;\r\n                    &lt;ul class=&quot;navbar-nav&quot;&gt;\r\n\t\t&lt;li class=&quot;nav-item&quot;&gt;\r\n\t\t\t&lt;a class=&quot;nav-link&quot; href=&quot;/Home/Login&quot;&gt;Войти&lt;/a&gt;\r\n\t\t&lt;/li&gt;\r\n&lt;/ul&gt;\r\n                    &lt;ul b-0amikuq6jw class=&quot;navbar-nav flex-grow-1&quot;&gt;\r\n                        &lt;li b-0amikuq6jw class=&quot;nav-item pt-lg-1&quot;&gt;\r\n                            &lt;a class=&quot;nav-link&quot; href=&quot;/&quot;&gt;Главная&lt;/a&gt;\r\n                        &lt;/li&gt;\r\n                        &lt;li b-0amikuq6jw class=&quot;nav-item pt-lg-1&quot;&gt;\r\n                            &lt;a class=&quot;nav-link&quot; href=&quot;/Product/ProductIndex&quot;&gt;Товары&lt;/a&gt;\r\n                        &lt;/li&gt;\r\n                        &lt;li b-0amikuq6jw class=&quot;nav-item pt-lg-1&quot;&gt;\r\n                            &lt;a class=&quot;nav-link&quot; href=&quot;/Document/DocumentIndex&quot;&gt;Документы&lt;/a&gt;\r\n                        &lt;/li&gt;\r\n                        &lt;li b-0amikuq6jw class=&quot;nav-item pt-lg-1&quot;&gt;\r\n                            &lt;a class=&quot;nav-link&quot; href=&quot;/Cart/CartIndex&quot;&gt;\r\n                                &lt;i b-0amikuq6jw class=&quot;fas fa-shopping-cart&quot;&gt;&lt;/i&gt;\r\n                            &lt;/a&gt;\r\n                        &lt;/li&gt;\r\n                    &lt;/ul&gt;\r\n                &lt;/div&gt;\r\n            &lt;/div&gt;\r\n        &lt;/nav&gt;\r\n    &lt;/header&gt;\r\n    &lt;div b-0amikuq6jw class=&quot;container&quot;&gt;\r\n        &lt;main b-0amikuq6jw role=&quot;main&quot; class=&quot;pb-3&quot;&gt;\r\n            \r\n&lt;form&gt;\r\n\r\n    &lt;div class=&quot;container row&quot;&gt;\r\n\r\n            &lt;div class=&quot;col-4 &quot;&gt;\r\n                &lt;div class=&quot;p-0 my-3 border&quot;&gt;\r\n                    &lt;div class=&quot;card&quot;&gt;\r\n                        &lt;img src=&quot;/Images/chasi.jpeg&quot; class=&quot;card-img-top&quot;&gt;\r\n                        &lt;div class=&quot;card-body&quot;&gt;\r\n                            &lt;h3 class=&quot;card-title text-success&quot;&gt;&amp;#x41C;&amp;#x443;&amp;#x436;&amp;#x441;&amp;#x43A;&amp;#x438;&amp;#x435; &amp;#x447;&amp;#x430;&amp;#x441;&amp;#x44B;&lt;/h3&gt;\r\n                            &lt;span class=&quot;badge badge-light mb-2 &quot;&gt;&amp;#x422;&amp;#x435;&amp;#x445;&amp;#x43D;&amp;#x438;&amp;#x43A;&amp;#x430;&lt;/span&gt;\r\n                            &lt;p class=&quot;card-text&quot;&gt;Мужские часы кварцевые.&lt;/p&gt;\r\n                            &lt;div class=&quot;row&quot;&gt;\r\n                                &lt;div class=&quot;col pt-1&quot;&gt;\r\n                                    &lt;span style=&quot;font-size:23px;&quot;&gt;15&amp;#xA0;000,00 &amp;#x20BD;&lt;/span&gt;\r\n                                &lt;/div&gt;\r\n                                &lt;div class=&quot;col&quot;&gt;\r\n                                    &lt;a class=&quot;btn btn-success form-control&quot; href=&quot;/Home/Details/23&quot;&gt;Детали&lt;/a&gt;\r\n                                &lt;/div&gt;\r\n\r\n                            &lt;/div&gt;\r\n\r\n                        &lt;/div&gt;\r\n                    &lt;/div&gt;\r\n                &lt;/div&gt;\r\n            &lt;/div&gt;\r\n            &lt;div class=&quot;col-4 &quot;&gt;\r\n                &lt;div class=&quot;p-0 my-3 border&quot;&gt;\r\n                    &lt;div class=&quot;card&quot;&gt;\r\n                        &lt;img src=&quot;/Images/coffecar.jpg&quot; class=&quot;card-img-top&quot;&gt;\r\n                        &lt;div class=&quot;card-body&quot;&gt;\r\n                            &lt;h3 class=&quot;card-title text-success&quot;&gt;&amp;#x41A;&amp;#x43E;&amp;#x444;&amp;#x435;&amp;#x43C;&amp;#x430;&amp;#x448;&amp;#x438;&amp;#x43D;&amp;#x430;&lt;/h3&gt;\r\n                            &lt;span class=&quot;badge badge-light mb-2 &quot;&gt;&amp;#x422;&amp;#x435;&amp;#x445;&amp;#x43D;&amp;#x438;&amp;#x43A;&amp;#x430;&lt;/span&gt;\r\n                            &lt;p class=&quot;card-text&quot;&gt;Кофемашина.&lt;/p&gt;\r\n                            &lt;div class=&quot;row&quot;&gt;\r\n                                &lt;div class=&quot;col pt-1&quot;&gt;\r\n                                    &lt;span style=&quot;font-size:23px;&quot;&gt;30&amp;#xA0;000,00 &amp;#x20BD;&lt;/span&gt;\r\n                                &lt;/div&gt;\r\n                                &lt;div class=&quot;col&quot;&gt;\r\n                                    &lt;a class=&quot;btn btn-success form-control&quot; href=&quot;/Home/Details/24&quot;&gt;Детали&lt;/a&gt;\r\n                                &lt;/div&gt;\r\n\r\n                            &lt;/div&gt;\r\n\r\n                        &lt;/div&gt;\r\n                    &lt;/div&gt;\r\n                &lt;/div&gt;\r\n            &lt;/div&gt;\r\n            &lt;div class=&quot;col-4 &quot;&gt;\r\n                &lt;div class=&quot;p-0 my-3 border&quot;&gt;\r\n                    &lt;div class=&quot;card&quot;&gt;\r\n                        &lt;img src=&quot;/Images/iphone11.jpg&quot; class=&quot;card-img-top&quot;&gt;\r\n                        &lt;div class=&quot;card-body&quot;&gt;\r\n                            &lt;h3 class=&quot;card-title text-success&quot;&gt;Iphone 11&lt;/h3&gt;\r\n                            &lt;span class=&quot;badge badge-light mb-2 &quot;&gt;&amp;#x422;&amp;#x435;&amp;#x445;&amp;#x43D;&amp;#x438;&amp;#x43A;&amp;#x430;&lt;/span&gt;\r\n                            &lt;p class=&quot;card-text&quot;&gt;Iphone 11.&lt;/p&gt;\r\n                            &lt;div class=&quot;row&quot;&gt;\r\n                                &lt;div class=&quot;col pt-1&quot;&gt;\r\n                                    &lt;span style=&quot;font-size:23px;&quot;&gt;45&amp;#xA0;000,00 &amp;#x20BD;&lt;/span&gt;\r\n                                &lt;/div&gt;\r\n                                &lt;div class=&quot;col&quot;&gt;\r\n                                    &lt;a class=&quot;btn btn-success form-control&quot; href=&quot;/Home/Details/25&quot;&gt;Детали&lt;/a&gt;\r\n                                &lt;/div&gt;\r\n\r\n                            &lt;/div&gt;\r\n\r\n                        &lt;/div&gt;\r\n                    &lt;/div&gt;\r\n                &lt;/div&gt;\r\n            &lt;/div&gt;\r\n            &lt;div class=&quot;col-4 &quot;&gt;\r\n                &lt;div class=&quot;p-0 my-3 border&quot;&gt;\r\n                    &lt;div class=&quot;card&quot;&gt;\r\n                        &lt;img src=&quot;/Images/koffe.jpeg&quot; class=&quot;card-img-top&quot;&gt;\r\n                        &lt;div class=&quot;card-body&quot;&gt;\r\n                            &lt;h3 class=&quot;card-title text-success&quot;&gt;&amp;#x41A;&amp;#x43E;&amp;#x444;&amp;#x435;&lt;/h3&gt;\r\n                            &lt;span class=&quot;badge badge-light mb-2 &quot;&gt;&amp;#x41F;&amp;#x440;&amp;#x43E;&amp;#x434;&amp;#x443;&amp;#x43A;&amp;#x442;&amp;#x44B; &amp;#x43F;&amp;#x438;&amp;#x442;&amp;#x430;&amp;#x43D;&amp;#x438;&amp;#x44F;&lt;/span&gt;\r\n                            &lt;p class=&quot;card-text&quot;&gt;Кофе.&lt;/p&gt;\r\n                            &lt;div class=&quot;row&quot;&gt;\r\n                                &lt;div class=&quot;col pt-1&quot;&gt;\r\n                                    &lt;span style=&quot;font-size:23px;&quot;&gt;450,00 &amp;#x20BD;&lt;/span&gt;\r\n                                &lt;/div&gt;\r\n                                &lt;div class=&quot;col&quot;&gt;\r\n                                    &lt;a class=&quot;btn btn-success form-control&quot; href=&quot;/Home/Details/26&quot;&gt;Детали&lt;/a&gt;\r\n                                &lt;/div&gt;\r\n\r\n                            &lt;/div&gt;\r\n\r\n                        &lt;/div&gt;\r\n                    &lt;/div&gt;\r\n                &lt;/div&gt;\r\n            &lt;/div&gt;\r\n            &lt;div class=&quot;col-4 &quot;&gt;\r\n                &lt;div class=&quot;p-0 my-3 border&quot;&gt;\r\n                    &lt;div class=&quot;card&quot;&gt;\r\n                        &lt;img src=&quot;/Images/kolonka.jpg&quot; class=&quot;card-img-top&quot;&gt;\r\n                        &lt;div class=&quot;card-body&quot;&gt;\r\n                            &lt;h3 class=&quot;card-title text-success&quot;&gt;&amp;#x41A;&amp;#x43E;&amp;#x43B;&amp;#x43E;&amp;#x43D;&amp;#x43A;&amp;#x430; JBL&lt;/h3&gt;\r\n                            &lt;span class=&quot;badge badge-light mb-2 &quot;&gt;&amp;#x422;&amp;#x435;&amp;#x445;&amp;#x43D;&amp;#x438;&amp;#x43A;&amp;#x430;&lt;/span&gt;\r\n                            &lt;p class=&quot;card-text&quot;&gt;Колонка JBL.&lt;/p&gt;\r\n                            &lt;div class=&quot;row&quot;&gt;\r\n                                &lt;div class=&quot;col pt-1&quot;&gt;\r\n                                    &lt;span style=&quot;font-size:23px;&quot;&gt;16&amp;#xA0;990,00 &amp;#x20BD;&lt;/span&gt;\r\n                                &lt;/div&gt;\r\n                                &lt;div class=&quot;col&quot;&gt;\r\n                                    &lt;a class=&quot;btn btn-success form-control&quot; href=&quot;/Home/Details/27&quot;&gt;Детали&lt;/a&gt;\r\n                                &lt;/div&gt;\r\n\r\n                            &lt;/div&gt;\r\n\r\n                        &lt;/div&gt;\r\n                    &lt;/div&gt;\r\n                &lt;/div&gt;\r\n            &lt;/div&gt;\r\n            &lt;div class=&quot;col-4 &quot;&gt;\r\n                &lt;div class=&quot;p-0 my-3 border&quot;&gt;\r\n                    &lt;div class=&quot;card&quot;&gt;\r\n                        &lt;img src=&quot;/Images/multivarka.jpg&quot; class=&quot;card-img-top&quot;&gt;\r\n                        &lt;div class=&quot;card-body&quot;&gt;\r\n                            &lt;h3 class=&quot;card-title text-success&quot;&gt;&amp;#x41C;&amp;#x443;&amp;#x43B;&amp;#x44C;&amp;#x442;&amp;#x438;&amp;#x432;&amp;#x430;&amp;#x440;&amp;#x43A;&amp;#x430;&lt;/h3&gt;\r\n                            &lt;span class=&quot;badge badge-light mb-2 &quot;&gt;&amp;#x422;&amp;#x435;&amp;#x445;&amp;#x43D;&amp;#x438;&amp;#x43A;&amp;#x430;&lt;/span&gt;\r\n                            &lt;p class=&quot;card-text&quot;&gt;Мультиварка.&lt;/p&gt;\r\n                            &lt;div class=&quot;row&quot;&gt;\r\n                                &lt;div class=&quot;col pt-1&quot;&gt;\r\n                                    &lt;span style=&quot;font-size:23px;&quot;&gt;7&amp;#xA0;490,00 &amp;#x20BD;&lt;/span&gt;\r\n                                &lt;/div&gt;\r\n                                &lt;div class=&quot;col&quot;&gt;\r\n                                    &lt;a class=&quot;btn btn-success form-control&quot; href=&quot;/Home/Details/28&quot;&gt;Детали&lt;/a&gt;\r\n                                &lt;/div&gt;\r\n\r\n                            &lt;/div&gt;\r\n\r\n                        &lt;/div&gt;\r\n                    &lt;/div&gt;\r\n                &lt;/div&gt;\r\n            &lt;/div&gt;\r\n            &lt;div class=&quot;col-4 &quot;&gt;\r\n                &lt;div class=&quot;p-0 my-3 border&quot;&gt;\r\n                    &lt;div class=&quot;card&quot;&gt;\r\n                        &lt;img src=&quot;/Images/obogrevatel.jpg&quot; class=&quot;card-img-top&quot;&gt;\r\n                        &lt;div class=&quot;card-body&quot;&gt;\r\n                            &lt;h3 class=&quot;card-title text-success&quot;&gt;&amp;#x41E;&amp;#x431;&amp;#x43E;&amp;#x433;&amp;#x440;&amp;#x435;&amp;#x432;&amp;#x430;&amp;#x442;&amp;#x435;&amp;#x43B;&amp;#x44C;&lt;/h3&gt;\r\n                            &lt;span class=&quot;badge badge-light mb-2 &quot;&gt;&amp;#x422;&amp;#x435;&amp;#x445;&amp;#x43D;&amp;#x438;&amp;#x43A;&amp;#x430;&lt;/span&gt;\r\n                            &lt;p class=&quot;card-text&quot;&gt;Обогреватель.&lt;/p&gt;\r\n                            &lt;div class=&quot;row&quot;&gt;\r\n                                &lt;div class=&quot;col pt-1&quot;&gt;\r\n                                    &lt;span style=&quot;font-size:23px;&quot;&gt;9&amp;#xA0;990,00 &amp;#x20BD;&lt;/span&gt;\r\n                                &lt;/div&gt;\r\n                                &lt;div class=&quot;col&quot;&gt;\r\n                                    &lt;a class=&quot;btn btn-success form-control&quot; href=&quot;/Home/Details/29&quot;&gt;Детали&lt;/a&gt;\r\n                                &lt;/div&gt;\r\n\r\n                            &lt;/div&gt;\r\n\r\n                        &lt;/div&gt;\r\n                    &lt;/div&gt;\r\n                &lt;/div&gt;\r\n            &lt;/div&gt;\r\n            &lt;div class=&quot;col-4 &quot;&gt;\r\n                &lt;div class=&quot;p-0 my-3 border&quot;&gt;\r\n                    &lt;div class=&quot;card&quot;&gt;\r\n                        &lt;img src=&quot;/Images/ytug.jpg&quot; class=&quot;card-img-top&quot;&gt;\r\n                        &lt;div class=&quot;card-body&quot;&gt;\r\n                            &lt;h3 class=&quot;card-title text-success&quot;&gt;&amp;#x423;&amp;#x442;&amp;#x44E;&amp;#x433;&lt;/h3&gt;\r\n                            &lt;span class=&quot;badge badge-light mb-2 &quot;&gt;&amp;#x422;&amp;#x435;&amp;#x445;&amp;#x43D;&amp;#x438;&amp;#x43A;&amp;#x430;&lt;/span&gt;\r\n                            &lt;p class=&quot;card-text&quot;&gt;Утюг.&lt;/p&gt;\r\n                            &lt;div class=&quot;row&quot;&gt;\r\n                                &lt;div class=&quot;col pt-1&quot;&gt;\r\n                                    &lt;span style=&quot;font-size:23px;&quot;&gt;16&amp;#xA0;000,00 &amp;#x20BD;&lt;/span&gt;\r\n                                &lt;/div&gt;\r\n                                &lt;div class=&quot;col&quot;&gt;\r\n                                    &lt;a class=&quot;btn btn-success form-control&quot; href=&quot;/Home/Details/30&quot;&gt;Детали&lt;/a&gt;\r\n                                &lt;/div&gt;\r\n\r\n                            &lt;/div&gt;\r\n\r\n                        &lt;/div&gt;\r\n                    &lt;/div&gt;\r\n                &lt;/div&gt;\r\n            &lt;/div&gt;\r\n            &lt;div class=&quot;col-4 &quot;&gt;\r\n                &lt;div class=&quot;p-0 my-3 border&quot;&gt;\r\n                    &lt;div class=&quot;card&quot;&gt;\r\n                        &lt;img src=&quot;/Images/zont.jpg&quot; class=&quot;card-img-top&quot;&gt;\r\n                        &lt;div class=&quot;card-body&quot;&gt;\r\n                            &lt;h3 class=&quot;card-title text-success&quot;&gt;&amp;#x417;&amp;#x43E;&amp;#x43D;&amp;#x442;&lt;/h3&gt;\r\n                            &lt;span class=&quot;badge badge-light mb-2 &quot;&gt;&amp;#x410;&amp;#x43A;&amp;#x441;&amp;#x435;&amp;#x441;&amp;#x441;&amp;#x443;&amp;#x430;&amp;#x440;&amp;#x44B; &amp;#x434;&amp;#x43B;&amp;#x44F; &amp;#x43F;&amp;#x43E;&amp;#x432;&amp;#x441;&amp;#x435;&amp;#x434;&amp;#x43D;&amp;#x435;&amp;#x432;&amp;#x43D;&amp;#x43E;&amp;#x433;&amp;#x43E; &amp;#x438;&amp;#x441;&amp;#x43F;&amp;#x43E;&amp;#x43B;&amp;#x44C;&amp;#x437;&amp;#x43E;&amp;#x432;&amp;#x430;&amp;#x43D;&amp;#x438;&amp;#x44F;&lt;/span&gt;\r\n                            &lt;p class=&quot;card-text&quot;&gt;Зонт.&lt;/p&gt;\r\n                            &lt;div class=&quot;row&quot;&gt;\r\n                                &lt;div class=&quot;col pt-1&quot;&gt;\r\n                                    &lt;span style=&quot;font-size:23px;&quot;&gt;1&amp;#xA0;500,00 &amp;#x20BD;&lt;/span&gt;\r\n                                &lt;/div&gt;\r\n                                &lt;div class=&quot;col&quot;&gt;\r\n                                    &lt;a class=&quot;btn btn-success form-control&quot; href=&quot;/Home/Details/31&quot;&gt;Детали&lt;/a&gt;\r\n                                &lt;/div&gt;\r\n\r\n                            &lt;/div&gt;\r\n\r\n                        &lt;/div&gt;\r\n                    &lt;/div&gt;\r\n                &lt;/div&gt;\r\n            &lt;/div&gt;\r\n            &lt;div class=&quot;col-4 &quot;&gt;\r\n                &lt;div class=&quot;p-0 my-3 border&quot;&gt;\r\n                    &lt;div class=&quot;card&quot;&gt;\r\n                        &lt;img src=&quot;/Images/chasi.jpeg&quot; class=&quot;card-img-top&quot;&gt;\r\n                        &lt;div class=&quot;card-body&quot;&gt;\r\n                            &lt;h3 class=&quot;card-title text-success&quot;&gt;22222&lt;/h3&gt;\r\n                            &lt;span class=&quot;badge badge-light mb-2 &quot;&gt;2222&lt;/span&gt;\r\n                            &lt;p class=&quot;card-text&quot;&gt;222222&lt;/p&gt;\r\n                            &lt;div class=&quot;row&quot;&gt;\r\n                                &lt;div class=&quot;col pt-1&quot;&gt;\r\n                                    &lt;span style=&quot;font-size:23px;&quot;&gt;12&amp;#xA0;222,00 &amp;#x20BD;&lt;/span&gt;\r\n                                &lt;/div&gt;\r\n                                &lt;div class=&quot;col&quot;&gt;\r\n                                    &lt;a class=&quot;btn btn-success form-control&quot; href=&quot;/Home/Details/32&quot;&gt;Детали&lt;/a&gt;\r\n                                &lt;/div&gt;\r\n\r\n                            &lt;/div&gt;\r\n\r\n                        &lt;/div&gt;\r\n                    &lt;/div&gt;\r\n                &lt;/div&gt;\r\n            &lt;/div&gt;\r\n\r\n    &lt;/div&gt;\r\n&lt;/form&gt;\r\n        &lt;/main&gt;\r\n    &lt;/div&gt;\r\n\r\n    &lt;footer b-0amikuq6jw class=&quot;border-top footer text-muted bg-dark&quot;&gt;\r\n        &lt;div b-0amikuq6jw class=&quot;container&quot;&gt;\r\n            &amp;copy; 2024 - Marketplace.Web\r\n        &lt;/div&gt;\r\n    &lt;/footer&gt;\r\n    &lt;script src=&quot;/lib/jquery/dist/jquery.min.js&quot;&gt;&lt;/script&gt;\r\n    &lt;script src=&quot;/lib/bootstrap/dist/js/bootstrap.bundle.min.js&quot;&gt;&lt;/script&gt;\r\n    &lt;script src=&quot;/js/site.js?v=4q1jwFhaPaZgr8WAUSrux6hAuh0XDg9kPS3xIVq36I0&quot;&gt;&lt;/script&gt;\r\n    &lt;script src=&quot;/js/bootstrap-datetimepicker.js&quot;&gt;&lt;/script&gt;\r\n    \r\n&lt;/body&gt;\r\n&lt;/html&gt;";
            var pageByte = Encoding.UTF8.GetBytes(page);
            //await _cache.SetAsync("https://localhost:7025/home/render", pageByte, options);

            var products = "[{\"Id\":23,\"Name\":\"Мужские часы\",\"Price\":15000.0,\"Description\":\"Мужские часы кварцевые.\",\"CategoryName\":\"Техника\",\"ImageUrl\":\"/Images/chasi.jpeg\"},{\"Id\":24,\"Name\":\"Кофемашина\",\"Price\":30000.0,\"Description\":\"Кофемашина.\",\"CategoryName\":\"Техника\",\"ImageUrl\":\"/Images/coffecar.jpg\"},{\"Id\":25,\"Name\":\"Iphone 11\",\"Price\":45000.0,\"Description\":\"Iphone 11.\",\"CategoryName\":\"Техника\",\"ImageUrl\":\"/Images/iphone11.jpg\"},{\"Id\":26,\"Name\":\"Кофе\",\"Price\":450.0,\"Description\":\"Кофе.\",\"CategoryName\":\"Продукты питания\",\"ImageUrl\":\"/Images/koffe.jpeg\"},{\"Id\":27,\"Name\":\"Колонка JBL\",\"Price\":16990.0,\"Description\":\"Колонка JBL.\",\"CategoryName\":\"Техника\",\"ImageUrl\":\"/Images/kolonka.jpg\"},{\"Id\":28,\"Name\":\"Мультиварка\",\"Price\":7490.0,\"Description\":\"Мультиварка.\",\"CategoryName\":\"Техника\",\"ImageUrl\":\"/Images/multivarka.jpg\"},{\"Id\":29,\"Name\":\"Обогреватель\",\"Price\":9990.0,\"Description\":\"Обогреватель.\",\"CategoryName\":\"Техника\",\"ImageUrl\":\"/Images/obogrevatel.jpg\"},{\"Id\":30,\"Name\":\"Утюг\",\"Price\":16000.0,\"Description\":\"Утюг.\",\"CategoryName\":\"Те...";
            // await _cache.SetStringAsync("Products", products, options);

            var dirClone = Path.GetFullPath(Path.Combine("doc.docx"));
            var content = await System.IO.File.ReadAllBytesAsync(dirClone);
            //  await _cache.SetAsync("content", content, options);



            var clientConfiguration = new IgniteClientConfiguration
            {
                Endpoints = new List<string>
                    {
                    "apache"
                    }
            };

            using (var igniteClient = Ignition.StartClient(clientConfiguration))
            {
                var cacheClient = igniteClient.GetOrCreateCache<string, byte[]>("Marketplace");
                var cacheClientstr = igniteClient.GetOrCreateCache<string, string>("Marketplace");
                cacheClient.Put("content", content);
                cacheClient.Put("https://localhost:7025/home/render", pageByte);
                cacheClientstr.Put("Products", products);
            }

            return NoContent();
        }

        [HttpGet]
        [Route("Test")]
        public async Task<IActionResult> Test()
        {
            return Ok();
        }
    }
}
