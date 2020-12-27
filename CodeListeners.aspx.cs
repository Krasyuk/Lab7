using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageCoursesWebApp.Models;
namespace LanguageCoursesWebApp
{
    public partial class CodeListeners : System.Web.UI.Page
    {
        private Data.AppContext _db = new Data.AppContext();
        private string strFindListener = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                strFindListener = TextBoxFindListener.Text;
                ShowData(strFindListener);
            }

        }

        protected void GridViewListener_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewListener.EditIndex = e.NewEditIndex;
            ShowData(strFindListener);

        }


        protected void GridViewListener_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewListener.Rows[e.RowIndex];
            int id = Convert.ToInt32(((TextBox)(row.Cells[1].Controls[0])).Text);
            Listener Listener = _db.Listeners.Where(f => f.ListenerId == id).FirstOrDefault();
            Listener.NameOfListener = e.NewValues["NameOfListener"].ToString();
            Listener.Surname = e.NewValues["Surname"].ToString();
            Listener.MiddleName = e.NewValues["MiddleName"].ToString();
            Listener.DateOfBirth = Convert.ToDateTime(e.NewValues["DateOfBirth"].ToString());
            Listener.Address = e.NewValues["Address"].ToString();
            Listener.Phone = e.NewValues["Phone"].ToString();
            Listener.PassportData = e.NewValues["PassportData"].ToString();
            _db.SaveChanges();
            GridViewListener.EditIndex = -1;

            ShowData(strFindListener);

        }

        protected void GridViewListener_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridViewListener.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[1].Text);
            Listener Listener = _db.Listeners.Where(f => f.ListenerId == id).FirstOrDefault();
            _db.Listeners.Remove(Listener);

            _db.SaveChanges();
            GridViewListener.EditIndex = -1;
            ShowData(strFindListener);

        }


        protected void GridViewListener_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewListener.EditIndex = 1;
            ShowData(strFindListener);
        }


        protected void ButtonFindListener_Click(object sender, EventArgs e)
        {
            strFindListener = TextBoxFindListener.Text;
            ShowData(strFindListener);
        }

        protected void ButtonAddListener_Click(object sender, EventArgs e)
        {
            string nameOfListener = TextBoxNameOfListener.Text;
            string surName = TextBoxSurName.Text;
            string middleName = TextBoxMiddleName.Text;
            DateTime dateOfBirth = Convert.ToDateTime(TextBoxDateOfBirth.SelectedDate);
            string address = TextBoxAddress.Text;
            string phone = TextBoxPhone.Text;
            string passportData = TextBoxPassportData.Text;
            Listener Listener = new Listener
            {
                NameOfListener = nameOfListener,
                Surname = surName,
                MiddleName = middleName,
                DateOfBirth = dateOfBirth,
                Address = address,
                Phone = phone,
                PassportData = passportData
            };

            _db.Listeners.Add(Listener);
            _db.SaveChanges();
            TextBoxNameOfListener.Text = "";
            TextBoxSurName.Text = "";
            TextBoxMiddleName.Text = "";
            TextBoxAddress.Text = "";
            TextBoxPhone.Text = "";
            TextBoxPassportData.Text = "";
            TextBoxDateOfBirth = default;
            ShowData(strFindListener);
        }
        protected void GridViewListener_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewListener.PageIndex = e.NewPageIndex;
            ShowData(strFindListener);

        }
        protected void ShowData(string strFindListener = "")
        {

            List<Listener> Listeners = _db.Listeners.Where(s => s.NameOfListener.Contains(strFindListener)).ToList();
            GridViewListener.DataSource = Listeners;
            GridViewListener.DataBind();
        }
    }
}