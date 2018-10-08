using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace BidApp
{
    public partial class Upload : Form
    {
        public Upload()
        {
            InitializeComponent();
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            ofd.ShowDialog();
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            string company_id = "TMS";
            string cust_name = string.Empty;
            string opp = string.Empty;
            string opp_date = string.Empty;
            string opp_id = string.Empty;
            string opp_comments = string.Empty;
            string customer_id = string.Empty;

            try
            {
                int nCount = 0;
                if (txtFilePath.Text != "")
                {
                    string fileName = txtFilePath.Text ;
                    
                    DataTable sheetData = new DataTable();
                    
                    using (OleDbConnection conn = this.returnConnection2(fileName) )
                    {
                        
                        conn.Open();
                        //OleDbDataAdapter sheetAdapter = new OleDbDataAdapter("select top 30000 * from [Sheet1$]", conn);
                        OleDbDataAdapter sheetAdapter = new OleDbDataAdapter("select top 7 * from ['Opp ID$']", conn);
                        sheetAdapter.Fill(sheetData);
                        conn.Close();
                    }
                    string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

                    using (SqlConnection con = new SqlConnection(connStr))
                    {
                        if (sheetData.Rows.Count > 0)
                        {
                            //SqlCommand cmd2 = new SqlCommand(truncateQry, con);
                            //con.Open();
                            //cmd2.ExecuteNonQuery();
                            //con.Close();

                            foreach (DataRow row in sheetData.Rows)
                            { //@company_id  ,@cust_name  ,@opp  ,@opp_date  ,@opp_id  ,@opp_comments
                                
                                string field = row[0].ToString();
                                string fieldvalue = row[1].ToString();
                                switch (field)
                                {
                                    case "Cust. Name":
                                        cust_name = fieldvalue;
                                        break;
                                    case "Opp:":
                                        opp = fieldvalue;
                                        break;
                                    case "Date:":
                                        opp_date = fieldvalue;
                                        break;
                                    case "Customer BT":
                                        customer_id = fieldvalue;
                                        break;
                                    case "Opp. ID:":
                                        opp_id = fieldvalue;
                                        break;
                                    case "Opp. Comments:":
                                        opp_comments = fieldvalue;
                                        break;
                                }                              
                            }
                        }
                        con.Close();
                    }
                     // MessageBox.Show(company_id + " " + cust_name + @opp + " " + opp_date + " " + opp_id + " " + opp_comments);
                    
                    //string truncateQry = "truncate table award_publication ";
                    string insertQry = "INSERT INTO [dbo].[Bid_repository] ([company_id],[cust_name] ,[opp] ,[opp_date] ,[opp_id]" +
                    ",[opp_comments] ,[customer_id],[lipsey_lane_id] ,[cust_lane_id] ,[lane_commitment] ,[origin_3zip] ,[dest_3zip] ,[origin_city]" +
                    ",[origin_st] ,[origin_zip] ,[dest_city] ,[dest_state] ,[dest_zip] ,[equip_type] ,[cust_miles] ,[pcm] ,[cust_fsc]" +
                    ",[lipsey_fsc] ,[volume] ,[volume_freq] ,[load_type] ,[unload_type] ,[origin_metro] ,[dest_metro] ,[metro_order_id]" +
                    ",[metro_avg_dst] ,[metro_avg_ttl_pay] ,[metro_avg_ttl_rev] ,[metro_mpu] ,[metro_mperct] ,[dat_avg_7] ,[dat_high_7]" +
                    ",[dat_avg_15] ,[dat_high_15] ,[dat_avg_30] ,[dat_high_30] ,[dat_avg_60] ,[dat_high_60] ,[dat_avg_90] ,[dat_high_90]" +
                    ",[dat_avg_360] ,[dat_high_360] ,[rpm_input] ,[min] ,[desired_flat_rate] ,[desired_all_in] ,[rpm_submit] ,[flat_submit]" +
                    ",[rpm_adj_submit] ,[flat_adj_submit] ,[publ_rpm] ,[publ_min_flat] ,[award_type] ,[cust_order_id] ,[cust_avg_dst] " +
                    ",[cust_avg_ttl_pay] ,[cust_avg_ttl_rev] ,[cust_mpu] ,[cust_mperct] ,[award] ,[award_volume] ,[award_rpm] ,[award_min_flat]" +
                    ",[award_eff_date] ,[award_exp_date])" +
                    "VALUES ( @company_id  ,@cust_name  ,@opp  ,@opp_date  ,@opp_id  ,@opp_comments, @customer_id  ,@lipsey_lane_id  ,@cust_lane_id  " +
                    ",@lane_commitment  ,@origin_3zip  ,@dest_3zip  ,@origin_city  ,@origin_st  ,@origin_zip  ,@dest_city  ,@dest_state  " +
                    ",@dest_zip  ,@equip_type  ,@cust_miles  ,@pcm  ,@cust_fsc  ,@lipsey_fsc ,@volume  ,@volume_freq  ,@load_type  " +
                    ",@unload_type  ,@origin_metro  ,@dest_metro  ,@metro_order_id  ,@metro_avg_dst  ,@metro_avg_ttl_pay ,@metro_avg_ttl_rev " +
                    ",@metro_mpu  ,@metro_mperct  ,@dat_avg_7  ,@dat_high_7  ,@dat_avg_15  ,@dat_high_15 ,@dat_avg_30  ,@dat_high_30  " +
                    ",@dat_avg_60  ,@dat_high_60  ,@dat_avg_90  ,@dat_high_90  ,@dat_avg_360 ,@dat_high_360  ,@rpm_input  ,@min  " +
                    ",@desired_flat_rate  ,@desired_all_in  ,@rpm_submit  ,@flat_submit ,@rpm_adj_submit  ,@flat_adj_submit  ,@publ_rpm  " +
                    ",@publ_min_flat  ,@award_type  ,@cust_order_id  ,@cust_avg_dst  ,@cust_avg_ttl_pay ,@cust_avg_ttl_rev  ,@cust_mpu  " +
                    ",@cust_mperct  ,@award  ,@award_volume  ,@award_rpm  ,@award_min_flat  ,@award_eff_date ,@award_exp_date)";

                    //string insertQry = "INSERT INTO [award_publication] ([Pricing Rate ID], [SORT (Edited)], [Sent To Publish], " +
                    //    " [Has Been Published], [Rate Number], [Company], [Customer Acknowledgement], [Source], [Parent Customer], " +
                    //    " [Customer BT], [Cust Lane ID], [Rate Type], [Origin City], [Origin State], [Origin Zip], [Origin Zip Range], " +
                    //    " [Dest City], [Dest State], [Dest Zip], [Dest Zip Range], [Award Type], [Awarded Vol], [Awarded Freq], " +
                    //    " [Award_Type], [Award RPM], [Award MIN], [Award Flat], [Rate Tyle], [Effective Date], [Expiration Date], " +
                    //    " [Origin Load Type], [Dest Unload Type], [Equipment Type], [Pricing Contact], [Pricing Change], [Comment]) " +
                    //    " VALUES (@pricingRateId, @sortId, @sentPub, @hasPub, @rateNum, @company, @custAck, " +
                    //    " @source, @parentCust, @customer, @custLaneId, @rateType, @originCity, @originState, " +
                    //    " @originZip, @originZipRange, @destCity, @destState, @destZip, @destZipRange, @awardType, " +
                    //    " @awardVol, @awardFreq, @awardType2, @awardRpm, @awardMin, @awardFlat, @rateTyle, @effDate, @expDate, " +
                    //    " @orgLoadType, @destUnloadType, @equipType, @pricingContact, @pricingChange, @comment )";

                    //string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
                    //connStr = "";

                    //reset sheetData
                    sheetData = new DataTable();
                    using (OleDbConnection conn = this.returnConnection(fileName))
                    {

                        conn.Open();
                        //OleDbDataAdapter sheetAdapter = new OleDbDataAdapter("select top 30000 * from [Sheet1$]", conn);
                        OleDbDataAdapter sheetAdapter = new OleDbDataAdapter("select * from [Template$A2:FF30000]", conn);
                        sheetAdapter.Fill(sheetData);
                        conn.Close();
                    }

                    connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;


                    using (SqlConnection con = new SqlConnection(connStr))
                    {
                        if (sheetData.Rows.Count > 3)
                        {
                            //SqlCommand cmd2 = new SqlCommand(truncateQry, con);
                            //con.Open();
                            //cmd2.ExecuteNonQuery();
                            //con.Close();
                            
                            foreach (DataRow row in sheetData.Rows)
                            {
                                if (row["Lipsey Lane ID"].ToString() != "Lipsey Lane ID")
                                {

                                
                                // string lipseylane_id = row["Lipsey Lane ID"].ToString(); //      .ToString();
                                string lipsey_lane_id = row["Lipsey Lane ID"].ToString();
                                string cust_lane_id = row["Cust Lane ID"].ToString();
                                string lane_commitment = row["Lane Comment"].ToString();
                                string origin_3zip = row["O3"].ToString();
                                string dest_3zip = row["D3"].ToString();
                                string origin_city = row["Orig City"].ToString();
                                string origin_st = row["Orig State"].ToString();
                                string origin_zip = row["Orig Zip"].ToString();
                                string dest_city = row["Dest City"].ToString();
                                string dest_state = row["Dest State"].ToString();
                                string dest_zip = row["Dest Zip"].ToString();
                                string equip_type = row["Eqp Type #1"].ToString();
                                string cust_miles = row["Cust Miles"].ToString();
                                string pcm = row["PCM "].ToString();
                                string cust_fsc = row["Customer FSC"].ToString();
                                string lipsey_fsc = row["Lipsey FSC"].ToString();
                                string volume = row["Volume"].ToString();
                                string volume_freq = row["Volume Freq"].ToString();
                                string load_type = row["Load Type"].ToString();
                                string unload_type = row["Unload Type"].ToString();
                                string origin_metro = row["Origin Metro"].ToString();
                                string dest_metro = row["Dest Metro"].ToString();
                                string metro_order_id = row["Metro = Metro Order ID"].ToString();
                                string metro_avg_dst = row["Metro Average of Distance"].ToString();
                                string metro_avg_ttl_pay = row["Metro Average of Total Pay"].ToString();
                                string metro_avg_ttl_rev = row["Metro Average of Total Revenue"].ToString();
                                string metro_mpu = row["Metro-Metro MPU"].ToString();
                                string metro_mperct = row["Metro-Metro M%"].ToString();
                                string dat_avg_7 = row["DAT Output 7 Avg"].ToString();
                                string dat_high_7 = row["DAT Output 7 High"].ToString();
                                string dat_avg_15 = row["DAT Output 15 Avg"].ToString();
                                string dat_high_15 = row["DAT Output 15 High"].ToString();
                                string dat_avg_30 = row["DAT Output 30 Avg"].ToString();
                                string dat_high_30 = row["DAT Output 30 High"].ToString();
                                string dat_avg_60 = row["DAT Output 60 Avg"].ToString();
                                string dat_high_60 = row["DAT Output 60 High"].ToString();
                                string dat_avg_90 = row["DAT Output 90 Avg"].ToString();
                                string dat_high_90 = row["DAT Output 90 High"].ToString();
                                string dat_avg_360 = row["DAT Output 360 Avg"].ToString();
                                string dat_high_360 = row["DAT Output 360 High"].ToString();
                                string rpm_input = row["RPM Input"].ToString();
                                string min = row["MIN"].ToString();
                                string desired_flat_rate = row["Desired Flat Rate"].ToString();
                                string desired_all_in = row["Desired All In"].ToString();
                                string rpm_submit = row["RPM to Submit"].ToString();
                                string flat_submit = row["Flat to Submit"].ToString();
                                string rpm_adj_submit = row["Flat to Submit"].ToString();
                                string flat_adj_submit = row["Flat to Submit"].ToString();
                                string publ_rpm = row["Publ RPM"].ToString();
                                string publ_min_flat = row["Publ MIN/Flat"].ToString();
                                string award_type = row["Award Type"].ToString();
                                string cust_order_id = row["Customer Specific Order ID"].ToString();
                                string cust_avg_dst = row["Cust Average of Distance"].ToString();
                                string cust_avg_ttl_pay = row["Cust Average of Total Pay"].ToString();
                                string cust_avg_ttl_rev = row["Cust Average of Total Revenue"].ToString();
                                string cust_mpu = row["Cust MPU"].ToString();
                                string cust_mperct = row["Cust M%"].ToString();
                                string award = row["Award ?"].ToString();
                                string award_volume = row["Volume Award"].ToString();
                                string award_rpm = row["Awarded Rate (RPM)"].ToString();
                                string award_min_flat = row["Awarded Rate (MIN/FLAT)"].ToString();
                                string award_eff_date = row["Eff "].ToString();
                                string award_exp_date = row["Exp"].ToString();


                                    if (lipsey_lane_id != "" && lipsey_lane_id != "Capture" && lipsey_lane_id != "Lipsey Lane ID")
                                    {
                                        using (SqlCommand command = new SqlCommand(insertQry, con))
                                        {
                                            //if (con != null && con.State==ConnectionState.Closed)
                                            //{

                                            //}
                                            con.Open();
                                            command.Parameters.AddWithValue("@company_id", company_id);
                                            command.Parameters.AddWithValue("@cust_name", cust_name);
                                            command.Parameters.AddWithValue("@opp", opp);
                                            command.Parameters.AddWithValue("@opp_date", opp_date);
                                            command.Parameters.AddWithValue("@opp_id", opp_id);
                                            command.Parameters.AddWithValue("@opp_comments", opp_comments);
                                            command.Parameters.AddWithValue("@customer_id", customer_id);
                                            command.Parameters.AddWithValue("@lipsey_lane_id", lipsey_lane_id);
                                            command.Parameters.AddWithValue("@cust_lane_id", cust_lane_id);
                                            command.Parameters.AddWithValue("@lane_commitment", lane_commitment);
                                            command.Parameters.AddWithValue("@origin_3zip", origin_3zip);
                                            command.Parameters.AddWithValue("@dest_3zip", dest_3zip);
                                            command.Parameters.AddWithValue("@origin_city", origin_city);
                                            command.Parameters.AddWithValue("@origin_st", origin_st);
                                            command.Parameters.AddWithValue("@origin_zip", origin_zip);
                                            command.Parameters.AddWithValue("@dest_city", dest_city);
                                            command.Parameters.AddWithValue("@dest_state", dest_state);
                                            command.Parameters.AddWithValue("@dest_zip", dest_zip);
                                            command.Parameters.AddWithValue("@equip_type", equip_type);
                                            command.Parameters.AddWithValue("@cust_miles", Convert.ToDecimal(check(cust_miles)));
                                            command.Parameters.AddWithValue("@pcm", Convert.ToDecimal(check(pcm)));
                                            command.Parameters.AddWithValue("@cust_fsc", Convert.ToDecimal(check(cust_fsc)));
                                            command.Parameters.AddWithValue("@lipsey_fsc", Convert.ToDecimal(check(lipsey_fsc)));
                                            command.Parameters.AddWithValue("@volume", volume);
                                            command.Parameters.AddWithValue("@volume_freq", volume_freq);
                                            command.Parameters.AddWithValue("@load_type", load_type);
                                            command.Parameters.AddWithValue("@unload_type", unload_type);
                                            command.Parameters.AddWithValue("@origin_metro", origin_metro);
                                            command.Parameters.AddWithValue("@dest_metro", dest_metro);
                                            command.Parameters.AddWithValue("@metro_order_id", metro_order_id);
                                            command.Parameters.AddWithValue("@metro_avg_dst", Convert.ToDecimal(check(metro_avg_dst)));
                                            command.Parameters.AddWithValue("@metro_avg_ttl_pay", Convert.ToDecimal(check(metro_avg_ttl_pay)));
                                            command.Parameters.AddWithValue("@metro_avg_ttl_rev", Convert.ToDecimal(check(metro_avg_ttl_rev)));
                                            command.Parameters.AddWithValue("@metro_mpu", Convert.ToDecimal(check(metro_mpu)));
                                            command.Parameters.AddWithValue("@metro_mperct", metro_mperct);
                                            command.Parameters.AddWithValue("@dat_avg_7", Convert.ToDecimal(check(dat_avg_7)));
                                            command.Parameters.AddWithValue("@dat_high_7", Convert.ToDecimal(check(dat_high_7)));
                                            command.Parameters.AddWithValue("@dat_avg_15", Convert.ToDecimal(check(dat_avg_15)));
                                            command.Parameters.AddWithValue("@dat_high_15", Convert.ToDecimal(check(dat_high_15)));
                                            command.Parameters.AddWithValue("@dat_avg_30", Convert.ToDecimal(check(dat_avg_30)));
                                            command.Parameters.AddWithValue("@dat_high_30", Convert.ToDecimal(check(dat_high_30)));
                                            command.Parameters.AddWithValue("@dat_avg_60", Convert.ToDecimal(check(dat_avg_60)));
                                            command.Parameters.AddWithValue("@dat_high_60", Convert.ToDecimal(check(dat_high_60)));
                                            command.Parameters.AddWithValue("@dat_avg_90", Convert.ToDecimal(check(dat_avg_90)));
                                            command.Parameters.AddWithValue("@dat_high_90", Convert.ToDecimal(check(dat_high_90)));
                                            command.Parameters.AddWithValue("@dat_avg_360", Convert.ToDecimal(check(dat_avg_360)));
                                            command.Parameters.AddWithValue("@dat_high_360", Convert.ToDecimal(check(dat_high_360)));
                                            command.Parameters.AddWithValue("@rpm_input", rpm_input);
                                            command.Parameters.AddWithValue("@min", min);
                                            command.Parameters.AddWithValue("@desired_flat_rate", desired_flat_rate);
                                            command.Parameters.AddWithValue("@desired_all_in", desired_all_in);
                                            command.Parameters.AddWithValue("@rpm_submit", rpm_submit);
                                            command.Parameters.AddWithValue("@flat_submit", flat_submit);
                                            command.Parameters.AddWithValue("@rpm_adj_submit", rpm_adj_submit);
                                            command.Parameters.AddWithValue("@flat_adj_submit", flat_adj_submit);
                                            command.Parameters.AddWithValue("@publ_rpm", publ_rpm);
                                            command.Parameters.AddWithValue("@publ_min_flat", publ_min_flat);
                                            command.Parameters.AddWithValue("@award_type", award_type);
                                            command.Parameters.AddWithValue("@cust_order_id", cust_order_id);
                                            command.Parameters.AddWithValue("@cust_avg_dst", cust_avg_dst);
                                            command.Parameters.AddWithValue("@cust_avg_ttl_pay", cust_avg_ttl_pay);
                                            command.Parameters.AddWithValue("@cust_avg_ttl_rev", cust_avg_ttl_rev);
                                            command.Parameters.AddWithValue("@cust_mpu", cust_mpu);
                                            command.Parameters.AddWithValue("@cust_mperct", cust_mperct);
                                            command.Parameters.AddWithValue("@award", award);
                                            command.Parameters.AddWithValue("@award_volume", award_volume);
                                            command.Parameters.AddWithValue("@award_rpm", Convert.ToDecimal(check(award_rpm)));
                                            command.Parameters.AddWithValue("@award_min_flat", Convert.ToDecimal(check(award_min_flat)));
                                            command.Parameters.AddWithValue("@award_eff_date", award_eff_date);
                                            command.Parameters.AddWithValue("@award_exp_date", award_exp_date);

                                            command.ExecuteNonQuery();
                                        }

                                        nCount++;
                                        con.Close();
                                    }
                                }
                                
                            }
                           


                        }

                    }

                }


                

                lblResults.Text = nCount.ToString() + " records uploaded successfully.";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private static string check(string s)
        {
            return (s == null || s == string.Empty) ? null : s;
        }
        private OleDbConnection returnConnection(string fileName)
        {
            //return new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + "; Jet OLEDB:Engine Type=5;Extended Properties=\"Excel 8.0;\"");
            return new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;'");

        }
        private OleDbConnection returnConnection2(string fileName)
        {
            //return new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + "; Jet OLEDB:Engine Type=5;Extended Properties=\"Excel 8.0;\"");
            return new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=No;'");

        }

        private static List<string> getZips(string sZips)
        {

            var zipList = new List<string>();
            try
            {


                var nLen = sZips.Length;

                var nCount = 0;

                sZips = sZips.Replace(" ", "");

                while (nLen > 3)
                {
                    string sChar = sZips.Substring(nCount, 1);
                    string sFirst = sZips.Substring(nCount, 3);
                    string sSecond = sZips.Substring(nCount + 1, 1);
                    string sCheck = sZips.Substring(nCount + 3, 1);

                    if (nLen > 3)
                    {
                        if (sChar == ",")
                        {
                            sFirst = sZips.Substring(nCount + 1, 3);

                            if (nLen >= 7)
                            {
                                sCheck = sZips.Substring(nCount + 4, 1);

                                if (sCheck == "-" || sCheck == ":")
                                {

                                    string sRange = sZips.Substring(nCount + 1, 7);

                                    int firstno = Convert.ToInt32(sRange.Substring(0, 3));
                                    int lastno = Convert.ToInt32(sRange.Substring(4, 3));

                                    int count = (lastno - firstno) + 1;

                                    var x = new List<string>();
                                    foreach (int i in Enumerable.Range(firstno, count)) x.Add(i.ToString());

                                    zipList.AddRange(x);
                                    nLen -= 8;
                                    nCount += 7;

                                }
                                else if (sSecond == " ")
                                {

                                    string sRange = sZips.Substring(nCount, 6);


                                    int firstno = Convert.ToInt32(sRange.Substring(0, 3));
                                    int lastno = Convert.ToInt32(sRange.Substring(4, 3));

                                    int count = (lastno - firstno) + 1;

                                    var x = new List<string>();
                                    foreach (int i in Enumerable.Range(firstno, count)) x.Add(i.ToString());

                                    zipList.AddRange(x);
                                    nLen -= 7;
                                    nCount += 7;

                                }
                                else
                                {
                                    nLen -= 3;
                                    nCount += 4;

                                    zipList.Add(sFirst);
                                }

                            }
                            else
                            {
                                nLen -= 3;
                                nCount += 3;

                                zipList.Add(sFirst);
                            }
                        }
                        else if (sZips.Substring(nCount + 3, 1) == ",")
                        {
                            nLen -= 3;
                            nCount += 3;

                            zipList.Add(sFirst);

                        }
                        else if (sCheck == "-" || sCheck == ":")
                        {

                            string sRange = sZips.Substring(nCount, 7);

                            int firstno = Convert.ToInt32(sRange.Substring(0, 3));
                            int lastno = Convert.ToInt32(sRange.Substring(4, 3));

                            int count = (lastno - firstno) + 1;

                            var x = new List<string>();
                            foreach (int i in Enumerable.Range(firstno, count)) x.Add(i.ToString());

                            zipList.AddRange(x);
                            nLen -= 7;
                            nCount += 7;

                        }
                        else
                        {
                            if (nLen == 5)
                            {
                                zipList.Add(sZips.Substring(nCount, 5));

                                nLen -= 5;
                            }
                            else if (nLen == 6)
                            {
                                string sFirstZip = sZips.Substring(nCount, 3);
                                string sSecondZip = sZips.Substring(nCount + 3, 3);

                                zipList.Add(sFirstZip);
                                zipList.Add(sSecondZip);
                                nLen -= 6;
                            }
                            else if (nLen == 4)
                            {
                                string sFour = sZips.Substring(nCount + 1, 4);

                                sFour = sFour.Replace(",", "");

                                zipList.Add(sFour);
                                nLen -= 4;

                            }
                            else
                            {
                                break;

                            }




                        }
                    }

                }

                for (int i = 0; i < zipList.Count; i++)
                {
                    string sTest = zipList[i].Trim();

                    if (sTest.Length < 3)
                    {

                        zipList[i] = zipList[i].Replace(zipList[i].ToString(), "0" + zipList[i].Trim());
                    }

                }

                return zipList;

            }
            catch (Exception)
            {

                return zipList;
            }
            finally
            {


            }
        }

        private void ofd_FileOk(object sender, CancelEventArgs e)
        {
            txtFilePath.Text = ofd.FileName;
        }

        //private void cmdCleanUp_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        //        string dupQuery = "SELECT Count([Pricing Rate ID]) As Duplicates, [Customer BT], [Origin City], [Origin State], [Origin Zip], " +
        //             " [Origin Zip Range], [Dest City], [Dest State], [Dest Zip], [Dest Zip Range]  From award_publication_temp " +
        //             " WHERE (GETDATE() BETWEEN ISNULL([Effective Date], GETDATE()) AND ISNULL([Expiration Date], GETDATE())) " +
        //             " GROUP BY [Customer BT], [Origin City], [Origin State], [Origin Zip], " +
        //             " [Origin Zip Range], [Dest City], [Dest State], [Dest Zip], [Dest Zip Range] " +
        //             " ORDER BY Duplicates DESC";

        //        SqlConnection conn = new SqlConnection(connStr);
        //        SqlCommand cmd = new SqlCommand(dupQuery, conn);
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);

        //        DataTable dt = new DataTable();

        //        conn.Open();

        //        da.Fill(dt);

        //        if (dt != null && dt.Rows.Count > 0)
        //        {
        //            foreach (DataRow row in dt.Rows)
        //            {
        //                int dups = int.Parse(row[0].ToString());

        //                if (dups > 1)
        //                {
        //                    AwardsData ad = new AwardsData();

        //                    ad.Customer = row["Customer BT"].ToString();
        //                    ad.OriginCity = row["Origin City"].ToString();
        //                    ad.OriginState = row["Origin State"].ToString();
        //                    ad.OriginZip = row["Origin Zip"].ToString();
        //                    ad.OriginZipRange = row["Origin Zip Range"].ToString();
        //                    ad.DestCity = row["Dest City"].ToString();
        //                    ad.DestState = row["Dest State"].ToString();
        //                    ad.DestZip = row["Dest Zip"].ToString();
        //                    ad.DestZipRange = row["Dest Zip Range"].ToString();

        //                    string query = "SELECT [Pricing Rate ID] FROM award_publication_temp WHERE [Customer BT] = @customer " +
        //                        " AND [Origin City] = @originCity AND [Origin State] = @originState AND [Origin Zip] = @originZip " +
        //                        " AND [Origin Zip Range] = @originZipRange AND [Dest City] = @destCity AND [Dest State] = @destState " +
        //                        " AND [Dest Zip] = @destZip AND [Dest Zip Range] = @destZipRange " +
        //                        " ORDER BY [Pricing Rate ID] DESC ";


        //                    using (SqlCommand command = new SqlCommand(query, conn))
        //                    {

        //                        using (SqlDataAdapter sda = new SqlDataAdapter(command))
        //                        {
        //                            command.Parameters.AddWithValue("@customer", ad.Customer);
        //                            command.Parameters.AddWithValue("@originCity", ad.OriginCity);
        //                            command.Parameters.AddWithValue("@originState", ad.OriginState);
        //                            command.Parameters.AddWithValue("@originZip", ad.OriginZip);
        //                            command.Parameters.AddWithValue("@originZipRange", ad.OriginZipRange);
        //                            command.Parameters.AddWithValue("@destCity", ad.DestCity);
        //                            command.Parameters.AddWithValue("@destState", ad.DestState);
        //                            command.Parameters.AddWithValue("@destZip", ad.DestZip);
        //                            command.Parameters.AddWithValue("@destZipRange", ad.DestZipRange);

        //                            DataTable dtDups = new DataTable();

        //                            sda.Fill(dtDups);

        //                            int nCount = 0;

        //                            if (dtDups != null && dtDups.Rows.Count > 0)
        //                            {
        //                                foreach (DataRow dupRow in dtDups.Rows)
        //                                {
        //                                    if (nCount > 0)
        //                                    {
        //                                        string pricingRateId = dupRow["Pricing Rate ID"].ToString();
        //                                        string deleteQry = "DELETE award_publication_temp WHERE [Pricing Rate ID] = '" + pricingRateId + "'";

        //                                        SqlCommand deleteCmd = new SqlCommand(deleteQry, conn);

        //                                        deleteCmd.ExecuteNonQuery();

        //                                    }

        //                                    nCount += 1;

        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //        conn.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        public class BidsData
        {
            public string company_id { get; set; }
            public string cust_name { get; set; }
            public string opp { get; set; }
            public string opp_date { get; set; }
            public string opp_id { get; set; }
            public string opp_comments { get; set; }
            public string lipsey_lane_id { get; set; }
            public string cust_lane_id { get; set; }
            public string lane_commitment { get; set; }
            public string origin_3zip { get; set; }
            public string dest_3zip { get; set; }
            public string origin_city { get; set; }
            public string origin_st { get; set; }
            public string origin_zip { get; set; }
            public string dest_city { get; set; }
            public string dest_state { get; set; }
            public string dest_zip { get; set; }
            public string equip_type { get; set; }
            public string cust_miles { get; set; }
            public string pcm { get; set; }
            public string cust_fsc { get; set; }
            public string lipsey_fsc { get; set; }
            public string volume { get; set; }
            public string volume_freq { get; set; }
            public string load_type { get; set; }
            public string unload_type { get; set; }
            public string origin_metro { get; set; }
            public string dest_metro { get; set; }
            public string metro_order_id { get; set; }
            public string metro_avg_dst { get; set; }
            public string metro_avg_ttl_pay { get; set; }
            public string metro_avg_ttl_rev { get; set; }
            public string metro_mpu { get; set; }
            public string metro_mperct { get; set; }
            public string dat_avg_7 { get; set; }
            public string dat_high_7 { get; set; }
            public string dat_avg_15 { get; set; }
            public string dat_high_15 { get; set; }
            public string dat_avg_30 { get; set; }
            public string dat_high_30 { get; set; }
            public string dat_avg_60 { get; set; }
            public string dat_high_60 { get; set; }
            public string dat_avg_90 { get; set; }
            public string dat_high_90 { get; set; }
            public string dat_avg_360 { get; set; }
            public string dat_high_360 { get; set; }
            public string rpm_input { get; set; }
            public string min { get; set; }
            public string desired_flat_rate { get; set; }
            public string desired_all_in { get; set; }
            public string rpm_submit { get; set; }
            public string flat_submit { get; set; }
            public string rpm_adj_submit { get; set; }
            public string flat_adj_submit { get; set; }
            public string publ_rpm { get; set; }
            public string publ_min_flat { get; set; }
            public string award_type { get; set; }
            public string cust_order_id { get; set; }
            public string cust_avg_dst { get; set; }
            public string cust_avg_ttl_pay { get; set; }
            public string cust_avg_ttl_rev { get; set; }
            public string cust_mpu { get; set; }
            public string cust_mperct { get; set; }
            public string award { get; set; }
            public string award_volume { get; set; }
            public string award_rpm { get; set; }
            public string award_min_flat { get; set; }
            public string award_eff_date { get; set; }
            public string award_exp_date { get; set; }

    }
    public class AwardsData
        {
            public string PricingRateId { get; set; }
            public string Customer { get; set; }
            public string CsrId { get; set; }
            public string SalesPersonId { get; set; }
            public string OriginZipRange { get; set; }
            public string OriginCity { get; set; }
            public string OriginState { get; set; }
            public string OriginZip { get; set; }
            public string DestZipRange { get; set; }
            public string DestCity { get; set; }
            public string DestState { get; set; }
            public string DestZip { get; set; }
            public int Loads { get; set; }
            public decimal AvgProfit { get; set; }
            public string AwardVol { get; set; }
            public string AwardFreq { get; set; }
            public string AwardRPM { get; set; }
            public string AwardMIN { get; set; }
            public string AwardFlat { get; set; }
            public string RateType { get; set; }
            public DateTime EffectiveDate { get; set; }
            public DateTime ExpirationDate { get; set; }
            public string EquipmentType { get; set; }
            public string AwardType { get; set; }
            public string AwardType2 { get; set; }
            public string RateType2 { get; set; }
            public string Company { get; set; }
            public string Comment { get; set; }
            public string ParentCustomer { get; set; }
            public string RateNumber { get; set; }
            public string CustLaneId { get; set; }

        }

    }
}
