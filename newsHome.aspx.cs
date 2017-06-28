﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class newsHome : System.Web.UI.Page
{
    #region Members
    const int PAGESIZE = 8;//每页显示信息数量 
    int PagesCount, RecordsCount;//记录总页数和信息总条数 
    int CurrentPage, Pages, JumpPage;//当前页，信息总页数(用来控制按钮失效)，跳转页码 
    const string COUNT_SQL = "select count(*)  from News";
    #endregion
    public string welcomeBack;
    protected void Page_Load(object sender, EventArgs e)
    {
        welcomeBack = new Request().ReturnValue;
        if(!IsPostBack)
        Page_Init();
    }
    public void Page_Init()
    {
        RecordsCount = GetRecordsCount("default");//默认信息总数 
        PagesCount = RecordsCount / PAGESIZE + OverPage();//默认的页总数 
        ViewState["PagesCount"] = RecordsCount / PAGESIZE - ModPage();//保存末页索引，比页总数小1 
        ViewState["PageIndex"] = 0;//保存页面初始索引从0开始 
        ViewState["JumpPages"] = PagesCount;
        ViewState["PageOrderBy"] = "count";
        ViewState["SelectedNewsType"] = "All";
        //保存页总数，跳页时判断用户输入数是否超出页码范围 
        //显示lbPageCount、lbRecordCount的状态 
        lbPageCount.Text = PagesCount.ToString();
        lbRecordCount.Text = RecordsCount.ToString();
        //判断跳页文本框失效 
        if (RecordsCount <= 10)
        {
            GotoPage.Enabled = false;
        }
        GridViewDataBind("default");//调用数据绑定函数TDataBind()进行数据绑定运算 
    }
    /// <summary> 
    /// 获取信息总数 
    /// </summary> 
    /// <param name="sqlSearch"></param> 
    /// <returns></returns> 
    public static int GetRecordsCount(string sqlRecordsCount)
    {
        string sqlQuery;
        if (sqlRecordsCount == "default")
        {
            sqlQuery = COUNT_SQL;
        }
        else
        {
            sqlQuery = sqlRecordsCount;
        }
        int RecordCount = 0;
        SqlCommand cmd = new SqlCommand(sqlQuery, Conn());
        RecordCount = Convert.ToInt32(cmd.ExecuteScalar());
        cmd.Connection.Close();
        return RecordCount;
    }
    /// <summary> 
    /// 计算余页 
    /// </summary> 
    /// <returns></returns> 
    public int OverPage()
    {
        int pages = 0;
        if (RecordsCount % PAGESIZE != 0)
            pages = 1;
        else
            pages = 0;
        return pages;
    }
    /// <summary> 
    /// 计算余页，防止SQL语句执行时溢出查询范围 
    /// </summary> 
    /// <returns></returns> 
    public int ModPage()
    {
        int pages = 0;
        if (RecordsCount % PAGESIZE == 0 && RecordsCount != 0)
            pages = 1;
        else
            pages = 0;
        return pages;
    }
    /// <summary> 
    /// 数据连接对象 
    /// </summary> 
    /// <returns></returns> 

    /// <summary> 
    /// GridView数据绑定，根据传入参数的不同，进行不同方式的查询， 
    /// </summary> 
    /// <param name="sqlSearch"></param> 
    private void GridViewDataBind(string sqlSearch)
    {
        CurrentPage = (int)ViewState["PageIndex"];
        //从ViewState中读取页码值保存到CurrentPage变量中进行按钮失效运算 
        Pages = (int)ViewState["PagesCount"];
        //从ViewState中读取总页参数进行按钮失效运算 
        //判断四个按钮（首页、上一页、下一页、尾页）状态 
        if (CurrentPage + 1 > 1)//当前页是否为首页 
        {
            Fistpage.Enabled = true;
            Prevpage.Enabled = true;
        }
        else
        {
            Fistpage.Enabled = false;
            Prevpage.Enabled = false;
        }
        if (CurrentPage == Pages)//当前页是否为尾页 
        {
            Nextpage.Enabled = false;
            Lastpage.Enabled = false;
        }
        else
        {
            Nextpage.Enabled = true;
            Lastpage.Enabled = true;
        }
        DataSet ds = new DataSet();
        string sqlResult;
        //根据传入参数sqlSearch进行判断，如果为default则为默认的分页查询，否则为添加了过滤条件的分页查询 
        if (sqlSearch == "default")
        {
            sqlResult = "Select Top " + PAGESIZE + "NewsID,NewsTitle,Date from News where NewsID not in(select top " + PAGESIZE * CurrentPage + " NewsID from News order by " + ViewState["PageOrderBy"].ToString() + " DESC) order by " + ViewState["PageOrderBy"].ToString() + " DESC";
        }
        else
        {
            sqlResult = sqlSearch;
        }
        SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlResult, Conn());
        sqlAdapter.Fill(ds, "Result");
        UserGridView.DataSource = ds.Tables["Result"].DefaultView;
        UserGridView.DataBind();
        //显示Label控件lbCurrentPaget和文本框控件GotoPage状态 
        lbCurrentPage.Text = (CurrentPage + 1).ToString();
        GotoPage.Text = (CurrentPage + 1).ToString();
        sqlAdapter.Dispose();
    }
    public static SqlConnection Conn()
    {
        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True");
        conn.Open();
        return conn;
    }
    protected void PagerBtnCommand_OnClick(object sender, EventArgs e)
    {
        CurrentPage = (int)ViewState["PageIndex"];
        //从ViewState中读取页码值保存到CurrentPage变量中进行参数运算 
        Pages = (int)ViewState["PagesCount"];//从ViewState中读取总页参数运算 
        Button btn = sender as Button;
        string sqlResult = "default";
        if (btn != null)
        {
            string cmd = btn.CommandName;
            switch (cmd)//根据不同的CommandName做出不同的处理 
            {
                case "next":
                    CurrentPage++;
                    break;
                case "prev":
                    CurrentPage--;
                    break;
                case "last":
                    CurrentPage = Pages;
                    break;
                case "search":
                    if (!string.IsNullOrEmpty(SearchName.Text))
                    {
                        RecordsCount = GetRecordsCount("select count(*) from News where NewsTitle like '" + SearchName.Text + "%'");//获取过滤后的总记录数  
                        PagesCount = RecordsCount / PAGESIZE + OverPage();//该变量为页总数  
                        ViewState["PagesCount"] = RecordsCount / PAGESIZE - ModPage();//该变量为末页索引，比页总数小1  
                        ViewState["PageIndex"] = 0;//保存一个为0的页面索引值到ViewState，页面索引从0开始  
                        ViewState["JumpPages"] = PagesCount;
                        //保存PageCount到ViewState，跳页时判断用户输入数是否超出页码范围  
                        //显示lbPageCount、lbRecordCount的状态  
                        lbPageCount.Text = PagesCount.ToString();
                        lbRecordCount.Text = RecordsCount.ToString();
                        //判断跳页文本框失效  
                        if (RecordsCount <= 10)
                            GotoPage.Enabled = false;
                        sqlResult = "Select Top " + PAGESIZE + "NewsID,NewsTitle,Date from News where NewsID not in(select top " + PAGESIZE * CurrentPage + " NewsID from News order by NewsID asc) and NewsTitle like '%" + SearchName.Text + "%' order by NewsID asc";
                    }
                    //                  ResetSearch();
                    break;
                case "jump":
                    JumpPage = (int)ViewState["JumpPages"];
                    //从ViewState中读取可用页数值保存到JumpPage变量中 
                    //判断用户输入值是否超过可用页数范围值 
                    if (Int32.Parse(GotoPage.Text) > JumpPage || Int32.Parse(GotoPage.Text) <= 0)
                        Response.Write("<script>alert('Warning!')</script>");
                    else
                    {
                        int InputPage = Int32.Parse(GotoPage.Text.ToString()) - 1;
                        //转换用户输入值保存在int型InputPage变量中 
                        ViewState["PageIndex"] = InputPage;
                        CurrentPage = InputPage;
                        //写入InputPage值到ViewState["PageIndex"]中 
                    }
                    break;
                default:
                    CurrentPage = 0;
                    break;
            }
            ViewState["PageIndex"] = CurrentPage;
            //将运算后的CurrentPage变量再次保存至ViewState 
            GridViewDataBind(sqlResult);//调用数据绑定函数TDataBind() 
        }
    }
    protected void orderBy_SelectedIndexChanged(object sender, EventArgs e)
    {
        CurrentPage = (int)ViewState["PageIndex"];
        //从ViewState中读取页码值保存到CurrentPage变量中进行参数运算 
        Pages = (int)ViewState["PagesCount"];//从ViewState中读取总页参数运算 
        string selected = orderBy.SelectedValue.ToString();
        ViewState["PageOrderBy"] = selected;
        RecordsCount = GetRecordsCount("select count(*) from News");//获取过滤后的总记录数  
        PagesCount = RecordsCount / PAGESIZE + OverPage();//该变量为页总数  
        ViewState["PagesCount"] = RecordsCount / PAGESIZE - ModPage();//该变量为末页索引，比页总数小1  
        ViewState["PageIndex"] = 0;//保存一个为0的页面索引值到ViewState，页面索引从0开始  
        ViewState["JumpPages"] = PagesCount;
        //保存PageCount到ViewState，跳页时判断用户输入数是否超出页码范围  
        //显示lbPageCount、lbRecordCount的状态  
        lbPageCount.Text = PagesCount.ToString();
        lbRecordCount.Text = RecordsCount.ToString();
        //判断跳页文本框失效  
        if (RecordsCount <= 10)
            GotoPage.Enabled = false;
        string sqlResult = "";
        if (ViewState["SelectedNewsType"].ToString().Equals("All"))
        {
            sqlResult = "Select Top " + PAGESIZE + "NewsID,NewsTitle,Date from News where NewsID not in(select top " + PAGESIZE * CurrentPage + " NewsID from News order by " + selected + " DESC) order by " + selected + " DESC";

        }
        else
        {
            sqlResult = "Select Top " + PAGESIZE + "NewsID,NewsTitle,Date from News where NewsTypeID = ( SELECT NewsTypeID FROM NewsType WHERE NewsTypeName = '" + selected + "') AND NewsID not in(select top " + PAGESIZE * CurrentPage + " NewsID from Game Where NewsTypeID = " + Convert.ToInt32(ViewState["SelectedNewsType"]) + " order by " + selected + " DESC) order by " + selected + " DESC";
        }
        ViewState["PageIndex"] = CurrentPage;
        //将运算后的CurrentPage变量再次保存至ViewState 
        GridViewDataBind(sqlResult);//调用数据绑定函数TDataBind() 
    }
    protected void SelectedTag_SelectedIndexChanged(object sender, EventArgs e)
    {
        CurrentPage = (int)ViewState["PageIndex"];
        //从ViewState中读取页码值保存到CurrentPage变量中进行参数运算 
        Pages = (int)ViewState["PagesCount"];//从ViewState中读取总页参数运算 
        string selected = selectedTag.SelectedValue.ToString();
        ViewState["SelectedNewsType"] = selected;
        RecordsCount = GetRecordsCount("select count(*) from News Where NewsTypeID =(SELECT NewsTypeID FROM NewsType WHERE NewsTypeName = '" + selected + "')");  //获取过滤后的总记录数  
        PagesCount = RecordsCount / PAGESIZE + OverPage();//该变量为页总数  
        ViewState["PagesCount"] = RecordsCount / PAGESIZE - ModPage();//该变量为末页索引，比页总数小1  
        ViewState["PageIndex"] = 0;//保存一个为0的页面索引值到ViewState，页面索引从0开始  
        ViewState["JumpPages"] = PagesCount;
        //保存PageCount到ViewState，跳页时判断用户输入数是否超出页码范围  
        //显示lbPageCount、lbRecordCount的状态  
        lbPageCount.Text = PagesCount.ToString();
        lbRecordCount.Text = RecordsCount.ToString();
        //判断跳页文本框失效  
        if (RecordsCount <= 10)
            GotoPage.Enabled = false;
        string sqlResult = "";
        if (selected.Equals("3"))
        {
            RecordsCount = GetRecordsCount("default");//默认信息总数  
            PagesCount = RecordsCount / PAGESIZE + OverPage();//默认的页总数  
            ViewState["PagesCount"] = RecordsCount / PAGESIZE - ModPage();//保存末页索引，比页总数小1  
            ViewState["PageIndex"] = 0;//保存页面初始索引从0开始  
            ViewState["JumpPages"] = PagesCount;
            ViewState["SelectedNewsType"] = "*";
            //保存页总数，跳页时判断用户输入数是否超出页码范围  
            //显示lbPageCount、lbRecordCount的状态  
            lbPageCount.Text = PagesCount.ToString();
            lbRecordCount.Text = RecordsCount.ToString();
            //判断跳页文本框失效  
            if (RecordsCount <= 10)
            {
                GotoPage.Enabled = false;
            }
            sqlResult = "Select Top " + PAGESIZE + "NewsID,NewsTitle,Date from News where NewsID not in (select top " + PAGESIZE * CurrentPage + " NewsID from News order by " + ViewState["PageOrderBy"].ToString() + " DESC ) order by " + ViewState["PageOrderBy"].ToString() + " DESC";
        }
        else
        {
            sqlResult = "Select Top " + PAGESIZE + "NewsID,NewsTitle,Date from News where NewsTypeID= '" + selected + "' AND NewsID not in(select top " + PAGESIZE * CurrentPage + " NewsID from News where NewsTypeID = (SELECT NewsTypeID FROM NewsType WHERE NewsTypeName = '" + selected + "') order by " + ViewState["PageOrderBy"].ToString() + " DESC) order by " + ViewState["PageOrderBy"].ToString() + " DESC";
        }
        ViewState["PageIndex"] = CurrentPage;
        //将运算后的CurrentPage变量再次保存至ViewState 
        GridViewDataBind(sqlResult);//调用数据绑定函数TDataBind() 
    }
}