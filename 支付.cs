using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Data.SqlClient;

namespace i_car1
{
    public partial class 支付 : Form
    {
        public SqlConnection conn;
        public 支付()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            string constr = @"Server=.\sqlexpress;Database=2021040614;Integrated security=True;";
            conn = new SqlConnection(constr);
        }

        private void 支付_Load(object sender, EventArgs e)
        {
            uiLabel3.Text = Class1.订单号;
            uiLabel2.Text = (Class1.总价 * 0.2).ToString()+"元";
            string sql = @"select 邮箱 from users where 用户名=@用户名";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@用户名", SqlDbType.NVarChar, 20).Value = Class1.用户名;
            try
            {
                conn.Open();
                Class1.邮箱 = cmd.ExecuteScalar().ToString();
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "失败");
            }
            finally
            {
                conn.Close();
            }//获得要付金额，邮箱等信息

        }

        private void uiRadioButton1_ValueChanged(object sender, bool value)
        {
            int version = Convert.ToInt16("5");

            int pixel = Convert.ToInt16("7");//二维码尺寸

            string str_msg = "您需要支付的定金为："+(Class1.总价*0.2).ToString()+"元";

            bool b_we = true;
            Bitmap bmp = chestnut_qrcode.Encoder.Code(str_msg, version, pixel, b_we);
            pictureBox1.Image = bmp;
            //chestnut_qrcode.Encoder.code(str_msg, version, pixel,b_we);
            for (int i = 0; i < 1; i++)
            {
                MailMessage mymail = new MailMessage();
                mymail.From = new System.Net.Mail.MailAddress("自己的邮箱");
                mymail.To.Add(Class1.邮箱);
                mymail.Subject = "上汽集团购车合同";
                mymail.Body = @"购车合同

甲方： 上海汽车集团股份有限公司
乙方："+Class1.姓名+@"

甲乙双方就乙方向甲方购买汽车并办理按揭或乙方通过其他汽车销售商购买汽车后委托甲方办理汽车按揭相关手续等有关事宜，经友好协商，签订本合同。
汽车型号及金额
     型号："+Class1.汽车品牌+@"
     发动机号：246764K
     车架号：LSGJR52U85S110284
     车价："+Class1.总价.ToString()+@"

二、购车方式
l 、乙方向甲方购买车辆；
2 、乙方向汽车销售商购买车辆，委托甲方办理汽车按揭手续。
三、交车时间、地点及方式
l 、乙方向甲方购买的车辆，交车时间、地点以乙方提车确认单为准 。
2 、乙方向汽车销售商购买的车辆，交车时间、地点以汽车经销商及乙方签名盖章的提车确认单为准。

四 、付款方式及期限：
乙方按下列方式及期限付款
1 、 一 次 性 付 款
      乙方于本合同生效之当日一次性付清全部车款"+ Class1.总价.ToString()+@"元。
2 、分期付款
乙方于本合同生效之当日首付"+ (Class1.总价 * 0.2).ToString()+@"元 ，其余车款乙方委托甲方向中国农业银行上海市嘉定区安亭镇支行申请汽车消费贷款，年限五年。

五、权利与义务

l、汽车销售商向乙方出售的汽车，质量须符合国家颁布的汽车质量标准。
2、汽车销售商向乙方出售的汽车，须是 在 《全国汽车、民用改装车和摩托车生产企业及产品目录》上备案的产品或经交通管理部门认可的汽车。
3、汽车销售商向乙方出售汽车时须真实准确介绍所售车辆的基本情况 。
4、乙方通过其它汽车销售商购买的车辆，乙 方负有审查所购车辆证件，发票 、手续是否齐全、真实，若因此而产生的风险及责任与甲方无关 。
5、乙方应对所购车辆的功能及外观进行认真检查、确认 。
6、如乙方所购车辆发生质量间题，甲方协助乙方或协助汽车销售商与生产厂家的维修站联系、解决。

六、有关汽车按揭的约定

乙方委托甲方办理汽车按揭手续的，乙方应切实履行如下义务：
l、乙方自提车之曰起至银行贷款发生之曰止，须配合甲方及银行的资信调查工作，不得以任何理由推脱。
2、乙方提车后，须及时上牌，并把车辆登记证及购车发票原件交与甲方 。
3、按揭期内，乙方未经银行同意，不得将抵押车辆私自转让给他人；如私自转让乙方承担由此引发的全部法律责任。
4、乙方在按揭期内，须严格履行还款义务，不得以经营状况不良或交通事故等原因而影响还款义务的履行。
5、乙方不得以所购车辆发生质量问题为由 ，影响还款义务的履行 。
6、乙方签订的本合同及银行贷款合同后 ，应严格履行，不得私自更改抵押权人，若由此而生的抵押问题，乙方承担全部责任。
7、甲方为乙方办理按揭贷款手续的费用（含保证金 、续保定金、担保手续 费、工本费等） ，由乙方承担。乙方贷款期内必须履行保险义务 ，乙 方的续保定 金在贷款期最后一年充抵保金 ，相关手续由甲方负责办理 。若乙方不履行保险义务，由此产生的法律后果乙方承担。
8、乙方若变更住址及联系电话，必须在变更后三日内通知甲方及贷款银行，否则应承担由此而产生的法律责任。

七、违约责任

l、本合同生效后，一方不履行合同的，应依法承担违约责任；造成另一方损失的还应赔偿对方的损失。
2、乙方不履行按揭付款义务的，除按按揭贷款合同承担法律责任外，还应赔偿甲方由此而造成的损失（包括利息、罚息、调查费、律师代理费等）。

八、合同争议解决的方式

本合同履行过程中若有争议，双方应友好协商解决，若协商不成，任何一 方均可向甲方所在地人民法院诉讼解决。

九、本合同所指的汽车销售商 ，系 指乙方所购汽车的开票单位。

十、本合同一式叁份，签字盖章之日起生效。甲、乙双方各执一份，借款银行备案一份。

甲方：上海汽车集团股份有限公司
联系电话：021 - 28902890

乙 方："+Class1.姓名+@"
联系电话：

";
                mymail.IsBodyHtml = true;
                SmtpClient smtpclient = new SmtpClient();
                smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpclient.Host = "smtp.qq.com";
                smtpclient.Credentials = new System.Net.NetworkCredential("自己的邮箱", "oxlmqrjhozczjiaj");
                try
                {
                    smtpclient.Send(mymail);
                    Console.WriteLine("发送成功");


                }
                catch (Exception ex)
                {
                    Console.WriteLine("发送邮件失败.请检查是否为qq邮箱，并且没有被防护软件拦截");

                }//发送邮件
            }
            string sql = @"update order1 set 支付状态='是' where 订单编号=@订单编号 ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "失败");
            }
            finally
            {
                conn.Close();
            }
        }//更新支付状态

        private void uiRadioButton2_ValueChanged(object sender, bool value)
        {
            int version = Convert.ToInt16("5");

            int pixel = Convert.ToInt16("7");

            string str_msg = "您需要支付的定金为：" + (Class1.总价 * 0.2).ToString() + "元";

            bool b_we = true;
            Bitmap bmp = chestnut_qrcode.Encoder.Code(str_msg, version, pixel, b_we);
            pictureBox1.Image = bmp;
            //chestnut_qrcode.Encoder.code(str_msg, version, pixel,b_we);
            for (int i = 0; i < 1; i++)
            {
                MailMessage mymail = new MailMessage();
                mymail.From = new System.Net.Mail.MailAddress("自己的邮箱");
                mymail.To.Add(Class1.邮箱);
                mymail.Subject = "上汽集团购车合同";
                mymail.Body = @"购车合同

甲方： 上海汽车集团股份有限公司
乙方：" + Class1.姓名 + @"

甲乙双方就乙方向甲方购买汽车并办理按揭或乙方通过其他汽车销售商购买汽车后委托甲方办理汽车按揭相关手续等有关事宜，经友好协商，签订本合同。
汽车型号及金额
     型号：" + Class1.汽车品牌 + @"
     发动机号：246764K
     车架号：LSGJR52U85S110284
     车价：" + Class1.总价.ToString() + @"

二、购车方式
l 、乙方向甲方购买车辆；
2 、乙方向汽车销售商购买车辆，委托甲方办理汽车按揭手续。
三、交车时间、地点及方式
l 、乙方向甲方购买的车辆，交车时间、地点以乙方提车确认单为准 。
2 、乙方向汽车销售商购买的车辆，交车时间、地点以汽车经销商及乙方签名盖章的提车确认单为准。

四 、付款方式及期限：
乙方按下列方式及期限付款
1 、 一 次 性 付 款
      乙方于本合同生效之当日一次性付清全部车款" + Class1.总价.ToString() + @"元。
2 、分期付款
乙方于本合同生效之当日首付" + (Class1.总价 * 0.2).ToString() + @"元 ，其余车款乙方委托甲方向中国农业银行上海市嘉定区安亭镇支行申请汽车消费贷款，年限五年。

五、权利与义务

l、汽车销售商向乙方出售的汽车，质量须符合国家颁布的汽车质量标准。
2、汽车销售商向乙方出售的汽车，须是 在 《全国汽车、民用改装车和摩托车生产企业及产品目录》上备案的产品或经交通管理部门认可的汽车。
3、汽车销售商向乙方出售汽车时须真实准确介绍所售车辆的基本情况 。
4、乙方通过其它汽车销售商购买的车辆，乙 方负有审查所购车辆证件，发票 、手续是否齐全、真实，若因此而产生的风险及责任与甲方无关 。
5、乙方应对所购车辆的功能及外观进行认真检查、确认 。
6、如乙方所购车辆发生质量间题，甲方协助乙方或协助汽车销售商与生产厂家的维修站联系、解决。

六、有关汽车按揭的约定

乙方委托甲方办理汽车按揭手续的，乙方应切实履行如下义务：
l、乙方自提车之曰起至银行贷款发生之曰止，须配合甲方及银行的资信调查工作，不得以任何理由推脱。
2、乙方提车后，须及时上牌，并把车辆登记证及购车发票原件交与甲方 。
3、按揭期内，乙方未经银行同意，不得将抵押车辆私自转让给他人；如私自转让乙方承担由此引发的全部法律责任。
4、乙方在按揭期内，须严格履行还款义务，不得以经营状况不良或交通事故等原因而影响还款义务的履行。
5、乙方不得以所购车辆发生质量问题为由 ，影响还款义务的履行 。
6、乙方签订的本合同及银行贷款合同后 ，应严格履行，不得私自更改抵押权人，若由此而生的抵押问题，乙方承担全部责任。
7、甲方为乙方办理按揭贷款手续的费用（含保证金 、续保定金、担保手续 费、工本费等） ，由乙方承担。乙方贷款期内必须履行保险义务 ，乙 方的续保定 金在贷款期最后一年充抵保金 ，相关手续由甲方负责办理 。若乙方不履行保险义务，由此产生的法律后果乙方承担。
8、乙方若变更住址及联系电话，必须在变更后三日内通知甲方及贷款银行，否则应承担由此而产生的法律责任。

七、违约责任

l、本合同生效后，一方不履行合同的，应依法承担违约责任；造成另一方损失的还应赔偿对方的损失。
2、乙方不履行按揭付款义务的，除按按揭贷款合同承担法律责任外，还应赔偿甲方由此而造成的损失（包括利息、罚息、调查费、律师代理费等）。

八、合同争议解决的方式

本合同履行过程中若有争议，双方应友好协商解决，若协商不成，任何一 方均可向甲方所在地人民法院诉讼解决。

九、本合同所指的汽车销售商 ，系 指乙方所购汽车的开票单位。

十、本合同一式叁份，签字盖章之日起生效。甲、乙双方各执一份，借款银行备案一份。

甲方：上海汽车集团股份有限公司
联系电话：021 - 28902890

乙 方：" + Class1.姓名 + @"
联系电话：

";
                mymail.IsBodyHtml = true;
                SmtpClient smtpclient = new SmtpClient();
                smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpclient.Host = "smtp.qq.com";
                smtpclient.Credentials = new System.Net.NetworkCredential("自己的邮箱", "oxlmqrjhozczjiaj");
                try
                {
                    smtpclient.Send(mymail);
                    Console.WriteLine("发送成功");


                }
                catch (Exception ex)
                {
                    Console.WriteLine("发送邮件失败.请检查是否为qq邮箱，并且没有被防护软件拦截");

                }
            }
            string sql = @"update order1 set 支付状态='是' where 订单编号=@订单编号 ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "失败");
            }
            finally
            {
                conn.Close();
            }
        }//微信渠道
    }
}
