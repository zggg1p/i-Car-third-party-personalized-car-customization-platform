import numpy as np
import pandas as pd
import datetime
import matplotlib.pyplot as plt
import statsmodels.api as sm
from dateutil.relativedelta import relativedelta
from statsmodels.tsa.seasonal import seasonal_decompose
plt.rcParams['font.sans-serif'] = ['SimHei']
#首先处理下数据
data=pd.read_excel("data.xlsx",engine='openpyxl',index_col=0)
print(data.head(10))
data.index.name = None  # 将index的name取消
data.reset_index(inplace=True)
data.drop(data.index[64], inplace=True)
start = datetime.datetime.strptime("2003-01", "%Y-%m")  # 把一个时间字符串解析为时间元组
date_list = [start + relativedelta(months=x*3) for x in range(0, 64)]  # 从2003-01-01开始逐月增加组成list
data['index'] = date_list
data.set_index(['index'], inplace=True)
print(data.head(10))
data1 = np.array(data['传统汽车销量'], dtype=np.float)
# 生成时间序列并画图
data1 = pd.Series(data1)
data1.index = data.index
# 趋势
data1.plot(figsize=(12, 8), title='传统汽车销量')
decomposition = seasonal_decompose(data['传统汽车销量'], freq=12)
fig = plt.figure()
fig = decomposition.plot()
plt.show()
fig.set_size_inches(15, 8)
fig = plt.figure(figsize=(12, 8))
ax2 = fig.add_subplot(111)
diff2 = data1.diff(2)
diff2.plot(ax=ax2)
plt.show()
arma_mod70 = sm.tsa.ARMA(data1,(7,0)).fit()
predict_dta = arma_mod70.predict('2019', '2022', dynamic=True)
print(predict_dta)
fig, ax = plt.subplots(figsize=(12, 8))
ax = data1.ix['2000':].plot(ax=ax)
fig = arma_mod70.plot_predict('2019', '2022', dynamic=True, ax=ax, plot_insample=False)
