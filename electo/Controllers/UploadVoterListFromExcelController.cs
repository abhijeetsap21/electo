using electo.Models;
using electo.Models.BaseClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace electo.Controllers
{
    public class UploadVoterListFromExcelController : BaseClass
    {
        public ActionResult importExcel()
        {
            return View();
        }

        [ActionName("importExcel")]
        [HttpPost]
        public ActionResult importexcel1()
        {

            if (Request.Files["FileUpload1"].ContentLength > 0)
            {
                string extension = System.IO.Path.GetExtension(Request.Files["FileUpload1"].FileName).ToLower();

                string connString = "";


                string[] validFileTypes = { ".xls", ".xlsx", ".csv" };

                string path1 = string.Format("{0}/{1}", Server.MapPath("~/Content/Uploads"), Request.Files["FileUpload1"].FileName);
                if (!Directory.Exists(path1))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Content/Uploads"));
                }
                if (validFileTypes.Contains(extension))
                {
                    if (System.IO.File.Exists(path1))
                    { System.IO.File.Delete(path1); }
                    Request.Files["FileUpload1"].SaveAs(path1);
                    if (extension.Trim() == ".xlsx")
                    {
                        connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path1 + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                        DataTable dt = Utility.ConvertXSLXtoDataTable(path1, connString);
                        
                        List<excel> excel = new List<excel>();
                        excel objexcel;

                        var c = dt.Rows.Count;
                        for (int i = 0; i < c; i++)
                        {
                            objexcel = new excel();
                            if (dt.Rows[i]["ID"].ToString() != "")
                            {
                                objexcel.ID = Convert.ToInt16(dt.Rows[i]["ID"].ToString());
                            }
                            if (dt.Rows[i]["statename"].ToString() != "")
                            {
                                objexcel.statename = dt.Rows[i]["statename"].ToString();
                            }
                            if (dt.Rows[i]["loksabhaname"].ToString() != "")
                            {
                                objexcel.loksabhaname = dt.Rows[i]["loksabhaname"].ToString();
                            }
                            if (dt.Rows[i]["districtname"].ToString() != "")
                            {
                                objexcel.districtname = dt.Rows[i]["districtname"].ToString();
                            }
                            if (dt.Rows[i]["vidhansabhaname"].ToString() != "")
                            {
                                objexcel.vidhansabhaname = dt.Rows[i]["vidhansabhaname"].ToString();
                            }
                            if (dt.Rows[i]["municipalcorporationname"].ToString() != "")
                            {
                                objexcel.municipalcorporationname = dt.Rows[i]["municipalcorporationname"].ToString();
                            }
                            if (dt.Rows[i]["zonename"].ToString() != "")
                            {
                                objexcel.zonename = dt.Rows[i]["zonename"].ToString();
                            }
                            if (dt.Rows[i]["wardname"].ToString() != "")
                            {
                                objexcel.wardname = dt.Rows[i]["wardname"].ToString();
                            }
                            if (dt.Rows[i]["pollingboothname"].ToString() != "")
                            {
                                objexcel.pollingboothname = dt.Rows[i]["pollingboothname"].ToString();
                            }
                            if (dt.Rows[i]["sectionName"].ToString() != "")
                            {
                                objexcel.areaname = dt.Rows[i]["sectionName"].ToString();
                            }
                            if (dt.Rows[i]["age"].ToString() != "")
                            {
                                objexcel.age = dt.Rows[i]["age"].ToString();
                            }
                            if (dt.Rows[i]["voterfirstname"].ToString() != "")
                            {
                                objexcel.voterfirstname = dt.Rows[i]["voterfirstname"].ToString();
                            }
                            if (dt.Rows[i]["voterlastname"].ToString() != "")
                            {
                                objexcel.voterlastname = dt.Rows[i]["voterlastname"].ToString();
                            }
                            if (dt.Rows[i]["voteridnumber"].ToString() != "")
                            {
                                objexcel.voteridnumber = dt.Rows[i]["voteridnumber"].ToString();
                            }
                            if (dt.Rows[i]["FatherName"].ToString() != "")
                            {
                                objexcel.FatherName = dt.Rows[i]["FatherName"].ToString();
                            }
                            if (dt.Rows[i]["plotno"].ToString() != "")
                            {
                                objexcel.plotno = dt.Rows[i]["plotno"].ToString();
                            }
                            if (dt.Rows[i]["wardno"].ToString() != "")
                            {
                                objexcel.wardno = dt.Rows[i]["wardno"].ToString();
                            }
                            if (dt.Rows[i]["gender"].ToString() != "")
                            {
                                objexcel.gender = dt.Rows[i]["gender"].ToString();
                            }
                            if (dt.Rows[i]["zipCode"].ToString() != "")
                            {
                                objexcel.zipCode = dt.Rows[i]["zipCode"].ToString();
                            }

                            if (dt.Rows[i]["dateofbirth"].ToString() != "")
                            {
                                var dte = Convert.ToDateTime(dt.Rows[i]["dateofbirth"].ToString());
                                objexcel.dateofbirth = dte;
                            }
                            objexcel.createdBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
                            objexcel.createdDate = BaseUtil.GetCurrentDateTime();
                            excel.Add(objexcel);
                        }
                        electoEntities ee = new electoEntities();
                        try
                        {
                            ee.excels.AddRange(excel);
                            ee.SaveChanges();

                            var result = ee.Database.SqlQuery<int>("exec sp_insertVoterListExcel").FirstOrDefault();

                        }
                        catch { ViewBag.Error = "errro"; }
                        ViewBag.Data = dt;
                    }

                    else
                    {
                        ViewBag.Error = "Please Upload File .xlsx format";

                    }

                }
            }

            return View();
        }
    }
    }
