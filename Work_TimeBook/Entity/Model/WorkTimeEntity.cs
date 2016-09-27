using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class WorkTimeEntity
    {
        public WorkTimeEntity ()
        {
            CreateTime=DateTime.Now;
            
        }
        [Key]
        public int WorkTimeId { get; set; }
        /// <summary>
        /// 工作时间    
        /// </summary>
        public DateTime WtDateTime { get; set; }
        /// <summary>
        /// 班组
        /// </summary>
        public virtual  TeamEntity  TeamEntity   { get; set; }
        /// <summary>
        /// 站点
        /// </summary>
        public virtual StationEntity StationEntity { get; set; }

        /// <summary>
        /// 工时数
        /// </summary>
        public float WtValue { get; set; }
        /// <summary>
        /// 工作人员
        /// </summary>

        public IEnumerable<UserInfoEntity> UserInfoEntities { get; set; }
        /// <summary>
        /// 工作内容
        /// </summary>
        public string WtContent { get; set; }

        public string Remarks { get; set; }
        public DateTime CreateTime { get; set; }    




    }
}
