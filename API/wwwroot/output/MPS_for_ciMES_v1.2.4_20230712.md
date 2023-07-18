![ref1]![ref2]

**Evaluation Only. Created with Aspose.Words. Copyright 2003-2023 Aspose Pty Ltd.**

<a name="ole_link7"></a>**翔鑫堡工業股份有限公司**

**報　　　告**

部　門： 系統開發部                                  編號：            

報告人：   張軒瑜    	日期： 2023 年 07 月 12 日

|<p>主</p><p>題</p>|MPS for ciMES系統需求規格書v1.2.4|
| :-: | :- |
|董事長||
|<p>執</p><p>行</p><p>副</p><p>總</p>||
|<p>管</p><p>理</p><p>本</p><p>部</p>||
|<p>會</p><p>簽</p><p>部</p><p>門</p><p>意</p><p>見</p>||
|<p>部</p><p>門</p><p>主</p><p>管</p>|<p></p><p></p><p>                   </p>|

sw7048
**Created with an evaluation copy of Aspose.Words. To discover the full versions of our APIs please visit: https://products.aspose.com/words/**

1

![ref3]![ref2]MPS for ciMES系統需求規格書

![](MPS_for_ciMES_v1.2.4_20230712.007.png)

MPS for ciMES系統

需求規格書v1.2.4

MPS for ciMES System – Specification


系統開發部

2023/07/12

張軒瑜 製
![](MPS_for_ciMES_v1.2.4_20230712.004.png)![Description: Light vertical](MPS_for_ciMES_v1.2.4_20230712.005.png)![](MPS_for_ciMES_v1.2.4_20230712.006.png)![](MPS_for_ciMES_v1.2.4_20230712.008.png)

# **目錄**
[一、	版本更新說明	2](#_toc140051502)

[二、	引言	2](#_toc140051503)

[01.	系統概述：	2](#_toc140051506)

[三、	系統程式與功能說明	3](#_toc140051507)

[**01.**	**「MPS000 System connect」 (系統介接)**	3](#_toc140051508)

[**02.**	**「MPS001 Print Material Sheet」MPS001 列印發料單**	5](#_toc140051509)

[**03.**	**「MPS002 Reprint Material Sheet」MPS002 重列印發料單**	20](#_toc140051510)

[**04.**	**「MPS003 Print Material Sheet (OEM Order)」MPS003 列印發料單(代工訂單)**	35](#_toc140051511)

[**05.**	**「MPS004 Reprint Material Sheet (OEM Order)」MPS004重列印發料單(代工訂單)**	45](#_toc140051512)

[**06.**	**「MPS005 Print Material Sheet (Replenishment)」MPS005 列印發料單(補料)**	54](#_toc140051513)

[**07.**	**「MPS006 Reprint Material Sheet (Replenishment)」MPS006 重列印發料單(補料)**	66](#_toc140051514)

[**08.**	**「MPS101 Print Pickup Form」MPS101 列印取料單**	78](#_toc140051515)

[**09.**	**「MPS102 Reprint Pickup Form」MPS102 重列印取料單 (Not ready)**	101](#_toc140051516)

[**10.**	**「MPS103 Print Pickup Form (OEM Order)」MPS103列印取料單(代工訂單)**	102](#_toc140051517)

[**11.**	**「MPS201 Pickup Form Status Change」MPS201 取料單狀態變更**	116](#_toc140051518)

[**12.**	**「MPS202 Cancel Pickup Form」MPS202 取消取料單**	120](#_toc140051519)

[**13.**	**「MPS203 PO Close」MPS203 訂單結案**	122](#_toc140051520)

[**14.**	**「MPS301 Material Calling PA」MPS301 PA料號叫料**	125](#_toc140051521)

[**15.**	**「MPS302 Material Calling UA」MPS302 UA料號叫料**	129](#_toc140051522)

[**16.**	**「MPS303 Material Calling BA」MPS303 BA料號叫料**	133](#_toc140051523)

[**17.**	**「MPS304 Material Calling FA」MPS304 FA料號叫料**	137](#_toc140051524)

[四、	附錄	141](#_toc140051525)





1. <a name="_toc140051502"></a>版本更新說明

|版次|修訂日期|更修者|描述|備註|
| :- | :- | :- | :- | :- |
|v1.0.0|2023/02/21|張軒瑜|系統建置|無需求單號|
|v1.0.1|2023/02/28|張軒瑜|新增MPS006~MPS009，Material Calling PA、UA、BA、FA|無需求單號|
|v1.0.2|2023/03/17|張軒瑜|新增MPS005 Pickup Form Status Change|無需求單號|
|v1.0.3|2023/03/23|張軒瑜|新增MPS201、MPS202，取消取料單、訂單結案|無需求單號|
|v1.0.4|2023/03/31|張軒瑜|新增MPS002 重列印發料單|無需求單號|
|v1.0.5|2023/04/03|張軒瑜|MPS001、MPS002新增資料JOIN條件|無需求單號|
|v1.0.6|2023/04/05|張軒瑜|MPS006~MPS009，可叫料時，按鈕顯示為綠色|無需求單號|
|v1.0.7|2023/04/06|張軒瑜|MPS001、MPS002無尺寸、有尺寸，判斷方式調整|無需求單號|
|v1.0.8|2023/05/05|張軒瑜|新增MPS003 列印取料單|無需求單號|
|v1.0.9|2023/05/08|張軒瑜|新增MPS010 發料單重印(代工訂單)|無需求單號|
|v1.1.0|2023/05/09|張軒瑜|MPS001、MPS002 新增判斷是否為重包裝工單|無需求單號|
|v1.1.1|2023/05/11|張軒瑜|移除所有FACTORY的JOIN條件|無需求單號|
|v1.1.2|2023/05/12|張軒瑜|MPS001、MPS002，材料名稱欄位調整|無需求單號|
|v1.1.3|2023/05/15|張軒瑜|新增MPS011 列印取料單(代工訂單)|無需求單號|
|v1.1.4|2023/05/18|張軒瑜|MPS001、MPS002，材料名稱欄位JOIN條件調整|無需求單號|
|v1.1.5|2023/05/18|張軒瑜|MPS003 [SEQUENCE]邏輯調整、MPS010搜尋條件MATERIAL\_NAME條件調整|無需求單號|
|v1.1.6|2023/06/01|張軒瑜|<p>1\.MPS003、MPS011，取消，取料單列印時，同時列印出發料單</p><p>2\.MPS001、MPS002搜尋條件調整</p><p>3\.程式編號調整</p><p>4\.新增列印發料單(代工訂單)</p>|無需求單號|
|v1.1.7|2023/06/17|張軒瑜|新增MPS005列印發料單(補料)，MPS006重列印發料單(補料)|無需求單號|
|v1.1.8|2023/06/20|張軒瑜|發料單邏輯調整、新增Model Name欄位|無需求單號|
|v1.1.9|2023/06/27|張軒瑜|取料單邏輯調整|無需求單號|
|v1.2.0|2023/07/03|張軒瑜|材料名稱全部改抓MATERIAL\_SPEC|無需求單號|
|v1.2.1|2023/07/05|張軒瑜|MPS301~MPS304 Material Calling PA、UA、BA、FA邏輯調整|無需求單號|
|v1.2.2|2023/07/07||||

**This document was truncated here because it was created in the Evaluation Mode.**
**Created with an evaluation copy of Aspose.Words. To discover the full versions of our APIs please visit: https://products.aspose.com/words/**

1

[ref1]: MPS_for_ciMES_v1.2.4_20230712.001.png
[ref2]: MPS_for_ciMES_v1.2.4_20230712.002.png
[ref3]: MPS_for_ciMES_v1.2.4_20230712.003.png
