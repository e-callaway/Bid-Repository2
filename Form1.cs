using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Office.Interop.Excel;

namespace BidApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dateFrom.Value = DateTime.Today.AddMonths(-1);
            dateTo.Value = DateTime.Today.AddDays(1).AddMilliseconds(-3);
            getcustomers();
        }

        public void getcustomers()
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
                string sQuery = "SELECT distinct br.cust_name " +
                                " from bid_repository br ORDER BY br.cust_name ASC";
                                

                using (SqlConnection con = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(sQuery, con))
                    {
                        con.Open();

                        using (SqlDataAdapter sda = new SqlDataAdapter(command))
                        {
                            System.Data.DataTable dt = new System.Data.DataTable();
                            sda.Fill(dt);
                            //dataGridView1.DataSource = null;
                            comboBox1.DisplayMember = "cust_name";
                            comboBox1.DataSource = dt;
                            
                        }
                                            
                        con.Close();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void button1_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            doSearch();

            //string CustomerID = txtCustomer.Text;
            //string CSRid = txtCsrId.Text;
            //string SalesPersonID = txtSalesPersonId.Text;

            //if (CustomerID == "" && CSRid == "" && SalesPersonID == "")
            //{
            //    MessageBox.Show("Plese enter at least one search criteria - Customer ID, CSR ID or SalesPerson ID.");
            //}
            //else
            //{
                
            //}
        }

        private void doSearch()
        {
            try
            {
                clearFilterFields();

                string sCustomer = txtCustomer.Text.Trim();
                //string csr = txtCsrId.Text.Trim();
                //string salesPerson = txtSalesPersonId.Text.Trim();

                string sQuery =
                    " SELECT [company_id],[cust_name],[opp], CAST([opp_date] AS datetime) AS [opp_date] ,[opp_id],[opp_comments],[lipsey_lane_id]" +
                    " ,[cust_lane_id],[lane_commitment],[origin_3zip],[dest_3zip],[origin_city],[origin_st],[origin_zip],[dest_city]" +
                    " ,[dest_state],[dest_zip],[equip_type],[cust_miles],[pcm],[cust_fsc],[lipsey_fsc],[volume],[volume_freq],[load_type]" +
                    " ,[unload_type],[origin_metro],[dest_metro],[metro_order_id],[metro_avg_dst],[metro_avg_ttl_pay],[metro_avg_ttl_rev]" +
                    " ,[metro_mpu],[metro_mperct],[dat_avg_7],[dat_high_7],[dat_avg_15],[dat_high_15],[dat_avg_30],[dat_high_30],[dat_avg_60]" +
                    " ,[dat_high_60],[dat_avg_90],[dat_high_90],[dat_avg_360],[dat_high_360],[rpm_input],[min],[desired_flat_rate]" +
                    " ,[desired_all_in],[rpm_submit],[flat_submit],[rpm_adj_submit],[flat_adj_submit],[publ_rpm],[publ_min_flat],[award_type]" +
                    " ,[cust_order_id],[cust_avg_dst],[cust_avg_ttl_pay],[cust_avg_ttl_rev],[cust_mpu],[cust_mperct],[award],[award_volume]" +
                    " ,[award_rpm],[award_min_flat],CAST([award_eff_date] AS datetime) AS [award_eff_date],CAST([award_exp_date]  AS datetime) AS [award_exp_date] " +
                    " FROM [dbo].[Bid_repository] ";

                
                if (sCustomer != "")
                {
                    sCustomer = "%" + sCustomer + "%";
                    sQuery = sQuery + " WHERE [cust_name] LIKE isnull(CASE WHEN @customer = '' THEN null ELSE @customer END,[cust_name]) ";
                }

                //"SELECT [Customer BT], " +
                //" [csr_id], [salesperson_id], [Origin Zip Range], [Origin City], " +
                //" [Origin State], [Origin Zip], [Dest Zip Range], [Dest City], " +
                //" [Dest State], [Dest Zip], CAST(0 AS int) As Loads, CAST(0 AS money) As [Avg Profit], CAST(ISNULL([Awarded Vol],0) as float) As [Awarded Vol], [Awarded Freq], " +
                //" [Award RPM], [Award MIN], [Award Flat], [RATE_TYPE], " +
                //" CAST([Effective Date] AS datetime) AS [Effective Date], CAST([Expiration Date] AS datetime) AS [Expiration Date], [Equipment Type], " +
                //" [Parent Customer], [Rate Number], [Cust Lane ID], " +
                //" [Award_Type], [Award Type], [Rate Type], [Company], [Comment] " +
                //" FROM[lme_1020].[dbo].[AwardedLanes] " +
                //" WHERE [Customer BT] LIKE isnull(CASE WHEN @customer = '' THEN null ELSE @customer END,[Customer BT]) ";

                //if (csr != "")
                //{
                //    sQuery = sQuery + " AND csr_id = isnull(CASE WHEN @csr_id = '' THEN null ELSE @csr_id END,csr_id)  ";
                //}

                //if (salesPerson != "")
                //{
                //    sQuery = sQuery + " AND salesperson_id = isnull(CASE WHEN @salesperson = '' THEN null ELSE @salesperson END,salesperson_id)  ";
                //}

                //string sCustomer = txtCustomer.Text.Trim();
                //if (sCustomer != "")
                //{
                //    sCustomer = "%" + sCustomer + "%";
                //}

                //if (chkPrimary.Checked)
                //{
                //    sQuery += " AND (LOWER([award_type]) = 'primary' OR LOWER([award type]) = 'primary' ) ";
                //}

                string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(sQuery, con))
                    {
                        con.Open();

                        using (SqlDataAdapter sda = new SqlDataAdapter(command))
                        {
                            command.Parameters.AddWithValue("@customer", sCustomer);
                            //command.Parameters.AddWithValue("@csr_id", csr);
                            //command.Parameters.AddWithValue("@salesperson", salesPerson);
                            //command.Parameters.AddWithValue("@start_date", dateFrom.Value);
                            //command.Parameters.AddWithValue("@end_date", dateTo.Value);

                            System.Data.DataTable dt = new System.Data.DataTable();
                            sda.Fill(dt);

                            //if (dt != null && dt.Rows.Count > 0)
                            //{
                            //    foreach (DataRow row in dt.Rows)
                            //    {
                            //        string customer = row[0].ToString();
                            //        string csrId = row[1].ToString();
                            //        string salesPersonId = row[2].ToString();
                            //        string originZip = row[6].ToString();
                            //        string destZip = row[10].ToString();
                            //        string originZipRange = row[3].ToString();
                            //        string destZipRange = row[7].ToString();
                            //        string originCity = row[4].ToString();
                            //        string originState = row[5].ToString();
                            //        string destCity = row[8].ToString();
                            //        string destState = row[9].ToString();

                            //        int loads = 0;
                            //        decimal profit = 0;

                            //        getTotals(customer, csrId, salesPersonId, originZip, destZip, originZipRange, destZipRange, originCity, originState, destCity, destState, ref loads, ref profit);

                            //        row["Loads"] = loads.ToString();
                            //        //row["Avg Profit"] = profit.ToString("c");
                            //        profit = Math.Round(profit, 2);
                            //        row["Avg Profit"] = profit.ToString();
                            //    }
                            //}

                            dataGridResults.DataSource = dt;
                            //dataGridView1.DataSource = null;
                            lblNumLoads.Text = "";
                            lblTotalProfit.Text = "";
                        }

                        //fixSort();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fixSort()
        {
            try
            {
                for (int i = 0; i < dataGridResults.Rows.Count; i++)
                {
                    //DateTime dt = Convert.ToDateTime(dataGridResults.Rows[i].Cells[9].Value.ToString());
                    //DateTime dtnow = DateTime.Now;
                    //TimeSpan ts = dtnow.Subtract(dt);
                    string sAmount = dataGridResults.Rows[i].Cells[12].Value.ToString();
                    sAmount = sAmount.Replace("$", "");
                    sAmount = sAmount.Replace("(", "-");
                    sAmount = sAmount.Replace(")", "");

                    double nAmount = double.Parse(sAmount);
                    dataGridResults.Rows[i].Cells[12].ValueType = typeof(double);
                    dataGridResults.Rows[i].Cells[12].Value = nAmount;
                }
            }
            catch (Exception)
            {

            }

        }

        private void getTotals(string customer, string csrId, string salesPersonId, string originZip, string destZip, string originZipRange, string destZipRange, string originCity, string originState, string destCity, string destState, ref int totalLoads, ref decimal avgProfit)
        {
            try
            {
                string query = "SELECT TOP (100) PERCENT RTRIM(c.id) AS [Customer BT], " +
                    " RTRIM(ss.city_name) + ', ' + ss.state AS Origin, RTRIM(cs.city_name) + ', ' + cs.state AS Dest, " +
                    " (RTRIM(ss.city_name) + ', ' + ss.state + ' ') + (RTRIM(cs.city_name) + ', ' + cs.state) AS Lane, " +
                    " RTRIM(ss.city_name) AS[Origin City], ss.state AS[Origin State], ss.zip_code AS[Origin Zip], RTRIM(cs.city_name) AS[Dest City], " +
                    " cs.state AS[Dest State], cs.zip_code AS[Dest Zip], SUM(o.total_charge_n) AS[Total Revenue], " +
                    " SUM(ISNULL(dep.amount, 0)) + SUM(ISNULL(m_1.carrier_pay, 0.00)) AS[Total Pay], " +
                    " SUM(o.total_charge_n - ISNULL(m_1.carrier_pay, 0.00) - ISNULL(dep.amount, 0)) AS Profit, " +
                    " DATEPART(week,ISNULL(ss.sched_arrive_late, ss.sched_arrive_early)) AS weeknum, o.rate, o.rate_id, c.csr_id, " +
                    " c.salesperson_id, ss.sched_arrive_early, ss.sched_arrive_late " +
                    " FROM dbo.orders AS o WITH(nolock) LEFT OUTER JOIN dbo.customer AS c ON o.customer_id = c.id AND o.company_id = c.company_id ";

                if (customer.Contains(","))
                {
                    customer = "'" + customer + "'";
                    customer = customer.Replace(",", "','");
                    customer = customer.Replace(" ", "");
                    query = query + " AND c.id IN (" + customer + ") ";
                }
                else
                {
                    query = query + " AND c.id LIKE '%" + customer + "%' ";
                }

                query = query + " LEFT OUTER JOIN dbo.salesperson AS sm WITH(nolock) ON c.salesperson_id = sm.id AND c.company_id = sm.company_id " +
                    //" AND c.salesperson_id = isnull(CASE WHEN @salesperson = '' THEN null ELSE @salesperson END,c.salesperson_id) " +
                    " INNER JOIN (SELECT mo.order_id, m.override_payee_id, p.name, m.dispatcher_user_id, " +
                    " ISNULL(SUM(m.override_pay_amt), 0) AS carrier_pay, m.company_id, m.brokerage_status " +
                    " FROM  dbo.movement AS m WITH(NOLOCK) INNER JOIN " +
                    " dbo.movement_order AS mo WITH(NOLOCK) ON m.id = mo.movement_id AND mo.company_id = m.company_id " +
                    " INNER JOIN dbo.payee AS p WITH(nolock) ON p.id = m.override_payee_id AND p.company_id = m.company_id " +
                    " GROUP BY mo.order_id, m.override_payee_id, m.dispatcher_user_id, p.name, m.brokerage_status, " +
                    " m.company_id) AS m_1 ON m_1.order_id = o.id AND  m_1.company_id = o.company_id INNER JOIN " +
                    " dbo.stop AS ss WITH(nolock) ON o.shipper_stop_id = ss.id AND ss.company_id = o.company_id  " +
                    " AND ss.actual_arrival BETWEEN @startDate AND @endDate ";

                if (originState.Length > 2)
                {
                    query += " AND ss.state = '" + originState.Substring(0, 2) + "' ";
                }
                else if (originState.Length == 2)
                {
                    query += " AND ss.state = '" + originState + "' ";
                }

                if (originCity != "")
                {
                    query += " AND RTRIM(ss.city_name) = '" + originCity + "' ";
                }
                else
                {
                    if (originZip != "" && originZip != null && originZip.Contains("-") == false)
                    {
                        if (originZip.Length == 3)
                        {
                            query += " AND (ss.zip_code LIKE '" + originZip + "%') ";
                        }
                        else
                        {
                            query += " AND (ss.zip_code = '" + originZip + "') ";
                        }
                    }

                    if (originZipRange != "" && originZipRange != null)
                    {
                        if (!Regex.IsMatch(originZipRange, @"[a-zA-Z]"))
                        {
                            string ranges = "'" + originZipRange + "'";
                            ranges = ranges.Replace(",", "','");
                            ranges = ranges.Replace(" ", "");
                            query += " AND LEFT(ss.zip_code,3) IN (" + ranges + ")";
                        }
                    }
                }

                query += " INNER JOIN dbo.stop AS cs WITH(nolock) ON o.consignee_stop_id = cs.id AND cs.company_id = o.company_id ";

                if (destState.Length > 2)
                {
                    query += " AND cs.state = '" + destState.Substring(0, 2) + "' ";
                }
                else if (destState.Length == 2)
                {
                    query += " AND cs.state = '" + destState + "' ";
                }

                if (destCity != "")
                {
                    query += " AND RTRIM(cs.city_name) = '" + destCity + "' ";
                }
                else
                {
                    if (destZip != "" && destZip != null && destZip.Contains("-") == false)
                    {
                        if (destZip.Length == 3)
                        {
                            query += " AND (cs.zip_code LIKE '" + destZip + "%') ";
                        }
                        else
                        {
                            query += " AND (cs.zip_code = '" + destZip + "')";
                        }
                    }

                    if (destZipRange != "" && destZipRange != null)
                    {
                        if (!Regex.IsMatch(destZipRange, @"[a-zA-Z]"))
                        {
                            string ranges = "'" + destZipRange + "'";
                            ranges = ranges.Replace(",", "','");
                            ranges = ranges.Replace(" ", "");
                            query += " AND LEFT(cs.zip_code,3) IN (" + ranges + ")";

                        }
                    }
                }

                query += " LEFT OUTER JOIN  (SELECT order_id, SUM(amount) AS amount FROM dbo.driver_extra_pay WHERE(company_id = 'TMS') " +
                    " GROUP BY order_id) AS dep ON dep.order_id = o.id " +
                    " WHERE(o.customer_id IS NOT NULL) " +
                    " AND (o.status NOT IN('V', 'Q')) " +
                    " GROUP BY c.name, c.id, o.entered_user_id, o.id, m_1.override_payee_id, m_1.name, m_1.dispatcher_user_id, " +
                    " ss.sched_arrive_late, ss.sched_arrive_early, ss.actual_arrival, cs.actual_departure, o.blnum, " +
                    " cs.actual_departure, c.entered_date, o.company_id, sm.percentage, ss.city_name, ss.state, " +
                    " ss.zip_code, cs.city_name, cs.state, cs.zip_code, o.bill_distance, o.revenue_code_id, " +
                    " o.freight_charge_n, o.rate, o.rate_id, c.csr_id, c.salesperson_id ORDER BY c.name ";

                string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
                decimal profitTotal = 0;
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        con.Open();

                        using (SqlDataAdapter sda = new SqlDataAdapter(command))
                        {
                            command.Parameters.AddWithValue("@CustomerID", customer);
                            command.Parameters.AddWithValue("@Salesperson", salesPersonId);
                            command.Parameters.AddWithValue("@startDate", dateFrom.Value);
                            command.Parameters.AddWithValue("@endDate", dateTo.Value);
                            System.Data.DataTable dt = new System.Data.DataTable();
                            sda.Fill(dt);

                            if (dt != null && dt.Rows.Count > 0)
                            {
                                foreach (DataRow row in dt.Rows)
                                {
                                    totalLoads += 1;
                                    decimal nProfit = 0;
                                    decimal.TryParse(row["Profit"].ToString(), out nProfit);
                                    profitTotal += nProfit;

                                }
                            }
                        }
                    }

                    if (totalLoads > 0)
                    {
                        avgProfit = profitTotal / totalLoads;
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void orderLookup(int rowIndex)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                lblNumLoads.Text = "";
                lblTotalProfit.Text = "";

                string customer = dataGridResults.Rows[rowIndex].Cells[1].Value.ToString();
                //string salesPersonId = dataGridResults.Rows[rowIndex].Cells[2].Value.ToString();
                string originZip = dataGridResults.Rows[rowIndex].Cells[13].Value.ToString();
                string destZip = dataGridResults.Rows[rowIndex].Cells[16].Value.ToString();
                //string originZipRange = dataGridResults.Rows[rowIndex].Cells[3].Value.ToString();
                //string destZipRange = dataGridResults.Rows[rowIndex].Cells[7].Value.ToString();
                string originCity = dataGridResults.Rows[rowIndex].Cells[11].Value.ToString();
                string originState = dataGridResults.Rows[rowIndex].Cells[12].Value.ToString();
                string destCity = dataGridResults.Rows[rowIndex].Cells[14].Value.ToString();
                string destState = dataGridResults.Rows[rowIndex].Cells[15].Value.ToString();

                string query = "SELECT TOP (100) PERCENT  o.id as [Load Num], " +
                    " RTRIM(ss.city_name) + ', ' + ss.state AS Origin, RTRIM(cs.city_name) + ', ' + cs.state AS Dest, " +
                    " (RTRIM(ss.city_name) + ', ' + ss.state + ' ') + (RTRIM(cs.city_name) + ', ' + cs.state) AS Lane, " +
                    " RTRIM(ss.city_name) AS[Origin City], ss.state AS[Origin State], ss.zip_code AS[Origin Zip], RTRIM(cs.city_name) AS[Dest City], " +
                    " cs.state AS[Dest State], cs.zip_code AS[Dest Zip], SUM(o.total_charge_n) AS[Total Revenue], " +
                    " SUM(ISNULL(dep.amount, 0)) + SUM(ISNULL(m_1.carrier_pay, 0.00)) AS[Total Pay], " +
                    " SUM(o.total_charge_n - ISNULL(m_1.carrier_pay, 0.00) - ISNULL(dep.amount, 0)) AS Profit, " +
                    " DATEPART(week,ISNULL(ss.sched_arrive_late, ss.sched_arrive_early)) AS weeknum, o.rate, o.rate_id, " +
                    " ss.actual_arrival  " +
                    " FROM dbo.orders AS o WITH(nolock)  ";


                //query = query + " AND c.id LIKE '%" + customer + "%' ";

                 /*" LEFT OUTER JOIN dbo.salesperson AS sm WITH(nolock) ON c.salesperson_id = sm.id AND c.company_id = sm.company_id "*/ 
                   // " AND c.salesperson_id = isnull(CASE WHEN @salesperson = '' THEN null ELSE @salesperson END,c.salesperson_id) " +
                   query += " INNER JOIN (SELECT mo.order_id, m.override_payee_id, p.name, m.dispatcher_user_id, " +
                    " ISNULL(SUM(m.override_pay_amt), 0) AS carrier_pay, m.company_id, m.brokerage_status " +
                    " FROM  dbo.movement AS m WITH(NOLOCK) INNER JOIN " +
                    " dbo.movement_order AS mo WITH(NOLOCK) ON m.id = mo.movement_id AND mo.company_id = m.company_id " +
                    " INNER JOIN dbo.payee AS p WITH(nolock) ON p.id = m.override_payee_id AND p.company_id = m.company_id " +
                    " GROUP BY mo.order_id, m.override_payee_id, m.dispatcher_user_id, p.name, m.brokerage_status, " +
                    " m.company_id) AS m_1 ON m_1.order_id = o.id AND  m_1.company_id = o.company_id INNER JOIN " +
                    " dbo.stop AS ss WITH(nolock) ON o.shipper_stop_id = ss.id AND ss.company_id = o.company_id  " +
                    " AND ss.actual_arrival BETWEEN @startDate AND @endDate ";

                if (originZip != "")
                {
                    query += " AND ss.zip_code = '" + originZip + "' ";
                }
                else
                {
                    query += " AND RTRIM(ss.city_name) = '" + originCity + "' AND ss.state = '" + originState + "' ";

                }

                query += " INNER JOIN dbo.stop AS cs WITH(nolock) ON o.consignee_stop_id = cs.id AND cs.company_id = o.company_id ";


                if (destZip != "")
                {
                    query += " AND cs.zip_code = '" + destZip + "' ";
                }
                else
                {
                    query += " AND RTRIM(cs.city_name) = '" + destCity + "' AND cs.state = '" + destState + "' ";

                }


                query += " LEFT OUTER JOIN  (SELECT order_id, SUM(amount) AS amount FROM dbo.driver_extra_pay WHERE(company_id = 'TMS') " +
                    " GROUP BY order_id) AS dep ON dep.order_id = o.id " +
                    " WHERE(o.customer_id IS NOT NULL) " +
                    " AND (o.status NOT IN('V', 'Q')) " +
                    " GROUP BY o.entered_user_id, o.id, m_1.override_payee_id, m_1.name, m_1.dispatcher_user_id, " +
                    " ss.sched_arrive_late, ss.sched_arrive_early, ss.actual_arrival, cs.actual_departure, o.blnum, " +
                    " cs.actual_departure, o.company_id, ss.city_name, ss.state, " +
                    " ss.zip_code, cs.city_name, cs.state, cs.zip_code, o.bill_distance, o.revenue_code_id, " +
                    " o.freight_charge_n, o.rate, o.rate_id ORDER BY o.id ";

                string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        con.Open();

                        using (SqlDataAdapter sda = new SqlDataAdapter(command))
                        {
                            command.Parameters.AddWithValue("@CustomerID", customer);
                            //command.Parameters.AddWithValue("@Salesperson", salesPersonId);
                            command.Parameters.AddWithValue("@startDate", dateFrom.Value);
                            command.Parameters.AddWithValue("@endDate", dateTo.Value);
                            System.Data.DataTable dt = new System.Data.DataTable();
                            sda.Fill(dt);
                            dataGridView1.DataSource = dt;

                            if (dt != null && dt.Rows.Count > 0)
                            {
                                int nCount = 0;
                                decimal profitTotal = 0;

                                foreach (DataRow row in dt.Rows)
                                {
                                    nCount += 1;
                                    decimal nProfit = 0;
                                    decimal.TryParse(row["Profit"].ToString(), out nProfit);
                                    profitTotal += nProfit;
                                }

                                lblTotalProfit.Text = profitTotal.ToString("c");
                                lblNumLoads.Text = nCount.ToString();
                            }
                        }

                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clearFilterFields()
        {
            txtOrgCity.Text = String.Empty;
            txtOrgState.Text = String.Empty;
            txtOrgZip.Text = String.Empty;
            txtDestZip.Text = String.Empty;
            txtDestState.Text = String.Empty;
            txtDestCity.Text = String.Empty;
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    txtCustomer.Text = String.Empty;
        //    txtCsrId.Text = string.Empty;
        //    txtSalesPersonId.Text = string.Empty;
        //    clearFilterFields();
        //}

        private void button3_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
        }

        private void build_filter()
        {
            try
            {
                string OriginState = txtOrgState.Text;
                string OriginCity = txtOrgCity.Text;
                string OriginZip = txtOrgZip.Text;
                string DestState = txtDestState.Text;
                string DestCity = txtDestCity.Text;
                string DestZip = txtDestZip.Text;

                var rowfilter = string.Empty;
                //[origin_city]
	            //[origin_st]
	            //[origin_zip]
	            //[dest_city]
	            //[dest_state]
	            //[dest_zip]

                if (dataGridResults.Rows.Count > 0)
                {
                    if (OriginState.Length != 0)
                    {
                        rowfilter = string.Format("[origin_st] LIKE '{0}%'", OriginState);
                    }
                    if (OriginCity.Length != 0)
                    {
                        if (rowfilter.Length != 0)
                        {
                            rowfilter += string.Format(" AND [origin_city] LIKE '{0}%'", OriginCity);
                        }
                        else
                        {
                            rowfilter = string.Format("[Origin City] LIKE '{0}%'", OriginCity);
                        }
                    }
                    if (OriginZip.Length != 0)
                    {
                        if (rowfilter.Length != 0)
                        {
                            rowfilter += string.Format(" AND [origin_zip] LIKE '%{0}%'", OriginZip);
                           
                        }
                        else
                        {
                            rowfilter = string.Format(" [origin_zip] LIKE '%{0}%'", OriginZip);
                            
                        }
                    }

                    if (DestState.Length != 0)
                    {
                        if (rowfilter.Length != 0)
                        {
                            rowfilter += string.Format(" AND [dest_state] LIKE '{0}%'", DestState);
                        }
                        else
                        {
                            rowfilter = string.Format("[dest_state] LIKE '{0}%'", DestState);
                        }
                    }
                    if (DestCity.Length != 0)
                    {
                        if (rowfilter.Length != 0)
                        {
                            rowfilter += string.Format(" AND [dest_city] LIKE '{0}%'", DestCity);
                        }
                        else
                        {
                            rowfilter = string.Format("[dest_city] LIKE '{0}%'", DestCity);
                        }
                    }
                    if (DestZip.Length != 0)
                    {
                        if (rowfilter.Length != 0)
                        {
                            rowfilter += string.Format(" AND [dest_zip] LIKE '%{0}%'", DestZip);
                        }
                        else
                        {
                            rowfilter = string.Format(" [dest_zip] LIKE '%{0}%'", DestZip);
                        }
                    }

                    (dataGridResults.DataSource as System.Data.DataTable).DefaultView.RowFilter = rowfilter;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        { //call build_filter to filter the datatable
            build_filter();
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            build_filter();
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            build_filter();
        }

        private void TextBox7_TextChanged(object sender, EventArgs e)
        {
            build_filter();
        }

        //private void TextBox6_TextChanged(object sender, EventArgs e)
        //{
        //    build_filter();
        //}

        //private void TextBox5_TextChanged(object sender, EventArgs e)
        //{
        //    build_filter();
        //}

        private void dataGridResults_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(dataGridResults.Rows[e.RowIndex].Cells[3].Value.ToString() + " was selected.");
            if (e.RowIndex >= 0)
            {
                orderLookup(e.RowIndex);
            }
        }

        //private void dataGridResults_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    if (dataGridResults.Columns[e.ColumnIndex].Name.Equals("Loads"))
        //    {
        //        if (e.RowIndex >= 0)
        //        {
        //            e.CellStyle.BackColor = Color.LightYellow;

        //        }
        //    }

        //    if (dataGridResults.Columns[e.ColumnIndex].Name.Equals("Avg Profit"))
        //    {
        //        if (e.RowIndex >= 0)
        //        {
        //            e.CellStyle.BackColor = Color.LightGreen;
        //        }
        //    }

        //    if (dataGridResults.Columns[e.ColumnIndex].Name.Equals("Awarded Vol"))
        //    {
        //        if (e.RowIndex >= 0)
        //        {
        //            e.CellStyle.BackColor = Color.LightBlue;

        //        }
        //    }
        //}

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //string selectedPath;
                //using (FolderBrowserDialog dlg = new FolderBrowserDialog())
                //{
                //    if (dlg.ShowDialog() != DialogResult.OK)
                //    {
                //        return;
                //    }
                //    selectedPath = dlg.SelectedPath;
                //}

                DataSet ds = new DataSet();
                ds.Tables.Add(dataGridResults.DataSource as System.Data.DataTable);
                string timeMark = DateTime.Now.ToString("yyyyMMdd HHmmss");
                //string fastExportFilePath = selectedPath + "RateAppExport_" + timeMark + ".xls";
                string fastExportFilePath = "S:\\BidApp\\Exports\\BidAppExport_" + timeMark + ".xls";
                FastExportingMethod.ExportToExcel(ds, fastExportFilePath);

                MessageBox.Show("Export completed succesfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            build_filter();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            build_filter();
        }

        private void txtDestState_TextChanged(object sender, EventArgs e)
        {
            build_filter();
        }

        private void txtDestZip_TextChanged(object sender, EventArgs e)
        {
            build_filter();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        //private void cmdSearchWeek_Click(object sender, EventArgs e)
        //{
        //    doSearchWeek();
        //}

        //private void doSearchWeek()
        //{
        //    try
        //    {
        //        clearFilterFields();

        //        string csr = txtCsrId.Text.Trim();
        //        string salesPerson = txtSalesPersonId.Text.Trim();

        //        dateTo.Text = DateTime.Now.ToShortDateString();
        //        dateFrom.Text = DateTime.Now.AddDays(-7).ToShortDateString();

        //        string sQuery = "SELECT [Customer BT], " +
        //        " [csr_id], [salesperson_id], [Origin Zip Range], [Origin City], " +
        //        " [Origin State], [Origin Zip], [Dest Zip Range], [Dest City], " +
        //        " [Dest State], [Dest Zip], Loads, Cast([Avg Profit] as numeric(10,2)) as [Avg Profit], [Awarded Vol], [Awarded Freq], " +
        //        " [Award RPM], [Award MIN], [Award Flat], [RATE_TYPE], " +
        //        " [Effective Date], [Expiration Date], [Equipment Type], " +
        //        " [Parent Customer], [Rate Number], [Cust Lane ID], " +
        //        " [Award_Type], [Award Type], [Rate Type], [Company], [Comment] " +
        //        " FROM[lme_1020].[dbo].[awards_data_wk] " +
        //        " WHERE [Customer BT] LIKE isnull(CASE WHEN @customer = '' THEN null ELSE @customer END,[Customer BT]) ";

        //        if (csr != "")
        //        {
        //            sQuery = sQuery + " AND csr_id = isnull(CASE WHEN @csr_id = '' THEN null ELSE @csr_id END,csr_id)  ";
        //        }

        //        if (salesPerson != "")
        //        {
        //            sQuery = sQuery + " AND salesperson_id = isnull(CASE WHEN @salesperson = '' THEN null ELSE @salesperson END,salesperson_id)  ";
        //        }

        //        string sCustomer = txtCustomer.Text.Trim();
        //        if (sCustomer != "")
        //        {
        //            sCustomer = "%" + sCustomer + "%";
        //        }

        //        //if (chkPrimary.Checked)
        //        //{
        //        //    sQuery += " AND (LOWER([award_type]) = 'primary' OR LOWER([award type]) = 'primary' ) ";
        //        //}

        //        string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        //        using (SqlConnection con = new SqlConnection(connStr))
        //        {
        //            using (SqlCommand command = new SqlCommand(sQuery, con))
        //            {
        //                con.Open();

        //                using (SqlDataAdapter sda = new SqlDataAdapter(command))
        //                {
        //                    command.Parameters.AddWithValue("@customer", sCustomer);
        //                    command.Parameters.AddWithValue("@csr_id", csr);
        //                    command.Parameters.AddWithValue("@salesperson", salesPerson);
        //                    //command.Parameters.AddWithValue("@start_date", dateFrom.Value);
        //                    //command.Parameters.AddWithValue("@end_date", dateTo.Value);

        //                    System.Data.DataTable dt = new System.Data.DataTable();
        //                    sda.Fill(dt);

        //                    if (dt != null && dt.Rows.Count > 0)
        //                    {

        //                    }
        //                    //{
        //                    //    foreach (DataRow row in dt.Rows)
        //                    //    {
        //                    //        string customer = row[0].ToString();
        //                    //        string csrId = row[1].ToString();
        //                    //        string salesPersonId = row[2].ToString();
        //                    //        string originZip = row[6].ToString();
        //                    //        string destZip = row[10].ToString();
        //                    //        string originZipRange = row[3].ToString();
        //                    //        string destZipRange = row[7].ToString();
        //                    //        string originCity = row[4].ToString();
        //                    //        string originState = row[5].ToString();
        //                    //        string destCity = row[8].ToString();
        //                    //        string destState = row[9].ToString();

        //                    //        int loads = 0;
        //                    //        decimal profit = 0;

        //                    //        getTotals(customer, csrId, salesPersonId, originZip, destZip, originZipRange, destZipRange, originCity, originState, destCity, destState, ref loads, ref profit);

        //                    //        row["Loads"] = loads.ToString();
        //                    //        //row["Avg Profit"] = profit.ToString("c");
        //                    //        profit = Math.Round(profit, 2);
        //                    //        row["Avg Profit"] = profit.ToString();
        //                    //    }
        //                    //}

        //                    dataGridResults.DataSource = dt;
        //                    //dataGridView1.DataSource = null;
        //                    lblNumLoads.Text = "";
        //                    lblTotalProfit.Text = "";
        //                }

        //                //fixSort();
        //                con.Close();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void doSearchMonthly()
        //{
        //    try
        //    {
        //        clearFilterFields();

        //        string csr = txtCsrId.Text.Trim();
        //        string salesPerson = txtSalesPersonId.Text.Trim();

        //        dateTo.Text = DateTime.Now.ToShortDateString();
        //        dateFrom.Text = DateTime.Now.AddDays(-30).ToShortDateString();

        //        string sQuery = "SELECT [Customer BT], " +
        //        " [csr_id], [salesperson_id], [Origin Zip Range], [Origin City], " +
        //        " [Origin State], [Origin Zip], [Dest Zip Range], [Dest City], " +
        //        " [Dest State], [Dest Zip], Loads, Cast([Avg Profit] as numeric(10,2)) as [Avg Profit], [Awarded Vol], [Awarded Freq], " +
        //        " [Award RPM], [Award MIN], [Award Flat], [RATE_TYPE], " +
        //        " [Effective Date], [Expiration Date], [Equipment Type], " +
        //        " [Parent Customer], [Rate Number], [Cust Lane ID], " +
        //        " [Award_Type], [Award Type], [Rate Type], [Company], [Comment] " +
        //        " FROM[lme_1020].[dbo].[awards_data_mth] " +
        //        " WHERE [Customer BT] LIKE isnull(CASE WHEN @customer = '' THEN null ELSE @customer END,[Customer BT]) ";

        //        if (csr != "")
        //        {
        //            sQuery = sQuery + " AND csr_id = isnull(CASE WHEN @csr_id = '' THEN null ELSE @csr_id END,csr_id)  ";
        //        }

        //        if (salesPerson != "")
        //        {
        //            sQuery = sQuery + " AND salesperson_id = isnull(CASE WHEN @salesperson = '' THEN null ELSE @salesperson END,salesperson_id)  ";
        //        }

        //        string sCustomer = txtCustomer.Text.Trim();
        //        if (sCustomer != "")
        //        {
        //            sCustomer = "%" + sCustomer + "%";
        //        }

        //        //if (chkPrimary.Checked)
        //        //{
        //        //    sQuery += " AND (LOWER([award_type]) = 'primary' OR LOWER([award type]) = 'primary' ) ";
        //        //}

        //        string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        //        using (SqlConnection con = new SqlConnection(connStr))
        //        {
        //            using (SqlCommand command = new SqlCommand(sQuery, con))
        //            {
        //                con.Open();

        //                using (SqlDataAdapter sda = new SqlDataAdapter(command))
        //                {
        //                    command.Parameters.AddWithValue("@customer", sCustomer);
        //                    command.Parameters.AddWithValue("@csr_id", csr);
        //                    command.Parameters.AddWithValue("@salesperson", salesPerson);
        //                    //command.Parameters.AddWithValue("@start_date", dateFrom.Value);
        //                    //command.Parameters.AddWithValue("@end_date", dateTo.Value);

        //                    System.Data.DataTable dt = new System.Data.DataTable();
        //                    sda.Fill(dt);

        //                    if (dt != null && dt.Rows.Count > 0)
        //                    {

        //                    }
        //                    //{
        //                    //    foreach (DataRow row in dt.Rows)
        //                    //    {
        //                    //        string customer = row[0].ToString();
        //                    //        string csrId = row[1].ToString();
        //                    //        string salesPersonId = row[2].ToString();
        //                    //        string originZip = row[6].ToString();
        //                    //        string destZip = row[10].ToString();
        //                    //        string originZipRange = row[3].ToString();
        //                    //        string destZipRange = row[7].ToString();
        //                    //        string originCity = row[4].ToString();
        //                    //        string originState = row[5].ToString();
        //                    //        string destCity = row[8].ToString();
        //                    //        string destState = row[9].ToString();

        //                    //        int loads = 0;
        //                    //        decimal profit = 0;

        //                    //        getTotals(customer, csrId, salesPersonId, originZip, destZip, originZipRange, destZipRange, originCity, originState, destCity, destState, ref loads, ref profit);

        //                    //        row["Loads"] = loads.ToString();
        //                    //        //row["Avg Profit"] = profit.ToString("c");
        //                    //        profit = Math.Round(profit, 2);
        //                    //        row["Avg Profit"] = profit.ToString();
        //                    //    }
        //                    //}

        //                    dataGridResults.DataSource = dt;
        //                    //dataGridView1.DataSource = null;
        //                    lblNumLoads.Text = "";
        //                    lblTotalProfit.Text = "";
        //                }

        //                //fixSort();
        //                con.Close();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void cmdSearchMonth_Click(object sender, EventArgs e)
        //{
        //    doSearchMonthly();
        //}


    }

}