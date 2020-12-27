using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageCoursesWebApp.Models;

namespace LanguageCoursesWebApp
{
    public partial class CodePayments : System.Web.UI.Page
    {
        private Data.AppContext _db = new Data.AppContext();
        private string strFindPayment = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                strFindPayment = TextBoxFindPayment.Text;
                ShowData(strFindPayment);
            }

        }

        protected void GridViewPayment_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewPayment.EditIndex = e.NewEditIndex;
            ShowData(strFindPayment);

        }


        protected void GridViewPayment_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewPayment.Rows[e.RowIndex];
            int id = Convert.ToInt32(((TextBox)(row.Cells[1].Controls[0])).Text);
            Payment Payment = _db.Payments.Where(f => f.PaymentId == id).FirstOrDefault();
            Payment.NameOfCourses = e.NewValues["NameOfCourses"].ToString();
            Payment.Date = Convert.ToDateTime(e.NewValues["Date"].ToString());
            Payment.Sum = Convert.ToDecimal(e.NewValues["Sum"].ToString());
            Payment.ListenerId = Convert.ToInt32(e.NewValues["listenerId"].ToString());
            Payment.LastPaymentDate = Convert.ToDateTime(e.NewValues["LastPaymentDate"].ToString());
            Payment.CourseId = int.Parse(e.NewValues["courseId"].ToString());
            _db.SaveChanges();
            GridViewPayment.EditIndex = -1;

            ShowData(strFindPayment);

        }

        protected void GridViewPayment_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridViewPayment.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[1].Text);
            Payment Payment = _db.Payments.Where(f => f.PaymentId == id).FirstOrDefault();
            _db.Payments.Remove(Payment);

            _db.SaveChanges();
            GridViewPayment.EditIndex = -1;
            ShowData(strFindPayment);

        }


        protected void GridViewPayment_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewPayment.EditIndex = 1;
            ShowData(strFindPayment);
        }


        protected void ButtonFindPayment_Click(object sender, EventArgs e)
        {
            strFindPayment = TextBoxFindPayment.Text;
            ShowData(strFindPayment);
        }

        protected void ButtonAddPayment_Click(object sender, EventArgs e)
        {
            string nameOfCourse = TextBoxNameOfCourse.Text;
            DateTime date = TextBoxDate.SelectedDate;
            decimal sum = Convert.ToDecimal(TextBoxSum.Text);
            int listenerId = int.Parse(ListenerDropDownList.SelectedValue);
            DateTime lastPaymentDate = TextBoxLastPaymentDate.SelectedDate;
            int courseId = int.Parse(CourseDropDownList.SelectedValue);
            Payment Payment = new Payment
            {
                NameOfCourses = nameOfCourse,
                Date = date,
                Sum = sum,
                ListenerId = listenerId,
                LastPaymentDate = lastPaymentDate,
                CourseId = courseId
            };

            _db.Payments.Add(Payment);
            _db.SaveChanges();
            TextBoxNameOfCourse.Text = "";
            TextBoxSum.Text = "";
            TextBoxDate = default;
            TextBoxLastPaymentDate = default;
            ShowData(strFindPayment);
        }
        protected void GridViewPayment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewPayment.PageIndex = e.NewPageIndex;
            ShowData(strFindPayment);

        }
        protected void ShowData(string strFindPayment = "")
        {

            List<Payment> Payments = _db.Payments.Where(s => s.NameOfCourses.Contains(strFindPayment)).ToList();
            GridViewPayment.DataSource = Payments;
            GridViewPayment.DataBind();
        }
    }
}