using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElasticsearchSampleWebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// 删除地址
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("InsertLog")]
        public void InsertLog()
        {
            //插入200条数据
            for (int i = 0; i < 200; i++)
            {
                var d = new
                {
                    Time = DateTime.Now,
                    Num = 5,
                    Name = "12313",
                    info = "hello world!"
                };
                ElasticSearchHelper.insert(d, "demo");

            }

        }

        /// <summary>
        /// 批量
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("InsertManeyLog")]
        public void InsertManeyLog()
        {
            var list = new List<object>();
            //插入200条数据
            for (int i = 0; i < 200; i++)
            {
                list.Add(new
                {
                    Time = DateTime.Now,
                    Num = 5,
                    Name = "12313",
                    info = "hello world!"
                });
            }
            ElasticSearchHelper.insertMany(list, "demo");
        }
    }
}
