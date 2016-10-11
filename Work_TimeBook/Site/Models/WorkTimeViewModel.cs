using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity.Model;

namespace Site.Models
{
    public class WorkTimeViewModel
    {
        public WorkTimeViewModel()
        {
            CreateTime = DateTime.Now;

        }
       
        public int WorkTimeId { get; set; }
        /// <summary>
        /// 工作开始时间    
        /// </summary>
      
        public DateTime WtStartDateTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
  
        public DateTime WtOverDateTime { get; set; }
        /// <summary>
        /// 班组
        /// </summary>
        public int TeamEntityIds { get; set; }

        public IEnumerable<SelectListItem> SelectStationid { get; set; }
        /// <summary>
        /// 站点
        /// </summary>
        public int StationEntityIds { get; set; }
       

        /// <summary>
        /// 工时数
        /// </summary>
        public float WtValue { get; set; }
        /// <summary>
        /// 工作人员
        /// </summary>


        /// <summary>
        /// 工作内容
        /// </summary>
        public string WtContent { get; set; }

        public string Remarks { get; set; }
        public DateTime CreateTime { get; set; }
        public IEnumerable<string> fucks { get; set; }
    }
}