using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        /// 工作开始时间    
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime WtStartDateTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime WtOverDateTime { get; set; }
        /// <summary>
        /// 班组
        /// </summary>
        public int TeamEntityId { get; set; }
        public virtual  TeamEntity  TeamEntity   { get; set; }
        /// <summary>
        /// 站点
        /// </summary>
        [ForeignKey("StationEntity")]
        public int StationEntityId { get; set; }
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
