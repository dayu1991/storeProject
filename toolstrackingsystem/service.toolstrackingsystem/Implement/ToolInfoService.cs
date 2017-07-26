using dbentity.toolstrackingsystem;
using sqlserver.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewEntity.toolstrackingsystem.view;

namespace service.toolstrackingsystem
{
   public class ToolInfoService:IToolInfoService
    {
       private IToolCategoryInfoRepository _toolCategoryInfoRepository;
       private IToolInfoRepository _toolInfoRepository;
              private IInStoreRepository _inStoreRepository;

              private ICurrentCountInfoRepository _currentCountInfoRepository;
              private IOutBackStoreRepository _outBackStoreRepository;


        private IMultiTableQueryRepository _multiTableQueryRepository;
        public ToolInfoService(IToolCategoryInfoRepository toolCategoryInfoRepository,
            IToolInfoRepository toolInfoRepository, 
            IMultiTableQueryRepository multiTableQueryRepository,
            IInStoreRepository inStoreRepository,
            ICurrentCountInfoRepository currentCountInfoRepository,
            IOutBackStoreRepository outBackStoreRepository)
       {
           _toolCategoryInfoRepository = toolCategoryInfoRepository;
           _toolInfoRepository = toolInfoRepository;
           _multiTableQueryRepository = multiTableQueryRepository;
            _inStoreRepository=inStoreRepository;
            _currentCountInfoRepository = currentCountInfoRepository;
            _outBackStoreRepository = outBackStoreRepository;
       }

        public List<t_ToolType> GetCategoryByClassify(int classifyType)
        {
            return _toolCategoryInfoRepository.GetCategoryByClassify(classifyType);
        }
        public long AddToolInfo(t_ToolInfo toolInfo)
        {
            _toolInfoRepository.Add(toolInfo);
            var entity = new t_InStore();
            entity.InStoreTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            entity.OptionPerson = toolInfo.OptionPerson;
            entity.ToolCode = toolInfo.ToolCode;
            entity.ToolName = toolInfo.ToolName;
            entity.TypeName = toolInfo.TypeName;
            entity.ChildTypeName = toolInfo.ChildTypeName;
            entity.OptionPerson = toolInfo.OptionPerson;
            _inStoreRepository.Add(entity);
            var entity1 = new t_CurrentCountInfo();
            entity1.TypeName = toolInfo.TypeName;
            entity1.ChildTypeName = toolInfo.ChildTypeName;
            entity1.ToolCode = toolInfo.ToolCode;
            entity1.ToolName = toolInfo.ToolName;
            entity1.Models = toolInfo.Models;
            entity1.Location = toolInfo.Location;
            entity1.Remarks = toolInfo.Remarks;
            entity1.InStoreTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            entity1.OptionType = "录入";
            entity1.OptionPerson = toolInfo.OptionPerson;
            return _currentCountInfoRepository.Add(entity1);
        }

        /// <summary>
        /// 是否存在编号的工具
        /// </summary>
        /// <param name="toolCode"></param>
        /// <returns></returns>
        public bool IsExistsByCode(string toolCode)
        {
            return _toolInfoRepository.IsExistsByCode(toolCode);
        }

        /// <summary>
        /// 获取工具列表
        /// </summary>
        /// <param name="blongValue"></param>
        /// <param name="categoryValue"></param>
        /// <param name="toolCode"></param>
        /// <param name="toolName"></param>
        /// <returns></returns>
        public List<t_ToolInfo> GetToolList(string blongValue, string categoryValue, string toolCode, string toolName, int pageIndex, int pageSize, out long totalCount)
        {
            return _toolInfoRepository.GetToolList(blongValue, categoryValue, toolCode, toolName,pageIndex,pageSize,out totalCount);
        }
        public t_ToolInfo GetToolByCode(string toolCode)
        {
            return _toolInfoRepository.GetToolByCode(toolCode);
        }
        public bool UpdateTool(t_ToolInfo entity)
        {
            return _toolInfoRepository.UpdateTool(entity);
        }

        public bool DelToolByCode(string ToolCode)
        {
            return _toolInfoRepository.DelToolByCode(ToolCode);
        }
        public List<t_ToolInfo> GetToolList(string blongValue, string categoryValue, string toolCode, string toolName)
        {
            return _toolInfoRepository.GetToolList(blongValue, categoryValue, toolCode, toolName);
        }
        public bool IsExistCategoryByName(string name, int classification)
        {
            return _toolCategoryInfoRepository.IsExistCategoryByName(name, classification);

        }
        public long AddCateGory(t_ToolType category)
        {
            return _toolCategoryInfoRepository.Add(category);

        }

        public bool IsExistsInStoryByCode(string toolCode)
        {
            return _inStoreRepository.IsExistsInStoryByCode(toolCode);
        }

        public bool OutStore(t_ToolInfo entity, t_PersonInfo person, string userCode,string toDate,string describ)
        {
            _inStoreRepository.DeleteByCode(entity.ToolCode);
            var outBackStore = new t_OutBackStore();
            outBackStore.ToolCode = entity.ToolCode;
            outBackStore.ToolName = entity.ToolName;
            outBackStore.OutStoreTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            outBackStore.PersonCode = person.PersonCode;
            outBackStore.PersonName = person.PersonName;

            outBackStore.UserTimeInfo = toDate;
            outBackStore.IsBack = "0";
            outBackStore.outdescribes = toDate;
            outBackStore.OptionPerson = userCode;
            outBackStore.IsCredit = "1";

            _outBackStoreRepository.Add(outBackStore);

            var currentCount = new t_CurrentCountInfo();
            currentCount.TypeName = entity.TypeName;
            currentCount.ChildTypeName = entity.ChildTypeName;
            currentCount.PackCode = entity.PackCode;
            currentCount.PackName = entity.PackName;
            currentCount.ToolCode = entity.ToolCode;


            currentCount.ToolName = entity.ToolName;
            currentCount.Models = entity.Models;
            currentCount.Location = entity.Location;
            currentCount.Remarks = entity.Remarks;
            currentCount.OutStoreTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            currentCount.OptionType = "领用";
            currentCount.PersonCode = person.PersonCode;
            currentCount.PersonName = person.PersonName;
            currentCount.describes = describ;
            currentCount.OptionPerson = userCode;
            return _currentCountInfoRepository.Add(currentCount)>0;

        }

    }
}
