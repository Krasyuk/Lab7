using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageCoursesWebApp.Models;
using System.Data.Entity;

namespace LanguageCoursesWebApp
{
    public partial class CodeCourses : System.Web.UI.Page
    {
        private Data.AppContext _db = new Data.AppContext();
        private string strFindCourse = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                strFindCourse = TextBoxFindCourse.Text;
                ShowData(strFindCourse);
            }

        }

        protected void GridViewCourse_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewCourse.EditIndex = e.NewEditIndex;
            ShowData(strFindCourse);

        }


        protected void GridViewCourse_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewCourse.Rows[e.RowIndex];
            int id = Convert.ToInt32(((TextBox)(row.Cells[1].Controls[0])).Text);
            Course Course = _db.Courses.Where(f => f.CourseId == id).FirstOrDefault();
            Course.NameOfCourse = e.NewValues["NameOfCourse"].ToString();
            Course.TrainingProgram = e.NewValues["TrainingProgram"].ToString();
            Course.Description = e.NewValues["Description"].ToString();
            Course.IntensityOfClasses = e.NewValues["IntensityOfClasses"].ToString();
            Course.GroupSize = int.Parse(e.NewValues["GroupSize"].ToString());
            Course.FreePlaces = int.Parse(e.NewValues["FreePlaces"].ToString());
            Course.NumberOfHours = int.Parse(e.NewValues["NumberOfHours"].ToString());
            Course.Cost = Convert.ToDecimal(e.NewValues["Cost"].ToString());
            Course.TeacherId = int.Parse(e.NewValues["teacherId"].ToString());
            _db.SaveChanges();
            GridViewCourse.EditIndex = -1;

            ShowData(strFindCourse);

        }

        protected void GridViewCourse_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridViewCourse.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[1].Text);
            Course Course = _db.Courses.Where(f => f.CourseId == id).FirstOrDefault();
            _db.Courses.Remove(Course);

            _db.SaveChanges();
            GridViewCourse.EditIndex = -1;
            ShowData(strFindCourse);

        }


        protected void GridViewCourse_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewCourse.EditIndex = 1;
            ShowData(strFindCourse);
        }


        protected void ButtonFindCourse_Click(object sender, EventArgs e)
        {
            strFindCourse = TextBoxFindCourse.Text;
            ShowData(strFindCourse);
        }

        protected void ButtonAddCourse_Click(object sender, EventArgs e)
        {
            string nameOfCourse = TextBoxNameOfCourse.Text;
            string trainingProgram = TextBoxProgram.Text;
            string description = TextBoxDescription.Text;
            string intincity = TextBoxIntensityOfClasses.Text;
            int groupSize = int.Parse(TextBoxGroupSize.Text);
            int freePlaces = int.Parse(TextBoxFreePlaces.Text);
            int numberOFHours = int.Parse(TextBoxNumberOfHours.Text);
            decimal cost = Convert.ToDecimal(TextBoxCost.Text);
            int teacherId = int.Parse(TeacherDropDownList.SelectedValue);
            Course Course = new Course
            {
                NameOfCourse = nameOfCourse,
                TrainingProgram = trainingProgram,
                Description = description,
                IntensityOfClasses = intincity,
                GroupSize = groupSize,
                FreePlaces = freePlaces,
                NumberOfHours = numberOFHours,
                Cost = cost,
                TeacherId = teacherId
            };

            _db.Courses.Add(Course);
            _db.SaveChanges();
            TextBoxNameOfCourse.Text = "";
            TextBoxProgram.Text = "";
            TextBoxDescription.Text = "";
            TextBoxIntensityOfClasses.Text = "";
            TextBoxGroupSize.Text = "";
            TextBoxFreePlaces.Text = "";
            TextBoxNumberOfHours.Text = "";
            TextBoxCost.Text = "";
            ShowData(strFindCourse);
        }
        protected void GridViewCourse_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewCourse.PageIndex = e.NewPageIndex;
            ShowData(strFindCourse);

        }
        protected void ShowData(string strFindCourse = "")
        {

            List<Course> Courses = _db.Courses.Include(c => c.Teacher).Where(s => s.NameOfCourse.Contains(strFindCourse)).ToList();
            GridViewCourse.DataSource = Courses;
            GridViewCourse.DataBind();
        }
    }
}