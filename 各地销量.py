from pyecharts import Map
import webbrowser
import pymssql
connect = pymssql.connect(host="127.0.0.1:51576",user="sa",password="yxh12138",database="2021040614",charset="utf8")
cursor = connect.cursor()   #创建一个游标对象,python里的sql语句都要通过cursor来执行
sql = "select * from shengfen  where 厂商='上海汽车'"
cursor.execute(sql)   #执行sql语句
row = cursor.fetchone()  #读取查询结果,
name=[]
data=[]
while row:              #循环读取所有结果
    name.append(row[1])
    data.append(row[2])
    row = cursor.fetchone()
cursor.close()
connect.close()
# map = Map("name_map -> dict定义地图名称", width=1200, height=600)
map = Map("上海汽车各地订单分析", width=1800, height=800)
map.add(
    "",  # name -> str图例名称
    name,  # attr -> list属性名称
    data,  # value -> list属性所对应的值
    maptype="china",  # maptype -> str   地图类型。 从 v0.3.2+ 起，地图已经变为扩展包，支持全国省份，全国城市，全国区县，全球国家等地图
    is_label_show=False,  # 显示各区域名称
    # is_map_symbol_show=True,   #is_map_symbol_show -> bool  是否显示地图标记红点，默认为 True。
    is_map_symbol_show=False,  # 设置 is_map_symbol_show=False 取消显示标记红点
    # is_roam -> bool/str 是否开启鼠标缩放和平移漫游。默认为 True 如果只想要开启缩放或者平移，可以设置成'scale'或者'move'。设置成 True 为都开启
    is_roam=True,
    # Visualmap 使用
    is_visualmap=True,
    visual_range=[0, max(data)],
    is_more_utils=False,
    visual_text_color="#000",

    # Note： 可以按右边的下载按钮将图片下载到本地，如果想要提供更多实用工具按钮，请在 add() 中设置 is_more_utils 为 True
    # is_more_utils=True
)
# map.render()#输出默认       render.html
map.render(path='上海汽车各地订单分析.html')
webbrowser.open("上海汽车各地订单分析.html")