﻿namespace MorningStar.Service
{
    /// <summary>
    /// 测试实现类
    /// </summary>
    public class TestService : SqlSugarRepository<TestEntity>, ITestService
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public TestService()
        {

        }

        #region 公共

        #endregion

        #region 业务
        /// <summary>
        /// 初始化测试数据
        /// </summary>
        public void InitDatas()
        {
            var list = GetListAsync().GetAwaiter().GetResult();
            if (list.Count == 0)
            {
                for (int i = 1; i < 25; i++)
                    list.Add(new TestEntity() { ID = i });
                if (list.Count != 0)
                    InsertRangeAsync(list).GetAwaiter().GetResult();
            }
        }

        /// <summary>
        /// 获取测试数据分页
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页大小</param>
        /// <returns></returns>
        public async Task<PageViewModel<TestEntity>> GetPage(int pageIndex, int pageSize)
        {
            var result = new PageViewModel<TestEntity>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                ViewModelList = []
            };

            var filter = Expressionable.Create<TestEntity>().ToExpression();
            RefAsync<int> count = 0;
            var list = await AsQueryable()
                                    .OrderByDescending(_ => _.MTime)
                                    .OrderBy(_ => _.OrderIndex)
                                    .Where(filter)
                                    .ToPageListAsync(pageIndex, pageSize, count);
            result.TotalCount = count;
            result.ViewModelList = list;

            return result;
        }

        /// <summary>
        /// 获取测试数据详情
        /// </summary>
        /// <param name="id">测试数据ID</param>
        /// <returns></returns>
        public async Task<TestEntity> GetDetail(long id)
        {
            return await GetByIdAsync(id) ?? throw new Exception("无效的测试数据ID！");
        }

        /// <summary>
        /// 保存测试数据
        /// </summary>
        /// <param name="model">保存测试数据WebModel</param>
        /// <returns></returns>
        public async Task SaveTest(SaveTestWebModel model)
        {
            if (model.ID == 0)// 新增
            {
                var list = await GetListAsync();
                var maxID = list?.Max(_ => _.ID) ?? 0;
                await InsertAsync(new TestEntity() { ID = maxID + 1 });
            }
            else// 编辑
            {
                _ = await GetByIdAsync(model.ID) ?? throw new Exception("无效的测试数据ID！");
                // todo:
            }
        }

        /// <summary>
        /// 删除测试数据
        /// </summary>
        /// <param name="id">测试数据ID</param>
        /// <returns></returns>
        public async Task DeleteTest(long id)
        {
            var en = await GetByIdAsync(id) ?? throw new Exception("无效的测试数据ID！");
            await DeleteAsync(en);
        }
        #endregion
    }
}
