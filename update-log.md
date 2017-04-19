## <center>   更新日志  </center>

#### 2017-04-18

1. 修复质量回溯的查询条件以及人员信息

   ​

#### 2016-11-28

1.修改数据库 T_Employee 添加字段 isDeleted [bool]

2.添加表 T_Employee_DeleteBak 和 T_Employee 的结构是一样的
```
     SELECT * FROM T_Employee into T_Employee_DeleteBak where 1 = 2
```
3.修改表 T_MaterialOutput 的字段 EmployeeName ===> EmployeeID

4.菜单表修改

5. 质量回溯-->报告下载

#### 2016-11-27
1.基本完成用户系统

#### 2016-11-06
1.  完成了纠结好多天的部署问题
    1. 安装 .net 4.5
    2. 注册 .net 到 IIS
       >   C:\Windows\Microsoft.NET\Framework<font color="red">64</font>\v4.0.30319 执行 aspnet_iis -i
    3. 在 IIS 的 ISAPI和GCI限制中设置 ASP.NET4.0 为允许
    4. 把网站的 .NET Framework 版本设置为 4.0
    5. Web.config 配置
```lang
   <system.webServer> 
        <modules runAllManagedModulesForAllRequests="true" /> 
  </system.webServer>
```


#### 2016-10-29
1. 完成界面基础数据 → 机台基础数据

2. 完成实时监控数据改变颜色

#### 2016-10-28
1. 添加报警状态信息

#### 2016-10-27
1. 添加死机曲线绘制以及报警

#### 2016-10-26
1. 给实时曲线和报警报表添加当前米数属性

#### 2016-10-25
1. 完成实时报警功能

#### 2016-10-23
1. 完成对实时曲线的关闭功能

2. 添加报警表格，并指定只能导出Excel

#### 2016-10-22
1. 完成模块实时值的显示

2. hotspot.js 添加 hp.setState(spot,newState)

3. 设置曲线添加曲线的时候不删除原先的数据

   > 还以为会画很长时间解决，原来设置addPoint(point,false)，false 为 shift 所赋值的对象，然后 chart.reDraw 就行

4. 移除曲线初始化的时候添加的随机数

5. 更改逻辑，当页面加载的时候所有曲线的数据都在缓存

6. 解决第二次点击的时候曲线不能置顶问题

7. 重拟服务器推送的关系

   > Web 1:------>N: MachineID 即使从原来的 Dictionary< string,int> ---> Dictionary< int,List< string>>极大地降低了内存开销和运算量

8. 设置曲线 X 轴的精度为 500ms

9. 设置未渲染数据缓存大小为50，,渲染数据缓存大小为500

10. 对实时曲线添加删除按钮，逻辑还未实现

#### 2016-10-21
1. 完成实时曲线动态绘制，MachineLayout.cshtml 进行注释和重构

#### 2016-10-20
1. 实时曲线从 fusioncharts 移植到 highstock, 完成基本属性添加

2. 完成 paramcode 逻辑

#### 2016-10-19
1. 完成状态更新逻辑

#### 2016-10-18
1. 添加系统设置→账户管理

2. 添加库房管理→材料查询

#### 2016-10-17
1. 修复项目施工坐标问题

#### 2016-10-09
1. 与王老师的数据服务器调试通过

#### 2016-10-08
1. 调试 TCPClient 异步接受功能通过

#### 2016-10-07
1. 调试 SignalR 推送功能通过


#### 2016-09-26

1. 设置 Fustioncharts 中 spmsline 的主题为`fint`

2. 实现一个模块，多条数据曲线实时绘制功能

3. 添加 历史查询 → 生产达成查询

#### 2014-09-25

1. 修改曲线图的绘制逻辑

2. 添加 基础数据 → 人员基础数据 

3. 添加 基础数据 → 参数类型 

#### 2014-09-24

1. 完成机台视图的CPK曲线绘制

#### 2016-09-21

1. 完成质量回溯


#### 2016-09-18

1. 添加服务器日志

2. 修正项目管理部分显示

#### 2016-09-17

1. 更改添加传感器属性

2. 更改数据库的表 `T_Machine` `T_ParamameterCode` `T_SensorModule` `T_SensorModule_T_ParameterCode` `T_MapMachineAddress` 等。

3. 增加 删除传感器 事件

#### 2016-09-16

1. mcAdmin 添加 API `changeCurrentTab(name,url)`

#### 2016-09-15

1. 基本完成项目施工

2. 添加表 T_SensorModule

3. 将 T_LayoutPicture 与 T_Machine 和 T_SensorModule 等表单联系起来了

4. 修复 HOME 键的功能

#### 2016-09-14

1.  完成项目施工

    > 修改标志简介的css样式

    > 添加标志样式按键置顶效果

2.  修复日志数据只写 TXT 而不写 SQL 的 BUG

#### 2016-09-12

1.  添加 Log4net 日志插件

    > 同时具备输出到文件和数据库的能力

#### 2016-09-11

1.  完成菜单管理界面 V1.0

    > 有时间推出 2.0 弃用 MenuLevel 字段，自适应分组，可以拖动排序等等功能

    > 修改菜单顺序还有 <font color="red">BUG</font>

#### 2016-09-10

1. 完成菜单配置界面的基本模型

2. 给 T_Menu 表添加 MenuSeq 字段

#### 2016-09-03

1. 使用 [GhostDoc][h0903-2]{:target = "_blank"} 完善了部分代码注释

2. 导入  [jsmind][h0903-1]{:target = "_blank"} 作为质量回溯图的插件

3. 初步完成机台图的前端工作

[h0903-1]: https://github.com/hizzgdev/jsmind
[h0903-2]: http://download.csdn.net/detail/y276827893/9606175

#### 2016-09-02

1.  修复 `LayoutPicture` 的点在点击的时候会出现全选状态

    > 添加了 CSS 属性 `user-select: none`

2.  添加 `mcAdmin.addTab(tabName,tabUrl)` API

3.  修复 `hotspotOfflineClass` 判别问题

#### 2016-09-01

1. [<font color="red">重构 UI 换成了基于 Bootstrap 的 H+ V4.1 模板</font>][h0901-1]{: target="_blank"}

2. 重构布局图逻辑，添加表 T_LayoutPicture, T_LayoutType

3. 更改菜单表为 T_Menu 完善菜单逻辑

[h0901-1]: http://download.csdn.net/detail/wkzd2016/9616891

#### 2016-08-28

1. 修复机台参数查找逻辑

2. 实现利用 `WebSocket` 和 `System.Timers.timer` 机制 动态刷新参数曲线

#### 2016-08-27

1. 完成 「机台参数」页面

2. 添加曲线值精度控制

3. 实现分页查询，只查询最近的十五条数据

#### 2016-08-26

1. 优化 「区域分布」的业务逻辑

2. 建立 「机台参数」的视图以及控制器

3. 添加表 T_ParameterUnit「参数单位」

#### 2016-08-24

1. 完成图片上传功能

2. 修复一些 BUG 

3. 优化逻辑，实现点和图共用


#### 2016-08-23

1. 完成图片标记的后端数据库

2. 后台与前端测试通过

3. 完成 「添加」图标功能

4. 完成 「删除」图标功能

5. 完成 「更新」图标功能，解决两个不同的`$.ligerDialog` 之间的冲突

#### 2016-08-22

1. 对 jQuery.Hotspot.js 进行了大量的重构，添加了些许 API

2. 完成图片标记的前端架构

#### 2016-08-21

1. 选择了 jQuery.Hotspot.js 作为图片标记的三方库

2. 添加了「车间区域分布图」的框架

#### 2016-08-20

1. 完成菜单管理功能.Version.1.0


#### 2016-08-19

1. 修改菜单详情页由 `iframe` 为 `div`

2. 删除 ~~DetailSysMenu~~

3. 修复 `dialog` 下面 table 为 `null` 的问题

#### 2016-08-19

1. 初步完成菜单编辑页面

2. 加入 DetailSysMenu 路由

#### 2016-08-18

1. 数据库调试通过

2. 三层架构调试通过

3. 菜单项架构成功

4. 实现利用 `JRaw` 传递在 JSON 中传递函数


#### 2016-08-17

2. 导入项目在 Visual Studio 中


#### 2016-08-16

1. 查看了相关的 ASP.NET MVC 的教程

2. 调试王老师给的 Demo


#### 2016-08-15

1. 接到任务